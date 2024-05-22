using AForge.Video;
using AForge.Video.DirectShow;
using System.Diagnostics;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private VideoCaptureDevice videoSource;
        private Process ffmpegProcess;
        FilterInfoCollection filterInfoCollection;

        public Form1()
        {
            InitializeComponent();
            InitializeWebcam();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo item in filterInfoCollection)
            {
                comboBox1.Items.Add(item.Name);
            }
            comboBox1.SelectedIndex = 0;
            videoSource = new VideoCaptureDevice();

        }
        private void InitializeWebcam()
        {
            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No video devices found.");
                return;
            }

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.VideoResolution = videoSource.VideoCapabilities[0];
            videoSource.NewFrame += VideoSource_NewFrame;
        }
        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Display the frame on a PictureBox or any other UI element
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = frame;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Start FFmpeg process to stream the webcam feed
            ffmpegProcess = new Process();
            ffmpegProcess.StartInfo.FileName = "ffmpeg";
            ffmpegProcess.StartInfo.Arguments = $"-f dshow -i video=\"{videoSource.Source}\" -vcodec h264 -f flv rtmp://rtmp.cdn.asset.aparat.com:443/event/efb683add3f2d79db206002e137b74905?s=001db668e2ff9dbe";
            ffmpegProcess.StartInfo.UseShellExecute = false;
            ffmpegProcess.StartInfo.RedirectStandardOutput = true;
            ffmpegProcess.StartInfo.RedirectStandardError = true;
            ffmpegProcess.StartInfo.CreateNoWindow = true;
            // Event handlers for capturing output and error streams
            ffmpegProcess.OutputDataReceived += (sender, e) => LogOutput(e.Data);
            ffmpegProcess.ErrorDataReceived += (sender, e) => LogError(e.Data);
            ffmpegProcess.Start();

            // Begin asynchronous read operations on the output and error streams
            ffmpegProcess.BeginOutputReadLine();
            ffmpegProcess.BeginErrorReadLine();

        }

        private void stop_Click(object sender, EventArgs e)
        {
            // Stop FFmpeg process
            if (ffmpegProcess != null && !ffmpegProcess.HasExited)
            {
                ffmpegProcess.Kill();
                ffmpegProcess.WaitForExit();
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop capturing webcam feed and release resources
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }

            if (ffmpegProcess != null && !ffmpegProcess.HasExited)
            {
                ffmpegProcess.Kill();
                ffmpegProcess.WaitForExit();
            }
        }

        private void capture_Click(object sender, EventArgs e)
        {
            videoSource = new VideoCaptureDevice(filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
            videoSource.NewFrame +=VideoSource_NewFrame;
            videoSource.Start();
        }

        private void LogOutput(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                // Log the output data to your desired destination (e.g., console, file, etc.)
                Console.WriteLine("Output: " + data);
            }
        }

        private void LogError(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                // Log the error data to your desired destination (e.g., console, file, etc.)
                Console.WriteLine("Error: " + data);
            }
        }
    }
}
