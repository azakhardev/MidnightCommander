using MidnightCommander.Tools;
using MidnightCommander.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.EditWindowFunctions
{
    public abstract class EditFunctions : Window
    {
        public File_Editor_Window FileEditorWindow { get; set; }

        public int OptionSelected { get; set; }

        public List<IEditComponent> Components = new List<IEditComponent>();

        public void BtnNo_Clicked()
        {
            Application.Windows.RemoveAt(Application.WindowSelected);
            Application.WindowSelected--;
        }

        public void OptionIsSelected()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public void OptionNotSelected()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
