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

			#region 50 ile 200 lük hareketli ortalama sistemi
			/*
			 * aşağıdaki koşullarda bakıldığında verilmiş örneklemde 50 günlük üssel haraka ortalaması 200 günlük üssel hareketli ortalamayı yukarı keserse alış sinyali, 
			 * 
			 */
			//var C = Sistem.GrafikFiyatSec("Kapanis");
			//var MA1 = Sistem.MA(C, "Exp", 50);
			//var MA2 = Sistem.MA(C, "Exp", 200);

			//var SonYon = "";
			//var Sinyal = "";

			//for (int i = 1; i < Sistem.BarSayisi; i++)
			//{
			//	if (MA1[i - 1] < MA2[i - 1] && MA1[i] > MA2[i] && SonYon != "A")
			//	{
			//		Sistem.Yon[i] = "A";
			//		SonYon = "A";
			//	}
			//	if (MA1[i - 1] > MA2[i - 1] && MA1[i] < MA2[i] && SonYon != "S")
			//	{
			//		Sistem.Yon[i] = "S";
			//		SonYon = "S";
			//	}
			//}

			//Sistem.Cizgiler[0].Deger = MA1;
			//Sistem.Cizgiler[1].Deger = MA2;

			#endregion

			#region MACD / RSI ŞARTINA DAYALI SİSTEM ÖRNEKLEMİ
			//Yukaridaki şartta macd
			/*
				Yapılmakta olan koşul şudur ki ;
			MACD EĞER  KENDİSİNİN HAREKETLİ ORTALAMSINDAN BÜYÜK İSE VE,
			RSI 14 LÜK DEĞER 30'UN ALTINDAYSA BENİM İÇİN AL SİNYALİ ÜRETSİN YOK EĞER BU ŞARTIN TAM TERSİ İSE SAT SİNYALİ ÜRETSİN

			// */
			//var C = Sistem.GrafikFiyatSec("Kapanis");
			//var EMA = Sistem.MA(C, "Exp", 21);
			//var MACD = Sistem.MACD(12, 24);
			//var EMA_MACD = Sistem.MACD(MACD, 9);
			//var RSI = Sistem.RSI(14);
			//var SonYon = "";
			//var Sinyal = "";

			//for (int i = 1; i < Sistem.BarSayisi; i++)

			//{
			//	//Birinci şartımızı yazalım 
			//	if (MACD[i-1] < EMA_MACD[i-1] && MACD[i] > EMA_MACD[i] && RSI[i]<30 && SonYon !="A") 
			//	{
			//		Sistem.Yon[i] = "A";
			//		Sinyal = "A";
			//	}
			//	if (MACD[i - 1] > EMA_MACD[i - 1] && MACD[i] < EMA_MACD[i] && RSI[i] > 60 && SonYon != "S")
			//	{
			//		Sistem.Yon[i] = "S";
			//		Sinyal = "S";
			//	}


			//}




			//Sistem.Cizgiler[0].Deger = MACD;

			//Sistem.Cizgiler[1].Deger = EMA_MACD;
			//Sistem.Cizgiler[2].Deger = RSI;




			#endregion

			#region basit bit rsı al sat kurgusu

			// Basit RSI Tabanlı Al-Sat Sinyali Üretimi */



			//var C = Sistem.RSI(14);
			//var SonYon = "";
			//var Sinyal = "";


			//for (int i = 0; i < Sistem.BarSayisi; i++)
			//{
			//	if (C[i] < 30 && SonYon != "A")
			//	{
			//		Sistem.Yon[i] = "A";
			//		SonYon = "A";
			//	}
			//	else if (C[i] > 50 && SonYon != "S")
			//	{
			//		Sistem.Yon[i] = "S";
			//		SonYon = "S";


			//	}
			//}





			#endregion


			#region RSI OPTİMİZASYON KURGUSU 14 LÜK RSI DEĞERİNİ OPT YAP





			//var Kapanis = Sistem.GrafikFiyatSec("Kapanis");
			//var SonYon = "";

			//		for (int P3 = 6; P3 < 35; P3++)
			//		{
			//			var RSI = Sistem.RSI(Kapanis, P3);
			//			for (int P4 = 2; P4 < 6; P4++)
			//			{
			//				var RSIAVR = Sistem.MA(RSI, "Exp", P4);

			//				for (int i = 1; i < Kapanis.Count; i++)
			//					Sistem.Yon[i] = "";
			//				// strateji
			//				for (int i = 1; i < Kapanis.Count; i++)
			//				{
			//					if (RSI[i] > RSIAVR[i] && SonYon != "A") // alış
			//					{
			//						Sistem.Yon[i] = "A";
			//						SonYon = "A";
			//					}
			//					else if (RSI[i] < RSIAVR[i] && SonYon != "S") // satış
			//					{
			//						Sistem.Yon[i] = "S";
			//						SonYon = "S";
			//					}
			//				}

			//				Sistem.Optimizasyon("RSI Periyot", P3);


			var c = Sistem.GrafikFiyatSec("Kapanis");
			var RSI = Sistem.RSI(24);
			var RSIoRT = Sistem.MA(RSI, "Exp", 4);

			var SonYon = "";

			for (int i = 1; i < Sistem.BarSayisi; i++)
			{
				if (RSI[i] < RSIoRT[i] && SonYon != "A")
				{

					Sistem.Yon[i] = "A";
					SonYon = "A";

				}

				if (RSI[i] > RSIoRT[i] && SonYon != "A")
				{

					Sistem.Yon[i] = "A";
					SonYon = "A";

				}

				//FOR Döngüsünün scopu*****************************
			}


			Sistem.Cizgiler[0].Deger = RSI;
			Sistem.Cizgiler[1].Deger = RSIoRT;










			#endregion

			//var C = Sistem.GrafikFiyatSec("Kapanis");
			//var MMESLowa = Sistem.MA(C, "Exp", 26);
			//var MMESLowb = Sistem.MA(C, "Exp", 26);

			//var MMESFasta = Sistem.MA(C, "Exp", 12);
			//var MMESFastb = Sistem.MA(C, "Exp", 12);

			//var DemaFast = Sistem.Liste(0);
			//var LigneMACDZeroLog = Sistem.Liste(0);
			//var RenkListesi = new List<Color>();
			//var LigneSignal = Sistem.Liste(0);
			//var MacdZeroLog = Sistem.Liste(0);
			//var DemaSlow = Sistem.Liste(0);



			//for (int i = 0; i < Sistem.BarSayisi; i++)
			
			//		RenkListesi.Add(Color.Aqua);
			//for (int i = 0; i < Sistem.BarSayisi; i++)
			//{
			//	DemaSlow[i] = ((2 * MMESLowa[i]) - MMESLowb[i]);
			//	DemaFast[i]= ((2 * MMESFasta[i])- MMESFastb[i]);
			//	LigneMACDZeroLog[i] = DemaFast[i] - DemaSlow[i];
			//}

			//var MMESignala = Sistem.MA(LigneMACDZeroLog, "Exp", 9);
			//var MMESignalb = Sistem.MA(LigneSignal, "Exp", 9);

			//for (int  i= 0;  i <Sistem.BarSayisi;  i++)
			//{
			//	LigneSignal[i] = ((2 * MMESignala[i]) - MMESignalb[i]);
			//	MacdZeroLog[i] = LigneMACDZeroLog[i] - LigneSignal[i];
			//	if (MacdZeroLog[i] > 0)
			//	{
			//		RenkListesi[i] = Color.Lime;
			//	}
			//	else if (MacdZeroLog[i] < 0)
			//	{
			//		RenkListesi[i] = Color.Red;
			//	}
			//}

			//Sistem.Cizgiler[0].Deger = LigneMACDZeroLog;
			//Sistem.Cizgiler[0].Aciklama = "ligne macd";
			//Sistem.Cizgiler[0].ActiveBool= true;

			//Sistem.Cizgiler[1].Deger = LigneSignal;
			//Sistem.Cizgiler[1].Aciklama = "Signal";
			//Sistem.Cizgiler[1].Stil = 1;
			//Sistem.Cizgiler[1].ActiveBool = true;

			//Sistem.Cizgiler[2].Deger = MacdZeroLog;
			//Sistem.Cizgiler[2].Aciklama = "MACD Zero Log";
			//Sistem.Cizgiler[2].RenkListesi = RenkListesi;
			//Sistem.Cizgiler[2].Stil = 5;
			//Sistem.Cizgiler[2].ActiveBool = true;








		}
	}
}
