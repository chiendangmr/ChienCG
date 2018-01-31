using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CGPreviewControl
{
    public partial class ShockwaveFlashControl : UserControl
    {
        public ShockwaveFlashControl()
        {
            InitializeComponent();
        }

        public AxShockwaveFlashObjects.AxShockwaveFlash FlashActiveX { get { return axShockwaveFlash1; } }
    }
}
