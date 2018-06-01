using BLL;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3
{
    public partial class Register : Form
    {
        UserServices uS = new UserServices();
        public Register()
        {
            InitializeComponent();
        }

        private async void doneButton_Click(object sender, EventArgs e)
        {
            if (tokenTextBox.Text == null) return;
            if (nameTextBox.Text == null) return;
            if (passwordTextBox.Text == null) return;
            if (repPasswordTextBox.Text == null) return;
            if (groupTextBox.Text == null) return;
            if (hobbyTextBox.Text == null) return;
            if (passwordTextBox.Text != repPasswordTextBox.Text) return;

            List<UserModel> users = await uS.getAll();
            UserModel user = users.FirstOrDefault(u => u.Token == tokenTextBox.Text);
            user.FullName = nameTextBox.Text;
            user.Password = passwordTextBox.Text;
            user.GroupName = groupTextBox.Text;
            user.Hobby = hobbyTextBox.Text;
            uS.update(user);

            this.Hide();
            var loginPanel = new Login();
            loginPanel.Closed += (s, args) => this.Close();
            loginPanel.Show();
        }
    }
}
