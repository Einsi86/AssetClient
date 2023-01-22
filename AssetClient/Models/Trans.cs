using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetClient.Models
{
    public class Trans
    {
        public int TransactionId { get; set; }
        public DateTime Created { get; set; }
        public int AssetId { get; set; }
        public string Comment { get; set; }
    }
}
