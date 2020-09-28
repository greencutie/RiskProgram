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
    /// Класс для передачи данных для рисования графика
    /// </summary>
    public class DataSender
    {
        public int n = 0; // Номер функции для рисования графика
        // для n==0
        public List<List<double>> histogram_h = new List<List<double>>(); // высоты столбцов для гистограммы
        public List<List<string>> histogram_name = new List<List<string>>(); // имена для гистограммы
        public List<string> histogram_attr_name = new List<string>(); // имена для груп гистограмм для одного атрибута гистограммы
        // для n==1 || n==2
        public List<ColorPoint> points = new List<ColorPoint>(); // второй и третий график
        public delegate double Func(double x);  // делегат для подачи функций разграничения цветов точек на графике
        public Func f1 = null; // функция для карты рисков - граница зеленого и желтого
        public Func f2 = null; // функция для карты рисков - граница желтого и красного
    }
}
