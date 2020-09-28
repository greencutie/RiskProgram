using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace CourseWork
{
    public partial class RiskEstimate : Form
    {
        public RiskEstimate()
        {
            InitializeComponent();
            #region Добавление таблицы со значениями рисков
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = "Вероятность";
            this.dataGridView1.Rows.Add(5);
            dataGridView1.Rows[1].Cells[0].Value = 0.9;
            dataGridView1.Rows[2].Cells[0].Value = 0.7;
            dataGridView1.Rows[3].Cells[0].Value = 0.5;
            dataGridView1.Rows[4].Cells[0].Value = 0.3;
            dataGridView1.Rows[5].Cells[0].Value = 0.1;
            for(int i = 1; i < 6; i++)
            {
                for(int j = 2; j < 7; j++)
                {
                    double n = Convert.ToDouble(dataGridView1.Columns[j].HeaderText);
                    dataGridView1.Rows[i].Cells[j].Value = (double)dataGridView1.Rows[i].Cells[0].Value * n;
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Green;
                    if ((double)dataGridView1.Rows[i].Cells[j].Value >= 0.04) dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Yellow;//Color.Orange;
                    if ((double)dataGridView1.Rows[i].Cells[j].Value >= 0.18) dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Red;
                }
            }
            toolStripTextBox1.Text = "0,04";
            toolStripTextBox2.Text = "0,18";

            dataGridView1.Rows.Add();
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.OldLace;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = "";

            dataGridView1.Rows.Add();
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.OldLace;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = "";

            dataGridView1.Rows.Add();
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.OldLace;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = "";
            #endregion

            this.dataGridView1.Rows.Add();
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.PowderBlue;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = "Названия риска";
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = "Источник риска";
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = "Последствия риска";
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = "Описание риска";
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value = "Оценка риска";
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[5].Value = "Вероятность риска";
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[6].Value = "Воздействие риска";

        }

        private void redraw_table(double min, double max)
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = 2; j < 7; j++)
                {
                    double n = Convert.ToDouble(dataGridView1.Columns[j].HeaderText);
                    dataGridView1.Rows[i].Cells[j].Value = (double)dataGridView1.Rows[i].Cells[0].Value * n;
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Green;
                    if ((double)dataGridView1.Rows[i].Cells[j].Value >= min) dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Yellow;//Color.Orange;
                    if ((double)dataGridView1.Rows[i].Cells[j].Value >= max) dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Red;
                }
            }
            for (int ns = 10; ns < dataGridView1.Rows.Count; ns++)// перебираем столбцы (перебирая системы)
            {
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Green;
                if ((double)dataGridView1.Rows[ns].Cells[4].Value >= min) dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Yellow;
                if ((double)dataGridView1.Rows[ns].Cells[4].Value >= max) dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Red;


            }
        }


        public void addselectedrisk(DataGridView d, double v, double ver, double vozd, string str)
        {
            this.dataGridView1.Rows.Add();
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = d.CurrentRow.Cells[1].Value;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = d.CurrentRow.Cells[2].Value;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = d.CurrentRow.Cells[3].Value;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = d.CurrentRow.Cells[4].Value;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value = v;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[5].Value = ver;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[6].Value = vozd;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[7].Value = str;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Green;
            if ((double)dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value >= 0.04) dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Yellow;
            if ((double)dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value >= 0.18) dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Red;
        }

        private void RiskEstimate_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///Рисуем карту рисков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void draw_risk_Click(object sender, EventArgs e)
        {
            try
            {

                DataSender ds = new DataSender();
                ds.n = 1;
                ds.points = new List<ColorPoint>();
                double scalecoeff = 50;

                // проходимся по дереву выбранных атрибутов, берем значение вероятности и влияния для выбранного элемента 
                for (int ns = 10; ns < dataGridView1.Rows.Count; ns++)// перебираем столбцы (перебирая системы)
                {
                    double x = (double)dataGridView1.Rows[ns].Cells[5].Value; // вероятность
                    double y = (double)dataGridView1.Rows[ns].Cells[6].Value; // влияние
                    string name = $"{dataGridView1.Rows[ns].Cells[1].Value}\r\n{dataGridView1.Rows[ns].Cells[2].Value}\r\n{dataGridView1.Rows[ns].Cells[3].Value}\r\n{dataGridView1.Rows[ns].Cells[4].Value}\r\n";// $"Система - {rsk[ns - 1]}, \r\nЭлемент - {(string)dataGridView3.Rows[oldrowindex].Cells[0].Value}, \r\nАтрибут - {(string)dataGridView3.Rows[i + oldrowindex].Cells[0].Value}";

                    ColorPoint cp = new ColorPoint(x, y, 10/*Радиус точки для отрисовки*/, name, dataGridView1.Rows[ns].DefaultCellStyle.BackColor, scalecoeff);

                    ds.points.Add(cp);
                    
                }
                FormGraphics fr = new FormGraphics(ds, $"Карта рисков\"{""}\"", own: this);
                fr.Show();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            draw_risk_Click(sender, e);
        }

        private void оценитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(toolStripTextBox1.Text) < 0 || double.Parse(toolStripTextBox1.Text) >= 1) throw new Exception();
                if (double.Parse(toolStripTextBox2.Text) < 0 || double.Parse(toolStripTextBox2.Text) >= 1) throw new Exception();
                redraw_table(double.Parse(toolStripTextBox1.Text), double.Parse(toolStripTextBox2.Text));
            }
            catch
            {
                MessageBox.Show("Wrong value of MIN-MAX parameters");
            }
        }

        private void оценитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            оценитьToolStripMenuItem1_Click(sender, e);
        }
    }
}
