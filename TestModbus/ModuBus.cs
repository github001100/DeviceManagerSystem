using HslCommunication.ModBus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestModbus
{
    public partial class ModuBus : Form
    {
        public byte[] sendBuf = new byte[12];
        public int[] dz;
        public int ipNUM = 1;
        public static ModbusTcpNet[] busTCPClient;
        public Int32[] ReceiveData = new Int32[200];

        public ModuBus()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

        }
        void InitModbus(byte dz, int startDZ, int RegistSL)
        {
            sendBuf[0] = 0x00;
            sendBuf[1] = 0x00;
            sendBuf[2] = 0x00;
            sendBuf[3] = 0x00;
            sendBuf[4] = 0x00;
            sendBuf[5] = 0x06;
            sendBuf[6] = 1;
            sendBuf[7] = 04;
            sendBuf[8] = (byte)((startDZ >> 8) & 0xFF);
            sendBuf[9] = (byte)(startDZ & 0xFF);
            sendBuf[10] = (byte)((RegistSL >> 8) & 0xFF);
            sendBuf[11] = (byte)(RegistSL & 0xFF);
        }
        public void ConnectModbus()
        {
            int port = 3000;
            int i = 0;
            try
            {
                busTCPClient = new HslCommunication.ModBus.ModbusTcpNet[ipNUM];
                dz = new int[ipNUM];
                busTCPClient[i] = new ModbusTcpNet("192.168.1.219", port, 0x01) { ConnectTimeOut = 3000 };

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public void SendMessage()
        {
            for (int i = 0; i < ipNUM; i++)
            {
                DateTime now = DateTime.Now;

                InitModbus((byte)(dz[i]), 0, 100);
                HslCommunication.OperateResult<byte[]> read = busTCPClient[i].ReadFromCoreServer(sendBuf);  //读数据

                if (read.IsSuccess)
                {
                    byte[] aa = read.Content; //读到数据包
                    //解析数据包  1寄存器第9-10为寄存器1号内容
             
                    #region 数据正常
                    if (aa.Length > 9)
                    
                    {
                        int dz1 = aa[6];
                        //  int lenth = aa[8]; //有效数据长度
                        int k = 1;

                        #region 收数据
                        for (int j = 9; j < aa.Length; j += 2)
                        {
                            //读第1寄存器内容
                            int val = (int)aa[j];  //高位  20191130 short 32767-32768
                            val <<= 8;
                            val |= (int)aa[j + 1]; //低位 20191130 short 32767-32768
                            ReceiveData[k - 1] = val;
                            k++;
                        }
                        #endregion

                        Thread.Sleep(50);
                    }
                    #endregion
                }
            }
        }
        CancellationTokenSource cancelltokenSource = new CancellationTokenSource();

        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectModbus();
            //开启设备连接线程
            Task.Factory.StartNew(() =>
            {
                while (!cancelltokenSource.IsCancellationRequested)
                {
                    //Task.Delay(500).Wait();
                    SendMessage();
                    Task.Delay(100).Wait();
                    label1.Text = "地址0 =" + ReceiveData[0];
                    label2.Text = "地址1 =" + ReceiveData[1];
                }
            }, cancelltokenSource.Token);
        }
    }
}
