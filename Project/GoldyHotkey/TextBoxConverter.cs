using System;
using System.Drawing;
using System.Windows.Forms;

namespace GoldyProject.GoldyHotkey {
    public class TextBoxConverter {
        private Label _label = new Label();
        private TextBox _textBox;
        private Action _action;
        private bool _isRegistHokey = false;
        private int _id;



        public string Success_String = "등록되었어요!";
        public string Fail_String = "완성되지 않았어요ㅜ";

        public Font Success_Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
        public Font Fail_Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));

        public Color Success_Color = Color.Blue;
        public Color Fail_Color = Color.Red;


        public TextBoxConverter(TextBox textBox, Action action) {
            if (textBox == null) {
                throw new Exception("텍스트 박스가 null이네요?");
            }
            if (action == null) {
                throw new Exception("Action이 null이네요?");
            }
            this._textBox = textBox;
            this._action = action;
            _createLabel();
            _createEvent();
        }
        private void _createLabel() {
            try {
                _textBox.Parent.Controls.Add(_label);
            } catch (Exception e) {
                throw new Exception("텍스트박스를 부모컨트롤에 추가하여주세요!" + e.Data);
            }
            _label.Location = new Point(_textBox.Right, _textBox.Top + 5);
        }

        private void _createEvent() {
            _textBox.KeyDown += _textbox_KeyDown;
            _textBox.KeyPress += _textbox_KeyPress;
            _textBox.KeyUp += _textbox_KeyUp;
            _textBox.TextChanged += textBox_TextChanged;
        }

        void textBox_TextChanged(object sender, EventArgs e) {
            bool isOK = _checkInputKey(_textBox.Text);
            if (isOK) {
                _label.Text = Success_String;
                _label.Font = Success_Font;
                _label.ForeColor = Success_Color;
                if (_isRegistHokey == false) {
                    registHotkey();

                }
            } else {
                _label.Text = Fail_String;
                _label.Font = Fail_Font;
                _label.ForeColor = Fail_Color;
                if (_isRegistHokey) {
                    unregistHotkey();
                }
            }
            _label.Width = (int)_getSizefAboutTextRealSize(_label.Text, _label.Font).Width;
        }

        private void registHotkey() {
            HotkeyMaster GSC = new HotkeyMaster();
            ShortcutKeys stData = GSC.GetShortcutKeys(_textBox.Text);
            _id = GSC.RegistHotkey(stData, _action);
            _isRegistHokey = true;
        }

        private void unregistHotkey() {
            new HotkeyMaster().UnregistHotkey(_id);
            _isRegistHokey = false;
        }
        private static SizeF _getSizefAboutTextRealSize(string text, Font font) {
            SizeF size;
            using (Graphics graphics = Graphics.FromImage(new Bitmap(1, 1))) {
                size = graphics.MeasureString(text, font);
            }
            return size;
        }


        private void _textbox_KeyDown(object sender, KeyEventArgs e) {
            HotkeyMaster temp = new HotkeyMaster();
            ShortcutKeys info = temp.GetShortcutKeys(e);
            _textBox.Text = info.ToString();
        }

        private void _textbox_KeyPress(object sender, KeyPressEventArgs e) {
            e.KeyChar = Convert.ToChar(0);
        }

        private void _textbox_KeyUp(object sender, KeyEventArgs e) {
            bool isOk = _checkInputKey(_textBox.Text);
            if (isOk == false) {
                _textBox.Text = "없음";
            }
        }

        private bool _checkInputKey(string p) {
            string[] t = p.Split(StringData.DIVISION_MARK);
            foreach (string v in Enum.GetNames(typeof(Keys))) {
                if (t[t.Length - 1].Trim().Equals(v)) {
                    return true;
                }
            }
            return false;
        }
    }
}
