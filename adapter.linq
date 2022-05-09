<Query Kind="Statements" />

//adapter
// If you have a generic dependency in multiple services, replace it with an interface
// than implement this interface as a class, that takes the depend. as a parameter or inherites it
// This helps to change the dependency if needed and still have the same unbroken interface in your code#
//#define before
#if before
#region before
class ImportantDependency
{
	public void DoSomething()
	{
		Console.WriteLine("Doing something important");
	}
}

class Service{
	private ImportantDependency _dep;
	public Service(ImportantDependency dep)
	{
		this._dep = dep
	}
	public void BusinessCall1()
	{
		Console.WriteLine("Doing stuff in Service...");
		this._dep.DoSomething();
	}
}

class Service1
{
	private ImportantDependency _dep;
	public Service1(ImportantDependency dep)
	{
		this._dep = dep
	}
	public void BusinessCall2()
	{
		Console.WriteLine("Doing stuff in Service1...");
		this._dep.DoSomething();
	}
}
#endregion
#else
#region after
interface IImportantDependency
{
	public void DoSomething();
}

class ObjectAdapter : IImportantDependency
{
	private ImportantDependency _dep;
	public ObjectAdapter(ImportantDependency dep)
	{
		this._dep = dep;
	}
	//Here we use the dependency on concrete realisation 
	//Than we can just change _dep to something else and call another method
	//This is now the only place on which our services depend
	public void DoSomething()
	{
		this._dep.DoSomething();
	}
}

class ImportantDependency
{
	public void DoSomething()
	{
		Console.WriteLine("Doing something important");
	}
}

class Service
{
	private IImportantDependency _dep;
	public Service(IImportantDependency dep)
	{
		this._dep = dep;
	}
	public void BusinessCall1()
	{
		Console.WriteLine("Doing stuff in Service...");
		this._dep.DoSomething();
	}
}

class Service1
{
	private IImportantDependency _dep;
	public Service1(IImportantDependency dep)
	{
		this._dep = dep;
	}
	public void BusinessCall2()
	{
		Console.WriteLine("Doing stuff in Service1...");
		this._dep.DoSomething();
	}
}
#endregion
#endif