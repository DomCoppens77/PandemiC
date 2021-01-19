namespace PandemiC.Web.Infrastructure
{
    public interface ISessionManager
    {
        SessionUser User { get; set; }
    }
}