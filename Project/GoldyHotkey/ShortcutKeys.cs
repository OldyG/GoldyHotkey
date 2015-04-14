using System;
using System.Text;
using System.Windows.Forms;

        
namespace GoldyProject.GoldyHotkey {
    public class ShortcutKeys {
        public enum Modifier {
            None = 0x0000,
            Alt = 0x0001,
            Control = 0x0002,
            Shift = 0x0004,
            Win = 0x0008
        } // 조합키

        public bool IsCtrl = false;
        public bool IsShift = false;
        public bool IsAlt = false;
        public bool isWin = false;
        public Keys Key;

            
        /// <summary>
        /// 단축키들의 키값이 일치할 경우 true를 반환합니다.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals (object obj)
        {
            if (obj == null || GetType() != obj.GetType()) 
            {
                return false;
            }
        
            ShortcutKeys otherKeys = obj as ShortcutKeys;
            return ToString() == otherKeys.ToString();
        }
    
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public ShortcutKeys() {
        }
        
        public int GetIntegerAboutModifier() {
            int sumModifier = 0;

            if (IsCtrl) sumModifier = sumModifier | (int)Modifier.Control;
            if (IsShift) sumModifier = sumModifier | (int)Modifier.Shift;
            if (IsAlt) sumModifier = sumModifier | (int)Modifier.Alt;
            if (isWin) sumModifier = sumModifier | (int)Modifier.Win;

            return sumModifier;
        }


       
        /// <summary>
        /// 단축키를 해석 가능한 String형으로 변환합니다.
        /// </summary>
        /// <returns></returns>
        public override String ToString() {
            StringBuilder temp = new StringBuilder();
            if (IsCtrl) {
                temp.Append(StringData.CTRL_NORMAL).Append(StringData.SPACE).Append(StringData.DIVISION_MARK).Append(StringData.SPACE);
            }
            if (IsAlt) {
                temp.Append(StringData.ALT_NORMAL).Append(StringData.SPACE).Append(StringData.DIVISION_MARK).Append(StringData.SPACE);
            }
            if (IsShift) {
                temp.Append(StringData.SHIFT_NORMAL).Append(StringData.SPACE).Append(StringData.DIVISION_MARK).Append(StringData.SPACE);
            }
            if (isWin) {
                temp.Append(StringData.WIN_NORMAL).Append(StringData.SPACE).Append(StringData.DIVISION_MARK).Append(StringData.SPACE);
            }
            if (Key.ToString() != "None") {
                temp.Append(Key.ToString());
            }
            return temp.ToString();
        }
    }
}
