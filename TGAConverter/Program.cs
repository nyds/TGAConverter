using Autofac;
using TGAConverter.Services;
using TGAConverter.Services.Interfaces;

namespace TGAConverter
{
    public class Program
    {
        static void Main(string[] args)
        {
            CompositionRoot().Resolve<Application.Application>().Run();
        }

        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application.Application>();

            builder.RegisterType<FileService>().As<IFileService>();
            builder.RegisterType<TgaService>().As<ITgaService>();
            builder.RegisterType<JpegService>().As<IJpegService>();

            return builder.Build();
        }
    }
}
