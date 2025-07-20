using MidnightCommander.PopUpWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.Buttons
{
    public class PullDn : IButton
    {
        public override event Action<Window> OnCreate;

        public PullDn(Main_Window mw)
        {
            this.MainWindow = mw;
        }

        public override void Press()
        {
            OnCreate.Invoke(new PopUpPullDn(MainWindow));
        }
    }
}
