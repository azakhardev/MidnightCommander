using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidnightCommander.EditButtons;

namespace MidnightCommander.Windows
{
    public class File_Editor_Window : Window
    {
        public Main_Window MainWindow { get; set; }

        public StreamReader Sr { get; set; }
        public StreamWriter Sw { get; set; }

        public int OffsetX { get; set; } = 0;

        public int OffsetY { get; set; } = 0;

        public int CursorPositionX { get; set; } = 0;

        public int CursorPositionY { get; set; } = 0;

        public List<int> MarkedX = new List<int>();

        public List<int> MarkedY = new List<int>();

        public int MaxRowsY { get; set; } = 26;

        public int MaxCharsX { get; set; } = 150;

        public List<string> MarkedLines = new List<string>();

        public List<string> Lines = new List<string>();

        public List<IEditButton> Buttons = new List<IEditButton>();

        public File_Editor_Window(Main_Window mw)
        {
            this.MainWindow = mw;
            this.Sr = new StreamReader(mw.Tables[mw.TableSelected].Handle.Path + @"\" + mw.Tables[mw.TableSelected].Handle.Rows[mw.Tables[mw.TableSelected].RowSelected].Name);
            using (Sr)
            {
                while (!Sr.EndOfStream)
                {
                    Lines.Add(Sr.ReadLine());
                }
            }

            Buttons.Add(new EHelp(this) { Name = "Help", ButtonKey = "F1" });
            Buttons.Add(new Save(this) { Name = "Search", ButtonKey = "F2" });
            Buttons.Add(new Mark(this) { Name = "Mark", ButtonKey = "F3" });
            Buttons.Add(new Replace(this) { Name = "Replace", ButtonKey = "F4" });
            Buttons.Add(new ECopy(this) { Name = "Copy", ButtonKey = "F5" });
            Buttons.Add(new EMove(this) { Name = "Move", ButtonKey = "F6" });
            Buttons.Add(new Search(this) { Name = "Search", ButtonKey = "F7" });
            Buttons.Add(new EDelete(this) { Name = "Delete", ButtonKey = "F8" });
            Buttons.Add(new EPullDn(this) { Name = "PullDn", ButtonKey = "F9" });
            Buttons.Add(new EQuit(this) { Name = "Quit", ButtonKey = "F10" });

            foreach (IEditButton button in Buttons)
            {
                button.PopUpInvoke += SwitchPopUp;
            }
        }

        public override void Draw()
        {
            int height = 0;
            int lineFrom = OffsetY;
            //DrawHeader();
            BackgroungColor();
            for (int i = 0; i <= MaxRowsY; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("".PadRight(MaxCharsX));
            }
            foreach (string line in Lines)
            {
                if (height < MaxRowsY)
                {
                    Console.SetCursorPosition(0, height);
                    if (Lines[lineFrom].Length > MaxCharsX)
                        Console.Write(Lines[lineFrom].Substring(OffsetX, MaxCharsX));
                    else
                        Console.Write(Lines[lineFrom]);
                    lineFrom++;
                    height++;
                }
            }
            if (CursorPositionX < MaxCharsX || CursorPositionY < MaxRowsY)
                Console.SetCursorPosition(CursorPositionX, CursorPositionY);
        }

        public override void HandleKey(ConsoleKeyInfo info)
        {
            int i = 0;
            foreach (IEditButton button in Buttons)
            {
                if (info.Key.ToString() == button.ButtonKey)
                    Buttons[i].Press();
                i++;
            }

            if (info.Key == ConsoleKey.UpArrow)
            {
                if (CursorPositionY > 0 || OffsetY == 0)
                {
                    CursorPositionYEdit("UpArrow");
                    CursorPositionY--;
                }
                else if (OffsetY > 0)
                {
                    CursorPositionYEdit("UpArrow");
                    OffsetY--;
                }
            }
            else if (info.Key == ConsoleKey.DownArrow)
            {
                if (CursorPositionY < MaxRowsY)
                {
                    CursorPositionYEdit("DownArrow");
                    CursorPositionY++;
                }
                else if (CursorPositionY >= MaxRowsY)
                {
                    CursorPositionYEdit("DownArrow");
                    OffsetY++;
                }
            }
            else if (info.Key == ConsoleKey.LeftArrow)
            {
                if (CursorPositionX + OffsetX != 0)
                    CursorPositionXEdit("Left");
            }
            else if (info.Key == ConsoleKey.RightArrow)
            {
                if (CursorPositionX + OffsetX != Lines[CursorPositionY + OffsetY].Length)
                    CursorPositionXEdit("Right");
            }
            else if (info.Key == ConsoleKey.Backspace)
            {
                Backspace();
            }
            else if (info.Key == ConsoleKey.Delete)
            {
                Delete();
            }
            else if (info.Key == ConsoleKey.Enter)
            {
                Enter();
            }
            else if (info.Key == ConsoleKey.Escape)
            {
                Buttons[1].Press();
            }
            else if (info.Key == ConsoleKey.PageUp)
            {
                CursorPositionX = Lines.First().Length;
                OffsetY = 0;
                CursorPositionY = 0;
            }
            else if (info.Key == ConsoleKey.PageDown)
            {
                CursorPositionX = Lines.Last().Length;
                if (Lines.Count() - 1 > MaxRowsY)
                {
                    CursorPositionY = MaxRowsY;
                    OffsetY = Lines.Count() - 1 - MaxRowsY;
                }
                else
                {
                    CursorPositionY = Lines.Count() - 1;
                }
            }
            else
            {
                if (CursorPositionX + OffsetX < Lines[CursorPositionY + OffsetY].Length)
                {
                    string part1 = Lines[CursorPositionY + OffsetY].Substring(0, CursorPositionX + OffsetX);
                    string part2 = Lines[CursorPositionY + OffsetY].Substring(CursorPositionX + OffsetX);

                    this.Lines[CursorPositionY + OffsetY] = part1 + info.KeyChar.ToString() + part2;
                }
                else
                {
                    this.Lines[CursorPositionY + OffsetY] += info.KeyChar;
                }

                CursorPositionXEdit("Right");
            }
        }

        public void SwitchPopUp(Window window)
        {
            Application.SwitchWindow(window);
        }

        public void Save()
        {
            this.Sw = new StreamWriter(MainWindow.Tables[MainWindow.TableSelected].Handle.Path + @"\" + MainWindow.Tables[MainWindow.TableSelected].Handle.Rows[MainWindow.Tables[MainWindow.TableSelected].RowSelected].Name);
            foreach (string line in Lines)
            {
                Sw.WriteLine(line);
            }
            Sw.Close();
        }

        public void BackgroungColor()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void CursorColor()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        private void Backspace()
        {
            if (CursorPositionX + OffsetX == 0)
            {
                CursorPositionX = Lines[CursorPositionY + OffsetY - 1].Length;
                Lines[CursorPositionY + OffsetY - 1] += Lines[CursorPositionY + OffsetY];
                Lines.RemoveAt(CursorPositionY + OffsetY);

                if (OffsetY != 0)
                    OffsetY--;
                else
                    CursorPositionY--;
            }
            else
            {
                this.Lines[CursorPositionY + OffsetY] = this.Lines[CursorPositionY + OffsetY].Remove(CursorPositionX + OffsetX - 1, 1);
                CursorPositionXEdit("Left");
            }
        }

        private void Delete()
        {
            if (CursorPositionX + OffsetX < Lines[CursorPositionY + OffsetY].Length)
            {
                this.Lines[CursorPositionY + OffsetY] = this.Lines[CursorPositionY + OffsetY].Remove(CursorPositionX + OffsetX, 1);
            }
            else
            {
                this.Lines[CursorPositionY + OffsetY] += this.Lines[CursorPositionY + OffsetY + 1];
                this.Lines.RemoveAt(CursorPositionY + OffsetY + 1);
            }
        }

        private void Enter()
        {

            Lines.Insert(CursorPositionY + OffsetY + 1, Lines[CursorPositionY + OffsetY].Substring(CursorPositionX + OffsetX, Lines[CursorPositionY + OffsetY].Length - CursorPositionX));
            Lines[CursorPositionY + OffsetY] = Lines[CursorPositionY + OffsetY].Substring(0, CursorPositionX + OffsetX);

            CursorPositionX = 0;
            OffsetX = 0;

            if (OffsetY != 0)
                OffsetY++;
            else
                CursorPositionY++;
        }

        private void CursorPositionYEdit(string operation)
        {
            if (operation == "DownArrow")
            {
                if ((CursorPositionX + OffsetX) > Lines[CursorPositionY + OffsetY + 1].Length)
                    CursorPositionX = Lines[CursorPositionY + OffsetY + 1].Length;
            }
            else if (operation == "UpArrow")
            {
                if ((CursorPositionX + OffsetX) > Lines[CursorPositionY + OffsetY - 1].Length)
                    CursorPositionX = Lines[CursorPositionY + OffsetY - 1].Length;
            }
        }

        private void CursorPositionXEdit(string operation)
        {
            if (operation == "Left")
            {
                if (CursorPositionX > 0 || OffsetX == 0)
                    CursorPositionX--;
                else if (OffsetX > 0)
                    OffsetX--;
            }
            else if (operation == "Right")
            {
                if (CursorPositionX < MaxCharsX)
                    CursorPositionX++;
                else if (CursorPositionX >= MaxCharsX)
                    OffsetX++;
            }
        }
        private void DrawHeader()
        {
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(MainWindow.Tables[MainWindow.TableSelected].Handle.Rows[MainWindow.Tables[MainWindow.TableSelected].RowSelected].Name + "".PadRight(6, ' '));
            Console.Write($"[{DrawFunction()}]".PadRight(8, ' ') + CursorPositionX + $" L:[{OffsetY}+{CursorPositionY} {OffsetY + CursorPositionY}/{Lines.Count}]".PadRight(151, ' '));
        }

        private string DrawFunction()
        {
            string function = "----";
            return function;
        }
    }
}