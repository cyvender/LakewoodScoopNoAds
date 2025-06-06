using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LakewoodScoopNoAds.Data;

public class LakewoodScoopDataContextFactory : IDesignTimeDbContextFactory<LakewoodScoopDataContext>
{
    public LakewoodScoopDataContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
           .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), 
           $"..{Path.DirectorySeparatorChar}LakewoodScoopNoAds.Web"))
           .AddJsonFile("appsettings.json")
           .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true).Build();

        return new LakewoodScoopDataContext(config.GetConnectionString("ConStr"));
    }
}