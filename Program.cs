using System;
using System.Collections.Generic;
using System.Text;

public class DanhSach<T>
{
    private List<T> items;

    public DanhSach()
    {
        items = new List<T>();
    }

    public void Them(T item)
    {
        items.Add(item);
    }

    public bool Xoa(T item)
    {
        return items.Remove(item);
    }

    public T Lay(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            return items[index];
        }
        else
        {
            throw new IndexOutOfRangeException("Index nằm ngoài phạm vi");
        }
    }

    public T Tim(Predicate<T> match)
    {
        return items.Find(match);
    }

    public int SoLuong
    {
        get { return items.Count; }
    }
}
public class SinhVien
{
    public string MaSV { get; set; }
    public string TenSV { get; set; }

    public override string ToString()
    {
        return $"{MaSV} - {TenSV}";
    }
}
public class QuanLySinhVien
{
    private Dictionary<string, string> sinhVienDictionary;

    public QuanLySinhVien()
    {
        sinhVienDictionary = new Dictionary<string, string>();
    }

    public void Them(string maSV, string tenSV)
    {
        if (!sinhVienDictionary.ContainsKey(maSV))
        {
            sinhVienDictionary.Add(maSV, tenSV);
        }
        else
        {
            Console.WriteLine($"Sinh viên với mã số {maSV} đã tồn tại.");
        }
    }

    public string LayThongTin(string maSV)
    {
        if (sinhVienDictionary.ContainsKey(maSV))
        {
            return sinhVienDictionary[maSV];
        }
        else
        {
            return null;
        }
    }
}

public class Program
{
    public static void HoanDoi<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    static void Main(string[] args)
    {
        DanhSach<SinhVien> danhSachSinhVien = new DanhSach<SinhVien>();
        Console.OutputEncoding = Encoding.UTF8;
        danhSachSinhVien.Them(new SinhVien { MaSV = "001", TenSV = "Nguyễn Văn A" });
        danhSachSinhVien.Them(new SinhVien { MaSV = "002", TenSV = "Nguyễn Văn B" });
        danhSachSinhVien.Them(new SinhVien { MaSV = "003", TenSV = "Nguyễn Văn C" });

        Console.WriteLine("Danh sách sinh viên:");
        for (int i = 0; i < danhSachSinhVien.SoLuong; i++)
        {
            Console.WriteLine(danhSachSinhVien.Lay(i));
        }

        Console.WriteLine();
        QuanLySinhVien quanLySinhVien = new QuanLySinhVien();

        quanLySinhVien.Them("001", "Nguyễn Văn A");
        quanLySinhVien.Them("002", "Nguyễn Văn B");
        quanLySinhVien.Them("003", "Nguyễn Văn C");

        Console.WriteLine("Sinh viên có mã số 002: " + quanLySinhVien.LayThongTin("002"));

        Console.WriteLine();
        int x = 5, y = 10;
        Console.WriteLine($"Trước khi hoán đổi: x = {x}, y = {y}");
        HoanDoi(ref x, ref y);
        Console.WriteLine($"Sau khi hoán đổi: x = {x}, y = {y}");

        string str1 = "Xin chào", str2 = "Thế giới";
        Console.WriteLine($"Trước khi hoán đổi: str1 = {str1}, str2 = {str2}");
        HoanDoi(ref str1, ref str2);
        Console.WriteLine($"Sau khi hoán đổi: str1 = {str1}, str2 = {str2}");

        Console.ReadLine();
    }
}

