using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Net;

namespace Microsoft.Samples.Kinect.BodyBasics
{
    /// <summary>
    /// LoginPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginPage : Page
    {
        HttpClient client = new HttpClient();
        UsersCollection _users = new UsersCollection();

        public LoginPage()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://testdandi.iptime.org/dandi/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        private async void Btn_goto_home_Click(object sender, RoutedEventArgs e)
        {
            
            Btn_goto_home.IsEnabled = false;

            try
            {
                var user = new User()
                {
                    user_id = TextBox_id.Text,
                    user_passwd = TextBox_passwd.Password,
                    user_name = null,
                    user_gender = null,
                    user_age = 0,
                    user_height = 0,
                    user_weight = 0,
                    user_phone = null
                };

                var response = await client.PostAsJsonAsync("user/rest/login", user);
                //response.EnsureSuccessStatusCode(); // 오류 코드를 던집니다.
                var status_code = response.StatusCode;

                if (status_code == HttpStatusCode.OK)
                {
                    MessageBox.Show("로 그 인 성 공 ~ >_<");
                    // 세션 관리
                    Session.sessionID = user.user_id;
                    NavigationService.Navigate(new Uri("HomePage.xaml", UriKind.Relative));
                }
                else
                    MessageBox.Show("아이디 혹은 패스워드가 틀립니다. ㅡㅡ");

                _users.Add(user);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Error: 아이디와 패스워드를 올바르게 입력해주세욧.");
            }
            finally
            {
                Btn_goto_home.IsEnabled = true;
            }
            
        }

        private void Btn_goto_join_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("JoinPage.xaml", UriKind.Relative));
        }
    }
}

class Session
{
    public static string sessionID;
}
