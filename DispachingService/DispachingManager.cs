using DispachingService.CustomJob;
using DispachingService.CustomListener;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispachingService
{
    public class DispachingManager
    {
        public static async Task Init()
        {
            #region 创建单元（时间轴/载体）
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            await scheduler.Start();
            #endregion

            scheduler.ListenerManager.AddJobListener(new CustomJobListener());

            #region 作业描述
            IJobDetail jobDetail = JobBuilder.Create<SendMessageJob>()
                                                .WithIdentity("sendMessageJob","group1")
                                                .WithDescription("this is Send Message Job")
                                                .Build();
            jobDetail.JobDataMap.Add("student1", "Azu");
            jobDetail.JobDataMap.Add("student2", "Ben");
            jobDetail.JobDataMap.Add("student3", "Cucci");
            jobDetail.JobDataMap.Add("Year", 2020);
            #endregion

            #region 时间策略
            ITrigger trigger = TriggerBuilder.Create()
                                             .WithIdentity("sendMessageTrigger", "group1")
                                             //.StartNow()
                                             //.WithSimpleSchedule(w=>w.WithIntervalInSeconds(5).WithRepeatCount(1000))
                                             .WithCronSchedule("5/10 * * * * ?")
                                             .Build();
            //trigger.JobDataMap.Add("student1", "Azu");
            //trigger.JobDataMap.Add("student2", "Ben");
            //trigger.JobDataMap.Add("student3", "Cucci");
            //trigger.JobDataMap.Add("Year", 2020);
            #endregion

            IJobDetail sayHiDetail = JobBuilder.Create<SayHiJob>()
                                     .WithIdentity("sayHiJobDetail", "group1")
                                     .WithDescription("this is sayHiJobDetail job")
                                     .Build();
            //把时间策略和作业承载到单元上
            await scheduler.ScheduleJob(sayHiDetail, trigger); 
        }
    }
}
