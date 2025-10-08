
using System.Text.RegularExpressions;

namespace overcome_Routing.customeRoutingConstarint
{
    public class MonthNumircConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey,
            RouteValueDictionary values, RouteDirection routeDirection)
        {

            if (!values.ContainsKey(routeKey))
            {
                return false;
            }


            string Pattern = "0[1-9]|1[012]";
            Regex MonthRegex = new Regex(Pattern);

            string? RouteValue = Convert.ToString(values[routeKey]);

            if(string.IsNullOrEmpty(RouteValue)) return false;

            return MonthRegex.IsMatch(RouteValue);
        }
    }
}
