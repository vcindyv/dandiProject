using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Net.Http;
using System.Net.Http.Headers;
using LiveCharts.Wpf;
using LiveCharts;

namespace Microsoft.Samples.Kinect.BodyBasics
{
    /// <summary>
    /// DiaryPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DiaryPage : Page
    {
        //로컬 DB서버 직접 접근 방식
        /*
        string db_info = @"Server=localhost;Database=dandidb;Uid=dandi;Pwd=passwd;"; //DB 연결 정보
        MySqlConnection mysql_connection;
        */
        
        HttpClient client = new HttpClient();
        FitRecordsCollection _fit_records = new FitRecordsCollection();

        public List<int> accuracy_list = new List<int>();
        public List<string> label_list = new List<string>();

        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }

        public DiaryPage()
        {
            InitializeComponent();

            //client 정보 설정 및 데이터 타입 json 설정
            client.BaseAddress = new Uri("http://testdandi.iptime.org/dandi/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            ShowChart();
        }

        private void Btn_goto_home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("HomePage.xaml", UriKind.Relative));
        }

        private async void ShowChart()
        {
            LineSeries lineSeries = new LineSeries();
            lineSeries.Title = "정확도";
            lineSeries.LineSmoothness = 0;
            lineSeries.PointGeometry = null;

            try
            {
                var response = await client.GetAsync("fit/rest/list");
                response.EnsureSuccessStatusCode(); //오류 코드를 던짐
                var fit_records = await response.Content.ReadAsAsync<IEnumerable<FitRecord>>();
                IEnumerator<FitRecord> iterator = fit_records.GetEnumerator();

                while (iterator.MoveNext())
                {
                    string fit_name = iterator.Current.fit_name;
                    string user_id = iterator.Current.user_id;

                    //접속한 유저의 해당 운동 데이터만 그래프에 포함
                    if (fit_name.Equals(FitInfo.fit_name) && user_id.Equals(Session.sessionID))
                    {
                        string fit_date = iterator.Current.fit_date;
                        int fit_accuracy = iterator.Current.fit_accuracy;

                        label_list.Add(iterator.Current.fit_date);
                        accuracy_list.Add(iterator.Current.fit_accuracy);
                    }
                }

                Labels = label_list;
                lineSeries.Values = new ChartValues<int>(accuracy_list);
                SeriesCollection = new SeriesCollection { };
                SeriesCollection.Add(lineSeries);
            }
            catch (Newtonsoft.Json.JsonException jEx)
            {
                MessageBox.Show(jEx.Message);
            }

            DataContext = this;
        }
    }

    //로컬DB서버 직접 접근 방식
    /*
    private void ShowChart()
    {
        try
        {
            using (mysql_connection = new MySqlConnection(db_info))
            {
                mysql_connection.Open();

                if(mysql_connection.State == ConnectionState.Open)
                {
                    string sql_read = "select * from fit_record";
                    MySqlCommand cmd_read = new MySqlCommand(sql_read, mysql_connection);
                    MySqlDataReader datareader = cmd_read.ExecuteReader();

                    while (datareader.Read())
                    {
                        string fit_date = datareader[2].ToString();
                        int fit_accuracy = int.Parse(datareader[3].ToString());
                        valueList.Add(new KeyValuePair<string, int>(fit_date, fit_accuracy));
                    }
                    datareader.Close();
                }
                mysql_connection.Close();
            }
            xLineChart.DataContext = valueList;
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    */

}

class FitRecord
{
    public string user_id { get; set; }
    public string fit_name { get; set; }
    public string fit_date { get; set; }
    public int fit_accuracy { get; set; }
}

class FitRecordsCollection : ObservableCollection<FitRecord>
{
    public void CopyFrom(IEnumerable<FitRecord> fit_records)
    {
        this.Items.Clear();

        foreach (var fit_record in fit_records)
        {
            this.Items.Add(fit_record);
            
        }

        this.OnCollectionChanged(
        new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }
}
