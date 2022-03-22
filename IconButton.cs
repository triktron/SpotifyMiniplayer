using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SpotifyMiniplayer
{
    internal class IconButton : PictureBox
    {
        private Image normalImage;
        private Image clickImage;
        private Image hoverImage;

        [Category("Icon Button")]
        public Image NormalImage
        {
            get { return normalImage; }
            set
            {
                normalImage = value;
                Image = value;
                Invalidate();
            }
        }

        [Category("Icon Button")]
        public Image ClickImage
        {
            get { return clickImage; }
            set
            {
                clickImage = value;
                Invalidate();
            }
        }

        [Category("Icon Button")]
        public Image HoverImage
        {
            get { return hoverImage; }
            set
            {
                hoverImage = value;
                Invalidate();
            }
        }

        public IconButton()
        {
            SizeMode = PictureBoxSizeMode.StretchImage;
            Size = new Size(50, 50);
            BackColor = Color.Transparent;
            ForeColor = Color.Transparent;
            normalImage = BackgroundImage;
            clickImage = BackgroundImage;
            hoverImage = BackgroundImage;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            Image = clickImage;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            Image = hoverImage;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            Image = hoverImage;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseEnter(e);

            Image = normalImage;
        }
    }
}