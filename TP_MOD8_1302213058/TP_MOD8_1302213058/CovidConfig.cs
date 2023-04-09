using System;
using System.Text.Json;

public class Covid
{
	public string satuan_suhu {get; set;}
    public int batas_hari_demam { get; set; }
    public string pesan_ditolak { get; set; }
    public string pesan_diterima { get; set; }

    public Covid(string suhu, int demam, string ditolak, string diterima)
    {
        this.satuan_suhu = suhu;
        this.batas_hari_demam = demam;
        this.pesan_ditolak = ditolak;
        this.pesan_diterima = diterima;
    }
    public Covid() { }
}



public class config
{
    //membuat path dan file location untuk membaca file json berada dimana
    public const string fileLocation = "E:\\DATA KULIAH\\SEMESTER 4\\Konstruksi Perangkat Lunak (KPL)\\TP Mod 8\\TP_MOD8_1302213058\\TP_MOD8_1302213058\\bin\\Debug\\net6.0";
    public const string filePath = fileLocation + @"CovidConfig.json";
    
    public Covid covid;
    
    public config() 
    {
        //menggunakan try catch block untuk menangkap dan menangani error yang di hasilkan oleh kode
        try
        {
           readJSON();
        }
        catch 
        {
            defaults();
            write();
            
            
        }
    }
    
    //untuk mengset defaults file json
    public void defaults()
    {
        covid = new Covid("Celcius", 14, "Anda tidak diperbolehkan masuk ke dalam gedung ini", "Anda dipersilahkan masuk ke dalam gedung ini");
    }

    //untuk menulis file konfigurasi dari json
    public void write()
    {
        var wrt = new JsonSerializerOptions { WriteIndented = true };
        string str = JsonSerializer.Serialize(covid, wrt);
        File.WriteAllText(@"CovidConfig.json", str);
        
    }
    //mengset filepath json
    private Covid readJSON()
    {
        
        string hasilbaca = File.ReadAllText(filePath);
        covid = JsonSerializer.Deserialize<Covid>(hasilbaca);
        return covid;
    }
    //mengubah satuan celcius dan fahrenheit yang akan keluar di output
    public void UbahSatuan()
    {
        if(covid.satuan_suhu == "Celcius")
        {
            covid.satuan_suhu = "fahrenheit";
            
            
        }
        else
        {
            covid.satuan_suhu = "Celcius";
        }
        
        
    }
}