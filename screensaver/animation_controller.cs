using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace screensaver
{
    public class animation_controller
    {
        int pbSizeWidth;
        int pbSizeHeight;
        curve_controller cc;
        List<clr> colors;
        animation_controller next;
        public List<dot> Dots
        { get { return cc.Dots; } }
        public void glueToNext(animation_controller nextn)
        { next = nextn; }
        public animation_controller(List<clr> clrs)
        {
            colors = clrs;
            cc = new curve_controller();
        }
        public void connectPictureBox(PictureBox pbn)
        {
            pbn.Paint += new PaintEventHandler(pb_Paint);
            pbSizeWidth = pbn.Size.Width;
            pbSizeHeight = pbn.Size.Height;
        }        

        public void glueToTail()
        {
            int nextLastDot = next.Dots.Count - 1;
            cc.setDotX(0, next.cc.getDotX(nextLastDot));
            cc.setDotY(0, next.cc.getDotY(nextLastDot));
        }
        public void addDot(int x, int y)
        { cc.addDot(new dot(x, y)); }
        public void move()
        {
            for (int i = 1; i < cc.Dots.Count; i++)
                cc.Dots[i].animate(pbSizeWidth, pbSizeHeight);
        }
        public List<dot> getDotsToDraw(float step)
        {
            List<dot> DotsToDraw = new List<dot>();
            for(float i=0; i <= 1; i+=step)
                DotsToDraw.Add(cc.tdot(i));
            return DotsToDraw;
        }
        public void changeColor(ref int count)
        {
            colors[count].changeClr();
            count++;
            count %= colors.Count;
        }
        private void pb_Paint(object sender, PaintEventArgs e)
        {
            List<dot> DotsToDraw = getDotsToDraw(0.001f);
            int count = 0;
            foreach(dot d in DotsToDraw)
            {
                e.Graphics.DrawEllipse(new Pen(Color.FromArgb(255, colors[count].R, colors[count].G, colors[count].B)), d.X, d.Y, 1, 1);
                changeColor(ref count);
            }
        }
    }
}
