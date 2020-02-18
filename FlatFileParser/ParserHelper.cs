using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FlatFileParser
{
    public class ParserHelper
    {
        public static  List<FlatFilePropertyMap> PrepareMapFromFMTFile(string filePath)
        {

            List<FlatFilePropertyMap> map = new List<FlatFilePropertyMap>();
            int startPosition = 0;
            int prevLength = 0;
            ParseFMTFile(filePath).ForEach(r =>
            {
                map.Add(new FlatFilePropertyMap()
                {
                    PropertyName = r.Key,
                    StartIndex = startPosition += prevLength,
                    Length = Math.Abs(r.Value)
                });


                prevLength = Math.Abs(r.Value);
            });

            return map;
        }
        public static List<KeyValuePair<string, int>> ParseFMTFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                //File does not exist
                return null;
            }
            else
            {

                var result =
                File.ReadAllLines(filePath)
                 .SkipWhile(l => l.StartsWith("#"))
                 .Select(l => l.Split("#".ToCharArray()).First())
                 .Select(l => l.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                 .Where(arr => arr.Length == 2)
                 .Select(arr => new KeyValuePair<string, int>(arr.First(), Convert.ToInt32(arr.Last())))
                .ToList();

                return result;
            }

        }
    }
}
