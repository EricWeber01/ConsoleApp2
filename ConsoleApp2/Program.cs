using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp3_core
{

    public delegate bool chot(int a);
    public delegate double pov(double a);
    public delegate bool den_p(DateTime a);
    public delegate int mas(int[] a);

    public class chelo
    {
        string name;
        int voz;
        public chelo(string _name, int _voz) { name = _name; voz = _voz; }
        public int get_voz { get { return voz; } }
        public override string ToString()
        {
            return $"Имя:{name}\nВозрост:{voz}\n--------------------";
        }
    }
    static class ExtensionMethod
    {
        public static bool chotnost(this int a)
        {
            if (a > 0) { return (a % 2 == 0); }
            return false;
        }
        public static int glas(this string a)
        {
            int p = 0;
            string buc = "ауоиэыяюеё";
            a.ToLower();
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < buc.Length; j++)
                {
                    if (a[i] == buc[j])
                    {
                        p++;
                    }
                }
            }
            return p;
        }
        public static int soglas(this string a)
        {
            int p = 0;
            string buc = "бвгджзйклмнпрстфхцчшщ";
            a.ToLower();
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < buc.Length; j++)
                {
                    if (a[i] == buc[j])
                    {
                        p++;
                    }
                }
            }
            return p;
        }
        public static chelo voz_max(this chelo[] a)
        {
            int p = a[0].get_voz, nom = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].get_voz > p)
                {
                    p = a[i].get_voz;
                    nom = i;
                }
            }
            return a[nom];
        }
        public static chelo voz_min(this chelo[] a)
        {
            int p = a[0].get_voz, nom = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].get_voz < p)
                {
                    p = a[i].get_voz;
                    nom = i;
                }
            }
            return a[nom];
        }
        public static int voz_sred(this chelo[] a)
        {
            int p = 0;
            for (int i = 0; i < a.Length; i++)
            {
                p += a[i].get_voz;
            }
            return p / a.Length;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string z;
            Random r = new Random();
            do
            {
                Console.Clear();
                Console.WriteLine("1.Лаба_1   2.Лаба_2   3.Лаба_3\n4.Лаба_4   5.Лаба_5   6.Лаба_6\n7.Лаба_7   8.Лаба_8   9.Лаба_9\n10.Лаба_10   0-Выход");
                z = Console.ReadLine();
                switch (z)
                {
                    case "1":
                        {
                            chot c = delegate (int a)
                            {
                                if (a > 0) { return (a % 2 == 0); }
                                return false;
                            };
                            Console.WriteLine($"{5} четный:{c(5)}");
                            Console.WriteLine($"{10} четный:{c(10)}");
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        {
                            pov p = delegate (double a)
                            {
                                return Math.Pow(a, 2);
                            };
                            Console.WriteLine($"{5} в степени {2} = {p(5)}");
                            Console.ReadKey();
                        }
                        break;
                    case "3":
                        {
                            pov p1 = (a) => Math.Pow(a, 3);
                            Console.WriteLine($"{5} в степени {3} = {p1(5)}");
                            Console.ReadKey();
                        }
                        break;
                    case "4":
                        {
                            DateTime dat = DateTime.Now;
                            den_p d = (a) => a.DayOfYear == 256;
                            Console.WriteLine($"{dat.DayOfYear} день програмиста : {d(dat)}");
                            Console.ReadKey();
                        }
                        break;
                    case "5":
                        {
                            int[] mai = new int[] { 3, 6, 9, 23, 1 };
                            mas mm = (a) => a.Max();
                            for (int i = 0; i < mai.Length; i++) { Console.Write(mai[i] + " ,"); }
                            Console.WriteLine($" максимум масива: {mm(mai)}");
                            Console.ReadKey();
                        }
                        break;
                    case "6":
                        {
                            int[] mai = new int[] { 3, 6, 9, 23, 1 };
                            mas mm = (a) => a.Min();
                            for (int i = 0; i < mai.Length; i++) { Console.Write(mai[i] + " ,"); }
                            Console.WriteLine($" минимум масива: {mm(mai)}");
                            Console.ReadKey();
                        }
                        break;
                    case "7":
                        {
                            int a = 5, b = 10;
                            Console.WriteLine($"{a} четный:{a.chotnost()}");
                            Console.WriteLine($"{b} четный:{b.chotnost()}");
                            Console.ReadKey();
                        }
                        break;
                    case "8":
                        {
                            string st = "я люблю сотреть на солнуе и есть ёгурт!";
                            Console.WriteLine($"{st} \nгласных букв:{st.glas()}");
                            Console.ReadKey();
                        }
                        break;
                    case "9":
                        {
                            string st = "я люблю сотреть на солнуе и есть ёгурт!";
                            Console.WriteLine($"{st} \nгласных букв:{st.soglas()}");
                            Console.ReadKey();
                        }
                        break;
                    case "10":
                        {
                            chelo[] ch = new chelo[3];
                            ch[0] = new chelo("Антон", 17);
                            ch[1] = new chelo("Люда", 87);
                            ch[2] = new chelo("Дима", 35);
                            for (int i = 0; i < ch.Length; i++)
                            {
                                Console.WriteLine(ch[i]);
                            }
                            Console.WriteLine($"максимум возраст: \n{ch.voz_max()}");
                            Console.WriteLine($"минимум возраст: \n{ch.voz_min()}");
                            Console.WriteLine($"средний возраст: {ch.voz_sred()}");
                            Console.ReadKey();
                        }
                        break;
                }
            } while (z != "0");

        }
    }

}
