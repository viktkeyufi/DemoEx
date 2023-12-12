using DemoExam.ModelEF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoExam.Forms.Client
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
            using(var db = new DB_DmExamEntities())
            {
                dataGridViewUser.DataSource = db.Users.Select(u => new { 
                u.FirstName,
                u.LastName,
                u.Role
                }).ToArray();
            }
        }
    }
}
