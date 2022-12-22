using System;
using System.IO;
using System.Xml.Serialization;

namespace Exercise1
{
    public interface IDataReader<T> where T : class
    {
        public bool TryRead(object from, out T result);
    }

    public class XmlReader<T> : IDataReader<T> where T : class
    {
        public bool TryRead(object from, out T result)
        {
            result = default;
            try
            {
                XmlSerializer xmlSerializer = new(typeof(T));

                using (FileStream fs = new(from as string, FileMode.Open))
                    if (xmlSerializer.Deserialize(fs) is T res)
                    {
                        result = res;
                        return true;
                    }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
