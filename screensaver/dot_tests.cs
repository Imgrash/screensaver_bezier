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

            Assert.IsTrue(dotj.X == 0, "X анимирован неверно - должен был дойти до крайней левой координаты");
            Assert.IsTrue(dotj.Y == 9, "Y анимирован неверно - должен был дойти до крайней верхней координаты");

            dotj.animate(9, 9);

            Assert.IsTrue(dotj.X == 9, "X анимирован неверно - должен был дойти до крайней правой координаты");
            Assert.IsTrue(dotj.Y == 0, "Y анимирован неверно - должен был дойти до крайней нижней координаты");
        }
    }
}
