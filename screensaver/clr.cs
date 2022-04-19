namespace screensaver
{
    using static System.Math;
    public class clr
    {
        private int r;
        public int R
        {
            get { return r; }
            set { r = Abs(value) % 255; }
        }
        private int g;
        public int G
        {
            get { return g; }
            set { g = Abs(value) % 255; }
        }
        private int b;
        public int B
        {
            get { return b; }
            set { b = Abs(value) % 255; }
        }
        private bool changeRRight = true;
        private bool changeGRight = true;
        private bool changeBRight = true;
        public clr(int rn, int gn, int bn)
        {
            R = rn; G = gn; B = bn;
        }
        void changeComponent(ref int C, ref bool Cb)
        {
            if (Cb) C += 2; else C -= 2;
            if(C < 0) { Cb = true; C = 0; }
            else if(C > 255) { Cb = false; C = 255; }
        }
        public void changeClr()
        {
            changeComponent(ref r, ref changeRRight);
            changeComponent(ref g, ref changeGRight);
            changeComponent(ref b, ref changeBRight);
        }
    }
}
