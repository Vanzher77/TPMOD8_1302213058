// See https://aka.ms/new-console-template for more information
using System.Text.Json;

public class program
{
 
    private static void Main(string[] args)
    {
        config Config = new config();
        Console.WriteLine("Berapa suhu badan anda saat ini? Dalam nilai " + Config.covid.satuan_suhu);
        //menggunakan tipe data double dikarenakan menginput celcius 
        double suhu = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        //menggunakan tipe data integer untuk menginput hari
        int demam = Convert.ToInt32(Console.ReadLine());
        //menggunakan if untuk memeriksa suatu kondisi dan mengeksekusi kode tertentu. 
        if(Config.covid.satuan_suhu == "Celcius")
        {
            string text = suhu >= 36.5 && suhu <= 37.5 && demam < Config.covid.batas_hari_demam ? Config.covid.pesan_diterima : Config.covid.pesan_ditolak;
            Console.WriteLine(text);
        }
        else if (Config.covid.satuan_suhu == "fahrenheit")
        {
            string text = suhu >= 97.7 && suhu <= 99.5 && demam < Config.covid.batas_hari_demam ? Config.covid.pesan_diterima : Config.covid.pesan_ditolak;
            Console.WriteLine(text);
        }
        Console.WriteLine();
        //mengubah celcius menjadi fahrenheit
        Config.UbahSatuan();
        Console.WriteLine("Berapa suhu badan anda saat ini ? Dalam nilai " + Config.covid.satuan_suhu);
        suhu = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        demam = Convert.ToInt32(Console.ReadLine());
        //menggunakan if untuk memeriksa suatu kondisi dan mengeksekusi kode tertentu. 
        if (Config.covid.satuan_suhu == "Celcius")
        {
            string text = suhu >= 36.5 && suhu <= 37.5 && demam < Config.covid.batas_hari_demam ? Config.covid.pesan_diterima : Config.covid.pesan_ditolak;
            Console.WriteLine(text);
        }
        else if (Config.covid.satuan_suhu == "fahrenheit")
        {
            string text = suhu >= 97.7 && suhu <= 99.5 && demam < Config.covid.batas_hari_demam ? Config.covid.pesan_diterima : Config.covid.pesan_ditolak;
            Console.WriteLine(text);
            //menggunakan console readline pada akhir console writeline, dikarenakan jika tidak memakai console readline terjadi error
            //error disini saat kita menginputkan suatu kondisi akan terjadi force close pada output nya
            Console.ReadLine();
        }



    }
}