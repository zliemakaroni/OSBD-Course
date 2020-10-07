using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач_КП_3сем
{
    public partial class GroupeForm : Form
    {
        public GroupeForm()
        {
            InitializeComponent();

            db = new Entity_DB.Model1();
            var spec = from s in db.Specialty
                       select new
                       {
                           Id = s.Id,
                           Name = s.Name
                       };
            comboBox1.DataSource = spec.ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            var cour = from c in db.Courses
                       select new
                       {
                           Id = c.Id,
                           Name = c.Name
                       };
            comboBox2.DataSource = cour.ToList();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
        }

        Entity_DB.Model1 db;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void GroupeForm_Load(object sender, EventArgs e)
        {

        }

    }
}
