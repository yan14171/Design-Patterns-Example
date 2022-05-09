<Query Kind="Statements" />

//decorator

var a = new TextNode("Some text");
a.Draw(0, 0);
"".Dump();
var b = new ItalicNode(a);
b.Draw(0, 0);
"".Dump();
var c = new BoldNode(b);
c.Draw(0, 0);
"".Dump();

interface Node
{
	public void Draw(int x, int y);
}

class TextNode : Node // Node {void Draw()}
{
	public TextNode(string text)
	{
		this._text = text;
	}
	private string _text;

	public void Draw(int x, int y)
	{
		Console.WriteLine($"Printing {_text} at {x} {y}");
	}
}

class ItalicNode : Node
{
	private Node _node;
	public ItalicNode(Node node)
	{
		this._node =  node;
	}
	
	public void Draw(int x, int y)
	{
		Console.WriteLine("Setting Italic");
		_node.Draw(x, y);
	}
}

class BoldNode : Node
{
	private Node _node;
	public BoldNode(Node node)
	{
		this._node = node;
	}

	public void Draw(int x, int y)
	{
		Console.WriteLine("Setting Bold");
		_node.Draw(x, y);
	}
}

