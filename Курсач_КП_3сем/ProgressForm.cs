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
    public partial class ProgressForm : Form
    {
        private int FacultyId;
        public ProgressForm(int facultyId)
        {
            this.FacultyId = facultyId;
            InitializeComponent();
            using (Entity_DB.Model1 db = new Entity_DB.Model1())
            {
                var sub = from s in db.Subjects
                          join t in db.Teachers on s.Teacher_Id equals t.Id
                          orderby s.Name
                          select new
                          {
                              Id = s.Id,
                              Name = s.Name + " ( " + t.Name + " )",
                          };
                comboBox1.DataSource = sub.ToList();
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";

                var stud = from s in db.Students
                           join g in db.Groups on s.Group_Id equals g.Id
                           where g.Faculty_Id == this.FacultyId
                           select new
                           {
                               Id = s.Id,
                               Name = s.Name
                           };
                comboBox2.DataSource = stud.ToList();
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Id";
            }
        }
        public ProgressForm()
        {
            InitializeComponent();
                        
        }

    }
}
