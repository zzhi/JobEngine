#region License

/* 
 * All content copyright Terracotta, Inc., unless otherwise indicated. All rights reserved. 
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

using System.Collections.Specialized;
using System.Threading.Tasks;

using Quartz.Impl;
using Quartz.Impl.Calendar;
using Quartz.Logging;
using System;
using Quartz;
namespace JobService
{
    /// <summary>
    /// This example will demonstrate how configuration can be
    /// done using an XML file.
    /// </summary>
    /// <author>Marko Lahma (.NET)</author>
    public class SchedulerService
    {
        public string Name => GetType().Name;

        public async Task Run()
        {
            ILog log = LogProvider.GetLogger(typeof (SchedulerService));

            
            var properties = new NameValueCollection
            {
                ["quartz.scheduler.instanceName"] = "XmlConfiguredInstance",
                ["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz",
                ["quartz.threadPool.threadCount"] = "5",
                ["quartz.plugin.xml.type"] = "Quartz.Plugin.Xml.XMLSchedulingDataProcessorPlugin, Quartz",
                ["quartz.plugin.xml.fileNames"] = "~/quartz_jobs.xml",
                ["quartz.serializer.type"] = "json"
            };

            ISchedulerFactory sf = new StdSchedulerFactory(properties);
            IScheduler sched = await sf.GetScheduler();
            await sched.Start();
            
            
        }
    }
}