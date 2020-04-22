using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispachingService.CustomJob
{
    [PersistJobDataAfterExecution]
    public class SendMessageJob : IJob
    {
        /// <summary>
        /// 当前Task内部就是作业要执行的任务
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("**********************");
                var student1 =  context.JobDetail.JobDataMap.GetString("student1");
                var student2 = context.JobDetail.JobDataMap.GetString("student2");
                var student3 = context.JobDetail.JobDataMap.GetString("student3");
                var Year = context.JobDetail.JobDataMap.GetInt("Year");
                Console.WriteLine($"从今天开始用Git记录项目  {DateTime.Now} {student1},{student2},{student3},{Year}");
                Console.WriteLine("**********************");
                context.JobDetail.JobDataMap.Put("Year", Year + 1);
            }); 
        }
    }
}
