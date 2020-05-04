using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMVC2
{
    public static class SpringApplication
    {
        private static IApplicationContext Context { get; set; }

        public static bool Contains(string objectName)
        {
            SpringApplication.EnsureContext();
            return SpringApplication.Context.ContainsObject(objectName);
        }

        public static object Resolve(string objectName)
        {
            SpringApplication.EnsureContext();
            return SpringApplication.Context.GetObject(objectName);
        }

        public static T Resolve<T>(string objectName)
        {
            return (T)SpringApplication.Resolve(objectName);
        }
        private static void EnsureContext()
        {
            if (SpringApplication.Context == null)
            {
                SpringApplication.Context = ContextRegistry.GetContext();
            }
        }

    }
}