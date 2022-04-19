using System.Collections.Generic;
namespace screensaver
{
    public class tLessThan0 : System.Exception
    { }
    public class tMoreThan1 : System.Exception
    { }
    public class curve_controller
    {
        List<dot> dotsArray;
        public List<dot> Dots
        { get { return dotsArray; } }
        public void setDotX(int number, float x)
        { dotsArray[number].X = x; }
        public void setDotY(int number, float y)
        { dotsArray[number].Y = y; }
        public float getDotX(int number)
        { return dotsArray[number].X; }
        public float getDotY(int number)
        { return dotsArray[number].Y; }
        public curve_controller()
        { dotsArray = new List<dot>(); }
        public void addDot(dot a)
        { dotsArray.Add(a); }
        public line middleline(line ab, line bc, float t)
        {
            dot d, e;
            d = new dot();
            e = new dot();
            d.X = (ab.B.X - ab.A.X) * t + ab.A.X;
            d.Y = (ab.B.Y - ab.A.Y) * t + ab.A.Y;
            e.X = (bc.B.X - bc.A.X) * t + bc.A.X;
            e.Y = (bc.B.Y - bc.A.Y) * t + bc.A.Y;
            return new line(d, e);
        }
        private dot recursive_processing(float t, List<line> lineArray)
        {
            if (lineArray.Count > 1)
            {
                List<line> newlineArray = new List<line>();
                for (int i = 1; i < lineArray.Count; i++)
                    newlineArray.Add(middleline(lineArray[i - 1], lineArray[i], t));
                return recursive_processing(t, newlineArray);
            }
            else
            {
                dot d;
                d = new dot();
                d.X = (lineArray[0].B.X - lineArray[0].A.X) * t + lineArray[0].A.X;
                d.Y = (lineArray[0].B.Y - lineArray[0].A.Y) * t + lineArray[0].A.Y;
                return d;
            }
        }
        public dot tdot(float t)
        {
            try
            {
                if (t < 0)
                    throw new tLessThan0();
                if (t > 1)
                    throw new tMoreThan1();
            }
            finally { }
            List<line> lineArray = new List<line>();
            for (int i = 0; i < dotsArray.Count-1; i++)
                lineArray.Add(new line(dotsArray[i], dotsArray[i+1]));
            return recursive_processing(t, lineArray);
        }
    }
}
