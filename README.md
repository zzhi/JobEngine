# JobEngine
基于quartz.net 的跨平台作业框架

quartz.net(https://github.com/quartznet/quartznet/tree/features/netcore11) 
也支持跨平台了 ，由于NuGet无法安装quartz-DotNetCore dll。

所以我直接把这个解决方案下载下来，删除一些无用的代码，在解决方案上直接创建项目JobServer,
通过添加引用的方式引用quartz-DotNetCore

如何创建新的作业？

1，Jobs项目中创建TestJob.cs ,代码如下：

    [DisallowConcurrentExecution]
    public class TestJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {

            Log.Information(DateTime.Now.ToString());
            return Task.FromResult(0);
        }
            
    }

	TestJob作业仅仅打印当前时间。

2，修改JobService项目的quartz_jobs.xml,如下：

    <job>
      <name>TestJob</name>
      <group>TestJobGroup</group>
      <description>TestJob</description>
      <job-type>Jobs.TestJob, Jobs</job-type>
      <durable>true</durable>
      <recover>false</recover>
    </job>

    <trigger>
      <cron>
        <name>TestJobTrigger</name>
        <group>TestJobTriggerGroup</group>
        <job-name>TestJob</job-name>
        <job-group>TestJobGroup</job-group>
        <cron-expression>0/5 * * * * ?</cron-expression>
      </cron>
    </trigger>


3，重新启动


