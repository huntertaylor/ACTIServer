using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.MemoryMappedFiles;
using System.Threading;
using System.Diagnostics;
using ACTIServer.Structs;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Net;

namespace ACTIServer
{
    public partial class Form1 : Form
    {
        private Boolean fut = true;
        private Thread thread;
        private UdpClient udpSender;
        public Form1()
        {
            InitializeComponent();
            thread = new Thread(new ThreadStart(olvasas));
            thread.Start();
        }

        private async void olvasas()
        {
            try
            {
                while (fut)
                {

                    var memoryFile = MemoryMappedFile.CreateOrOpen("Local\\acpmf_physics", 784);
                    Debug.WriteLine(memoryFile.ToString());
                    var viewStream = memoryFile.CreateViewStream(0L, 784L);
                    byte[] data = new byte[784];
                    await viewStream.ReadAsync(data, 0, 784);
                    Debug.WriteLine(data.Length);

                    SharedFilePhisycs shared = new SharedFilePhisycs();
                    var pageFileContent = shared.ByteArrayToNewStuff(data);
                    if (pageFileContent.speedKmh == 0.0)
                    {
                        label2.Text = "Waiting for Assetto Corsa";
                        Thread.Sleep(1500);
                    }
                    else
                    {
                        //label2.Text = "Assetto Corsa Online";
                        var json = JsonConvert.SerializeObject(pageFileContent);

                        IPEndPoint endpoint = new IPEndPoint(IPAddress.Broadcast, 9666);

                        udpSender = new UdpClient();
                        //udpSender.Connect(endpoint);
                        byte[] sendableData = Encoding.ASCII.GetBytes(json);
                        label1.Text = "UDP Broadcating is alive";
                        await udpSender.SendAsync(sendableData, sendableData.Length, endpoint);
                    }
                    Thread.Sleep(100);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                try
                {
                    if (udpSender.Client.Connected)
                    {
                        udpSender.Close();
                    }
                }
                catch (Exception exp)
                {
                    Debug.WriteLine(exp.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (fut)
                {
                    fut = !fut;
                    thread.Abort();
                    button1.Text = "Connect to AC";
                    label2.Text = "";
                    label1.Text = "UDP Broadcasting turned off";
                    try
                    {
                        if (udpSender.Client.Connected)
                        {
                            udpSender.Close();
                        }
                    }
                    catch (Exception exp)
                    {
                        Debug.WriteLine(exp.Message);
                    }
                }
                else
                {
                    fut = !fut;
                    thread = new Thread(new ThreadStart(olvasas));
                    thread.Start();
                    button1.Text = "Stop Assetto Corsa Reading";
                    label2.Text = "Waiting for Assetto Corsa";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
    }
}