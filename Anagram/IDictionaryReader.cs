using System;
using System.Collections.Generic;
using System.Text;

namespace Anagram
{
    public interface IDictionaryReader
    {
        Dictionary<string, List<string>> read();
    }
}
