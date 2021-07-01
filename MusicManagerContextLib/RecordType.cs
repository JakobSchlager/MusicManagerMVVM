using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManagerContextLib
{
    public class RecordType
    {
        public int Id { get; set; }
        public string Descr { get; set; }
        public ICollection<Record> Records { get; set; }
    }
}
