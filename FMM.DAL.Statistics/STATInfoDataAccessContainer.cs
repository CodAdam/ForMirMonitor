using System;
using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace FMM.DAL.Statistics
{

        public class STATInfoDataAccessContainer
        {
            private static STATInfoDataAccessContainer _instance;
            private string configFile = "";
            private string _ContainerName = "ContainerDataAccess";
            static readonly object lockobj = new object();
            private static IUnityContainer statInfoDataAccessContainer;


            /// <summary>
            /// 构造函数，得到Unity配置文件
            /// </summary>
            private STATInfoDataAccessContainer()
            {
                configFile = "Config\\Unity\\Unity.DAL.STAT.config";

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
            public static STATInfoDataAccessContainer Instance
            {
                get
                {
                    lock (lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new STATInfoDataAccessContainer();
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
                    if (statInfoDataAccessContainer == null)
                    {
                    statInfoDataAccessContainer = new UnityContainer();
                        ExeConfigurationFileMap basicFileMap = new ExeConfigurationFileMap
                        {
                            ExeConfigFilename = configFile
                        };
                        UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager
                            .OpenMappedExeConfiguration(basicFileMap, ConfigurationUserLevel.None)
                            .GetSection("unity");
                        section.Configure(statInfoDataAccessContainer, _ContainerName);
                    }
                    return statInfoDataAccessContainer;
                }
            }

        }
    }

