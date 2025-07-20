using MidnightCommander.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.PopUpWindows
{
    public class PopUpDelete : PopUpWindow
    {
        private string Path { get; set; }
        public PopUpDelete(Main_Window mw)
        {
            this.MainWindow = mw;
            
            this.Path = mw.Tables[mw.TableSelected].Handle.Path + @"\" + mw.Tables[mw.TableSelected].Handle.Rows[mw.Tables[mw.TableSelected].RowSelected].Name ;

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
            Console.Write("║".PadRight(4, ' ') + "Do you want to delete this file?".PadRight(36, ' ') + "║");

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
            Delete();
            Application.Windows.RemoveAt(Application.WindowSelected);
            Application.WindowSelected--;
        }

        public void Delete()
        {
            this.Dir = new DirectoryInfo(Path);
            this.File = new FileInfo(Path);
            try
            {
                foreach (DirectoryInfo item in Dir.GetDirectories())
                {
                    item.Delete(true);
                }
                foreach (FileInfo item in Dir.GetFiles())
                {
                    item.Delete();
                }
                Dir.Delete();
            }
            catch (Exception)
            {
                File.Delete();
            }
        }
    }
}
