//[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Site.App_Start.IocConfig), "Start")]
//[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Site.App_Start.IocConfig), "Stop")]

using Dominio.Contratos.Upload;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Syntax;
using Ninject.Web.Common;
using Repositorio.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.App_Start
{
    public class IocConfig
    {
        #region modo antigo
        //private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        ///// <summary>
        ///// Starts the application
        ///// </summary>
        //public static void Start()
        //{
        //    DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
        //    DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
        //    bootstrapper.Initialize(CreateKernel);
        //}

        ///// <summary>
        ///// Stops the application.
        ///// </summary>
        //public static void Stop()
        //{
        //    bootstrapper.ShutDown();
        //}

        ///// <summary>
        ///// Creates the kernel that will manage your application.
        ///// </summary>
        ///// <returns>The created kernel.</returns>
        //private static IKernel CreateKernel()
        //{
        //    var kernel = new StandardKernel();
        //    try
        //    {
        //        kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
        //        kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

        //        RegisterServices(kernel);
        //        return kernel;
        //    }
        //    catch
        //    {
        //        kernel.Dispose();
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// Load your modules or register your services here!
        ///// </summary>
        ///// <param name="kernel">The kernel.</param>
        //private static void RegisterServices(IKernel kernel)
        //{
        //    //kernel.Bind<IUploadRep>().To<UploadRep>();

        //}
        #endregion

        public static void ConfigurarDependencias()
        {
            //Cria o Container 
            IKernel kernel = new StandardKernel();

            //Instrução para mapear a interface IUploadRep para a classe concreta UploadRep
            kernel.Bind<IUploadFileRep>().To<UploadFileRep>();

            //Registra o container no ASP.NET
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IResolutionRoot _resolutionRoot;

        public NinjectDependencyResolver(IResolutionRoot kernel)
        {
            _resolutionRoot = kernel;
        }

        public object GetService(Type serviceType)
        {
            return _resolutionRoot.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolutionRoot.GetAll(serviceType);
        }
    }
}