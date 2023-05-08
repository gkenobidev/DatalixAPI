namespace DatalixAPI.Enums
{
    public enum Status
    {
        Stopping,
        Shutdown,
        Starting,
        Running,
        Stopped,
        Installing,
        Error,

        AwaítingDeployment,

        CreatingBackup,
        RestoringBackup,

        PlannedBackup,
        PlannedRestore,
    }
}
