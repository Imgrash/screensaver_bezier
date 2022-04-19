using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace screensaver
{
    public class controller
    {
        PictureBox pb;
        Random rnd = new Random();
        List<clr> colors = new List<clr>();
        List<animation_controller> acs = new List<animation_controller>();
        public List<animation_controller> Acs
        { get { return acs; } }
        public void init(int pbSizeWidth, int pbSizeHeight, int quantLines, int quantDots)
        {
            for (int k = 0; k < 255; k += 8)
                for (int i = 0; i < 255; i++)
                    colors.Add(new clr(i, k, i));
            for (int i = 0; i < quantLines; i++)
                acs.Add(new animation_controller(colors));
            foreach (animation_controller a in acs)
                for (int i = 0; i < quantDots; i++)
                    a.addDot(rnd.Next() % pbSizeWidth, rnd.Next() % pbSizeHeight);
            for (int i = 0; i < acs.Count - 1; i++)
                acs[i].glueToNext(acs[i + 1]);
            acs[acs.Count - 1].glueToNext(acs[0]);
            foreach (animation_controller a in acs)
                a.glueToTail();
        }
        public controller(int pbSizeWidth, int pbSizeHeight, int quantLines, int quantDots)
        {
            init(pbSizeWidth, pbSizeHeight, quantLines, quantDots);
        }
        public controller(int pbSizeWidth, int pbSizeHeight)
        {
            init(pbSizeWidth, pbSizeHeight, Properties.Settings.Default.QuantLines, Properties.Settings.Default.QuantDots);
        }
        public void connectPictureBox(PictureBox pbn)
        {
            pb = pbn;
            
            Timer tmr = new Timer();
            tmr.Interval = 20;
            foreach (animation_controller a in acs)
                a.connectPictureBox(pb);
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Start();
        }
        public void animate()
        {
            foreach (animation_controller ac in acs)
                ac.move();
            foreach (animation_controller ac in acs)
                ac.glueToTail();
        }
        private void tmr_Tick(object sender, EventArgs e)
        {
            animate();
            pb.Invalidate();
        }
        
    }
}
