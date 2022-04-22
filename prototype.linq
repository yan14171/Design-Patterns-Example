<Query Kind="Statements" />

//prototype


CarFactory.GetAuto("semi").Dump();
CarFactory.GetAuto("family").Dump();


class Auto
{
	public Auto(string Number)
	{
		this.Number = Number;
	}
	public string Number { get; set; }
	public virtual Auto Clone()
	{
		return new Auto(this.Number);
	}
}

class Semi : Auto
{
	public int WheelCount { get; set; }
	public Semi(string Number, int WheelCount) :
	base(Number)
	{
		this.WheelCount = WheelCount;
	}
	public override Auto Clone()
	{
		return new Semi("<generate number>", this.WheelCount);
	}
	public override string ToString()
	{
		return $"Big semi with {WheelCount} wheels";
	}
}

class Family : Auto
{
	public int Places { get; set; }
	public Family(string Number, int Places) :
	base(Number)
	{
		this.Places = Places;
	}
	public override Auto Clone()
	{
		return new Semi("<generate number>", this.Places);
	}
	public override string ToString()
	{
		return $"Comfy car for the family of {Places}";
	}
}

static class CarFactory
{
	private static Dictionary<string, Auto> protos;
	static CarFactory()
	{
		protos = new Dictionary<string, Auto>
		{
			{"semi", new Semi("", 8)},
			{"family", new Family("", 4)}
		};		
	}
	public static Auto GetAuto(string type)
	{
		var proto = protos[type];
		return proto.Clone();
	}
}
