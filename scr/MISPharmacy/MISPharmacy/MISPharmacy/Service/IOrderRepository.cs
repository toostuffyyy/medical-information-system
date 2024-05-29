using System.Threading.Tasks;
using MISPharmacy.Models;
using Refit;

namespace MISPharmacy.Service;

public interface IOrderRepository
{
    [Post("/Order/AddOrder")]
    public Task AddOrder(Order order);
}