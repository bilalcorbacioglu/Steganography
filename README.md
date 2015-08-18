# Steganografi

[![Secret-Sharing](https://img.shields.io/badge/consistent-%25100-brightgreen.svg)](https://github.com/bilalcorbacioglu/Steganography)
[![Secret-Sharing](https://img.shields.io/badge/codequality-B-blue.svg?style=flat-square)](https://github.com/bilalcorbacioglu/Steganography)
[![Secret-Sharing](https://img.shields.io/badge/license-GPL-yellowgreen.svg)](https://github.com/bilalcorbacioglu/Steganography/blob/master/LICENSE)


Steganografi, eski Yunanca'da "gizlenmiş yazı" anlamına gelir ve bilgiyi gizleme (önemli: şifreleme değil) bilimine verilen addır. Steganografi'nin şifrelemeye göre en büyük avantajı bilgiyi gören bir kimsenin gördüğü şeyin içinde önemli bir bilgi olduğunu farkedemiyor olmasıdır, böylece içinde bir bilgi aramaz (oysaki bir şifreli mesaj, çözmesi zor olsa bile, gizemi dolayısıyla ilgi çeker).

Bu programda, gizli verinin en anlamsız bitlerinin yer değişimi tekniğini kullanılarak steganografiyi gerçekleştireceğiz. Mantığını aşağıda izah etmeye çalışacağım.

#### Süreç
Bildiğiniz üzere resimler pixellerden, pixeller RGB değerlerinden oluşur. Steganografide temel mantık R G B değerlerinin saklanmasına dayalı. 

Örneğin;

Elimizdeki taşıyıcı ve gizletilecek olan resimlerimiz olsun. Gizletmek istediğimiz resmi taşıyıcı resmin içine gömmek istiyoruz. Örneğin 1.Piksellerin R değerlerini ele alalım.
    
    Gizletilecek Resim      Taşıyıcı resim
    R = 41                  R = 12
    R = 00101001            R = 00001100

Buradaki temel mantık gizletilecek olan resimin pixel değerlerinin RGB değerlerini binary çevirerek son 2 veya 3 bitini yani LSB bitlerini, taşıyıcı resmin pixel değerine karşılık gelen LSB lerine gömmektir. Geri kalanı sıradaki pixel değerinin LSB sine gömülür.Böylece gizletilecek olan resmin tüm pixel değerleri, taşıyıcı resmin içine gömülene kadar bu süreç kendini tekrar eder. 

    Peki neden son 2 veya 3 bitine gömüyoruz ?

Çünkü son 4 bitine gömersek insan gözü bu değişimin farkına varır. Hatta son 3 bit bile risklidir. 2 bit kesin sonucu verecektir. Bende bu programda son 2 bite gömdüm. Yukarıdaki örneği daha iyi anlamanız için onu biraz aşağı doğru devam ettireceğim
    
    Gizletilecek resim          Taşıyıcı Resim
    R = 00101001            R = 00001100 (1.Pixel)
                            G = 00010111
                            B = 01001001
                            R = 01011011 (2.Pixel)
                            G = 10100111
                            B = 11100101

Programı Çalıştırdıktan Sonra Taşıyıcı Resmin içine gizletilecek olan resmin 1.Pixelinin R değerinin gömüldüğüne dikkat edin.

    Gizletilecek resim          Taşıyıcı Resim
                                Eski        Yeni
    R = 00101001            R = 00001100 -> 00001100 (1.Pixel)
                            G = 00010111 -> 00010110
                            B = 01001001 -> 01001010
                            R = 01011011 -> 01011001 (2.Pixel)
                            G = 10100111 -> 10100111
                            B = 11100101 -> 11100101

* Steganografi ile Secret Sharing birlikte kullanılırsa, tesine mühendislik oldukça zor olacaktır.

#### Boyutlar

Gizli Görüntü 25 X 30 boyutunda olsun. Bu boyuttaki bir görüntüyü tamamen örten bir taşıyıcı resimin boyutu şu şekilde hesaplanır.

    0 <= 25 x 30 <= (M X N X S)/8   

* M X N Taşıyıcı Resmin Boyutu
* S son kaç bite gömüleceği

 

### Credits

 * [Bilal Çorbacıoğlu](https://github.com/bilalcorbacioglu)

### License

The GNU General Public License - see [LICENSE.md](https://github.com/bilalcorbacioglu/Secret-Sharing/blob/master
