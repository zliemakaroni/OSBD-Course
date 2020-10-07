using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач_КП_3сем
{
    public partial class AutorisationForm : Form
    {
        public AutorisationForm()
        {
            InitializeComponent();
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (loginBox.Text == "admin" && passwordBox.Text == "admin")
            {
                DeveloperMode DM = new DeveloperMode();
                DM.Show();
                this.Hide();
            }
            else
            {
                using (Entity_DB.Model1 db = new Entity_DB.Model1())
                {
                    var reg = db.Users
                        .Where(z => z.Login == loginBox.Text && z.Password == passwordBox.Text)
                        .Select(z => z.Faculty_Id)
                        .ToList();
                    if (reg.Count > 0)
                    {
                        Entity_DB.decanMode DecMode = new Entity_DB.decanMode(reg.First().Value);
                        DecMode.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
