using MidnightCommander.EditWindowFunctions;
using MidnightCommander.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.EditPopUpWindows
{
    public class Copier : EditFunctions
    {
        public Copier(File_Editor_Window few) 
        {
            this.FileEditorWindow = few;
        }

        public override void Draw()
        {

            string firstPart = FileEditorWindow.Lines[FileEditorWindow.CursorPositionY + FileEditorWindow.OffsetY].Substring(0, FileEditorWindow.CursorPositionX + FileEditorWindow.OffsetX);
            string secondPart = FileEditorWindow.Lines[FileEditorWindow.CursorPositionY + FileEditorWindow.OffsetY].Substring(FileEditorWindow.CursorPositionX + FileEditorWindow.OffsetX);
            string newLine = firstPart + FileEditorWindow.MarkedLines[0];
            if (FileEditorWindow.CursorPositionX + FileEditorWindow.OffsetX != 0)
            {
                FileEditorWindow.Lines.Insert(FileEditorWindow.CursorPositionY + FileEditorWindow.OffsetY, newLine);
                for (int i = 1; i < FileEditorWindow.MarkedLines.Count; i++)
                {
                    if (i != FileEditorWindow.MarkedLines.Count - 1)
                    {
                        FileEditorWindow.Lines.Insert(FileEditorWindow.CursorPositionY + FileEditorWindow.OffsetY + i, FileEditorWindow.MarkedLines[i]);
                    }
                    else
                    {
                        FileEditorWindow.Lines.Insert(FileEditorWindow.CursorPositionY + FileEditorWindow.OffsetY + i, FileEditorWindow.MarkedLines[i] + secondPart);
                    }
                }
            }
            else
            {
                for (int i = 0; i < FileEditorWindow.MarkedLines.Count; i++)
                {
                    if (i != FileEditorWindow.MarkedLines.Count - 1)
                    {
                        FileEditorWindow.Lines.Insert(FileEditorWindow.CursorPositionY + FileEditorWindow.OffsetY + i, FileEditorWindow.MarkedLines[i]);
                    }
                    else
                    {
                        FileEditorWindow.Lines.Insert(FileEditorWindow.CursorPositionY + FileEditorWindow.OffsetY + i, FileEditorWindow.MarkedLines[i] + secondPart);
                    }
                }
            }
            FileEditorWindow.Draw();

            Application.Windows.RemoveAt(Application.WindowSelected);
            Application.WindowSelected--;
        }

        public override void HandleKey(ConsoleKeyInfo info)
        {

        }
    }
}
