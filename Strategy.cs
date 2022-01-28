using System;

abstract class Zawodnik
{

    KopniecieTyp kopniecieTyp;
    SkokTyp skokTyp;
 
    public Zawodnik(KopniecieTyp kopniecieTyp, SkokTyp skokTyp)
    {
        this.kopniecieTyp = kopniecieTyp;
        this.skokTyp = skokTyp;
    }
    
    public void uderzenie()
    {
        Console.WriteLine("Uderzenie");
    }
    
    public void kopniecie()
    {
        this.kopniecieTyp.kopniecie();
    }
    
    public void skok()
    {
        this.skokTyp.skok();
    }
    
    public void ustawKopniecieTyp(KopniecieTyp kopniecieTyp)
    {
        this.kopniecieTyp = kopniecieTyp;
    }
    
    public void ustawSkokTyp(SkokTyp skokTyp)
    {
        this.skokTyp = skokTyp;
    }
    
    virtual public void przedstaw(){}

}
 
 
interface KopniecieTyp
{
  
  void kopniecie();
  
}

class KopniecieLod : KopniecieTyp
{
  
  public void kopniecie(){
    Console.WriteLine("Kopniecie lodowe");
  }
  
}

class KopniecieOgien : KopniecieTyp
{
  
    public void kopniecie()
    {
    Console.WriteLine("Kopniecie z ogniem");
  }
  
}
 

interface SkokTyp
{
  
  void skok();
  
}

class DlugiSkok : SkokTyp
{
  
  public void skok(){
    Console.WriteLine("Dlugi skok");
  }

}

class KrotkiSkok : SkokTyp
{
  
  public void skok(){
    Console.WriteLine("Krotki skok");
  }

}
 
 
class SubZero : Zawodnik
{
  
  KopniecieTyp kopniecieTyp;
  SkokTyp skokTyp;

  public SubZero(KopniecieTyp kopniecieTyp ,SkokTyp skokTyp) : base(kopniecieTyp, skokTyp)
  {
    this.kopniecieTyp = kopniecieTyp;
    this.skokTyp = skokTyp;
  }
  
  override public void przedstaw()
  {
    Console.WriteLine("Jestem Sub-Zero!");
  }
  
}


class Scorpion : Zawodnik
{

  KopniecieTyp kopniecieTyp;
  SkokTyp skokTyp;

  public Scorpion(KopniecieTyp kopniecieTyp ,SkokTyp skokTyp) : base(kopniecieTyp, skokTyp)
    {
    this.kopniecieTyp = kopniecieTyp;
    this.skokTyp = skokTyp;
  }
  
  override public void przedstaw()
    {
    Console.WriteLine("Jestem Scorpion!");
  }
  
}



class MainClass 
{
  
  public static void Main (string[] args) 
  {

    Console.WriteLine("-- Mortal Kombat --");
    Console.WriteLine();
    
    SkokTyp dlugiSkok = new DlugiSkok();
    SkokTyp krotkiSkok = new KrotkiSkok();
    KopniecieTyp kopniecieLod = new KopniecieLod();
    KopniecieTyp kopniecieOgien = new KopniecieOgien();

    Zawodnik subZero = new SubZero(kopniecieLod, krotkiSkok);
    subZero.przedstaw();
    subZero.uderzenie();
    subZero.kopniecie();
    subZero.skok();
    subZero.ustawSkokTyp(dlugiSkok);
    subZero.skok();
    
    Console.WriteLine();

    Zawodnik scorpion = new Scorpion(kopniecieOgien, dlugiSkok);
    scorpion.przedstaw();
    scorpion.uderzenie();
    scorpion.kopniecie();
    scorpion.ustawKopniecieTyp(kopniecieLod);
    scorpion.kopniecie();
    scorpion.skok();
    
  }
  
}
