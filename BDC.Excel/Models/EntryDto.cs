using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BDC.Excel.Models
{
    public class EntryDto
    {
        [Key]
        public string Id { get; set; }
        public string Location { get; set; }
        public string ATMName { get; set; }
        public string Branch { get; set; }
        public string SerialNumber { get; set; }
        public string Governorate { get; set; }
        public string OffSiteOrBranch { get; set; }
        public string ATMType { get; set; }
        public string CDBNA { get; set; }
        public string ATMClass { get; set; }
        public string CIT { get; set; }
        public string Port { get; set; }
        public string Model { get; set; }
        public string GPSLocation { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string StartDate { get; set; }
        public string NeedPermission { get; set; }
        public string Comment { get; set; }
        public string AvailabilityForCustomer { get; set; }
    }
}
