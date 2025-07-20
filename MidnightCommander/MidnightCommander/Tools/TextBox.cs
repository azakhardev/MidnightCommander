using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.Tools
{
    public class TextBox : IEditComponent
    {        
        public string Value { get; set; } = "";

        public int Size { get; set; } = 20;

        public void Draw()
        {
            Console.Write(Value);
        }

        public void HandleKey(ConsoleKeyInfo info)
        {
            if (info.Key == ConsoleKey.Backspace)
            {
                if (this.Value.Length == 0)
                    return;

                this.Value = this.Value.Substring(0, this.Value.Length - 1);
            }
            else
            {
                this.Value += info.KeyChar;
            }
        }
    }
}
