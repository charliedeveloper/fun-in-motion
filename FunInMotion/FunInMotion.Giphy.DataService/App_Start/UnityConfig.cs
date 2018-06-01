using AutoMapper;
using FunInMotion.Gif.EF;
using System.Data.Entity;
using Unity;
using Unity.Lifetime;

namespace FunInMotion.Gif.DataService
{
    public class UnityServiceContainer
	{
		public UnityContainer RegisterServiceContainer()
		{
			var container = new UnityContainer();
			
			//container.RegisterType<IUserService, UserService>();
   //         container.RegisterType<IImageEfService, ImageEfService>();
   //         container.RegisterType<ICategoryService, CategoryService>();
            
            container.RegisterType<DbContext, EF.GifCollectionEntities>(new PerThreadLifetimeManager());

			return container;
		}
	}

	public  static class FunInMotionAutoMapperConfiguration
	{
		public static void InitializeMapper()
		{
			Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<User, Model.User>();
				cfg.CreateMap<Model.User, User>();

				cfg.CreateMap<Model.UserImageModel, EF.Gif>();
				cfg.CreateMap<EF.Gif, Model.UserImageModel>();

                cfg.CreateMap<EF.Category, Model.Category>();
                cfg.CreateMap<Model.Category, EF.Category>();

            });

		}
	}

}