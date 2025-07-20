using MidnightCommander.EditWindowFunctions;
using MidnightCommander.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.EditPopUpWindows
{
    public class PopUpEPullDn : EditFunctions
    {
        public PopUpEPullDn(File_Editor_Window few) 
        {
            this.FileEditorWindow = few;
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
