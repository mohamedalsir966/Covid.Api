using Domain.Entities;
using Domain.Entities.Enum;
using Service.Dto.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class PatientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public Gender Gender { get; set; }
        public bool IsVaccinated { get; set; }
        public  List<VaccinModel> Vaccin { get; set; }
      
    }
  
}
