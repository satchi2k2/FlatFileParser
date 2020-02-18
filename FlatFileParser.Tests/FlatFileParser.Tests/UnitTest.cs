using FlatFileParser.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;

namespace FlatFileParser.Tests
{
    public class UnitTest
    {
        [Theory]
        [InlineData(@"TestData\maint.fmt", @"TestData\RegMaint.dat")]
        public void TestFMTParser(string filePath, string maintenanceFile)
        {
            var appfileinfo = new FileInfo(Assembly.GetExecutingAssembly().Location);
            string actualPath = Path.Combine(appfileinfo.DirectoryName, filePath);
            string maintFile = Path.Combine(appfileinfo.DirectoryName, maintenanceFile);

            var maps = FlatFileParser.ParserHelper.PrepareMapFromFMTFile(actualPath);


           

            File.ReadAllLines(maintFile).ToList().ForEach(line =>
            {

                


            });



        }
    }
}
