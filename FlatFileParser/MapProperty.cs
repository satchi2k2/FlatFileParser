using System;

namespace FlatFileParser
{
    [System.AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MapProperty : Attribute
    {
        public string Name { get; set; }
        public int StartIndex { get; set; }
        public int Length { get; set; }

    }


}
