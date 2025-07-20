using MidnightCommander.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.EditButtons
{
    public abstract class IEditButton
    {
        public abstract event Action<Window> PopUpInvoke;

        public string Name { get; set; }

        public string ButtonKey { get; set; }

        public File_Editor_Window FileEditorWindow { get; set; }

        public abstract void Press();
    }
}
