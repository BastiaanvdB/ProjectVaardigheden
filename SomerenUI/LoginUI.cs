using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SomerenModel;
using SomerenLogic;

namespace SomerenUI
{
    public partial class LoginUI : Form
    {
        public LoginUI()
        {
            InitializeComponent();
            MagicWord magic = new MagicWord();
            magic.Show();
        }


        private void Login()
        {
            if ((textBoxUsername.Text.Length > 0) && (textBoxPassword.Text.Length > 0))
            {
                User user = new User
                {
                    Username = textBoxUsername.Text,
                    Password = textBoxPassword.Text
                };

            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Login();
        }
    }
}
