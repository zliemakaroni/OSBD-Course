using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач_КП_3сем.Entity_DB
{
    public partial class decanMode : Form
    {

        private int FacultyId;
        Entity_DB.Model1 db;
        public decanMode()
        {
            InitializeComponent();
            
        }

        private void DGV1fill()
        {
                var res = from prog in db.Progress

                          join stud in db.Students on prog.Student_Id equals stud.Id
                          join sub in db.Subjects on prog.Student_Id equals sub.Id
                          join t in db.Teachers on sub.Teacher_Id equals t.Id
                          join g in db.Groups on stud.Group_Id equals g.Id
                          where g.Faculty_Id == this.FacultyId
                          orderby stud.Name, sub.Name
                          select new
                          {
                              Id = prog.Id,
                              Subject = sub.Name + " ( " + t.Name + " )",
                              Student = stud.Name,
                              Mark = prog.Mark
                          };
                dataGridView1.DataSource = res.ToList();
        }
        private void DGV2fill()
        {
            var groups = from g in db.Groups
                         join s in db.Specialty on g.Specialty_Id equals s.Id
                         join c in db.Courses on g.Course_Id equals c.Id
                         where g.Faculty_Id == this.FacultyId
                         orderby c.Name, s.Name
                         select new
                         {
                             Id = g.Id,
                             Course = c.Name,
                             Number = g.Number,
                             Specialty = s.Name,
                             TimeOfStudy = s.Time_of_study,
                             Year = g.Year

                         };
            dataGridView2.DataSource = groups.ToList();
        }
        private void DGV3fill()
        {
            var students = from stud in db.Students
                         join g in db.Groups on stud.Group_Id equals g.Id
                         where g.Faculty_Id == this.FacultyId
                         orderby stud.Name
                         select new
                         {
                             Id = stud.Id,
                             Name = stud.Name,
                             Date_of_Birth = stud.Date_of_birth,
                             Group = g.Number


                         };
            dataGridView3.DataSource = students.ToList();
        }
        public decanMode(int facultyId)
        {
            this.FacultyId = facultyId;
            InitializeComponent();

            db = new Entity_DB.Model1();
            DGV1fill();
            DGV2fill();
            DGV3fill();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            GroupeForm GF = new GroupeForm();
            DialogResult result = GF.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;


            Entity_DB.Groups Group = new Entity_DB.Groups();
                Group.Specialty_Id = (int)GF.comboBox1.SelectedValue;
                Group.Course_Id = (int)GF.comboBox2.SelectedValue;
                Group.Year = (int)GF.numericUpDown1.Value;
                Group.Number = (int)GF.numericUpDown2.Value;
            Group.Faculty_Id = this.FacultyId;
            db.Groups.Add(Group);
            db.SaveChanges();
            DGV2fill();
            
            MessageBox.Show("Новая группа добавлена");
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Курсач");
        }

        /*private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int index = dataGridView2.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView2[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                DB.Groups groupe = db.Groups.Find(id);

                GroupeForm GF = new GroupeForm();

                GF.comboBox1.SelectedValue = groupe.Specialty_Id;
                GF.comboBox2.SelectedValue = groupe.Course_Id;
                GF.numericUpDown1.Value = groupe.Year;
                GF.numericUpDown2.Value = groupe.Number;

                DialogResult result = GF.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;


                DB.Groups Group = new DB.Groups();
                Group.Specialty_Id = (int)GF.comboBox1.SelectedValue;
                Group.Course_Id = (int)GF.comboBox2.SelectedValue;
                Group.Year = (int)GF.numericUpDown1.Value;
                Group.Number = (int)GF.numericUpDown2.Value;
                Group.Faculty_Id = this.FacultyId;
                db.SaveChanges();
                DGV2fill();
                MessageBox.Show("Группа изменена");
            }
        }*/

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int index = dataGridView2.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView2[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                Entity_DB.Groups groupe = db.Groups.Find(id);
                db.Groups.Remove(groupe); db.SaveChanges();
                DGV2fill();
                MessageBox.Show("Группа удалена");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProgressForm PF = new ProgressForm(this.FacultyId);
            DialogResult result = PF.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;


            Entity_DB.Progress Prog = new Entity_DB.Progress();
            Prog.Subject_Id = (int)PF.comboBox2.SelectedValue;
            Prog.Student_Id = (int)PF.comboBox1.SelectedValue;
            Prog.Mark = PF.textBox1.SelectedText;

            db.Progress.Add(Prog);
            db.SaveChanges();
            DGV1fill();
            MessageBox.Show("Новая запись добавлена");
        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            int id = 0;
            bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
            if (converted == false)
                return;
            DB.Schedule temp = db.Schedule.Find(id);

            ScheduleForm SF = new ScheduleForm();

            SF.comboBox1.SelectedValue = temp.Day_Id;
            SF.comboBox2.SelectedValue = temp.Lesson_Id;
            SF.comboBox3.SelectedValue = temp.Auditory_Id;
            SF.comboBox4.SelectedValue = temp.Group_Id;
            SF.comboBox5.SelectedValue = temp.Subject_Id;
            SF.comboBox6.SelectedValue = temp.LessonType_Id;
            SF.comboBox7.SelectedValue = temp.Teacher_Id;

            DialogResult result = SF.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;


            DB.Schedule Sched = new DB.Schedule();
            Sched.Day_Id = (int)SF.comboBox1.SelectedValue;
            Sched.Lesson_Id = (int)SF.comboBox2.SelectedValue;
            Sched.Auditory_Id = (int)SF.comboBox3.SelectedValue;
            Sched.Group_Id = (int)SF.comboBox4.SelectedValue;
            Sched.Subject_Id = (int)SF.comboBox5.SelectedValue;
            Sched.LessonType_Id = (int)SF.comboBox6.SelectedValue;
            Sched.Teacher_Id = (int)SF.comboBox7.SelectedValue;
            db.SaveChanges();
            DGV1fill();
            MessageBox.Show("Запись изменена");

        }*/

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                Entity_DB.Progress Prog = db.Progress.Find(id);
                db.Progress.Remove(Prog);
                db.SaveChanges();
                DGV1fill();
                MessageBox.Show("Запись удалена");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StudentForm SF = new StudentForm();
            DialogResult result = SF.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;


            Entity_DB.Students Student = new Entity_DB.Students();
            Student.Name = SF.textBox1.SelectedText;
            Student.Date_of_birth = SF.textBox2.SelectedText;
            Student.Group_Id = (int)SF.comboBox1.SelectedValue;
            db.Students.Add(Student);
            db.SaveChanges();
            DGV3fill();

            MessageBox.Show("Новый студент добавлен");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                int index = dataGridView3.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView3[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                Entity_DB.Students Stud = db.Students.Find(id);
                db.Students.Remove(Stud);
                db.SaveChanges();
                DGV3fill();
                MessageBox.Show("Запись удалена");
            }
        }

        private void decanMode_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var res = from prog in db.Progress

                      join stud in db.Students on prog.Student_Id equals stud.Id
                      join sub in db.Subjects on prog.Student_Id equals sub.Id
                      join t in db.Teachers on sub.Teacher_Id equals t.Id
                      join g in db.Groups on stud.Group_Id equals g.Id
                      where (int)comboBox1.SelectedValue == stud.Id
                      where g.Faculty_Id == this.FacultyId
                      orderby stud.Name, sub.Name
                      select new
                      {
                          Id = prog.Id,
                          Subject = sub.Name + " ( " + t.Name + " )",
                          Student = stud.Name,
                          Mark = prog.Mark
                      };
            dataGridView1.DataSource = res.ToList();
        }

        private void decanMode_Load(object sender, EventArgs e)
        {
            using (Entity_DB.Model1 db = new Entity_DB.Model1())
            {

                var stud = from s in db.Students
                           join g in db.Groups on s.Group_Id equals g.Id
                           where g.Faculty_Id == this.FacultyId
                           select new
                           {
                               Id = s.Id,
                               Name = s.Name
                           };
                comboBox1.DataSource = stud.ToList();
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
            }

        }
    }
}
