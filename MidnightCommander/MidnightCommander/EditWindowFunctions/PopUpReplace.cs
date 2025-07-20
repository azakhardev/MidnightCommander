using MidnightCommander.EditWindowFunctions;
using MidnightCommander.Tools;
using MidnightCommander.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.EditPopUpWindows
{
    public class PopUpReplace : EditFunctions
    {
        public PopUpReplace(File_Editor_Window few) 
        {
            this.FileEditorWindow = few;

            this.Components.Add(new TextBox());
            this.Components.Add(new TextBox());

            Button btnOk = new Button() { Title = "Ok" };
            btnOk.Clicked += BtnOk_Clicked;

            Button btnCancel = new Button() { Title = "Cancel" };
            btnCancel.Clicked += BtnNo_Clicked;

            this.Components.Add(btnOk);
            this.Components.Add(btnCancel);
        }

        public override void Draw()
        {
            OptionNotSelected();

            Console.SetCursorPosition(35, 6);
            Console.Write("┌".PadRight(79, '─') + "┐");

            Console.SetCursorPosition(35, 7);
            Console.Write("│ Enter text to find:".PadRight(79, ' ') + '│');

            Console.SetCursorPosition(35, 8);
            Console.Write($"│ {(Components[0] as TextBox).Value}".PadRight(79, ' ') + '│');

            Console.SetCursorPosition(35, 9);
            Console.Write("│ Enter new text:".PadRight(79, ' ') + '│');

            Console.SetCursorPosition(35, 10);
            Console.Write($"│ {(Components[1] as TextBox).Value}".PadRight(79, ' ') + '│');

            Console.SetCursorPosition(35, 11);
            Console.Write("├".PadRight(79, '─') + '┤');

            Console.SetCursorPosition(35, 12);
            Console.Write("│ (*) Normal".PadRight(39, ' ') + "[ ] Key sensetive".PadRight(40, ' ') + '│');

            Console.SetCursorPosition(35, 13);
            Console.Write("│ ( ) Regular expression".PadRight(39, ' ') + "[ ] Reversed".PadRight(40, ' ') + '│');

            Console.SetCursorPosition(35, 14);
            Console.Write("│ ( ) Hexadecimal".PadRight(39, ' ') + "[ ] In selection".PadRight(40, ' ') + '│');

            Console.SetCursorPosition(35, 15);
            Console.Write("│ ( ) Search by wildcard".PadRight(39, ' ') + "[ ] Only complete words".PadRight(40, ' ') + '│');

            Console.SetCursorPosition(35, 16);
            Console.Write("│".PadRight(39, ' ') + "[ ] Every character set".PadRight(40, ' ') + '│');

            Console.SetCursorPosition(35, 17);
            Console.Write("├".PadRight(79, '─') + '┤');

            Console.SetCursorPosition(35, 18);
            Console.Write("│".PadRight(30, ' '));

            if (OptionSelected == 2)
                OptionIsSelected();

            Console.Write((Components[2] as Button).Title);
            OptionNotSelected();

            Console.Write(new string(' ', 11));

            if (OptionSelected == 3)
                OptionIsSelected();

            Console.Write((Components[3] as Button).Title);
            OptionNotSelected();

            Console.Write("".PadRight(30, ' ') + '│');

            Console.SetCursorPosition(35, 19);
            Console.Write("└".PadRight(79, '─') + '┘');

            if (OptionSelected == 0)
                Console.SetCursorPosition((Components[0] as TextBox).Value.Length + 37, 8);

            if (OptionSelected == 1)
                Console.SetCursorPosition((Components[1] as TextBox).Value.Length + 37, 10);
        }

        public override void HandleKey(ConsoleKeyInfo info)
        {
            if (info.Key == ConsoleKey.Tab)
            {
                this.OptionSelected = (this.OptionSelected + 1) % this.Components.Count;
            }
            else
            {
                this.Components[this.OptionSelected].HandleKey(info);
            }
        }

        public void BtnOk_Clicked() 
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Blue;

            Replace();

            Application.Windows.RemoveAt(Application.WindowSelected);
            Application.WindowSelected--;
        }

        public void Replace() 
        {
            int i = 0;
            foreach (string line in FileEditorWindow.Lines)
            {
                Console.SetCursorPosition(0, i);

                if (line.Contains((Components[0] as TextBox).Value))
                {
                    line.Replace((Components[0] as TextBox).Value, (Components[1] as TextBox).Value);
                    Console.Write(line);
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
