using System.Diagnostics;

namespace uniqueIpAddress
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var map = new UArray<bool>();
            var map2 = new UArray<bool>();

            ulong index = 0;
            var stopwatch = Stopwatch.StartNew();


            using (var reader = new StreamReader(@"D:\\projects\uniqueIpAddress\ip_addresses"))
            {
                var line = default(string);
                var stopwatch2 = Stopwatch.StartNew();

                reader.BaseStream.Position = 10242048;

                while ((line = reader.ReadLine()) is not null)
                {
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
    }
}
