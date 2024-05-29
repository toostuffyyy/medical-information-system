using System.Threading.Tasks;
using MISEmployeeDesktop.Models;
using Refit;

namespace MISEmployeeDesktop;

public interface IPersonalLocationRepository
{
    [Get("/PersonLocations")] 
    public Task<ResponceRersonalLocation> GetPersonalLocation();
}