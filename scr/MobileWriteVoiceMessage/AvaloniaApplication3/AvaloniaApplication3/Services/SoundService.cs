using System;
using System.IO;
using Android.Media;
using Stream = System.IO.Stream;

namespace AvaloniaApplication3.Services;

public class SoundService : ISoundService, IDisposable
{
    private readonly Lazy<MediaRecorder> _audioRecord;
    private string path;
    public SoundService()
    {
        _audioRecord = new (() => new MediaRecorder());
    }

    public void StartRecord(string fileName)
    {
        path =  Android.OS.Environment.ExternalStorageDirectory.AbsolutePath.ToString() + "/" + fileName;
        _audioRecord.Value.SetAudioSource(AudioSource.Mic);
        _audioRecord.Value.SetOutputFormat(OutputFormat.ThreeGpp);
        _audioRecord.Value.SetAudioEncoder(AudioEncoder.AmrNb);
        _audioRecord.Value.SetOutputFile(path);
        _audioRecord.Value.Prepare();
        _audioRecord.Value.Start();
    }
    public Stream StopRecord()
    {
       _audioRecord.Value.Stop();
       _audioRecord.Value.Reset();
       return new FileStream(path, FileMode.Open,FileAccess.Read);
    }
    public void Dispose()
    {
        _audioRecord.Value.Release();
    }
}