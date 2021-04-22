
namespace Splines
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewSplines = new System.Windows.Forms.DataGridView();
            this.plotViewSplines = new OxyPlot.WindowsForms.PlotView();
            this.buttonDraw = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.checkBoxControlLine = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelPolyDegreeOpenBSpline = new System.Windows.Forms.Label();
            this.trackBarOpenUniformBSpline = new System.Windows.Forms.TrackBar();
            this.radioButtonOpenUniformBSpline = new System.Windows.Forms.RadioButton();
            this.radioButtonCatmullRom = new System.Windows.Forms.RadioButton();
            this.radioButtonBezier = new System.Windows.Forms.RadioButton();
            this.labelError = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSplines)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpenUniformBSpline)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewSplines
            // 
            this.dataGridViewSplines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSplines.Location = new System.Drawing.Point(11, 10);
            this.dataGridViewSplines.Name = "dataGridViewSplines";
            this.dataGridViewSplines.RowTemplate.Height = 25;
            this.dataGridViewSplines.Size = new System.Drawing.Size(272, 228);
            this.dataGridViewSplines.TabIndex = 0;
            // 
            // plotViewSplines
            // 
            this.plotViewSplines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotViewSplines.Location = new System.Drawing.Point(324, 12);
            this.plotViewSplines.Name = "plotViewSplines";
            this.plotViewSplines.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotViewSplines.Size = new System.Drawing.Size(734, 598);
            this.plotViewSplines.TabIndex = 1;
            this.plotViewSplines.Text = "plotView1";
            this.plotViewSplines.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotViewSplines.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotViewSplines.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // buttonDraw
            // 
            this.buttonDraw.Location = new System.Drawing.Point(11, 244);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(75, 23);
            this.buttonDraw.TabIndex = 2;
            this.buttonDraw.Text = "Draw";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(92, 244);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // checkBoxControlLine
            // 
            this.checkBoxControlLine.AutoSize = true;
            this.checkBoxControlLine.Location = new System.Drawing.Point(173, 247);
            this.checkBoxControlLine.Name = "checkBoxControlLine";
            this.checkBoxControlLine.Size = new System.Drawing.Size(88, 19);
            this.checkBoxControlLine.TabIndex = 4;
            this.checkBoxControlLine.Text = "ControlLine";
            this.checkBoxControlLine.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelPolyDegreeOpenBSpline);
            this.groupBox1.Controls.Add(this.trackBarOpenUniformBSpline);
            this.groupBox1.Controls.Add(this.radioButtonOpenUniformBSpline);
            this.groupBox1.Controls.Add(this.radioButtonCatmullRom);
            this.groupBox1.Controls.Add(this.radioButtonBezier);
            this.groupBox1.Location = new System.Drawing.Point(11, 273);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 119);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Splines";
            // 
            // labelPolyDegreeOpenBSpline
            // 
            this.labelPolyDegreeOpenBSpline.AutoSize = true;
            this.labelPolyDegreeOpenBSpline.Location = new System.Drawing.Point(123, 76);
            this.labelPolyDegreeOpenBSpline.Name = "labelPolyDegreeOpenBSpline";
            this.labelPolyDegreeOpenBSpline.Size = new System.Drawing.Size(50, 15);
            this.labelPolyDegreeOpenBSpline.TabIndex = 7;
            this.labelPolyDegreeOpenBSpline.Text = "Degree: ";
            // 
            // trackBarOpenUniformBSpline
            // 
            this.trackBarOpenUniformBSpline.LargeChange = 1;
            this.trackBarOpenUniformBSpline.Location = new System.Drawing.Point(174, 71);
            this.trackBarOpenUniformBSpline.Maximum = 5;
            this.trackBarOpenUniformBSpline.Minimum = 1;
            this.trackBarOpenUniformBSpline.Name = "trackBarOpenUniformBSpline";
            this.trackBarOpenUniformBSpline.Size = new System.Drawing.Size(96, 45);
            this.trackBarOpenUniformBSpline.TabIndex = 6;
            this.trackBarOpenUniformBSpline.Value = 2;
            // 
            // radioButtonOpenUniformBSpline
            // 
            this.radioButtonOpenUniformBSpline.AutoSize = true;
            this.radioButtonOpenUniformBSpline.Location = new System.Drawing.Point(7, 72);
            this.radioButtonOpenUniformBSpline.Name = "radioButtonOpenUniformBSpline";
            this.radioButtonOpenUniformBSpline.Size = new System.Drawing.Size(97, 19);
            this.radioButtonOpenUniformBSpline.TabIndex = 5;
            this.radioButtonOpenUniformBSpline.Text = "open B Spline";
            this.radioButtonOpenUniformBSpline.UseVisualStyleBackColor = true;
            this.radioButtonOpenUniformBSpline.Enter += new System.EventHandler(this.radioButtonOpenUniformBSpline_Enter);
            // 
            // radioButtonCatmullRom
            // 
            this.radioButtonCatmullRom.AutoSize = true;
            this.radioButtonCatmullRom.Location = new System.Drawing.Point(7, 49);
            this.radioButtonCatmullRom.Name = "radioButtonCatmullRom";
            this.radioButtonCatmullRom.Size = new System.Drawing.Size(95, 19);
            this.radioButtonCatmullRom.TabIndex = 1;
            this.radioButtonCatmullRom.Text = "Catmull Rom";
            this.radioButtonCatmullRom.UseVisualStyleBackColor = true;
            this.radioButtonCatmullRom.Enter += new System.EventHandler(this.radioButtonCatmullRom_Enter);
            // 
            // radioButtonBezier
            // 
            this.radioButtonBezier.AutoSize = true;
            this.radioButtonBezier.Checked = true;
            this.radioButtonBezier.Location = new System.Drawing.Point(7, 23);
            this.radioButtonBezier.Name = "radioButtonBezier";
            this.radioButtonBezier.Size = new System.Drawing.Size(56, 19);
            this.radioButtonBezier.TabIndex = 0;
            this.radioButtonBezier.TabStop = true;
            this.radioButtonBezier.Text = "Bezier";
            this.radioButtonBezier.UseVisualStyleBackColor = true;
            this.radioButtonBezier.Enter += new System.EventHandler(this.radioButtonBezier_Enter);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(15, 401);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(238, 50);
            this.labelError.TabIndex = 6;
            this.labelError.Text = "Catmull-Rom Spline must\r\nconsist of min. 4 Points";
            this.labelError.Visible = false;
            this.labelError.Click += new System.EventHandler(this.labelError_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewSplines);
            this.panel1.Controls.Add(this.labelError);
            this.panel1.Controls.Add(this.buttonDraw);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.buttonClear);
            this.panel1.Controls.Add(this.checkBoxControlLine);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 600);
            this.panel1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 628);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.plotViewSplines);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSplines)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpenUniformBSpline)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSplines;
        private OxyPlot.WindowsForms.PlotView plotViewSplines;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.CheckBox checkBoxControlLine;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonCatmullRom;
        private System.Windows.Forms.RadioButton radioButtonBezier;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelPolyDegreeOpenBSpline;
        private System.Windows.Forms.TrackBar trackBarOpenUniformBSpline;
        private System.Windows.Forms.RadioButton radioButtonOpenUniformBSpline;
        private System.Windows.Forms.Panel panel1;
    }
}

