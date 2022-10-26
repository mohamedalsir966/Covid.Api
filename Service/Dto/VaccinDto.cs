using Service.Dto.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class VaccinDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TotalNumOfDose { get; set; }
    }
    public class VaccinModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

}
