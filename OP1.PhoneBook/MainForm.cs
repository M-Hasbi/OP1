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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_newregistry_Click(object sender, EventArgs e)
        {
            BussinessLogicLayer.BLL BLL = new BussinessLogicLayer.BLL();
            int returnvalue = BLL.AddRegistry(txt_name.Text,txt_surname.Text,txt_phonei.Text,txt_phoneii.Text,txt_phoneiii.Text,txt_email.Text,txt_webaddress.Text,txt_address.Text,
                txt_description.Text);
            if (returnvalue>0)
            {
                MessageBox.Show("New Registry Has Been Created", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
