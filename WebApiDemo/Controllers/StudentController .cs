using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
            using (WebApiDemoContext contexts = new WebApiDemoContext())
            {
                // return all student
                return contexts.Student.ToList();
               
            }
        }
        [HttpGet("{id}")]
        public HttpResponseMessage Get(int id)
        {
             using (WebApiDemoContext contexts = new WebApiDemoContext())
            {
                // return student by id
                var context = contexts.Student.FirstOrDefault(e => e.StudentId == id);
                if (context != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, context);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with id" + id.ToString() + "not found");
                }
            }
        }
       
        [HttpPost]
        public HttpResponseMessage Get(int id)
        {
           try
            {
                using (WebApiDemoContext contexts = new WebApiDemoContext())
                {
                    contexts.Student.Add(student);
                    contexts.SaveChanges();

                    var context = Request.CreateResponse(HttpStatusCode.Created, student);
                    context.Headers.Location = new Uri(Request.RequestUri + student.StudentId.ToString);
                    return context;
                }
            }
            catch (Exception ex)
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
              
        }
       public HttpResponseMessage Put(int id,[FromBody] Student student)
        {
            try
            {
                using (WebApiDemoContext contexts = new WebApiDemoContext())
                {
                    var context = contexts.Student.FirstOrDefault(e => e.StudentId == id);
                    if (context == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with id = " + id.ToString() + "not found to delet");
                    }
                    else
                    {
                        context.StudentId = student.StudentId;
                        context.StudentName = student.StudentName;
                        contexts.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, context);
                    }

                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


      public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (WebApiDemoContext contexts = new WebApiDemoContext())
                {
                    var context = contexts.Student.FirstOrDefault(e => e.StudentId == id);
                    if (context == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with id = " + id.ToString() + "not found to delet");
                    }
                    else
                    {
                        contexts.Student.Remove(context);
                        contexts.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }

                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }

    
}
