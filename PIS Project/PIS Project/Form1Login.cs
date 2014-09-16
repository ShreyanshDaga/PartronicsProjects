using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PIS_Project
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Decline_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2RouteSel ss = new Form2RouteSel();
            ss.Show();


        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
