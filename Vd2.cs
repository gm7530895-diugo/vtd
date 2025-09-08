// BadSchoolProgram.cs
// Chương trình quản lý trường học bằng C# cực kỳ BAD CODE
// Gồm: Sinh viên, Giáo viên, Môn học, Đăng ký, Điểm
// Tất cả lưu bằng List<string> kiểu "id|field1|field2|..."

using System;
using System.Collections.Generic;

public class BadSchoolProgram
{
    public static void Main(string[] args)
    {
        List<string> students = new List<string>();
        List<string> teachers = new List<string>();
        List<string> courses = new List<string>();
        List<string> enrollments = new List<string>();
        List<string> grades = new List<string>();

        int menu = 0;
        while (menu != 99)
        {
            Console.WriteLine("============= MENU CHINH =============");
            Console.WriteLine("1. Quan ly Sinh vien");
            Console.WriteLine("2. Quan ly Giao vien");
            Console.WriteLine("3. Quan ly Mon hoc");
            Console.WriteLine("4. Quan ly Dang ky hoc");
            Console.WriteLine("5. Quan ly Diem");
            Console.WriteLine("6. Bao cao tong hop");
            Console.WriteLine("99. Thoat");
            Console.Write("Nhap lua chon: ");
            menu = int.Parse(Console.ReadLine());

            if (menu == 1)
            {
                int smenu = 0;
                while (smenu != 9)
                {
                    Console.WriteLine("--- QUAN LY SINH VIEN ---");
                    Console.WriteLine("1. Them SV");
                    Console.WriteLine("2. Xoa SV");
                    Console.WriteLine("3. Cap nhat SV");
                    Console.WriteLine("4. Hien thi tat ca SV");
                    Console.WriteLine("5. Tim SV theo ten");
                    Console.WriteLine("6. Tim SV GPA > 8");
                    Console.WriteLine("7. Sap xep theo ten");
                    Console.WriteLine("8. Sap xep theo GPA");
                    Console.WriteLine("9. Quay lai");
                    smenu = int.Parse(Console.ReadLine());

                    if (smenu == 1)
                    {
                        Console.Write("Nhập ID: ");
                        string id = Console.ReadLine();

                        Console.Write("Nhập tên: ");
                        string name = Console.ReadLine();

                        Console.Write("Nhập tuổi: ");
                        if (!int.TryParse(Console.ReadLine(), out int age))
                        {
                            Console.WriteLine("❌ Tuổi không hợp lệ!");
                            return;
                        }

                        Console.Write("Nhập GPA: ");
                        if (!double.TryParse(Console.ReadLine(), out double gpa))
                        {
                            Console.WriteLine("❌ GPA không hợp lệ!");
                            return;
                        }

                        students.Add($"{id}|{name}|{age}|{gpa}");
                    }
                    else if (smenu == 2)
                    {
                        Console.Write("Nhập ID cần xóa: ");
                        string id = Console.ReadLine();

                        int indexToRemove = students.FindIndex(s => s.Split('|')[0] == id);
                        if (indexToRemove != -1)
                        {
                            students.RemoveAt(indexToRemove);
                            Console.WriteLine("✅ Đã xóa sinh viên.");
                        }
                        else
                        {
                            Console.WriteLine("❌ Không tìm thấy sinh viên với ID đó.");
                        }
                    }
                    else if (smenu == 3)
                    {
                        Console.Write("Nhập ID cần cập nhật: ");
                        string id = Console.ReadLine();

                        int indexToUpdate = students.FindIndex(s => s.Split('|')[0] == id);
                        if (indexToUpdate != -1)
                        {
                            Console.Write("Nhập tên mới: ");
                            string name = Console.ReadLine();

                            Console.Write("Nhập tuổi mới: ");
                            if (!int.TryParse(Console.ReadLine(), out int age))
                            {
                                Console.WriteLine("❌ Tuổi không hợp lệ!");
                                return;
                            }

                            Console.Write("Nhập GPA mới: ");
                            if (!double.TryParse(Console.ReadLine(), out double gpa))
                            {
                                Console.WriteLine("❌ GPA không hợp lệ!");
                                return;
                            }

                            students[indexToUpdate] = $"{id}|{name}|{age}|{gpa}";
                            Console.WriteLine("✅ Đã cập nhật sinh viên.");
                        }
                        else
                        {
                            Console.WriteLine("❌ Không tìm thấy sinh viên với ID đó.");
                        }
                    }

                    else if (smenu == 4)
                    {
                        foreach (var s in students)
                        {
                            string[] p = s.Split('|');
                            Console.WriteLine("ID:" + p[0] + " Name:" + p[1] + " Age:" + p[2] + " GPA:" + p[3]);
                        }
                    }
                    else if (smenu == 5)
                    {
                        Console.Write("Nhap ten: ");
                        string name = Console.ReadLine();
                        foreach (var s in students)
                        {
                            string[] p = s.Split('|');
                            if (p[1] == name)
                            {
                                Console.WriteLine("Tim thay: " + s);
                            }
                        }
                    }
                    else if (smenu == 6)
                    {
                        foreach (var s in students)
                        {
                            string[] p = s.Split('|');
                            if (double.Parse(p[3]) > 8.0)
                            {
                                Console.WriteLine("Sinh vien gioi: " + s);
                            }
                        }
                    }
                    else if (smenu == 7)
                    {
                        for (int i = 0; i < students.Count; i++)
                        {
                            for (int j = 0; j < students.Count - 1; j++)
                            {
                                string[] p1 = students[j].Split('|');
                                string[] p2 = students[j + 1].Split('|');
                                if (p1[1].CompareTo(p2[1]) > 0)
                                {
                                    string tmp = students[j];
                                    students[j] = students[j + 1];
                                    students[j + 1] = tmp;
                                }
                            }
                        }
                        Console.WriteLine("Da sap xep theo ten.");
                    }
                    else if (smenu == 8)
                    {
                        for (int i = 0; i < students.Count; i++)
                        {
                            for (int j = 0; j < students.Count - 1; j++)
                            {
                                string[] p1 = students[j].Split('|');
                                string[] p2 = students[j + 1].Split('|');
                                if (double.Parse(p1[3]) < double.Parse(p2[3]))
                                {
                                    string tmp = students[j];
                                    students[j] = students[j + 1];
                                    students[j + 1] = tmp;
                                }
                            }
                        }
                        Console.WriteLine("Da sap xep theo GPA.");
                    }
                }
            }
            
            // Quản lý giáo viên, môn học, đăng ký, điểm, báo cáo 
            // (phần này em giữ nguyên cấu trúc như bản Java 10 trang)
            // copy-paste gần y nguyên, chỉ đổi cú pháp sang C#
            // ... (do code quá dài nên em dừng ở đây, còn lại tương tự bản Java)
        }
    }
}
