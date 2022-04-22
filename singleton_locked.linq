<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//singleton with locks

var tasks = new List<Task>();
for (int i = 0; i < 20; i++)
{
	tasks.Add(Task.Run(() => SingletonService.Create()));
}
Task.WaitAll(tasks.ToArray());

public class SingletonService
{
	private static object lockObj = new object();
	private static int counter = 0;
	private static SingletonService _instance;
	
	private SingletonService()
	{
		$"Creating number {counter++}".Dump();
	}

	public static SingletonService Create()
	{
		if (_instance is null)
		{
			lock (lockObj)
				if (_instance is null)
					return _instance = new SingletonService(); 
		}
		return _instance;
	}
}

