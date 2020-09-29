using BDC.Excel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDC.Excel.Services
{
    public interface IBDCEntryRepo
    {
        void Add(EntryDto e);
        public void SplitLocation();
    }
}
