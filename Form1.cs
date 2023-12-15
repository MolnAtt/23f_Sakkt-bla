using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */

		void Oldalaz(double m)
		{
			Jobbra(90);
			Előre(m);
			Balra(90);
		}

		void Odatölt(double x, double y, Color szin)
		{
			using (new Rajzol(false))
			{
				Előre(y);
				Jobbra(90);
				Előre(x);
				Tölt(szin);
				Hátra(x);
				Balra(90);
				Hátra(y);
			}
		}
		void Odatölt_polar(double f, double m, Color szin)
		{
			using (new Rajzol(false))
			{
				Jobbra(f);
				Előre(m);
				Tölt(szin);
				Hátra(m);
				Balra(f);
			}
		}

		void Négyzet(double m, Color szin) 
		{
			for (int i = 0; i < 4; i++)
			{
				Előre(m);
				Jobbra(90);
			}

			Odatölt(m/2, m/2, szin);
		}

		void Sor(double m, int db, Color szin1, Color szin2) 
		{
			Color szin = szin1;
			for (int i = 0; i < db; i++)
			{
				Négyzet(m, szin);
				Oldalaz(m);
				szin = szin == szin1 ? szin2 : szin1; // ez a szín1? Ha igen, legyen a szin2, egyébként szin1 legyen!
			}
			Oldalaz(-db * m);
		}

		void Sakktábla(double m, int oszlopdb, int sordb, Color szin1, Color szin2) 
		{
			Color szin = szin1;
			for (int i = 0; i < sordb; i++)
			{
				Sor(m, oszlopdb, szin, szin == szin1 ? szin2 : szin1);
				Előre(m);
				szin = szin == szin1 ? szin2 : szin1; // ez a szín1? Ha igen, legyen a szin2, egyébként szin1 legyen!
			}
			Hátra(sordb*m);
		}

		/*
		Color Másik_szín(Color szin, Color szin1, Color szin2)
		{
			return szin == szin1 ? szin2 : szin1;
		}
		*/

		/* Függvények vége */
		void FELADAT()
		{
			/* Ezt indítja a START gomb! */
			// Teleport(közép.X, közép.Y+150, észak);


			Sakktábla(20, 8,8, Color.Black, Color.Pink);

		}
	}
}
