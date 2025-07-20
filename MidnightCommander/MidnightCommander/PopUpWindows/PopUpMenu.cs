using MidnightCommander.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.PopUpWindows
{
    public class PopUpMenu : PopUpWindow
    {       
        public PopUpMenu(Main_Window mw)
        {
            this.MainWindow = mw;
        }

        public override void Draw()
        {
            Application.Windows.RemoveAt(Application.WindowSelected);
            Application.WindowSelected--;
        }

        public override void HandleKey(ConsoleKeyInfo info)
        {

        }
    }
}
