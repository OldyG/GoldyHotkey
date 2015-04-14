using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldyProject.GoldyHotkey {
    static class StringData {

        // --COMMON-- //
        public static string EMPTY = "";
        public static string SPACE = " ";
        public static string SINGLE_QUOTATION_MARKS = "\'";
        public static string DOUBLE_QUOTATION_MARKS = "\"";

        // --Exception Messages-- //
        public static string DON_T_CREATE_SHORTCUTKEYS = "ShortcutKeys를 생성하지 못하였습니다.";
        public static string WRONG_SHORTCUT_STRING = "단축키 문자열이 잘못되었습니다.";
        public static string DO_NOT_OVERFLOW_ABOUT_FOUR_OF_PLUS_CHARACTER = "\'+\'는 최대 4개까지 들어갈수 있습니다.";
        public static string NOT_NORMAL_STRING_ABOUT_LAST_STRING = "마지막 키는 기본키만 입력 할 수 있습니다.";
        public static string NO_MORE_CREATE_HOTKEY = "마지막 키는 기본키만 입력 할 수 있습니다.";
        public static string OVERLAP_KEYS = "중복 된 키가 있습니다.";
        public static string NOT_HAVE_KEY = "을(를) 가진 키가 존재하지 않습니다. 일반키 목록은 \"System.Windows.Forms.Keys\"를 참고하세요";
        public static string NOT_MODIFIER = "조합키가 아닌 문자열이 포함되어있습니다.";
        public static string HAS_EMPTYKEY = "비어있는 키가 있습니다.";

        // --Modifier Keys-- //
        public static string CTRL_NORMAL = "Ctrl";
        public static string ALT_NORMAL = "Alt";
        public static string SHIFT_NORMAL = "Shift";
        public static string WIN_NORMAL = "Win";
        public static string CTRL_LOWER = "ctrl";
        public static string ALT_LOWER = "alt";
        public static string SHIFT_LOWER = "shift";
        public static string WIN_LOWER = "win";


        // --ShortcutKeys-- //
        public static string NULL_SHORTCUTKEYS_STRING = "없음";
        public static char DIVISION_MARK = '+';
        public static string NONE = "None";

    }
}
