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
    [Route("api/checkAnagram")]
    public class CheckAnagramController : ControllerBase
    {
        private readonly ILogger<CheckAnagramController> _logger;
        private readonly IAnagramChecker _checker;

        public CheckAnagramController(ILogger<CheckAnagramController> logger, IAnagramChecker checker)
        {
            _logger = logger;
            _checker = checker;
        }

        [HttpPost]
        public IActionResult Check([FromBody] WordsToCheck words)
        {
            if(string.IsNullOrEmpty(words.w1) || string.IsNullOrEmpty(words.w2))
            {
                _logger.LogWarning("missing words");
                return BadRequest();
            }
            if(!_checker.isAnagram(words.w1, words.w2))
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
