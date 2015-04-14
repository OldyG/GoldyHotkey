using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GoldyProject.GoldyHotkey {
    /// <summary>
    /// GoldyProject.GoldyHotkey.dll에 포함되어있는 모든 클래스들을 총관리하는 클래스입니다.
    /// </summary>
    public class HotkeyMaster {

        private IntPtr mainHandle;

        /// <summary>
        /// Default Constructor.
        /// </summary>
        internal HotkeyMaster() {
        }

        /// <summary>
        /// 핫키마스터를 인스턴스합니다.
        /// </summary>
        /// <param name="mainFormHandle">Owner가 되는 메인폼의 핸들입니다.</param>
        public HotkeyMaster(IntPtr mainFormHandle) {
            this.mainHandle = mainFormHandle;
        }

        
        /// <summary>
        /// 해당 Action을 가진 유저정의용 핫키텍스트박스를 반환합니다.
        /// </summary>
        /// <param name="action">단축키 입력시 실행 할 행동입니다.</param>
        /// <returns>변환 된 사용자정의용 텍스트박스입니다.</returns>
        public TextBox GetHotkeyTextBox(Action action) {
            TextBox tb = new TextBox();
            ConvertTextBox(tb, action);
            return tb;
        }

        /// <summary>
        /// 일반텍스트박스를 유저정의용 핫키텍스트박스로 변환합니다.
        /// </summary>
        /// <param name="textbox">일반 텍스트박스입니다.</param>
        /// <param name="action">단축키 입력시 실행 할 행동입니다.</param>
        public void ConvertTextBox(TextBox textbox, Action action) {
            TextBoxConverter temp = new TextBoxConverter(textbox, action);
        }

        /// <summary>
        /// 등록 된 ID 리스트 복사본을 반환합니다.
        /// </summary>
        /// <returns></returns>
        public List<int> GetIdList() {
            return HotkeyAdmin.GetIdList();
        }

        
        /// <summary>
        /// MouseDown Event핸들러에 해당하는 KeyEventArgs를 분석하여 ShortcutKeys를 반환합니다.
        /// </summary>
        /// <param name="e">MouseDown Event핸들러의 매개변수인 KeyEventArgs입니다.</param>
        /// <returns></returns>
        public ShortcutKeys GetShortcutKeys(KeyEventArgs e) {
            return new KeyEventAnalyst(e).GetShortcutKeys();
        }

        /// <summary>
        /// ShortcutString을 분석하여 ShortcutKeys로 반환합니다.
        /// </summary>
        /// <param name="ShortcutString">단축키 문자열입니다.</param>
        /// <returns></returns>
        public ShortcutKeys GetShortcutKeys(string ShortcutString) {
            return ShortcutStringAnalyst.GetShortcutKeys(ShortcutString);
        }

        /// <summary>
        /// 해당 ID를 가진 ShortcutKeys를 가져옵니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ShortcutKeys FindShortcutKeys(int id) {
            return HotkeyAdmin.GetShortCutKeysAboutID(id);
        }


        /// <summary>
        /// ShrtcutKeys에 해당하는 키로 새로운 핫키를 정의합니다.
        /// </summary>
        /// <param name="shortcutKeys"></param>
        /// <param name="action">단축키 입력시 실행 할 행동입니다.</param>
        /// <returns>반환되는 값은 해당 액션의 ID 값이므로 삭제할때 사용됩니다.</returns>
        public int RegistHotkey(ShortcutKeys shortcutKeys, Action action) {
            return HotkeyAdmin.create(shortcutKeys, action);
        }

        /// <summary>
        /// 해당 문자열을 분석하여 새로운 핫키를 정의합니다.
        /// </summary>
        /// <param name="shortcutKeys"></param>
        /// <param name="action">단축키 입력시 실행 할 행동입니다.</param>
        /// <returns>반환되는 값은 해당 액션의 ID 값이므로 삭제할때 사용됩니다.</returns>
        public int RegistHotkey(String shortcutString, Action action) {
            ShortcutKeys temp = ShortcutStringAnalyst.GetShortcutKeys(shortcutString);
            return RegistHotkey(temp, action);
        }

        /// <summary>
        /// 해당 ID로 정의된 핫키를 해제합니다.
        /// </summary>
        /// <param name="id">등록된 핫키의 ID값입니다.</param>
        public void UnregistHotkey(int id) {
            HotkeyAdmin.RemoveAt(id);
        }

        /// <summary>
        /// 해당 ShortcutKeys로 정의된 핫키를 해제합니다.
        /// </summary>
        /// <param name="shortcutData"></param>
        public void UnregistHotkey(ShortcutKeys shortcutData) {
            HotkeyAdmin.RemoveAt(shortcutData);
        }

        /// <summary>
        /// 해당 문자열이 Shortcutkeys로 사용 될 수 있는지 검사합니다.
        /// </summary>
        /// <param name="ShortcutString"></param>
        /// <returns>문자열이 정상적이지 않을 경우 Exception이 발생합니다.</returns>
        public bool CheckShortcutString(string ShortcutString) {
            return ShortcutStringAnalyst.CheckString(ShortcutString);
        }

        /// <summary>
        /// 핫키들을 제어하기 위해 해당 액션 위에 제어하는 기능을 감쌉니다.
        /// </summary>
        /// <param name="action">단축키 입력시 실행 할 행동입니다.</param>
        /// <returns></returns>
        private Action _checkAction(Action action) {
            Action changer = () => {
                if (_checkOverapShortcut() == false) {
                    action();
                }
            };
            return changer;
        }

        private bool _checkOverapShortcut() {
            throw new NotImplementedException();
        }
    }
}
