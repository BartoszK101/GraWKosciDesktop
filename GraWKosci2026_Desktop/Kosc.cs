using System;

namespace GraWKosci2026_Desktop;

public class Kosc
{
	public static int liczbaInstancji = 0;

	public static string[] nazwyPlikow =
	[
		"kosc0.png", "kosc1.png", "kosc2.png", "kosc3.png",
		"kosc4.png", "kosc5.png", "kosc6.png"
	];

	private static readonly string[] wynikiSlownie =
	[
		"zero", "jeden", "dwa", "trzy", "cztery", "pięć", "sześć"
	];

	public int liczbaOczek;
	public int identyfikatorPliku;
	public bool dostepna;

	public Kosc(int wartosc = -1)
	{
		liczbaOczek = (wartosc >= 0 && wartosc <= 6)
			? wartosc
			: Random.Shared.Next(1, 7);

		identyfikatorPliku = liczbaOczek;
		dostepna = true;
		liczbaInstancji++;
	}

	public void Rzut()
	{
		if (!dostepna) return;

		liczbaOczek = Random.Shared.Next(1, 7);
		identyfikatorPliku = liczbaOczek;
	}

	public void Zablokuj() => dostepna = false;

	public string PodajWynikSlownie() =>
		(liczbaOczek >= 0 && liczbaOczek < wynikiSlownie.Length)
			? wynikiSlownie[liczbaOczek]
			: "zero";
}
