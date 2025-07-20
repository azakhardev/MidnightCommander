using MidnightCommander.EditWindowFunctions;
using MidnightCommander.Tools;
using MidnightCommander.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.EditPopUpWindows
{
    public class PopUpSearch : EditFunctions
    {
        public PopUpSearch(File_Editor_Window few)
        {
            this.FileEditorWindow = few;

            this.Components.Add(new TextBox());

            Button btnOk = new Button() { Title = "Ok" };
            btnOk.Clicked += BtnOk_Clicked;

            Button btnFindAll = new Button() { Title = "Find All" };
            btnOk.Clicked += BtnFindAll_Clicked;

            Button btnCancel = new Button() { Title = "Cancel" };
            btnCancel.Clicked += BtnNo_Clicked;

            this.Components.Add(btnOk);
            this.Components.Add(btnFindAll);
            this.Components.Add(btnCancel);
        }

        public override void Draw()
        {
            OptionNotSelected();

            Console.SetCursorPosition(35, 7);
            Console.Write("┌".PadRight(79, '─') + "┐");

            Console.SetCursorPosition(35, 8);
            Console.Write("│ Enter text to find:".PadRight(79, ' ') + '│');
          
            Console.SetCursorPosition(35, 9);
            Console.Write($"│ {(Components[0] as TextBox).Value}".PadRight(79, ' ') + '│');
            
            Console.SetCursorPosition(35, 10);
            Console.Write("├".PadRight(79, '─') + '┤');

            Console.SetCursorPosition(35, 11);
            Console.Write("│ (*) Normal".PadRight(39, ' ') + "[ ] Key sensetive".PadRight(40, ' ') + '│');

            Console.SetCursorPosition(35, 12);
            Console.Write("│ ( ) Regular expression".PadRight(39, ' ') + "[ ] Reversed".PadRight(40, ' ') + '│');

            Console.SetCursorPosition(35, 13);
            Console.Write("│ ( ) Hexadecimal".PadRight(39, ' ') + "[ ] In selection".PadRight(40, ' ') + '│');

            Console.SetCursorPosition(35, 14);
            Console.Write("│ ( ) Search by wildcard".PadRight(39, ' ') + "[ ] Only complete words".PadRight(40, ' ') + '│');

            Console.SetCursorPosition(35, 15);
            Console.Write("│".PadRight(39, ' ') + "[ ] Every character set".PadRight(40, ' ') + '│');

            Console.SetCursorPosition(35, 16);
            Console.Write("├".PadRight(79, '─') + '┤');

            Console.SetCursorPosition(35, 17);
            Console.Write("│".PadRight(27, ' '));

            if (OptionSelected == 1)
                OptionIsSelected();

            Console.Write((Components[1] as Button).Title);
            OptionNotSelected();

            Console.Write(new string(' ',3));

            if (OptionSelected == 2)
                OptionIsSelected();

            Console.Write((Components[2] as Button).Title);
            OptionNotSelected();

            Console.Write(new string(' ', 3));

            if (OptionSelected == 3)
                OptionIsSelected();

            Console.Write((Components[3] as Button).Title);
            OptionNotSelected();

            Console.Write("".PadRight(30, ' ') + '│');

            Console.SetCursorPosition(35, 18);
            Console.Write("└".PadRight(79, '─') + '┘');

            if (OptionSelected == 0)
                Console.SetCursorPosition((Components[0] as TextBox).Value.Length+37, 9);
        }

        public override void HandleKey(ConsoleKeyInfo info)
        {
            if (info.Key == ConsoleKey.Tab)
            {
                this.OptionSelected = (this.OptionSelected + 1) % this.Components.Count;
            }
            else if (info.Key == ConsoleKey.F7) 
            {
                Application.Windows.RemoveAt(Application.WindowSelected);
                Application.WindowSelected--;
            }
            else
            {
                this.Components[this.OptionSelected].HandleKey(info);
            }
        }

        public void BtnOk_Clicked()
        {
            Find(false);
        }

        public void BtnFindAll_Clicked()
        {
            Find(true);
        }

        public void Find(bool all)
        {
            if (all == false)
            {
                bool first = false;
                int i = 0;
                foreach (string line in FileEditorWindow.Lines)
                {
                    Console.SetCursorPosition(0, i);
                    if (line.Contains((Components[0] as TextBox).Value) && first != true)
                    {
                        string firstPart = line.Substring(0, line.IndexOf((Components[0] as TextBox).Value));
                        string selectedPart = line.Substring(line.IndexOf((Components[0] as TextBox).Value), (Components[0] as TextBox).Value.Length-1);
                        string lastPart = line.Substring(firstPart.Length + selectedPart.Length - 2,line.Length-1);

                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(firstPart);

                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(selectedPart);

                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(lastPart);

                        first = true;
                    }
                    else 
                    {
                        Console.Write(line);
                    }
                    i++;
                }
            }
            else if (all == true)
            {
                int i = 0;
                foreach (string line in FileEditorWindow.Lines)
                {                    
                    Console.SetCursorPosition(0, i);
                    if (line.Contains((Components[0] as TextBox).Value))
                    {                        string firstPart = line.Substring(0, line.IndexOf((Components[0] as TextBox).Value));
                        string selectedPart = line.Substring(line.IndexOf((Components[0] as TextBox).Value), (Components[0] as TextBox).Value.Length - 1);
                        string lastPart = line.Substring(firstPart.Length + selectedPart.Length - 2, line.Length - 1);

                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(firstPart);

                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(selectedPart);

                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(lastPart);
                    }
                    else
                    {
                        Console.Write(line);
                    }
                    i++;
                }
            }
        }
    }
}
