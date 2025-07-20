using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidnightCommander.PopUpWindows;
using MidnightCommander.Tools;
using MidnightCommander.Windows;

namespace MidnightCommander
{
    public abstract class PopUpWindow : Window
    {
        public DirectoryInfo Dir { get; set; }

        public FileInfo File { get; set; }

        public Main_Window MainWindow { get; set; }

        public File_Editor_Window FileEditorWindow { get; set; }
        public int OptionSelected { get; set; }

        public List<IEditComponent> Components = new List<IEditComponent>();

        public void BtnNo_Clicked() 
        {
            Application.Windows.RemoveAt(Application.WindowSelected);
            Application.WindowSelected --;
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
