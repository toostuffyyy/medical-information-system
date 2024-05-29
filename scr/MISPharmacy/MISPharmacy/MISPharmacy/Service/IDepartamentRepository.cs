using System.Threading.Tasks;
using MISPharmacy.Models;
using Refit;

namespace MISPharmacy.Service;

public interface IDepartamentRepository
{
    [Get("/Departament/GetSupplier")]
    public Task GetSupplier();
}