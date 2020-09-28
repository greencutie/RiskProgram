using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Класс для отрисовки графиков
    /// </summary>
    public class ForGraphics
    {
        public Bitmap bmp; // битмап
        Graphics graph;
        Brush brush; // специальная кисть для рисования
        public float scale = 10; //Масштаб
        public int dspace = 3; // Ширина белой рамки (зазора) вокруг графика (т.е. дополнительная зона около осей - для надписи)
        public int space { get { return Math.Max((int)(this.dspace * scale),15); } } // Ширина белой рамки (зазора) вокруг графика (т.е. дополнительная зона около осей - для надписи)
        public double vscale = 6; // Отношение значения риска атрибута к высоте столбца гистограммы  (столбец диаграммы будет в vscale раз выше, чем вычисленный риск атрибута )   
        public float TextSize = 5f; // размер шрифта
        public List<ColorPoint> mas_point = new List<ColorPoint>(); // массив точек
        public List<ColorRect> mas_rect = new List<ColorRect>(); // массив точек

        /// <summary>
        /// конструктор о умолчаниию
        /// </summary>
        public ForGraphics() { }
        public ForGraphics(Form f, float scale = 1)
        {
            this.scale = scale;
            this.bmp = new Bitmap((int)(f.Width * this.scale), (int)(f.Width * this.scale));// создаем битмап размеров с форму
            this.graph = Graphics.FromImage(bmp); // график, который лежит в битмапе
        }

        /// <summary>
        /// построение стрелок и подписи к ним
        /// </summary>
        /// <param name="xe">максимальное значение на оси x</param>
        /// <param name="ye">максимальное значение на оси y</param>
        /// <param name="zv">нулевое значение (начало координат)</param>
        /// <param name="xs">подпись под осью x</param>
        /// <param name="ys">подпись под осью y</param>
        void DrawAxis(int xe = -1, int ye = -1, int zv = 0, string xs = null, string ys = null)
        {
            graph.FillRectangle(System.Drawing.Brushes.White, 0, 0, bmp.Width, bmp.Height);// белая область размером с наш график

            float textsize = (float)(TextSize * 2.5) * scale / 8;// размер шрифта
            float arroww = 0.1f * this.scale;

            // надо ли рисовать нулевое значение
            if (xe != -1 || ye != -1) graph.DrawString(zv.ToString(), new Font("Tempus Sans ITC", textsize, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), (3), bmp.Height - space + 2);

            // прямая ox и две "палочки для стрелки"
            for (int i = 0; i <= arroww; i++)
            {
                graph.DrawLine(new Pen(Color.Black), new Point(space, bmp.Height - space + i), new Point(bmp.Width - space, bmp.Height - space + i));
                graph.DrawLine(new Pen(Color.Black), new Point(bmp.Width - space - (int)(5 * scale/10), bmp.Height - space - (int)(3 * scale/10) + i), new Point(bmp.Width - space, bmp.Height - space + i));
                graph.DrawLine(new Pen(Color.Black), new Point(bmp.Width - space - (int)(5 * scale/10), bmp.Height - space + (int)(3 * scale/10) + (int)(arroww) - i), new Point(bmp.Width - space, bmp.Height - space + (int)(arroww) - i));
            }
            if (xs != null) graph.DrawString(xs, new Font("Tempus Sans ITC", textsize, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), (bmp.Width - 2 * space) / 2 - (int)(xs.Length * textsize / 5.5)/*половина длины поля для рисования*/, bmp.Height - space + 2); // Текст будет по центру
            // если задано максимальное, рисуем его
            if (xe != -1) graph.DrawString(xe.ToString(), new Font("Tempus Sans ITC", textsize, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), (bmp.Width - space), bmp.Height - space + 2);



            // прямая oy и две "палочки для стрелки"
            for (int i = 0; i <= arroww; i++)
            {
                graph.DrawLine(new Pen(Color.Black), new Point(space - i, bmp.Height - space), new Point(space - i, space));
                graph.DrawLine(new Pen(Color.Black), new Point(space - (int)(3 * scale/10) - (int)(arroww) + i, space + (int)(5 * scale/10)), new Point(space - (int)(arroww) + i, space));
                graph.DrawLine(new Pen(Color.Black), new Point(space + (int)(3 * scale/10) - i, space + (int)(5 * scale/10)), new Point(space - i, space));
            }
            if (ys != null) graph.DrawString(ys, new Font("Tempus Sans ITC", textsize, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), space + 5, space - 7); // Правее чем стрелочка
            // если задано максимальное, рисуем его
            if (ye != -1) graph.DrawString(ye.ToString(), new Font("Tempus Sans ITC", textsize, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 3, space - 7);
        }

        /// <summary>
        /// Рисуем прямоугольник (Только для гистограммы)
        /// </summary>
        /// <param name="x">координата левого верхнего угла</param>
        /// <param name="y">координата левого верхнего угла</param>
        /// <param name="w">ширина</param>
        /// <param name="h">высота</param>
        /// <param name="c">цвет</param>
        /// <param name="s">название</param>
        /// <param name="f">рисовать столбец или текст</param>
        ColorRect DrawRect(int x, int y, int w, int h, Color c, string s = null, bool f=true)
        {
            float textsize = (float)(TextSize * 2.5) * scale / 16;// размер шрифта
            if (f)
            {
                brush = new System.Drawing.SolidBrush(c); // кисточка нужного цвета
                graph.FillRectangle(this.brush, x, y, w, h);
            }
            else
            {
                // Добавление имени над прямоугольником
                if (s != null) graph.DrawString(s, new Font("Tempus Sans ITC", textsize, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), (float)(x + w / 2.0 - s.Length * textsize / 5.5), (float)(y - 28 * scale / 10.0));
            }
            return new ColorRect(x, y, w, h, s, c);
        }

        /// <summary>
        /// Рисование точки (карта рисков и карта соотношений)
        /// </summary>
        /// <param name="x">координата верхнего левого угла прямоугольника, в который вписана окружность</param>
        /// <param name="y"></param>
        /// <param name="r">радиус</param>
        /// <param name="c"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        ColorPoint DrawPoint(int x, int y, int r, Color c, string s)
        {
            float textsize = (float)(TextSize * 2.5); // размер шрифта
            brush = new System.Drawing.SolidBrush(c);
            graph.FillEllipse(this.brush, x - r, y - r, r * 2, r * 2);

            return new ColorPoint(x, y, r, s, c);
        }

        /// <summary>
        /// Функция для рисования гистограммы 
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="histogramwigth"></param>
        /// <param name="spaceingroup"></param>
        /// <param name="spacebetweengroups"></param>
        public void DrawHists(DataSender ds, int histogramwigth = 5, int spaceingroup = 2, int spacebetweengroups = 5)
        {
            mas_rect = new List<ColorRect>();
            List<List<int>> histogram = new List<List<int>>(); // массив, высот столбцов гистограммы приведённый к int
            int counter = 0;
            for (int i = 0; i < ds.histogram_h.Count; i++)
            {
                histogram.Add(new List<int>());
                for (int j = 0; j < ds.histogram_h[i].Count; j++)
                {
                    histogram[i].Add((int)(Math.Max(1,ds.histogram_h[i][j] * vscale)));
                    counter++;
                }
            }
            int wigth = (int)((((histogramwigth) + (spaceingroup)) * (counter) + (spacebetweengroups - spaceingroup) * (histogram.Count) + spacebetweengroups) * scale + space * 2);
            List<List<string>> names = ds.histogram_name; // массив, имён столбцов гистограммы

            // ширина белой области, на которой рисуется график

            // ищем максимальное значение риска для нахождения высоты белой области, на которой рисуется график
            int maxv = histogram[0][0];
            foreach (var i in histogram)
            {
                foreach (var j in i)
                {
                    maxv = Math.Max(maxv, j);
                }
            }

            int heigth = (int)((((maxv) + 28 / 10.0) * scale + space * 2 + space)); // spaсe - ширина рамки вокруг графика (для надписей) 

            bmp = new Bitmap(wigth, heigth);
            graph = Graphics.FromImage(bmp);

            DrawAxis(xs: "Атрибуты", ys: " ", ye: 1); //рисуем оси и создаем белое поле нужного размера

            // поэтапно рисуем прямоугольники для гистограммы
            int nowx = (int)(space + (spacebetweengroups) * scale); // нынешняя позиция по оси x
            for (int i = 0; i < histogram.Count; i++)
            {
                for (int j = 0; j < histogram[i].Count; j++)
                {
                    Color c = Color.Green; // далеее, смотря по высоте прямоугольника, при необходимости поменяем на желтый или красный
                    if (histogram[i][j] >= maxv / 3 && histogram[i][j] < maxv * 2 / 3) c = Color.Yellow;
                    if (histogram[i][j] >= maxv * 2 / 3) c = Color.Red;
                    mas_rect.Add(DrawRect((int)(nowx), (int)(bmp.Height - space - (int)(histogram[i][j] * scale)), (int)(histogramwigth * scale), (int)(histogram[i][j] * scale), c, names[i][j]));
                    nowx += (int)((histogramwigth + spaceingroup) * scale);
                }
                nowx += (int)((spacebetweengroups - spaceingroup) * scale);
            }
            nowx = (int)(space + (spacebetweengroups) * scale); // нынешняя позиция по оси x
            for (int i = 0; i < histogram.Count; i++)
            {
                maxv = 0;
                for (int j = 0; j < histogram[i].Count; j++)
                {
                    maxv = Math.Max(maxv, histogram[i][j]);
                }
                for (int j = 0; j < histogram[i].Count; j++)
                {
                    Color c = Color.Green; // далеее, смотря по высоте прямоугольника, при необходимости поменяем на желтый или красный
                    if (histogram[i][j] >= maxv / 3 && histogram[i][j] < maxv * 2 / 3) c = Color.Yellow;
                    if (histogram[i][j] >= maxv * 2 / 3) c = Color.Red;
                    if (j == histogram[i].Count / 2)
                    {
                        DrawRect((int)(nowx), (int)(bmp.Height - space - (int)(maxv * scale + 28)), (int)(histogramwigth * scale), (int)(maxv * scale + 28), c, ds.histogram_attr_name[i], false);
                    }
                    DrawRect((int)(nowx), (int)(bmp.Height - space - (int)(histogram[i][j] * scale)), (int)(histogramwigth * scale), (int)(histogram[i][j] * scale), c, (j + 1).ToString(), false);
                    nowx += (int)((histogramwigth + spaceingroup) * scale);
                }
                nowx += (int)((spacebetweengroups - spaceingroup) * scale);
            }

        }

        /// <summary>
        /// Функция для построение 2-го графика (карта рисков)
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        public void DrawPoints(DataSender ds, DataSender.Func f1 = null, DataSender.Func f2 = null)
        {
            mas_point = new List<ColorPoint>();
            if (f1 == null)
            {
                if (ds.f1 != null)
                {
                    f1 = ds.f1;
                }
                else
                {
                    f1 = delegate (double x) { return ((1.0 / (Math.Max(0,x * 100.0 - 32))) + 32) / 100.0; };
                }
            }
            if (f2 == null)
            {
                if (ds.f2 != null)
                {
                    f2 = ds.f2;
                }
                else
                {
                    f2 = delegate (double x) { return ((1.0 / (Math.Max(0,x * 100.0 - 70))) + 70) / 100.0; };
                }
            }

            int maxvx = ds.points[0].X; // ищем максимальное значение по x и y, чтобы понять, какую область надо выделять под график
            int maxvy = ds.points[0].Y;
            int maxvr = (int)ds.points[0].r; // ищем максимальный радиус, чтобы относительно него вычислить размер области, на которой рисуется график
            foreach (var i in ds.points)
            {
                maxvx = Math.Max(maxvx, i.X);
                maxvy = Math.Max(maxvy, i.Y);
                maxvr = Math.Max(maxvr, (int)i.r);
            }
            int wigth = (int)(Math.Max((maxvx + 3 * maxvr), 50) * scale + space * 3);  //определяем ширину бимпама
            int heigth = (int)(Math.Max((maxvy + 3 * maxvr), 50) * scale + space * 3 + space); // определяем высоту бимпама
            bmp = new Bitmap(wigth, heigth);
            graph = Graphics.FromImage(bmp);

            DrawAxis(xs: "Вероятность", ys: "Влияние", xe: 1, ye: 1);// xe: 1, ye: 1 - для  отображения 0 и 1 на осях графиков

            // отрисовка точек
            for (int i = 0; i < ds.points.Count; i++)
            {
                //Color c = Color.Green; // аналогично опредеелнию цвета для графика №1
                //if (ds.points[i].y >= f1(ds.points[i].x) && ds.points[i].y < f2(ds.points[i].x)) c = Color.Yellow;
                //if (ds.points[i].y >= f2(ds.points[i].x)) c = Color.Red;
                string name = ds.points[i].ToString(3,2);  // 2 - номер графика (нумерация здесь с 1)
                mas_point.Add(DrawPoint((int)(ds.points[i].X * scale + space * 2), (int)(bmp.Height - space * 2 - (int)(ds.points[i].Y * scale)), (int)(ds.points[i].r), ds.points[i].c, name));
            }
        }

        /// <summary>
        /// Функция  для отрисовки 3-го графика (карта соотношений) 
        /// </summary>
        /// <param name="ds"></param>
        public void DrawBigPoints(DataSender ds)
        {
            mas_point = new List<ColorPoint>();
            int maxvx = ds.points[0].X; // ищем максимальное значение по x и y, чтобы понять, какую область надо выделять под график
            int maxvy = ds.points[0].Y;
            int maxvr = (int)ds.points[0].r; // ищем максимальный радиус, чтобы относительно него вычислить размер области, на которой рисуется график
            foreach (var i in ds.points)
            {
                maxvx = Math.Max(maxvx, i.X);
                maxvy = Math.Max(maxvy, i.Y);
                maxvr = Math.Max(maxvr, (int)i.r);
            }
            int wigth = (int)(Math.Max((maxvx + 3 * maxvr), 50) * scale + space * 2);  //определяем ширину бимпама
            int heigth = (int)(Math.Max((maxvy + 3 * maxvr), 50) * scale + space * 2 + space); // определяем высоту бимпама
            bmp = new Bitmap(wigth, heigth);
            graph = Graphics.FromImage(bmp);

            DrawAxis(xs: "Качество системы", ys: "Средневзвешенный риск системы", xe: 1, ye: 1);

            for (int i = 0; i < ds.points.Count; i++)
            {
                string name = ds.points[i].ToString(3,3);  //3 - номер графика (нумерация здесь с 1)
                mas_point.Add(DrawPoint((int)(ds.points[i].X * scale + space), (int)(bmp.Height - space - (int)(ds.points[i].Y * scale)), (int)(Math.Max(1,ds.points[i].r * scale)), ds.points[i].c, name));
            }
        }
    }
}
