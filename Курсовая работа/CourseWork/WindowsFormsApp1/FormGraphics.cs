using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Класс для формы, на которой будут рисоваться графики
    /// </summary>
    public partial class FormGraphics : Form
    {
        private float posx, posy, pox, poy; // положение левого верхнего угла битмапа на форме (нужно для перемещения)
        private ForGraphics gr; // класс для графика
        public DataSender ds; // данные для построения графика
        private int nowp = -1; // номер точки, с которой начнётся проверка выбора при следующем двойном нажатии на левую кнопку мышки (для случая совпадания точек на графике)
        private bool f = false; // Происходит ли перемещение графика относительно формы
        Form owner = null;
        private Bitmap bmph = null;

        /// <summary>
        /// конструктор 
        /// </summary>
        /// <param name="ds"></param>
        public FormGraphics(DataSender ds, string name = "Graphics", Form own = null)
        {
            try
            {
                this.ds = ds;
                this.owner = own;
                this.Owner = null;
                DoubleBuffered = true;
                gr = new ForGraphics(this);
                InitializeComponent();
                Invalidate();
                Init(); // задание изначальной позиции верхнего левого угла битмапа
                this.Focus();
                this.Text = name;
                //this.TopMost = true; // будет всегда поверх остальных окон
                //this.TopMost = false; // будет поверх остальных окон, но уже не всегда
                this.MinimumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2);

            }
            catch (Exception ex)
            {
                //ApplicationClosingByException(ex);
            }
        }

        /// <summary>
        /// Построение графика
        /// </summary>
        void DrawChart(bool firstdraw = false)
        {
            if (f) Init();
            float scl = gr.scale;
            gr.scale = Math.Max(20, gr.scale);
            string text_help = "СПРАВКА:" +
                            "\r\nПеремещать график можно с помощью мышки. " +
                            "\r\nУвеличивать/уменьшать изображение на графике можно с помощью колесика мышки или клавиш \"W\" / \"S\"." +
                            "\r\nДля возврата к исходному положению и размеру графика нажмите \"R\".";
            
            switch (ds.n) // по значению n - определяем, какой из графиков рисовать
            {
                case 0:
                    {
                        string histog = "На гистограмме расположены группы столбцов. " +
                             "Каждая группа задает влияние/вероятность риска соответствующего атрибута (в элементе, выбранном на 2 вкладке) для всех рассматриваемых ИТ систем. " +
                             "Номер системы задается цифрой над соответствующим столбцом. Тип атрибута задается названием над соответствующей группой столбцов. " +
                             "Столбцы гистограмм окрашены в красный, желтый, зеленый цвета в зависимости от относительной значения высоты. " +
                             "Кол-во групп равно кол-ву атрибутов, выбранных на 2-ой вкладке. ";
                        //textBox2.Text/*справка*/ = text_help + "\r\n"+ histog;
                        richTextBox1.Text = "СПРАВКА:";
                        text_help = "\r\nПеремещать график можно с помощью мышки. " +
                            "\r\nУвеличивать/уменьшать изображение на графике можно с помощью колесика мышки или клавиш \"W\" / \"S\"." +
                            "\r\nДля возврата к исходному положению и размеру графика нажмите \"R\".";
                        richTextBox1.SelectionStart = richTextBox1.TextLength;
                        richTextBox1.SelectionLength = 0;
                        richTextBox1.SelectionColor = Color.Blue;
                        richTextBox1.AppendText(text_help + "\r\n");
                        richTextBox1.SelectionColor = richTextBox1.ForeColor;
                        richTextBox1.SelectionColor = Color.Black;
                        richTextBox1.AppendText(histog);
                        richTextBox1.SelectionColor = richTextBox1.ForeColor;

                        textBox1.Text = "Для вывода информации о столбцах на графике два раза нажмите на столбец."; ;
                        if (firstdraw)
                        {
                            gr.DrawHists(ds);
                            this.bmph = new Bitmap((Image)gr.bmp.Clone());
                        }
                        gr.scale = scl;
                        gr.DrawHists(ds);
                        break;
                    }
                case 1:
                    {
                        textBox1.Text = "Для вывода информации о точках на графике два раза нажмите на точку.";
                        //textBox2.Text/*справка*/ = text_help + "\r\nТочки выводятся зеленым, желтым и красным цветом для обозначения низкого, среднего и высокого уровней риска соответственно.";
                        richTextBox1.Text = "СПРАВКА:";
                        text_help = "\r\nПеремещать график можно с помощью мышки. " +
                            "\r\nУвеличивать/уменьшать изображение на графике можно с помощью колесика мышки или клавиш \"W\" / \"S\"." +
                            "\r\nДля возврата к исходному положению и размеру графика нажмите \"R\".";
                        richTextBox1.SelectionStart = richTextBox1.TextLength;
                        richTextBox1.SelectionLength = 0;
                        richTextBox1.SelectionColor = Color.Blue;
                        richTextBox1.AppendText(text_help + "\r\n");
                        richTextBox1.SelectionColor = richTextBox1.ForeColor;
                        richTextBox1.SelectionColor = Color.Black;
                        richTextBox1.AppendText("Точки выводятся зеленым, желтым и красным цветом для обозначения низкого, среднего и высокого уровней риска соответственно.");
                        richTextBox1.SelectionColor = richTextBox1.ForeColor;
                        if (firstdraw)
                        {
                            gr.DrawPoints(ds);
                            this.bmph = new Bitmap((Image)gr.bmp.Clone());
                        }
                        gr.scale = scl;
                        gr.DrawPoints(ds);
                        break;
                    }
                case 2:
                    {
                        textBox1.Text = "Для вывода информации о точках на графике два раза нажмите на точку.";
                        //textBox2.Text/*справка*/ = text_help + "\r\nДиаметр круга, соответствующего системе, пропорционален стоимости данной системы.";
                        richTextBox1.Text = "СПРАВКА:";
                        text_help = "\r\nПеремещать график можно с помощью мышки. " +
                            "\r\nУвеличивать/уменьшать изображение на графике можно с помощью колесика мышки или клавиш \"W\" / \"S\"." +
                            "\r\nДля возврата к исходному положению и размеру графика нажмите \"R\".";
                        richTextBox1.SelectionStart = richTextBox1.TextLength;
                        richTextBox1.SelectionLength = 0;
                        richTextBox1.SelectionColor = Color.Blue;
                        richTextBox1.AppendText(text_help + "\r\n");
                        richTextBox1.SelectionColor = richTextBox1.ForeColor;
                        richTextBox1.SelectionColor = Color.Black;
                        richTextBox1.AppendText("Диаметр круга, соответствующего системе, пропорционален стоимости данной системы.");
                        richTextBox1.SelectionColor = richTextBox1.ForeColor;
                        if (firstdraw)
                        {
                            gr.DrawBigPoints(ds);
                            this.bmph = new Bitmap((Image)gr.bmp.Clone());
                        }
                        gr.scale = scl;
                        gr.DrawBigPoints(ds);
                        break;
                    }
            }
            firstdraw = false;
            //gr.bmp = new Bitmap(((Image)gr.bmp.Clone()), (int)(gr.bmp.Width * scl / gr.scale), (int)(gr.bmp.Height * scl / gr.scale));
            Invalidate(); // будет вызван OnPaint
        }

        /// <summary>
        /// Переопределение перерисовки окна - вызывается при вызове Invalidate().
        /// (Переопределение стандартного метода OnPaint)
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (gr.bmp != null)
                {
                    e.Graphics.DrawImage(gr.bmp, posx, posy);// отрисовываем битмап на нашей форме
                }
                base.OnPaint(e);
            }
            catch (Exception ex)
            {
                //ApplicationClosingByException(ex);
            }
        }

        /// <summary>
        /// Для выбора точек (к которым выведется информация) с помощью двойного щелчка левой кнопкой мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Point nowpoint = new Point((int)(e.X - posx)/*переход в относительные координаты битмапа из координат на форме*/, (int)(e.Y - posy));
                if (ds.n == 0)
                {
                    if (nowp < 0) { nowp = gr.mas_rect.Count - 1; }
                    for (int i = 0; i < gr.mas_rect.Count; i++, nowp = (nowp - 1 + gr.mas_rect.Count) % gr.mas_rect.Count) // проходим  по массиву отрисованных столбцов
                    {
                        var debe = gr.mas_rect[nowp];
                        if (nowpoint < gr.mas_rect[nowp])
                        {
                            this.textBox1.Text = "" + gr.mas_rect[nowp].name;
                            nowp = (nowp - 1 + gr.mas_rect.Count) % gr.mas_rect.Count; // чтобы при нажатии на то же самое место на карте  - выводились системы поочередно, заключенные в данной точке
                                                                                         //(остаток так как мы можем проходить массив не с 0-го элемента и переходить через последний элемент к 0-му элементу)
                            break;
                        }
                    }
                }
                else
                {
                    if (nowp < 0) { nowp = gr.mas_point.Count - 1; }
                    for (int i = 0; i < gr.mas_point.Count; i++, nowp = (nowp - 1 + gr.mas_point.Count) % gr.mas_point.Count) // проходим  по массиву отрисованных точек
                    {
                        if (nowpoint + gr.mas_point[nowp] < gr.mas_point[nowp].rv)
                        {
                            this.textBox1.Text = "" + gr.mas_point[nowp].name;
                            nowp = (nowp - 1 + gr.mas_point.Count) % gr.mas_point.Count; // чтобы при нажатии на то же самое место на карте  - выводились системы поочередно, заключенные в данной точке
                                                                                         //(остаток так как мы можем проходить массив не с 0-го элемента и переходить через последний элемент к 0-му элементу)
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //ApplicationClosingByException(ex);
            }
        }

        #region Перемещение графика
        /// <summary>
        /// Левая кнопка мыши нажата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (gr.bmp == null) return;
                if (!f)
                {
                    pox = e.X;
                    poy = e.Y;
                    f = true;
                    return;
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                ////ApplicationClosingByException(ex);
            }
        }

        /// <summary>
        /// Левая кнопка мыши отпущена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (gr.bmp == null) return;
                if (f)
                {
                    f = false;
                }
            }
            catch (Exception ex)
            {
                ////ApplicationClosingByException(ex);
            }
        }

        /// <summary>
        /// Перемещение курсора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (gr.bmp == null) return;
                if (f)
                {
                    float dx = e.X - pox, dy = e.Y - poy;
                    pox += dx;
                    poy += dy;
                    posx += dx;
                    posy += dy;
                    posx = Math.Min(this.Width - 18, Math.Max(-gr.bmp.Width + 1, posx)); //чтобы не отдалялось за рамки  - часть битмапа всегда внутри формы
                    posy = Math.Min(this.Height - 38, Math.Max(-gr.bmp.Height + 1, posy));
                    Invalidate();
                }
            }
            catch (Exception ex)
            {
                //ApplicationClosingByException(ex);
            }
        }
        #endregion

        #region Масштабирование графика
        /// <summary>
        /// Приближение в конкретной точке.
        /// Реагирует на курсор.
        /// </summary>
        /// <param name="e"></param>
        void ZoomUp(MouseEventArgs e)
        {
            try
            {
                //gr.scale = Math.Min(50,Math.Max(4, gr.scale *(float)1.5));
                gr.scale *= (float)1.5;
                if (gr.scale < 4)
                {
                    gr.scale /= (float)1.5;
                    return;
                }
                if (gr.scale > 50)
                {
                    gr.scale /= (float)1.5;
                    return;
                }
                pox -= (posx - e.X) - (posx - e.X) * (float)(1.5); // Чтобы увеличивать на том месте , к которому направлена мышка
                poy -= (posy - e.Y) - (posy - e.Y) * (float)(1.5);
                posx -= (posx - e.X) - (posx - e.X) * (float)(1.5);
                posy -= (posy - e.Y) - (posy - e.Y) * (float)(1.5);
            }
            catch (Exception ex)
            {
                //ApplicationClosingByException(ex);
            }
        }

        /// <summary>
        /// Приближение в левом верхнем углу.
        /// Реагирует на кнопку для быстрого действия и приближает "в левом верхнем углу", а не к "курсору".
        /// </summary>
        void ZoomUp()
        {
            try
            {
                //gr.scale = Math.Min(50, Math.Max(4, gr.scale *(float)1.5));
                gr.scale *= (float)1.5;
                if (gr.scale < 4)
                {
                    gr.scale /= (float)1.5;
                    return;
                }
                if (gr.scale > 50)
                {
                    gr.scale /= (float)1.5;
                    return;
                }

                Rewrite();
            }
            catch (Exception ex)
            {
                //ApplicationClosingByException(ex);
            }
        }

        /// <summary>
        /// Отдаление в конкретной точке.
        /// Реагирует на курсор.
        /// </summary>
        /// <param name="e"></param>
        void ZoomDown(MouseEventArgs e)
        {
            try
            {
                //gr.scale= Math.Min(50, Math.Max(4,gr.scale / (float)1.5));
                gr.scale /= (float)1.5;
                if (gr.scale < 4)
                {
                    gr.scale *= (float)1.5;
                    return;
                }
                if (gr.scale > 50)
                {
                    gr.scale *= (float)1.5;
                    return;
                }
                pox -= (posx - e.X) - (posx - e.X) / (float)(1.5);
                poy -= (posy - e.Y) - (posy - e.Y) / (float)(1.5);
                posx -= (posx - e.X) - (posx - e.X) / (float)(1.5);
                posy -= (posy - e.Y) - (posy - e.Y) / (float)(1.5);
                //Rewrite();
            }
            catch (Exception ex)
            {
                //ApplicationClosingByException(ex);
            }
        }

        /// <summary>
        /// Отдаление в левом вехнем углу экрана.
        /// Реагирует на кнопку для быстрого действия и приближает "в левом верхнем углу", а не к "курсору".
        /// </summary>
        void ZoomDown()
        {
            try
            {
                //gr.scale = Math.Min(50, Math.Max(4, gr.scale / (float)1.5));
                gr.scale /= (float)1.5;
                if (gr.scale < 4)
                {
                    gr.scale *= (float)1.5;
                    return;
                }
                if (gr.scale > 50)
                {
                    gr.scale *= (float)1.5;
                    return;
                }
                Rewrite();
            }
            catch (Exception ex)
            {
                //ApplicationClosingByException(ex);
            }
        }

        /// <summary>
        /// Масштабирование изображения.
        /// Реагирует на прокрутку колесика мышки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (gr.bmp == null) return;
                if (e.Delta > 0)
                {
                    ZoomUp(e);
                }
                else
                {
                    ZoomDown(e);
                }
                Rewrite();
            }
            catch (Exception ex)
            {
                //ApplicationClosingByException(ex);
            }
        }
        #endregion

        /// <summary>
        /// Отлов нажатий клавиш.
        /// Клавиши для быстрых операций.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (gr.bmp == null) return;
                if (e.KeyCode == Keys.R)
                {
                    Init();
                }
                if (e.KeyCode == Keys.W)
                {
                    ZoomUp();
                }
                if (e.KeyCode == Keys.S)
                {
                    ZoomDown();
                }

            }
            catch (Exception ex)
            {
                //ApplicationClosingByException(ex);
            }
        }

        /// <summary>
        /// Перерисовываем фрактал
        /// </summary>
        void Rewrite()
        {
            try
            {
                DrawChart();
            }
            catch (System.ArgumentException ex)
            {
                Problem("Слишком большое приближение/удаление \n");
                Init();
            }
            catch (Exception ex)
            {
                Problem("\n" + ex.Message);
            }
            Invalidate();
        }

        /// <summary>
        /// Сохранение изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (gr.bmp == null) throw (new NullReferenceException());
                    SaveFileDialog FBD = new SaveFileDialog();
                    FBD.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.PNG)|*.PNG|All Files(*.*)|*.*";
                    FBD.FilterIndex = 2; // задаем по умолчанию JPG
                    FBD.FileName = "Сhart"; // имя по умолчанию
                    if (FBD.ShowDialog() == DialogResult.OK)
                    {
                        DrawChart(true);
                        this.bmph.Save(FBD.FileName);
                    }
                }
                catch (ArgumentNullException ex)
                {
                    Problem("Неверный путь");
                }
                catch (System.Runtime.InteropServices.ExternalException ex)
                {
                    Problem("Невозможно сохранить из-за ошибки файловой системы");
                }
                catch (NullReferenceException ex)
                {
                    Problem("Невозможно сохранить несуществующий объект\n" + ex.Message);
                }
                catch (Exception ex)
                {
                    Problem("" + ex.Message);
                }
            }
            catch (Exception ex)
            {
                //ApplicationClosingByException(ex);
            }
        }

        /// <summary>
        /// Вывод сообщения об ошибке
        /// </summary>
        /// <param name="s"></param>
        void Problem(string s)
        {
            MessageBox.Show(s);
        }

        /// <summary>
        /// Стартовые значения позиции и размера
        /// </summary>
        /// <param name="draw">Перерисовать фрактал?Да:Нет</param>
        private void Init(bool draw = true)
        {
            try
            {
                if (gr.bmp == null) return;
                posx = gr.space;
                posy = gr.space + textBox1.Height;
                gr.scale = 10;
                if (draw)
                {
                    DrawChart();
                    Invalidate();
                }
            }
            catch (Exception ex)
            {
                //ApplicationClosingByException(ex);
            }
        }

        /// <summary>
        /// Закрытие приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Form1Closed(object sender, EventArgs e)
        {
            Dispose();
        }

        ///// <summary>
        ///// Метод для закрытия приложения при возникновении исключения
        ///// </summary>
        //private void ApplicationClosingByException(Exception ex = null, string s = "")
        //{
        //    Program.formclosedbyexception = true;
        //    if (ex != null)
        //    {
        //        Program.exceptionmessage = $"Возникло исключение. Форма будет перещапущена. \r\nДополнительная информация: \r\n{ex.Message}";
        //    }
        //    else
        //    {
        //        Program.exceptionmessage = s;
        //    }
        //    foreach (var i in this.OwnedForms)
        //    {
        //        i.Close();
        //    }
        //    bool f = MessageBox.Show(Program.exceptionmessage, "Перезапустить приложение?", MessageBoxButtons.YesNo) == DialogResult.Yes;
        //    this.owner?.Close();
        //    this.Close();
        //    Program.formclosedbyexception = f;
        //}

    }
}
