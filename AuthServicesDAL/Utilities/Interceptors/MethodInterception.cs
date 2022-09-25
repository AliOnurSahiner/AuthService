using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServicesDAL.Utilities.Interceptors
{
    public abstract class MethodInterception :MethodInterceptionBaseAttribute  // Bir Metod Nasıl ele alınır burda bunu yaptık Bussinesstan gelen ValidationRule burada işlenecek
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation) { }
        protected virtual void OnSuccess(IInvocation invocation) { } 
        public override void Intercept(IInvocation invocation)
        {
           var  isSuccess = true;

            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception)
            {

                isSuccess = false;
                OnException(invocation);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }



    }
}
