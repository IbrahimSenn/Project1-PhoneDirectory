using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_PhoneDirectory
{
    public class Rehber
    {
        List<Kisi> kisiler = new List<Kisi>(); //yeni listenin türü kisi objesi

        public Rehber()
        {       //Varsayılan 5 kişi
            kisiler.Add(new Kisi("Umut","Önal","1234567893"));
            kisiler.Add(new Kisi("Yusuf","Can", "5678931234"));
            kisiler.Add(new Kisi("Ozan", "Çam" , "9312345678"));
            kisiler.Add(new Kisi("Savaş","Uyar", "3456789312"));
            kisiler.Add(new Kisi("Mahmut","Toprak", "6789312345"));
        }

        public void AddNo()
        {
            Console.WriteLine("***** Yeni Numara Kaydetme *****");
            string name = "";
            string surName = "";
            string phone_Number = "";
            //Kullanıcıdan aldığımız inputların validasyonu için bool ifadeleri ile kontrol sağlarız.

            bool nameIsValid = false;
            bool surnameIsValid = false;
            bool phoneIsValid = false;

            while(!nameIsValid || !surnameIsValid || !phoneIsValid) //Tüm koşullar true olduğunda döngü sonlanır.
            {
                if (!nameIsValid) //initial olarak bu blok çalışır.
                {
                    Console.WriteLine("İsminizi giriniz: ");
                    name = Console.ReadLine().Trim() ;

                    if (string.IsNullOrEmpty(name))//string kütüphanesinin bir metodu olan IsNullOrEmpty metodu ile name'in boş olup
                                                   //olmadığı kontrolü yapılır
                    {
                        Console.WriteLine("Uyarı !!!");
                        Console.WriteLine("İsim boş bırakılamaz");

                    }
                    else
                    {
                        nameIsValid= true;
                    }

                }

                if (!surnameIsValid)
                {
                    Console.WriteLine("Soy isminizi giriniz: ");
                    surName = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(surName))
                    {
                        Console.WriteLine("Uyarı !!!");
                        Console.WriteLine("Soyisim boş bırakılamaz");
                    }
                    else
                    {
                        surnameIsValid= true;
                    }

                }
                if (!phoneIsValid)
                {
                    Console.Write("10 haneli telefon numaranızı giriniz: ");
                    phone_Number = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(phone_Number))
                    {
                        Console.WriteLine("Uyarı !!!");
                        Console.WriteLine("Telefon numarası boş geçilemez");
                    }

                    else if (phone_Number.Length == 10)
                    {
                        //string türündeki telefon numarasını TryParse metodu ile long türüne çevirmeye çalışılır
                        //Eğer çevrilemezse yapı false döner ve geçersiz telefon numarası uyarısı verir. 

                        if (long.TryParse(phone_Number, out long converted_no) == false)
                        {
                            Console.WriteLine("Geçersiz telefon numarası");
                        }
                        else
                        {
                            phoneIsValid = true;
                        }

                    }


                }
                


            }

            kisiler.Add(new Kisi(name, surName, phone_Number));
            Console.WriteLine("Ekleme işlemi başarılı");    
        }

        public void DeleteNo()
        {
            string name = "";
            string surname = "";

            bool nameIsValid = false;   
            bool surnameIsValid = false;

            while (!nameIsValid || !surnameIsValid)
            {
                if (!nameIsValid)
                {
                    Console.Write("Numarasını silmek istediğiniz kişinin adını giriniz: ");
                    name = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(name) )
                    {
                        Console.WriteLine("İsim boş bırakılamaz");
                    }
                    else
                    {
                        nameIsValid = true;
                    }
                }
                else if (!surnameIsValid)
                {
                    Console.Write("Numarasını silmek istediğiniz kişinin soyadını giriniz: ");
                    surname = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(surname))
                    {
                        Console.WriteLine("Soyad boş bırakılamaz");

                    }
                    else
                    {
                        surnameIsValid = true;
                    }


                }
            }

            var result = kisiler.Find(x => x.Name == name && x.SurName == surname);

            if (result != null)
            {
                kisiler.Remove(result);
                Console.WriteLine("Kişi başarıyla listenizden silindi");
            }
            else
            {
                Console.WriteLine("Kişi bulanamadı !");
            }
        }

        public void List()
        {
            string secim = "";
            bool secimIsValid =false;
            Console.WriteLine("Rehberi Listele");
            Console.WriteLine("****************");
            while (!secimIsValid)
            {
                if (!secimIsValid)
                {
                    Console.WriteLine("A-Z listelemek için '1' \nZ-A listelemek için '2' seçiniz: ");
                    secim = Console.ReadLine();
                    if (string.IsNullOrEmpty(secim))
                    {
                        Console.WriteLine("Lütfen doğru seçim yapınız");
                    }
                    else
                    {
                        secimIsValid = true;
                    }

                }

            }
            if (secim == "1")
            {
                Console.WriteLine("Telefon Listesi");
                Console.WriteLine("****************");

                List<Kisi> sortedList = kisiler.OrderBy(x => x.Name).ToList();  //İsme göre A-Z sıralama yapar orderby

                foreach (var item in sortedList)
                {
                    Console.WriteLine("Ad: " + item.Name);
                    Console.WriteLine("Soyad: " + item.SurName);
                    Console.WriteLine("Telefon numarası: " + item.Phone_Number);

                }

            }

            if (secim == "2")
            {
                Console.WriteLine("Telefon Listesi");
                Console.WriteLine("****************");

                List<Kisi> sortedList = kisiler.OrderByDescending(x => x.Name).ToList();  //İsme göre Z-A sıralama yapar orderby

                foreach (var item in sortedList)
                {
                    Console.WriteLine("Ad: " + item.Name);
                    Console.WriteLine("Soyad: " + item.SurName);
                    Console.WriteLine("Telefon numarası: " + item.Phone_Number);

                }

            }

        }

        public void Search()
        {
            Console.WriteLine("İsim ve soyisme göre arama yapmak için '1'\n" +
                "Telefon numarasına göre arama yapmak için '2' seçiniz: ");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                Console.WriteLine("Aramak istediğiniz ismi giriniz");
                string name = Console.ReadLine();
                Console.WriteLine("Aramak istediğiniz soy ismi giriniz");
                string surname = Console.ReadLine();

                var result = kisiler.Find(x => x.Name == name && x.SurName == surname);

                if (result != null)
                {
                    Console.WriteLine( $"{result.Name} {result.SurName} {result.Phone_Number}" );

                }
                else
                {
                    Console.WriteLine("Kişi bulunamadı.");
                }

            }

            if(secim == "2")
            {
                Console.WriteLine("Aramak istediğiniz numarayı giriniz :");
                string no = Console.ReadLine();

                var result = kisiler.Find(x => x.Phone_Number == no);

                if (result != null)
                {
                    Console.WriteLine($"{result.Name} {result.SurName} {result.Phone_Number}");

                }
                else
                {
                    Console.WriteLine("Kişi bulunamadı.");
                }


            }

        }

        public void UpdateNo()
        {
            string name = "";
            string surName = "";
            string phoneNumber = "";

            bool nameIsValid = false;
            bool surNameIsValid = false;
            bool phoneNumberIsValid = false;

            while (!nameIsValid || !surNameIsValid || !phoneNumberIsValid)
            {
                if (!nameIsValid)
                {
                    Console.WriteLine("Numarasını güncellemek istediğiniz kişinin adını giriniz: ");
                    name = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Bu kısım boş geçilemez. ");
                    }

                    else
                    {
                        nameIsValid= true;
                    }


                }

                else if (!surNameIsValid)
                {
                    Console.WriteLine("Numarasını güncellemek istediğiniz kişinin soyadını giriniz: ");
                   surName = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(surName))
                    {
                        Console.WriteLine("Bu kısım boş geçilemez. ");
                    }

                    else
                    {
                        surNameIsValid = true;
                    }

                }
                else if (!phoneNumberIsValid)
                {
                    Console.WriteLine("10 haneli telefon numaranızı giriniz :");
                    phoneNumber = Console.ReadLine().Trim();

                    var result = kisiler.Find(x => x.Phone_Number == phoneNumber);
                    Console.WriteLine(result);

                    if (string.IsNullOrEmpty(phoneNumber))
                    {
                        Console.WriteLine("Uyarı !!!");
                        Console.WriteLine("Telefon numarası boş geçilemez");
                    }
                    else if (phoneNumber.Length == 10)
                    {
                        //string türündeki telefon numarasını TryParse metodu ile long türüne çevirmeye çalışılır
                        //Eğer çevrilemezse yapı false döner ve geçersiz telefon numarası uyarısı verir. 

                        if (long.TryParse(phoneNumber, out long converted_no) == false)
                        {
                            Console.WriteLine("Geçersiz telefon numarası");
                        }
                    }
                     if (result != null) //else if yapılmamalı 
                    {
                        Console.WriteLine("Kişi bulundu");
                        Console.WriteLine($"Name: {result.Name}");
                        Console.WriteLine($"Phone Number: {result.Phone_Number}");
                        Console.Write("Yeni telefon numarasını giriniz:");
                        string new_no = Console.ReadLine();

                        if (string.IsNullOrEmpty(new_no))
                        {
                            Console.WriteLine("Numara boş geçilemez !");
                        }

                        else if (new_no.Length == 10)
                        {
                            if (long.TryParse(phoneNumber, out long converted_no) == false)
                            {
                                Console.WriteLine("Geçersiz telefon numarası");
                            }

                            else
                            {
                                var sonuc = kisiler.Find(x => x.Phone_Number == phoneNumber);

                                sonuc.Phone_Number = new_no;
                                Console.WriteLine("Güncelleme başarıyla gerçekleştirildi");
                                phoneNumberIsValid = true;
                            }
                        }
                        else 
                        { 
                            Console.WriteLine("Geçersiz telefon numarası!");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Kişi bulunamadı. Lütfen bir seçim yapınız");
                        Console.WriteLine("Güncellenemyi sonlandırmak için :'1'\n" +
                                          "Yeniden denemek için:           :'2'");
                        string secim = Console.ReadLine();
                        if (secim == "1")
                        {
                            break;
                        }
                        else if (secim != "2")
                        {
                            Console.WriteLine("Hatalı giriş yaptınız");
                        }
                    }
                }
                



            }


        }


    }
}
