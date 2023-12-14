using Grpc.Net.Client;
using SimpleGRPC;
using SimpleGRPC.Protos;

namespace AssignmentGRPC
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };

            var grpcChannel = GrpcChannel.ForAddress("https://localhost:7291", new GrpcChannelOptions
            {
                HttpClient = new HttpClient(httpClientHandler)
            });
            //var grpcChannel = GrpcChannel.ForAddress("https://localhost:7291");

            var greeterClient = new Greeter.GreeterClient(grpcChannel);
            var greeterReply = greeterClient.SayHello(new HelloRequest
            {
                Name = "Truong",
            });
            Console.WriteLine(greeterReply.ToString());

            var studentClient = new StudentRPC.StudentRPCClient(grpcChannel);
            var studentReply = studentClient.GetStudentDetail(new GetStudentRequest
            {
                Id = "01",
            });
            Console.WriteLine(studentReply.ToString());
            Console.ReadKey();
        }
    }
}