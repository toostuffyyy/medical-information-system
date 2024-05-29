using System;
using Avalonia.Media;
using Avalonia.Notification;

namespace MISMedicalCardMobile1.ViewModels;

public class NotificationService : INotificationService
{
    public INotificationMessageManager Manager { get; }

    public NotificationService()
    {
        Manager = new NotificationMessageManager();
    }
    public void Show(string Title, string Message)
    {
        this.Manager
            .CreateMessage()
            .Animates(true)
            .Background(Brushes.White)
            .HasBadge(Title)
            .HasMessage(Message)
            .Dismiss().WithDelay(TimeSpan.FromSeconds(5))
            .Queue();
    }
}