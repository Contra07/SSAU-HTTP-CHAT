using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bonus
{
    public partial class Form1 : Form
    {
        string log = "2020-00983";
        Site site;
        string[,] chats;
        public Form1()
        {
            InitializeComponent();
            textBoxLogin.Text = log;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            site = new Site();
            if (site.Login(textBoxLogin.Text, textBoxPass.Text)) 
            {
                chats = site.getChats();
                listBoxChats.Items.Clear();
                for (int i = 0; i < chats.GetLength(0); i++) 
                {
                    listBoxChats.Items.Add(chats[i,0]);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            string[] chat = site.getChat(chats[listBoxChats.SelectedIndex, 1]);
            foreach (string message in chat)
            {
                textBox1.Text += message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (site.sendMessage(chats[listBoxChats.SelectedIndex, 1], textBoxMessage.Text)) 
            {
                textBoxMessage.Text = "";
                listBox1_SelectedIndexChanged(null, null);
            }
        }
    }
}
