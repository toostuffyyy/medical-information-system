using Avalonia.Controls.Notifications;

namespace MISSheduleEmployee.Service;

public interface INotificationService
{
    public void Registration(INotificationManager manager);
    public void Show(INotification notification);
}