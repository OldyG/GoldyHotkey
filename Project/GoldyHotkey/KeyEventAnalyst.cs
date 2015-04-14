using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GoldyProject.GoldyHotkey {
    public class KeyEventAnalyst {
        /// <summary>
        /// 등록 제한할 일반키리스트입니다.
        /// </summary>
        private List<Keys> _rejectionKeyList;

        /// <summary>
        /// 입력키의 정보입니다.
        /// </summary>
        private ShortcutKeys _info;

        /// <summary>
        /// keyDown이벤트의 이벤트 핸들러입니다.
        /// </summary>
        private KeyEventArgs _e;


        /// <summary>
        /// 기본생성자 제한
        /// </summary>
        private KeyEventAnalyst() { }


        public KeyEventAnalyst(KeyEventArgs e) {
            this._e = e;
            _info = new ShortcutKeys();
            _analyse();
        }

        private void _analyse() {
            _settingDefaultRejectionKey();
            _settingModifier();
            _settingNormalKey();
        }

        private void _settingDefaultRejectionKey() {
            _rejectionKeyList = new List<Keys>();
            _rejectionKeyList.Add(Keys.Control);
            _rejectionKeyList.Add(Keys.ControlKey);
            _rejectionKeyList.Add(Keys.Alt);
            _rejectionKeyList.Add(Keys.Shift);
            _rejectionKeyList.Add(Keys.ShiftKey);
            _rejectionKeyList.Add(Keys.LShiftKey);
            _rejectionKeyList.Add(Keys.RShiftKey);
            _rejectionKeyList.Add(Keys.Menu);
            _rejectionKeyList.Add(Keys.LMenu);
            _rejectionKeyList.Add(Keys.RMenu);
            _rejectionKeyList.Add(Keys.HanjaMode);
            _rejectionKeyList.Add(Keys.ProcessKey);
            _rejectionKeyList.Add(Keys.LWin);
            _rejectionKeyList.Add(Keys.RWin);
        }
        private void _settingModifier() {
            _info.IsCtrl = _e.Control;
            _info.IsAlt = _e.Alt;
            _info.IsShift = _e.Shift;
        }

        private void _settingNormalKey() {
            foreach (Keys key in _rejectionKeyList) {
                if (_e.KeyCode == key) {
                    return;
                }
            }
            _info.Key = _e.KeyCode;
        }


        public ShortcutKeys GetShortcutKeys() {
            return _info;
        }


        public void AddRejectionKeys(Keys key) {
            _rejectionKeyList.Add(key);
        }

        public override string ToString() {
            return _info.ToString();
        }
    }
}
