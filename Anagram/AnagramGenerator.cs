using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Anagram
{
    public class AnagramGenerator : IAnagramGenerator
    {
        public IEnumerable<string> generate(string s)
        {
            // https://loekvandenouweland.com/content/Permutations-with-C-sharp-and-LINQ.html
            if (s.Length == 1) return new List<string> { s };
            var permutations = from c in s
                               from p in generate(new string(s.Where(x => x != c).ToArray()))
                               select c + p;

            return permutations;
        }

    }
}
