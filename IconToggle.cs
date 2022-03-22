using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SpotifyMiniplayer
{
    internal class IconToggle : PictureBox
    {
        private Image normalImage;
        private Image activeImage;

        private Image normalImageHover;
        private Image activeImageHover;


        [Category("Icon Toggle")]
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

        [Category("Icon Toggle")]
        public Image ActiveImage
        {
            get { return activeImage; }
            set
            {
                activeImage = value;
                Invalidate();
            }
        }

        [Category("Icon Toggle")]
        public Image NormalImageHover
        {
            get { return normalImageHover; }
            set
            {
                normalImageHover = value;
                Invalidate();
            }
        }

        [Category("Icon Toggle")]
        public Image ActiveImageHover
        {
            get { return activeImageHover; }
            set
            {
                activeImageHover = value;
                Invalidate();
            }
        }

        private bool state = false;

        public bool IsActive => state;

        bool IsHoverd = false;
        bool IsPressed = false;

        public IconToggle()
        {
            SizeMode = PictureBoxSizeMode.StretchImage;
            Size = new Size(50, 50);
            BackColor = Color.Transparent;
            ForeColor = Color.Transparent;
            normalImage = BackgroundImage;
            activeImage = BackgroundImage;

            UpdateImage();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            state = !state;
            IsPressed = true;

            UpdateImage();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            IsPressed = false;

            UpdateImage();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            IsHoverd = true;

            UpdateImage();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            IsHoverd = false;

            UpdateImage();
        }

        public void SetState(bool _state)
        {
            state = _state;

            UpdateImage();
        }

        private void UpdateImage()
        {
            if (IsHoverd)
            {
                Image = state ? activeImageHover : normalImageHover;
            } else
            {
                Image = state ? activeImage : normalImage;
            }
        }
    }
}