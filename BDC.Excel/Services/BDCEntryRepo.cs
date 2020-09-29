using BDC.Excel.Contexts;
using BDC.Excel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDC.Excel.Services
{
    public class BDCEntryRepo : IBDCEntryRepo
    {
        private readonly BDCContext _bdccontext;

        public BDCEntryRepo(BDCContext bdccontext)
        {
            _bdccontext = bdccontext;
        }

        public void Add(EntryDto e)
        {
            //var s = _bdccontext.ExcelEntries.FirstOrDefault(p => p.Id == e.Id);
            //if (s == null)
            //{
            //    _bdcContext.Add(e);
            //}
            //else
            //{
            //    _bdcContext.Update(e);
            //}
            _bdccontext.Entries.Add(e);
            _bdccontext.SaveChanges();
        }

        public void SplitLocation()
        {
           // var inp =  _bdccontext.Entries.AsQueryable();
           // IQueryable<EntryDto> entries = inp.Select(entry => InsertLatitudeAndLongitudeTwo(entry));
            foreach (EntryDto entry in _bdccontext.Entries)
            {
                string latitude="";
                string longitude="";
                if (entry.GPSLocation.Contains("N"))
                {
                    int index = entry.GPSLocation.IndexOf("N");
                    latitude = entry.GPSLocation.Substring(0, index + 1);
                    longitude = entry.GPSLocation.Substring(index + 1);

                } else if (entry.GPSLocation.Contains(","))
                {
                    int index = entry.GPSLocation.IndexOf(",");
                    latitude = entry.GPSLocation.Substring(0, index);
                    longitude = entry.GPSLocation.Substring(index + 1);
                }
                entry.Latitude = latitude;
                entry.Longitude = longitude;
            }
            _bdccontext.SaveChanges();
        }

        //private double FromDMStoDecimal(string dms, int index)
        //{
        //    if (dms.Contains("'"))
        //    {
        //        char[] spearator = { '°', '\'', '"' };
        //        string[] holder = dms.Split(spearator);
        //        double decimalValue = double.Parse(holder[0]) + double.Parse(holder[1]) / 60 +
        //            double.Parse(holder[2]) / 3600;
        //        return decimalValue;
        //    }
        //}
        private EntryDto InsertLatitudeAndLongitudeTwo(EntryDto entry)
        {
            int index = entry.GPSLocation.IndexOf("N");
            string latitude = entry.GPSLocation.Substring(0, index + 1);
            string longitude = entry.GPSLocation.Substring(index + 1);

            entry.Latitude.Insert(0,latitude);
            entry.Longitude.Insert(0,longitude);
            _bdccontext.SaveChanges();
            return entry;
        }

    }
}
