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
    /// Класс реализующий рисование кистью.
    /// </summary>
    public static class BrushPen
    {
        const string Mode = "Перо";

        /// <summary>
        /// Рисование кистью.
        /// </summary>
        public static void BrushPen_Drawing()
        {
            if (Transfer.mode == Mode && Transfer.Size >= 10)
            {
                Transfer.inkCanvas.EditingMode = (InkCanvasEditingMode)1;
                Transfer.inkCanvas.DefaultDrawingAttributes.Width = Transfer.Size;
                Transfer.inkCanvas.DefaultDrawingAttributes.Height = 2;
            }
            else if (Transfer.mode == Mode && Transfer.Size < 10)
            {
                Transfer.inkCanvas.EditingMode = (InkCanvasEditingMode)1;
                Transfer.inkCanvas.DefaultDrawingAttributes.Width = 10;
                Transfer.inkCanvas.DefaultDrawingAttributes.Height = 2;
            }
        }
    }
}
