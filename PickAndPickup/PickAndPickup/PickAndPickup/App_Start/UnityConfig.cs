using DAL.Contracts;
using DAL.Repos;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace PickAndPickup
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IUserRepo, UserRepo>();
            container.RegisterType<IMealRepo, MealRepo>();
            container.RegisterType<IOrderRepo, OrderRepo>();
            container.RegisterType<IOrderProductRepo, OrderProductRepo>();
        }
    }
}