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
    /// Класс реализующий ластик.
    /// </summary>
    public static class Eraser
    {
        const string Mode = "Стёрка";

        /// <summary>
        /// Реализация стёрки.
        /// </summary>
        public static void Erases_Canvas()
        {
            if(Transfer.mode == Mode)
            {
                Transfer.inkCanvas.DefaultDrawingAttributes.Color = Colors.White;
                if (Transfer.Size < 5)
                {
                    Transfer.inkCanvas.EditingMode = (InkCanvasEditingMode)1;
                    Transfer.inkCanvas.DefaultDrawingAttributes.Width = 5;
                    Transfer.inkCanvas.DefaultDrawingAttributes.Height = 5;
                }
                else
                {
                    Transfer.inkCanvas.EditingMode = (InkCanvasEditingMode)1;
                    Transfer.inkCanvas.DefaultDrawingAttributes.Width = Transfer.Size;
                    Transfer.inkCanvas.DefaultDrawingAttributes.Height = Transfer.Size;
                }
            }
        }
    }
}
