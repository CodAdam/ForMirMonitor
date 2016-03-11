using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace FMM.Service.Statistics
{
    public sealed class STATInfoServiceContainer
    { 
        private static STATInfoServiceContainer _instance;
        private string configFile = "";
        private string _ContainerName = "ContainerService";
        static readonly object lockobj = new object();
        private static IUnityContainer statInfoServiceUnityContainer;


        /// <summary>
        /// 构造函数，得到Unit配置文件
        /// </summary>
        private STATInfoServiceContainer()
        {
            configFile = "";
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
        public static STATInfoServiceContainer Instance {
            get {
                lock (lockobj) {
                    if (_instance == null){
                        _instance = new STATInfoServiceContainer();
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
                if (statInfoServiceUnityContainer == null)
                {
                    statInfoServiceUnityContainer = new UnityContainer();
                    ExeConfigurationFileMap basicFileMap = new ExeConfigurationFileMap
                    {
                        ExeConfigFilename = configFile
                    };
                    UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager
                        .OpenMappedExeConfiguration(basicFileMap, ConfigurationUserLevel.None)
                        .GetSection("unity");
                    section.Configure(statInfoServiceUnityContainer, _ContainerName);
                }
                return statInfoServiceUnityContainer;
            }
        }

    }
}
