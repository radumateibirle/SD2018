using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace Assignment3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void loginButon_Click(object sender, EventArgs e)
        {
            HomeService hs = new HomeService();
            string res = await hs.Login(usernameText.Text, PasswordText.Text);
            if (res == null) return;
            this.Hide();
            if (res.ToLower()=="admin")
            {
                var teacherPanel = new TeacherPanel(usernameText.Text, PasswordText.Text);
                teacherPanel.Closed += (s, args) => this.Close();
                teacherPanel.Show();
            }
            else if (res.ToLower() == "student")
            {
                var studentPanel = new StudentPanel(usernameText.Text, PasswordText.Text);
                studentPanel.Closed += (s, args) => this.Close();
                studentPanel.Show();
            }

        }
    }
}
