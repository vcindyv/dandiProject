using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Microsoft.Samples.Kinect.BodyBasics
{
    /// <summary>
    /// FitInfoPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FitInfoPage : Page
    {
        HttpClient client = new HttpClient();
        FitInfosCollection _fit_infos = new FitInfosCollection();
        Uri media_src ;

        public FitInfoPage()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://testdandi.iptime.org/dandi/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            ShowFitInfo();
        }

        private void btn_goto_training_Click(object sender, RoutedEventArgs e)
        {
             int set = Convert.ToInt32(set_num.Text);
            NavigationService.Navigate(new TrainingPage(set,media_src));
        }

        private void btn_goto_choice_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChoicePage());
        }

        //운동 영상과 설명 서버에서 가져와서 보여줌
        private async void ShowFitInfo()
        {
            try
            {
                var response = await client.GetAsync("fitinfo/rest/list");
                response.EnsureSuccessStatusCode(); //오류 코드를 던짐

                Fit_Info fit_info = new Fit_Info();
                var fit_infos = await response.Content.ReadAsAsync<IEnumerable<Fit_Info>>();

                IEnumerator<Fit_Info> iterator = fit_infos.GetEnumerator();

                while (iterator.MoveNext())
                {
                    fit_info.fit_name = iterator.Current.fit_name;

                    //해당 운동의 영상과 설명만 변수에 저장
                    if (fit_info.fit_name.Equals(FitInfo.fit_name))
                    {
                        fit_info.fit_description = iterator.Current.fit_description;
                        fit_info.fit_resource = iterator.Current.fit_resource;
                        break;
                    }
                }

                FitInfoText.Inlines.Add("운동이름: " + fit_info.fit_name + "\n\n");
                FitInfoText.Inlines.Add("운동설명: " + fit_info.fit_description);

                FitInfoMedia.Source = new Uri(client.BaseAddress + "resources/" + fit_info.fit_resource, UriKind.Absolute);
                media_src = FitInfoMedia.Source;
                FitInfoMedia.Play();

                //미디어 종료시 이벤트 발생(반복 재생)
                FitInfoMedia.MediaEnded += new RoutedEventHandler(RepeatPlayMedia);
            }
            catch (Newtonsoft.Json.JsonException jEx)
            {
                MessageBox.Show(jEx.Message);
                NavigationService.Navigate(new ChoicePage());
            }
        }

        //운동 영상 반복 재생을 위한 미디어 종료 이벤트 핸들러
        private void RepeatPlayMedia(object sender, RoutedEventArgs e)
        {
            FitInfoMedia.Stop();
            FitInfoMedia.Play();
        }
    }
}

// 운동 정보를 담을 데이터 클래스
class Fit_Info
{
    public string fit_name { get; set; }
    public string fit_core1 { get; set; }
    public string fit_core2 { get; set; }
    public string fit_core3 { get; set; }
    public string fit_resource { get; set; }
    public string fit_description { get; set; }
}

// 운동 정보 리스트를 관리 하기 위한 컬렉션
class FitInfosCollection : ObservableCollection<Fit_Info>
{
    public void CopyFrom(IEnumerable<Fit_Info> fit_infos)
    {
        this.Items.Clear();

        foreach (var fit_info in fit_infos)
        {
            this.Items.Add(fit_info);

        }

        this.OnCollectionChanged(
        new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }


}
