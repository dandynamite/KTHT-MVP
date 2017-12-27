using Client.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Presenter;
using Newtonsoft.Json;
using Client.Model;

namespace Client
{
    public partial class Main : Form, IView
    {
        PresenterImp presenter;
        public Main()
        {
            presenter = new PresenterImp(this);
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)
        {

            if (!addNameStudent.Text.Equals("") &&
                !addLopStudent.Text.Equals(""))
            {
                Student student = new Student
                {
                    Name = addNameStudent.Text,
                    LopId = Int32.Parse(addLopStudent.Text)
                };
                presenter.addStudent(student);
            }
        }

        public void updateView(String json, String type)
        {
            if (type.Equals("Student"))
                dataGridView1.DataSource = JsonConvert.DeserializeObject<List<Student>>(json);
            else if (type.Equals("Lop"))
                dataGridView1.DataSource = JsonConvert.DeserializeObject<List<Lop>>(json);
        }

        public void error(string error)
        {
            MessageBox.Show(error, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            presenter.viewStudent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            presenter.viewClass();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (!deleteIdStudent.Text.Equals(""))
            {
                int id = Int32.Parse(deleteIdStudent.Text);
                presenter.deleteStudent(id);
            }
        }

        private void updateIdStudent_TextChanged(object sender, EventArgs e)
        {
            int id = Int32.Parse(updateIdStudent.Text);
            Student student = presenter.getStudent(id);
            namUpdateStudent.Text = student.Name;
            LopUpdateStudent.Text = "" + student.LopId;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!namUpdateStudent.Text.Equals("") && !LopUpdateStudent.Text.Equals(""))
            {
                Student student = new Student
                {
                    Id = Int32.Parse(updateIdStudent.Text),
                    Name = namUpdateStudent.Text,
                    LopId = Int32.Parse(LopUpdateStudent.Text)
                };

                presenter.updateStudent(student);
            }
        }
    }
}
