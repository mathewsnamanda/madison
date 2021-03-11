using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mfiles.Models
{
    public class File
    {
        public string Name { get; set; }
        public string EscapedName { get; set; }
        public string Extension { get; set; }
        public int Size { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime ChangeTimeUtc { get; set; }
        public DateTime ChangeTime { get; set; }
        public DateTime CreatedUtc { get; set; }
        public string CreatedDisplayValue { get; set; }
        public string LastModifiedDisplayValue { get; set; }
        public string FileGUID { get; set; }
        public int ID { get; set; }
        public int Version { get; set; }
        public int FileVersionType { get; set; }
    }
}
