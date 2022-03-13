using System.Drawing;

namespace ImageConverter
{
    public class Program
    {
        static void Main(string[] args)
        {
            var asciiMap = "`^\",:;Il!i~+_-?][}{1)(|\\/tfjrxnuvczXYUJCLQ0OZmwqpdbkhao*#MW&8%B@$";

            var file = "C:\\C#Image\\test.png";

            Console.WriteLine($"Loading {file}");

            using (FileStream pngStream = new FileStream(file, FileMode.Open, FileAccess.Read))
            using (var image = new Bitmap(pngStream))
            {
                var column = string.Empty;

                for (int i = 0; i < image.Height; i++)
                {
                    Console.WriteLine(column);
                    column = String.Empty;

                    for (int j = 0; j < image.Width; j++) {

                        var pixel = image.GetPixel(j,i);
                            
                        var brightness =  pixel.GetBrightness() * 10;

                        var rangeValue = MapRange((int)Math.Truncate(brightness), 0, 10, 0, asciiMap.Length - 1);

                        var symbolIndex = (int)rangeValue;

                        column += asciiMap[symbolIndex];
                    }
                }
            }
        }

        public static decimal MapRange(decimal value, decimal min, decimal max, decimal targetMin, decimal targetMax)
        {
            return (value - min) / (max - min) * (targetMax - targetMin) + targetMin;
        }

    }
}