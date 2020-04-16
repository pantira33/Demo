using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiDemo.Entitys;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("Student")]
    public class StudentController : ControllerBase
    {
        

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            using (var context = new WebApiDemoContext())
            {
                // return all student
                return context.Student.ToList();
               
            }
        }
        [HttpGet("{id}")]
        public IEnumerable<Student> GetByID(int id)
        {
            using (var context = new WebApiDemoContext())
            {
                // return student by id
                return context.Student.Where(e => e.StudentId == id).ToList();
            }
        }
       
        [HttpPost]
        public IEnumerable<Student> Post()
        {
            using (var context = new WebApiDemoContext())
            {
                // return Add Student
                Student std = new Student();
                std.StudentId = 103;
                std.StudentName = "C";

                context.Student.Add(std);
                context.SaveChanges();
                return context.Student.Where(e => e.StudentId == 103).ToList();
            }
              
        }
        public IEnumerable<Student> Update(int id)
        {
            using (var context = new WebApiDemoContext())
            {
                // return update Student
                Student std = context.Student.Where(e => e.StudentId == 103).FirstOrDefault();
                std.StudentName = "D";
                context.SaveChanges();
                return context.Student.Where(e => e.StudentId == 103).ToList();
            }
        }

       public IEnumerable<Student> Delete(int id)
        {
            using (var context = new WebApiDemoContext())
            {
                // return remove Student
                Student std = new Student();
                context.Student.Remove(std);
                context.SaveChanges();
                return context.Student.Where(e => e.StudentId == 103).ToList();

            }
        }
    }
}
