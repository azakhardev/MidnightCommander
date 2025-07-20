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
    public class Marker : EditFunctions
    {
        public int FirstX { get; set; }

        public int LastX { get; set; }

        public int FirstY { get; set; }

        public int LastY { get; set; }

        public Marker(File_Editor_Window few)
        {
            this.FileEditorWindow = few;

            FirstX = FileEditorWindow.CursorPositionX + FileEditorWindow.OffsetX;
            FirstY = FileEditorWindow.CursorPositionY + FileEditorWindow.OffsetY;
            LastX = FileEditorWindow.CursorPositionX + FileEditorWindow.OffsetX;
            LastY = FileEditorWindow.CursorPositionY + FileEditorWindow.OffsetY;
        }

        public override void Draw()
        {
            //FileEditorWindow.Draw();
            ////int height = 1;
            ////int lineFrom = FileEditorWindow.OffsetY;
            ////string marked = "";
            ////foreach (string line in FileEditorWindow.Lines)
            ////{
            ////    Console.SetCursorPosition(0, height);
            ////    int i = 0;
            ////    foreach (char ch in line)
            ////    {
            ////        if ( i > Math.Min(FirstY, LastY) || i< Math.Max(FirstY, LastY)) 
            ////        {
            ////            OptionIsSelected();
            ////            Console.Write(ch);
            ////            OptionNotSelected();
            ////            i++;
            ////            marked += ch;
            ////        }
            ////        else
            ////        {
            ////            Console.Write(ch);
            ////            i++;
            ////        }
            ////    }
            ////    height++;
            ////}
            Console.SetCursorPosition(LastX,LastY);
        }

        public override void HandleKey(ConsoleKeyInfo info)
        {

            if (info.Key == ConsoleKey.UpArrow)
            {
                if (LastY > 0)
                    LastY--;
            }
            else if (info.Key == ConsoleKey.DownArrow)
            {
                if (LastY < FileEditorWindow.Lines.Count)
                    LastY++;
            }
            else if (info.Key == ConsoleKey.LeftArrow)
            {
                if (LastX > 0)
                    LastX--;
            }
            else if (info.Key == ConsoleKey.RightArrow)
            {
                if (LastX < FileEditorWindow.Lines[FileEditorWindow.CursorPositionY].Length)
                    LastX++;
            }
            else if (info.Key == ConsoleKey.F3)
            {
                int i = LastY;
                SelectedString();
                foreach (string item in FileEditorWindow.MarkedLines)
                {
                    Console.SetCursorPosition(0,i);
                    Console.Write(item); 
                    i++;
                }
                Application.Windows.RemoveAt(Application.WindowSelected);
                Application.WindowSelected--;
            }
        }

        public void SelectedString()
        {
            for (int i = Math.Min(FirstY,LastY); i <= Math.Max(FirstY,LastY); i++)
            {
                string text = "";
                if (i != Math.Min(FirstY, LastY) || i != Math.Max(FirstY, LastY))
                {
                    FileEditorWindow.MarkedLines.Add(FileEditorWindow.Lines[i]);
                }
                else 
                {
                    for (int j = Math.Min(FirstX, LastX); j <= Math.Max(FirstX, LastX); j++)
                    {
                        text += FileEditorWindow.Lines[i].ElementAt(j);
                    }
                }
                FileEditorWindow.MarkedLines.Add(text);
            }

            FileEditorWindow.MarkedY.Add(Math.Min(FirstY, LastY));
            FileEditorWindow.MarkedY.Add(Math.Max(FirstY, LastY));
            
            FileEditorWindow.MarkedX.Add(Math.Min(FirstX,LastX));
            FileEditorWindow.MarkedX.Add(Math.Max(FirstX, LastX));
        }
    }
}
