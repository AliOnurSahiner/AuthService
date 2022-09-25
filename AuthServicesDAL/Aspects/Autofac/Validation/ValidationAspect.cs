using AuthServicesDAL.CrossCuttingConcerns.Validation;
using AuthServicesDAL.Utilities.Interceptors;
using Castle.DynamicProxy;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServicesDAL.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
       private readonly Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Gönderilen ValidationType Hatalı");
            }
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {

            var validator = (IValidator)Activator.CreateInstance(_validatorType); //LoginValidator Newlendi. Reflection Yöntemi ile
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //LoginValidator'daki LoginRequest'i okuduk.
            var entities = invocation.Arguments.Where(x => x.GetType() == entityType);//AuthManager'de Login methodunun parametrelerini oku!
            foreach (var item in entities)
            {
                if (validator != null)
                {
                    ValidationTool.Validate(validator, item);
                }

            }
        }

    }
}
