using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using System.Net.Sockets;
using System.Net;

using Microsoft.DirectX;
using Microsoft.DirectX.DirectInput;

using System.IO.Ports;

using AForge.Video;
using AForge.Video.DirectShow;

namespace TwoCamerasTest
{
    public partial class MainForm : Form
    {
        // Список видео устройств
        FilterInfoCollection videoDevices;
        // секундомер для измерения FPS
        private Stopwatch stopWatch = null;

        string adr, welcome;
        byte[] data = new byte[1024];
        string input, stringData;
        UdpClient server;
        IPEndPoint sender_1;
        
        public MainForm()
        {
            InitializeComponent();


            camera1FpsLabel.Text = string.Empty;
            camera2FpsLabel.Text = string.Empty;

            // Список устройств
            try
            {
                // нумерация видеоустройств
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                {
                    throw new Exception();
                }

                for (int i = 1, n = videoDevices.Count; i <= n; i++)
                {
                    string cameraName = i + " : " + videoDevices[i - 1].Name;

                    camera1Combo.Items.Add(cameraName);
                    camera2Combo.Items.Add(cameraName);
                }

                // check cameras count
                if (videoDevices.Count == 1)
                {
                    camera2Combo.Items.Clear();

                    camera2Combo.Items.Add("Only one camera found");
                    camera2Combo.SelectedIndex = 0;
                    camera2Combo.Enabled = false;
                }
                else
                {
                    camera2Combo.SelectedIndex = 1;
                }
                camera1Combo.SelectedIndex = 0;
            }
            catch
            {
                startButton.Enabled = false;

                camera1Combo.Items.Add("No cameras found");
                camera2Combo.Items.Add("No cameras found");

                camera1Combo.SelectedIndex = 0;
                camera2Combo.SelectedIndex = 0;

                camera1Combo.Enabled = false;
                camera2Combo.Enabled = false;
            }
        }

        // On form closing
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCameras();
            //ComPort.Write("0");
        }

        // Запуск камер
        private void startButton_Click(object sender, EventArgs e)
        {
            StartCameras();

            startButton.Enabled = false;
            stopButton.Enabled = true;
        }

        // остановка видео
        private void stopButton_Click(object sender, EventArgs e)
        {
            StopCameras();

            startButton.Enabled = true;
            stopButton.Enabled = false;

            camera1FpsLabel.Text = string.Empty;
            camera2FpsLabel.Text = string.Empty;
        }

        // Start cameras
        private void StartCameras()
        {
            // create first video source
            VideoCaptureDevice videoSource1 = new VideoCaptureDevice(videoDevices[camera1Combo.SelectedIndex].MonikerString);
            videoSource1.DesiredFrameRate = 10;

            videoSourcePlayer1.VideoSource = videoSource1;
            videoSourcePlayer1.Start();

            // create second video source
            if (camera2Combo.Enabled == true)
            {
                System.Threading.Thread.Sleep(500);

                VideoCaptureDevice videoSource2 = new VideoCaptureDevice(videoDevices[camera2Combo.SelectedIndex].MonikerString);
                videoSource2.DesiredFrameRate = 10;

                videoSourcePlayer2.VideoSource = videoSource2;
                videoSourcePlayer2.Start();
            }

            // reset stop watch
            stopWatch = null;
            // start timer
            timer.Start();
        }

        // Stop cameras
        private void StopCameras()
        {
            timer.Stop();

            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer2.SignalToStop();

            videoSourcePlayer1.WaitForStop();
            videoSourcePlayer2.WaitForStop();
        }

        // On times tick - collect statistics
        private void timer_Tick(object sender, EventArgs e)
        {
            IVideoSource videoSource1 = videoSourcePlayer1.VideoSource;
            IVideoSource videoSource2 = videoSourcePlayer2.VideoSource;

            int framesReceived1 = 0;
            int framesReceived2 = 0;

            // get number of frames for the last second
            if (videoSource1 != null)
            {
                framesReceived1 = videoSource1.FramesReceived;
            }

            if (videoSource2 != null)
            {
                framesReceived2 = videoSource2.FramesReceived;
            }

            if (stopWatch == null)
            {
                stopWatch = new Stopwatch();
                stopWatch.Start();
            }
            else
            {
                stopWatch.Stop();

                float fps1 = 1000.0f * framesReceived1 / stopWatch.ElapsedMilliseconds;
                float fps2 = 1000.0f * framesReceived2 / stopWatch.ElapsedMilliseconds;

                camera1FpsLabel.Text = fps1.ToString("F2") + " fps";
                camera2FpsLabel.Text = fps2.ToString("F2") + " fps";

                stopWatch.Reset();
                stopWatch.Start();
            }
        }

                
        private void but_Open_Click(object sender, EventArgs e)
        {
            adr = "192.168.1.2";
            label1.Text = adr;

            server = new UdpClient(adr, 8888);

            sender_1 = new IPEndPoint(IPAddress.Any, 0);

            welcome = "Client connect!";
            label2.Text = welcome;

            //data = Encoding.UTF8.GetBytes(welcome);
            //server.Send(data, data.Length);
            //data = server.Receive(ref sender_1);
            //label3.Text = sender_1.ToString();
            stringData = Encoding.UTF8.GetString(data, 0, data.Length);
            label3.Text = stringData;
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            server.Close();
        }
           

        
        bool[] servo = new bool[12];
        bool[] key = new bool[14];
        private void MainForm_Load(object sender, EventArgs e)
        {
            but_Open.Focus();
            for (int s = 0; s < 12; s++)
            {
                servo[s] = true;
            }
            for (int k = 0; k < 12;k++)
            {
                key[k] = true;
            }
        }

        bool ServoN1 = true;
        bool ServoN2 = true;

        int pre = 6;
        int pde = 6;

        private void open_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyData)
            {
                case Keys.W:     //Вперед
                    if (key[0])
                    {
                        data = Encoding.UTF8.GetBytes("W");
                        server.Send(data, data.Length);
                        key[0] = false;
                    }
                    break;
                case Keys.S:    //Назад
                    if (key[pde+0])
                    {
                        data = Encoding.UTF8.GetBytes("S");
                        server.Send(data, data.Length);
                        key[pde + 0] = false;
                    }
                    break;
                case Keys.A:    //Влево
                    if (key[1])
                    {
                        data = Encoding.UTF8.GetBytes("A");
                        server.Send(data, data.Length);
                        key[1] = false;
                    }
                    break;
                case Keys.D:  // Направо
                    if (key[pde+1])
                    {
                        data = Encoding.UTF8.GetBytes("D");
                        server.Send(data, data.Length);
                        key[pde + 1] = false;
                    }
                    break;
                case Keys.Q:  //Вверх
                    if (key[2])
                    {
                        data = Encoding.UTF8.GetBytes("Q");
                        server.Send(data, data.Length);
                        key[2] = false;
                    }
                    break;
                case Keys.E: //Вниз
                    if (key[pde + 2])
                    {
                        data = Encoding.UTF8.GetBytes("E");
                        server.Send(data, data.Length);
                        key[pde+2]=false;
                    }
                    break;
                    // наклон вперед
                case Keys.T:
                    if (key[3])
                    {
                        data = Encoding.UTF8.GetBytes("T");
                        server.Send(data, data.Length);
                        key[3] = false;
                    }
                    break;
                    //наклон назад
                case Keys.G:
                    if (key[pde + 3])
                    {
                        data = Encoding.UTF8.GetBytes("G");
                        server.Send(data, data.Length);
                        key[pde + 3] = false;
                    }
                    break;
                case Keys.F:
                    if (key[4])
                    {
                        data = Encoding.UTF8.GetBytes("F");
                        server.Send(data, data.Length);
                        key[4] = false;
                    }
                    break;
                //наклон назад
                case Keys.H:
                    if (key[pde + 4])
                    {
                        data = Encoding.UTF8.GetBytes("H");
                        server.Send(data, data.Length);
                        key[pde + 4] = false;
                    }
                    break;
                case Keys.D6:
                    if (key[5])
                    {
                        //label4.Text="gfjh-dsg";
                        data = Encoding.UTF8.GetBytes("6");
                        server.Send(data, data.Length);
                        key[5] = false;
                    }
                    break;
                    
                case Keys.D7:
                    if (key[pde+5])
                    {
                        data = Encoding.UTF8.GetBytes("7");
                        server.Send(data, data.Length);
                        key[pde+5] = false;
                    }
                    break;
                case Keys.D8:
                    if (key[6])
                    {
                        data = Encoding.UTF8.GetBytes("8");
                        server.Send(data, data.Length);
                        key[6] = false;
                    }
                    break;
                case Keys.D9:
                    if (key[pde+6])
                    {
                        data = Encoding.UTF8.GetBytes("9");
                        server.Send(data, data.Length);
                        key[pde+6] = false;
                    }
                    break;

                case Keys.I:   //Опустить
                    if (servo[0])
                    {
                        data = Encoding.UTF8.GetBytes("I");
                        server.Send(data, data.Length);
                        servo[0] = false;
                    }
                    break;
                case Keys.K:  //Поднять
                    if (servo[pre + 0])
                    {
                        data = Encoding.UTF8.GetBytes("K");
                        server.Send(data, data.Length);
                        servo[pre + 0] = false;
                    }
                    break;
                case Keys.J:   // Поворот кистью налево
                    if (servo[1])
                    {
                        data = Encoding.UTF8.GetBytes("J");
                        server.Send(data, data.Length);
                        servo[1] = false;
                    }
                    break;
                case Keys.L:  // Поворот кистью направо
                    if (servo[pre + 1])
                    {
                        data = Encoding.UTF8.GetBytes("L");
                        server.Send(data, data.Length);
                        servo[pre+1]=false;
                    }
                    break;
                case Keys.U:  //Захват
                    if (servo[2])
                    {
                        data = Encoding.UTF8.GetBytes("U");
                        server.Send(data, data.Length);
                        servo[2] = false;
                    }
                    break;
                case Keys.O:  //Разжатие
                    if (servo[pre + 2])
                    {
                        data = Encoding.UTF8.GetBytes("O");
                        server.Send(data, data.Length);
                        servo[pre + 2] = false;
                    }
                    break;
                default: return;
            }
        }

        private void open_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.W:     //Вперед
                    if (!key[0])
                    {
                        data = Encoding.UTF8.GetBytes("0");
                        server.Send(data, data.Length);
                        key[0] = true;
                    }
                    break;
                case Keys.S:    //Назад
                    if (!key[pde + 0])
                    {
                        data = Encoding.UTF8.GetBytes("0");
                        server.Send(data, data.Length);
                        key[pde + 0] = true;
                    }
                    break;
                case Keys.A:    //Влево
                    if (!key[1])
                    {
                        data = Encoding.UTF8.GetBytes("0");
                        server.Send(data, data.Length);
                        key[1] = true;
                    }
                    break;
                case Keys.D:  // Направо
                    if (!key[pde + 1])
                    {
                        data = Encoding.UTF8.GetBytes("0");
                        server.Send(data, data.Length);
                        key[pde + 1] = true;
                    }
                    break;
                case Keys.Q:  //Вверх
                    if (!key[2])
                    {
                        data = Encoding.UTF8.GetBytes("0");
                        server.Send(data, data.Length);
                        key[2] = true;
                    }
                    break;
                case Keys.E: //Вниз
                    if (!key[pde + 2])
                    {
                        data = Encoding.UTF8.GetBytes("0");
                        server.Send(data, data.Length);
                        key[pde + 2] = true;
                    }
                    break;
                case Keys.T:
                    if (!key[3])
                    {
                        data = Encoding.UTF8.GetBytes("0");
                        server.Send(data, data.Length);
                        key[3] = true;
                    }
                    break;
                //наклон назад
                case Keys.G:
                    if (!key[pde + 3])
                    {
                        data = Encoding.UTF8.GetBytes("0");
                        server.Send(data, data.Length);
                        key[pde + 3] = true;
                    }
                    break;
                case Keys.F:
                    if (!key[4])
                    {
                        data = Encoding.UTF8.GetBytes("0");
                        server.Send(data, data.Length);
                        key[4] = true;
                    }
                    break;
                //наклон назад
                case Keys.H:
                    if (!key[pde + 4])
                    {
                        data = Encoding.UTF8.GetBytes("0");
                        server.Send(data, data.Length);
                        key[pde + 4] = true;
                    }
                    break;
                case Keys.D6:
                    if (!key[5])
                    {
                        //data = Encoding.UTF8.GetBytes("6");
                        //server.Send(data, data.Length);
                        key[5] = true;
                    }
                    break;
                case Keys.D7:
                    if (!key[pde + 5])
                    {
                        //data = Encoding.UTF8.GetBytes("7");
                        //server.Send(data, data.Length);
                        key[pde + 5] = true;
                    }
                    break;
                case Keys.D8:
                    if (!key[6])
                    {
                        //data = Encoding.UTF8.GetBytes("8");
                        //server.Send(data, data.Length);
                        key[6] = true;
                    }
                    break;
                case Keys.D9:
                    if (!key[pde + 6])
                    {
                        //data = Encoding.UTF8.GetBytes("9");
                        //server.Send(data, data.Length);
                        key[pde + 6] = true;
                    }
                    break;
                /* //наклон вперед
                case Keys.Z:
                    if (!key[3])
                    {
                        data = Encoding.UTF8.GetBytes("0");
                        server.Send(data, data.Length);
                        key[3] = false;
                    }
                    break;
                //наклон назад
                case Keys.C:
                    if (!key[pde + 3])
                    {
                        data = Encoding.UTF8.GetBytes("0");
                        server.Send(data, data.Length);
                        key[pde + 3] = false;
                    }
                    break;*/
                case Keys.I:
                    if (!servo[0])
                    {
                        data = Encoding.UTF8.GetBytes("1");
                        server.Send(data, data.Length);
                        servo[0] = true;
                    }
                    break;
                case Keys.K:
                    if (!servo[pre + 0])
                    {
                        data = Encoding.UTF8.GetBytes("1");
                        server.Send(data, data.Length);
                        servo[pre + 0] = true;
                    }
                    break;
                case Keys.J:
                    if (!servo[1])
                    {
                        data = Encoding.UTF8.GetBytes("2");
                        server.Send(data, data.Length);
                        servo[1] = true;
                    }
                    break;
                case Keys.L:
                    if (!servo[pre + 1])
                    {
                        data = Encoding.UTF8.GetBytes("2");
                        server.Send(data, data.Length);
                        servo[pre + 1] = true;
                    }
                    break;
                case Keys.U:
                    if (!servo[2])
                    {
                        data = Encoding.UTF8.GetBytes("3");
                        server.Send(data, data.Length);
                        servo[2] = true;
                    }
                    break;
                case Keys.O:
                    if (!servo[pre + 2])
                    {
                        data = Encoding.UTF8.GetBytes("3");
                        server.Send(data, data.Length);
                        servo[pre + 2] = true;
                    }
                    break;
                default: return;
            }
        }
        


    }
} 
   
        
    

