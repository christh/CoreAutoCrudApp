using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CoreAutoCrudApp.Data.Contexts;
using CoreAutoCrudApp.Data.Models;

namespace CoreAutoCrudApp.Data.Repositories
{
    public class SeedData
    {
        public static void Initialize()
        {
            using (var context = new AssetContext())
            {

                // Safety check in case DB doesn't exist, e.g. during first run of the program
                // There is no elegant means of testing for table existence in SQlite (2020-03-17)
                try
                {
                    context.Assets.Count();
                }
                catch (Exception)
                {
                    // If thrown then assets table doesn't exist... Re-run the DB migrations
                    try
                    {
                        context.Database.Migrate();
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }

                // Look for any assets - if so then DB has already been seeded
                if (context.Assets.Any())
                {
                    return;   
                }

                // We need to import the CSV data
                var csvFile = Resources.AssetImport;

                byte[] byteArray = Encoding.UTF8.GetBytes(csvFile);
                MemoryStream stream = new MemoryStream(byteArray);

                IEnumerable<Asset> records;
                using (var reader = new StreamReader(stream))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Configuration.RegisterClassMap<AssetMap>();
                        records = csv.GetRecords<Asset>();
                        context.AddRange(records);
                        context.SaveChanges();
                    }
                }
                
            }
        }
    }
}
