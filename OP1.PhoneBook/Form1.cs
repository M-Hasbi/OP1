using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OP1.PhoneBook
{
    public partial class Form1 : Form
    {
        BussinessLogicLayer.BLL bll;
        public Form1()
        {
            InitializeComponent();
            bll = new BussinessLogicLayer.BLL();

        }

        private void btnenter_Click(object sender, EventArgs e)
        {
            int ReturnValues = bll.SystemControl(txtusername.Text,txtpassword.Text);
            if (ReturnValues > 0)
            {
                MainForm MF = new MainForm();
                MF.Show();
            }
            else
            {
                MessageBox.Show("Please make sure you entered your username or password correctly", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
