namespace MailDownloader.Logic
{
    public enum State
    {
        Blocked,
        Requesting,
        Accepted,
        Downloading,
        Stopped
    }
}
