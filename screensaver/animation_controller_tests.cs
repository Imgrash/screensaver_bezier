using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace screensaver_tests
{
    using screensaver;
    [TestClass]
    public class animation_controller_tests
    {
        Random rnd = new Random();
        List<clr> colors = new List<clr>();
        List<animation_controller> acs = new List<animation_controller>();
        
        [TestMethod]
        public void Test_AnimationController_HeadsAndTailsGluedAfterAnimating()
        {
            for (int k = 0; k < 255; k += 20)
                for (int i = 0; i < 255; i += 20)
                    colors.Add(new clr(i, k, i));
            for (int i = 0; i < 2; i++)
                acs.Add(new animation_controller(colors));
            foreach (animation_controller a in acs)
                for (int i = 0; i < 3; i++)
                    a.addDot(rnd.Next() % 50, rnd.Next() % 50);
            for (int i = 0; i < acs.Count - 1; i++)
                acs[i].glueToNext(acs[i + 1]);
            acs[acs.Count - 1].glueToNext(acs[0]);
            foreach (animation_controller a in acs)
                a.glueToTail();

            foreach (animation_controller ac in acs)
                ac.move();
            foreach (animation_controller ac in acs)
                ac.glueToTail();

            Assert.IsTrue(acs[0].Dots[2].X == acs[1].Dots[0].X, "Координаты хвоста и головы соседних кривых не равны");
            Assert.IsTrue(acs[0].Dots[2].Y == acs[1].Dots[0].Y, "Координаты хвоста и головы соседних кривых не равны");

            Assert.IsTrue(acs[0].Dots[0].X == acs[1].Dots[2].X, "Координаты хвоста и головы соседних кривых не равны");
            Assert.IsTrue(acs[0].Dots[0].Y == acs[1].Dots[2].Y, "Координаты хвоста и головы соседних кривых не равны");
        }
        [TestMethod]
        public void Test_AnimationController_ChangeColor()
        {
            for (int k = 0; k < 255; k += 50)
                for (int i = 0; i < 255; i += 50)
                    colors.Add(new clr(i, k, i));
            animation_controller ac = new animation_controller(colors);
            for (int i = 0; i < 3; i++)
                ac.addDot(rnd.Next() % 50, rnd.Next() % 50);

            int count = 0;
            while(count < colors.Count-1)
                ac.changeColor(ref count);
            ac.changeColor(ref count);
            Assert.IsTrue(count == 0, "Указатель на используемый цвет должен быть закольцован");
        }
        [TestMethod]
        public void Test_AnimationController_GetDotsToDraw()
        {
            for (int k = 0; k < 255; k += 50)
                for (int i = 0; i < 255; i += 50)
                    colors.Add(new clr(i, k, i));
            animation_controller ac = new animation_controller(colors);
            for (int i = 0; i < 3; i++)
                ac.addDot(rnd.Next() % 50, rnd.Next() % 50);

            List<dot> DotsToDraw = ac.getDotsToDraw(0.5f);
            Assert.IsTrue(DotsToDraw.Count == 3, "0 и 1 должны быть включены в используемые коэффициенты при подсчете координат");

        }
    }
}
