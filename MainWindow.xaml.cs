using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_4
{

    public partial class MainWindow : Window
    {
        Left left { get; set; } = new Left();
        Right right { get; set; }=new Right();

        public MainWindow()
        {
            InitializeComponent();
            this.Resources.Add("Left", left);
            LeftTextBlock.SetResourceReference(TextBlock.DataContextProperty, "Left");
            RightTextBlock.DataContext = right;
            left.thread.Start();
            left.StartTimer();
            right.thread.Start();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            right.Work = false;
        }
    }
}