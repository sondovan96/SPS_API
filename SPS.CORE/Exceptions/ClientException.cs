using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Core.Exceptions
{
    public class ClientException : Exception
    {
        public IList<KeyValuePair<string,object>> Erros { get; set; } = new List<KeyValuePair<string,object>>();
        public void Add(string propertyName, object originalValue)
        {
            Erros.Add(new KeyValuePair<string,object>(propertyName,originalValue));
        }
    }
}
