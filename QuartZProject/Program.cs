using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispachingService;

namespace QuartZProject
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
				{ 

				}
				{
					DispachingManager.Init().GetAwaiter().GetResult();
				}				
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
			Console.Read();
        }
    }
}
