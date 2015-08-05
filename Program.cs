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

        static int totaline(int next) { 
			StreamReader TL = new StreamReader("");//Gomulecek resmin yolu.(Sacma resim mesela.)
                string line = TL.ReadLine();
                while (line != null)
                {
                    
                    //Console.WriteLine(line);
                    next = next + 1;
                    line = TL.ReadLine();
                        
                }
                TL.Close();
                Console.WriteLine(next);
           return next;
        }

        static void Main(string[] args)
        {
            int next = 0;
            int subline = totaline(next) * 4;
            string[] array = new string[subline];
            int length = 0, fark = 0, j = 0, i = 0, k = 0, f = 0;
			StreamReader SRG = new StreamReader("");//Gomulecek resmin yolu.(Sacma resim mesela.)
			StreamWriter WR = new StreamWriter("");//Gomulmus txt nin kaydolacagi yer ardindan Secret Sharing deki txttobmp.cpp kullanabilirsiniz.
            string line1 = SRG.ReadLine();
            while (line1 != null)
            {
                //Console.WriteLine(line1);
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
                line1 = SRG.ReadLine();//Ilk line while disinda okudugumuz icin ilk satiri isleme sokmamiz gerekiyor.
                //WR.WriteLine(stringbin);
                //Console.WriteLine(stringbin);
                //WR.Flush();
                for (i = 0; i < 4; i++ ){
                    array[f] = stringbin.Substring(k,2);
                    k = k + 2;
                    f++;
                }
                k = 0;
            }
            //WR.Close();

            string[] arraygom = new string[subline];
			StreamReader SR = new StreamReader("");//Icine gomulecek resim yolu
            string line2 = SR.ReadLine();

            int z = 0;
            while (line2 != null)
            {
                //Console.WriteLine(line2);
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
                //Bu noktada strinbin bizim decimal to binary degerimiz 
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
                Console.Read();
        
        }
    }
}