using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vaccin: BaseEntity
    {
        public string Name { get; set; }
        public int TotalNumOfDose { get; set; }
    }
}
