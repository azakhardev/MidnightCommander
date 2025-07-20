using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander
{
    public class Handler
    {
        public string Path { get; set; }

        public List<Row> Rows = new List<Row>();        

        public Handler(string path)
        {
            this.Path = path;
            LoadData();
        }

        public void LoadData() 
        {
            if (this.Path == "")
                GetDrives();
            else 
                GetRows();
        }

        public void GetRows()
        {
            DirectoryInfo dir = new DirectoryInfo(this.Path);
            if (dir.Parent == null)
            {
                Row row1 = new Row() { Name = @"\.." };
                Rows.Add(row1);
            }
            else
            {
                Row row1 = new Row() { Name = @"\..", Path = Path.Remove(Path.LastIndexOf(@"\"))};
                Rows.Add(row1);
            }

            foreach (DirectoryInfo subdir in dir.GetDirectories())
            {                
                Row row = new Row() { Name = subdir.Name, Date = subdir.LastAccessTime.ToString().Remove(10), Path = subdir.FullName };
                Rows.Add(row);
            }
            foreach (FileInfo file in dir.GetFiles())
            {                
                Row row = new Row() { Name = file.Name, Size = FileSize(file.Length.ToString()), Date = file.LastAccessTime.ToString().Remove(10), Path = this.Path };
                Rows.Add(row);
            }
        }

        public void GetDrives() 
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                Row row = new Row() { Name = drive.Name, Path = drive.Name};
                Rows.Add(row);
            }
        }

        public string FileSize(string size)
        {
            double numSize = Convert.ToDouble(size);
            string finalFormat = "";
            List<string> units = new List<string>() { "B", "KB", "MB", "GB", "TB" };
            int i = 0;

            while (numSize / 1024 > 1)
            {
                numSize = Math.Round(numSize / 1024, 0);
                i++;
            }
            
            finalFormat = numSize + units[i];
            return finalFormat;
        }        
    }
}
