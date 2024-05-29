using System;
using System.IO;
using Android.Media;
using Stream = System.IO.Stream;

namespace MISMedicalCardMobile1.Service;

public class SoundService : ISoundService, IDisposable
{
    private readonly Lazy<MediaRecorder> _audioRecord;
    private string _path;

    public SoundService()
    {
        _audioRecord = new(() => new MediaRecorder());
    }
    public void StartRecord(string fileName)
    {
        /*_path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/" + fileName;
        _audioRecord.Value.SetAudioSource(AudioSource.Mic);
        _audioRecord.Value.SetOutputFormat(OutputFormat.ThreeGpp);
        _audioRecord.Value.SetAudioEncoder(AudioEncoder.AmrNb);
        _audioRecord.Value.SetOutputFile(_path);
        _audioRecord.Value.Prepare();
        _audioRecord.Value.Start();*/
    }

    public Stream StopRecord()
    {
        /*_audioRecord.Value.Stop();
        _audioRecord.Value.Reset();*/
        return new FileStream(_path, FileMode.Open, FileAccess.Read);
    }
    
    public void Dispose()
    {
        _audioRecord.Value.Reset();    
    }
}