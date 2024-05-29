using Avalonia.Notification;

namespace MISMedicalCardMobile1.ViewModels;

public interface INotificationService
{
    public void Show(string Title, string Message);
}