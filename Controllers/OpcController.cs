using OpcLabs.EasyOpc.DataAccess;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace opc_rest.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OpcController : ApiController
    {
        public class PutBody
        {
            public string value;
        }
        private string serverClass = "ICONICS.DataWorX32.8/Register";
        // GET: api/Opc
        public IEnumerable<string> Get()
        {
            return new string[] { "" };
        }

        // GET: api/opc&q_str=tag1,tag2,...
        [HttpGet]
        public IHttpActionResult Get(string q_str)
        {
            EasyDAClient _client = new EasyDAClient();
            string[] tags = q_str.Split(',');
            string response = "";
            foreach (var tag in  tags)
            {
                response += "," + _client.ReadItem("", serverClass, tag);
            }
            return Ok(response); 
        }

        // POST: api/Opc
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Opc/5
        [HttpPut]
        public IHttpActionResult Put(string q_str, [FromBody]PutBody value)
        {
            EasyDAClient _client = new EasyDAClient();
            string[] tags = q_str.Split(',');
            for (int i = 0; i < tags.Length;)
            {
                var tag = tags[i];
                _client.WriteItemValue("", serverClass, tag, 10);
            }
            return Ok(value);
        }

        // DELETE: api/Opc/5
        public void Delete(int id)
        {
        }
    }
}
