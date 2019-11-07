using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Microsoft.Samples.Kinect.BodyBasics
{
    
    /// <summary>
    /// JoinPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class JoinPage : Page
    {
        HttpClient client = new HttpClient();
        UsersCollection _users = new UsersCollection();

        public JoinPage()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://testdandi.iptime.org/dandi/");
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }


        private async void button_Click(object sender, RoutedEventArgs e)
        { //회원 정보 입력하구 난뒤 
            button.IsEnabled = false;

            try
            {
                var user = new User()
                {
                    user_id = userinfo_id.Text,
                    user_passwd = userinfo_pw.Password,
                    user_name = userinfo_name.Text,
                    user_gender = userinfo_gender.Text,
                    user_age = int.Parse(userinfo_age.Text),
                    user_height = int.Parse(userinfo_height.Text),
                    user_weight = int.Parse(userinfo_weight.Text),
                    user_phone = userinfo_contact.Text
                };

                var response = await client.PostAsJsonAsync("user/rest", user);
                //response.EnsureSuccessStatusCode(); // 오류 코드를 던집니다.
                var status_code = response.StatusCode;

                if (status_code == HttpStatusCode.OK)
                    MessageBox.Show("회원가입 완료 되었습니다. >_< 로그인 화면으로 돌아가 주세요");
                else
                    MessageBox.Show("중복된 아이디입니다. ㅡㅡ");

                _users.Add(user);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FormatException)
            {
                MessageBox.Show("Error: 나이, 신장, 체중은 숫자로만 입력하시오.");
            }
            finally
            {
                button.IsEnabled = true;
            }
        }

        private void Btn_goto_login_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("LoginPage.xaml", UriKind.Relative));
        }
    }
}


class User
{
    public string user_id { get; set; }
    public string user_passwd { get; set; }
    public string user_name { get; set; }
    public string user_gender { get; set; }
    public int user_age { get; set; }
    public int user_height { get; set; }
    public int user_weight { get; set; }
    public string user_phone { get; set; }
}

class UsersCollection : ObservableCollection<User>
{
    public void CopyFrom(User users)
    {
        this.Items.Clear();
        this.Items.Add(users);

        this.OnCollectionChanged(
        new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }
}

