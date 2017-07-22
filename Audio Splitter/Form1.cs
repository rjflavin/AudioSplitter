using System;
using System.Collections.Generic;
using NAudio.Wave;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Drawing;
using System.IO;

namespace Audio_Splitter
{
    public partial class Form1 : Form
    {
        List<int> clippedFileStartPositions = new List<int>();
        List<int> clippedFileEndPositions = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void InputFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                inputFileTextArea.Text = openFileDialog1.FileName;
            }

            graphFile(inputFileTextArea.Text);
        }

        private void CreateSaveBitmap(Canvas canvas, string filename)
        {
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
             (int)canvas.Width, (int)canvas.Height,
             96d, 96d, PixelFormats.Pbgra32);
            // needed otherwise the image output is black
            canvas.Measure(new System.Windows.Size((int)canvas.Width, (int)canvas.Height));
            canvas.Arrange(new Rect(new System.Windows.Size((int)canvas.Width, (int)canvas.Height)));

            renderBitmap.Render(canvas);

            //JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
            pictureBox1.Width = renderBitmap.PixelWidth;
            pictureBox1.Image = BitmapFromSource(renderBitmap);

            using (FileStream file = File.Create(filename))
            {
                encoder.Save(file);
            }
        }

        private Bitmap BitmapFromSource(BitmapSource bitmapsource)
        {
            Bitmap bitmap;
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();

                enc.Frames.Add(BitmapFrame.Create(bitmapsource));
                enc.Save(outStream);
                bitmap = new Bitmap(outStream);
            }
            return bitmap;
        }

        private void graphFile(string file)
        {
            var window = new Window();
            var canvas = new Canvas();

            //WaveFormat target = new WaveFormat(8000, 8, 1);
            //WaveStream stream = new WaveFileReader("c:\\test.wav");
            //WaveFormatConversionStream str = new WaveFormatConversionStream(target, stream);
            //WaveFileWriter.CreateWaveFile("c:\\converted.wav", str);

            using (var reader = new AudioFileReader(@file))
            {
                var samples = (reader.Length) / (reader.WaveFormat.Channels * reader.WaveFormat.BitsPerSample / 8);
                var f = 0.0f;
                var max = 0.0f;
                // waveform will be a maximum of 4000 pixels wide:
                var batch = (int)Math.Max(40, samples / 4000)/4;
                var mid = 100;
                var yScale = 100;
                float[] buffer = new float[batch];
                int read;
                var xPos = 0;

                Boolean insideFile = false;
                int[] startEndPositions = { 0,0};
                //System.Windows.Forms.MessageBox.Show(batch.ToString());
                while ((read = reader.Read(buffer, 0, batch)) == batch)
                {
                    for (int n = 0; n < read; n++)
                    {
                        max = Math.Max(Math.Abs(buffer[n]), max);
                    }
                    
                    var line = new System.Windows.Shapes.Line();
                    line.X1 = xPos;
                    line.X2 = xPos;
                    line.Y1 = mid + (max * yScale);
                    line.Y2 = mid - (max * yScale);
                    line.StrokeThickness = 1;

                    //Console.WriteLine("Y1:" + line.Y1);
                    //Console.WriteLine("Y2:" + line.Y2);

                    if (line.Y1 < 100+trackBar1.Value && line.Y2>trackBar1.Value)
                    {
                        line.Stroke = System.Windows.Media.Brushes.Black;

                        if(insideFile==true)
                        {
                            insideFile = false;
                            startEndPositions[1] = (int)reader.Position;
                            clippedFileEndPositions.Add(startEndPositions[1]);
                            //Console.WriteLine(startEndPositions[0]+","+startEndPositions[1]);
                        }
                    }
                    else
                    {
                        line.Stroke = System.Windows.Media.Brushes.Green;

                        if(insideFile==false)
                        {
                            startEndPositions[0] = (int)reader.Position;
                            clippedFileStartPositions.Add(startEndPositions[0]);
                            insideFile = true;
                        }
                    }
                    canvas.Children.Add(line);
                    max = 0;
                    xPos++;
                }
                canvas.Width = xPos;
                canvas.Height = mid * 2;
            }
            window.Height = 260;
            var scrollViewer = new ScrollViewer();
            scrollViewer.Content = canvas;
            scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            window.Content = scrollViewer;

            //window.ShowDialog();

            CreateSaveBitmap(canvas, "test");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            graphFile(inputFileTextArea.Text);
        }

        private void OutputDirectoryButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                outputDirectoryTextArea.Text = openFileDialog1.SelectedPath;
            }
        }

        private void SplitButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(outputDirectoryTextArea.Text) && File.Exists(inputFileTextArea.Text))
            {

                    for (int i = 0; i < clippedFileStartPositions.Count; i++)
                    {
                        using (AudioFileReader reader = new AudioFileReader(inputFileTextArea.Text))
                        {
                            using (WaveFileWriter writer = new WaveFileWriter(outputDirectoryTextArea.Text + @"\" + Path.GetFileNameWithoutExtension(inputFileTextArea.Text) + i + ".wav", reader.WaveFormat))
                            {
                                Console.WriteLine(outputDirectoryTextArea.Text + @"\" + Path.GetFileNameWithoutExtension(inputFileTextArea.Text) + i + ".wav");
                                //Console.WriteLine(clippedFileStartEndPositionsList[i][0] + "," + clippedFileStartEndPositionsList[i][1]);
                                TrimWavFile(reader, writer, clippedFileStartPositions[i], clippedFileEndPositions[i]);
                            }
                        }
                    }
                
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please Select a Valid Input File and Output Directory");
            }
}

        private static void TrimWavFile(AudioFileReader reader, WaveFileWriter writer, int startPos, int endPos)
        {
            reader.Position = startPos;
            byte[] buffer = new byte[1024];
            while (reader.Position < endPos)
            {
                //Console.WriteLine(reader.Position);
                //Console.WriteLine(endPos);
                int bytesRequired = (int)(endPos - reader.Position);
                if (bytesRequired > 0)
                {
                    int bytesToRead = Math.Min(bytesRequired, buffer.Length);
                    int bytesRead = reader.Read(buffer, 0, bytesToRead);
                    if (bytesRead > 0)
                    {
                        writer.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}
