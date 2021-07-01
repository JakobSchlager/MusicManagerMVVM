using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManagerContextLib
{
    public class Artist
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public ICollection<Record> Records { get; set; }

        public override string ToString() => ArtistName; 

    }
}
