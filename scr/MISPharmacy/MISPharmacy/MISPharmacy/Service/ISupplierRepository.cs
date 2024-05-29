using System.Threading.Tasks;
using MISPharmacy.Models;
using Refit;

namespace MISPharmacy.Service;

public interface ISupplierRepository
{
    [Get("/Supplier/GetSupplier")]
    public Task GetSupplier();
}