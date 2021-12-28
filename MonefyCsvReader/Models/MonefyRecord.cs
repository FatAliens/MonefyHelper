using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace MonefyCsvReader.Models
{
    internal class MonefyRecord
    {
        [Name("date")]
        public string Date { get; set; }

        [Name("account")]
        public string Account { get; set; }

        [Name("category")]
        public string Category { get; set; }

        [Name("amount")]
        public string Amount { get; set; }

        [Name("currency")]
        public string Currency { get; set; }

        [Name("converted amount")]
        public string ConvertedAmount { get; set; }

        [Name("currency")]
        public string ConvertedCurrency { get; set; }

        [Name("description")]
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Date}\n{Account}\n{Category}\n{Amount}\n{Currency}\n{ConvertedAmount}\n{ConvertedCurrency}\n{Description}";
        }
    }
}
