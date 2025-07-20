using MidnightCommander.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidnightCommander.EditPopUpWindows;

namespace MidnightCommander.EditButtons
{
    public class Search : IEditButton
    {
        public override event Action<Window> PopUpInvoke;

        public Search(File_Editor_Window few) 
        {
            this.FileEditorWindow = few;
        }
        public override void Press()
        {
            PopUpInvoke.Invoke(new PopUpSearch(FileEditorWindow));
        }
    }
}
