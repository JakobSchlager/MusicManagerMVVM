using MusicManagerContextLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MusicManager
{
    public class DbSeeder
    {
        private readonly MusicManagerContext db;

        public DbSeeder(MusicManagerContext db) => this.db = db;


        public void Seed()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            string dataDirectory = Path.GetDirectoryName(location);
            string fullPath = Path.Combine(dataDirectory, "musicDbData.csv");

            //int iterator = 1;

            //string currentRecordTitle = ""; 
            //int trackNoIterator = 1;


            /*Dictionary<RecordType, List<Record>> recordTypeDict = new Dictionary<RecordType, List<Record>>();

            Dictionary<Record, List<Song>> recordDict = new Dictionary<Record, List<Song>>();
            Dictionary<Artist, List<Record>> artistDict = new Dictionary<Artist, List<Record>>(); 
            */

            List<Artist> artists = new List<Artist>();
            List<Record> records = new List<Record>();
            List<RecordType> recordTypes = new List<RecordType>();
            List<Song> songs = new List<Song>();

            File.ReadAllLines(fullPath)
                    .Skip(1)
                    .ToList()
                    .ForEach(x =>
                    {

                        Artist artist = new Artist
                        {
                            ArtistName = x.Split(";")[0].Replace("'", "").Replace("\"", "")
                        };
                        if (artists.Find(x => x.ArtistName.Equals(artist.ArtistName)) == null) artists.Add(artist);


                        RecordType recordType = new RecordType
                        {
                            Descr = x.Split(";")[2]
                        };
                        if (recordTypes.Find(x => x.Descr.Equals(recordType.Descr)) == null) recordTypes.Add(recordType);

                        Record record;
                        if (x.Split(";")[3] != "0")
                        {
                            record = new Record
                            {
                                Artist = artist,
                                RecordTime = DateTime.ParseExact(x.Split(";")[3], "yyyy", System.Globalization.CultureInfo.InvariantCulture),
                                RecordTitle = x.Split(";")[1],
                                RecordType = recordType
                            };
                        }
                        else
                        {
                            record = new Record
                            {
                                Artist = artist,
                                RecordTitle = x.Split(";")[1],
                                RecordType = recordType
                            };
                        }

                        if (records.Find(x => x.RecordTitle.Equals(record.RecordTitle)) == null) records.Add(record);

                        Song song = new Song
                        {
                            Record = record,
                            SongTitle = x.Split(";")[4],
                        };
                        if (songs.Find(x => x.SongTitle.Equals(song.SongTitle)) == null) songs.Add(song);


                        /*List<Record> records = artistDict[artist];
                        records.Add(record);
                        artistDict.Add(artist, records);

                        List<Song> songs = recordDict[record]; 
                        songs.Add(song)
                        */

                    });

            records.ForEach(x => x.Songs = songs.Where(x1 => x1.Record.RecordTitle == x.RecordTitle).ToList());
            artists.ForEach(x => x.Records = records.Where(x1 => x1.Artist.ArtistName == x.ArtistName).ToList());

            recordTypes.ForEach(x => x.Records = records.Where(x1 => x1.RecordType.Descr == x.Descr).ToList());

            artists.ForEach(x => db.ArtistSet.Add(x));
            songs.ForEach(x => db.SongSet.Add(x)); 
            db.SaveChanges();

        }

    }
}
