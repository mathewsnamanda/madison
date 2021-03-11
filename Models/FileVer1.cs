using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace public_link.Models.models
{
    public class FileVer
    {
        
        public int ID { get; set; }
        public int Version { get; set; }
        public int FileVersionType { get; set; }
         public string ExpirationTime { get; set; }
         public string Description { get; set; }
    }
}
