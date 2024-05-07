using SuperSocket.ProtoBase;
using SuperSocket.Server;
using SuperSocket.Server.Abstractions;
using SuperSocket.Server.Host;
using SuperSocketAot;

await SuperSocketHostBuilder.Create<StringPackageInfo, CommandLinePipelineFilter>()
    .ConfigureSuperSocket(server =>
    {
        server.AddListener(new ListenOptions
        {
            BackLog = 512,
            Ip = "Any",
            Port = 8050
        });
    })
    .UseSessionHandler(onConnected: session =>
    {
        Console.WriteLine("a session connectioned {0}", session.SessionID);
        return ValueTask.CompletedTask;
    })
    .UsePackageHandler(packageHandler: (session, packages) =>
    {
        Console.WriteLine(packages.Key);
        return ValueTask.CompletedTask;
    })
    .RunConsoleAsync();