using Microsoft.EntityFrameworkCore;
using MusicManagerContextLib;
using MVVM.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManager
{
    public class MusicManagerViewModel : ObservableObject
    {
        private MusicManagerContext db;
        public MusicManagerViewModel()
        { }

        public MusicManagerViewModel(MusicManagerContext db)
        {
            this.db = db;
            Artists = db.ArtistSet.ToList();
            //Songs = db.SongSet.ToList(); 
        }


        public List<Artist> Artists { get; set; } = new();

        public List<Song> songs { get; set; }
        public List<Song> Songs { 
            get => songs;
            set 
            {
                songs = value;

                RaisePropertyChangedEvent(nameof(Songs));
            }
        }

        
        private List<Record> records;
        public List<Record> Records
        {
            get => records; 
                /*records.Select(x => new
                {
                    Jahr = x.RecordTime.Year.ToString(),
                    Titel = x.RecordTitle.ToString(),
                    Typ = x.RecordType.ToString(),
                    Id = x.Id.ToString()
                }).ToList();*/
            set
            {
                records = value;
                RaisePropertyChangedEvent(nameof(Records));
            }
        }

        private Artist selectedArtist;
        public Artist SelectedArtist
        {
            get => selectedArtist;
            set
            {
                selectedArtist = value;
                Records = db.ArtistSet.Include(x => x.Records).Where(x => x.ArtistName.Equals(selectedArtist.ArtistName)).First().Records.ToList();
                RaisePropertyChangedEvent(nameof(SelectedArtist));
            }
        }

        private Record selectedRecord;

        public Record SelectedRecord
        {
            get => selectedRecord; 
            set 
            { 
                selectedRecord = value;
                Songs = db.SongSet.Where(x => x.Record.RecordTitle.Equals(selectedRecord.RecordTitle)).ToList();

                RaisePropertyChangedEvent(nameof(SelectedRecord)); 
            }   
        }

    }
}
