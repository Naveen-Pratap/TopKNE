using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TopKNE.Controllers
{
    [ApiController]
    [Route("topk")]
    public class TopKFromTweetsController : ControllerBase
    {

        private readonly ILogger<TopKFromTweetsController> _logger;
        private readonly ITwitterService _service;

        public TopKFromTweetsController(ITwitterService service, ILogger<TopKFromTweetsController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet]
        public ResponseModel Get([FromQuery(Name = "username")] string username, [FromQuery(Name = "k")] int k = 1)
        {
            var tokens = _service.GetTopK(username, k);
            ResponseModel _objResponseModel = new ResponseModel
            {
                Data = tokens,
                Status = true,
                Message = "Request successfull"
            };

            return _objResponseModel;
        }
    }
}
