using FootballWorld.Data;
using FootballWorld.Services;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.Unity.Mvc;
using System;
using System.Collections.Generic;
using log4net;

namespace FootballWorld.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();

            container.AddNewExtension<Interception>();

            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            container.RegisterType<ApplicationDbContext>(new PerRequestLifetimeManager());

            container.RegisterType<ArticleService>(new Interceptor<VirtualMethodInterceptor>(), new InterceptionBehavior<LoggingInterceptionBehavior>());
        }
    }

    class LoggingInterceptionBehavior : IInterceptionBehavior
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LoggingInterceptionBehavior));

        public IMethodReturn Invoke(IMethodInvocation input,
          GetNextInterceptionBehaviorDelegate getNext)
        {
            // Before invoking the method on the original target.
            log.Debug(String.Format("<<<{0}: Invoking method {1}", input.MethodBase.DeclaringType.Name, input.MethodBase));

            // Invoke the next behavior in the chain.
            var result = getNext()(input, getNext);

            // After invoking the method on the original target.
            if (result.Exception != null)
            {
                log.Error(String.Format("<<<{0}: Method {1} threw exception {2}", input.MethodBase.DeclaringType.Name, input.MethodBase, result.Exception.Message));
            }
            else
            {
                log.Debug(String.Format("<<<{0}: Method {1} returned {2}", input.MethodBase.DeclaringType.Name, input.MethodBase, result.ReturnValue));
            }

            return result;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}