using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output"); ;

            ImageProcess imageProcess = new ImageProcess();

            imageProcess.Clean(destinationPath);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var taskResult = imageProcess.ResizeImagesAsync(sourcePath, destinationPath, 2.0);
            await taskResult;
            sw.Stop();
            //50 img
            //改寫前4978ms
            //改寫後2802ms
            //結合Parallel.ForEach 429ms
            Console.WriteLine($"花費時間: {sw.ElapsedMilliseconds} ms");
            Console.Read();
        }
    }
}
