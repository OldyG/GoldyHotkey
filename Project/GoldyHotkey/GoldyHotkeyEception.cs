using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldyProject.GoldyHotkey {
    public class GoldyHotkeyEception : Exception {
        public GoldyHotkeyEception() : base() { }
        public GoldyHotkeyEception(string message) : base(message) { }
        public GoldyHotkeyEception(string message, System.Exception inner) : base(message, inner) { }

    }
}
