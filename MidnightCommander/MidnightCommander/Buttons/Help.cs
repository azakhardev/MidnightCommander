using MidnightCommander.PopUpWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.Buttons
{
    public class Help : IButton
    {
        public override event Action<Window> OnCreate;

        public Help(Main_Window mw)
        {
            this.MainWindow = mw;
        }

        public override void Press()
        {
            OnCreate.Invoke(new PopUpHelp(MainWindow));
        }
    }
}
