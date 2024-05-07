using SuperSocket.Server;
using SuperSocket.Server.Abstractions.Session;

namespace SuperSocketAot;

public sealed class AppSessionFactory : ISessionFactory
{
    public IAppSession Create() => new AppSession();

    public Type SessionType { get; } = typeof(AppSession);
}