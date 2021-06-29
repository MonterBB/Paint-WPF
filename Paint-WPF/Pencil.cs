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
    /// Класс реализующий рисование карандашом.
    /// </summary>
    public static class Pencil
    {
        const string Mode = "Карандаш";

        /// <summary>
        /// Рисование карандашом.
        /// </summary>
        public static void Pencil_Drawing() 
        {
            if(Transfer.mode == Mode)
            {
                Transfer.inkCanvas.EditingMode = (InkCanvasEditingMode)1;
                Transfer.inkCanvas.DefaultDrawingAttributes.Width = Transfer.Size;
                Transfer.inkCanvas.DefaultDrawingAttributes.Height = Transfer.Size;
            }
        }
    }
}
