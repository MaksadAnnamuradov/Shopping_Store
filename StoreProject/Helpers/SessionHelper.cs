using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using StoreProject.Data;
using System.Collections.Generic;

namespace StoreProject.Helpers
{
    public static class SessionHelper
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static List<LineItem> GetObjectFromJson(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (value == null)
            {
                return new List<LineItem>();
            }
            return JsonConvert.DeserializeObject<List<LineItem>>(value);
        }
    }
}