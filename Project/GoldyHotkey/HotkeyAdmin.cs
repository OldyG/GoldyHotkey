using System;
using System.Collections;
using System.Collections.Generic;

namespace GoldyProject.GoldyHotkey {
    public static class HotkeyAdmin {
        /// <summary>
        /// 핫키등록 최대 개수
        /// </summary>
        private static int MAX = 100;

        /// <summary>
        /// 핫키 ID 리스트
        /// </summary>
        private static List<int> _hotkeyIdList = new List<int>();

        /// <summary>
        /// 등록된 핫키 테이블(ID,핫키정보)
        /// </summary>
        //private static Hashtable _hotkeyTable = new Hashtable();
        private static Dictionary<int, HotkeyRegister> _hotkeyDictionary = new Dictionary<int, HotkeyRegister> ();

        /// <summary>
        /// 핫키를 생성합니다.
        /// </summary>
        /// <param name="shortcutKeys"></param>
        /// <param name="_action"></param>
        /// <returns>_id</returns>
        public static int create(ShortcutKeys shortcutString, Action action) {
            int id = makeID();
            if (id == MAX + 1) throw new GoldyHotkeyEception(StringData.NO_MORE_CREATE_HOTKEY);

            _hotkeyDictionary.Add(id, new HotkeyRegister(id, shortcutString, action));
            return id;
        }


        /// <summary>
        /// 해당 ID를 가진 핫키를 제거합니다.
        /// </summary>
        /// <param name="_id"></param>
        public static void RemoveAt(int id) {
            _hotkeyDictionary[id].RemoveAction();
            _hotkeyDictionary.Remove(id);
            for (int i = 0; i < _hotkeyIdList.Count; i++) {
                if (_hotkeyIdList[i] == id) {
                    _hotkeyIdList.RemoveAt(i);
                    break;
                }
            }
        }

        /// <summary>
        /// 해당 단축키를 가진 핫키를 제거합니다.
        /// </summary>
        /// <param name="shortcutKeys"></param>
        public static void RemoveAt(ShortcutKeys shortcutKeys) {
            shortcutKeys.Equals(1);
            foreach (int id in _hotkeyIdList) {
                if (shortcutKeys.Equals(_hotkeyDictionary[id].shortcutKeys)) {
                    RemoveAt(id);
                    return;
                }
            }
        }

        /// <summary>
        /// 등록되어있는 모든 핫키를 제거합니다.
        /// </summary>
        public static void RemoveAll() {
            foreach (KeyValuePair<int,HotkeyRegister> test in _hotkeyDictionary) {
                test.Value.RemoveAction();
            }
            _hotkeyDictionary.Clear();
        }

        /// <summary>
        /// 해당 아이디를 가진 단축키를 반환합니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ShortcutKeys GetShortCutKeysAboutID(int id) {
            bool isExist = _existHotkey(id);
            
            if (isExist) {
                return _hotkeyDictionary[id].shortcutKeys;
            } else {
                throw new Exception("해당ID를 가진 핫키가 존재하지 않습니다.");
            }
        }

        /// <summary>
        /// 해당 아이디를 가진 단축키의 String 값을 반환합니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetShortCutStringAboutID(int id) {
            return GetShortCutKeysAboutID(id).ToString();
        }

        private static bool _existHotkey(int id) {
            foreach (int hotkeyId in _hotkeyIdList) {
                if (hotkeyId.Equals(id)) {
                    return true;
                }
            }
            return false;
        }

        

        /// <summary>
        /// 핫키에 대한 ID값을 생성합니다.
        /// </summary>
        /// <returns></returns>
        private static int makeID() {
            int tempId = 0;
            if (_hotkeyIdList.Count < MAX) {
                while (true) {
                    tempId = new Random().Next(MAX);
                    bool isOverlap = false;

                    foreach (int id in _hotkeyIdList) {
                        if (tempId == id) {
                            isOverlap = true;
                            break;
                        }
                    }
                    if (isOverlap == false) break;
                }
                _hotkeyIdList.Add(tempId);
            } else { tempId = MAX + 1; }
            return tempId;
        }

        public static List<int> GetIdList() {
            
            List<int> temp = new List<int>();
            temp = _hotkeyIdList.GetRange(0, _hotkeyIdList.Count);
            return temp;
        }
    }
}
