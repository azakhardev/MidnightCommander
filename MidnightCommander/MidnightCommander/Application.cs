using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander
{
    public class Application 
    {
        public List<Window> Windows = new List<Window>();

        public int WindowSelected { get; set;} = - 1;
        
        public Application() 
        {
            SwitchWindow(new Main_Window());
        }

        public void Draw()
        {
            Windows[WindowSelected].Draw();
        }

        public void HandleKey(ConsoleKeyInfo info) 
        {
            Windows[WindowSelected].HandleKey(info);
        }

        public void SwitchWindow(Window window)
        {
            window.Application = this;
            this.Windows.Add(window);
            WindowSelected++;
        }
    }
}
