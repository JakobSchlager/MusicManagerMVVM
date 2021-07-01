using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicManager;
using MusicManagerContextLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicManager
{
    public class Startup
    {
        internal void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            string connectionString = configuration.GetConnectionString("Persons");
            services.AddDbContext<MusicManagerContext>(x => x.UseSqlServer("Persons"));
            services.AddSingleton<MainWindow>(); 
        }
    }
}
