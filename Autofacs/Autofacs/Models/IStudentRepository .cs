using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autofacs.Models
{
    public interface IStudentRepository
    {
        string Name
        {
            get;
        }

        IEnumerable<Student> GetAll();
        Student Get(int id);
        Student Add(Student item);
        bool Update(Student item);
        bool Delete(int id);
    }
}