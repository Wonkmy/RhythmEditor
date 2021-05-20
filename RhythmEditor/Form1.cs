using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace RhythmEditor
{
    public struct BookInfo
    {
        public string name;
        public int count;
        public int price;
    }
    public partial class Form1 : Form
    {
        int index = 0;

        public List<BookInfo> bookInfo = new List<BookInfo>() { 

            new BookInfo { name = "语文", count = 1, price = 10 } ,
            new BookInfo { name = "数学", count = 2, price = 35 },
            new BookInfo { name = "英语", count = 5, price = 46 }
        };

        public Form1()
        {
            InitializeComponent();
            string bookListtJson = JsonConvert.SerializeObject(bookInfo);
            writeJsonFile(@"e:\booklist.json", bookListtJson);
        }
        //将序列化的json字符串内容写入Json文件，并且保存
        void writeJsonFile(string path, string jsonConents)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine(jsonConents);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 90; i+=3)
            {
                Bitmap image = new Bitmap(500, 500);
                using (Graphics g = Graphics.FromImage(image))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.TranslateTransform(100, 100);
                    g.RotateTransform(i);
                    g.FillRectangle(Brushes.Red, 100, 100, 100, 100);
                }
                imageList1.Images.Add(image);
            }
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[index++];
            index %= imageList1.Images.Count;
        }
    }
}
