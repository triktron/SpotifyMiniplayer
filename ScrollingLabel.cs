using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SpotifyMiniplayer
{
    internal class ScrollingLabel : Label
    {
        private int availebleWidth = 100;
        private int speed = 10;
        private int delay = 10;

        [Category("Scrolling Text")]
        public int AvailebleWidth
        {
            get { return availebleWidth; }
            set
            {
                availebleWidth = value;
                Invalidate();
            }
        }


        [Category("Scrolling Text")]
        public int Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                Invalidate();
            }
        }

        [Category("Scrolling Text")]
        public int Delay
        {
            get { return delay; }
            set
            {
                delay = value;
                Invalidate();
            }
        }

        private enum States
        {
            startWait,
            left,
            endWait,
            right
        }

        private States state = States.right;
        private int offset = 0;
        private Timer timer = new Timer();

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (DesignMode) return;

            timer.Tick += UpdatePosition;
            timer.Start();
        }

        private void UpdatePosition(object? sender, EventArgs e)
        {
            if (state == States.right) offset += 1;
            if (state == States.left) offset -= 1;

            if (state == States.startWait)
            {
                state = States.left;
                timer.Interval = speed;
            }

            if (state == States.endWait)
            {
                state = States.right;
                timer.Interval = speed / 3;
            }

            if (state == States.left && offset <= -Width + availebleWidth) // Left - Width + availebleWidth
            {
                state = States.endWait;
                timer.Interval = delay / 3;
            }

            if (state == States.right && offset >= 0)
            {
                state = States.startWait;
                timer.Interval = delay;
            }

            Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (DesignMode) return;
            offset = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.HighQuality;
            
            g.DrawString(Text, Font, new SolidBrush(ForeColor), new Point(offset, 0));
        }
    }
}