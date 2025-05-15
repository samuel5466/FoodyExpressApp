using FoodyExpressApp.Models;
using FoodyExpressApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodyExpressApp
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private AuthService authService = new AuthService();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtLoginUsername.Text;
            string password = txtLoginPassword.Text;

            var user = authService.Login(username, password);
            if (user != null)
            {
                MessageBox.Show($"Welcome {user.Role}, {user.FirstName}!", "Login Success");
                // You can now show dashboard panels or features based on user.Role
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed");
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Password = txtPassword.Text,
                DateOfBirth = dtpDOB.Value,
                Gender = cbGender.Text,
                Role = cbRole.Text
            };

            if (authService.Register(user))
            {
                MessageBox.Show("Registration successful! Your username is: " + user.Username);
                panelRegister.Visible = false;
                panelLogin.Visible = true;
                txtLoginUsername.Text = user.Username;
            }
            else
            {
                MessageBox.Show("Registration failed. Username might already exist.");
            }
        }

        private void linkToLogin_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelRegister.Visible = false;
            panelLogin.Visible = true;
        }

        private void linkToRegister_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelLogin.Visible = false;
            panelRegister.Visible = true;
        }
    }
}
