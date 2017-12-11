using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autofacs.Models
{
    public class StudentQuery : IStudentQuery
    {
        //public IStudentRepository[] studentRepositorys;
        public IStudentRepository studentRepositorys;
        public StudentQuery(
            //IStudentRepository[] studentRepositorys
            IStudentRepository studentRepositorys
            )
        {
            this.studentRepositorys = studentRepositorys;
        }

        public IEnumerable<Student> FindStudents()
        {
            var data = new List<Student>();
            //foreach (var studentRepository in studentRepositorys)
            //{
            //    foreach (var stu in studentRepository.GetAll())
            //    {
            //        data.Add(stu);
            //    }
            //}

            data = studentRepositorys.GetAll().ToList();

            return data;
        }
    }
}