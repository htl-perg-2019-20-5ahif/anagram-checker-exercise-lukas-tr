using Anagram;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.WriteLine("invalid args");
                return;
            }
            switch(args[0])
            {
                case "check":
                    if(args.Length <= 2)
                    {
                        Console.WriteLine("invalid args");
                        return;
                    }
                    Console.WriteLine("\"{0}\" and \"{1}\" are {2}anagrams", args[0], args[1], new AnagramChecker().isAnagram(args[1], args[2]) ? "" : "no ");
                    break;
                case "getKnown":
                    if(args.Length <= 1)
                    {
                        Console.WriteLine("invalid args");
                        return;
                    }
                    var config = new ConfigurationBuilder();
                    config.AddJsonFile("config.json");
                    config.AddEnvironmentVariables();
                    var dr = new DictionaryReader(config.Build());
                    var dict = dr.read();
                    var key = new AnagramChecker().sortLetters(args[1]);
                    if(dict.ContainsKey(key))
                    {
                        foreach(var str in dict[key])
                        {
                            if (str.Equals(args[1]))
                            {
                                continue;
                            }
                            Console.WriteLine(str);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No known anagrams found");
                    }
                    break;
                default:
                    Console.WriteLine("invalid args");
                    break;
            }
        }
    }
}
