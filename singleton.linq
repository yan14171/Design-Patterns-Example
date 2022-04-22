<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//singleton

//without locking

var tasks = new List<Task>();
for (int i = 0; i < 20; i++)
{
	tasks.Add(Task.Run(() => SingletonService.Create()));
}
Task.WaitAll(tasks.ToArray());

//basically, every thread can freely enter the creation part, 
//so it would create the amount of instances which is
//equal to the amount of virtual cores on the machine
public class SingletonService
{
	private static int counter = 0;
	private static SingletonService _instance;
	private SingletonService()
	{
		$"Creating number {counter++}".Dump();
	}
	
	public static SingletonService Create()
	{
		if(_instance is null)
			return _instance = new SingletonService();
		return _instance;
	}
}

