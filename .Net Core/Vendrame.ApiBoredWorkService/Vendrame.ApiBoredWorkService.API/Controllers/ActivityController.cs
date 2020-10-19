using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Vendrame.ApiBoredWorkService.Model;
using Vendrame.ApiBoredWorkService.Service;

namespace Vendrame.ApiBoredWorkService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ActivityController> _logger;
        private readonly IServiceActivity _serviceActivity;

        public ActivityController(IConfiguration configuration, ILogger<ActivityController> logger, IServiceActivity serviceActivity)
        {
            _configuration = configuration;
            _logger = logger;
            _serviceActivity = serviceActivity;
        }

        // GET: api/Activity
        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            return _serviceActivity.getActivity();
        }

        // GET: api/Activity/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Activity
        [HttpPost]
        public void Post([FromBody] Activity activity)
        {
            var data = DateTime.Now;
            activity.CreationDate = data;
            _serviceActivity.InsertActivity(activity);
        }

        // PUT: api/Activity/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
