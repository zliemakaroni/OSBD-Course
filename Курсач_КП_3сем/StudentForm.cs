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
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
            using (Entity_DB.Model1 db = new Entity_DB.Model1())
            {
                var groups = from g in db.Groups
                             join s in db.Specialty on g.Specialty_Id equals s.Id
                               select new
                               {
                                   Id = g.Id,
                                   Name = s.Name + " - " + g.Year,

                               };
                comboBox1.DataSource = groups.ToList();
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";

            }
        }

    }
}
