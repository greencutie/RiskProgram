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
    /// класс для цветной точки на графиках: "карта рисков" и "карта соотношений"
    /// </summary>
    public class ColorPoint
    {
        public double x = 0, y = 0; // Координаты точки
        public int X { get { return (int)(x * scalecoeff); } } // Данные координаты использует функция рисования при отображении точки
        public int Y { get { return (int)(y * scalecoeff); } }
        public double r { get { return Math.Max(0, rv * coeff); } } // Радиус видимой точки - радиус нарисованной точки, а не исходный радиус
        public double rv = 3; // исходный подаваемый радиус точки 
        public string name = "";
        public Color c = Color.Black;
        public double scalecoeff = 1;
        public double coeff = 1;

        public ColorPoint() { }

        public ColorPoint(double x, double y, double r, string name, double scalecoeff = 1, double coeff = 1)
        {
            this.x = x; // координаты точки
            this.y = y;// координаты точки
            this.rv = r; // радиус при выделении
            this.name = name;  // имя при наведении 
            this.scalecoeff = scalecoeff;
            this.coeff = coeff;
        }

        public ColorPoint(double x, double y, double r, string name, Color c, double scalecoeff = 1, double coeff = 1)
        {
            this.x = x; // координаты точки
            this.y = y;// координаты точки
            this.rv = r; // радиус при выделении
            this.name = name;  // имя при наведении 
            this.c = c; // цвет 
            this.scalecoeff = scalecoeff;
            this.coeff = coeff;
        }

        // приведение типов
        public static implicit operator Point(ColorPoint p)
        {
            return new Point((int)(p.x), (int)(p.y));
        }
        public static implicit operator ColorPoint(Point p)
        {
            return new ColorPoint(p.X, p.Y, 3, "", Color.Black);
        }

        //Оператор получения длины вектора по двум точкам с помощью знака +
        public static double operator +(ColorPoint a, ColorPoint b)
        {
            if (a == null || b == null) throw new NullReferenceException();
            return Math.Sqrt(((a.X - b.X) * (a.X - b.X)) + ((a.Y - b.Y) * (a.Y - b.Y)));
        }

        //переопределенный метод ToString()
        public override string ToString()
        {
            return ToString(3,3);
        }
        //Информация об объекте
        public string ToString(int prec, int num = 2)
        {
            if (num == 2)
            {
                int p = 1;
                for (int i = 0; i < prec; i++)
                {
                    p *= 10;
                }
                return $"{name}\r\nВероятность атрибута {getstr(x, p)}\r\nВлияние атрибута {getstr(y, p)}\r\n";
            }

            if (num == 3)
            {
                int p = 1;
                for (int i = 0; i < prec; i++)
                {
                    p *= 10;
                }
                return $"{name}\r\nКачество {getstr(x, p)}\r\nСредневзвешенный риск системы {getstr(y, p)}\r\nCтоимость {getstr(rv, p)} тыс $";
            }

            return "";
        }

        /// <summary>
        /// Вывод не больше 3 знаков после запятой
        /// </summary>
        /// <param name="x"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public string getstr(double x, int p)
        {
            //string rs = "" + (int)(x);
            //if (((int)(x * p) % p) > 0)
            //{
            //    rs += ",";
            //    string rs2 = "";
            //    int p2 = p;
            //    bool flaga = false;
            //    while (p2 / 10 > 0)
            //    {
            //        int n = (((int)(x * p2) % p2)) % 10;
            //        if (flaga || n != 0)
            //        {
            //            flaga = true;
            //            rs2 += $"{ n}";
            //        }
            //        p2 /= 10;
            //    }

            //    rs += new string((rs2.Reverse()).ToArray<char>());

            //}

            //return rs;

            string x_s = String.Format("{0:0.###}", x);

            return x_s;
        }

        

    }
}
