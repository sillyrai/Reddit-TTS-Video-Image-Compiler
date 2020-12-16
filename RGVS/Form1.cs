using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RGVS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getPost();
        }
        string currentImgUrl = "";
        List<string> Posts = new List<string>();
        WebClient web = new WebClient();
        void getPost()
        {
            

            dynamic JS = JObject.Parse(web.DownloadString("https://meme-api.herokuapp.com/gimme/dankmemesfromsite19"));

            string postLink = JS.postLink;

            if(Posts.Contains(postLink))
            {
                getPost();
                return;
            }

            By_Label.Text = JS.author;
            URL_Label.Text = JS.postLink;
            Upvotes_Label.Text = JS.ups;
            string URL = JS.url;
            pictureBox1.Load(URL);
            currentImgUrl = URL;
            Posts.Add(postLink);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.AppendAllText("Credits.txt", $"u/{By_Label.Text} - {URL_Label.Text}\n");
            string ImgName = currentImgUrl.Replace("https://i.redd.it/", "");
            web.DownloadFile(currentImgUrl, ImgName);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getPost();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new BiggerView(pictureBox1.Image).Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            File.WriteAllText("Transscript.txt", richTextBox1.Text);
        }
    }
}
