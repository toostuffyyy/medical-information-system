namespace MISEmployeeDesktop.Entities;

public static class DoctorId
{
    private static int _id;
    public static int Id
    {
        get => _id;
        set => _id = value;
    }
}