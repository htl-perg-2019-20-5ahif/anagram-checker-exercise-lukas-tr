using System;
using System.Linq;

namespace Anagram
{
    public class AnagramChecker : IAnagramChecker
    {
        public bool isAnagram(string s1, string s2) =>
            sortLetters(s1).Equals(sortLetters(s2));

        public string sortLetters(string s) => String.Concat(s.OrderBy(c => c));
    }
}
