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
    public partial class DeveloperMode : Form
    {
        public DeveloperMode()
        {
            InitializeComponent();
        }
        private void SaveAll()
        {
            try
            {
                this.progressTableAdapter.Update(this.progressDataSet.Progress);
                this.studentsTableAdapter.Update(this.progressDataSet.Students);
                this.usersTableAdapter.Update(this.progressDataSet.Users);
                this.coursesTableAdapter.Update(this.progressDataSet.Courses);
                this.teachersTableAdapter.Update(this.progressDataSet.Teachers);
                this.specialtyTableAdapter.Update(this.progressDataSet.Specialty);
                this.subjectsTableAdapter.Update(this.progressDataSet.Subjects);
                this.groupsTableAdapter.Update(this.progressDataSet.Groups);
                this.facultiesTableAdapter.Update(this.progressDataSet.Faculties);
            }
            catch(Exception SaveError)
            {
                MessageBox.Show(SaveError.Message, "Error");
                this.progressTableAdapter.Fill(this.progressDataSet.Progress);
                this.studentsTableAdapter.Fill(this.progressDataSet.Students);
                this.usersTableAdapter.Fill(this.progressDataSet.Users);
                this.coursesTableAdapter.Fill(this.progressDataSet.Courses);
                this.teachersTableAdapter.Fill(this.progressDataSet.Teachers);
                this.specialtyTableAdapter.Fill(this.progressDataSet.Specialty);
                this.subjectsTableAdapter.Fill(this.progressDataSet.Subjects);
                this.groupsTableAdapter.Fill(this.progressDataSet.Groups);
                this.facultiesTableAdapter.Fill(this.progressDataSet.Faculties);

            }
        }

        private void DeveloperMode_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "progressDataSet.Progress". При необходимости она может быть перемещена или удалена.
            this.progressTableAdapter.Fill(this.progressDataSet.Progress);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "progressDataSet.Students". При необходимости она может быть перемещена или удалена.
            this.studentsTableAdapter.Fill(this.progressDataSet.Students);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "progressDataSet.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.progressDataSet.Users);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "progressDataSet.Courses". При необходимости она может быть перемещена или удалена.
            this.coursesTableAdapter.Fill(this.progressDataSet.Courses);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "progressDataSet.Teachers". При необходимости она может быть перемещена или удалена.
            this.teachersTableAdapter.Fill(this.progressDataSet.Teachers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "progressDataSet.Subjects". При необходимости она может быть перемещена или удалена.
            this.subjectsTableAdapter.Fill(this.progressDataSet.Subjects);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "progressDataSet.Specialty". При необходимости она может быть перемещена или удалена.
            this.specialtyTableAdapter.Fill(this.progressDataSet.Specialty);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "progressDataSet.Groups". При необходимости она может быть перемещена или удалена.
            this.groupsTableAdapter.Fill(this.progressDataSet.Groups);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "progressDataSet.Faculties". При необходимости она может быть перемещена или удалена.
            this.facultiesTableAdapter.Fill(this.progressDataSet.Faculties);

        }


        private void button1_Click(object sender, EventArgs e)
        {

            this.SaveAll();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Курсач сделан с использованием паттерна ShitCode");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {

                DialogResult dialogResult = MessageBox.Show("Сохранить изменения?","!",MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    this.SaveAll();
                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Close();
                }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void DeveloperMode_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
