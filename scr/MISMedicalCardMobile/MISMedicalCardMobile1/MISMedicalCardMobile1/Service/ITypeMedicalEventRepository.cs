using System.Collections.Generic;
using System.Threading.Tasks;
using MISMedicalCardMobile1.Models;
using Refit;

namespace MISMedicalCardMobile1.Service;

public interface ITypeMedicalEventRepository
{
    [Get("/TypeMedicalEvent/GetTypeMedicalEvent")]
    public Task<IEnumerable<TypeMedicalEvent>> GetTypeMedicalEvent();
}