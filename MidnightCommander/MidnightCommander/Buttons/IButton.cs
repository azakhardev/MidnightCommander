using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidnightCommander.PopUpWindows;
using MidnightCommander.Windows;

namespace MidnightCommander
{

    public abstract class IButton
    {
        //List<PopUps> PopUps { get; set; }
        public abstract event Action<Window> OnCreate;

        public string Name { get; set; }

        public string ButtonKey { get; set; }

        public Main_Window MainWindow { get; set; }

        public File_Editor_Window FileEditorWindow { get; set; }

        public abstract void Press();
                
        //private DirectoryInfo Dir { get; set; }

        //private FileInfo File { get; set; }

        //public PopUpWindow PopUp { get; set; }
        //public void HandleKey(string path, ConsoleKeyInfo info)
        //{            
        //    FileInfo File = new FileInfo(path);
        //    if (info.Key == ConsoleKey.F1)
        //        BtnF1Clicked();                
        //    if (info.Key == ConsoleKey.F2)
        //        BtnF2Clicked();
        //    if (info.Key == ConsoleKey.F3)
        //        BtnF3Clicked();
        //    if (info.Key == ConsoleKey.F4)
        //        BtnF4Clicked();
        //    if (info.Key == ConsoleKey.F5)
        //        BtnF5Clicked();
        //    if (info.Key == ConsoleKey.F6)
        //        BtnF6Clicked();
        //    if (info.Key == ConsoleKey.F7)
        //        BtnF7Clicked(path);
        //    if (info.Key == ConsoleKey.F8)
        //        BtnF8Clicked(path);
        //    if (info.Key == ConsoleKey.F9)
        //        BtnF9Clicked();
        //    if (info.Key == ConsoleKey.F10)
        //        BtnF10Clicked();
        //}

        //public void BtnF1Clicked()
        //{
            
        //}

        //public void BtnF2Clicked()
        //{

        //}

        //public void BtnF3Clicked()
        //{

        //}

        //public void BtnF4Clicked()
        //{

        //}

        //public void BtnF5Clicked()
        //{
        //    //dir.MoveTo();
                        
        //}

        //public void BtnF6Clicked()
        //{            
        //    //dir.MoveTo();
        //} 

        //public void BtnF7Clicked(string path)
        //{
        //    //.Remove(path.LastIndexOf(@"\"))
        //    Dir = new DirectoryInfo(path+"ahoj");
        //    File = new FileInfo(path);
        //    //PopUp.Create();

        //    if(Dir.Exists)
        //        Console.Write("Existuje");
        //    else
        //        Dir.Create();

        //}

        //public void BtnF8Clicked(string path)
        //{ 
        //    //Delete
        //    Dir = new DirectoryInfo(path);
        //    File = new FileInfo(path);
            
        //    try
        //    {
        //        foreach (DirectoryInfo item in Dir.GetDirectories())
        //        {
        //            item.Delete(true);
        //        }
        //        foreach (FileInfo item in Dir.GetFiles()) 
        //        {
        //            item.Delete();
        //        }
        //        Dir.Delete();
        //    }
        //    catch (Exception)
        //    {
        //        File.Delete();                
        //    }
        //}

        //public void BtnF9Clicked()
        //{

        //}

        //public void BtnF10Clicked()
        //{

        //}
    }
}
