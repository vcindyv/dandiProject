using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Microsoft.Samples.Kinect.BodyBasics
{
    /// <summary>
    /// HomePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void btn_goto_training1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("ChoicePage.xaml", UriKind.Relative));
        }

        private void btn_goto_diary1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("DiaryChoicePage.xaml", UriKind.Relative));
        }

        private void btn_goto_login1_Click(object sender, RoutedEventArgs e)
        {
            if (Session.sessionID == null)
                NavigationService.Navigate(new Uri("LoginPage.xaml", UriKind.Relative));
            else
                MessageBox.Show(Session.sessionID + " 님 로그인 중입니다. > ㅅ <");
        }

        private void btn_goto_home1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("HomePage.xaml", UriKind.Relative));
        }
    }
}
