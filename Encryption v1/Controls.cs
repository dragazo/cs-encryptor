using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Encryption_v1
{
    public class SolidProgress : UserControl
    {
        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                Invalidate();
            }
        }

        private int _maxValue;
        public int MaxValue
        {
            get
            {
                return _maxValue;
            }
            set
            {
                _maxValue = value;
                Invalidate();
            }
        }

        public SolidProgress(int value, int maxValue)
        {
            _value = value;
            _maxValue = maxValue;

            BorderStyle = BorderStyle.FixedSingle;

            DoubleBuffered = true;
        }
        public SolidProgress() : this(0, 100) { }

        public SolidBrush ProgressBrush = new SolidBrush(Color.LightSkyBlue);
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(ProgressBrush,
                0f, 0f, Width * (float)Value / MaxValue, Height);
        }
    }
}
