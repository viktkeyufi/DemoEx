using DemoExam.ModelEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DemoExam.Forms
{
    public partial class RegisterForm : Form
    {
        private List<string> _roleManager = new List<string> { "Client" };
        private List<string> _roleAdmin = new List<string> { "Client", "Admin", "Manager", "Master" };
        public RegisterForm(decimal? roleID)
        {
            InitializeComponent();
            using (var db = new DB_DmExamEntities())
            {
                if (roleID == db.Roles.First(c => c.RoleName == "Manager").ID)
                    comboBoxRole.DataSource = _roleManager;
                else comboBoxRole.DataSource = _roleAdmin;
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                using (var db = new DB_DmExamEntities())
                {
                    if (db.Users.FirstOrDefault(u => u.Nikname == textBoxNikName.Text) != null)
                    {
                        MessageBox.Show("Такой никнейм уже существует");
                        return;
                    }
                    User user = new User
                    {
                        Login = textBoxLogin.Text,
                        Password = textBoxPassword.Text,
                        FirstName = textBoxFirstName.Text,
                        LastName = textBoxLastName.Text,
                        Nikname = textBoxNikName.Text,
                        Mail = textBoxMail.Text,
                        Phone = textBoxPhone.Text,
                        RegisterDate = DateTime.Today,
                        ID_role = db.Roles.First(c => c.RoleName == comboBoxRole.Text).ID
                    };

                    db.Users.Add(user); db.SaveChanges();
                }
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Возникла ошибка, попробуйте снова.\n" + ex.ToString());
            }
        }
    }
}
