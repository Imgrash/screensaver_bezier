using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace screensaver_tests
{
    using screensaver;
    [TestClass]
    public class clr_tests
    {
        [TestMethod]
        public void Test_Clr_MoreThan255()
        {
            clr col = new clr(280,280,280);
            Assert.IsTrue(col.R == 25, "Компонент цвета не свелся к делению нацело на 256");
            Assert.IsTrue(col.G == 25, "Компонент цвета не свелся к делению нацело на 256");
            Assert.IsTrue(col.B == 25, "Компонент цвета не свелся к делению нацело на 256");
        }
        [TestMethod]
        public void Test_Clr_LessThan0()
        {
            clr col = new clr(-280, -280, -280);
            Assert.IsTrue(col.R > 0, "Компонент цвета не обратился в положительное число");
            Assert.IsTrue(col.G > 0, "Компонент цвета не обратился в положительное число");
            Assert.IsTrue(col.B > 0, "Компонент цвета не обратился в положительное число");
        }
        [TestMethod]
        public void Test_Clr_ChangeToLessThan0()
        {
            clr col = new clr(254, 254, 254);
            col.changeClr();
            col.R = 1; col.G = 1; col.B = 1;
            col.changeClr();
            Assert.IsTrue(col.R == 0, "Цвет не обратился в левую границу (в 0)");
            Assert.IsTrue(col.G == 0, "Цвет не обратился в левую границу (в 0)");
            Assert.IsTrue(col.B == 0, "Цвет не обратился в левую границу (в 0)");
        }
        [TestMethod]
        public void Test_Clr_ChangeToMoreThan255()
        {
            clr col = new clr(254, 254, 254);
            col.changeClr();
            Assert.IsTrue(col.R == 255, "Цвет не обратился в правую границу (в 255)");
            Assert.IsTrue(col.G == 255, "Цвет не обратился в правую границу (в 255)");
            Assert.IsTrue(col.B == 255, "Цвет не обратился в правую границу (в 255)");
        }
    }
}
