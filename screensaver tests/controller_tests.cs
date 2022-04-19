using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace screensaver_tests
{
    using screensaver;
    [TestClass]
    public class controller_tests
    {
        [TestMethod]
        public void Test_Controller()
        {
            int linesCount = 4;
            int dotsCOunt = 4;
            controller contr = new controller(50, 50, linesCount, dotsCOunt);
            contr.animate();
            for (int i = 0; i < linesCount - 1; i++)
            {
                Assert.IsTrue(contr.Acs[i].Dots[dotsCOunt - 1].X == contr.Acs[i + 1].Dots[0].X, "Координаты хвоста и головы соседних кривых не равны");
                Assert.IsTrue(contr.Acs[i].Dots[dotsCOunt - 1].Y == contr.Acs[i + 1].Dots[0].Y, "Координаты хвоста и головы соседних кривых не равны");
            }
            Assert.IsTrue(contr.Acs[linesCount-1].Dots[dotsCOunt - 1].X == contr.Acs[0].Dots[0].X, "Координаты хвоста и головы соседних кривых не равны");
            Assert.IsTrue(contr.Acs[linesCount-1].Dots[dotsCOunt - 1].Y == contr.Acs[0].Dots[0].Y, "Координаты хвоста и головы соседних кривых не равны");
        }
        
    }
}
