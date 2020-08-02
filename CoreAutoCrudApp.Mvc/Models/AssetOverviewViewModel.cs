using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CoreAutoCrudApp.Mvc.Models
{
    public class AssetOverviewViewModel
    {
        [ReadOnly(true)] 
        public Guid AssetId { get; set; }
        public string FileName { get; set; }
        [ReadOnly(true)] 
        public DateTime? CreatedOn { get; set; }
    }
}
