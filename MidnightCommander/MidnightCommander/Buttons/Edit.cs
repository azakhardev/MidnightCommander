using MidnightCommander.PopUpWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.Buttons
{
    public class Edit : IButton
    {
        public override event Action<Window> OnCreate;

        public Edit(Main_Window mw)
        {
            this.MainWindow = mw;
        }

        public override void Press()
        {
            if (MainWindow.Tables[MainWindow.TableSelected].Handle.Rows[MainWindow.Tables[MainWindow.TableSelected].RowSelected].Name.Contains(".txt"))
            OnCreate.Invoke(new PopUpEdit(MainWindow));
        }
    }
}
