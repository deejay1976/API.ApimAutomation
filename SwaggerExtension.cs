using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
namespace MHR.API.ApimAutomation
{
    public class SwaggerExtensionFilter: IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
         var descriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;           
            if (descriptor != null)
            {
                var controllerName = descriptor.ControllerTypeInfo.Name;
                if (controllerName.ToString().Contains("Address"))
                   operation.Description = "k.jbk.jbb.kjb.kbk.jb.kbkbkjbkbjkjbmn,m ,knkjbkvhkhvkhv";
                if (controllerName.ToString().Contains("Customer"))
                    operation.Description = "Get employee data by specifying a set of fields. This is suitable for getting basic employee information, including current values for fields that are part of a historical table, like job title, or compensation information. See the fields endpoint for a list of possible fields.";
            }
        }
    }
}
