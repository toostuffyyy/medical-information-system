using System.Threading.Tasks;
using MISPharmacy.Models;
using Refit;

namespace MISPharmacy.Service;

public interface IDistributionRepository
{
    [Get("/Distribution/GetDistribution")]
    public Task GetDistribution();

    [Put("/Distribution/UpdateDistribution")]
    public Task UpdateDistribution(Distribution distribution);
}