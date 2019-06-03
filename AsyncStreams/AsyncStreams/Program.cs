using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncStreams
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // await SimpleAsyncStreamAsync();
            await SimpleStreamWithCancellationAsync();
        }

        private async static Task SimpleStreamAsync()
        {
            var device = new ADevice();
            await foreach (var data in device.GetDataStreamAsync())
            {
                Console.WriteLine($"{data.Value1} {data.Value2}");
            }
        }

        private async static Task SimpleStreamWithCancellationAsync()
        {
            try
            {
                var cts2 = new CancellationTokenSource();
                cts2.CancelAfter(5000);
                cts2.Token.Register(() =>
                {
                    Console.WriteLine("cancel cts2 now...");
                });
                var cts = new CancellationTokenSource();
                cts.Token.Register(() =>
                {
                    Console.WriteLine("cancel now...");
                });
                cts.CancelAfter(3000);
                var device = new ADevice();
                await foreach (var data in device.GetDataStreamWithCancellationAsync(cts2.Token).WithCancellation(cts.Token))
                {
                    Console.WriteLine($"{data.Value1} {data.Value2}");
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
