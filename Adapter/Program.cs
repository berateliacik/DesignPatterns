using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new BeLogger());
            productManager.Save();
            Console.ReadLine();
        }
    }

    class ProductManager
    {
        private ILogger _logger;
        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            _logger.Log("User Data");
            Console.WriteLine("saved");
        }
    }

    interface ILogger
    {
        void Log(string message);

    }

    class BeLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("logged, {0}", message);
        }
    }

    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("logged with log4net, {0}", message);
        }
    }

    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);

        }
    }
}
