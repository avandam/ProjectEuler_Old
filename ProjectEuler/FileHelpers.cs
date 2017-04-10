using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler
{
    public static class FileHelpers
    {
        public static List<List<long>> ReadNumberSequencePerLine(string filename)
        {
            var lines = File.ReadAllLines(filename);

            return lines.Select(line => line.Split(' ')).Select(items => items.Select(long.Parse).ToList()).ToList();
        }

        public static List<List<int>> ReadDigitsPerLine(string filename)
        {
            var lines = File.ReadAllLines(filename);

            return lines.Select(line => line.Select(character => int.Parse(character.ToString())).ToList()).ToList();
        }

        public static List<string> ReadNamesFromFile(string filename)
        {
            var text = File.ReadAllLines(filename);

            return text[0].Replace("\"", "").ToLower().Split(',').ToList();
        }
    }
}
