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
    [Route("api/getKnownAnagrams")]
    public class KnownAnagramController : ControllerBase
    {
        private readonly ILogger<KnownAnagramController> _logger;
        private readonly IAnagramChecker _checker;
        private readonly IDictionaryReader _reader;

        public KnownAnagramController(ILogger<KnownAnagramController> logger, IAnagramChecker checker, IDictionaryReader reader)
        {
            _logger = logger;
            _checker = checker;
            _reader = reader;
        }

        [HttpGet]
        public IActionResult GetKnown([FromQuery] string w)
        {
            if (string.IsNullOrEmpty(w))
            {
                _logger.LogWarning("missing word");
                return BadRequest();
            }
            var key = _checker.sortLetters(w);
            var dict = _reader.read();
            if (dict.ContainsKey(key))
            {
                return Ok(dict[key].Where(anagram => !anagram.Equals(w)));
            }
            _logger.LogInformation("missing word in dictionary: {0}", w);
            return NotFound();
        }
    }
}
