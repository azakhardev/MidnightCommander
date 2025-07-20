using MidnightCommander.EditPopUpWindows;
using MidnightCommander.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.EditButtons
{
    public class EMove : IEditButton
    {
        public override event Action<Window> PopUpInvoke;

        public EMove(File_Editor_Window few) 
        {
            this.FileEditorWindow = few;
        }
        public override void Press()
        {
            PopUpInvoke.Invoke(new Mover(FileEditorWindow));
        }
    }
}
