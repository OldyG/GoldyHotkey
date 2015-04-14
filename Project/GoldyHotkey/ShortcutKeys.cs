using System;
using System.Text;
using System.Windows.Forms;


namespace GoldyProject.GoldyHotkey
{
    public class ShortcutKeys
    {
        public ShortcutKeys()
        {
        }
        public ShortcutKeys(bool ctrl, bool alt, bool shift, bool win, Keys normalKey)
        {
            this.IsCtrl = ctrl;
            this.IsAlt = alt;
            this.IsShift = shift;
            this.IsWin = win;
            this.Key = normalKey;
        }

        public enum Modifier
        {
            None = 0x0000,
            Alt = 0x0001,
            Control = 0x0002,
            Shift = 0x0004,
            Win = 0x0008
        } // 조합키

        public bool IsCtrl = false;
        public bool IsShift = false;
        public bool IsAlt = false;
        public bool IsWin = false;
        public Keys Key;


        /// <summary>
        /// 단축키들의 키값이 일치할 경우 true를 반환합니다.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
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
            int modifierValue = GetIntegerAboutModifier();
            int keyValue = (int)Key;

            //return base.GetHashCode();
            return modifierValue + keyValue;
        } // 미완성 코드


        public int GetIntegerAboutModifier()
        {
            int sumModifier = 0;

            if (IsCtrl) sumModifier = sumModifier | (int)Modifier.Control;
            if (IsShift) sumModifier = sumModifier | (int)Modifier.Shift;
            if (IsAlt) sumModifier = sumModifier | (int)Modifier.Alt;
            if (IsWin) sumModifier = sumModifier | (int)Modifier.Win;

            return sumModifier;
        }



        /// <summary>
        /// 단축키를 해석 가능한 String형으로 변환합니다.
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            StringBuilder returnString = new StringBuilder();
            if (IsCtrl)
            {
                returnString.Append(StringData.CTRL_NORMAL).Append(StringData.SPACE).Append(StringData.DIVISION_MARK).Append(StringData.SPACE);
            }
            if (IsAlt)
            {
                returnString.Append(StringData.ALT_NORMAL).Append(StringData.SPACE).Append(StringData.DIVISION_MARK).Append(StringData.SPACE);
            }
            if (IsShift)
            {
                returnString.Append(StringData.SHIFT_NORMAL).Append(StringData.SPACE).Append(StringData.DIVISION_MARK).Append(StringData.SPACE);
            }
            if (IsWin)
            {
                returnString.Append(StringData.WIN_NORMAL).Append(StringData.SPACE).Append(StringData.DIVISION_MARK).Append(StringData.SPACE);
            }
            if (Key.ToString() != "None")
            {
                returnString.Append(Key.ToString());
            }
            return returnString.ToString();
        }
    }
}
