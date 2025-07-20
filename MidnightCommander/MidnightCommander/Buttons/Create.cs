using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MidnightCommander.PopUpWindows;

namespace MidnightCommander.Buttons
{
    public class Create : IButton
    {
        public override event Action<Window> OnCreate;

        public Create(Main_Window mw) 
        {
            this.MainWindow = mw;
        }

        public override void Press()
        {
            OnCreate.Invoke(new PopUpCreate(MainWindow));
        }
    }
}
