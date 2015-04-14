using GoldyProject.GoldyHotkey;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GoldyHotkeyExample {
    public partial class MainForm : Form {
        HotkeyMaster hotkeyMaster;

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e) {
            // Second, Instance for hotkeyMaster.
            // HotkeyMaster necessary parameter is  handle of OwnerForm
            hotkeyMaster = new HotkeyMaster(this.Handle);

            // next functions is how to use the example code.
            일반텍스트박스를_사용자핫키정의용_텍스트박스로_변환하기();
            개발자정의핫키등록하기1();
            개발자정의핫키등록하기2();
            핫키제거하기();
        }
        /// <summary>
        /// 텍스트박스와 Action을 넘겨주어 사용자핫키정의 텍스트박스로 변환시켜줍니다.
        /// 여러개의 텍스트박스를 설정하여도 모두 관리합니다.
        /// </summary>
        private void 일반텍스트박스를_사용자핫키정의용_텍스트박스로_변환하기() {

            // 1. create new TextBox, and Add Control in MainForm
            TextBox tb = new TextBox();
            this.Controls.Add(tb);

            // 2. Create Action
            Action act = () => {
                this.Text = MousePosition.ToString();
            };

            // 3. Convert Textbox
            // it need objects are TextBox and Action 
            hotkeyMaster.ConvertTextBox(tb, act);
        }

        private void 개발자정의핫키등록하기1() {

            // 1. Create ShortcutKeys.
            // ShortcutKeys has three modifier(Ctrl,Alt,Shift) and a Normal Key
            ShortcutKeys tempKeys = new ShortcutKeys();

            // 2. and Setting keys
            tempKeys.IsCtrl = true;
            tempKeys.IsAlt = true;
            tempKeys.Key = Keys.T;

            // 3. Create Action
            Action act = () => {
                MessageBox.Show("개발자정의핫키등록하기2");
            };

            // 4. Regist Hotkey in HotkeyMaster.RegistHotkey
            // parameter, ShortcutKeys object and Action object
            int id = hotkeyMaster.RegistHotkey(tempKeys, act);
            // int id = HotkeyAdmin.create(tempKeys, act); <- it's same sentence

        }

        private void 개발자정의핫키등록하기2() {

            // 1. Create Action
            Action act = () => {
                MessageBox.Show("개발자정의핫키등록하기1");
            };

            // Since returning the ID, and must always be kept
            // ID, you can use when you want to remove(unregistred) the hotkey
            int id = hotkeyMaster.RegistHotkey("Ctrl + Alt + T", act);

            // "int id = HotkeyAdmin.create("Ctrl + Alt + T", act);" its same sentence
        }



        /// <summary>
        /// 개발자가 수동으로 핫키를 생성하였을 경우 제거하는 방법입니다.
        /// </summary>
        private void 핫키제거하기() {

        }
    }
}
