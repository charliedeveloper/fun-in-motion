using FunInMotion.Gif.DataService;
using FunInMotion.Gif.DomainLogic;
using FunInMotion.Gif.Service;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace FunInMotion.Gif.Model
{
    public static class UnityConfig
	{
		public static void RegisterComponents()
		{
			var container = new UnityContainer();


			// register all your components with the container here
			// it is NOT necessary to register your controllers

			// e.g. container.RegisterType<ITestService, TestService>();

			FunInMotionAutoMapperConfiguration.InitializeMapper();

			var serviceContainer = new UnityServiceContainer();
			container = serviceContainer.RegisterServiceContainer();
			container.RegisterType<IUserDomain, UserDomain>();
            container.RegisterType<ICategoryDomain, CategoryDomain>();

            container.RegisterType<IGiphyService, GiphyService>();
            container.RegisterType<IGiphyApi, GiphyApi>();
            container.RegisterType<IImageDomain, ImageDomain>();

            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IImageEfService, ImageEfService>();
            container.RegisterType<ICategoryService, CategoryService>();



            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		}
	}
}