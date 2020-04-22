using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispachingService.CustomJob
{
    public class SayHiJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("***********************");
                Console.WriteLine("My name is Vansor");
                Console.WriteLine("***********************");
            });
        }
    }
}
