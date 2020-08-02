using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAutoCrudApp.Data.Models
{
    // For the purposes of the CsvProcessingTest, we are only interested in the below columns 
    public class CsvProcessingTestMap : ClassMap<Asset>
    {
        public CsvProcessingTestMap()
        {
            Map(m => m.AssetId).Name("asset id");
            Map(m => m.MimeType).Name("mime_type");
            Map(m => m.Country).Name("country");
        }
    }

}
