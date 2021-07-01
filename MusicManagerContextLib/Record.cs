using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManagerContextLib
{
    public class Record
    {
        public int Id { get; set; }
        public string RecordTitle { get; set; }
        public DateTime RecordTime { get; set; }
        public int ArtistId { get; set; }
        public int RecordTypeId { get; set; }

        public Artist Artist { get; set; }
        public RecordType RecordType { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
