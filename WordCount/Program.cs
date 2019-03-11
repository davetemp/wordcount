using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("LordOfTheRingsFellowship.txt"))
            {
                foreach(var word in GetMostFrequent(sr, 10))
                {
                    Console.WriteLine(word.Text + " appears " + word.Count + " Times.");
                }
            }
        }

        public static List<Word> GetMostFrequent(StreamReader sr, int top)
        {
            var counts = new List<Word>();
            var words = sr.ReadToEnd().Split(' ');

            foreach (var word in words.GroupBy(w => w)
            .OrderByDescending(g => g.Count())
            .Take(top)
            .Select(g => g.Key))
            {
                counts.Add(new Word() { Text = word, Count = words.Where(w => w == word).Count()});
            }

            return counts;
        }

        public class Word
        {
            public string Text { get; set; }
            public int Count { get; set; }
        }
    }
}
