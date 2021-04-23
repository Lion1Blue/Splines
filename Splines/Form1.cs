using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System.Diagnostics;

namespace Splines
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridViewSplines.ColumnCount = 2;
            dataGridViewSplines.RowCount = 1;
            dataGridViewSplines.Columns[0].HeaderCell.Value = "x";
            dataGridViewSplines.Columns[1].HeaderCell.Value = "y";
            labelPolyDegreeOpenBSpline.Text = $"Degree: {trackBarOpenUniformBSpline.Value}";

            //Creating a Poltmodel
            myPlotModel = new PlotModel { Title = "Splines" };
            myPlotModel.Series.Add(new LineSeries());
            myPlotModel.Series.Add(new LineSeries());
            plotViewSplines.Model = myPlotModel;

            DrawAll();
            InitalizeMouseEvents(myPlotModel);

            plotViewSplines.MouseUp += PlotViewSplines_MouseUp;
        }

        int indexOfCurrentSelectedPoint = -1;
        bool onMouseHold = false;

        private void PlotViewSplines_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && onMouseHold)
            {
                onMouseHold = false;
            }
        }

        public Point[] GetPointsFromGrid(DataGridView dataGridView)
        {
            Point[] points = new Point[dataGridView.RowCount - 1];

            for (int i = 0; i < dataGridView.RowCount - 1; i++)
            {
                double x = Convert.ToDouble(dataGridView.Rows[i].Cells[0].Value);
                double y = Convert.ToDouble(dataGridView.Rows[i].Cells[1].Value);

                points[i] = new Point(x, y);
            }

            return points;
        }

        

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            DrawAll();
        }

        PlotModel myPlotModel;

        private void DrawAll()
        {
            Point[] points = GetPointsFromGrid(dataGridViewSplines);
            LineSeries controlPoints = new LineSeries();
            controlPoints.Title = "ControlPoints";
            controlPoints.LineStyle = checkBoxControlLine.Checked ? LineStyle.Dot : LineStyle.None;
            controlPoints.MarkerType = MarkerType.Circle;
            controlPoints.Color = OxyColors.Red;

            DrawSpline(myPlotModel);
            DrawControlPoints(myPlotModel, controlPoints, points);

            myPlotModel.InvalidatePlot(true);
        }

        public delegate Point SplineFunction(double t, Point[] points, int k);
        private void DrawSpline(PlotModel myModel)
        {
            Point[] points = GetPointsFromGrid(dataGridViewSplines);

            LineSeries splineLine = new LineSeries();
            splineLine.Title = currentSpline.ToString();
            splineLine.MarkerType = MarkerType.None;
            splineLine.Color = OxyColors.Blue;

            if (points.Length == 0)
            {
                myModel.Series[0] = splineLine;
                return;
            }

            SplineFunction splineFunction;
            float length;
            float start = 0;
            float dx = 0.001f;
            int k;

            switch (currentSpline)
            {
                case SplineType.Bezier:
                    splineFunction = Spline.Bezier;
                    length = 1;
                    start = 0;
                    dx = 0.001f;
                    k = points.Length - 1;
                    break;

                case SplineType.CatmullRom:
                    if (points.Length < 4)
                    {
                        labelError.Visible = true;
                        return;
                    }
                    labelError.Visible = false;
                    k = 0;
                    splineFunction = Spline.CatmullRom;
                    length = points.Length - 3f;
                    start = 0;
                    dx = 0.005f;
                    break;

                case SplineType.OpenUniformBSpline:
                    splineFunction = Spline.OpenUniformBSpline;
                    start = 0;
                    length = points.Length - trackBarOpenUniformBSpline.Value + 2;
                    dx = 0.005f;
                    k = trackBarOpenUniformBSpline.Value;
                    break;

                default:
                    return;
            }

            for (float t = start; t <= length; t += dx)
            {
                Point a = splineFunction(t, points, k);
                if (a != null)
                {
                    splineLine.Points.Add(new DataPoint(a.X, a.Y));
                }
            }

            myModel.Series[0] = splineLine;
        }
        private void InitalizeMouseEvents(PlotModel myModel)
        {
            Point[] points = GetPointsFromGrid(dataGridViewSplines);
            LineSeries controlPoints = new LineSeries();
            controlPoints.Title = "ControlPoints";
            controlPoints.LineStyle = checkBoxControlLine.Checked ? LineStyle.Dot : LineStyle.None;
            controlPoints.MarkerType = MarkerType.Circle;
            controlPoints.Color = OxyColors.Red;

            myModel.MouseDown += (s, e) =>
            {
                double x, y;

                Point[] points = GetPointsFromGrid(dataGridViewSplines);

                x = controlPoints.InverseTransform(e.Position).X;
                y = controlPoints.InverseTransform(e.Position).Y;

                //Get the the distance from two points 9 pixels apart
                ScreenPoint screenPointOne = new ScreenPoint(0, 0);
                ScreenPoint screenPointTwo = new ScreenPoint(7, 7);

                DataPoint dataPointOne = controlPoints.InverseTransform(screenPointOne);
                DataPoint dataPointTwo = controlPoints.InverseTransform(screenPointTwo);

                double dx = dataPointOne.X - dataPointTwo.X;
                double dy = dataPointOne.Y - dataPointTwo.Y;

                double distance = Math.Sqrt(dx * dx + dy * dy);

                int index;

                bool sucessfullGrap = IsInDistance(distance, points, new Point(x, y), out index);

                if (e.ChangedButton == OxyMouseButton.Right && sucessfullGrap)
                {
                    dataGridViewSplines.Rows.RemoveAt(index);
                    points = GetPointsFromGrid(dataGridViewSplines);
                    DrawSpline(myModel);
                    DrawControlPoints(myModel, controlPoints, points);
                    //Updates the View
                    myModel.InvalidatePlot(true);

                    return;
                }

                if (e.ChangedButton == OxyMouseButton.Left && !sucessfullGrap)
                {
                    AppendPointToDataGridView(dataGridViewSplines, new Point(x, y));
                    points = GetPointsFromGrid(dataGridViewSplines);
                    DrawSpline(myModel);
                    DrawControlPoints(myModel, controlPoints, points);
                    //Updates the View
                    myModel.InvalidatePlot(true);

                    return;
                }

                if (e.ChangedButton == OxyMouseButton.Left && sucessfullGrap)
                {
                    onMouseHold = true;
                    indexOfCurrentSelectedPoint = index;
                }

            };

            myModel.MouseMove += (s, e) =>
            {
                if (onMouseHold)
                {
                    Point[] points = GetPointsFromGrid(dataGridViewSplines);

                    double x, y;

                    x = controlPoints.InverseTransform(e.Position).X;
                    y = controlPoints.InverseTransform(e.Position).Y;

                    dataGridViewSplines.Rows[indexOfCurrentSelectedPoint].Cells[0].Value = x.ToString();
                    dataGridViewSplines.Rows[indexOfCurrentSelectedPoint].Cells[1].Value = y.ToString();

                    DrawSpline(myModel);
                    DrawControlPoints(myModel, controlPoints, points);
                    myModel.InvalidatePlot(true);
                }
            };


            trackBarOpenUniformBSpline.ValueChanged += (s, e) =>
            {
                labelPolyDegreeOpenBSpline.Text = $"Degree: {trackBarOpenUniformBSpline.Value}";

                if (currentSpline == SplineType.OpenUniformBSpline)
                {
                    DrawSpline(myPlotModel);
                    myPlotModel.InvalidatePlot(true);
                }
            };


            checkBoxControlLine.CheckedChanged += (s, e) =>
            {
                controlPoints.LineStyle = checkBoxControlLine.Checked ? LineStyle.Dot : LineStyle.None;
                Point[] points = GetPointsFromGrid(dataGridViewSplines);
                DrawControlPoints(myModel, controlPoints, points);
                myModel.InvalidatePlot(true);
            };

            DrawControlPoints(myModel, controlPoints, points);
        }

        private void AppendPointToDataGridView(DataGridView dataGridView, Point point)
        {
            dataGridView.RowCount++;
            dataGridView.Rows[dataGridView.RowCount - 2].Cells[0].Value = point.X.ToString();
            dataGridView.Rows[dataGridView.RowCount - 2].Cells[1].Value = point.Y.ToString();
        }

        private void DrawControlPoints(PlotModel myModel, LineSeries controlPoints, Point[] points)
        {
            controlPoints.Points.Clear();

            for (int i = 0; i < points.Length; i++)
            {
                controlPoints.Points.Add(new DataPoint(points[i].X, points[i].Y));
            }

            myModel.Series[1] = controlPoints;
        }

        public bool IsInDistance(double maxDistance, Point[] points, Point point, out int indexOfMin)
        {
            int currentIndex = 0;
            double currentMaxDistance = maxDistance;

            for (int i = 0; i < points.Length; i++)
            {
                double dx = points[i].X - point.X;
                double dy = points[i].Y - point.Y;

                double distance = Math.Sqrt(dx * dx + dy * dy);
                if (currentMaxDistance > distance)
                {
                    currentIndex = i;
                    currentMaxDistance = distance;
                }
            }

            if (maxDistance == currentMaxDistance)
            {
                indexOfMin = 0;
                return false;
            }


            indexOfMin = currentIndex;
            return true;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            dataGridViewSplines.RowCount = 1;
            DrawAll();
        }

        enum SplineType { Bezier, CatmullRom, OpenUniformBSpline };
        SplineType currentSpline = SplineType.Bezier;

        private void radioButtonBezier_Enter(object sender, EventArgs e)
        {
            currentSpline = SplineType.Bezier;
            labelError.Visible = false;
            DrawAll();
        }

        private void radioButtonCatmullRom_Enter(object sender, EventArgs e)
        {
            currentSpline = SplineType.CatmullRom;
            DrawAll();
            radioButtonCatmullRom.Checked = true;
        }

        private void labelError_Click(object sender, EventArgs e)
        {
            labelError.Visible = false;
        }

        private void radioButtonOpenUniformBSpline_Enter(object sender, EventArgs e)
        {
            currentSpline = SplineType.OpenUniformBSpline;
            DrawAll();
        }

        private void dataGridViewSplines_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridViewTextBox_KeyPress);
        }

        private void dataGridViewTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridViewTextBox_KeyPress(dataGridViewSplines, sender, e);
        }

        private void dataGridViewTextBox_KeyPress(DataGridView dataGraidView, object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '-'))
            {
                e.Handled = true;
            }
        }

        private void dataGridViewSplines_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.FormattedValue.ToString() != string.Empty && !decimal.TryParse(e.FormattedValue.ToString(), out decimal value))
            {
                e.Cancel = true;
            }
        }
    }
}
