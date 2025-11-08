using ideal;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace iDeal_SystemChart_Exemple_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
			
		}

        void ideal_systemchart_exemple_01(ideal.cxSistem Sistem)
        {




			var V = Sistem.GrafikVerileri;
			var RSI = Sistem.RSI(30);
			var MOM = Sistem.Momentum(120);

			var SonYon = "";
			var Sinyal = "";

			for (int i = 100; i < V.Count; i++)
			{
				if (RSI[i] > 55 && MOM[i] > 100) Sinyal = "A";
				if (RSI[i] < 45 && MOM[i] < 100) Sinyal = "S";
				if (Sinyal != "" && SonYon != Sinyal)
				{
					Sistem.Yon[i] = Sinyal;
					SonYon = Sinyal;

				}

			}
			Sistem.GetiriHesapla("01/01/2000", 0);
			Sistem.Cizgiler[0].Deger = Sistem.GetiriKZ;
			Sistem.ZeminYazisiEkle("Toplam = ", 2, 30, 20, Color.Red, "Tahoma", 25);
			Sistem.ZeminYazisiEkle(Sistem.GetiriToplamIslem.ToString(), 2, 230, 20, Color.Aqua, "Tahoma", 25);











		}
	}
}
