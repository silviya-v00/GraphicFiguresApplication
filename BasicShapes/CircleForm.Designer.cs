using System;
namespace BasicShapes
{
    partial class CircleForm
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
            this.statusStrip2Scene = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelPerimeter = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1Scene = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelArea = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip2Scene.SuspendLayout();
            this.statusStrip1Scene.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip2Scene
            // 
            this.statusStrip2Scene.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip2Scene.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelPerimeter});
            this.statusStrip2Scene.Location = new System.Drawing.Point(0, 424);
            this.statusStrip2Scene.Name = "statusStrip2Scene";
            this.statusStrip2Scene.Size = new System.Drawing.Size(800, 26);
            this.statusStrip2Scene.TabIndex = 2;
            this.statusStrip2Scene.Text = "statusStripPerimeter";
            // 
            // toolStripStatusLabelPerimeter
            // 
            this.toolStripStatusLabelPerimeter.Name = "toolStripStatusLabelPerimeter";
            this.toolStripStatusLabelPerimeter.Size = new System.Drawing.Size(112, 20);
            this.toolStripStatusLabelPerimeter.Text = "Total Perimeter:";
            // 
            // statusStrip1Scene
            // 
            this.statusStrip1Scene.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1Scene.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelArea});
            this.statusStrip1Scene.Location = new System.Drawing.Point(0, 398);
            this.statusStrip1Scene.Name = "statusStrip1Scene";
            this.statusStrip1Scene.Size = new System.Drawing.Size(800, 26);
            this.statusStrip1Scene.TabIndex = 3;
            this.statusStrip1Scene.Text = "statusStrip1";
            // 
            // toolStripStatusLabelArea
            // 
            this.toolStripStatusLabelArea.Name = "toolStripStatusLabelArea";
            this.toolStripStatusLabelArea.Size = new System.Drawing.Size(80, 20);
            this.toolStripStatusLabelArea.Text = "Total Area:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Draw a circle by clicking right button.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(337, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Click on any circle and press DEL button to delete it.";
            // 
            // CircleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1Scene);
            this.Controls.Add(this.statusStrip2Scene);
            this.Name = "CircleForm";
            this.Text = "CircleForm";
            this.Load += new System.EventHandler(this.CircleForm_Load_1);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CircleForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CircleForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CircleForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CircleForm_MouseUp);
            this.statusStrip2Scene.ResumeLayout(false);
            this.statusStrip2Scene.PerformLayout();
            this.statusStrip1Scene.ResumeLayout(false);
            this.statusStrip1Scene.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip2Scene;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelPerimeter;
        private System.Windows.Forms.StatusStrip statusStrip1Scene;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}