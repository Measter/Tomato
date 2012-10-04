using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gif.Components;
using System.Drawing;
using System.Threading.Tasks;

namespace Lettuce
{
    public class DeferredGifEncoder
    {
        public AnimatedGifEncoder GifEncoder;
        private List<Image> frames;
        public bool Finished = false;
        public bool Encoding = false;
        private string fileName;

        public DeferredGifEncoder(AnimatedGifEncoder gifEncoder, string file)
        {
            GifEncoder = gifEncoder;
            frames = new List<Image>();
            fileName = file;
        }

        public void AddFrame(Image frame)
        {
            frames.Add((Image)frame.Clone());
        }

        public void FinishAsync(Action completed)
        {
            Encoding = Finished = true;
            Task.Factory.StartNew(() =>
                {
                    GifEncoder.Start(fileName);
                    GifEncoder.SetDelay(16); // 60 Hz
                    GifEncoder.SetRepeat(0); // Always repeat
                    foreach (var frame in frames)
                        GifEncoder.AddFrame(frame);
                    GifEncoder.Finish();
                    Encoding = false;
                    if (completed != null)
                        completed();
                });
        }
    }
}
