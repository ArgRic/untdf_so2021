namespace ProcessScheduling.WinApp
{
    partial class App
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
            this.flpApp = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.flpApp.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpApp
            // 
            this.flpApp.Controls.Add(this.titleLabel);
            this.flpApp.Controls.Add(this.groupBox1);
            this.flpApp.Controls.Add(this.groupBox2);
            this.flpApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpApp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpApp.Location = new System.Drawing.Point(0, 0);
            this.flpApp.Name = "flpApp";
            this.flpApp.Size = new System.Drawing.Size(1465, 638);
            this.flpApp.TabIndex = 0;
            this.flpApp.WrapContents = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(3, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(3, 197);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 150);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.Location = new System.Drawing.Point(3, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(347, 38);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Planificador de Procesador";
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1465, 638);
            this.Controls.Add(this.flpApp);
            this.Name = "App";
            this.Text = "UNTDF - SO 2021 - Gestor de Procesos";
            this.flpApp.ResumeLayout(false);
            this.flpApp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flpApp;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label titleLabel;
    }
}