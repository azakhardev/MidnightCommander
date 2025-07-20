using MidnightCommander.EditWindowFunctions;
using MidnightCommander.PopUpWindows;
using MidnightCommander.Windows;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.EditPopUpWindows
{
    public class Mover : EditFunctions
    {
        Copier Copier { get; set; }
        Deleter Deleter { get; set; }
        public Mover(File_Editor_Window few)
        {
            this.FileEditorWindow = few;
            this.Copier = new Copier(few);
            this.Deleter = new Deleter(few);
        }
        public override void Draw()
        {
            Deleter.Draw();
            Copier.Draw();           
        }

        public override void HandleKey(ConsoleKeyInfo info)
        {

        }
    }
}