using Domain.Entities;
using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public interface IPatientVaccinRepository
    {
        Task<PatientVaccin> CreateNewPatientVaccinCommand(PatientVaccin vaccin);
        Task<List<PatientVaccin>> GetAllPatientVaccinQuery();
    }
}
