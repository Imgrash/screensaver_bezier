using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace screensaver_tests
{
    using screensaver;
    [TestClass]
    public class curve_controller_tests
    {
        curve_controller cc = new curve_controller();

        [TestMethod]
        [ExpectedException(typeof( tLessThan0 ), "t должен быть больше нуля")]
        public void Test_CurveController_tIsLessThan0()
        {
            cc.addDot(new dot(0, 0));
            cc.addDot(new dot(1, 1));
            cc.tdot(-1);
        }
        [TestMethod]
        [ExpectedException(typeof(tMoreThan1), "t должен быть меньше единицы")]
        public void Test_CurveController_tMoreThan1()
        {
            cc.addDot(new dot(0, 0));
            cc.addDot(new dot(1, 1));
            cc.tdot(2);
        }
        [TestMethod]
        public void Test_CurveController_CountingTDot()
        {
            cc.addDot(new dot(0,  0 ));
            cc.addDot(new dot(0,  30));
            cc.addDot(new dot(30, 0) );
            cc.addDot(new dot(30, 30));
            dot t = cc.tdot(0.5f);
            Assert.IsTrue(t.X == 15, "X должен быть на 15");
            Assert.IsTrue(t.Y == 15, "Y должен быть на 15");
        }
    }
}
