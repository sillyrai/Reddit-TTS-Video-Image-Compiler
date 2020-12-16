using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGVS
{
    public partial class BiggerView : Form
    {
        public BiggerView(Image img)
        {
            InitializeComponent();
            pictureBox1.Image = img;
        }

        private void BiggerView_Load(object sender, EventArgs e)
        {

        }
    }
}
