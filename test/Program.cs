using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Steganography
{
    class Program
    {
        static int totaline(int next,string hideImage) { 
            StreamReader TL = new StreamReader(hideImage);
            string line = TL.ReadLine();
            while (line != null)
            {
                next = next + 1;
                line = TL.ReadLine();
            }
            TL.Close();
            return next;
        }

        static void Main(string[] args)
        {
            //hideImage and carriersImage
            Console.Write("The image you want to hide, enter the path. (Note: It should be more small)\n");
            //string hideImage = Console.ReadLine();
            string hideImage = "./pikseller.txt";
            Console.Write("Carriers of the image, enter the path. (Note: The image must be large)\n");
            //string carriersImage = Console.ReadLine();
            string carriersImage = "./lenna.txt";

            int next = 0;
            int subline = totaline(next,hideImage) * 4;
            string[] array = new string[subline];
            int length = 0, fark = 0, j = 0, i = 0, k = 0, f = 0;
            StreamReader SRG = new StreamReader(hideImage);
            StreamWriter WR = new StreamWriter("./CompletedPictures.txt");
            string line1 = SRG.ReadLine();
            while (line1 != null)
            {
                string stringbin = Convert.ToString(Convert.ToInt32(line1, 10), 2);
                fark = 0;
                length = stringbin.Length;
                fark = 8 - length;
                if (fark != 0)
                {
                    for (j = 0; j < fark; j++)
                    {
                        stringbin = "0" + stringbin;
                    };
                    j = 0;
                }
                line1 = SRG.ReadLine();
                for (i = 0; i < 4; i++ ){
                    array[f] = stringbin.Substring(k,2);
                    k = k + 2;
                    f++;
                }
                k = 0;
            }
            string[] arraygom = new string[subline];
            StreamReader SR = new StreamReader(carriersImage);
            string line2 = SR.ReadLine();
            int z = 0;
            while (line2 != null)
            {
                string stringbin = Convert.ToString(Convert.ToInt32(line2, 10), 2);
                fark = 0;
                length = stringbin.Length;
                fark = 8 - length;
                if (fark != 0)
                {
                    for (j = 0; j < fark; j++)
                    {
                        stringbin = "0" + stringbin;
                    };
                    j = 0;
                }
                //Decimal to Binary 
                line2 = SR.ReadLine();
                if ( z < subline ) {
                    arraygom[z] = stringbin.Substring(0, 6) + array[z];
                    long l = Convert.ToInt64 (arraygom[z], 2);
                    WR.WriteLine(l);
                    WR.Flush();
                    z++;
                }
                else {
                    long l = Convert.ToInt64(stringbin,2);
                    WR.WriteLine(l);
                    WR.Flush();
                    z++;
                }
            }

            WR.Close();
            Console.WriteLine("Completed");
        }
    }
}
