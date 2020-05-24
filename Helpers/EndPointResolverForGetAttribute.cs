using System;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Primitives;

namespace GMartWebServices.Helpers
{
    
    ///<summary>Provides Custom Attribute to select actionmethod based on querystringParameter</summary>

    //allow multiple times use of attribute over actionmethod
    [AttributeUsage(AttributeTargets.Method,AllowMultiple=true)]
    public class EndPointResolverForGetAttribute : ActionMethodSelectorAttribute
    {
        string _valueName;
        bool _valuePresent;
        public EndPointResolverForGetAttribute(string valueName,bool valuePresent)
        {
            this._valueName=valueName;
            this._valuePresent=valuePresent;
        }

        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            //get the value for field(e.g.Comapnyname or id) in querystring
            var value=routeContext.HttpContext.Request.Query[this._valueName];
            if(_valuePresent)
            {
                return !StringValues.IsNullOrEmpty(value);//send true:validateRequest for action,enable action
            }
           return StringValues.IsNullOrEmpty(value);//send false,disable action
        }
    }
}