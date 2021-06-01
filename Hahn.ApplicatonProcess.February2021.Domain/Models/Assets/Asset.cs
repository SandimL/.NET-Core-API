using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hahn.ApplicatonProcess.February2021.Domain.Models.Assets
{
    [Table("Asset")]
    public class Asset
    {
        public int ID { get; set; }
        public string AssetName { get; set; }
        public Department Department { get; set; }
        public string CountryOfDepartment { get; set; }
        public string EMailAdressOfDepartment { get; set; }
        public DateTime PurchaseDate { get; set; } //UTC
        public bool broken { get; set; }

        public Asset(int iD, string assetName, Department department, string countryOfDepartment, string eMailAdressOfDepartment, DateTime purchaseDate, bool broken = false)
        {
            ID = iD;
            AssetName = assetName;
            Department = department;
            CountryOfDepartment = countryOfDepartment;
            EMailAdressOfDepartment = eMailAdressOfDepartment;
            PurchaseDate = purchaseDate;
            this.broken = broken;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
