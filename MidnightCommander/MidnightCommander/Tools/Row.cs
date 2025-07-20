using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace MidnightCommander
{
    public class Row
    {

        //public DirectoryInfo Dir { get; set; }
        public string Path { get; set; } = "";

        public string Name { get; set; } 

        public string Size { get; set; } = "";

        public string Date { get; set; } = "";
    }
}
