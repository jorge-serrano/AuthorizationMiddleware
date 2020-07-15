using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutorizeCode
{
    public class AuthorizeForProcedure : IActionFilter, IOrderedFilter
    {
        /// <summary>
        /// orden de apliacación del filtro, en caso de que haya varios
        /// </summary>
        public int Order => int.MaxValue - 10;
        /// <summary>
        /// intercepta la salida de cada action (si se desea cambiar la salida
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
        /// <summary>
        /// intercepta las llamadas, antes de llegar a la controladora
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var attributes = context.ActionDescriptor.EndpointMetadata;
            var procedureAttributte = attributes.OfType<ProcedureAttribute>().FirstOrDefault();
            if (procedureAttributte == null)
                return;
            string procedureName = procedureAttributte.Name;
            string actionName = procedureAttributte.Action;

            if(procedureName != "FRMEMP" && actionName != "View")
                context.Result = new ForbidResult("No está Autorizado");
        }
    }
}
