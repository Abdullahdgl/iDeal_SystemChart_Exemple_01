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
			var RSI = Sistem.RSI(14);

			var SonYon = "";
			var Sinyal = "";

			for (int i = 100; i < V.Count; i++)
			{
				if (RSI[i] > 55) Sinyal = "A";
				if (RSI[i] < 45) Sinyal = "S";
				if (Sinyal != "" && SonYon != Sinyal)
				{
					Sistem.Yon[i] = Sinyal;
					SonYon = Sinyal;

				}

			}
			Sistem.GetiriHesapla("01/01/2024", 0.0);
			Sistem.Cizgiler[0].Deger = RSI;
			Sistem.Cizgiler[1].Deger = Sistem.GetiriKZ;
			Sistem.Cizgiler[2].Deger = Sistem.GetiriKZGun;











		}
	}
}
