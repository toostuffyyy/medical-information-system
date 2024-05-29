using Avalonia.Controls.Notifications;

namespace MISPharmacy.Service;

public class NotificationService : INotificationService
{
    private INotificationManager _manager;
    public void Registration(INotificationManager manager)
    {
        _manager = manager;
    }

    public void Show(INotification notification)
    {
        _manager.Show(notification);
    }
}