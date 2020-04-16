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
    [Route("Univercity")]
    public class UnivercityController : ControllerBase
    {
        

        [HttpGet]
        public IEnumerable<Univercity> Get()
        {
            using (var context = new WebApiDemoContext())
            {
                // return all student
                return context.Univercity.ToList();
               
            }
        }
        [HttpGet("{id}")]
        public IEnumerable<Univercity> GetByID(int id)
        {
            using (var context = new WebApiDemoContext())
            {
                // return student by id
                return context.Univercity.Where(u => u.UnivercityId == id).ToList();
            }
        }
        
        [HttpPost]
        public IEnumerable<Univercity> Post()
        {
            using (var context = new WebApiDemoContext())
            {
                // return Add Student
                Univercity uni = new Univercity();
                uni.UnivercityId = 1004;
                uni.UnivercityName = "KMUTL";

                context.Univercity.Add(uni);
                context.SaveChanges();
                return context.Univercity.Where(u => u.UnivercityId == 1004).ToList();
            }
              
        }
        public IEnumerable<Univercity> Update(int id)
        {
            using (var context = new WebApiDemoContext())
            {
                // return update Student
                Univercity uni = context.Univercity.Where(u => u.UnivercityId == 1003).FirstOrDefault();
                uni.UnivercityName = "BU";
                context.SaveChanges();
                return context.Univercity.Where(u => u.UnivercityId == 1003).ToList();
            }
        }
        public IEnumerable<Univercity> Delete(int id)
        {
            using (var context = new WebApiDemoContext())
            {
                // return remove Student
                Univercity std = new Univercity();
                context.Univercity.Remove(std);
                context.SaveChanges();
                return context.Univercity.Where(u => u.UnivercityId == 1003).ToList();

            }
        }
    }
}
