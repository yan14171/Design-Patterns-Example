<Query Kind="Statements" />

//Obviously, this StringBuilder implementation holds no performance gains, 
//which are in place in C# native one, it simply demonstrates how to use this pattern


var builder = new MyStringBuilder("1");
for (int i = 2; i < 10; i++)
{
	builder.Append(i.ToString());
}
builder.Build().Dump();


interface IStringBuilder
{
	public IStringBuilder Append(string value);
}
class MyStringBuilder : IStringBuilder
{
	private string _value;
	public MyStringBuilder(string init = "")
	{
		_value = init;
	}
	public IStringBuilder Append(string value)
	{
		_value = $"{_value} {value}";
		return this;
	}	
	public string Build() => _value;
}