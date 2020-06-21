using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLib;
using DITest;
using NLog;
using SimpleInjector;

namespace DITest
{
    public static class FactoryMaker
    {
        public static IFactory Create()
        {
            return new FactoryClass();
        }
    }

    class FactoryClass : IFactory
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public FactoryClass()
        {
            try
            {
                m_Collection.Register<IDITestClass, DITestClass>(Lifestyle.Singleton);
                m_Collection.Register<IDITestClass2, DITestClass2>(Lifestyle.Singleton);
                m_Collection.Register<IDITestClass2_Type2, DITestClass2>(Lifestyle.Singleton);
                m_Collection.Register<IFactory>(() => this, Lifestyle.Singleton);
                m_Collection.Verify();
            }
            catch (Exception e)
            {
                Logger.Warn(e.ToString);
                throw;
            }
        }

        private readonly Container m_Collection = new Container();

        public void CreateInstance(out IDITestClass diTestClass)
        {
            diTestClass = m_Collection.GetInstance<IDITestClass>();
        }

        public TType GetInstanceWithDI<TType>() where TType : class
        {
            return m_Collection.GetInstance<TType>();
        }

        public void TestCallFactory()
        {
            Logger.Info($"{nameof(TestCallFactory)}");
        }
    }
}
