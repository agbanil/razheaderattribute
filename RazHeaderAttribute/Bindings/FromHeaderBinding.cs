using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace RazHeaderAttribute.Bindings
{
    public class FromHeaderBinding : HttpParameterBinding
    {
        private string name;

        public FromHeaderBinding(HttpParameterDescriptor parameter, string headerKey) : base(parameter)
        {
            // If a header key wasn't passed, assume the parameter name :)
            this.name = string.IsNullOrEmpty(headerKey) ? parameter.ParameterName : headerKey;
        }

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            IEnumerable<string> values;
            if (actionContext.Request.Headers.TryGetValues(this.name, out values))
            {
                actionContext.ActionArguments[this.Descriptor.ParameterName] = Convert.ChangeType(values.FirstOrDefault(), this.Descriptor.ParameterType);
            }
            else
            {
                actionContext.ActionArguments[this.Descriptor.ParameterName] = Convert.ChangeType(0, this.Descriptor.ParameterType);
            }

            var taskSource = new TaskCompletionSource<object>();
            taskSource.SetResult(null);
            return taskSource.Task;
        }
    }
}
