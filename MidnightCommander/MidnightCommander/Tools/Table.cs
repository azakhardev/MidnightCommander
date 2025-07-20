using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander
{
    public class Table
    {
        //public List<Component> Components = new List<Component>();

        public Handler Handle;

        public Main_Window MainWindow;

        public int MaxRows { get; set; } = 19;

        public int RowSelected { get; set; } = 0;

        public int Offset { get; set; } = 0;

        public int CursorPositionX { get; set; }

        public string RowName = "..";

        public Table(int cursorPosition)
        {
            this.CursorPositionX = cursorPosition;
        }

        public void Draw()
        {
            //Kdyz upArrow tak se nesmi posouvat cela tabulka
            //Pri posunuti za offset selectnuty radek se posune o 2
            for (int i = Offset; i <= Offset + Math.Min(MaxRows-1,Handle.Rows.Count-1); i++)
            {
                Console.SetCursorPosition(this.CursorPositionX, 3 + i - Offset);

                if (i == RowSelected+Offset) 
                {
                    RowName = Handle.Rows[i].Name;
                    RowIsSelected();
                }

                Console.Write('│' + Handle.Rows[i].Name.PadRight(52, ' ') + '│');
                Console.Write(Handle.Rows[i].Size.PadRight(7, ' ') + '│');
                Console.Write(Handle.Rows[i].Date.PadRight(12, ' ') + '│');

                RowNotSelected();    
            }

            for (int i = Handle.Rows.Count; i <= MaxRows; i++)
            {
                Console.SetCursorPosition(CursorPositionX, 3 + i);
                Console.Write("│".PadRight(53, ' ') + "│".PadRight(8, ' ') + "│".PadRight(13, ' ') + "│");
            }

            Console.SetCursorPosition(CursorPositionX,3+MaxRows);
            Console.Write("├".PadRight(74, '─') + "┤");
            Console.SetCursorPosition(CursorPositionX, 4 + MaxRows);
            Console.Write('│' + Handle.Rows[RowSelected+Offset].Name.PadRight(73, ' ') + "│");
            Console.SetCursorPosition(CursorPositionX, 5 + MaxRows);
            Console.WriteLine("└".PadRight(74, '─') + '┘');
        }

        public void HandleKey(ConsoleKeyInfo keyinfo)
        {
            if (keyinfo.Key == ConsoleKey.UpArrow)
            {
                if (RowSelected > 0 && Offset == 0)
                    RowSelected--;

                if (Offset !=0)
                    Offset--;
            }
            else if (keyinfo.Key == ConsoleKey.DownArrow)
            {
                if (RowSelected < MaxRows-1 && RowSelected < Handle.Rows.Count - 1)
                    RowSelected++;

                if (RowSelected == MaxRows-1 && Offset+RowSelected < Handle.Rows.Count-1)
                    Offset++;
            }
        }

        public string GetNewPath() 
        {
            return Handle.Rows[RowSelected+Offset].Path;
        }

        public void RowIsSelected()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public void RowNotSelected()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
        }     
    }
}