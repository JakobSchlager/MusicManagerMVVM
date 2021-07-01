using MusicManagerContextLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MusicManagerContext db; 
       
        public MainWindow(MusicManagerContext db)
        {
            InitializeComponent();
            this.db = db;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                db.Database.EnsureDeleted(); 
                db.Database.EnsureCreated();
                DbSeeder dbSeeder = new DbSeeder(db);
                dbSeeder.Seed();

                this.DataContext = new MusicManagerViewModel(db);

                int nr = db.ArtistSet.Count();
                Title = $"{nr} Artists";
                // db.Dispose();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.StackTrace.ToString());
            }
        }

      
    }
    
}
