using System.Collections.Generic;
using System.Threading.Tasks;
using MISMedicalCardMobile1.Models;
using Refit;

namespace MISMedicalCardMobile1.Service;

public interface IGenderRepository
{
    [Get("/Gender/GetGender")]
    public Task<List<Gender>> GetGender();
}