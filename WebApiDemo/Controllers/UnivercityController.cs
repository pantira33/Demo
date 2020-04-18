using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
            using (WebApiDemoContext contexts = new WebApiDemoContext())
            {
                
                return contexts.Univercity.ToList();

            }
        }
        [HttpGet("{id}")]
        public HttpResponseMessage Get(int id)
        {
            using (WebApiDemoContext contexts = new WebApiDemoContext())
            {
                
                var context = contexts.Univercity.FirstOrDefault(e => e.UnivercityId == id);
                if (context != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, context);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Univercity with id" + id.ToString() + "not found");
                }
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] Univercity univercity)
        {
            try
            {
                using (WebApiDemoContext contexts = new WebApiDemoContext())
                {
                    contexts.Univercity.Add(univercity);
                    contexts.SaveChanges();

                    var context = Request.CreateResponse(HttpStatusCode.Created, univercity);
                    context.Headers.Location = new Uri(Request.RequestUri + univercity.StudentId.ToString);
                    return context;
                }
            }
            catch (Exception ex)
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        public HttpResponseMessage Put(int id, [FromBody] Univercity univercity)
        {
            try
            {
                using (WebApiDemoContext contexts = new WebApiDemoContext())
                {
                    var context = contexts.Univercity.FirstOrDefault(e => e.UnivercityId == id);
                    if (context == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Univercity with id = " + id.ToString() + "not found to delet");
                    }
                    else
                    {
                        context.UnivercityId = univercity.StudentId;
                        context.UnivercityName = univercity.StudentName;
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
                    var context = contexts.Univercity.FirstOrDefault(e => e.UnivercityId == id);
                    if (context == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Univercity with id = " + id.ToString() + "not found to delet");
                    }
                    else
                    {
                        contexts.Univercity.Remove(context);
                        contexts.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }

                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }

       
}
