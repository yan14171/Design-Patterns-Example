<Query Kind="Statements" />

//composite

var nodes = new CompositeNode("Composite1")
	.Fill(new List<INode>
	{
	new UnitNode("unit1"),
	new CompositeNode("Composite2")
		.Fill(new List<INode>
		{
			new UnitNode("unit2_1")
		})
	});
//
//
//      N
//   CN  
// CN 
//   N
//
//
//

nodes.ComputeNames().Dump();
interface INode
{
	public string Name { get; set; }
	
	public string ComputeNames();
}

class UnitNode : INode
{
	public string Name { get; set; }
	
	public UnitNode(string name)
	{
		this.Name = name;
	}
	
	public string ComputeNames(){
		return Name;
	}
}

class CompositeNode : INode
{
	public string Name { get; set; }

	public List<INode> Nodes { get; set; }
	
	public CompositeNode(string name)
	{
		this.Name = name;
		Nodes = new List<INode>();
	}

	public string ComputeNames()
	{
		var builder = new StringBuilder($"Composite {{{Name}}}:"+'\n');
		foreach (var element in Nodes)
		{
			builder.Append(element.ComputeNames() + '\n');
		}
		return builder.ToString();
	}

	public CompositeNode Fill(List<INode> inner)
	{
		Nodes.AddRange(inner);
		return this;
	}
}