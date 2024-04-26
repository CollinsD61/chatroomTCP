using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Send();
            AddMessage(txbMessage.Text);
        }

        IPEndPoint IP;
        Socket client;
        void Connect()// kết nối 
        {
            
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9854);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try {
                client.Connect(IP);
            }
            catch {
                MessageBox.Show("Không thể kết nối server!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }
          

            Thread listen = new Thread (Receive); 
            listen.IsBackground = true; 
            listen.Start();
        }


        void Close()
        {
                client.Close();
        }


        void Send() // gửi tin 
        {
            if (txbMessage.Text != string.Empty)
                client.Send(Serializse(txbMessage.Text));
        }

        void Receive(object obj) {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    string message = (string)Deserialize(data);
                    AddMessage(message);
                }
            }
            catch { 
            Close();
            }
            
        }   // nhận tin
        
                    
        //add message vào khung chat 
        void AddMessage(string s)
        {
            lsvMessage.Items.Add(new ListViewItem() { Text = s });
            txbMessage.Clear();
        }


        //phân mảnh 

        byte[] Serializse(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);

            return stream.ToArray();
        }

        //gom mảnh 

        object Deserialize(byte[] data)
        {

            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);


        }

        private void client_FormClosed(object sender, FormClosedEventArgs e) // đóng kết nối khi đóng form 
        {
            Close();
        }

       
    }
}
