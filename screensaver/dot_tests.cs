using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace screensaver_tests
{
    using screensaver;
    [TestClass]
    public class dot_tests
    {
        
        [TestMethod]
        public void Test_Dot_BordersInAnimate()
        {
            dot dotj = new dot(1,1);
            dotj.animate(9,9);

            Assert.IsTrue(dotj.X == 0, "X ���������� ������� - ������ ��� ����� �� ������� ����� ����������");
            Assert.IsTrue(dotj.Y == 9, "Y ���������� ������� - ������ ��� ����� �� ������� ������� ����������");

            dotj.animate(9, 9);

            Assert.IsTrue(dotj.X == 9, "X ���������� ������� - ������ ��� ����� �� ������� ������ ����������");
            Assert.IsTrue(dotj.Y == 0, "Y ���������� ������� - ������ ��� ����� �� ������� ������ ����������");
        }
    }
}
