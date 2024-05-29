using System.Threading.Tasks;
using MISPharmacy.Models;
using Refit;

namespace MISPharmacy.Service;

public interface IPartyRepository
{
    [Post("/Party/AddParty")]
    public Task AddParty(Party party);
    [Put("/Party/MovingStorage")]
    public Task AddParty(int oldId, int newId, int amount);
}