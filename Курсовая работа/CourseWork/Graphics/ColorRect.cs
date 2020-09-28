using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class ColorRect
    {
        public double x = 0, y = 0; // Координаты точки
        public int X { get { return (int)(x * scalecoeff); } } // Данные координаты использует функция рисования при отображении точки
        public int Y { get { return (int)(y * scalecoeff); } }
        public double w { get { return Math.Max(0, wv * coeff); } } // Ширина видимого столбца - ширина нарисованного столбца, а не исходна ширина
        public double wv = 3; // исходный подаваемая широна столбца
        public double h { get { return Math.Max(0, hv * coeff); } } // Высота видимого столбца - высота нарисованного столбца, а не исходна высота
        public double hv = 3; // исходный подаваемая высота столбца
        public string name = "";
        public string paramname = "";
        public Color c = Color.Black;
        public double scalecoeff = 1;
        public double coeff = 1;

        public ColorRect() { }

        public ColorRect(double x, double y, double w, double h, string name, double scalecoeff = 1, double coeff = 1)
        {
            this.x = x; // координаты точки
            this.y = y;// координаты точки
            this.wv = w; // ширина при выделении
            this.hv = h; // высота при выделении
            this.name = name;  // имя при наведении 
            this.scalecoeff = scalecoeff;
            this.coeff = coeff;
        }

        public ColorRect(double x, double y, double w, double h, string name, Color c, double scalecoeff = 1, double coeff = 1)
        {
            this.x = x; // координаты точки
            this.y = y;// координаты точки
            this.wv = w; // ширина при выделении
            this.hv = h; // высота при выделении
            this.name = name;  // имя при наведении 
            this.c = c; // цвет 
            this.scalecoeff = scalecoeff;
            this.coeff = coeff;
        }

        //Оператор получения лежит ли точка внутри прямоугольника
        public static bool operator <(Point a, ColorRect b)
        {
            if (a == null || b == null) throw new NullReferenceException();
            if (b.X < a.X && a.X < (b.X + b.wv) && b.Y < a.Y && a.Y < (b.Y + b.hv)) return true;
            return false;
        }

        //Лежит ли точка вне прямоугольника
        public static bool operator >(Point a, ColorRect b)
        {
            if (a == null || b == null) throw new NullReferenceException();
            return !(a < b);
        }

        /// <summary>
        /// Вывод не больше 3 знаков после запятой
        /// </summary>
        /// <param name="x"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string getstr(double x, int p)
        {
            string x_s = String.Format("{0:0.###}", x);

            return x_s;
        }
    }
}
