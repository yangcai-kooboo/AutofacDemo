using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autofacs.Models
{
    public class StudentRepository2 : IStudentRepository
    {
        private List<Student> Articles = new List<Student>();

        public StudentRepository2()
        {
            //添加演示数据  
            Add(new Student { Id = 4, Name = "赵六", Major = "软件工程", Graduation = "2013年", School = "西安工业大学" });
            Add(new Student { Id = 5, Name = "吴七", Major = "计算机科学与技术", Graduation = "2013年", School = "西安工业大学" });
            Add(new Student { Id = 6, Name = "王八", Major = "自动化", Graduation = "2013年", School = "西安工业大学" });
        }

        public string Name
        {
            get { return "StudentRepository1"; }
        }
        /// <summary>  
        /// 获取全部学生信息  
        /// </summary>  
        /// <returns></returns>  
        public IEnumerable<Student> GetAll()
        {
            return Articles;
        }
        /// <summary>  
        /// 通过ID获取学生信息  
        /// </summary>  
        /// <param name="id"></param>  
        /// <returns></returns>  
        public Student Get(int id)
        {
            return Articles.Find(p => p.Id == id);
        }
        /// <summary>  
        /// 添加学生信息  
        /// </summary>  
        /// <param name="item"></param>  
        /// <returns></returns>  
        public Student Add(Student item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            Articles.Add(item);
            return item;
        }
        /// <summary>  
        /// 更新学生信息  
        /// </summary>  
        /// <param name="item"></param>  
        /// <returns></returns>  
        public bool Update(Student item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index = Articles.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            Articles.RemoveAt(index);
            Articles.Add(item);
            return true;
        }
        /// <summary>  
        /// 删除学生信息  
        /// </summary>  
        /// <param name="id"></param>  
        /// <returns></returns>  
        public bool Delete(int id)
        {
            Articles.RemoveAll(p => p.Id == id);
            return true;
        }  
    }
}