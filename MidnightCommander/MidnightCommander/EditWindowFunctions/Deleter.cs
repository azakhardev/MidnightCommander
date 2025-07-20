using MidnightCommander.EditWindowFunctions;
using MidnightCommander.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.PopUpWindows
{
    public class Deleter : EditFunctions
    {
        public List<string> NewLines = new List<string>();

        public Deleter(File_Editor_Window few)
        {
            this.FileEditorWindow = few;
        }

        public override void Draw()
        {
            foreach (string lines in FileEditorWindow.Lines)
            {
                int i = 0;
                bool matching = true;
                foreach (string markedLines in FileEditorWindow.MarkedLines)
                {
                    if (i == 0)
                    {
                        try
                        {
                            if (FileEditorWindow.MarkedX[0] == 0)
                            {
                                if (markedLines != lines)
                                    matching = false;
                                    //NewLines.Add(lines);
                            }
                            else if (FileEditorWindow.MarkedX[0] != 0)
                            {
                                NewLines.Add(lines.Remove(FileEditorWindow.MarkedX[0]));
                                if (markedLines != lines.Substring(FileEditorWindow.MarkedX[0]))
                                {
                                    string firstPart = NewLines.Last();
                                    NewLines.RemoveAt(NewLines.Count - 1);
                                    NewLines.Add(firstPart + lines.Substring(FileEditorWindow.MarkedX[0]));
                                }
                            }
                        }
                        catch (Exception)
                        {
                            NewLines.Add(lines);
                        }
                        i++;
                    }
                    else if (i == FileEditorWindow.MarkedLines.Count - 1)
                    {
                        try
                        {
                            if (FileEditorWindow.MarkedX[1] != 0)
                            {
                                if (markedLines != lines.Substring(0, FileEditorWindow.MarkedX[1]))
                                    matching = false;
                            }
                            else
                            {
                                if (markedLines == lines.Substring(0, FileEditorWindow.MarkedX[1]))
                                    matching = false;
                            }
                        }
                        catch (Exception)
                        {
                            matching = false;
                        }
                        i++;
                    }
                    else
                    {
                        if (lines != markedLines)
                            matching = false;
                        i++;
                    }
                }

                if (matching == false)
                {
                    if (i == 0)
                        NewLines.Add(lines.Substring(0, FileEditorWindow.MarkedX[0]));
                    else if (i == FileEditorWindow.Lines.Count - 1)
                        NewLines.Add(lines.Substring(FileEditorWindow.MarkedX[0]));
                    else
                        NewLines.Add(lines);
                }
            }
            //foreach (string lineM in FileEditorWindow.MarkedLines)
            //{
            //    int i = 0;

            //    foreach (string lineL in FileEditorWindow.Lines)
            //    {
            //        if (FileEditorWindow.SelectedX[0] == 0) 
            //        {
            //            if (lineL == lineM)
            //            {
            //                newLines.Add(lineL);
            //            }
            //            else 
            //            {
            //                if (lineL.Length > FileEditorWindow.SelectedX[0])
            //                {
            //                    if (lineL.Substring(FileEditorWindow.SelectedX[0]) != lineM && lineL.Substring(0, FileEditorWindow.SelectedX[1]) != lineM)
            //                        newLines.Add(lineL);
            //                }
            //            }
            //            i++;
            //        }
            //        //else 
            //        //{
            //        //    if (lineL.Length > FileEditorWindow.SelectedX[0])
            //        //    {
            //        //        lineL.Substring(FileEditorWindow.SelectedX[0]);
            //        //    }

            //        //    if (lineL == lineM)
            //        //    {
            //        //        FileEditorWindow.Lines.RemoveAt(i);
            //        //    }
            //        //    i++;
            //        //}
            //    }
            //}
            //foreach (string item in newLines)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.ReadKey();
            FileEditorWindow.Lines.Clear();
            foreach (string newLines in NewLines)
            {
                FileEditorWindow.Lines.Add(newLines);
            }
            FileEditorWindow.Draw();

            Application.Windows.RemoveAt(Application.WindowSelected);
            Application.WindowSelected--;
        }

        public override void HandleKey(ConsoleKeyInfo info)
        {
            throw new NotImplementedException();
        }
    }
}
