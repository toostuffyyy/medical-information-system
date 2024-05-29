using Avalonia.Controls.Notifications;
using Notification = System.Reactive.Notification;

namespace MISPharmacy.Service;

public interface INotificationService
{
    public void Registration(INotificationManager manager);
    public void Show(INotification notification);
}