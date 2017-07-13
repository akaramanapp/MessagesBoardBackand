using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MessagesBoardBackand.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MessagesBoardBackand.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        static List<Message> _messages = new List<Message>{
                new Message { Owner="Kerim", Text="New Content" },
                new Message { Owner="Tuğba", Text="Old Content" }
            };
        // GET: api/values
        [HttpGet]
        public IEnumerable<Message> Get()
        {
            return _messages;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public Message Post([FromBody] Message message)
        {
            if (message.Text != "" && message.Owner != "")
            {
                _messages.Add(message);
            }

            return message;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
