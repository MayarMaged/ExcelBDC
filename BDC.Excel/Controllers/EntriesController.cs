using BDC.Excel.Models;
using BDC.Excel.Services;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BDC.Excel.Controllers
{
    [ApiController]
    [Route("BDC")]
    public class EntriesController : ControllerBase
    {
        private readonly IBDCEntryRepo _ibdcentryrepo;

        public EntriesController(IBDCEntryRepo ibdcentryrepo)
        {
            _ibdcentryrepo = ibdcentryrepo;
        }
        [HttpGet("fromExcel")]
        public void ImportDataFromExcel()
        {
            //provide file path
            FileInfo existingFile = new FileInfo(@"C:\Users\Mayar\Downloads\bdc update English version.xlsx");
            //use EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                //get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int colCount = worksheet.Dimension.End.Column;  //get Column Count
                int rowCount = worksheet.Dimension.End.Row;     //get row count
                for (int row = 2; row <= rowCount; row++)
                {
                    // for each row initiate an excel entry 
                    EntryDto entry = new EntryDto();
                    List<string> TempEntry = new List<string>();
                    for (int col = 1; col <= colCount; col++)
                    {
                        TempEntry.Add(worksheet.Cells[row, col].Value?.ToString().Trim());
                    }
                    entry.Id = TempEntry[0];
                    entry.Location = TempEntry[1];
                    entry.ATMName = TempEntry[2];
                    entry.Branch = TempEntry[3];
                    entry.SerialNumber = TempEntry[4];
                    entry.Governorate = TempEntry[5];
                    entry.OffSiteOrBranch = TempEntry[6];
                    entry.ATMType = TempEntry[7];
                    entry.CDBNA = TempEntry[8];
                    entry.ATMClass = TempEntry[9];
                    entry.CIT = TempEntry[10];
                    entry.Port = TempEntry[11];
                    entry.Model = TempEntry[12];
                    entry.GPSLocation = TempEntry[13];
                    entry.StartDate = TempEntry[14];
                    entry.NeedPermission = TempEntry[15];
                    entry.Comment = TempEntry[16];
                    entry.AvailabilityForCustomer = TempEntry[17];
                    _ibdcentryrepo.Add(entry);
                }

            }
            _ibdcentryrepo.SplitLocation();
        }

        //[HttpGet("SplitColumns")]
        //public void SplitLocationColumn()
        //{
        //    _ibdcentryrepo.SplitLocation();
        //}

        //[HttpGet("Nearest10Locations")]
        //public List<string> GetNearestTenLocations(string coordinates)
        //{

        //}
        
    }
}
