using System.Threading.Tasks;
using MISPharmacy.Models;
using Refit;

namespace MISPharmacy.Service;

public interface IStorageRepository
{
    [Get("/Storage/GetStorage")]
    public Task GetStorage();
}