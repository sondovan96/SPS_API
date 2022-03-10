using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Core.Exceptions
{
    public class ResourceNotFoundException : ClientException
    {
        public ResourceNotFoundException()
        {

        }
        public ResourceNotFoundException(string propertyName, object originalValue)
        {
            Erros.Add(new KeyValuePair<string, object>(propertyName, originalValue));
        }
    }
}
