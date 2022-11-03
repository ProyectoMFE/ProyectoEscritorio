using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    internal class Utils
    {
        public static void parse<T>(object sourceObject, ref T destObject)
        {
            // if eiter the source, or destination is null, return
            if (sourceObject == null || destObject == null)
                return;

            // Get the type of each object
            Type sourceType = sourceObject.GetType();
            Type targetType = destObject.GetType();

            // Loop through the source properties
            foreach (PropertyInfo p in sourceType.GetProperties())
            {
                // Get the matching property in the destination object
                PropertyInfo targetObj = targetType.GetProperty(p.Name);
                // If there is none, skip
                
                if (targetObj == null)
                    continue;

                // Set the value in the destination
                targetObj.SetValue(destObject, p.GetValue(sourceObject, null), null);
            }
        }
    }
}
