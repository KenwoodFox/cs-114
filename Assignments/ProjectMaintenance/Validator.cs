using System;

public class Validator
{
	public Validator()
	{
	}

	public static string IsPresent(string value, string name)
	{
		string msg = "";
		if (value == "") { msg += name + " is a required field. \n"; }
		return msg;
	}

	public static string IsDecimal(string value, string name)
	{
		string msg = "";
		if(!Decimal.TryParse(value, out decimal d)) { msg += name + " must be a valid decimal value"; }
		return msg;
	}
}
