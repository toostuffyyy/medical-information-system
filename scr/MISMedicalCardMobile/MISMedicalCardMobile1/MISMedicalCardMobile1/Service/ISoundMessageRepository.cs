using System.Threading.Tasks;
using Refit;

namespace MISMedicalCardMobile1.Service;

public interface ISoundMessageRepository
{
    [Multipart]
    [Post("/SoundMessage/AddSoundMessage")]
    public Task AddSoundMessage([AliasAs("formFile")]StreamPart formFile);
}