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

			/*	bu örnek 50 günlük haraketli ortalama 200 günlük hareketli ortalamayı yukarı yönlü kırarsa AL,
			 *	Aşağı yönlü kırarsa sat koşullarını uygular lakin, eğer burda izleyen stop ve son fiyat bilgisi %1 yukarı yönlüyse stopla veya kar al aslında bir nevi seviyeli izleyen stopa örnek bir kurgu içermektedir.
			 */


			var V = Sistem.GrafikVerileri;
			var C = Sistem.GrafikFiyatSec("Kapanis");
			var EMA50 = Sistem.MA(C, "Exp", 50);
	var EMA200 = Sistem.MA(C, "Exp", 200);			

			var SonYon = "";
			var Sinyal = "";
			float sonFiyat = 0;
			float izleyenStop = 0;


			for (int i = 1; i < Sistem.BarSayisi; i++)
			{
				if (EMA50[i - 1] < EMA200[i - 1] && EMA50[i] > EMA200[i]) Sinyal = "A";
				if (EMA50[i - 1] > EMA200[i - 1] && EMA50[i] < EMA200[i]) Sinyal = "S";


				if (SonYon == "A" && V[i].Close > izleyenStop) izleyenStop = V[i].Close;
				if (SonYon == "S" && V[i].Close < izleyenStop) izleyenStop = V[i].Close;

				if (SonYon == "A" && V[i].Close < 0.995 * izleyenStop && (V[i].Close>sonFiyat*1.01)) Sinyal = "F";
				if (SonYon == "S" && V[i].Close > 1.005 * izleyenStop && (V[i].Close < sonFiyat * 0.99)) Sinyal = "F";


				if (Sinyal != "" && Sinyal != SonYon)
				{
					Sistem.Yon[i] = Sinyal;
					SonYon = Sinyal;
					sonFiyat = V[i].Close;
				}

			}

			Sistem.Cizgiler[0].Deger = EMA50;
			Sistem.Cizgiler[1].Deger = EMA200;


			Sistem.GetiriHesapla("01/01/2025", 0.5);

			Sistem.Cizgiler[2].Deger = Sistem.GetiriKZ;


















			//var V = Sistem.GrafikVerileri;
			//var HHV = Sistem.HHV(120);
			//var LLV = Sistem.LLV(120);



			//var SonYon = "";
			//var Sinyal = "";

			//float islemFiyati = 0;

			//for (int i = 100; i < V.Count; i++)
			//{
			//	if (HHV[i] > HHV[i-1]) Sinyal = "A";
			//	if (LLV[i]< LLV[i-1]) Sinyal = "S";

			//	if (SonYon == "A" && V[i].Close < 0.99 * islemFiyati) Sinyal = "F";



			//	if (Sinyal != "" && SonYon != Sinyal)
			//	{
			//		Sistem.Yon[i] = Sinyal;
			//		SonYon = Sinyal;
			//		islemFiyati = V[i].Close;

			//	}

			//}
			//Sistem.GetiriHesapla("01/01/2000", 0);
			//Sistem.Cizgiler[0].Deger = Sistem.GetiriKZ;
			//Sistem.ZeminYazisiEkle("Toplam = ", 2, 30, 20, Color.Red, "Tahoma", 25);
			//Sistem.ZeminYazisiEkle(Sistem.GetiriToplamIslem.ToString(), 2, 230, 20, Color.Aqua, "Tahoma", 25);











		}
	}
}
