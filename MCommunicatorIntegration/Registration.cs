using System.Configuration;
using MCommunicatorIntegration.Interfaces.Repositories;
using MCommunicatorIntegration.Interfaces.Wrappers;
using MCommunicatorIntegration.Repositories;
using MCommunicatorIntegration.Wrappers;
using Unity;

namespace MCommunicatorIntegration
{
    public static class Registration
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ISqlWrapper, SqlWrapper>();
            container.RegisterInstance(typeof(ISqlWrapper), new SqlWrapper(ConfigurationManager.ConnectionStrings["MciConnectionString"].ConnectionString));
            container.RegisterType<IMcAttachmentRepository, McAttachmentRepository>();
        }
    }
}