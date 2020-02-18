using FlatFileParser.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace FlatFileParser
{
    public static class ExtensionMethods
    {
        public static T MapObject<T>(this T objectToMap, List<FlatFilePropertyMap> propertyMaps, string inputString) where T : IMapFixture, new()
        {

            if (string.IsNullOrEmpty(inputString)) return default(T);

            T tempT = new T();

            Type typeOfT = typeof(T);
            PropertyInfo[] propertiesOfT = typeOfT.GetProperties();

            foreach (var prop in propertiesOfT)
            {
                var propName = prop.Name;

                var propType = prop.PropertyType;
                var propTypeCode = propType.GetTypeInfo().Attributes.GetTypeCode();

                var attribute = prop.GetCustomAttribute<MapProperty>();

                var maptoUse = propertyMaps.FirstOrDefault(m => m.PropertyName == propName || (attribute != null && m.PropertyName == attribute.Name));
                if (maptoUse != null
                    && maptoUse.StartIndex >= 0
                    && maptoUse.StartIndex < inputString.Length - 1
                    && maptoUse.StartIndex + maptoUse.Length <= inputString.Length)
                {

                    prop.SetValue(tempT, inputString.Substring(maptoUse.StartIndex, maptoUse.Length).GetValueObject(propTypeCode));
                }


            }
            return tempT;

        }


        public static object GetValueObject(this string chunk, TypeCode typeCode)
        {
            object retVal = new object();

            switch (typeCode)
            {

                case TypeCode.Empty:
                    break;

                case TypeCode.Object:
                    {
                        retVal = chunk.GetValue<Object>();
                        break;
                    }
                case TypeCode.DBNull:
                    {
                        retVal = chunk.GetValue<DBNull>();
                        break;
                    }
                case TypeCode.Boolean:
                    {
                        retVal = chunk.GetValue<Boolean>();
                        break;
                    }
                case TypeCode.Char:
                    {
                        retVal = chunk.GetValue<char>();
                        break;
                    }
                case TypeCode.SByte:
                    {
                        retVal = chunk.GetValue<sbyte>();
                        break;
                    }
                case TypeCode.Byte:
                    {
                        retVal = chunk.GetValue<byte>();
                        break;
                    }
                case TypeCode.Int16:
                    {
                        retVal = chunk.GetValue<Int16>();
                        break;
                    }
                case TypeCode.UInt16:
                    {
                        retVal = chunk.GetValue<UInt16>();
                        break;
                    }
                case TypeCode.Int32:
                    {
                        retVal = chunk.GetValue<int>();
                        break;
                    }
                case TypeCode.UInt32:
                    {
                        retVal = chunk.GetValue<uint>();
                        break;
                    }
                case TypeCode.Int64:
                    {
                        retVal = chunk.GetValue<long>();
                        break;
                    }
                case TypeCode.UInt64:
                    {
                        retVal = chunk.GetValue<ulong>();
                        break;
                    }
                case TypeCode.Single:
                    {
                        retVal = chunk.GetValue<Single>();
                        break;
                    }
                case TypeCode.Double:
                    {
                        retVal = chunk.GetValue<double>();
                        break;
                    }
                case TypeCode.Decimal:
                    {
                        retVal = chunk.GetValue<decimal>();
                        break;
                    }
                case TypeCode.DateTime:
                    {
                        retVal = chunk.GetValue<DateTime>();
                        break;
                    }
                case TypeCode.String:
                    {
                        retVal = chunk.GetValue<string>();
                        break;
                    }



            }
            return retVal;

        }

        public static object GetValueObject<T>(this string chunk)
        {
            return chunk.GetValue<T>();


        }


        public static T GetValue<T>(this string chunk)
        {
            T retVal = default(T);

            switch (typeof(T).GetTypeInfo().Attributes.GetTypeCode())
            {

                case TypeCode.Empty:
                    break;

                case TypeCode.Object:
                    {
                        retVal = (T)(object)chunk;
                        break;
                    }
                case TypeCode.DBNull:
                    {
                        retVal = (T)(object)null;
                        break;
                    }
                case TypeCode.Boolean:
                    {
                        retVal = bool.TryParse(chunk, out bool outvar) ? (T)(object)outvar : default(T);
                        break;
                    }
                case TypeCode.Char:
                    {
                        retVal = char.TryParse(chunk, out char outvar) ? (T)(object)outvar : default(T);
                        break;
                    }
                case TypeCode.SByte:
                    {
                        retVal = sbyte.TryParse(chunk, out sbyte outvar) ? (T)(object)outvar : default(T);
                        break;
                    }
                case TypeCode.Byte:
                    {
                        retVal = byte.TryParse(chunk, out byte outvar) ? (T)(object)outvar : default(T);
                        break;
                    }
                case TypeCode.Int16:
                    {
                        retVal = Int16.TryParse(chunk, out Int16 outvar) ? (T)(object)outvar : default(T);
                        break;
                    }
                case TypeCode.UInt16:
                    {
                        retVal = UInt16.TryParse(chunk, out UInt16 outvar) ? (T)(object)outvar : default(T);
                        break;
                    }
                case TypeCode.Int32:
                    {
                        retVal = int.TryParse(chunk, out int outvar) ? (T)(object)outvar : default(T);
                        break;
                    }
                case TypeCode.UInt32:
                    {
                        retVal = uint.TryParse(chunk, out uint outvar) ? (T)(object)outvar : default(T);
                        break;
                    }
                case TypeCode.Int64:
                    {
                        retVal = long.TryParse(chunk, out long outvar) ? (T)(object)outvar : default(T);
                        break;
                    }
                case TypeCode.UInt64:
                    {
                        retVal = ulong.TryParse(chunk, out ulong outvar) ? (T)(object)outvar : default(T);
                        break;
                    }
                case TypeCode.Single:
                    {
                        retVal = Single.TryParse(chunk, out Single outvar) ? (T)(object)outvar : default(T);
                        break;
                    }
                case TypeCode.Double:
                    {
                        retVal = double.TryParse(chunk, out double outvar) ? (T)(object)outvar : default(T);
                        break;
                    }
                case TypeCode.Decimal:
                    {
                        retVal = decimal.TryParse(chunk, out decimal outvar) ? (T)(object)outvar : default(T);
                        break;
                    }
                case TypeCode.DateTime:
                    {
                        retVal = DateTime.TryParse(chunk, out DateTime outvar) ? (T)(object)outvar : default(T);
                        break;
                    }
                case TypeCode.String:
                    {
                        retVal = (T)(object)chunk;
                        break;
                    }
                default:
                    retVal = default(T);
                    break;


            }
            return retVal;


        }

        public static void AddMap<T>(this T mapObject, Expression<Func<T, MapProperty>> mapexpression)
        {


        }

    }
}
