using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace szamTech
{
    internal class Program
    {
        class Adatok
        {
            public string nev, parameterek, jellemzok;
            public int ar, mennyiseg;
        }

        static List<Adatok> Beolvas()
        {
            StreamReader sr = new StreamReader("eszkozok.txt");
            List<Adatok> list = new List<Adatok>();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] sorok = line.Split(';');
                Adatok sv = new Adatok();
                sv.nev = sorok[0];
                sv.ar = int.Parse(sorok[1]);
                sv.mennyiseg = int.Parse(sorok[2]);
                sv.parameterek = sorok[3];
                sv.jellemzok = sorok[4];

                list.Add(sv);
            }
            sr.Close();
            return list;
        }
        static int Menu()
        {
            int kivalasztott = 0;
            ConsoleKeyInfo lenyomott;
            string[] ugyek = { "Termékek/Eszközök", "Eszköz Hozzáadása", "Eszköz Módosítása", "Eszköz Törlése", "Kilépés" };
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" ::::::::  :::::::::   ::::::::  :::::::::::  ::::::::  :::    ::: \r\n:+:    :+: :+:    :+: :+:    :+:     :+:     :+:    :+: :+:   :+:  \r\n+:+    +:+ +:+    +:+ +:+            +:+     +:+    +:+ +:+  +:+   \r\n+#+    +:+ +#++:++#+  +#+            +#+     +#+    +:+ +#++:++    \r\n+#+    +#+ +#+        +#+            +#+     +#+    +#+ +#+  +#+   \r\n#+#    #+# #+#        #+#    #+#     #+#     #+#    #+# #+#   #+#  \r\n ########  ###         ########  ###########  ########  ###    ###\n");
                for (int i = 0; i < ugyek.Count(); i++)
                {
                    if (i == kivalasztott)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine($"\t{ugyek[i]}");
                }

                lenyomott = Console.ReadKey();

                switch (lenyomott.Key)
                {
                    case ConsoleKey.UpArrow: if (kivalasztott > 0) kivalasztott--; break;
                    case ConsoleKey.DownArrow: if (kivalasztott < ugyek.Count() - 1) kivalasztott++; break;
                }
            } while (lenyomott.Key != ConsoleKey.Enter);
            return kivalasztott;
        }
        static void write()
        {
            Random rnd = new Random();
            List<Adatok> list = Beolvas();
            ConsoleKeyInfo lenyomott;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("::::::::::  ::::::::  ::::::::: :::    :::  ::::::::  :::::::::  ::::::::  :::    ::: \r\n:+:        :+:    :+:      :+:  :+:   :+:  :+:    :+:      :+:  :+:    :+: :+:   :+:  \r\n+:+        +:+            +:+   +:+  +:+   +:+    +:+     +:+   +:+    +:+ +:+  +:+   \r\n+#++:++#   +#++:++#++    +#+    +#++:++    +#+    +:+    +#+    +#+    +:+ +#++:++    \r\n+#+               +#+   +#+     +#+  +#+   +#+    +#+   +#+     +#+    +#+ +#+  +#+   \r\n#+#        #+#    #+#  #+#      #+#   #+#  #+#    #+#  #+#      #+#    #+# #+#   #+#  \r\n##########  ########  ######### ###    ###  ########  #########  ########  ###    ### \n");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < list.Count; i++)
            {
                if (rnd.Next(0, 11) == 6)
                {
                    if (list[i].mennyiseg < 10)
                    {
                        Console.WriteLine($"\t{list[i].nev} {list[i].ar} FT {list[i].mennyiseg} DB   !!!GYORSAN ELVAUL ÉS KIFOGYÓBAN!!!");
                    }
                    else
                    {
                        Console.WriteLine($"\t{list[i].nev} {list[i].ar} FT \u001a {list[i].ar - rnd.Next(3000, 10001)} FT {list[i].mennyiseg} DB   !!!GYORSAN ELAVUL!!!");
                    }
                }
                else
                {
                    if (list[i].mennyiseg < 10)
                    {
                        Console.WriteLine($"\t{list[i].nev} {list[i].ar} FT {list[i].mennyiseg} DB   !!!KIFOGYÓBAN!!!");
                    }
                    else
                    {
                        Console.WriteLine($"\t{list[i].nev} {list[i].ar} FT {list[i].mennyiseg} DB");
                    }
                }


            }

            lenyomott = Console.ReadKey();
        }
        static void add()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(":::    :::  ::::::::  ::::::::: :::::::::     :::         :::     :::::::::      :::      ::::::::\r\n" +
                               ":+:    :+: :+:    :+:      :+:       :+:    :+: :+:     :+: :+:   :+:    :+:   :+: :+:   :+:    :+:\r\n" +
                               "+:+    +:+ +:+    +:+     +:+       +:+    +:+   +:+   +:+   +:+  +:+    +:+  +:+   +:+  +:+   \r\n" +
                               "+#++:++#++ +#+    +:+    +#+       +#+    +#++:++#++: +#++:++#++: +#+    +:+ +#++:++#++: +#++:++#++\r\n" +
                               "+#+    +#+ +#+    +#+   +#+       +#+     +#+     +#+ +#+     +#+ +#+    +#+ +#+     +#+        +#+\r\n" +
                               "#+#    #+# #+#    #+#  #+#       #+#      #+#     #+# #+#     #+# #+#    #+# #+#     #+# #+#    #+#\r\n" +
                               "###    ###  ########  ######### ######### ###     ### ###     ### #########  ###     ###  ######## \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Adja meg az eszköz nevét: ");
            string nev = Console.ReadLine();
            Console.Write("Adja meg az eszköz árát: ");
            int ar = int.Parse(Console.ReadLine());
            Console.Write("Adja meg az eszköz mennyiségét: ");
            int mennyiseg = int.Parse(Console.ReadLine());
            Console.Write("Adja meg az eszköz paramétereit: ");
            string parameter = Console.ReadLine();
            Console.Write("Adja meg az eszköz jellemzőit: ");
            string jellemzo = Console.ReadLine();

            TextWriter add = new StreamWriter("eszkozok.txt", true);
            add.Write($"\n{nev};{ar};{mennyiseg};{parameter};{jellemzo}");
            add.Close();
        }

        static void change()
        {
            List<Adatok> list = Beolvas();
            ConsoleKeyInfo lenyomott;
            int kivalasztott = 0;
            do
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("::::    ::::   ::::::::  :::::::::   ::::::::   ::::::::  ::::::::::: :::::::::::     :::      ::::::::  \r\n" +
                                  "+:+:+: :+:+:+ :+:    :+: :+:    :+: :+:    :+: :+:    :+:     :+:         :+:       :+: :+:   :+:    :+: \r\n" +
                                  "+:+ +:+:+ +:+ +:+    +:+ +:+    +:+ +:+    +:+ +:+            +:+         +:+      +:+   +:+  +:+ \r\n" +
                                  "+#+  +:+  +#+ +#+    +:+ +#+    +:+ +#+    +:+ +#++:++#++     +#+         +#+     +#++:++#++: +#++:++#++ \r\n" +
                                  "+#+       +#+ +#+    +#+ +#+    +#+ +#+    +#+        +#+     +#+         +#+     +#+     +#+        +#+ \r\n" +
                                  "#+#       #+# #+#    #+# #+#    #+# #+#    #+# #+#    #+#     #+#         #+#     #+#     #+# #+#    #+# \r\n" +
                                  "###       ###  ########  #########   ########   ########  ###########     ###     ###     ###  ########  \n");
                Console.ForegroundColor = ConsoleColor.White;

                for (int i = 0; i < list.Count(); i++)
                {
                    if (i == kivalasztott)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine($"\t{list[i].nev} {list[i].ar} FT {list[i].mennyiseg} DB");
                }

                lenyomott = Console.ReadKey();

                switch (lenyomott.Key)
                {
                    case ConsoleKey.UpArrow: if (kivalasztott > 0) kivalasztott--; break;
                    case ConsoleKey.DownArrow: if (kivalasztott < list.Count() - 1) kivalasztott++; break;
                }
            } while (lenyomott.Key != ConsoleKey.Enter);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Adja meg a módosított eszköz nevét: ");
            string nev = Console.ReadLine();
            Console.Write("Adja meg a módosított eszköz árát: ");
            int ar = int.Parse(Console.ReadLine());
            Console.Write("Adja meg a módosított eszköz mennyiségét: ");
            int mennyiseg = int.Parse(Console.ReadLine());
            Console.Write("Adja meg a módosított eszköz paramétereit: ");
            string parameter = Console.ReadLine();
            Console.Write("Adja meg a módosított eszköz jellemzőit: ");
            string jellemzo = Console.ReadLine();

            list[kivalasztott].nev = nev;
            list[kivalasztott].ar = ar;
            list[kivalasztott].mennyiseg = mennyiseg;
            list[kivalasztott].parameterek = parameter;
            list[kivalasztott].jellemzok = jellemzo;

            rewrite(list);
        }
        static void rewrite(List<Adatok> list)
        {
            StreamWriter write = new StreamWriter("eszkozok.txt");
            for (int i = 0; i < list.Count; i++)
            {
                write.Write($"{list[i].nev};{list[i].ar};{list[i].mennyiseg};{list[i].parameterek};{list[i].jellemzok}\n");
            }
            write.Close();
        }

        static void delete()
        {
            List<Adatok> list = Beolvas();
            ConsoleKeyInfo lenyomott;
            int kivalasztott = 0;
            do
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(":::::::::::  ::::::::  :::::::::  :::        ::::::::::  ::::::::  \r\n" +
                                  "    :+:     :+:    :+: :+:    :+: :+:        :+:        :+:    :+: \r\n" +
                                  "    +:+     +:+    +:+ +:+    +:+ +:+        +:+        +:+ \r\n" +
                                  "    +#+     +#+    +:+ +#++:++#:  +#+        +#++:++#   +#++:++#++ \r\n" +
                                  "    +#+     +#+    +#+ +#+    +#+ +#+        +#+               +#+  \r\n" +
                                  "    #+#     #+#    #+# #+#    #+# #+#        #+#        #+#    #+# \r\n" +
                                  "    ###      ########  ###    ### ########## ##########  ########   \n");
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < list.Count(); i++)
                {
                    if (i == kivalasztott)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine($"\t{list[i].nev} {list[i].ar} FT {list[i].mennyiseg} DB");
                }

                lenyomott = Console.ReadKey();

                switch (lenyomott.Key)
                {
                    case ConsoleKey.UpArrow: if (kivalasztott > 0) kivalasztott--; break;
                    case ConsoleKey.DownArrow: if (kivalasztott < list.Count() - 1) kivalasztott++; break;
                }
            } while (lenyomott.Key != ConsoleKey.Enter);
            list.RemoveAt(kivalasztott);
            rewrite(list);
        }

        static void Main(string[] args)
        {
            do
            {
                int kivalaszott = Menu();
                if (kivalaszott == 0)
                {
                    write();
                }
                else if (kivalaszott == 1)
                {
                    add();
                }
                else if (kivalaszott == 2)
                {
                    change();
                }
                else if (kivalaszott == 3)
                {
                    delete();
                }
                else if (kivalaszott == 4)
                {
                    break;
                }
            } while (true);
        }
    }
}