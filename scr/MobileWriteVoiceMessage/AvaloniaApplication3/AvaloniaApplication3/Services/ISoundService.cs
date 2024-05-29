using System.IO;

namespace AvaloniaApplication3.Services;

public interface ISoundService
{
    public void StartRecord(string fileName);
    public Stream StopRecord();
}