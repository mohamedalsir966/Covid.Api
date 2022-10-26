using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PatientVaccin : BaseEntity
    {
        public Guid PatientId { get; set; }
        public Guid VaccinId { get; set; }
        public int DoseNum { get; set; }
        public virtual Vaccin Vaccin { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
