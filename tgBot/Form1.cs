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
using System.IO;

using Telegram.Bot;

namespace tgBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static TelegramBotClient Bot;
        private AIMLbot.Bot aiml;
        AIMLbot.User me;

        async void InitBot()
        {
            string token = textBoxToken.Text;

            WebProxy wp = new WebProxy("142.93.87.88:3128", true);
            wp.Credentials = new NetworkCredential("user1", "user1password");

            Bot = new TelegramBotClient(token, wp);

            if (!await Bot.TestApiAsync())
            {
                throw new Exception("Can't reach Telegram");
            }

            Bot.OnMessage += Bot_OnMessage;
            Bot.OnMessageEdited += Bot_OnMessage;
            Bot.StartReceiving();

            label1.Text = "Run";
        }       

        private void InitAIML()
        {
            aiml = new AIMLbot.Bot();
            string p1 = Environment.CurrentDirectory;
            string p2 = Path.Combine("config", "Settings.xml");
            string p = Path.Combine(p1, p2);
            aiml.loadSettings();
            
            me = new AIMLbot.User("Lucky", aiml);
            aiml.isAcceptingUserInput = false;
            aiml.loadAIMLFromFiles();
            aiml.isAcceptingUserInput = true;

            
        }

        private void buttonRunBot_Click(object sender, EventArgs e)
        {
            InitBot();
            InitAIML();
        }

        private void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
           
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                /*
                if (e.Message.Text == "How are you?")
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Fine, thank you) And you?");
                else if (e.Message.Text == "Good morning)")
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Good morning, " + e.Message.Chat.Username);
                }
                else
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, @"Usage:                            
                       How are you?                            
                       Good morning!
                        ");
                }*/
                AIMLbot.Request r = new AIMLbot.Request(e.Message.Text, me, aiml);
                AIMLbot.Result res = aiml.Chat(r);
                Bot.SendTextMessageAsync(e.Message.Chat.Id, res.Output);

                

                //label1.Text += "Received: " + e.Message.Text;
            }
        }
    }
}
