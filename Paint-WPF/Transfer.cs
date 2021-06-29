using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Paint_WPF
{
    /// <summary>
    /// Содержит статические ссылки на экземпляры элементов.
    /// </summary>
    public static class Transfer
    {
        public static InkCanvas inkCanvas;
        public static double Size;
        public static string mode;
        public static bool tPolygon = false;
        public static bool tPolyline = false;
        public static PointCollection PointC;
    }
}
