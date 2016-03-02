using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Filters.OData
{
    public static class Extensions
    {
        public static T ReadFromQueryString<T>(this T context, HttpRequest request)
            where T : IODataContext
        {
            var queryStringPairs = request.QueryString.Value.Split('&').Select(x => x.Split('=')).Where(x => x.Length == 2).ToDictionary(x => x[0], x => x[1]);

            var top = string.Empty;
            var skip = string.Empty;
            var orderBy = string.Empty;

            queryStringPairs.TryGetValue("top", out top);
            queryStringPairs.TryGetValue("skip", out skip);
            queryStringPairs.TryGetValue("orderBy", out orderBy);

            try
            {
                if (!string.IsNullOrEmpty(top)) context.Top = Convert.ToInt32(top);
                if (!string.IsNullOrEmpty(skip)) context.Skip = Convert.ToInt32(skip);
                if (!string.IsNullOrEmpty(orderBy)) context.OrderBy = orderBy;
            } catch (Exception ex)
            {
                throw new InvalidOperationException($"The format of OData parameters top: {top}, skip: {skip}, orderBy: {orderBy} is incorrect.");
            }

            return context;
        }

    }
}
