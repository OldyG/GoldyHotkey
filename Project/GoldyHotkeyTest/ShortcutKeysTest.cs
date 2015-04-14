using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoldyProject.GoldyHotkey;
using System.Windows.Forms;

namespace GoldyHotkeyTest
{
    [TestClass]
    public class ShortcutKeysTest
    {
        /// <summary>
        /// 키가 같을 경우 같은 객체로 인식
        /// </summary>
        [TestMethod]
        public void TestEqualTest()
        {
            ShortcutKeys tempKey1 = new ShortcutKeys();
            tempKey1.IsCtrl = true;
            tempKey1.IsShift = true;
            tempKey1.Key = Keys.D1;

            ShortcutKeys tempKey2 = new ShortcutKeys();
            tempKey2.IsCtrl = true;
            tempKey2.IsShift = true;
            tempKey2.Key = Keys.D1;

            Assert.AreEqual<ShortcutKeys>(tempKey1,tempKey2);

        }
        /// <summary>
        /// 키가 다를 경우 다른 객체로 인식
        /// </summary>
        [TestMethod]
        public void TestNotEqualTest()
        {
            ShortcutKeys tempKey1 = new ShortcutKeys();
            tempKey1.IsCtrl = true;
            tempKey1.IsShift = true;
            tempKey1.Key = Keys.D1;

            ShortcutKeys tempKey2 = new ShortcutKeys();
            tempKey2.IsCtrl = false;
            tempKey2.IsShift = false;
            tempKey2.Key = Keys.D2;

            Assert.AreNotEqual<ShortcutKeys>(tempKey1, tempKey2);
        }

        /// <summary>
        /// Ctrl + A
        /// </summary>
        [TestMethod]
        public void TestCtrlAKeys()
        {
            ShortcutKeys tempKey1 = new ShortcutKeys();
            tempKey1.IsCtrl = true;
            tempKey1.Key = Keys.A;

            Assert.AreEqual<String>("Ctrl + A", tempKey1.ToString());
        }

        /// <summary>
        /// Alt + A
        /// </summary>
        [TestMethod]
        public void TestAltAKeys()
        {
            ShortcutKeys tempKey1 = new ShortcutKeys();
            tempKey1.IsAlt = true;
            tempKey1.Key = Keys.A;

            Assert.AreEqual<String>("Alt + A", tempKey1.ToString());
        }

        /// <summary>
        /// Shift + A
        /// </summary>
        [TestMethod]
        public void TestShiftAKeys()
        {
            ShortcutKeys tempKey1 = new ShortcutKeys();
            tempKey1.IsShift = true;
            tempKey1.Key = Keys.A;

            Assert.AreEqual<String>("Shift + A", tempKey1.ToString());
        }

        /// <summary>
        /// Win + A
        /// </summary>
        [TestMethod]
        public void TestWinAKeys()
        {
            ShortcutKeys tempKey1 = new ShortcutKeys();
            tempKey1.isWin = true;
            tempKey1.Key = Keys.A;

            Assert.AreEqual<String>("Win + A", tempKey1.ToString());
        }

        /// <summary>
        /// Ctrl + Alt + Shift + Win + A
        /// </summary>
        [TestMethod]
        public void TestCtrlAltShiftWinAKeys()
        {
            ShortcutKeys tempKey1 = new ShortcutKeys();
            tempKey1.IsCtrl= true;
            tempKey1.IsAlt = true;
            tempKey1.IsShift = true;
            tempKey1.isWin = true;
            tempKey1.Key = Keys.A;

            Assert.AreEqual<String>("Ctrl + Alt + Shift + Win + A", tempKey1.ToString());
        }
    }
}
