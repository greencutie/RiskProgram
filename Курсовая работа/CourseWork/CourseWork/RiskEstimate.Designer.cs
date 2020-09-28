namespace CourseWork
{
    partial class RiskEstimate
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.переоценкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нижняяГраницаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.значениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.оценитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.верхняяГраницаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.значениеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.оценитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Random = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Step = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Random,
            this.Step,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(800, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.переоценкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(66, 20);
            this.toolStripMenuItem1.Text = "Оценить";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // переоценкаToolStripMenuItem
            // 
            this.переоценкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.нижняяГраницаToolStripMenuItem,
            this.верхняяГраницаToolStripMenuItem});
            this.переоценкаToolStripMenuItem.Name = "переоценкаToolStripMenuItem";
            this.переоценкаToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.переоценкаToolStripMenuItem.Text = "Переоценка";
            // 
            // нижняяГраницаToolStripMenuItem
            // 
            this.нижняяГраницаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.значениеToolStripMenuItem,
            this.toolStripTextBox1,
            this.оценитьToolStripMenuItem1});
            this.нижняяГраницаToolStripMenuItem.Name = "нижняяГраницаToolStripMenuItem";
            this.нижняяГраницаToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.нижняяГраницаToolStripMenuItem.Text = "Нижняя граница";
            // 
            // значениеToolStripMenuItem
            // 
            this.значениеToolStripMenuItem.Name = "значениеToolStripMenuItem";
            this.значениеToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.значениеToolStripMenuItem.Text = "Значение:";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            // 
            // оценитьToolStripMenuItem1
            // 
            this.оценитьToolStripMenuItem1.Name = "оценитьToolStripMenuItem1";
            this.оценитьToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.оценитьToolStripMenuItem1.Text = "Оценить";
            this.оценитьToolStripMenuItem1.Click += new System.EventHandler(this.оценитьToolStripMenuItem1_Click);
            // 
            // верхняяГраницаToolStripMenuItem
            // 
            this.верхняяГраницаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.значениеToolStripMenuItem1,
            this.toolStripTextBox2,
            this.оценитьToolStripMenuItem});
            this.верхняяГраницаToolStripMenuItem.Name = "верхняяГраницаToolStripMenuItem";
            this.верхняяГраницаToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.верхняяГраницаToolStripMenuItem.Text = "Верхняя граница";
            // 
            // значениеToolStripMenuItem1
            // 
            this.значениеToolStripMenuItem1.Name = "значениеToolStripMenuItem1";
            this.значениеToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.значениеToolStripMenuItem1.Text = "Значение:";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 23);
            // 
            // оценитьToolStripMenuItem
            // 
            this.оценитьToolStripMenuItem.Name = "оценитьToolStripMenuItem";
            this.оценитьToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.оценитьToolStripMenuItem.Text = "Оценить";
            this.оценитьToolStripMenuItem.Click += new System.EventHandler(this.оценитьToolStripMenuItem_Click);
            // 
            // Random
            // 
            this.Random.HeaderText = "";
            this.Random.Name = "Random";
            this.Random.ReadOnly = true;
            this.Random.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Step
            // 
            this.Step.HeaderText = "Степень воздействия";
            this.Step.Name = "Step";
            this.Step.ReadOnly = true;
            this.Step.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "0,05";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "0,1";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "0,2";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "0,4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "0,8";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RiskEstimate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RiskEstimate";
            this.Text = "RiskEstimate";
            this.Load += new System.EventHandler(this.RiskEstimate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion



        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem переоценкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem нижняяГраницаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem значениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem оценитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem верхняяГраницаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem значениеToolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripMenuItem оценитьToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Random;
        private System.Windows.Forms.DataGridViewTextBoxColumn Step;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}