using System;
using System.Collections.Generic;

namespace OgrenciYonetimUygulamasi
{
    internal class Program
    {
        static List<Ogrenci> ogrenciler = new List<Ogrenci>();


        static void Main(string[] args)
        {

            Giris();
        }


        static void Giris()
        {

            Console.WriteLine("Öğrenci Yönetim Uygulaması");
            Console.WriteLine("1- Öğrenci Ekle (E)");
            Console.WriteLine("2- Öğrenci Listele (L)");
            Console.WriteLine("3- Öğrenci Sil (S)");
            Console.WriteLine("4- Çıkış (X)");

            SecimAl();

           
        }

        static void SecimAl()

        {
            int secimAdet = 0;
            while (secimAdet<10)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Seçiminiz : ");

                string secim = Console.ReadLine();
               

                switch (secim)
                {
                    case "E":
                    case "1":
                        OgrenciEkle();

                        break;

                    case "2":
                    case "L":

                        OgrenciListele();

                        break;

                    case "3":
                    case "S":

                        OgrenciSil();

                        break;

                    case "4":
                    case "X":

                        Environment.Exit(0);

                        break;

                    default: 
                        Console.WriteLine("Hatalı giriş yapıldı");
                        secimAdet++;
                        break;

                }

            }

             Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor");
            Environment.Exit(0);


        }


        static void OgrenciEkle()
        {
            Ogrenci ogrenci = new Ogrenci();


            Console.WriteLine("1- Öğrenci Ekle -------------");
            Console.WriteLine((ogrenciler.Count+1)+". Öğrencinin");
            bool NoEsitMi;

            do
            {
                NoEsitMi = false;
                Console.Write("No :");
                ogrenci.No = int.Parse(Console.ReadLine());

                foreach (Ogrenci item in ogrenciler)
                {
                    if (ogrenci.No == item.No)
                    {
                        Console.WriteLine();
                        NoEsitMi = true;
                    }
                }
            } while (NoEsitMi);


            Console.Write("Adı : ");
            ogrenci.Ad =IlkHarfBuyut(Console.ReadLine());
            Console.Write("Soyadı : ");
            ogrenci.Soyad = IlkHarfBuyut(Console.ReadLine());
            Console.Write("Şubesi : ");
            ogrenci.Sube = IlkHarfBuyut(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Öğrenciyi kaydetmek istediğinize emin misiniz? (E/H)");
            string secim = Console.ReadLine().ToUpper();
            Console.WriteLine();

            if (secim == "E")
            {
                ogrenciler.Add(ogrenci);
                Console.WriteLine("Öğrenci eklendi.");

            }
            else
            {
                Console.WriteLine("Öğrenci eklenmedi. ");
            }

        }

        static void OgrenciListele()
        {

            Console.WriteLine("2-Öğrenci Listele -------------");
            Console.WriteLine();

            if (ogrenciler.Count == 0)
            {
                Console.WriteLine("Gösterilecek öğrenci yok.");
            }

            else
            {

                Console.WriteLine("Şube    No   Ad ve Soyad");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine();
                foreach (Ogrenci item in ogrenciler)
                {
                    Console.WriteLine(item.Sube.PadRight(6) + item.No.ToString().PadLeft(4) + "   " + item.Ad.PadRight(8) + " " + item.Soyad);
                }
                Console.WriteLine();
            }
        }

        static void OgrenciSil()
        {

            Console.WriteLine("3- Öğrenci Sil --------");

            if (ogrenciler.Count > 0)
            {

                Console.WriteLine("Silmek istediğiniz öğrencinin ");
                Console.Write("No : ");
                int no = int.Parse(Console.ReadLine());

                bool VarMi = false;

                foreach (Ogrenci item in ogrenciler)
                {
                    if (item.No == no)
                    {
                        VarMi = true;
                        Console.WriteLine("Adı : " + item.Ad);
                        Console.WriteLine("Soyadı : " + item.Soyad);
                        Console.WriteLine("Şubesi : " + item.Sube);
                        Console.WriteLine();
                        Console.Write("Öğrenciyi silmek istediğinize emin misiniz? (E/H)");
                        string secim = Console.ReadLine().ToUpper();
                        Console.WriteLine();

                        if (secim == "E")
                        {
                            ogrenciler.Remove(item);
                            Console.WriteLine("Öğrenci silindi.");

                        }
                        else
                        {
                            Console.WriteLine("Öğrenci silinmedi. ");
                        }


                        break;
                    }
                }




                if (VarMi == false)
                {
                    Console.WriteLine("Böyle bir öğrenci bulunamadı");


                }

            }

            else
            {
                Console.WriteLine("Listede silinecek öğrenci yok.");
            }




        }

        static string IlkHarfBuyut(string x)
        {
            string z = x.Substring(0, 1).ToUpper() + x.Substring(1).ToLower();
            return z;

        }


    }
    }
