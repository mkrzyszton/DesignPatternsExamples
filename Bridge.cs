using System;

public interface ITelewizor
{
	int Kanal { get; set; }
	void Wlacz();
	void Wylacz();
	void ZmienKanal(int kanal);
}

public class TvLg : ITelewizor
{
	public TvLg()
	{
		this.Kanal = 1;
	}

	public int Kanal { get; set; }


	public void Wlacz()
	{
		Console.WriteLine("Telewizor LG włączony.");
	}

	public void Wylacz()
	{
		Console.WriteLine("Telewizor LG wyłączony.");
	}

	public void ZmienKanal(int kanal)
	{
		Console.WriteLine($"Telewizor LG, kanał: {Kanal = kanal}");
	}
}

public class TvXiaomi : ITelewizor
{
	public TvXiaomi()
	{
		this.Kanal = 1;
	}

	public int Kanal { get; set; }

	public void Wlacz()
	{
		Console.WriteLine("Telewizor Xiaomi włączony.");
	}

	public void Wylacz()
	{
		Console.WriteLine("Telewizor Xiaomi wyłączony.");
	}

	public void ZmienKanal(int kanal)
	{
		Console.WriteLine($"Telewizor Xiaomi: {Kanal = kanal}");
	}
}

public abstract class PilotAbstrakcyjny
{
	private ITelewizor tv;

	public PilotAbstrakcyjny(ITelewizor tv)
	{
		this.tv = tv;
	}

	public void ZmienKanal(int kanal)
	{
		this.tv.Kanal = kanal;
	}
}

public class PilotHarmony : PilotAbstrakcyjny
{
	public PilotHarmony(ITelewizor tv) : base(tv) { }

	public void DoWlacz(ITelewizor tv)
	{
		Console.WriteLine("Pilot Harmony włącza telewizor...");
    tv.Wlacz();
	}

	public void DoWylacz(ITelewizor tv)
	{
		Console.WriteLine("Pilot Harmony wyłącza telewizor...");
		tv.Wylacz();
	}

  public void DoZmienKanal(ITelewizor tv, int kanal)
	{		
    Console.WriteLine("Pilot Harmony zmienia kanał...");
		tv.ZmienKanal(kanal);
	}
}

public class PilotPhilips : PilotAbstrakcyjny
{
  public PilotPhilips(ITelewizor tv) : base(tv) { }

	public void DoWlacz(ITelewizor tv)
	{
		Console.WriteLine("Pilot Philips włącza telewizor...");
		tv.Wylacz();
	}

	public void DoWylacz(ITelewizor tv)
	{
		Console.WriteLine("Pilot Philips wyłącza telewizor...");
		tv.Wylacz();
	}

  public void DoZmienKanal(ITelewizor tv, int kanal)
	{		
    Console.WriteLine("Pilot Philips zmienia kanał...");
		tv.ZmienKanal(kanal);
	}
}

class MainClass
{
	public static void Main(string[] args)
	{
    Console.OutputEncoding = System.Text.Encoding.UTF8;

		ITelewizor tv = new TvLg();
		var pilotHarmony = new PilotHarmony(tv);
		var pilotPhilips = new PilotPhilips(tv);

		pilotHarmony.DoWlacz(tv);
		Console.WriteLine("Kanał: " + tv.Kanal);
		pilotPhilips.DoZmienKanal(tv, 100);
		Console.WriteLine("Kanał: " + tv.Kanal);
		pilotHarmony.DoWylacz(tv);
	}
}
