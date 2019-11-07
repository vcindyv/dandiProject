using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Microsoft.Samples.Kinect.BodyBasics
{
    /// <summary>
    /// DiaryChoicePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DiaryChoicePage : Page
    {
        public DiaryChoicePage()
        {
            InitializeComponent();
        }

        private void Btn_training_choice_Click(object sender, RoutedEventArgs e)
        {
            //전역변수
            FitInfo.fit_name = "나비운동";
            NavigationService.Navigate(new Uri("DiaryPage.xaml", UriKind.Relative));
        }

        private void Btn_training2_choice_Click(object sender, RoutedEventArgs e)
        {
            //전역변수 
            FitInfo.fit_name = "다리운동";
            NavigationService.Navigate(new Uri("DiaryPage.xaml", UriKind.Relative));
        }

        private void Btn_training3_choice_Click(object sender, RoutedEventArgs e)
        {
            //전역변수
            FitInfo.fit_name = "옆구리운동";
            NavigationService.Navigate(new Uri("DiaryPage.xaml", UriKind.Relative));
        }

        private void Btn_training4_choice_Click(object sender, RoutedEventArgs e)
        {
            //전역변수
            FitInfo.fit_name = "발레스쿼트";
            NavigationService.Navigate(new Uri("DiaryPage.xaml", UriKind.Relative));
        }

        private void Btn_training5_choice_Click(object sender, RoutedEventArgs e)
        {
            //전역변수
            FitInfo.fit_name = "꽃게운동";
            NavigationService.Navigate(new Uri("DiaryPage.xaml", UriKind.Relative));
        }

        private void Btn_training6_choice_Click(object sender, RoutedEventArgs e)
        {
            //전역변수
            FitInfo.fit_name = "PT체조";
            NavigationService.Navigate(new Uri("DiaryPage.xaml", UriKind.Relative));
        }

        private void Btn_goto_home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("HomePage.xaml", UriKind.Relative));
        }
    }
}
