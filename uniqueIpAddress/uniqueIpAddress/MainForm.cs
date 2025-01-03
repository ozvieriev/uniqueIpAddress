using System.ComponentModel;
using System.Diagnostics;

namespace uniqueIpAddress
{
    public partial class MainForm : Form
    {
        private readonly BackgroundWorker _backgroundWorker;

        public MainForm()
        {
            InitializeComponent();

            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.WorkerReportsProgress = true;
            _backgroundWorker.DoWork += backgroundWorker_DoWork;
            _backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
        }

        private void backgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            var backgroundWorker = (BackgroundWorker)sender;

            var map = new UArray<bool>();
            var map2 = new UArray<bool>();

            var index = ulong.MinValue;
            var stopwatch = Stopwatch.StartNew();
            
            

            using (var reader = new StreamReader(@"D:\\projects\uniqueIpAddress\ip_addresses"))
            {
                var line = default(string);
                var percent = reader.BaseStream.Length / 100;
                var iterationPercent = (int)(reader.BaseStream.Position / percent);

                var stopwatch2 = Stopwatch.StartNew();

                while ((line = reader.ReadLine()) is not null)
                {
                    if (iterationPercent != reader.BaseStream.Position / percent)
                    {
                        iterationPercent = (int)(reader.BaseStream.Position / percent);
                        backgroundWorker.ReportProgress(iterationPercent);
                    }

                    ++index;

                    //var ipIndex = IpAddressConvert.IpAddressToUint(line);

                    //if (map2[ipIndex])
                    //    continue;

                    //if (map[ipIndex])
                    //    map2[ipIndex] = true;
                    //else
                    //    map[ipIndex] = true;
                }
            }

            stopwatch.Stop();
            Console.WriteLine("Getting all duplicates time: {0}, total: {1}", new TimeSpan(stopwatch.ElapsedTicks), index);

            //stopwatch = Stopwatch.StartNew();

            //var totalDuplicates = map2
            //                        .Items
            //                        .Where(entity => entity)
            //                        .Count();

            //stopwatch.Stop();

            //Console.WriteLine("Total time: {0}, total: {1}", new TimeSpan(stopwatch.ElapsedTicks), totalDuplicates);
            Console.ReadLine();
        }

        private void backgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (_backgroundWorker.IsBusy)
                return;

            _backgroundWorker.RunWorkerAsync();
        }
    }
}
