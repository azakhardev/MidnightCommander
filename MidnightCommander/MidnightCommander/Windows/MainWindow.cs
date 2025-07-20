using MidnightCommander.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander
{
    public class Main_Window : Window
    {
        public List<Table> Tables = new List<Table>();

        public List<IButton> Buttons = new List<IButton>();

        public int TableSelected { get; set; } = 0;

        public List<string> FolderName = new List<string>();

        public Main_Window()
        {
            Table tb1 = new Table(0);
            Table tb2 = new Table(75);

            FolderName.Add("C:");
            FolderName.Add("C:");

            Tables.Add(tb1);
            GetNewData("C:");
            SwitchWindow();

            Tables.Add(tb2);
            GetNewData("C:");
            SwitchWindow();

            Buttons.Add(new Help(this) { Name = "Help", ButtonKey = "F1" });
            Buttons.Add(new Menu(this) { Name = "Menu", ButtonKey = "F2" });
            Buttons.Add(new View(this) { Name = "View", ButtonKey = "F3" });
            Buttons.Add(new Edit(this) { Name = "Edit", ButtonKey = "F4" });
            Buttons.Add(new Copy(this) { Name = "Copy", ButtonKey = "F5" });
            Buttons.Add(new Move(this) { Name = "Move", ButtonKey = "F6" });
            Buttons.Add(new Create(this) { Name = "Create", ButtonKey = "F7" });
            Buttons.Add(new Delete(this) { Name = "Delete", ButtonKey = "F8" });
            Buttons.Add(new PullDn(this) { Name = "PullDn", ButtonKey = "F9" });
            Buttons.Add(new Quit(this) { Name = "Quit", ButtonKey = "F10" });

            foreach (IButton item in Buttons)
            {
                item.OnCreate += SwitchPopUp;
            }
        }

        public override void Draw()
        {
            DrawHead();
            DrawBody();

            for (int i = 0; i < Tables.Count; i++)
            {
                Tables.ElementAt(i).Draw();
            }
            DrawButtons();
        }

        public override void HandleKey(ConsoleKeyInfo info)
        {
            if (TableSelected == 0)
            {
                Tables.ElementAt(TableSelected).HandleKey(info);
            }
            else if (TableSelected == 1)
            {
                Tables.ElementAt(TableSelected).HandleKey(info);
            }

            if (info.Key == ConsoleKey.Tab)
            {
                SwitchWindow();
            }

            if (info.Key == ConsoleKey.Enter)
            {                
                string path = Tables[TableSelected].Handle.Path;
                if (Tables[TableSelected].RowSelected == 0 && path.Contains(@"\"))
                {
                    this.FolderName.RemoveAt(TableSelected);
                    this.FolderName.Insert(TableSelected, path.Remove(path.LastIndexOf(@"\")));
                }
                else if (Tables[TableSelected].RowSelected > 0 && !Tables[TableSelected].RowName.Contains('.'))
                {
                    this.FolderName.RemoveAt(TableSelected);
                    this.FolderName.Insert(TableSelected, path + @"\" + Tables[TableSelected].RowName);
                }
                else if (Tables[TableSelected].RowName.Contains('.')) 
                {

                }
                else
                    this.FolderName[TableSelected] = "";
                Console.ResetColor();
                Console.Clear();
                GetNewData(Tables[TableSelected].GetNewPath());
                Tables[TableSelected].RowSelected = 0;
                Tables[TableSelected].Offset = 0;
            }

            int i = 0;
            foreach (IButton button in Buttons)
            {
                if (info.Key.ToString() == button.ButtonKey)
                    Buttons[i].Press();
                i++;
            }
        }

        public void DrawHead()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Left        File        Command        Options        Right".PadRight(150, ' '));
            Console.ResetColor();
        }

        public void DrawBody()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("┌──>" + FolderName[0].PadRight(70, '─') + "┐" + "┌──>" + FolderName[1].PadRight(70, '─') + "┐");
            Console.Write("│".PadRight(26, ' ') + "Name".PadRight(27, ' ') + '│' + " Size".PadRight(7, ' ') + '│' + "   MTime".PadRight(12, ' ') + '│');
            Console.WriteLine("│".PadRight(26, ' ') + "Name".PadRight(27, ' ') + '│' + " Size".PadRight(7, ' ') + '│' + "   MTime".PadRight(12, ' ') + '│');
            Console.SetCursorPosition(0, Tables.ElementAt(0).MaxRows + 3);
        }

        public void SwitchPopUp(Window window)
        {
            Application.SwitchWindow(window);
        }

        public void DrawButtons()
        {
            int i = 0;
            foreach (IButton btn in Buttons)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(i + 1);
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"{btn.Name} ");
                i++;
            }
        }

        public void GetNewData(string path)
        {
            Tables[TableSelected].Handle = new Handler(path);
        }

        public void SwitchWindow()
        {
            if (TableSelected == 0)
                TableSelected = 1;
            else if (TableSelected == 1)
                TableSelected = 0;
        }
    }
}
