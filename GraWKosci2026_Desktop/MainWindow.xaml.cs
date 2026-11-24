using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GraWKosci2026_Desktop;

public partial class MainWindow : Window
{
	private const int LiczbaKosci = 5;
	private readonly Kosc[] kosci = new Kosc[LiczbaKosci];
	private readonly Image[] obrazy;

	public MainWindow()
	{
		InitializeComponent();

		obrazy =
		[
			obrazKosc0, obrazKosc1, obrazKosc2,
			obrazKosc3, obrazKosc4
		];

		for (int i = 0; i < LiczbaKosci; i++)
		{
			kosci[i] = new Kosc(0);
			RysujKosc(i);
		}
	}

	private void Rzut_Click(object sender, RoutedEventArgs e)
	{
		int suma = 0;

		for (int i = 0; i < LiczbaKosci; i++)
		{
			kosci[i].Rzut();
			RysujKosc(i);
			suma += kosci[i].liczbaOczek;
		}

		wynik.Text = suma.ToString();
	}

	private void Kosc_Click(object sender, RoutedEventArgs e)
	{
		if (sender is not Button przycisk) return;

		int indeks = Convert.ToInt32(przycisk.Tag);
		kosci[indeks].dostepna = !kosci[indeks].dostepna;

		RysujKosc(indeks);
	}

	private void RysujKosc(int indeks)
	{
		Kosc aktualnaKosc = kosci[indeks];
		string nazwaPliku = Kosc.nazwyPlikow[aktualnaKosc.identyfikatorPliku];

		obrazy[indeks].Source = new BitmapImage(new Uri($"/Obrazy/{nazwaPliku}", UriKind.Relative));
		obrazy[indeks].Opacity = aktualnaKosc.dostepna ? 1.0 : 0.5;
	}
}
