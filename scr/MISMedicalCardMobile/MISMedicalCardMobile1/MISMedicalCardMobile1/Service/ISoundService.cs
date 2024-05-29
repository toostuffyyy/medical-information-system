using System.IO;

namespace MISMedicalCardMobile1.Service;

public interface ISoundService
{
    public void StartRecord(string fileName);
    public Stream StopRecord();
}