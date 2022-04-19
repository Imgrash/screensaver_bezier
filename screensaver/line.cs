namespace screensaver
{
    public class line
    {
        private dot a;
        private dot b;
        public dot A
        {
            get { return a; }
        }
        public dot B
        {
            get { return b; }
        }
        public line(dot newa, dot newb)
        {
            a = newa;
            b = newb;
        }
    }
}
