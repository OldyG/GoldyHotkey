using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoldyProject.GoldyHotkey;


namespace GoldyHotkeyTest {
    [TestClass]
    public class ShortcutStringAnalystTest {


        #region 이 범위에 있는 테스트는 허용하는 방식입니다.
        /// <summary>
        /// 한 개의 키도 받아들이는지
        /// </summary>
        [TestMethod]
        public void TestOneKey() {
            Assert.AreEqual<String>("T", ShortcutStringAnalyst.GetShortcutKeys("t").ToString());
        }

        /// <summary>
        /// 정상적인 String을 정상적으로 출력하는지
        /// </summary>
        [TestMethod]
        public void TestConvertByNormalString() {
            Assert.AreEqual<String>("Ctrl + Alt + Shift + T", ShortcutStringAnalyst.GetShortcutKeys("Ctrl + Alt + Shift + T").ToString());
        }

        /// <summary>
        /// 모두 소문자로 하여도 변환하는지
        /// </summary>
        [TestMethod]
        public void TestConvertByLowerString() {
            Assert.AreEqual<String>("Ctrl + Alt + Shift + T", ShortcutStringAnalyst.GetShortcutKeys("ctrl + alt + shift + t").ToString());
        }

        /// <summary>
        /// 모두 대문자로 하여도 변환하는지
        /// </summary>
        [TestMethod]
        public void TestConvertByUpperString() {
            Assert.AreEqual<String>("Ctrl + Alt + Shift + T", ShortcutStringAnalyst.GetShortcutKeys("CTRL + ALT + SHIFT + T").ToString());
        }

        /// <summary>
        /// 대문자, 소문자,왔다갔다 해도 인식하는지
        /// </summary>
        [TestMethod]
        public void TestZigZagByLowerOrUpper() {
            Assert.AreEqual<String>("Ctrl + Alt + Shift + T", ShortcutStringAnalyst.GetShortcutKeys("ctrl + ALT + ShIFt + t").ToString());
        }


        /// <summary>
        /// 조합키 순서를 변형하여도 변환하는지
        /// </summary>
        [TestMethod]
        public void TestChangeSequence() {
            Assert.AreEqual<String>("Ctrl + Alt + Shift + T", ShortcutStringAnalyst.GetShortcutKeys(" SHIFT + ALT + CTRL + T").ToString());
        }

        /// <summary>
        /// 스페이스 랜덤해도 변환하는지
        /// </summary>
        [TestMethod]
        public void TestSpaceString() {
            Assert.AreEqual<String>("Ctrl + Alt + Shift + T", ShortcutStringAnalyst.GetShortcutKeys(" SHIFT+ ALT +CTRL+ T").ToString());
        }

        #endregion

        
        #region 이 범위에 있는 테스트는 허용하지 않아 Exception을 발생합니다.
        /// <summary>
        /// '+'가 5개 넘어갈  경우
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(GoldyHotkeyEception))]
        public void TestPlusCharacterMorethenFive() {
            ShortcutKeys temp = ShortcutStringAnalyst.GetShortcutKeys(" Ctrl + ALT + SHIFT + WIN + H + T ");
        } 

        /// <summary>
        /// 같은키가 여러개 일 경우 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(GoldyHotkeyEception))]
        public void TestSameKeys() {
            ShortcutKeys temp = ShortcutStringAnalyst.GetShortcutKeys(" Ctrl + CTRL + ctrl + T");
        }

        /// <summary>
        /// 조합키 주변에 잡키가 껴있을경우
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(GoldyHotkeyEception))]
        public void TestWrongStringAboutModifier() {
            ShortcutKeys temp = ShortcutStringAnalyst.GetShortcutKeys("ACTRLA + BALTB + CSHIFTC + T");
        }

        /// <summary>
        /// 조합키 자리에 알수 없는 키가 들어올 경우
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(GoldyHotkeyEception))]
        public void TestUnknowStringAboutModifier() {
            ShortcutKeys temp = ShortcutStringAnalyst.GetShortcutKeys("A + B + C + T");
        }

        /// <summary>
        /// 키가 비어있을 경우
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(GoldyHotkeyEception))]
        public void TestPlusPlusPlus() {
            ShortcutKeys temp = ShortcutStringAnalyst.GetShortcutKeys("CTRL+Shift+ALT+");
        }

        /// <summary>
        /// 조합키에 띄어쓰기되어있을경우
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(GoldyHotkeyEception))]
        public void TestSpaceFromModifier() {
            ShortcutKeys temp = ShortcutStringAnalyst.GetShortcutKeys("CTR L+S hi ft+A LT+T");
        }
        #endregion
    }
}
