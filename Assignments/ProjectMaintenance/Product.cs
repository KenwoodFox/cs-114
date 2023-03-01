using System;

public class Product
{
	private string code, desc;
	private decimal price;

	public Product(string code, string description, decimal price)
	{
		this.code = code;
		this.desc = description;
		this.price = price;
	}

	public string Code
	{
		get { return code; }
		set { code = value; }
	}

    public string Description
    {
        get { return desc; }
        set { desc = value; }
    }

    public decimal Price
    {
        get { return price; }
        set { price = value; }
    }
}
