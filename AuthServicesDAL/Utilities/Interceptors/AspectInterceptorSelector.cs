using Castle.DynamicProxy;
using System.Reflection;
using System.Collections;

namespace AuthServicesDAL.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAtrributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes =type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);  //Add GetList Login gibi methodlar
            classAtrributes.AddRange(methodAttributes);
            return classAtrributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
