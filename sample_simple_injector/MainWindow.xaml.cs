using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DITest;
using NLog;

namespace sample_dotnetframework_microsoft_di
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private IFactory m_Factory = FactoryMaker.Create();
        private IDITestClass m_MainClass;

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private void OnMainClick(object sender, RoutedEventArgs e)
        {
            //DIの実験
            Logger.Info("Main Start");
            m_Factory.CreateInstance(out m_MainClass);
            m_MainClass.TestCall();


            //DIで生成されたメンバーをリフレクションで操作する実験
            Logger.Info("Main 2");

            var classType2 = m_MainClass.GetType();
            var fieldType2 = classType2.GetFields(BindingFlags.GetField | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).First(d => d.FieldType == typeof(IDITestClass2));
            var inst2 = (IDITestClass2)fieldType2.GetValue(m_MainClass);
            inst2.TestCall();

            Logger.Info("Main End");
        }
    }
}
