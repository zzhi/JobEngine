using Quartz;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobs
{
    [DisallowConcurrentExecution]
    public class TestJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {

            Log.Information(DateTime.Now.ToString());
            return Task.FromResult(0);
        }
            
    }
}
