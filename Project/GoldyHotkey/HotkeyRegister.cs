using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace GoldyProject.GoldyHotkey {
    internal class HotkeyRegister : Control {
        [DllImport("user32.dll")]
        private static extern int RegisterHotKey(int hwnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern int UnregisterHotKey(int hwnd, int id);

        private int id;
        public readonly ShortcutKeys shortcutKeys;
        private Action action;

        public HotkeyRegister(int id, ShortcutKeys shortcutKeys, Action action) {
            this.id = id;
            this.shortcutKeys = shortcutKeys;
            this.action = action;
            Register();
        }

        public ShortcutKeys GetShortcutKeys() {
            return this.shortcutKeys;
        }

        public void RemoveAction() {
            Unregister();
        }

        public void Register() {
            RegisterHotKey((int)this.Handle, id, shortcutKeys.GetIntegerAboutModifier(), (int)shortcutKeys.Key);
        } // Ctrl+Alt+A에 대한 핫키 선언

        public void Unregister() {
            UnregisterHotKey((int)this.Handle, id);
        } // 선언 해제
        protected override void WndProc(ref System.Windows.Forms.Message m) {
            base.WndProc(ref m);

            if (m.Msg == (int)0x312) {
                if (m.WParam == (IntPtr)id) {
                    action();
                }
            }
        } // 윈도프로시저 등록
    }
}
