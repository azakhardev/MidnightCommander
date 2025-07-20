using MidnightCommander.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.PopUpWindows
{
    public class PopUpMove : PopUpWindow
    {
        private string OldPath { get; set; }

        private string NewPath { get; set; }

        public PopUpMove(Main_Window mw)
        {
            this.MainWindow = mw;

            this.OldPath = MainWindow.FolderName[MainWindow.TableSelected] + @"\" + MainWindow.Tables[MainWindow.TableSelected].RowName;

            this.NewPath = mw.FolderName[(mw.TableSelected + 1) % 2];

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
            Console.Write("║".PadRight(5, ' ') + "Do you want to move this file?".PadRight(35, ' ') + "║");

            Console.SetCursorPosition(55, 16);
            Console.Write("║".PadRight(5, ' ') + "Name:" + MainWindow.Tables[MainWindow.TableSelected].RowName.PadRight(30, ' ') + "║");

            Console.SetCursorPosition(55, 17);
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


            Console.SetCursorPosition(55, 18);
            Console.Write("╚".PadRight(40, '═') + '╝');
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
            Move(true);
            Application.Windows.RemoveAt(Application.WindowSelected);
            Application.WindowSelected--;
        }

        public void Move(bool loop)
        {
            this.Dir = new DirectoryInfo(OldPath);
            this.File = new FileInfo(OldPath);

            if (!Directory.Exists(NewPath + @"\" + Dir.Name))                
                Directory.CreateDirectory(NewPath + @"\" + Dir.Name);

            foreach (FileInfo file in Dir.GetFiles())
            {
                string path = NewPath + @"\" + file.Name;
                file.CopyTo(path);
            }

            if (loop == true)
            {
                foreach (DirectoryInfo item in Dir.GetDirectories())
                {
                    string newPath = NewPath + @"\" + item.Parent.Name;
                    OldPath = item.FullName;
                    NewPath = newPath;
                    Move(true);
                }
            }
            Dir.Delete();
        }
    }
}
