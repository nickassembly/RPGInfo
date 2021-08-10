using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Models
{
    public class Setting
    {
        public List<Campaign> Campaigns { get; set; }
        public List<AreasOfInterest> AreasOfInterest { get; set; }

    }
}
