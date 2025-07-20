using MidnightCommander.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidnightCommander.EditPopUpWindows;
using MidnightCommander.PopUpWindows;

namespace MidnightCommander.EditButtons
{
    public class EDelete : IEditButton
    {
        public override event Action<Window> PopUpInvoke;

        public EDelete(File_Editor_Window few)
        {
            this.FileEditorWindow = few;
        }

        public override void Press()
        {
            PopUpInvoke.Invoke(new Deleter(FileEditorWindow));
        }
    }
}