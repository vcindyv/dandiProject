using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Microsoft.Samples.Kinect.BodyBasics
{
    /// <summary>
    /// ChoicePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ChoicePage : Page
    {
        public ChoicePage()
        {
            InitializeComponent();
        }

        private void Btn_training1_Click(object sender, RoutedEventArgs e)
        {
            FitInfo.fit_name = "나비운동";
            TableInfo.train_xy = "train1_xy_table";
            TableInfo.train_xz = "train1_xz_table";
            TableInfo.preview_src = "/resources/train1.JPG";
            TableInfo.video_src = "resources/train1_after.mp4";
            TableInfo.video_src_real = "resources/du_navi.mp4";
            NavigationService.Navigate(new Uri("FitInfoPage.xaml", UriKind.Relative));

        }

        private void Btn_training2_Click(object sender, RoutedEventArgs e)
        {
            FitInfo.fit_name = "다리운동";
            TableInfo.train_xy = "train2_xy_table";
            TableInfo.train_xz = "train2_xz_table";
            TableInfo.preview_src = "/resources/train2.JPG";
            TableInfo.video_src = "resources/train2_after.mp4";
            TableInfo.video_src_real = "resources/du_leg.mp4";
            NavigationService.Navigate(new Uri("FitInfoPage.xaml", UriKind.Relative));
        }

        private void Btn_training3_Click(object sender, RoutedEventArgs e)
        {
            FitInfo.fit_name = "옆구리운동";
            TableInfo.train_xy = "train3_xy_table";
            TableInfo.train_xz = "train3_xz_table";
            TableInfo.preview_src = "/resources/train3.JPG";
            TableInfo.video_src = "resources/train3_after.mp4";
            TableInfo.video_src_real = "resources/du_velly.mp4";
            NavigationService.Navigate(new Uri("FitInfoPage.xaml", UriKind.Relative));
        }

        private void Btn_training4_Click(object sender, RoutedEventArgs e)
        {
            FitInfo.fit_name = "발레스쿼트";
            TableInfo.train_xy = "train4_xy_table";
            TableInfo.train_xz = "train4_xz_table";
            TableInfo.preview_src = "/resources/train4.JPG";
            TableInfo.video_src = "resources/train4_after.mp4";
            TableInfo.video_src_real ="resources/du_ballet.mp4";
            NavigationService.Navigate(new Uri("FitInfoPage.xaml", UriKind.Relative));
        }

        private void Btn_training5_Click(object sender, RoutedEventArgs e)
        {
            FitInfo.fit_name = "꽃게운동";
            TableInfo.train_xy = "train5_xy_table";
            TableInfo.train_xz = "train5_xz_table";
            TableInfo.preview_src = "/resources/train5.JPG";
            TableInfo.video_src = "resources/train5_after.mp4";
            TableInfo.video_src_real = "resources/du_crab.mp4";
            NavigationService.Navigate(new Uri("FitInfoPage.xaml", UriKind.Relative));
        }

        private void Btn_training6_Click(object sender, RoutedEventArgs e)
        {
            FitInfo.fit_name = "PT체조";
            TableInfo.train_xy = "train6_xy_table";
            TableInfo.train_xz = "train6_xz_table";
            TableInfo.preview_src = "/resources/train6.JPG";
            TableInfo.video_src = "resources/train6_after.mp4";
            TableInfo.video_src_real = "resources/du_pt.mp4";
            NavigationService.Navigate(new Uri("FitInfoPage.xaml", UriKind.Relative));
        }

        private void Btn_goto_home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("HomePage.xaml", UriKind.Relative));
        }
    }
}

class TableInfo
{
    public static string train_xy ;
    public static string train_xz ;
    public static string preview_src;
    public static string video_src;
    public static string video_src_real;

}

class FitInfo
{
    public static string fit_name;
}
