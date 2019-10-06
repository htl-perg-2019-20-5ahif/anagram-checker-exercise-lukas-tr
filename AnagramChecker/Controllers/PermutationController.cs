using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anagram;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnagramChecker.Controllers
{
    [ApiController]
    [Route("api/getPermutations")]
    public class PermutationController : ControllerBase
    {
        private readonly ILogger<PermutationController> _logger;
        private readonly IAnagramGenerator _generator;

        public PermutationController(ILogger<PermutationController> logger, IAnagramGenerator generator)
        {
            _generator = generator;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GeneratePermutations([FromQuery] string w)
        {
            if (string.IsNullOrEmpty(w))
            {
                _logger.LogWarning("missing word");
                return BadRequest();
            }
            return Ok(_generator.generate(w));
        }
    }
}
