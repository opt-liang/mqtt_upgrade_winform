using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Net.Security;
using System.Threading;
using System.Diagnostics;
using System.Timers;
using System.Net;

namespace upgrade
{

    public partial class upgrade : Form
    {
        MqttClient client;
        bool ConnectFlag = false;
        SynchronizationContext synctext = null;
        byte[] inform = new byte[19];
        UInt32 upgrade_times = 0;
        UInt32 upgrade_timeouts = 0;

        System.Timers.Timer upgrade_alive = new System.Timers.Timer();

        static UInt16[] crc16tab = {
            0x0000,0x1021,0x2042,0x3063,0x4084,0x50a5,0x60c6,0x70e7,
            0x8108,0x9129,0xa14a,0xb16b,0xc18c,0xd1ad,0xe1ce,0xf1ef,
            0x1231,0x0210,0x3273,0x2252,0x52b5,0x4294,0x72f7,0x62d6,
            0x9339,0x8318,0xb37b,0xa35a,0xd3bd,0xc39c,0xf3ff,0xe3de,
            0x2462,0x3443,0x0420,0x1401,0x64e6,0x74c7,0x44a4,0x5485,
            0xa56a,0xb54b,0x8528,0x9509,0xe5ee,0xf5cf,0xc5ac,0xd58d,
            0x3653,0x2672,0x1611,0x0630,0x76d7,0x66f6,0x5695,0x46b4,
            0xb75b,0xa77a,0x9719,0x8738,0xf7df,0xe7fe,0xd79d,0xc7bc,
            0x48c4,0x58e5,0x6886,0x78a7,0x0840,0x1861,0x2802,0x3823,
            0xc9cc,0xd9ed,0xe98e,0xf9af,0x8948,0x9969,0xa90a,0xb92b,
            0x5af5,0x4ad4,0x7ab7,0x6a96,0x1a71,0x0a50,0x3a33,0x2a12,
            0xdbfd,0xcbdc,0xfbbf,0xeb9e,0x9b79,0x8b58,0xbb3b,0xab1a,
            0x6ca6,0x7c87,0x4ce4,0x5cc5,0x2c22,0x3c03,0x0c60,0x1c41,
            0xedae,0xfd8f,0xcdec,0xddcd,0xad2a,0xbd0b,0x8d68,0x9d49,
            0x7e97,0x6eb6,0x5ed5,0x4ef4,0x3e13,0x2e32,0x1e51,0x0e70,
            0xff9f,0xefbe,0xdfdd,0xcffc,0xbf1b,0xaf3a,0x9f59,0x8f78,
            0x9188,0x81a9,0xb1ca,0xa1eb,0xd10c,0xc12d,0xf14e,0xe16f,
            0x1080,0x00a1,0x30c2,0x20e3,0x5004,0x4025,0x7046,0x6067,
            0x83b9,0x9398,0xa3fb,0xb3da,0xc33d,0xd31c,0xe37f,0xf35e,
            0x02b1,0x1290,0x22f3,0x32d2,0x4235,0x5214,0x6277,0x7256,
            0xb5ea,0xa5cb,0x95a8,0x8589,0xf56e,0xe54f,0xd52c,0xc50d,
            0x34e2,0x24c3,0x14a0,0x0481,0x7466,0x6447,0x5424,0x4405,
            0xa7db,0xb7fa,0x8799,0x97b8,0xe75f,0xf77e,0xc71d,0xd73c,
            0x26d3,0x36f2,0x0691,0x16b0,0x6657,0x7676,0x4615,0x5634,
            0xd94c,0xc96d,0xf90e,0xe92f,0x99c8,0x89e9,0xb98a,0xa9ab,
            0x5844,0x4865,0x7806,0x6827,0x18c0,0x08e1,0x3882,0x28a3,
            0xcb7d,0xdb5c,0xeb3f,0xfb1e,0x8bf9,0x9bd8,0xabbb,0xbb9a,
            0x4a75,0x5a54,0x6a37,0x7a16,0x0af1,0x1ad0,0x2ab3,0x3a92,
            0xfd2e,0xed0f,0xdd6c,0xcd4d,0xbdaa,0xad8b,0x9de8,0x8dc9,
            0x7c26,0x6c07,0x5c64,0x4c45,0x3ca2,0x2c83,0x1ce0,0x0cc1,
            0xef1f,0xff3e,0xcf5d,0xdf7c,0xaf9b,0xbfba,0x8fd9,0x9ff8,
            0x6e17,0x7e36,0x4e55,0x5e74,0x2e93,0x3eb2,0x0ed1,0x1ef0
        };

        static UInt32[] crcTable = {
            0x00000000,0x77073096,0xEE0E612C,0x990951BA,0x076DC419,0x706AF48F,0xE963A535,
            0x9E6495A3,0x0EDB8832,0x79DCB8A4,0xE0D5E91E,0x97D2D988,0x09B64C2B,0x7EB17CBD,
            0xE7B82D07,0x90BF1D91,0x1DB71064,0x6AB020F2,0xF3B97148,0x84BE41DE,0x1ADAD47D,
            0x6DDDE4EB,0xF4D4B551,0x83D385C7,0x136C9856,0x646BA8C0,0xFD62F97A,0x8A65C9EC,
            0x14015C4F,0x63066CD9,0xFA0F3D63,0x8D080DF5,0x3B6E20C8,0x4C69105E,0xD56041E4,
            0xA2677172,0x3C03E4D1,0x4B04D447,0xD20D85FD,0xA50AB56B,0x35B5A8FA,0x42B2986C,
            0xDBBBC9D6,0xACBCF940,0x32D86CE3,0x45DF5C75,0xDCD60DCF,0xABD13D59,0x26D930AC,
            0x51DE003A,0xC8D75180,0xBFD06116,0x21B4F4B5,0x56B3C423,0xCFBA9599,0xB8BDA50F,
            0x2802B89E,0x5F058808,0xC60CD9B2,0xB10BE924,0x2F6F7C87,0x58684C11,0xC1611DAB,
            0xB6662D3D,0x76DC4190,0x01DB7106,0x98D220BC,0xEFD5102A,0x71B18589,0x06B6B51F,
            0x9FBFE4A5,0xE8B8D433,0x7807C9A2,0x0F00F934,0x9609A88E,0xE10E9818,0x7F6A0DBB,
            0x086D3D2D,0x91646C97,0xE6635C01,0x6B6B51F4,0x1C6C6162,0x856530D8,0xF262004E,
            0x6C0695ED,0x1B01A57B,0x8208F4C1,0xF50FC457,0x65B0D9C6,0x12B7E950,0x8BBEB8EA,
            0xFCB9887C,0x62DD1DDF,0x15DA2D49,0x8CD37CF3,0xFBD44C65,0x4DB26158,0x3AB551CE,
            0xA3BC0074,0xD4BB30E2,0x4ADFA541,0x3DD895D7,0xA4D1C46D,0xD3D6F4FB,0x4369E96A,
            0x346ED9FC,0xAD678846,0xDA60B8D0,0x44042D73,0x33031DE5,0xAA0A4C5F,0xDD0D7CC9,
            0x5005713C,0x270241AA,0xBE0B1010,0xC90C2086,0x5768B525,0x206F85B3,0xB966D409,
            0xCE61E49F,0x5EDEF90E,0x29D9C998,0xB0D09822,0xC7D7A8B4,0x59B33D17,0x2EB40D81,
            0xB7BD5C3B,0xC0BA6CAD,0xEDB88320,0x9ABFB3B6,0x03B6E20C,0x74B1D29A,0xEAD54739,
            0x9DD277AF,0x04DB2615,0x73DC1683,0xE3630B12,0x94643B84,0x0D6D6A3E,0x7A6A5AA8,
            0xE40ECF0B,0x9309FF9D,0x0A00AE27,0x7D079EB1,0xF00F9344,0x8708A3D2,0x1E01F268,
            0x6906C2FE,0xF762575D,0x806567CB,0x196C3671,0x6E6B06E7,0xFED41B76,0x89D32BE0,
            0x10DA7A5A,0x67DD4ACC,0xF9B9DF6F,0x8EBEEFF9,0x17B7BE43,0x60B08ED5,0xD6D6A3E8,
            0xA1D1937E,0x38D8C2C4,0x4FDFF252,0xD1BB67F1,0xA6BC5767,0x3FB506DD,0x48B2364B,
            0xD80D2BDA,0xAF0A1B4C,0x36034AF6,0x41047A60,0xDF60EFC3,0xA867DF55,0x316E8EEF,
            0x4669BE79,0xCB61B38C,0xBC66831A,0x256FD2A0,0x5268E236,0xCC0C7795,0xBB0B4703,
            0x220216B9,0x5505262F,0xC5BA3BBE,0xB2BD0B28,0x2BB45A92,0x5CB36A04,0xC2D7FFA7,
            0xB5D0CF31,0x2CD99E8B,0x5BDEAE1D,0x9B64C2B0,0xEC63F226,0x756AA39C,0x026D930A,
            0x9C0906A9,0xEB0E363F,0x72076785,0x05005713,0x95BF4A82,0xE2B87A14,0x7BB12BAE,
            0x0CB61B38,0x92D28E9B,0xE5D5BE0D,0x7CDCEFB7,0x0BDBDF21,0x86D3D2D4,0xF1D4E242,
            0x68DDB3F8,0x1FDA836E,0x81BE16CD,0xF6B9265B,0x6FB077E1,0x18B74777,0x88085AE6,
            0xFF0F6A70,0x66063BCA,0x11010B5C,0x8F659EFF,0xF862AE69,0x616BFFD3,0x166CCF45,
            0xA00AE278,0xD70DD2EE,0x4E048354,0x3903B3C2,0xA7672661,0xD06016F7,0x4969474D,
            0x3E6E77DB,0xAED16A4A,0xD9D65ADC,0x40DF0B66,0x37D83BF0,0xA9BCAE53,0xDEBB9EC5,
            0x47B2CF7F,0x30B5FFE9,0xBDBDF21C,0xCABAC28A,0x53B39330,0x24B4A3A6,0xBAD03605,
            0xCDD70693,0x54DE5729,0x23D967BF,0xB3667A2E,0xC4614AB8,0x5D681B02,0x2A6F2B94,
            0xB40BBE37,0xC30C8EA1,0x5A05DF1B,0x2D02EF8D
        };

        private UInt16 winform_crc16(byte[] buf, UInt32 len)
        {
            UInt32 count = 0;
            UInt16 crc = 0;
            for (; count < len; count++)
            {
                crc = (UInt16)((crc << 8) ^ crc16tab[((crc >> 8) ^ buf[count]) & 0x00ff]);
            }
            return crc;
        }

        private UInt32 winform_crc32(byte[] buf, UInt32 len)
        {
            UInt32 crc = 0xe3 ^ 0xFFFFFFFF;
            for (UInt32 i = 0; i < len; i++)
            {
                crc = (crc >> 8) ^ crcTable[(crc ^ buf[i]) & 0xFF];
            }
            return crc ^ 0xFFFFFFFF;
        }

        private bool IPCheck(string IP)
        {
            return Regex.IsMatch(IP, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        private byte[] Encrypt(byte[] toEncryptarray)
        {
            int encrypt_length = toEncryptarray.Length;
            byte ctr = 1;
            UInt32 bufferindex = 0;
            string key = "0C7E151657AFDEA6ABF7158809CF4F3C";
            byte[] keyarray = new byte[16];

            byte[] sBlock = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
            };
            byte[] aBlock = { 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
            };

            for (UInt16 i = 0; i < key.Length / 2; i++)
            {
                keyarray[i] = (byte)Convert.ToUInt16(key.Substring(i * 2, 2), 16);
            }

            RijndaelManaged rdel = new RijndaelManaged();
            rdel.Key = keyarray;
            rdel.Mode = CipherMode.ECB;
            rdel.Padding = PaddingMode.PKCS7;
            ICryptoTransform ctransform = rdel.CreateEncryptor();

            while (encrypt_length > 16)
            {
                aBlock[15] = (byte)((ctr) & 0xFF);
                ctr++;
                sBlock = ctransform.TransformFinalBlock(aBlock, 0, aBlock.Length);
                for (UInt32 i = 0; i < 16; i++)
                {
                    toEncryptarray[bufferindex + i] = (byte)((toEncryptarray[bufferindex + i]) ^ (sBlock[i]));
                }
                bufferindex += 16;
                encrypt_length -= 16;
            }
            if (encrypt_length > 0)
            {
                aBlock[15] = (byte)((ctr) & 0xFF);
                sBlock = ctransform.TransformFinalBlock(aBlock, 0, aBlock.Length);
                for (UInt32 i = 0; i < encrypt_length; i++)
                {
                    toEncryptarray[bufferindex + i] = (byte)((toEncryptarray[bufferindex + i]) ^ (sBlock[i]));
                }
            }
            return toEncryptarray;
        }

        private void SetTextSafePost(object text)
        {
            DateTime dt = DateTime.Now;
            string strmsg = dt.ToString() + ": ";
            strmsg += text.ToString() + "\r\n\r\n";
            this.SubMsg.AppendText(strmsg);
        }

        private void SetTextUpgradeTimesPost(object text)
        {
            this.Times.Text = text.ToString();
        }

        private void cycle_check(object source, System.Timers.ElapsedEventArgs e)
        {
            upgrade_timeouts++;
            if (upgrade_timeouts > 60)
            {
                upgrade_timeouts = 0;
                client.Publish(this.DeviceID.Text, inform);
                Console.WriteLine( "upgrade timeouts" );
            }
        }

        private void SetTimerPara()
        {
            upgrade_alive.Elapsed += new ElapsedEventHandler(cycle_check);
            upgrade_alive.Interval = 1000;
            upgrade_alive.AutoReset = true;
            upgrade_alive.Enabled = true;
        }

        private void messageReceive(object sender, MqttMsgPublishEventArgs e)
        {
            string msg = null;
            for (Int32 i = 0; i < e.Message.Length; i++)
            {
                msg += e.Message[i].ToString("x2");
            }
            synctext.Post(SetTextSafePost, msg);
            if ( string.Compare(msg, "7fef0b0074d6fabc17958c890b" ) == 0 )
            {
                upgrade_timeouts = 0;
                upgrade_times++;
                synctext.Post(SetTextUpgradeTimesPost, upgrade_times.ToString() );
                client.Publish(this.DeviceID.Text, inform);//"0015832A6F2C"
            }
        }

        private void SetButtonSafePost(object text)
        {
            this.ConnectButton.Text = text.ToString();
            this.Sub.Enabled = true;
            this.PORT.Enabled = true;
            this.IPADDR.Enabled = true;
            this.CliendID.Enabled = true;
            this.DeviceID.Enabled = false;
            this.FilePath.Enabled = false;
            this.PubTopic.Enabled = false;
            this.UpgradeButton.Enabled = false;
            this.FileButton.Enabled = false;
            this.FilePushButton.Enabled = false;
        }

        public void ConnectState(object sender, EventArgs e)
        {
            synctext.Post(SetButtonSafePost, "connect");
            ConnectFlag = false;
        }

        public upgrade()
        {
            InitializeComponent();
            synctext = SynchronizationContext.Current;
            SetTimerPara();
        }

        private void upgrade_Load(object sender, EventArgs e)
        {
            CliendID.Text = DateTime.Now.ToString();
            DeviceID.Enabled = false;
            FilePath.Enabled = false;
            FileButton.Enabled = false;
            FilePushButton.Enabled = false;
            PubTopic.Enabled = false;
            UpgradeButton.Enabled = false;
            Times.Enabled = false;
        }

        private void FileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择升级文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] names = fileDialog.FileNames;
                if (names.Length == 1)
                {
                    FilePath.Text = names[0];
                }
                else
                {
                    MessageBox.Show("只能选择一个文件！");
                }
            }
        }

        //private void UpgradeButton_Click(object sender, EventArgs e)
        //{

        //}

        private bool domainnameToip(string domainname)
        {
            bool result = true;
            try
            {
                IPHostEntry hostinfo = Dns.GetHostByName(domainname);
                IPAddress[] aryIP = hostinfo.AddressList;
                string ip = aryIP[0].ToString();
            }
            catch( Exception e)
            {
                result = false;
            }
            return result;
        }
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            string clientId = DateTime.Now.ToString();

            CliendID.Text = clientId;

            if (IPADDR.Text.Length == 0)
            {
                MessageBox.Show("请输入服务器地址!");
                return;
            }

            if (PORT.Text.Length == 0)
            {
                MessageBox.Show("端口号为空，请输入端口号!");
                return;
            }

            if (!IPCheck(IPADDR.Text))
            {
                if (!domainnameToip(IPADDR.Text))
                {
                    MessageBox.Show("IP或域名格式不正确!");
                    IPADDR.Text = string.Empty;
                    IPADDR.Focus();
                    return;
                }
    
            }

            int port = Convert.ToInt32(PORT.Text);
            if (port > 65535)
            {
                MessageBox.Show("端口号超过65535，请输入正确端口号！");
                PORT.Text = string.Empty;
                PORT.Focus();
                return;
            }

            string username = "u001";
            string password = "p001";
            string[] topics = new string[1];
            if (Sub.Text.Length != 0)
            {
                topics[0] = Sub.Text;
            }
            else
            {
                topics[0] = "+";
                Sub.Text = "+";
            }

            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE };

            try
            {
                if (string.Compare(ConnectButton.Text, "connect") == 0)
                {
                    //单向SSL通信
                    client = new MqttClient(IPADDR.Text, port, false, null, null, MqttSslProtocols.None);
                    //消息接受
                    client.MqttMsgPublishReceived += new MqttClient.MqttMsgPublishEventHandler(messageReceive);
                    //连接Broker
                    client.ConnectionClosed += new MqttClient.ConnectionClosedEventHandler(ConnectState);

                    client.Connect(clientId, username, password);

                    client.Subscribe( topics, qosLevels );


                    ConnectFlag = true;
                    Sub.Enabled = false;
                    PORT.Enabled = false;
                    IPADDR.Enabled = false;
                    DeviceID.Enabled = true;
                    FilePath.Enabled = true;
                    CliendID.Enabled = false;
                    PubTopic.Enabled = true;
                    UpgradeButton.Enabled = true;
                    FileButton.Enabled = true;
                    FilePushButton.Enabled = true;
                    ConnectButton.Text = "disconnect";
                    return;
                }
                else
                {
                    client.Disconnect();
                    Sub.Enabled = true;
                    ConnectFlag = false;
                    PORT.Enabled = true;
                    IPADDR.Enabled = true;
                    DeviceID.Enabled = false;
                    CliendID.Enabled = true;
                    FilePath.Enabled = false;
                    FileButton.Enabled = false;
                    FilePushButton.Enabled = false;

                    PubTopic.Enabled = false;
                    UpgradeButton.Enabled = false;
                    ConnectButton.Text = "connect";
                    return;
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("MQTT服务器连接失败，请重新连接！");
                
                PORT.Enabled = true;
                IPADDR.Enabled = true;
                CliendID.Enabled = true;
                FilePath.Enabled = false;
                FileButton.Enabled = false;
                FilePushButton.Enabled = false;
                ConnectButton.Text = "connect";
                return;
            }
        }

        private void FilePushButton_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(FilePath.Text))
            {
                string PATTERN = @"([A-Fa-f0-9]*)";
                if (PubTopic.Text.Length != 6 || !Regex.IsMatch(PubTopic.Text, PATTERN))
                {
                    MessageBox.Show("PUB TOPIC ERROR！");
                    return;
                }

                byte[] filebyte = File.ReadAllBytes(FilePath.Text);
                int fileKB = (filebyte.Length) / 1024;
                if (fileKB < 100 && fileKB > 20)
                {
                    int alllength = filebyte.Length;
                    int payloadlen = 512;
                    int payketnum = 1;
                    while (alllength != 0)
                    {

                        if (alllength > 512)
                        {
                            alllength -= 512;
                            payloadlen = 512;
                        }
                        else
                        {
                            payloadlen = alllength;
                            alllength = 0;
                        }

                        byte[] payload = new byte[payloadlen + 13];
                        payload[0] = 0xef;
                        payload[1] = 0x7f;
                        payload[2] = (byte)((((UInt16)(payloadlen + 11)) & 0x00ff));
                        payload[3] = (byte)((((UInt16)(payloadlen + 11)) & 0xff00) >> 8);
                        payload[4] = 0x1d;
                        payload[5] = 0x12;
                        payload[6] = (byte)payketnum;

                        byte[] currentpacket = new byte[payloadlen];

                        Array.Copy(filebyte, (payketnum - 1) * 512, currentpacket, 0, payloadlen);

                        UInt32 CRC32 = winform_crc32(currentpacket, (uint)payloadlen);

                        payload[7] = (byte)(((CRC32) & 0x000000ff));
                        payload[8] = (byte)(((CRC32) & 0x0000ff00) >> 8);
                        payload[9] = (byte)(((CRC32) & 0x00ff0000) >> 16);
                        payload[10] = (byte)(((CRC32) & 0xff000000) >> 24);

                        Array.Copy(currentpacket, 0, payload, 11, payloadlen);

                        UInt16 CRC16 = winform_crc16((byte[])(payload.Skip(2).Take(payloadlen + 9).ToArray()), (uint)(payloadlen + 9));

                        payload[payloadlen + 13 - 1] = (byte)((CRC16 & 0xff00) >> 8);
                        payload[payloadlen + 13 - 2] = (byte)(CRC16 & 0x00ff);

                        byte[] encryptdata = new byte[payloadlen + 9];
                        Array.Copy(payload, 4, encryptdata, 0, payloadlen + 9);

                        encryptdata = Encrypt(encryptdata);

                        Array.Copy(encryptdata, 0, payload, 4, payloadlen + 9);

                        string topic = PubTopic.Text + payketnum.ToString("x2");
                        //Console.Write(topic+":");
                        //for (int i = 0; i < (payloadlen + 13); i++)
                        //{
                        //    Console.Write(payload[i].ToString("x2") + " ");
                        //}
                        //Console.WriteLine("");

                        payketnum++;

                        if (ConnectFlag)
                        {
                            client.Publish(topic, payload, MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, true);
                            Thread.Sleep(1);
                        }
                        else
                        {
                            return;
                        }
                    }

                   
                    MessageBox.Show("推送升级包完成！");
                }
                else
                {
                    if (fileKB >= 100)
                        MessageBox.Show("文件超过100KB！");
                    else
                        MessageBox.Show("文件小于20KB！");
                }
            }
            else
            {
                MessageBox.Show("目录下没有升级文件！");
                FilePath.Focus();
            }
        }

        private void IPADDR_TextChanged(object sender, EventArgs e)
        {

        }

        private void PORT_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClientID_TextChanged(object sender, EventArgs e)
        {

        }

        private void FilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeviceID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Sub_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpgradeButton_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(FilePath.Text))
            {
                string PATTERN = @"([A-Fa-f0-9]*)";
                if (PubTopic.Text.Length != 6 || !Regex.IsMatch(PubTopic.Text, PATTERN))
                {
                    MessageBox.Show("PUB TOPIC ERROR！");
                    return;
                }

                byte[] filebyte = File.ReadAllBytes(FilePath.Text);

                UInt32 crctotal = winform_crc32(filebyte, (UInt32)filebyte.Length);
                int payketnum = filebyte.Length / 512;
                if (filebyte.Length % 512 != 0)
                {
                    payketnum += 1;
                }

                byte[] topic = System.Text.Encoding.Default.GetBytes(PubTopic.Text);

                inform[0] = 0xef;
                inform[1] = 0x7f;
                inform[2] = 0x11;
                inform[3] = 0x00;
                inform[4] = 0x1F;
                inform[5] = 0x10;
                inform[6] = topic[0];
                inform[7] = topic[1];
                inform[8] = topic[2];
                inform[9] = topic[3];
                inform[10] = topic[4];
                inform[11] = topic[5];
                inform[12] = (byte)(payketnum);
                inform[16] = (byte)((crctotal & 0xff000000) >> 24);
                inform[15] = (byte)((crctotal & 0x00ff0000) >> 16);
                inform[14] = (byte)((crctotal & 0x0000ff00) >> 8);
                inform[13] = (byte)((crctotal & 0x000000ff));
                UInt16 crc16 = winform_crc16((byte[])inform.Skip(2).Take(15).ToArray(), 15);
                inform[18] = (byte)((crc16 & 0xff00) >> 8);
                inform[17] = (byte)((crc16 & 0x00ff));
                //encrypt
                byte[] nodeencrypt = (byte[])inform.Skip(4).Take(15).ToArray();
                nodeencrypt = Encrypt(nodeencrypt);
                Array.Copy(nodeencrypt, 0, inform, 4, 15);

                client.Publish(this.DeviceID.Text, inform);//"0015832A6F2C"
                upgrade_times++;
                Times.Text = upgrade_times.ToString();
                upgrade_timeouts = 0;
            }
            else
            {
                MessageBox.Show("目录下没有升级文件！");
                FilePath.Focus();
            }
                

        }
    }
}


