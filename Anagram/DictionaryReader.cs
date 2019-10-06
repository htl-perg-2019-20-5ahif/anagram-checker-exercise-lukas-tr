using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Anagram
{
    public class DictionaryReader : IDictionaryReader
    {
        private IConfiguration config;

        public DictionaryReader(IConfiguration config)
        {
            this.config = config;
        }
        public Dictionary<string, List<string>> read()
        {
            var text = File.ReadAllText(config["dictionaryFileName"]);
            var lines = text.Replace("\r", "").Split('\n');
            var dict = new Dictionary<string, List<string>>();
            foreach(var line in lines)
            {
                var sameWords = line.Split('=').Select(word => word.Trim()).ToList();
                if(sameWords.Count() < 2)
                {
                    continue;
                }
                var key = new AnagramChecker().sortLetters(sameWords[0]);
                if(dict.ContainsKey(key))
                {
                    dict[key].AddRange(sameWords);
                    dict[key] = dict[key].Distinct().ToList();
                }
                else
                {
                    dict.Add(key, sameWords);
                }
            }
            return dict;
        }
    }
}
