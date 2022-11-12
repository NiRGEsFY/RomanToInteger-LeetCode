using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution("III"));
            Console.WriteLine(Solution("LVIII"));
            Console.WriteLine(Solution("MCMXCIV"));
            Console.WriteLine(Solution("DCLXVI"));
            Console.ReadLine();
        }
        static public int Solution(string s)
        {
            char[] word = s.ToArray();
            int answer = 0;
            Dictionary<char, int> IndexOfChar = new Dictionary<char, int>
            {
                ['M'] = 1000,
                ['D'] = 500,
                ['C'] = 100,
                ['L'] = 50,
                ['X'] = 10,
                ['V'] = 5,
                ['I'] = 1
            };
            char[] findChars = new char[] { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };
            foreach (var chars in findChars)
            {
                while (s.Contains(chars))
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == chars && i == 0)
                        {
                            answer += IndexOfChar[word[i]];
                            s = s.Remove(0, 1);
                            word = s.ToArray();
                            break;
                        }
                        else if (word[i] == chars && i != 0)
                        {
                            answer += IndexOfChar[word[i]];
                            s = s.Remove(s.IndexOf(word[i]), s.IndexOf(word[i]));
                            word = s.ToArray();
                            for (int j = (i - 1); j >= 0; j--)
                            {
                                answer -= IndexOfChar[word[j]];
                            }
                            s = s.Remove(0, i);
                            word = s.ToArray();
                            break;
                        }
                    }
                }
            }
            return answer;
        }
    }
}
