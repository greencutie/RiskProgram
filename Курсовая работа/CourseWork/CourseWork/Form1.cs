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
using System.Data.OleDb;
namespace CourseWork
{
    public partial class Form1 : Form
    {
       
        int[] TimeArray = new int[0];
        int[] TimeArrayp = new int[0];
        int[] FinanceArray = new int[0];
        int[] FinanceArrayp = new int[0];
        int[] StaffArray = new int[0];
        int[] StaffArrayp = new int[0];
        int[] QualityArray = new int[0];
        int[] QualityArrayp = new int[0];
        

        RiskEstimate form2 = new RiskEstimate();

        int[] getarrtype()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        return TimeArray;
                        break;
                    }
                case 1:
                    {
                        return FinanceArray;
                        break;
                    }
                case 2:
                    {
                        return StaffArray;
                        break;
                    }
                case 3:
                    {
                        return QualityArray;
                        break;
                    }
            }
            return null;
        }

        int[] getarrptype()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        return TimeArrayp;
                        break;
                    }
                case 1:
                    {
                        return FinanceArrayp;
                        break;
                    }
                case 2:
                    {
                        return StaffArrayp;
                        break;
                    }
                case 3:
                    {
                        return QualityArrayp;
                        break;
                    }
            }
            return null;
        }

        void resizearrs()
        {

            if (TimeArray.Length < time_risksBindingSource.Count) Array.Resize(ref TimeArray, time_risksBindingSource.Count);
            if (TimeArrayp.Length < time_risksBindingSource.Count) Array.Resize(ref TimeArrayp, time_risksBindingSource.Count);
            if (FinanceArray.Length < financial_risksBindingSource.Count) Array.Resize(ref FinanceArray, financial_risksBindingSource.Count);
            if (FinanceArrayp.Length < financial_risksBindingSource.Count) Array.Resize(ref FinanceArrayp, financial_risksBindingSource.Count);
            if (StaffArray.Length < staff_risksBindingSource.Count) Array.Resize(ref StaffArray, staff_risksBindingSource.Count);
            if (StaffArrayp.Length < staff_risksBindingSource.Count) Array.Resize(ref StaffArrayp, staff_risksBindingSource.Count);
            if (QualityArray.Length < quality_risksBindingSource.Count) Array.Resize(ref QualityArray, quality_risksBindingSource.Count);
            if (QualityArrayp.Length < quality_risksBindingSource.Count) Array.Resize(ref QualityArrayp, quality_risksBindingSource.Count);

        }

        int getcr(DataGridViewRow CurrRow1 = null)
        {
            if (CurrRow1 == null) CurrRow1 = dataGridView2.CurrentRow;
            return (int)CurrRow1.Cells[0].Value - 1;
        }

        public Form1()
        {
            InitializeComponent();
            comboBox2.SelectedIndex = 0;
            Text = "Identification";
            comboBox3.Visible = false;
            label7.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            label11.Visible = false;
            label10.Visible = false;
            label9.Visible = false;
            label8.Visible = false;
            button5.Visible = false;

        }

        public void Form1_Update()
        {

        }

        /// <summary>
        /// Remove all
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите сбросить все риски?", "Внимание!", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                int[] arr = null;
                arr = TimeArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = 0;
                }
                arr = FinanceArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = 0;
                }
                arr = StaffArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = 0;
                }
                arr = QualityArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = 0;
                }
                var table = dataGridView2;
                while (table.Rows.Count > 0)
                    table.Rows.Remove(table.Rows[0]);

                table = dataGridView3;
                employer1TableAdapter.Fill(risk_databaseDataSet.Employer1);
                while (table.Rows.Count > 0)
                    table.Rows.Remove(table.Rows[0]);
                employer1BindingSource.EndEdit();
                employer1TableAdapter.Update(risk_databaseDataSet.Employer1);


                table = dataGridView5;
                employer2TableAdapter.Fill(risk_databaseDataSet.Employer2);
                while (table.Rows.Count > 0)
                    table.Rows.Remove(table.Rows[0]);
                employer2BindingSource.EndEdit();
                employer2TableAdapter.Update(risk_databaseDataSet.Employer2);

                table = dataGridView4;
                employer3TableAdapter.Fill(risk_databaseDataSet.Employer3);
                while (table.Rows.Count > 0)
                    table.Rows.Remove(table.Rows[0]);
                employer3BindingSource.EndEdit();
                employer3TableAdapter.Update(risk_databaseDataSet.Employer3);

                comboBox1_SelectedIndexChanged(sender, e);
            }
            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }
        }


        public void CheckEntry()
        {
            if (WhoEntered == 1)
            {
                dataGridView1.Visible = false;
                comboBox1.Visible = false;
                dataGridView2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                button1.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                button2.Visible = false;
                dataGridView3.Visible = true;
                dataGridView4.Visible = false;
                dataGridView5.Visible = false;
                button3.Visible = false;
                comboBox2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                button4.Visible = true;
                label6.Visible = true;
                dataGridView3.Location = new Point(12, 98);
                label6.Location = new Point(12, 82);
                comboBox2.Location = new Point(683,113);
                button4.Location = new Point(709, 206);
                label3.Location = new Point(684, 157);
                label4.Location = new Point(684, 183);
                textBox3.Location = new Point(759, 154);
                textBox4.Location = new Point(759, 180);
                this.Size = new Size(841, 331);
            }
            if (WhoEntered == 3)
            {
                dataGridView1.Visible = false;
                comboBox1.Visible = false;
                dataGridView2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                button1.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                button2.Visible = false;
                dataGridView3.Visible = false;
                dataGridView4.Visible = false;
                dataGridView5.Visible = true;
                button3.Visible = false;
                comboBox2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                button4.Visible = true;
                label6.Visible = true;
            }
            if (WhoEntered == 2)
            {
                dataGridView1.Visible = false;
                comboBox1.Visible = false;
                dataGridView2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                button1.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                button2.Visible = false;
                dataGridView3.Visible = false;
                dataGridView4.Visible = true;
                dataGridView5.Visible = false;
                button3.Visible = false;
                comboBox2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                button4.Visible = true;
                label6.Visible = true;
                
            }
            if (WhoEntered == 4)
            {
                dataGridView1.Visible = true;
                comboBox1.Visible = true;
                dataGridView2.Visible = true;
                label1.Visible = false;
                label2.Visible = false;
                button1.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                button2.Visible = true;
                dataGridView3.Visible = false;
                dataGridView4.Visible = false;
                dataGridView5.Visible = false;
                button3.Visible = true;
                label5.Visible = true;
                comboBox3.Visible = true;
                label7.Visible = true;
                button5.Visible = true;
                label6.Visible = false;
                comboBox2.Visible = false;
                button4.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                this.Size = new Size(841,581);
            }
            else
            {

                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                button5.Visible = false;
            }
        }

        public int WhoEntered;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {

                //if (textBox1.Text == "E1" && textBox2.Text == "EP1")
                //{
                //    MessageBox.Show("Entry Succeded, Employer1!");
                //    WhoEntered = 1;
                //    CheckEntry();
                //    return;
                //}
                //if (textBox1.Text == "E2" && textBox2.Text == "EP2")
                //{
                //    MessageBox.Show("Entry Succeded, Employer2!");
                //    WhoEntered = 2;
                //    CheckEntry();
                //    return;
                //}
                //if (textBox1.Text == "E3" && textBox2.Text == "EP3")
                //{
                //    MessageBox.Show("Entry Succeded, Employer3!");
                //    WhoEntered = 3;
                //    CheckEntry();
                //    return;
                //}
                if (textBox1.Text == "admin" && textBox2.Text == "password")
            {
                MessageBox.Show("Entry Succeded!");
                WhoEntered = 4;
                CheckEntry();
                return;
            }
            
            else
            {
                MessageBox.Show("Incorrect login or password!");
                return;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {

                dataGridView1.DataSource = time_risksBindingSource;
                resizearrs();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Visible = TimeArray[i] == 0 ? true : false;
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                dataGridView1.DataSource = financial_risksBindingSource;
                resizearrs();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Visible = FinanceArray[i] == 0 ? true : false;
                }
            }
            if (comboBox1.SelectedIndex == 2)
            {
                dataGridView1.DataSource = staff_risksBindingSource;
                resizearrs();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Visible = StaffArray[i] == 0 ? true : false;
                }
            }
            if (comboBox1.SelectedIndex == 3)
            {
                dataGridView1.DataSource = quality_risksBindingSource;
                resizearrs();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Visible = QualityArray[i] == 0 ? true : false;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "risk_databaseDataSet.Employer1". При необходимости она может быть перемещена или удалена.
                this.employer1TableAdapter.Fill(this.risk_databaseDataSet.Employer1);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "risk_databaseDataSet.Employer2". При необходимости она может быть перемещена или удалена.
                this.employer2TableAdapter.Fill(this.risk_databaseDataSet.Employer2);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "risk_databaseDataSet.Employer3". При необходимости она может быть перемещена или удалена.
                this.employer3TableAdapter.Fill(this.risk_databaseDataSet.Employer3);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "risk_databaseDataSet.ManagerTable". При необходимости она может быть перемещена или удалена.
                this.managerTableTableAdapter.Fill(this.risk_databaseDataSet.ManagerTable);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "risk_databaseDataSet.Time_risks". При необходимости она может быть перемещена или удалена.
                this.time_risksTableAdapter.Fill(this.risk_databaseDataSet.Time_risks);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "risk_databaseDataSet.Staff_risks". При необходимости она может быть перемещена или удалена.
                this.staff_risksTableAdapter.Fill(this.risk_databaseDataSet.Staff_risks);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "risk_databaseDataSet.Quality_risks". При необходимости она может быть перемещена или удалена.
                this.quality_risksTableAdapter.Fill(this.risk_databaseDataSet.Quality_risks);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "risk_databaseDataSet.Quality_risks". При необходимости она может быть перемещена или удалена.
                this.financial_risksTableAdapter.Fill(this.risk_databaseDataSet.Financial_risks);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "risk_databaseDataSet.Quality_risks". При необходимости она может быть перемещена или удалена.
                this.financial_risksTableAdapter.Fill(this.risk_databaseDataSet.Financial_risks);
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте подключение баз данных с рисками");
                this.Close();
            }
            if (dataGridView2.RowCount <= 0)
            {

            }

        }

        private void financial_risksBindingSource_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                int CurrRow1 = dataGridView1.CurrentRow.Index;
                getarrtype()[CurrRow1] = -1; //Пометка, что он лежит в очереди на распределение
                if (dataGridView1.Rows.Count < 1)
                {
                    throw new IndexOutOfRangeException();
                }
                managerTableBindingSource.Add(null);
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[5].Value = "";
                for (int i = 0; i < 5; i++)
                {
                    dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[i].Value = dataGridView1.CurrentRow.Cells[i].Value;
                }

                financial_risksBindingSource.MoveNext();
                time_risksBindingSource.MoveNext();
                staff_risksBindingSource.MoveNext();
                quality_risksBindingSource.MoveNext();
                try
                {
                    dataGridView1.Rows[CurrRow1].Visible = false;
                }
                catch (Exception ex)
                {
                    //if (dataGridView1.Rows[CurrRow1].Cells[0].Value == null) throw new IndexOutOfRangeException();
                    //if(comboBox1.SelectedIndex==1)financial_risksBindingSource.Add(null);
                    //if (comboBox1.SelectedIndex == 0) time_risksBindingSource.Add(null);
                    //if (comboBox1.SelectedIndex == 2) staff_risksBindingSource.Add(null);
                    //if (comboBox1.SelectedIndex == 3) quality_risksBindingSource.Add(null);
                    if (dataGridView1.CurrentCell == null) throw new IndexOutOfRangeException();
                    dataGridView1.CurrentCell = null;
                    dataGridView1.Rows[CurrRow1].Visible = false;
                }
                managerTableBindingSource.MoveNext();




            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Вы все выбрали");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выберите новую базу данных");
            }
        }

        int findin(DataGridView d, DataGridViewRow r)
        {
            for (int i = 0; i < d.Rows.Count; i++)
            {
                bool f = true;
                for (int j = 1; j < Math.Min(d.Rows[i].Cells.Count, r.Cells.Count); j++)
                {
                    if ((string)d.Rows[i].Cells[j].Value != (string)r.Cells[j].Value)
                    {
                        f = false;
                        break;
                    }
                }
                if (f)
                {
                    return i;
                }
            }
            return -1;
        }


        private void add_risk(string[] s, int type = 0)
        {
            switch (type) {
                case (0):
                    {
                        Validate();
                        time_risksBindingSource.EndEdit();
                        time_risksTableAdapter.Insert(s[0], s[1], s[2], s[3]);
                        //employer1TableAdapter.Update(risk_databaseDataSet.Employer1);
                        time_risksTableAdapter.Fill(risk_databaseDataSet.Time_risks);
                        Validate();
                        break;
                    }
                case (1):
                    {
                        Validate();
                        financial_risksBindingSource.EndEdit();
                        financial_risksTableAdapter.Insert(s[0], s[1], s[2], s[3]);
                        //employer1TableAdapter.Update(risk_databaseDataSet.Employer1);
                        financial_risksTableAdapter.Fill(risk_databaseDataSet.Financial_risks);
                        Validate();
                        break;
                    }
                case (2):
                    {
                        Validate();
                        staff_risksBindingSource.EndEdit();
                        staff_risksTableAdapter.Insert(s[0], s[1], s[2], s[3]);
                        //employer1TableAdapter.Update(risk_databaseDataSet.Employer1);
                        staff_risksTableAdapter.Fill(risk_databaseDataSet.Staff_risks);
                        Validate();
                        break;
                    }
                case (3):
                    {
                        Validate();
                        quality_risksBindingSource.EndEdit();
                        quality_risksTableAdapter.Insert(s[0], s[1], s[2], s[3]);
                        //employer1TableAdapter.Update(risk_databaseDataSet.Employer1);
                        quality_risksTableAdapter.Fill(risk_databaseDataSet.Quality_risks);
                        Validate();
                        break;
                    }
            }

        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            resizearrs();
            if (e.ColumnIndex != 5)
            {
                return;
            }
            int CurrRow1 = getcr();//dataGridView2.CurrentRow.Index;
            #region Извлечение
            int retfi;
            switch (comboBox1.SelectedIndex)
            {
                //Time
                //Finance
                //Staff
                //Quality
                case 0:
                    {
                        if (TimeArray[CurrRow1] > 0)
                        {
                            DataGridView table = null;
                            switch (TimeArray[CurrRow1])
                            {
                                case 1:
                                    {
                                        table = dataGridView3;
                                        retfi = findin(table, dataGridView1.Rows[CurrRow1]);
                                        if (retfi > -1)
                                        {
                                            //employer1TableAdapter.Fill(risk_databaseDataSet.Employer1);
                                            employer1TableAdapter.Delete((int)table.Rows[retfi].Cells[0].Value, (string)table.Rows[retfi].Cells[1].Value, (string)table.Rows[retfi].Cells[2].Value, (string)table.Rows[retfi].Cells[3].Value, (string)table.Rows[retfi].Cells[4].Value, (string)table.Rows[retfi].Cells[5].Value, (string)table.Rows[retfi].Cells[6].Value, (string)table.Rows[retfi].Cells[7].Value);
                                            //, (int)table.Rows[retfi].Cells[6].Value, (int)table.Rows[retfi].Cells[7].Value
                                            table.Rows.Remove(table.Rows[retfi]);
                                            employer1BindingSource.EndEdit();
                                            //employer1TableAdapter.Update(risk_databaseDataSet.Employer1);
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        table = dataGridView5;
                                        retfi = findin(table, dataGridView1.Rows[CurrRow1]);
                                        if (retfi > -1)
                                        {
                                            //employer2TableAdapter.Fill(risk_databaseDataSet.Employer2);
                                            employer2TableAdapter.Delete((int)table.Rows[retfi].Cells[0].Value, (string)table.Rows[retfi].Cells[1].Value, (string)table.Rows[retfi].Cells[2].Value, (string)table.Rows[retfi].Cells[3].Value, (string)table.Rows[retfi].Cells[4].Value);
                                            table.Rows.Remove(table.Rows[retfi]);
                                            employer2BindingSource.EndEdit();
                                            //employer2TableAdapter.Update(risk_databaseDataSet.Employer2);
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        table = dataGridView4;
                                        retfi = findin(table, dataGridView1.Rows[CurrRow1]);
                                        if (retfi > -1)
                                        {
                                            //employer3TableAdapter.Fill(risk_databaseDataSet.Employer3);
                                            employer3TableAdapter.Delete((int)table.Rows[retfi].Cells[0].Value, (string)table.Rows[retfi].Cells[1].Value, (string)table.Rows[retfi].Cells[2].Value, (string)table.Rows[retfi].Cells[3].Value, (string)table.Rows[retfi].Cells[4].Value);
                                            table.Rows.Remove(table.Rows[retfi]);
                                            employer3BindingSource.EndEdit();
                                            //employer3TableAdapter.Update(risk_databaseDataSet.Employer3);
                                        }
                                        break;
                                    }
                            }
                            table.CurrentCell = null;
                            TimeArray[CurrRow1] = 0;
                        }
                        break;
                    }
                case 1:
                    {
                        if (FinanceArray[CurrRow1] > 0)
                        {
                            DataGridView table = null;
                            switch (FinanceArray[CurrRow1])
                            {
                                case 1:
                                    {
                                        table = dataGridView3;
                                        retfi = findin(table, dataGridView1.Rows[CurrRow1]);
                                        if (retfi > -1)
                                        {
                                            //employer1TableAdapter.Fill(risk_databaseDataSet.Employer1);
                                            employer1TableAdapter.Delete((int)table.Rows[retfi].Cells[0].Value, (string)table.Rows[retfi].Cells[1].Value, (string)table.Rows[retfi].Cells[2].Value, (string)table.Rows[retfi].Cells[3].Value, (string)table.Rows[retfi].Cells[4].Value, (string)table.Rows[retfi].Cells[5].Value, (string)table.Rows[retfi].Cells[6].Value, (string)table.Rows[retfi].Cells[7].Value);
                                            table.Rows.Remove(table.Rows[retfi]);
                                            employer1BindingSource.EndEdit();
                                            //employer1TableAdapter.Update(risk_databaseDataSet.Employer1);
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        table = dataGridView5;
                                        retfi = findin(table, dataGridView1.Rows[CurrRow1]);
                                        if (retfi > -1)
                                        {
                                            //employer2TableAdapter.Fill(risk_databaseDataSet.Employer2);
                                            employer2TableAdapter.Delete((int)table.Rows[retfi].Cells[0].Value, (string)table.Rows[retfi].Cells[1].Value, (string)table.Rows[retfi].Cells[2].Value, (string)table.Rows[retfi].Cells[3].Value, (string)table.Rows[retfi].Cells[4].Value);
                                            table.Rows.Remove(table.Rows[retfi]);
                                            employer2BindingSource.EndEdit();
                                            //employer2TableAdapter.Update(risk_databaseDataSet.Employer2);
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        table = dataGridView4;
                                        retfi = findin(table, dataGridView1.Rows[CurrRow1]);
                                        if (retfi > -1)
                                        {
                                            //employer3TableAdapter.Fill(risk_databaseDataSet.Employer3);
                                            employer3TableAdapter.Delete((int)table.Rows[retfi].Cells[0].Value, (string)table.Rows[retfi].Cells[1].Value, (string)table.Rows[retfi].Cells[2].Value, (string)table.Rows[retfi].Cells[3].Value, (string)table.Rows[retfi].Cells[4].Value);
                                            table.Rows.Remove(table.Rows[retfi]);
                                            employer3BindingSource.EndEdit();
                                            //employer3TableAdapter.Update(risk_databaseDataSet.Employer3);
                                        }
                                        break;
                                    }
                            }
                            table.CurrentCell = null;
                            FinanceArray[CurrRow1] = 0;
                        }
                        break;
                    }
                case 2:
                    {
                        if (StaffArray[CurrRow1] > 0)
                        {
                            DataGridView table = null;
                            switch (StaffArray[CurrRow1])
                            {
                                case 1:
                                    {
                                        table = dataGridView3;
                                        retfi = findin(table, dataGridView1.Rows[CurrRow1]);
                                        if (retfi > -1)
                                        {
                                            //employer1TableAdapter.Fill(risk_databaseDataSet.Employer1);
                                            employer1TableAdapter.Delete((int)table.Rows[retfi].Cells[0].Value, (string)table.Rows[retfi].Cells[1].Value, (string)table.Rows[retfi].Cells[2].Value, (string)table.Rows[retfi].Cells[3].Value, (string)table.Rows[retfi].Cells[4].Value, (string)table.Rows[retfi].Cells[5].Value, (string)table.Rows[retfi].Cells[6].Value, (string)table.Rows[retfi].Cells[7].Value);
                                            table.Rows.Remove(table.Rows[retfi]);
                                            employer1BindingSource.EndEdit();
                                            //employer1TableAdapter.Update(risk_databaseDataSet.Employer1);
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        table = dataGridView5;
                                        retfi = findin(table, dataGridView1.Rows[CurrRow1]);
                                        if (retfi > -1)
                                        {
                                            //employer2TableAdapter.Fill(risk_databaseDataSet.Employer2);
                                            employer2TableAdapter.Delete((int)table.Rows[retfi].Cells[0].Value, (string)table.Rows[retfi].Cells[1].Value, (string)table.Rows[retfi].Cells[2].Value, (string)table.Rows[retfi].Cells[3].Value, (string)table.Rows[retfi].Cells[4].Value);
                                            table.Rows.Remove(table.Rows[retfi]);
                                            employer2BindingSource.EndEdit();
                                            //employer2TableAdapter.Update(risk_databaseDataSet.Employer2);
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        table = dataGridView4;
                                        retfi = findin(table, dataGridView1.Rows[CurrRow1]);
                                        if (retfi > -1)
                                        {
                                            //employer3TableAdapter.Fill(risk_databaseDataSet.Employer3);
                                            employer3TableAdapter.Delete((int)table.Rows[retfi].Cells[0].Value, (string)table.Rows[retfi].Cells[1].Value, (string)table.Rows[retfi].Cells[2].Value, (string)table.Rows[retfi].Cells[3].Value, (string)table.Rows[retfi].Cells[4].Value);
                                            table.Rows.Remove(table.Rows[retfi]);
                                            employer3BindingSource.EndEdit();
                                            //employer3TableAdapter.Update(risk_databaseDataSet.Employer3);
                                        }
                                        break;
                                    }
                            }
                            table.CurrentCell = null;

                            StaffArray[CurrRow1] = 0;
                        }
                        break;
                    }
                case 3:
                    {
                        if (QualityArray[CurrRow1] > 0)
                        {
                            DataGridView table = null;
                            switch (QualityArray[CurrRow1])
                            {
                                case 1:
                                    {
                                        table = dataGridView3;
                                        retfi = findin(table, dataGridView1.Rows[CurrRow1]);
                                        if (retfi > -1)
                                        {
                                            //employer1TableAdapter.Fill(risk_databaseDataSet.Employer1);
                                            employer1TableAdapter.Delete((int)table.Rows[retfi].Cells[0].Value, (string)table.Rows[retfi].Cells[1].Value, (string)table.Rows[retfi].Cells[2].Value, (string)table.Rows[retfi].Cells[3].Value, (string)table.Rows[retfi].Cells[4].Value, (string)table.Rows[retfi].Cells[5].Value, (string)table.Rows[retfi].Cells[6].Value, (string)table.Rows[retfi].Cells[7].Value);
                                            table.Rows.Remove(table.Rows[retfi]);
                                            employer1BindingSource.EndEdit();
                                            //employer1TableAdapter.Update(risk_databaseDataSet.Employer1);
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        table = dataGridView5;
                                        retfi = findin(table, dataGridView1.Rows[CurrRow1]);
                                        if (retfi > -1)
                                        {
                                            //employer2TableAdapter.Fill(risk_databaseDataSet.Employer2);
                                            employer2TableAdapter.Delete((int)table.Rows[retfi].Cells[0].Value, (string)table.Rows[retfi].Cells[1].Value, (string)table.Rows[retfi].Cells[2].Value, (string)table.Rows[retfi].Cells[3].Value, (string)table.Rows[retfi].Cells[4].Value);
                                            table.Rows.Remove(table.Rows[retfi]);
                                            employer2BindingSource.EndEdit();
                                            //employer2TableAdapter.Update(risk_databaseDataSet.Employer2);
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        table = dataGridView4;
                                        retfi = findin(table, dataGridView1.Rows[CurrRow1]);
                                        if (retfi > -1)
                                        {
                                            //employer3TableAdapter.Fill(risk_databaseDataSet.Employer3);
                                            employer3TableAdapter.Delete((int)table.Rows[retfi].Cells[0].Value, (string)table.Rows[retfi].Cells[1].Value, (string)table.Rows[retfi].Cells[2].Value, (string)table.Rows[retfi].Cells[3].Value, (string)table.Rows[retfi].Cells[4].Value);
                                            table.Rows.Remove(table.Rows[retfi]);
                                            employer3BindingSource.EndEdit();
                                            //employer3TableAdapter.Update(risk_databaseDataSet.Employer3);
                                        }
                                        break;
                                    }
                            }

                            QualityArray[CurrRow1] = 0;
                        }
                        break;
                    }
            }
            #endregion
            switch ((string)dataGridView2.CurrentRow.Cells[5].Value)
            {
                case "Employer1":
                    string type = "";
                    //employer1TableAdapter.Fill(risk_databaseDataSet.Employer1);
                    //employer1BindingSource.Add(null);
                    switch (comboBox1.SelectedIndex)
                    {
                        //Time
                        //Finance
                        //Staff
                        //Quality
                        case 0:
                            {
                                type = "Time";
                                TimeArray[CurrRow1] = 1;
                                TimeArrayp[CurrRow1] = dataGridView3.Rows.Count - 1;
                                break;
                            }
                        case 1:
                            {
                                type = "Finance";
                                FinanceArray[CurrRow1] = 1;
                                FinanceArrayp[CurrRow1] = dataGridView3.Rows.Count - 1;
                                break;
                            }
                        case 2:
                            {
                                type = "Staff";
                                StaffArray[CurrRow1] = 1;
                                StaffArrayp[CurrRow1] = dataGridView3.Rows.Count - 1;
                                break;
                            }
                        case 3:
                            {
                                type = "Quality";
                                QualityArray[CurrRow1] = 1;
                                QualityArrayp[CurrRow1] = dataGridView3.Rows.Count - 1;
                                break;
                            }
                    }
                    //dataGridView2.CurrentRow.Cells[5].Value = "Employer1";
                    //int maxn = -1;
                    //for (int i = 1; i < dataGridView3.Rows.Count - 1; i++)
                    //{
                    //    maxn = Math.Max(maxn, (int)dataGridView3.Rows[i].Cells[0].Value);
                    //}
                    //for (int i = 1; i < 5; i++)
                    //{
                    //    dataGridView3.Rows[dataGridView3.Rows.Count - 1].Cells[i].Value = dataGridView2.CurrentRow.Cells[i].Value;
                    //}
                    //dataGridView3.Rows[dataGridView3.Rows.Count - 1].Cells[0].Value = Math.Max(maxn + 1, (int)dataGridView3.Rows[dataGridView3.Rows.Count - 1].Cells[0].Value);
                    Validate();
                    employer1BindingSource.EndEdit();
                    employer1TableAdapter.Insert(type, (string)dataGridView2.CurrentRow.Cells[1].Value, (string)dataGridView2.CurrentRow.Cells[2].Value, (string)dataGridView2.CurrentRow.Cells[3].Value, (string)dataGridView2.CurrentRow.Cells[4].Value, "0","0");
                    //employer1TableAdapter.Update(risk_databaseDataSet.Employer1);
                    employer1TableAdapter.Fill(risk_databaseDataSet.Employer1);
                    Validate();

                    break;
                case "Employer2":
                    //employer2TableAdapter.Fill(risk_databaseDataSet.Employer2);
                    //employer2BindingSource.Add(null);
                    switch (comboBox1.SelectedIndex)
                    {
                        //Time
                        //Finance
                        //Staff
                        //Quality
                        case 0:
                            {
                                TimeArray[CurrRow1] = 2;
                                TimeArrayp[CurrRow1] = dataGridView5.Rows.Count - 1;
                                break;
                            }
                        case 1:
                            {
                                FinanceArray[CurrRow1] = 2;
                                FinanceArrayp[CurrRow1] = dataGridView5.Rows.Count - 1;
                                break;
                            }
                        case 2:
                            {
                                StaffArray[CurrRow1] = 2;
                                StaffArrayp[CurrRow1] = dataGridView5.Rows.Count - 1;
                                break;
                            }
                        case 3:
                            {
                                QualityArray[CurrRow1] = 2;
                                QualityArrayp[CurrRow1] = dataGridView5.Rows.Count - 1;
                                break;
                            }
                    }
                    //dataGridView2.CurrentRow.Cells[5].Value = "Employer2";
                    //maxn = -1;
                    //for (int i = 1; i < dataGridView5.Rows.Count - 1; i++)
                    //{
                    //    maxn = Math.Max(maxn, (int)dataGridView5.Rows[i].Cells[0].Value);
                    //}
                    //for (int i = 1; i < 5; i++)
                    //{
                    //    dataGridView5.Rows[dataGridView5.Rows.Count - 1].Cells[i].Value = dataGridView2.CurrentRow.Cells[i].Value;
                    //}
                    //dataGridView5.Rows[dataGridView5.Rows.Count - 1].Cells[0].Value = Math.Max(maxn + 1, (int)dataGridView5.Rows[dataGridView5.Rows.Count - 1].Cells[0].Value);
                    employer2BindingSource.EndEdit();
                    //employer2TableAdapter.Update(risk_databaseDataSet.Employer2);
                    employer2TableAdapter.Insert((string)dataGridView2.CurrentRow.Cells[1].Value, (string)dataGridView2.CurrentRow.Cells[2].Value, (string)dataGridView2.CurrentRow.Cells[3].Value, (string)dataGridView2.CurrentRow.Cells[4].Value);

                    employer2TableAdapter.Fill(risk_databaseDataSet.Employer2);
                    Validate();
                    break;
                case "Employer3":
                    //employer3TableAdapter.Fill(risk_databaseDataSet.Employer3);
                    //employer3BindingSource.Add(null);
                    switch (comboBox1.SelectedIndex)
                    {
                        //Time
                        //Finance
                        //Staff
                        //Quality
                        case 0:
                            {
                                TimeArray[CurrRow1] = 3;
                                TimeArrayp[CurrRow1] = dataGridView4.Rows.Count - 1;
                                break;
                            }
                        case 1:
                            {
                                FinanceArray[CurrRow1] = 3;
                                FinanceArrayp[CurrRow1] = dataGridView4.Rows.Count - 1;
                                break;
                            }
                        case 2:
                            {
                                StaffArray[CurrRow1] = 3;
                                StaffArrayp[CurrRow1] = dataGridView4.Rows.Count - 1;
                                break;
                            }
                        case 3:
                            {
                                QualityArray[CurrRow1] = 3;
                                QualityArrayp[CurrRow1] = dataGridView4.Rows.Count - 1;
                                break;
                            }
                    }
                    //dataGridView2.CurrentRow.Cells[5].Value = "Employer3";
                    //maxn = -1;
                    //for (int i = 1; i < dataGridView4.Rows.Count - 1; i++)
                    //{
                    //    maxn = Math.Max(maxn, (int)dataGridView4.Rows[i].Cells[0].Value);
                    //}
                    //for (int i = 1; i < 5; i++)
                    //{
                    //    dataGridView4.Rows[dataGridView4.Rows.Count - 1].Cells[i].Value = dataGridView2.CurrentRow.Cells[i].Value;
                    //}
                    //dataGridView4.Rows[dataGridView4.Rows.Count - 1].Cells[0].Value = Math.Max(maxn + 1, (int)dataGridView4.Rows[dataGridView4.Rows.Count - 1].Cells[0].Value);
                    employer3BindingSource.EndEdit();
                    //employer3TableAdapter.Update(risk_databaseDataSet.Employer3);
                    employer3TableAdapter.Insert((string)dataGridView2.CurrentRow.Cells[1].Value, (string)dataGridView2.CurrentRow.Cells[2].Value, (string)dataGridView2.CurrentRow.Cells[3].Value, (string)dataGridView2.CurrentRow.Cells[4].Value);
                    employer3TableAdapter.Fill(risk_databaseDataSet.Employer3);
                    Validate();
                    break;
            }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool f = true;
            double v = 1;
            DataGridView d = dataGridView3;
            if (WhoEntered == 2) d = dataGridView5;
            if (WhoEntered == 3) d = dataGridView4;
            try
            {
                if (d.Rows.Count < 1)
                {
                    f = false;
                    throw new Exception();
                }
                if (Convert.ToDouble(textBox3.Text) > 1 || Convert.ToDouble(textBox3.Text) < 0)
                {
                    f = false;
                    throw new OverflowException();
                }
                else
                {
                    v *= Convert.ToDouble(textBox3.Text);
                }
            }
            catch (OverflowException)
            {
                MessageBox.Show("Введите значение вероятности между 0 и 1");
                return;
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректное значение вероятности");
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("У вас нет рисков для оценки!");
            }
            try
            {
                if (Convert.ToDouble(textBox4.Text) > 1 || Convert.ToDouble(textBox4.Text) < 0)
                {
                    f = false;
                    throw new OverflowException();
                }
                else
                {
                    v *= Convert.ToDouble(textBox4.Text);
                }
            }
            catch (OverflowException)
            {
                MessageBox.Show("Введите значение воздействия между 0 и 1");
                return;
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректное значение воздействия");
                return;
            }
            if (f)
            {
                form2.addselectedrisk(d, v, Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text), (string)comboBox2.SelectedItem);
                if (!form2.IsAccessible)
                    form2.ShowDialog(); // OLD TABLE
                //form2.draw_risk_Click(sender, e);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (((DataGridView)dataGridView3).SelectedRows.Count == 1)
                {
                    //((DataGridView)dataGridView3).SelectedRows[0].Cells[6].ValueType = typeof(string);
                    //employer1TableAdapter.Delete((int)dataGridView3.SelectedRows[0].Cells[0].Value, (string)dataGridView3.SelectedRows[0].Cells[1].Value, (string)dataGridView3.SelectedRows[0].Cells[2].Value, (string)dataGridView3.SelectedRows[0].Cells[3].Value, (string)dataGridView3.SelectedRows[0].Cells[4].Value, (string)dataGridView3.SelectedRows[0].Cells[5].Value, (string)dataGridView3.SelectedRows[0].Cells[6].Value, (string)dataGridView3.SelectedRows[0].Cells[7].Value);
                    ((DataGridView)dataGridView3).SelectedRows[0].Cells[6].Value = textBox3.Text;
                    employer1TableAdapter.Update(risk_databaseDataSet.Employer1);
                    //employer1TableAdapter.Insert((string)dataGridView3.SelectedRows[0].Cells[1].Value, (string)dataGridView3.SelectedRows[0].Cells[2].Value, (string)dataGridView3.SelectedRows[0].Cells[3].Value, (string)dataGridView3.SelectedRows[0].Cells[4].Value, (string)dataGridView3.SelectedRows[0].Cells[5].Value, (string)dataGridView3.SelectedRows[0].Cells[6].Value, (string)dataGridView3.SelectedRows[0].Cells[7].Value);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (((DataGridView)dataGridView3).SelectedRows.Count == 1)
                {
                    //((DataGridView)dataGridView3).SelectedRows[0].Cells[7].ValueType = typeof(string);
                    //employer1TableAdapter.Delete((int)dataGridView3.SelectedRows[0].Cells[0].Value, (string)dataGridView3.SelectedRows[0].Cells[1].Value, (string)dataGridView3.SelectedRows[0].Cells[2].Value, (string)dataGridView3.SelectedRows[0].Cells[3].Value, (string)dataGridView3.SelectedRows[0].Cells[4].Value, (string)dataGridView3.SelectedRows[0].Cells[5].Value, (string)dataGridView3.SelectedRows[0].Cells[6].Value, (string)dataGridView3.SelectedRows[0].Cells[7].Value);
                    ((DataGridView)dataGridView3).SelectedRows[0].Cells[7].Value = textBox4.Text;
                    employer1TableAdapter.Update(risk_databaseDataSet.Employer1);
                    //employer1TableAdapter.Insert((string)dataGridView3.SelectedRows[0].Cells[1].Value, (string)dataGridView3.SelectedRows[0].Cells[2].Value, (string)dataGridView3.SelectedRows[0].Cells[3].Value, (string)dataGridView3.SelectedRows[0].Cells[4].Value, (string)dataGridView3.SelectedRows[0].Cells[5].Value, (string)dataGridView3.SelectedRows[0].Cells[6].Value, (string)dataGridView3.SelectedRows[0].Cells[7].Value);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }



        /// <summary>
        ///Рисуем карту рисков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void draw_risk_Click(object sender, EventArgs e)
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
                    string name = $"{dataGridView1.Rows[ns].Cells[1]}\r\n{dataGridView1.Rows[ns].Cells[2]}\r\n{dataGridView1.Rows[ns].Cells[3]}\r\n{dataGridView1.Rows[ns].Cells[4]}\r\n{dataGridView1.Rows[ns].Cells[5]}\r\n{comboBox2.SelectedItem}";// $"Система - {rsk[ns - 1]}, \r\nЭлемент - {(string)dataGridView3.Rows[oldrowindex].Cells[0].Value}, \r\nАтрибут - {(string)dataGridView3.Rows[i + oldrowindex].Cells[0].Value}";

                    ColorPoint cp = new ColorPoint(x, y, 10/*Радиус точки для отрисовки*/, name, Color.Black, scalecoeff);

                    ds.points.Add(cp);

                }
                FormGraphics fr = new FormGraphics(ds, $"Карта рисков\"{""}\"", own: this);
                fr.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            WhoEntered = comboBox3.SelectedIndex + 1;
            if (WhoEntered == 2) WhoEntered = 4;
            CheckEntry();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        public void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // обработчик события закрытия формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        bool is_adding_flag = false;
        private void button5_Click(object sender, EventArgs e)
        {
            if (!is_adding_flag)
            {
                dataGridView1.Visible = false;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                label11.Visible = true;
                label10.Visible = true;
                label9.Visible = true;
                label8.Visible = true;
                is_adding_flag = true;
            }
            else
            {
                add_risk(new String[] { textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text }, comboBox1.SelectedIndex);
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                label11.Visible = false;
                label10.Visible = false;
                label9.Visible = false;
                label8.Visible = false;
                dataGridView1.Visible = true;
                is_adding_flag = false;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (((DataGridView)sender).SelectedRows.Count == 1)
                {
                    textBox3.Text = ((DataGridView)sender).SelectedRows[0].Cells[6].Value.ToString();
                    textBox4.Text = ((DataGridView)sender).SelectedRows[0].Cells[7].Value.ToString();
                }
            }
            catch { }
        }

        
    }
}
