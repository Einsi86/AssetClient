using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetClient.Models
{
    public class Asset
    {
        public int assetId { get; set; }
        public string description { get; set; }
        public string longDescription { get; set; }
        public int AssetTypeId { get; set; }
        public int StatusId { get; set; }
        public int UserId { get; set; }
        public string AssetType { get; set; }
        public string Status { get; set; }
        public string User { get; set; }
    }
}
