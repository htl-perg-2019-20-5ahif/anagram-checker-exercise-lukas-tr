using System;
using System.Collections.Generic;
using System.Text;

namespace Anagram
{
    public interface IAnagramGenerator
    {
        IEnumerable<string> generate(string word);
    }
}
