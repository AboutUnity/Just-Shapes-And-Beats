using System;
using System.Reflection;

namespace YNL.Extension.Method
{
    public static class MUtilities
    {
        /// <summary>
        /// Invoke an method via it's name.
        /// </summary>
        public static void Invoke(this string typeName, string methodname, object obj, object[] paramters)
        {
            Type type = Type.GetType(typeName);
            
            if (type.IsNull())
            {
                MDebug.Error("Type name is not correct!");
                return;
            }

            MethodInfo methodInfo = type.GetMethod(methodname);

            if (!methodInfo.IsNull()) methodInfo.Invoke(obj, paramters);
            else MDebug.Error("Method name is not correct");
        }
    }
}