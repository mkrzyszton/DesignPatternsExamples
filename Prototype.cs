using System;
using System.Collections.Generic;


public abstract class ProductPrototype
{
    public decimal _price;

    public ProductPrototype(decimal price)
    {
        this._price = price;
    }

    public ProductPrototype Clone()
    {
        return (ProductPrototype)this.MemberwiseClone();
    }

}


public class Bread : ProductPrototype
{

    public Bread(decimal price) : base(price) { }

}

public class Butter : ProductPrototype
{

    public Butter(decimal price) : base(price) { }

}


public class Supermarket
{

    private Dictionary<string, ProductPrototype> _productList = new Dictionary<string, ProductPrototype>();

    public void AddProduct(string key, ProductPrototype productPrototype)
    {
        _productList.Add(key, productPrototype);
    }

    public ProductPrototype GetClonedProduct(string key)
    {
        return _productList[key].Clone();
    }

}

class MainClass
{

    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Supermarket supermarket = new Supermarket();
        ProductPrototype product;

        supermarket.AddProduct("bread", new Bread(9.50m));
        supermarket.AddProduct("butter", new Butter(5.30m));

        product = supermarket.GetClonedProduct("bread");
        decimal discount = (product._price * 0.9m);
        Console.WriteLine(String.Format("Bread - {0} zł > {1} zł\n", product._price, discount.ToString("F2")));

        product = supermarket.GetClonedProduct("bread");
        Console.WriteLine(String.Format("Bread - {0} zł\n", product._price));

        product = supermarket.GetClonedProduct("butter");
        Console.WriteLine(String.Format("Butter - {0} zł", product._price));

    }

}