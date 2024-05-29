using System.Collections.Generic;
using System.Threading.Tasks;
using MISPharmacy.Models;
using Refit;

namespace MISPharmacy.Service;

public interface IMedicationRepository
{
    [Get("/Medication/GetMedication")]
    public Task<List<Medication>> GetMedication();
}