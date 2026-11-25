namespace HospitalManagementSystem
{
    partial class Form1
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
            button1 = new Button();
            comboBox1 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            splitContainer1 = new SplitContainer();
            dataGridView1 = new DataGridView();
            doctor = new DataGridViewTextBoxColumn();
            doctor2 = new DataGridViewTextBoxColumn();
            dataGridView2 = new DataGridView();
            besho = new DataGridViewTextBoxColumn();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(288, 158);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "login";
            button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Mina", "magdy" });
            comboBox1.Location = new Point(0, 0);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(429, 201);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 2;
            dateTimePicker1.Value = new DateTime(2026, 11, 19, 0, 0, 0, 0);
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(437, 209);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Size = new Size(187, 125);
            splitContainer1.SplitterDistance = 62;
            splitContainer1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { doctor, doctor2 });
            dataGridView1.Location = new Point(52, 209);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(502, 188);
            dataGridView1.TabIndex = 0;
            // 
            // doctor
            // 
            doctor.HeaderText = "Column1";
            doctor.MinimumWidth = 6;
            doctor.Name = "doctor";
            doctor.Width = 125;
            // 
            // doctor2
            // 
            doctor2.HeaderText = "mario";
            doctor2.MinimumWidth = 6;
            doctor2.Name = "doctor2";
            doctor2.Width = 125;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { besho });
            dataGridView2.Location = new Point(415, 7);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(390, 188);
            dataGridView2.TabIndex = 4;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // besho
            // 
            besho.HeaderText = "osama";
            besho.MinimumWidth = 6;
            besho.Name = "besho";
            besho.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(243, 58);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 5;
            label1.Text = "name";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(splitContainer1);
            Controls.Add(dateTimePicker1);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePicker1;
        private SplitContainer splitContainer1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn doctor;
        private DataGridViewTextBoxColumn doctor2;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn besho;
        private Label label1;
    }
}