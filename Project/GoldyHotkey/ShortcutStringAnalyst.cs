using System;
using System.Windows.Forms;

namespace GoldyProject.GoldyHotkey
{
    public static class ShortcutStringAnalyst
    {

        public static ShortcutKeys GetShortcutKeys(String shortcutString)
        {

            if (CheckString(shortcutString))
            {
                ShortcutKeys info = new ShortcutKeys();
                _settingModifier(shortcutString, info);
                _settingKey(shortcutString, info);
                return info;
            }
            else
            {
                throw new GoldyHotkeyEception(StringData.DON_T_CREATE_SHORTCUTKEYS);
                //throw new Exception(StringData.DON_T_CREATE_SHORTCUTKEYS);
            }
        }


        internal static bool CheckString(String shortcutString)
        {
            string[] keys = shortcutString.Split(StringData.DIVISION_MARK);

            if (shortcutString.Equals(StringData.NULL_SHORTCUTKEYS_STRING) || shortcutString.Trim().Equals(StringData.EMPTY) || shortcutString == null)
            {
                // 빈문자열일경우
                throw new GoldyHotkeyEception(StringData.WRONG_SHORTCUT_STRING);
            }
            else if (keys.Length > 5)
            {
                // + 가 5개 이상일경우
                throw new GoldyHotkeyEception(StringData.DO_NOT_OVERFLOW_ABOUT_FOUR_OF_PLUS_CHARACTER);
            }
            else if (_checkNotEmptyKeys(keys) == false)
            {
                // Ctrl+ +Shift+T 이러한 경우
                // 즉 키가 있어야할 자리에 키가 없을 경우
                throw new GoldyHotkeyEception(StringData.HAS_EMPTYKEY);
            }
            else if (_checkOverlapKey(keys) == false)
            {
                // 중복된 키가 있을경우
                throw new GoldyHotkeyEception(StringData.OVERLAP_KEYS);
            }
            else if (_checkLastStringIsModifier(keys) == false)
            {
                // 일반키 자리(맨끝)에 조합키가 있을 경우
                throw new GoldyHotkeyEception(StringData.NOT_NORMAL_STRING_ABOUT_LAST_STRING);
            }
            else if (_checkModifierKeys(keys) == false)
            {
                // 조합키 자리에 다른키가 있을 경우
                throw new GoldyHotkeyEception(StringData.NOT_MODIFIER);
            }
            return true;
        }

        private static bool _checkNotEmptyKeys(string[] keys)
        {

            foreach (string v in keys)
            {
                if (v.Trim().Equals(StringData.EMPTY))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool _checkModifierKeys(string[] keys)
        {
            for (int i = 0; i < keys.Length - 1; i++)
            {
                keys[i] = keys[i].Trim().ToLower();
                if (!(keys[i].Equals(StringData.CTRL_LOWER) ||
                    keys[i].Equals(StringData.ALT_LOWER) ||
                    keys[i].Equals(StringData.SHIFT_LOWER) ||
                    keys[i].Equals(StringData.WIN_LOWER)))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool _checkOverlapKey(string[] keys)
        {

            for (int i = 0; i < keys.Length - 1; i++)
            {
                for (int j = i + 1; j < keys.Length; j++)
                {
                    if (keys[i].ToLower().Equals(keys[j].ToLower()))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool _checkLastStringIsModifier(string[] keys)
        {
            string lastkeyString = keys[keys.Length - 1].ToLower();

            if (lastkeyString.Equals(StringData.CTRL_LOWER) || lastkeyString.Equals(StringData.ALT_LOWER)
                || lastkeyString.Equals(StringData.SHIFT_LOWER) || lastkeyString.Equals(StringData.WIN_LOWER))
            {
                return false;
            }
            return true;
        }

        private static void _settingModifier(String shortcutString, ShortcutKeys info)
        {
            if (shortcutString.ToLower().Contains(StringData.CTRL_LOWER))
            {
                info.IsCtrl = true;
            }
            if (shortcutString.ToLower().Contains(StringData.ALT_LOWER))
            {
                info.IsAlt = true;
            }
            if (shortcutString.ToLower().Contains(StringData.SHIFT_LOWER))
            {
                info.IsShift = true;
            }
            if (shortcutString.ToLower().Contains(StringData.WIN_LOWER))
            {
                info.isWin = true;
            }
        }

        private static void _settingKey(String shortcutString, ShortcutKeys info)
        {
            // String을 + 기준으로 분해
            String[] keys = shortcutString.Split(StringData.DIVISION_MARK);

            // 마지막 노멀키 추출 및 공백제거
            String tempKey = keys[keys.Length - 1].Trim();

            // Keys의 리스트들과 소문자로 비교하여 이름이 같으면 그것을 이름으로 지정
            // 대소문자를 구분하지 않도록 하기 위한 코드
            foreach (string keyString in Enum.GetNames(typeof(Keys)))
            {
                if (keyString.ToLower().Equals(tempKey.ToLower()))
                {
                    tempKey = keyString;
                    break;
                }
            }

            try
            {
                info.Key = (Keys)Enum.Parse(typeof(Keys), tempKey);
            }
            catch (Exception e)
            {

                System.Text.StringBuilder errMsg = new System.Text.StringBuilder();
                errMsg.Append(StringData.DOUBLE_QUOTATION_MARKS);
                errMsg.Append(tempKey);
                errMsg.Append(StringData.DOUBLE_QUOTATION_MARKS);
                errMsg.Append(StringData.NOT_HAVE_KEY);
                throw new GoldyHotkeyEception(errMsg.ToString());
            }
        }
    }
}
