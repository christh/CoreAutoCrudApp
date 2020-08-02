using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreAutoCrudApp.Data.Models
{
    public class Asset
    {
        public Guid AssetId { get; set; }
        [Required]
        public string MimeType { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Description { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedOn { get; set; }
    }
}
