using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.Tools
{
    public interface IEditComponent
    {
        void HandleKey(ConsoleKeyInfo info);

        void Draw();
    }
}
