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

namespace server
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }

        private void server_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void btnSend_Click(object sender, EventArgs e)// gửi tin cho tất cả client
        {
            foreach(Socket item in ClientList) {
                Send(item);
            }
            AddMessage(txbMessage.Text);
            txbMessage.Clear();
        }

        IPEndPoint IP;
        Socket server;
        List<Socket> ClientList;

        void Connect()// kết nối 
        {
            ClientList = new List<Socket>();
            IP = new IPEndPoint(IPAddress.Any, 9854);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            server.Bind(IP);
            Thread Listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        ClientList.Add(client);

                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch {
                    IP = new IPEndPoint(IPAddress.Any, 2224);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });

            Listen.IsBackground = true;
            Listen.Start();
        }


        void Close()
        {
            server.Close();
        }


        void Send(Socket client ) // gửi tin 
        {
            if (client!= null &&  txbMessage.Text != string.Empty)
                client.Send(Serializse(txbMessage.Text));
        }

        void Receive(object obj)    // nhận tin
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    string message = (string)Deserialize(data);
                    foreach (Socket item in ClientList)
                    {
                        if (item != null && item != client)
                          item.Send(Serializse(message));
                    }
                    AddMessage(message);
                }
            }
            catch
            {
                ClientList.Remove(client);
                client.Close();
            }


        }



        //add message vào khung chat 
        void AddMessage(string s)
        {
            lsvMessage.Items.Add(new ListViewItem() { Text = s });
            
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

