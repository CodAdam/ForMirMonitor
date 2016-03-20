using System;
using log4net;
using log4net.Config;
using System.IO;

namespace FMM.Common.Log
{
    public class Logger
    {
        static Logger()
        {
            XmlConfigurator.Configure(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config\\log\\log4net.config")));
            ILog Log = LogManager.GetLogger(typeof(Logger));
            Log.Info("系统初始化Logger模块");
        }

        private ILog logger = null;
        private Logger(Type type)
        {
            logger = LogManager.GetLogger(type);
        }

        /// <summary>
        /// 创建Logger
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Logger CreateLogger(Type type)
        {
            return new Logger(type);
        }

        /// <summary>
        /// Log4日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public void Error(string msg = "出现异常", Exception ex = null)
        {
            Console.WriteLine(msg);
            if(logger.IsErrorEnabled)
            logger.Error(msg, ex);
        }

        /// <summary>
        /// Log4日志
        /// </summary>
        /// <param name="msg"></param>
        public void Warn(string msg)
        {
            Console.WriteLine(msg);
            if (logger.IsWarnEnabled)
                logger.Warn(msg);
        }

        /// <summary>
        /// Log4日志
        /// </summary>
        /// <param name="msg"></param>
        public void Info(string msg)
        {
            Console.WriteLine(msg);
            if (logger.IsInfoEnabled)
                logger.Info(msg);
        }

        /// <summary>
        /// Log4日志
        /// </summary>
        /// <param name="msg"></param>
        public void Debug(string msg)
        {
            Console.WriteLine(msg);
            if (logger.IsDebugEnabled)
                logger.Debug(msg);
        }


    }
}
