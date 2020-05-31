using System;
using System.Collections.Generic;
using System.Text;
using CommonLib;
using NLog;

namespace DITest
{
    public class DITestClass : IDITestClass
    {
        private IDITestClass2 _diTestClass2;


        public DITestClass(IDITestClass2 diTestClass2, IDITestClass2_Type2 diTestClass2Type2)
        {
            Logger.Info($"{nameof(DITestClass)} Construct Param");

            //相互参照は解決できないので、逆方向については一番上のクラス（最後に生成されるインスタンス）から直接引き渡す
            diTestClass2._diTestClass = this;
            _diTestClass2 = diTestClass2;
            _diTestClass2Type2 = diTestClass2Type2;
        }

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private IDITestClass2_Type2 _diTestClass2Type2;

        public void TestCall()
        {
            Logger.Info($"{nameof(DITestClass)} TestCall");
            _diTestClass2?.TestCall();
            _diTestClass2Type2?.TestCallType2();
        }

        public void TestCall2()
        {
            Logger.Info($"{nameof(DITestClass)} TestCall2");
        }
    }
}
