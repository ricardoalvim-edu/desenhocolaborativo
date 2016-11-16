using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Pacote;

namespace Trabalho_3___Servidor
{
    public partial class Servidor : Form
    {
        IPAddress ip;
        int porta;
        IPEndPoint host;
        Socket servidor;
        Thread Touvinte;
        List<Socket> clientes;
        Bitmap desenho;


        public Servidor()
        {
            InitializeComponent();
        }

        private void Servidor_Load(object sender, EventArgs e)
        {
            clientes = new List<Socket>();
        }

        private void BT_Ligar_Click(object sender, EventArgs e)
        {
            if (!CB_Padrao.Checked)
            {
                if (TB_IP.Text.Equals("") || TB_Porta.Text.Equals(""))
                {
                    MessageBox.Show("Preencha o IP/Porta", "Erro na entrada de dados",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            TB_Log.Text += "[Ligando...]" + Environment.NewLine;
            ligar();
            TB_IP.Enabled = false;
            CB_Padrao.Enabled = false;
            TB_Porta.Enabled = false;
            BT_Ligar.Enabled = false;
            BT_Ligar.Text = "Ligado";
        }

        private void ligar()
        {
            if (CB_Padrao.Checked)
            {
                ip = IPAddress.Parse("127.0.0.1");
                porta = int.Parse("2000");
            }
            else
            {
                ip = IPAddress.Parse(TB_IP.Text);
                porta = int.Parse(TB_Porta.Text);
            }

            host = new IPEndPoint(ip, porta);
            servidor = new Socket(AddressFamily.InterNetwork,
                  SocketType.Stream, ProtocolType.Tcp);
            try
            {
                servidor.Bind(host);
                Touvinte = new Thread(new ThreadStart(ouvinte));
                Touvinte.Start();
                TB_Log.Text += "[Ligado]" + Environment.NewLine;
            }
            catch (Exception ex)
            {
                TB_Log.Text += "[Erro]" + Environment.NewLine;
                MessageBox.Show("Não foi possível iniciar o servidor neste IP/Porta\n\nErro: " + ex.ToString(), "Erro na conexão",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void ouvinte()
        {
            servidor.Listen(50);
            while (true)
            {
                Socket temp = servidor.Accept();
                clientes.Add(temp);
                Thread t = new Thread(new ParameterizedThreadStart(trata_Cliente));
                t.Start(temp);
            }
        }

        private void trata_Cliente(object obj)
        {
            Socket cliente = (Socket)obj;
            while (true)
            {
                byte[] dados = new byte[999999];
                try
                {
                    cliente.Receive(dados, SocketFlags.None);
                }
                catch { return; }
                Pacote.Pacote receivePack = new Pacote.Pacote();
                receivePack = (Pacote.Pacote)ByteArrayToObject(dados);

                switch (receivePack.Id)
                {
                    case Identificador.Login:
                        AppendTextBox("Cliente conectado de: " + cliente.LocalEndPoint + Environment.NewLine);
                        Console.WriteLine("\n\nAlguém logou!\n");
                        break;
                    case Identificador.Logout:
                        foreach (Socket c in clientes)
                        {
                            if (c == cliente)
                            {
                                clientes.Remove(c);
                                break;
                            }
                        }
                        Console.WriteLine("\n\nLogout!\n");
                        break;
                    case Identificador.Info:
                        Console.WriteLine("\nInfo!\n");
                        if (desenho != null)
                        {
                            Graphics g = Graphics.FromImage(desenho);
                            g.DrawImage(receivePack.Imagem, new Point(0, 0));
                        }
                        else
                        {
                            desenho = receivePack.Imagem;
                        }

                        Pacote.Pacote sendPack = new Pacote.Pacote();
                        sendPack.Id = Identificador.Info;
                        sendPack.Imagem = desenho;
                        dados = new byte[999999];
                        dados = ObjectToByteArray(sendPack);
                        foreach (Socket c in clientes)
                        {
                            c.Send(dados, SocketFlags.None);
                            Console.WriteLine("enviou!" + Environment.NewLine);
                        }
                        if (desenho != null)
                        {
                            desenho.Save("batman.png");
                        }
                        else
                        {
                            Console.WriteLine("qede");
                        }
                        break;
                }
            }
        }

        private void CB_Padrao_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Padrao.Checked)
            {
                TB_IP.Enabled = false;
                TB_Porta.Enabled = false;
            }
            else
            {
                TB_IP.Enabled = true;
                TB_Porta.Enabled = true;
            }
        }

        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            TB_Log.Text += value;
        }

        #region Conversor
        // Convert an object to a byte array
        private byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }

        // Convert a byte array to an Object
        private Object ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);
            return obj;
        }
        #endregion
    }
}
