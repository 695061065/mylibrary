using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUllForm
{
    public partial class ForMain : Form
    {
        public ForMain()
        {
            InitializeComponent();
        }

        private void ForMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = Mylibrary.EncHelper.MD5Encrypt32(textBox1.Text.Trim());
            label1.Text = textBox2.TextLength.ToString();
        }
    }
}
