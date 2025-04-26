using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhaHangNhau
{
    public partial class fQRCode : Form
    {
        public fQRCode()
        {
            InitializeComponent();
        }

        public fQRCode(Bitmap qrCode)
        {
            InitializeComponent();
            this.Width = qrCode.Width+ 25 + 30 + 25;
            this.Height = qrCode.Height + 25 + 30 + 25;
            this.StartPosition = FormStartPosition.CenterScreen;

            picBoxQRCode.Location = new Point(25, 25);
            picBoxQRCode.Width = qrCode.Width;
            picBoxQRCode.Height = qrCode.Height;
            picBoxQRCode.Image = qrCode;
        }
    }
}
