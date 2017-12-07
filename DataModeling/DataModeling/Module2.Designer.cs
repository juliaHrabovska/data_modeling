namespace DataModeling
{
    partial class Module2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.readToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveInDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartInterpolation = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.checkBoxInterpolationMethod1 = new System.Windows.Forms.CheckBox();
            this.checkBoxInterpolationMethod2 = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonSaveInDB = new System.Windows.Forms.Button();
            this.labelInfoLagrange = new System.Windows.Forms.Label();
            this.labelInfoNewton = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartInterpolation)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readToolStripMenuItem,
            this.saveInDBToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(805, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // readToolStripMenuItem
            // 
            this.readToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromFileToolStripMenuItem,
            this.fromDBToolStripMenuItem});
            this.readToolStripMenuItem.Name = "readToolStripMenuItem";
            this.readToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.readToolStripMenuItem.Text = "Read";
            // 
            // fromFileToolStripMenuItem
            // 
            this.fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
            this.fromFileToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.fromFileToolStripMenuItem.Text = "From file";
            this.fromFileToolStripMenuItem.Click += new System.EventHandler(this.fromFileToolStripMenuItem_Click);
            // 
            // fromDBToolStripMenuItem
            // 
            this.fromDBToolStripMenuItem.Name = "fromDBToolStripMenuItem";
            this.fromDBToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.fromDBToolStripMenuItem.Text = "From DB";
            // 
            // saveInDBToolStripMenuItem
            // 
            this.saveInDBToolStripMenuItem.Name = "saveInDBToolStripMenuItem";
            this.saveInDBToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // chartInterpolation
            // 
            chartArea2.Name = "ChartArea1";
            this.chartInterpolation.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartInterpolation.Legends.Add(legend2);
            this.chartInterpolation.Location = new System.Drawing.Point(220, 27);
            this.chartInterpolation.Name = "chartInterpolation";
            this.chartInterpolation.Size = new System.Drawing.Size(573, 384);
            this.chartInterpolation.TabIndex = 1;
            this.chartInterpolation.Text = "chart1";
            // 
            // checkBoxInterpolationMethod1
            // 
            this.checkBoxInterpolationMethod1.AutoSize = true;
            this.checkBoxInterpolationMethod1.Location = new System.Drawing.Point(12, 72);
            this.checkBoxInterpolationMethod1.Name = "checkBoxInterpolationMethod1";
            this.checkBoxInterpolationMethod1.Size = new System.Drawing.Size(71, 17);
            this.checkBoxInterpolationMethod1.TabIndex = 2;
            this.checkBoxInterpolationMethod1.Text = "Lagrange";
            this.checkBoxInterpolationMethod1.UseVisualStyleBackColor = true;
            this.checkBoxInterpolationMethod1.CheckedChanged += new System.EventHandler(this.checkBoxInterpolationMethod1_CheckedChanged);
            // 
            // checkBoxInterpolationMethod2
            // 
            this.checkBoxInterpolationMethod2.AutoSize = true;
            this.checkBoxInterpolationMethod2.Location = new System.Drawing.Point(118, 72);
            this.checkBoxInterpolationMethod2.Name = "checkBoxInterpolationMethod2";
            this.checkBoxInterpolationMethod2.Size = new System.Drawing.Size(63, 17);
            this.checkBoxInterpolationMethod2.TabIndex = 3;
            this.checkBoxInterpolationMethod2.Text = "Newton";
            this.checkBoxInterpolationMethod2.UseVisualStyleBackColor = true;
            this.checkBoxInterpolationMethod2.CheckedChanged += new System.EventHandler(this.checkBoxInterpolationMethod2_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonSaveInDB
            // 
            this.buttonSaveInDB.Location = new System.Drawing.Point(45, 372);
            this.buttonSaveInDB.Name = "buttonSaveInDB";
            this.buttonSaveInDB.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveInDB.TabIndex = 4;
            this.buttonSaveInDB.Text = "Save in DB";
            this.buttonSaveInDB.UseVisualStyleBackColor = true;
            this.buttonSaveInDB.Click += new System.EventHandler(this.buttonSaveInDB_Click);
            // 
            // labelInfoLagrange
            // 
            this.labelInfoLagrange.AutoSize = true;
            this.labelInfoLagrange.Location = new System.Drawing.Point(13, 115);
            this.labelInfoLagrange.Name = "labelInfoLagrange";
            this.labelInfoLagrange.Size = new System.Drawing.Size(75, 13);
            this.labelInfoLagrange.TabIndex = 5;
            this.labelInfoLagrange.Text = "Lagrange info:";
            // 
            // labelInfoNewton
            // 
            this.labelInfoNewton.AutoSize = true;
            this.labelInfoNewton.Location = new System.Drawing.Point(115, 115);
            this.labelInfoNewton.Name = "labelInfoNewton";
            this.labelInfoNewton.Size = new System.Drawing.Size(67, 13);
            this.labelInfoNewton.TabIndex = 6;
            this.labelInfoNewton.Text = "Newton info:";
            // 
            // Module2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 423);
            this.Controls.Add(this.labelInfoNewton);
            this.Controls.Add(this.labelInfoLagrange);
            this.Controls.Add(this.buttonSaveInDB);
            this.Controls.Add(this.checkBoxInterpolationMethod2);
            this.Controls.Add(this.checkBoxInterpolationMethod1);
            this.Controls.Add(this.chartInterpolation);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Module2";
            this.Text = "Module2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartInterpolation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem readToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromDBToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartInterpolation;
        private System.Windows.Forms.CheckBox checkBoxInterpolationMethod1;
        private System.Windows.Forms.CheckBox checkBoxInterpolationMethod2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveInDBToolStripMenuItem;
        private System.Windows.Forms.Button buttonSaveInDB;
        private System.Windows.Forms.Label labelInfoLagrange;
        private System.Windows.Forms.Label labelInfoNewton;
    }
}