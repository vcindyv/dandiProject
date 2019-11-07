using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Microsoft.Samples.Kinect.BodyBasics
{
    /// <summary>
    /// Feedback.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Feedback : Page
    {
        public Feedback(int max1,int max2,int max3,int final_average)
        {
            InitializeComponent();
            String[] feedback_comment = new String[10];

            feedback_comment[0] = "얼굴과 목 사이]" + Session.sessionID + "님 고개에 집중하시면 정확도가 향상될거에요^^!";
            feedback_comment[1] = "왼쪽 어깨와 팔꿈치 사이]" + Session.sessionID + "님 왼쪽 어깨에 집중하시면 정확도가 향상될거에요^^!";
            feedback_comment[2] = "오른쪽 어깨와 팔꿈치 사이]" + Session.sessionID + "님 오른쪽 어깨에 집중하시면 정확도가 향상될거에요^^!";
            feedback_comment[3] = "왼쪽 손목과 팔꿈치 사이] " + Session.sessionID + "님 왼쪽 팔꿈치에 집중하시면 정확도가 향상될거에요^^!";
            feedback_comment[4] = "오른쪽 손목과 팔꿈치 사이] " + Session.sessionID + "님 오른쪽 팔꿈치에 집중하시면 정확도가 향상될거에요^^!";
            feedback_comment[5] = "목과 척추 사이] " + Session.sessionID + "님 등과 척추에 집중하시면 정확도가 향상될거에요^^!";
            feedback_comment[6] = "왼쪽 골반과 왼쪽 무릎 사이 ] " + Session.sessionID + "님 왼쪽 허벅지에 집중하시면 정확도가 향상될거에요^^!";
            feedback_comment[7] = "오른쪽 골반과 오른쪽 무릎 사이 ] " + Session.sessionID + "님 오른쪽 허벅지에 집중하시면 정확도가 향상될거에요^^!";
            feedback_comment[8] = "왼쪽 무릎과 왼쪽 발목 사이] " + Session.sessionID + "님 왼쪽 아랫 다리에 집중하시면 정확도가 향상될거에요^^!";
            feedback_comment[9] = "오른쪽 무릎과 오른쪽 발목 사이] " + Session.sessionID + "님 오른쪽 아랫 다리에 집중하시면 정확도가 향상될거에요^^!";

            max1_ui.Text = "[Top1 :" + feedback_comment[max1];
            max2_ui.Text = "[Top2 :" + feedback_comment[max2];
            max3_ui.Text = "[Top3 :" + feedback_comment[max3];

            total_average_ui.Text = final_average.ToString() + "%";
        }

        private void goToTrainingChoice_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FitInfoPage());
        }

        private void goToDiary_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DiaryPage());
        }
    }
}
