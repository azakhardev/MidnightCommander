using MidnightCommander.Tools;
using MidnightCommander.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.PopUpWindows
{
    public class PopUpEdit : PopUpWindow
    {
        public PopUpEdit(Main_Window mw)
        {
            this.MainWindow = mw;

            Button btnOk = new Button() { Title = "YES" };
            btnOk.Clicked += BtnOk_Clicked;

            Button btnCancel = new Button() { Title = "NO" };
            btnCancel.Clicked += BtnNo_Clicked;

            this.Components.Add(btnOk);
            this.Components.Add(btnCancel);
        }

        public override void Draw()
        {
            OptionNotSelected();

            Console.SetCursorPosition(55, 14);
            Console.Write("╔".PadRight(40, '═') + "╗");

            Console.SetCursorPosition(55, 15);
            Console.Write("║".PadRight(5, ' ') + "Do you want to edit this file?".PadRight(35, ' ') + "║");

            Console.SetCursorPosition(55, 17);
            Console.Write("╚".PadRight(40, '═') + '╝');

            Console.SetCursorPosition(55, 16);
            Console.Write("║".PadRight(13, ' '));
            OptionNotSelected();
            if (OptionSelected == 0)
                OptionIsSelected();
            Console.Write("YES");

            OptionNotSelected();
            Console.Write(new string(' ', 9));

            if (OptionSelected == 1)
                OptionIsSelected();

            Console.Write("NO");
            OptionNotSelected();
            Console.Write("".PadRight(13, ' ') + '║');
        }

        public void BtnOk_Clicked() 
        {
            Application.Windows.RemoveAt(Application.WindowSelected);
            Application.WindowSelected--;
            Edit();            
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

        public void Edit() 
        {
            Application.SwitchWindow(new File_Editor_Window(MainWindow));
        }
    }
}
