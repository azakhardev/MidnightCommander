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
    public class PopUpSave : EditFunctions
    {
        public PopUpSave(File_Editor_Window few) 
        {
            this.FileEditorWindow = few;
                        
            Button btnYes = new Button() { Title = "YES" };
            btnYes.Clicked += BtnYes_Clicked;

            Button btnNo = new Button() { Title = "NO" };
            btnNo.Clicked += BtnCancel_Clicked;

            Button btnCancel = new Button() { Title = "Cancel" };
            btnCancel.Clicked += BtnNo_Clicked;

            this.Components.Add(btnYes);
            this.Components.Add(btnNo);
            this.Components.Add(btnCancel);
        }

        public override void Draw()
        {
            OptionNotSelected();

            Console.SetCursorPosition(55, 14);
            Console.Write("╔".PadRight(42, '═') + "╗");

            Console.SetCursorPosition(55, 15);
            Console.Write("║" + "Do you want to save changes in this file?" + "║");

            Console.SetCursorPosition(55, 17);
            Console.Write("╚".PadRight(42, '═') + '╝');

            Console.SetCursorPosition(55, 16);
            Console.Write("║".PadRight(7, ' '));
            
            
            if (OptionSelected == 0)
                OptionIsSelected();
            
            Console.Write("YES");
            OptionNotSelected();
            
            Console.Write(new string(' ', 7));

            if (OptionSelected == 1)
                OptionIsSelected();

            Console.Write("NO");
            OptionNotSelected();

            Console.Write(new string(' ', 7));

            if (OptionSelected == 2)
                OptionIsSelected();
            
            Console.Write("Cancel");
            OptionNotSelected();

            Console.Write("".PadRight(10, ' ') + '║');
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

        public void BtnCancel_Clicked() 
        {
            BtnNo_Clicked();
            BtnNo_Clicked();
        }

        public void BtnYes_Clicked() 
        {
            FileEditorWindow.Save();
            BtnNo_Clicked();
            BtnNo_Clicked();
        }
    }
}
