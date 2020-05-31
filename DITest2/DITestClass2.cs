using System;
using System.Collections.Generic;
using System.Text;
using CommonLib;
using NLog;

namespace DITest
{
    public class DITestClass2 : IDITestClass2, IDITestClass2_Type2
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public IDITestClass _diTestClass { get; set; }

        public DITestClass2()
        {
            Logger.Info($"{nameof(DITestClass2)} Construct");
        }

        public void TestCall()
        {
            Logger.Info($"{nameof(DITestClass2)} TestCall");
        }

        public void TestCallType2()
        {
            Logger.Info($"{nameof(DITestClass2)} TestCallType2");

            _diTestClass.TestCall2();
        }
    }
}
