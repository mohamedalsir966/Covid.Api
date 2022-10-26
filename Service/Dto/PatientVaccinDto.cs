using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class PatientVaccinDto
    {
        public Guid PatientId { get; set; }
        public Guid VaccinId { get; set; }
        public int DoseNum { get; set; }
    }
}
