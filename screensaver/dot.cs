namespace screensaver
{
    public class dot
    {
        private float x;
        private float y;
        private bool anLeft;
        private bool anUp;
        private int speed = 10;
        public dot()
        {
            x = 0; y = 0;
            anLeft = true;
            anUp = true;
        }
        public dot(float xn,float yn)
        {
            x = xn; y = yn;
            anLeft = true;
            anUp = true;
        }

        public float X
        {
            get { return x; }
            set { x = value; }
        }
        public float Y
        {
            get { return y; }
            set { y = value; }
        }
        public void animate(int width, int height)
        {
            if (anLeft)
                x -= speed;
            else
                x += speed;

            if (anUp)
                y += speed;
            else
                y -= speed;

            if (x < 0)
            {   anLeft = false; x = 0;  }
            else if (x > width)
            {   anLeft = true;  x = width;  }

            if (y < 0)
            {   anUp = true;    y = 0;  }
            else if (y > height)
            {   anUp = false;   y = height; }
        }
    }
}
