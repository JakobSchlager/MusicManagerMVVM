using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManagerContextLib
{
    public class Song
    {
        public int Id { get; set; }
        public string SongTitle { get; set; }
        public int TrackNo { get; set; }
        public int RecordId { get; set; }
        public Record Record { get; set; }
    }
}
