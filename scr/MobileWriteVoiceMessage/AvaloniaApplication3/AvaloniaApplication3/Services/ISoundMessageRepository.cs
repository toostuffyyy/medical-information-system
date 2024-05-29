using System.Threading.Tasks;
using Refit;

namespace AvaloniaApplication3.Services;

public interface ISoundMessageRepository
{
    [Multipart]
    [Post("/SoundMessage/AddSoundMessage")]
    public Task AddSoundMessage([AliasAs("formFile")]StreamPart file);
}