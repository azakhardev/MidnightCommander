using MidnightCommander.PopUpWindows;
using MidnightCommander.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidnightCommander.EditPopUpWindows;

namespace MidnightCommander.EditButtons
{
    public class Mark : IEditButton
    {
        public override event Action<Window> PopUpInvoke;

        public Mark(File_Editor_Window few) 
        {
            FileEditorWindow = few;
        }

        public override void Press()
        {
            PopUpInvoke.Invoke(new Marker(FileEditorWindow));
        }
    }
}
