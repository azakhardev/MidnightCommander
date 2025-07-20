using MidnightCommander.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MidnightCommander.PopUpWindows
{
    public class PopUpCreate : PopUpWindow
    {
        private string Path { get; set; }

        public PopUpCreate(Main_Window mw)
        {
            this.MainWindow = mw;

            this.Path = mw.Tables[mw.TableSelected].Handle.Path;

            this.Components.Add(new TextBox());

            Button btnOk = new Button() { Title = "OK" };
            btnOk.Clicked += BtnOk_Clicked;

            Button btnCancel = new Button() { Title = "Cancel" };
            btnCancel.Clicked += BtnNo_Clicked;

            this.Components.Add(btnOk);
            this.Components.Add(btnCancel);
        }

        public override void Draw()
        {
            //dodelat maximalni delku/posouvat
            OptionNotSelected();
            Console.SetCursorPosition(55, 14);
            Console.Write("╔".PadRight(40, '═') + "╗");

            Console.SetCursorPosition(55, 15);
            Console.Write("║".PadRight(8, ' ') + "Write name of the file:".PadRight(32, ' ') + "║");

            Console.SetCursorPosition(55, 16);
            Console.Write("║".PadRight(4, ' ') + "|" + (Components[0] as TextBox).Value.PadRight(31, ' '));

            if (OptionSelected == 0)
            {
                OptionIsSelected();
                Console.SetCursorPosition(60 + (Components[0] as TextBox).Value.Length, 16);
                Console.Write(' ');
                OptionNotSelected();
            }

            Console.SetCursorPosition(90, 16);
            Console.Write("|".PadRight(5, ' ') + '║');
            OptionNotSelected();

            Console.SetCursorPosition(55, 18);
            Console.Write("╚".PadRight(40, '═') + '╝');

            Console.SetCursorPosition(55, 17);
            Console.Write("║".PadRight(10, ' '));
            OptionNotSelected();
            if (OptionSelected == 1)
                OptionIsSelected();
            Console.Write("OK");
            OptionNotSelected();
            Console.Write(new string(' ', 10));
            OptionNotSelected();
            if (OptionSelected == 2)
                OptionIsSelected();
            Console.Write("Cancel");
            OptionNotSelected();
            Console.Write("".PadRight(12, ' ') + '║');
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
            Create();
            Application.Windows.RemoveAt(Application.WindowSelected);
            Application.WindowSelected--;
        }

        public void Create()
        {
            this.Dir = new DirectoryInfo(Path + (Components[0] as TextBox).Value);
            this.File = new FileInfo(Path);

            if (Components[0].ToString().Contains(".txt"))
            {
                if (File.Exists)
                    return;
                else
                    System.IO.File.Create(Path + @"\" + (Components[0] as TextBox).Value);
            }
            else
            {
                if (Dir.Exists )
                    return;
                else
                    Directory.CreateDirectory(Path + @"\" + (Components[0] as TextBox).Value);
            }
        }
    }
}
