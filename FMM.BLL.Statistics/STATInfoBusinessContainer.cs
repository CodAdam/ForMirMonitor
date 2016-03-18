using System;
using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace FMM.BLL.Statistics
{
    public class STATInfoBusinessContainer
    {
        private static STATInfoBusinessContainer _instance;
        private string configFile = "";
        private string _ContainerName = "ContainerBusiness";
        static readonly object lockobj = new object();
        private static IUnityContainer statInfoBusinessUnityContainer;


        /// <summary>
        /// 构造函数，得到Unity配置文件
        /// </summary>
        private STATInfoBusinessContainer()
        {
            configFile = "Config\\Unity\\Unity.BLL.STAT.config";

            if (string.IsNullOrEmpty(configFile))
            {
                throw new Exception("配置出错");
            }
            else
            {
                configFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configFile);
            }
        }

        /// <summary>
        ///  单例
        /// </summary>
        public static STATInfoBusinessContainer Instance
        {
            get
            {
                lock (lockobj)
                {
                    if (_instance == null)
                    {
                        _instance = new STATInfoBusinessContainer();
                    }
                    return _instance;
                }
            }
        }

        /// <summary>
        /// 初始化Unity的IoC容器对象
        /// </summary>
        public IUnityContainer Container
        {
            get
            {
                if (statInfoBusinessUnityContainer == null)
                {
                    statInfoBusinessUnityContainer = new UnityContainer();
                    ExeConfigurationFileMap basicFileMap = new ExeConfigurationFileMap
                    {
                        ExeConfigFilename = configFile
                    };
                    UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager
                        .OpenMappedExeConfiguration(basicFileMap, ConfigurationUserLevel.None)
                        .GetSection("unity");
                    section.Configure(statInfoBusinessUnityContainer, _ContainerName);
                }
                return statInfoBusinessUnityContainer;
            }
        }

    }
}

