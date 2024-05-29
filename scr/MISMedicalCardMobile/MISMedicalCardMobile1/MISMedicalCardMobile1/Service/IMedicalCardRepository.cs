using System.Threading.Tasks;
using MISMedicalCardMobile1.Models;
using Refit;

namespace MISMedicalCardMobile1.Service;

public interface IMedicalCardRepository
{
    [Get("/MedicalCard/GetMedicalCart")]
    public Task<MedicalCard> GetMedicalCart([Body] int number);
}