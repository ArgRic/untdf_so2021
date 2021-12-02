namespace ProcessScheduling.WinApp
{
    using System.Windows.Forms;

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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flpApp = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.policySelect = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.quantumLabel = new System.Windows.Forms.Label();
            this.quantumUpDown = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tcpUpDown = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tfpLabel = new System.Windows.Forms.Label();
            this.tfpUpDown = new System.Windows.Forms.NumericUpDown();
            this.tipPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tipLabel = new System.Windows.Forms.Label();
            this.tipUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.filenameLabel = new System.Windows.Forms.Label();
            this.loadFileButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.startButton = new System.Windows.Forms.Button();
            this.logPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvOutput = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.flpApp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantumUpDown)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcpUpDown)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tfpUpDown)).BeginInit();
            this.tipPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.logPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flpApp, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 447F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(769, 598);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // flpApp
            // 
            this.flpApp.Controls.Add(this.groupBox1);
            this.flpApp.Controls.Add(this.groupBox2);
            this.flpApp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpApp.Location = new System.Drawing.Point(2, 2);
            this.flpApp.Margin = new System.Windows.Forms.Padding(2);
            this.flpApp.Name = "flpApp";
            this.flpApp.Size = new System.Drawing.Size(765, 121);
            this.flpApp.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel4);
            this.groupBox1.Controls.Add(this.flowLayoutPanel3);
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.tipPanel);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(756, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CPU Config";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.label2);
            this.flowLayoutPanel4.Controls.Add(this.policySelect);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(10, 21);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(243, 30);
            this.flowLayoutPanel4.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Politica";
            // 
            // policySelect
            // 
            this.policySelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.policySelect.FormattingEnabled = true;
            this.policySelect.Location = new System.Drawing.Point(69, 3);
            this.policySelect.Name = "policySelect";
            this.policySelect.Size = new System.Drawing.Size(164, 23);
            this.policySelect.TabIndex = 6;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.quantumLabel);
            this.flowLayoutPanel3.Controls.Add(this.quantumUpDown);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(598, 21);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(154, 30);
            this.flowLayoutPanel3.TabIndex = 5;
            // 
            // quantumLabel
            // 
            this.quantumLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.quantumLabel.AutoSize = true;
            this.quantumLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.quantumLabel.Location = new System.Drawing.Point(3, 4);
            this.quantumLabel.Name = "quantumLabel";
            this.quantumLabel.Size = new System.Drawing.Size(75, 20);
            this.quantumLabel.TabIndex = 1;
            this.quantumLabel.Text = "Quantum";
            // 
            // quantumUpDown
            // 
            this.quantumUpDown.Location = new System.Drawing.Point(84, 3);
            this.quantumUpDown.Name = "quantumUpDown";
            this.quantumUpDown.Size = new System.Drawing.Size(46, 23);
            this.quantumUpDown.TabIndex = 0;
            this.quantumUpDown.Tag = "";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.tcpUpDown);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(361, 21);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(101, 30);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "TCP";
            // 
            // tcpUpDown
            // 
            this.tcpUpDown.Location = new System.Drawing.Point(44, 3);
            this.tcpUpDown.Name = "tcpUpDown";
            this.tcpUpDown.Size = new System.Drawing.Size(46, 23);
            this.tcpUpDown.TabIndex = 0;
            this.tcpUpDown.Tag = "";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.tfpLabel);
            this.flowLayoutPanel1.Controls.Add(this.tfpUpDown);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(468, 21);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(124, 30);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // tfpLabel
            // 
            this.tfpLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tfpLabel.AutoSize = true;
            this.tfpLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tfpLabel.Location = new System.Drawing.Point(3, 4);
            this.tfpLabel.Name = "tfpLabel";
            this.tfpLabel.Size = new System.Drawing.Size(35, 20);
            this.tfpLabel.TabIndex = 1;
            this.tfpLabel.Text = "TFP";
            // 
            // tfpUpDown
            // 
            this.tfpUpDown.Location = new System.Drawing.Point(44, 3);
            this.tfpUpDown.Name = "tfpUpDown";
            this.tfpUpDown.Size = new System.Drawing.Size(62, 23);
            this.tfpUpDown.TabIndex = 0;
            this.tfpUpDown.Tag = "";
            // 
            // tipPanel
            // 
            this.tipPanel.Controls.Add(this.tipLabel);
            this.tipPanel.Controls.Add(this.tipUpDown);
            this.tipPanel.Location = new System.Drawing.Point(259, 21);
            this.tipPanel.Name = "tipPanel";
            this.tipPanel.Size = new System.Drawing.Size(96, 30);
            this.tipPanel.TabIndex = 2;
            // 
            // tipLabel
            // 
            this.tipLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tipLabel.AutoSize = true;
            this.tipLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tipLabel.Location = new System.Drawing.Point(3, 4);
            this.tipLabel.Name = "tipLabel";
            this.tipLabel.Size = new System.Drawing.Size(32, 20);
            this.tipLabel.TabIndex = 1;
            this.tipLabel.Text = "TIP";
            // 
            // tipUpDown
            // 
            this.tipUpDown.Location = new System.Drawing.Point(41, 3);
            this.tipUpDown.Name = "tipUpDown";
            this.tipUpDown.Size = new System.Drawing.Size(46, 23);
            this.tipUpDown.TabIndex = 0;
            this.tipUpDown.Tag = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.filenameLabel);
            this.groupBox2.Controls.Add(this.loadFileButton);
            this.groupBox2.Location = new System.Drawing.Point(2, 71);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(752, 47);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File";
            // 
            // filenameLabel
            // 
            this.filenameLabel.Location = new System.Drawing.Point(150, 14);
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(597, 28);
            this.filenameLabel.TabIndex = 1;
            this.filenameLabel.Text = "Seleccionar Archivo";
            // 
            // loadFileButton
            // 
            this.loadFileButton.Location = new System.Drawing.Point(10, 14);
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.Size = new System.Drawing.Size(134, 23);
            this.loadFileButton.TabIndex = 0;
            this.loadFileButton.Text = "Seleccionar Archivo";
            this.loadFileButton.UseVisualStyleBackColor = true;
            this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.startButton);
            this.groupBox5.Controls.Add(this.logPanel);
            this.groupBox5.Location = new System.Drawing.Point(3, 131);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(757, 463);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Output  (Verde: CPU   Rojo: I/O   Gris: Ready   Naranja: Exit, Negro: Terminado)";
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(671, 0);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(80, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Iniciar";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // logPanel
            // 
            this.logPanel.Controls.Add(this.dgvOutput);
            this.logPanel.Location = new System.Drawing.Point(3, 22);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(750, 435);
            this.logPanel.TabIndex = 0;
            // 
            // dgvOutput
            // 
            this.dgvOutput.AllowUserToAddRows = false;
            this.dgvOutput.AllowUserToDeleteRows = false;
            this.dgvOutput.AllowUserToResizeRows = false;
            this.dgvOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutput.Location = new System.Drawing.Point(3, 3);
            this.dgvOutput.MultiSelect = false;
            this.dgvOutput.Name = "dgvOutput";
            this.dgvOutput.ReadOnly = true;
            this.dgvOutput.RowHeadersVisible = false;
            this.dgvOutput.RowHeadersWidth = 62;
            this.dgvOutput.RowTemplate.Height = 25;
            this.dgvOutput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvOutput.Size = new System.Drawing.Size(742, 429);
            this.dgvOutput.TabIndex = 0;
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 598);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "App";
            this.Text = "ProcessScheduler - Mansilla Ricardo";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flpApp.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantumUpDown)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcpUpDown)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tfpUpDown)).EndInit();
            this.tipPanel.ResumeLayout(false);
            this.tipPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.logPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flpApp;
        private GroupBox groupBox1;
        private FlowLayoutPanel flowLayoutPanel4;
        private Label label2;
        private ComboBox policySelect;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label quantumLabel;
        private NumericUpDown quantumUpDown;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label1;
        private NumericUpDown tcpUpDown;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label tfpLabel;
        private NumericUpDown tfpUpDown;
        private FlowLayoutPanel tipPanel;
        private Label tipLabel;
        private NumericUpDown tipUpDown;
        private GroupBox groupBox2;
        private Button loadFileButton;
        private Button startButton;
        private GroupBox groupBox5;
        private FlowLayoutPanel logPanel;
        private DataGridView dgvOutput;
        private Label filenameLabel;
    }
}