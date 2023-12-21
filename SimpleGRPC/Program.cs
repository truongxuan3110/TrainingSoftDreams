using ProtoBuf.Grpc.Server;
using SimpleGRPC.Repository.IRepository;
using SimpleGRPC.Repository;
using SimpleGRPC.Services;

namespace SimpleGRPC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

            builder.Services.AddSingleton<NHibernate.ISessionFactory>(NHibernateConfig.BuildSessionFactory());
            builder.Services.AddSingleton<IClassRepository, ClassRepository>();
            builder.Services.AddSingleton<ITeacherRepository, TeacherRepository>();

            // Add services to the container.
            builder.Services.AddCodeFirstGrpc();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<GreeterService>();
            app.MapGrpcService<ClassService>();
            app.MapGrpcService<TeacherService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}