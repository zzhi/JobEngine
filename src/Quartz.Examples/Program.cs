#region License

/* 
 * Copyright 2009- Marko Lahma
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not 
 * use this file except in compliance with the License. You may obtain a copy 
 * of the License at 
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0 
 *   
 * Unless required by applicable law or agreed to in writing, software 
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT 
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
 * License for the specific language governing permissions and limitations 
 * under the License.
 * 
 */

#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

using Quartz.Logging;
#if LOG4NET
using log4net.Config;
#endif
using Quartz.Util;

namespace Quartz.Examples
{
    /// <summary>
    /// Console main runner.
    /// </summary>
    /// <author>Marko Lahma</author>
    public class Program
    {
#if NETCORE
        public static void Main()
#else
        [STAThread]
        public static void Main()
#endif
        {
            try
            {
#if LOG4NET
                XmlConfigurator.Configure();
#else
                Logging.LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());
#endif

                //Assembly asm = typeof(Program).GetTypeInfo().Assembly;
                //Type[] types = asm.GetTypes();

                //IDictionary<int, Type> typeMap = new Dictionary<int, Type>();
                //int counter = 1;

                //Console.WriteLine("Select example to run: ");
                //List<Type> typeList = new List<Type>();
                //foreach (Type t in types)
                //{
                //    if (new List<Type>(t.GetInterfaces()).Contains(typeof(IExample)))
                //    {
                //        typeList.Add(t);
                //    }
                //}

                //// sort for easier readability
                //typeList.Sort(new TypeNameComparer());

                //foreach (Type t in typeList)
                //{
                //    string counterString = $"[{counter}]".PadRight(4);
                //    Console.WriteLine("{0} {1} {2}", counterString, t.Namespace.Substring(t.Namespace.LastIndexOf(".") + 1), t.Name);
                //    typeMap.Add(counter++, t);
                //}

                //Console.WriteLine();
                //Console.Write("> ");
                //int num = Convert.ToInt32(Console.ReadLine());
                //Type eType = typeMap[num];
                IExample example = ObjectUtils.InstantiateType<IExample>(typeof(Example15.XmlConfigurationExample));

                example.Run().Wait();
                Console.WriteLine("Example run successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error running example: " + ex.Message);
                Console.WriteLine(ex.ToString());
            }
            Console.Read();
        }

        public class ConsoleLogProvider : ILogProvider
        {
            public Logger GetLogger(string name)
            {
                return Log;
            }

            private static bool Log(LogLevel logLevel, Func<string> messageFunc, Exception exception, object[] formatparameters)
            {
                var message = messageFunc == null ? string.Empty : messageFunc();
                if (string.IsNullOrEmpty(message))
                {
                    return true;
                }
                Console.WriteLine("[" + DateTime.Now.ToString(CultureInfo.InvariantCulture) + "] " + message, formatparameters);

                return true;
            }

            public IDisposable OpenNestedContext(string message)
            {
                return null;
            }

            public IDisposable OpenMappedContext(string key, string value)
            {
                return null;
            }
        }

        public class TypeNameComparer : IComparer<Type>
        {
            public int Compare(Type t1, Type t2)
            {
                if (t1.Namespace.Length > t2.Namespace.Length)
                {
                    return 1;
                }

                if (t1.Namespace.Length < t2.Namespace.Length)
                {
                    return -1;
                }

                return t1.Namespace.CompareTo(t2.Namespace);
            }
        }
    }
}