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
using System.Net;
using System.IO;
using Shell32;

namespace 生成器
{
    public partial class Form1 : Form
    {
         
        public Form1()
        {
            InitializeComponent();
        }
        public void ReadWebFile(string url, string fileName)
        {
            label10.Text = "正在进行写字幕文件...\n字幕文件写入完成\n正在进行生成音频\n";
            WebClient client = new WebClient();
            client.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Headers.Add("UserAgent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            client.DownloadFile(url, fileName);
            label10.Text = "正在进行写字幕文件...\n字幕文件写入完成\n正在进行生成音频\n音频生成完成\n";
        }
     
        //视频切割
        public string Cut(string OriginFile/*视频源文件*/, string DstFile/*生成的文件*/, int startTime/*开始时间*/, int endTime/*结束时间*/)
        {
            label10.Text = "正在进行写字幕文件...\n字幕文件写入完成\n正在进行生成音频\n音频生成完成\n正在进行随机裁剪视频\n";
            string strCmd = " -i " + OriginFile + " -ss " +
                startTime.ToString() + " -t " + 10 + " -vcodec copy " + DstFile + " -y ";

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "ffmpeg.exe";//要执行的程序名称  
            p.StartInfo.Arguments = " " + strCmd;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = false;//可能接受来自调用程序的输入信息  
            p.StartInfo.RedirectStandardOutput = false;//由调用程序获取输出信息   
            p.StartInfo.RedirectStandardError = false;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口   


            p.Start();//启动程序   


            p.WaitForExit();//等待程序执行完退出进程



             if (System.IO.File.Exists(DstFile))
            {
                return DstFile;
            }
          
            label10.Text = "正在进行写字幕文件...\n字幕文件写入完成\n正在进行生成音频\n音频生成完成\n正在进行随机裁剪视频\n视频裁剪完成\n";
            return "";
        }
        //视频合并
        public void Combine()
        {
            label10.Text = "正在进行写字幕文件...\n字幕文件写入完成\n正在进行生成音频\n音频生成完成\n正在进行随机裁剪视频\n视频裁剪完成\n合并视频\n";
            string strCmd = " -f concat -i filelist.txt -c copy  output.mp4 -y";     
            System.Diagnostics.Process p = new System.Diagnostics.Process();         
            p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "ffmpeg.exe";//要执行的程序名称  
            p.StartInfo.Arguments = " " + strCmd;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = false;//可能接受来自调用程序的输入信息  
            p.StartInfo.RedirectStandardOutput = false;//由调用程序获取输出信息   
            p.StartInfo.RedirectStandardError = false;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口   
            p.Start();//启动程序   
            p.WaitForExit();
        }
        public void Combinebgm()
        {
            string strCmd = " -y -i bgm.mp3 -af volume=-15dB output.mp3";
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "ffmpeg.exe";//要执行的程序名称  
            p.StartInfo.Arguments = " " + strCmd;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = false;//可能接受来自调用程序的输入信息  
            p.StartInfo.RedirectStandardOutput = false;//由调用程序获取输出信息   
            p.StartInfo.RedirectStandardError = false;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口   
            p.Start();//启动程序   
            p.WaitForExit();
            string strCmd2 = "-y -i test.wav -i output.mp3 -filter_complex amix=inputs=2:duration=first:dropout_transition=2 -f mp3 out2.mp3";
            p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "ffmpeg.exe";//要执行的程序名称  
            p.StartInfo.Arguments = " " + strCmd2;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = false;//可能接受来自调用程序的输入信息  
            p.StartInfo.RedirectStandardOutput = false;//由调用程序获取输出信息   
            p.StartInfo.RedirectStandardError = false;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口   
            p.Start();//启动程序   
            p.WaitForExit();
            string strCmd3 = "-y -i output.mp4 -i out2.mp3 -c copy output2.mp4";
            p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "ffmpeg.exe";//要执行的程序名称  
            p.StartInfo.Arguments = " " + strCmd3;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = false;//可能接受来自调用程序的输入信息  
            p.StartInfo.RedirectStandardOutput = false;//由调用程序获取输出信息   
            p.StartInfo.RedirectStandardError = false;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口   
            p.Start();//启动程序   
            p.WaitForExit();
            label10.Text = "正在进行写字幕文件...\n字幕文件写入完成\n正在进行生成音频\n音频生成完成\n正在进行随机裁剪视频\n视频裁剪完成\n合并视频\n合并bgm";
        }
        public void Combinesrt()
        {
            label10.Text = "正在进行写字幕文件...\n字幕文件写入完成\n正在进行生成音频\n音频生成完成\n正在进行随机裁剪视频\n视频裁剪完成\n合并视频\n合并字幕\n";
            string strCmd = "-i output2.mp4 -vcodec libx264 -vf subtitles=test.srt  final.mp4 -y";
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "ffmpeg.exe";//要执行的程序名称  
            p.StartInfo.Arguments = " " + strCmd;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = false;//可能接受来自调用程序的输入信息  
            p.StartInfo.RedirectStandardOutput = false;//由调用程序获取输出信息   
            p.StartInfo.RedirectStandardError = false;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口   
            p.Start();//启动程序   
            p.WaitForExit();
            label10.Text = "正在进行写字幕文件...\n字幕文件写入完成\n正在进行生成音频\n音频生成完成\n正在进行随机裁剪视频\n视频裁剪完成\n合并视频\n合并字幕\n完成操作";
        }
       private void setsrt() {
           label10.Text = "正在进行写字幕文件...";
           double iE_word = 0.22;
           double iE_words = 0.26;
           string str1 = textBox1.Text;//营销号
           string str2 = textBox2.Text;//多多少少
           string str3 = textBox3.Text;//爬
           string par1=str1 + str2 + "是怎么回事呢?"+ str1 + "相信大家都很熟悉";
           string par2="但是" + str1 + str2 + "是怎么回事呢,接下来就让小编带大家一起了解吧。";
           string par3=str1 + str2 + "其实就是" + str3;
           string par4="大家可能会很惊讶" + str1 + "怎么会" + str2 + "呢？但事实就是这样，小编也感到很惊讶。";
           string par5="这就是关于" + str1 + str2 + "的事情了，大家有什么想法呢，欢迎在评论区告诉小编一起讨论哦";
           double start1=0.13;
           double end1=0.13+iE_word*par1.Length;
           double start2=end1+iE_words;
           double end2=start2+iE_word*par2.Length;
           double start3=end2+iE_words;
           double end3=start3+iE_word*par3.Length;
           double start4=end3+iE_words;
           double end4=start4+iE_word*par4.Length;
           double start5=end4+iE_words;
           double end5=start5+iE_word*par1.Length*2;

           string srt0 = "0\n00:00:" + start1 + " --> 00:00:" + end1 + "\n" + par1 + "\n";
           string srt1 = "1\n00:00:" + start2 + " --> 00:00:" + end2 + "\n" + par2 + "\n";
           string srt2 = "2\n00:00:" + start3 + " --> 00:00:" + end3 + "\n" + par3 + "\n";
           string srt3 = "3\n00:00:" + start4 + " --> 00:00:" + end4 + "\n" + par4 + "\n";
           string srt4 = "4\n00:00:" + start5 + " --> 00:00:" + end5 + "\n" + par5 + "\n";
           string[] str = new string[] { srt0, srt1, srt2, srt3, srt4 };
           writesrt(str);
          
           
      

       }
       private void writesrt(string []str) {
           string pathUrl = Application.StartupPath + "\\test.srt";
           File.WriteAllText(pathUrl, string.Empty);
           File.AppendAllLines(pathUrl,str, Encoding.GetEncoding("UTF-8"));
           //AppendAllText方式向文件写入数据
           label10.Text = "正在进行写字幕文件...\n字幕文件写入完成";
            
       }
        private string getString() { 
            string str1=textBox1.Text;//营销号
            string str2=textBox2.Text;//多多少少
            string str3=textBox3.Text;//爬
            return str1 + str2 + "是怎么回事呢?" + str1 + "相信大家都很熟悉,但是" + str1 + str2 + "是怎么回事呢,接下来就让小编带大家一起了解吧。" + str1 + str2 + "其实就是" + str3 + "大家可能会很惊讶" + str1 + "怎么会" + str2 + "呢？但事实就是这样，小编也感到很惊讶。这就是关于" + str1 + str2 + "的事情了，大家有什么想法呢，欢迎在评论区告诉小编一起讨论哦！";
        }
        private void deletefile() {
            label10.Text = "正在进行写字幕文件...\n字幕文件写入完成\n正在进行生成音频\n音频生成完成\n正在进行随机裁剪视频\n视频裁剪完成\n合并视频\n合并字幕\n完成合并字幕\n正在删除临时文件...\n";
             string pathUrl = Application.StartupPath + "\\filelist.txt";
            
             File.Delete(pathUrl);
             for (int i = 1; i < 6; i++) {
                 pathUrl = Application.StartupPath + "\\log_"+i+".mp4";
                 File.Delete(pathUrl);
             }
            pathUrl = Application.StartupPath + "\\out2.mp3";
            File.Delete(pathUrl);
            pathUrl = Application.StartupPath + "\\output.mp3";
            File.Delete(pathUrl);
            pathUrl = Application.StartupPath + "\\output.mp4";
            File.Delete(pathUrl);
            pathUrl = Application.StartupPath + "\\output2.mp4";
            File.Delete(pathUrl);
            pathUrl = Application.StartupPath + "\\test.srt";
            File.Delete(pathUrl);
            pathUrl = Application.StartupPath + "\\test.wav";
            File.Delete(pathUrl);
            button1.Enabled = true;
            label10.Text = "正在进行写字幕文件...\n字幕文件写入完成\n正在进行生成音频\n音频生成完成\n正在进行随机裁剪视频\n视频裁剪完成\n合并视频\n合并字幕\n完成合并字幕\n正在删除临时文件...\n\n完成操作";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            //生成字幕
            setsrt();
            string str = getString();
            //生成音频
            ReadWebFile("http://tts.baidu.com/text2audio?lan=zh&ie=UTF-8&spd=5&text="+str, Application.StartupPath+"\\test.wav");
            Random rd = new Random();
            int i = rd.Next(10,20);
            string pathUrl = Application.StartupPath + "\\filelist.txt";
            File.WriteAllText(pathUrl, string.Empty);
            for (int n = 1; n < 6; n++) {
               Cut(Application.StartupPath + "\\all.mp4",  "log_" + n + ".mp4", i * n, n * i + 10);
               string[] list = new string[] { "file 'log_" + n + ".mp4'" };
                File.AppendAllLines(pathUrl,list, Encoding.GetEncoding("gb2312"));
            }
            Combine();
            Combinebgm();
            Combinesrt();
            deletefile();
        }
    }
}
