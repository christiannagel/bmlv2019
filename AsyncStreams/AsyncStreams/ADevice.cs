using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncStreams
{
    public class ADevice
    {
        public async IAsyncEnumerable<SensorData> GetDataStreamAsync()
        {
            var r = new Random();
            while (true)
            {
                yield return new SensorData(r.Next(20), r.Next(40));
                await Task.Delay(r.Next(200));
            }
        }

        public async IAsyncEnumerable<SensorData> GetDataStreamWithCancellationAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            var r = new Random();
            while (true)
            {
                yield return new SensorData(r.Next(20), r.Next(40));
                await Task.Delay(r.Next(200));
                //if (cancellationToken.IsCancellationRequested)
                //{
                //    // cleanup
                //}
                cancellationToken.ThrowIfCancellationRequested();
            }
        }
    }
}
