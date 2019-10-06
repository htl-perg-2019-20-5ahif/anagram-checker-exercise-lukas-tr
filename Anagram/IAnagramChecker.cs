using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Anagram
{
    public interface IAnagramChecker
    {
        bool isAnagram(string s1, string s2);
        string sortLetters(string s);
    }
}
