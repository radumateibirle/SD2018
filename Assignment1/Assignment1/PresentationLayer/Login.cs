using Assignment1.ServicesLayer.Contracts;
using Assignment1.ServicesLayer.Models;
using Assignment1.ServicesLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Assignment1.PresentationLayer
{
    public partial class Login : Form
    {
        private readonly IUserService userServices;
        public Login()
        {
            InitializeComponent();
            userServices = new UserService();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            UserModel attempt = new UserModel();
            attempt.setUsername(usernameText.Text);
            attempt.setPlainPassword(passwordText.Text);

            int role = userServices.login(attempt);
            Console.WriteLine("role = " + role);
            if(role == 0)
            {
                this.Hide();
                var admin = new Admin();
                admin.Closed += (s, args) => this.Close();
                admin.Show();
            }
            else if(role == 10)
            {
                this.Hide();
                var cashier = new Cashier();
                cashier.Closed += (s, args) => this.Close();
                cashier.Show();
            }
            else
            {
                StatusLabel.Text = "Login failed!";
            }
        }
    }
}
