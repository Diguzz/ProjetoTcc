using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTccModel
{
    public class files
    {
        private Int32 lastModified = Int32.MinValue;
        private DateTime lastModifiedDate  = DateTime.MinValue;
        private String name   = String.Empty;
        private Int32 size  = Int32.MinValue;
        private String type  = String.Empty;
        private String webkitRelativePath  = String.Empty;

        public int LastModified { get => lastModified; set => lastModified = value; }
        public DateTime LastModifiedDate { get => lastModifiedDate; set => lastModifiedDate = value; }
        public string Name { get => name; set => name = value; }
        public int Size { get => size; set => size = value; }
        public string Type { get => type; set => type = value; }
        public string WebkitRelativePath { get => webkitRelativePath; set => webkitRelativePath = value; }
    }
}
