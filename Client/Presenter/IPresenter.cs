using Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Presenter
{
    interface IPresenter
    {
        void addStudent(Student student);
        void deleteStudent(int id);
        void updateStudent(Student student);
        void viewStudent();
        void viewClass();
        Student getStudent(int id);
    }
}
