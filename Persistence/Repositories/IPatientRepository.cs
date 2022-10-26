using Domain.Entities;
using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient> GetPatientByIdQuery(Guid? id);
        Task<Patient> DeletePatientByIdCommand(Patient patient);
        Task<Patient> UpdatePatientByIdCommand(Patient patient);
        Task<Patient> CreateNewPatientCommand(Patient patient);
        Task<PagedList<Patient>> GetAllPatientsQuery(QueryStringParameters queryString);
    }
}
