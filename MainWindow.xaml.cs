using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Threading.Tasks;
using System.Threading;

namespace HttpStableTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 次数选择标志
        /// </summary>
        int TimesSelected = 50;

     //   int SleepTime

        public MainWindow()
        {
            InitializeComponent();
        }

        #region //UI逻辑

        private void CustomTimes_Checked(object sender, RoutedEventArgs e)
        {
            CustomTimesValue.IsEnabled = true;
            TimesSelected = -1;
        }

        private void CustomTimes_Unchecked(object sender, RoutedEventArgs e)
        {
            CustomTimesValue.IsEnabled = false;
        }

        private void ByPost_Checked(object sender, RoutedEventArgs e)
        {
            RequestParams.IsEnabled = true;
        }

        private void ByGet_Checked(object sender, RoutedEventArgs e)
        {
            if (RequestParams != null)
                RequestParams.IsEnabled = false;
        }

        private void NormalTimes_Checked(object sender, RoutedEventArgs e)
        {
            TimesSelected = 50;
        }

        private void MediumTimes_Checked(object sender, RoutedEventArgs e)
        {
            TimesSelected = 500;
        }

        private void HighTimes_Checked(object sender, RoutedEventArgs e)
        {
            TimesSelected = 5000;
        }

        private void VeryHighTimes_Checked(object sender, RoutedEventArgs e)
        {
            TimesSelected = 50000;
        }

        #endregion

        #region //请求线程相关

        Thread T0, T1, T2, T3;
        private bool CreateThreads(int SleepSpan = 0, int OutOfTimeValue = 30000)
        {
            if (TimesSelected == -1)
            {
                if (!int.TryParse(CustomTimesValue.Text, out TimesSelected))
                {
                    MessageBox.Show("请求次数格式错误！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            } 
            
            if (string.IsNullOrEmpty(RequestURL.Text))
            {
                MessageBox.Show("请求地址不能为空！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            string Method = "GET";
            if (ByPost.IsChecked == true)
            {
                Method = "POST";
            }
            string Url = RequestURL.Text;
            string Params = RequestParams.Text;
            T0 = new Thread(() =>
                {
                    for (int i = 0; i < TimesSelected; i++)
                    {
                        WPFRequest Request = new WPFRequest(Url, Method, OutOfTimeValue);
                        Request.PostParams(Params);
                        Request.DoRequest();
                        if (Request.ResultState == false)
                        {
                            Dispatcher.BeginInvoke((Action)delegate()
                                {
                                    Result_0.Text += string.Format("<#{0} Request Failed!>\n", i);
                                    Result_0.ScrollToEnd();
                                });
                        }
                        else
                        {
                            Dispatcher.BeginInvoke((Action)delegate()
                            {
                                Result_0.Text += string.Format("<#{0} Request 200!>\n", i);
                                Result_0.ScrollToEnd();
                            });
                        }
                        Thread.Sleep(SleepSpan);
                    }
                    Dispatcher.BeginInvoke((Action)delegate()
                    {
                        T0_S.Text = "停止";
                        StartRequest.IsEnabled = true;
                        ThreadAmount.IsEnabled = true;
                        SleepTimeValue.IsEnabled = true;
                        NormalTimes.IsEnabled = true;
                        MediumTimes.IsEnabled = true;
                        HighTimes.IsEnabled = true;
                        VeryHighTimes.IsEnabled = true;
                        RequestURL.IsEnabled = true;
                        if (ByPost.IsChecked == true)
                            RequestParams.IsEnabled = true;
                    });
                });
            T1 = new Thread(() =>
            {
                for (int i = 0; i < TimesSelected; i++)
                {
                    WPFRequest Request = new WPFRequest(Url, Method, OutOfTimeValue);
                    Request.PostParams(Params);
                    Request.DoRequest();
                    if (Request.ResultState == false)
                    {
                        Dispatcher.BeginInvoke((Action)delegate()
                        {
                            Result_1.Text += string.Format("<#{0} Request Failed!>\n", i);
                            Result_1.ScrollToEnd();
                        });
                    }
                    else
                    {
                        Dispatcher.BeginInvoke((Action)delegate()
                        {
                            Result_1.Text += string.Format("<#{0} Request 200!>\n", i);
                            Result_1.ScrollToEnd();
                        });
                    }
                    Thread.Sleep(SleepSpan);
                }
                Dispatcher.BeginInvoke((Action)delegate()
                {
                    T1_S.Text = "停止";
                    StartRequest.IsEnabled = true;
                    ThreadAmount.IsEnabled = true;
                    SleepTimeValue.IsEnabled = true;
                    NormalTimes.IsEnabled = true;
                    MediumTimes.IsEnabled = true;
                    HighTimes.IsEnabled = true;
                    VeryHighTimes.IsEnabled = true;
                    RequestURL.IsEnabled = true;
                    if (ByPost.IsChecked == true)
                        RequestParams.IsEnabled = true;
                });
            });
            T2 = new Thread(() =>
            {
                for (int i = 0; i < TimesSelected; i++)
                {
                    WPFRequest Request = new WPFRequest(Url, Method, OutOfTimeValue);
                    Request.PostParams(Params);
                    Request.DoRequest();
                    if (Request.ResultState == false)
                    {
                        Dispatcher.BeginInvoke((Action)delegate()
                        {
                            Result_2.Text += string.Format("<#{0} Request Failed!>\n", i);
                            Result_2.ScrollToEnd();
                        });
                    }
                    else
                    {
                        Dispatcher.BeginInvoke((Action)delegate()
                        {
                            Result_2.Text += string.Format("<#{0} Request 200!>\n", i);
                            Result_2.ScrollToEnd();
                        });
                    }
                    Thread.Sleep(SleepSpan);
                }
                Dispatcher.BeginInvoke((Action)delegate()
                {
                    T2_S.Text = "停止";
                    StartRequest.IsEnabled = true;
                    ThreadAmount.IsEnabled = true;
                    SleepTimeValue.IsEnabled = true;
                    NormalTimes.IsEnabled = true;
                    MediumTimes.IsEnabled = true;
                    HighTimes.IsEnabled = true;
                    VeryHighTimes.IsEnabled = true;
                    RequestURL.IsEnabled = true;
                    if (ByPost.IsChecked == true)
                        RequestParams.IsEnabled = true;
                });
            });
            T3 = new Thread(() =>
            {
                for (int i = 0; i < TimesSelected; i++)
                {
                    WPFRequest Request = new WPFRequest(Url, Method, OutOfTimeValue);
                    Request.PostParams(Params);
                    Request.DoRequest();
                    if (Request.ResultState == false)
                    {
                        Dispatcher.BeginInvoke((Action)delegate()
                        {
                            Result_3.Text += string.Format("<#{0} Request Failed!>\n", i);
                            Result_3.ScrollToEnd();
                        });
                    }
                    else
                    {
                        Dispatcher.BeginInvoke((Action)delegate()
                        {
                            Result_3.Text += string.Format("<#{0} Request 200!>\n", i);
                            Result_3.ScrollToEnd();
                        });
                    }
                    Thread.Sleep(SleepSpan);
                }
                Dispatcher.BeginInvoke((Action)delegate()
                {
                    T3_S.Text = "停止";
                    StartRequest.IsEnabled = true;
                    ThreadAmount.IsEnabled = true;
                    SleepTimeValue.IsEnabled = true;
                    NormalTimes.IsEnabled = true;
                    MediumTimes.IsEnabled = true;
                    HighTimes.IsEnabled = true;
                    VeryHighTimes.IsEnabled = true;
                    RequestURL.IsEnabled = true;
                    if (ByPost.IsChecked == true)
                        RequestParams.IsEnabled = true;
                });
            });
            return true;
        }

        #endregion

        private void StartRequest_Click(object sender, RoutedEventArgs e)
        {
            Result_0.Text = "";
            Result_1.Text = "";
            Result_2.Text = "";
            Result_3.Text = "";
            int Time = 0;
            int OutOfTime = 30000;
            bool CreateSuccess = false;
            if (int.TryParse(SleepTimeValue.Text, out Time) && int.TryParse(OutOfTimeValue.Text, out OutOfTime))
            {
                CreateSuccess = CreateThreads(Time, OutOfTime * 1000);
            }
            else
            {
                CreateSuccess = CreateThreads();
            }
            if (CreateSuccess == false)
            {
                MessageBox.Show("创建测试任务失败！","错误",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            int Amount = 3;
            if (!int.TryParse(ThreadAmount.SelectedIndex.ToString(), out Amount))
            {
                Amount = 3;
            }

            if (Amount >= 0)
            {
                T0.Start();
                T0_S.Text = "运行";
            }
            if (Amount >= 1)
            {
                T1.Start();
                T1_S.Text = "运行";
            }
            if (Amount >= 2)
            {
                T2.Start();
                T2_S.Text = "运行";
            }
            if (Amount >= 3)
            {
                T3.Start();
                T3_S.Text = "运行";
            }
            ThreadAmount.IsEnabled = false;
            StartRequest.IsEnabled = false;
            SleepTimeValue.IsEnabled = false;
            NormalTimes.IsEnabled = false;
            MediumTimes.IsEnabled = false;
            HighTimes.IsEnabled = false;
            VeryHighTimes.IsEnabled = false;
            RequestURL.IsEnabled = false;
            RequestParams.IsEnabled = false;
        }

        private void BreakRequest_Click(object sender, RoutedEventArgs e)
        {
            if (T0 != null)
            {
                T0.Abort();
                T0_S.Text = "停止";
            }
            if (T1 != null)
            {
                T1.Abort();
                T1_S.Text = "停止";
            }
            if (T2 != null)
            {
                T2.Abort();
                T2_S.Text = "停止";
            }
            if (T3 != null)
            {
                T3.Abort();
                T3_S.Text = "停止";
            }
            StartRequest.IsEnabled = true;
            ThreadAmount.IsEnabled = true;
            SleepTimeValue.IsEnabled = true;
            NormalTimes.IsEnabled = true;
            MediumTimes.IsEnabled = true;
            HighTimes.IsEnabled = true;
            VeryHighTimes.IsEnabled = true;
            RequestURL.IsEnabled = true;
            if (ByPost.IsChecked == true)
                RequestParams.IsEnabled = true;
        }

    }
}
