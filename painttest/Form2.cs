using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace painttest
{
    public partial class Form2 : Form
    {
        Form1 parentForm;
        public Form2(int width, int height, Form1 parentform)
        {
            InitializeComponent();

            this.parentForm = parentform;
            textBox1.Text = width.ToString();
            textBox2.Text = height.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out int width);
            int.TryParse(textBox2.Text, out int height);

            parentForm.resize(width, height, checkBox1.Checked);

            this.Close();
        }
    }
}
