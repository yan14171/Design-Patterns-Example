<Query Kind="Statements" />

//chain of responsibility

var genericHandler = new GenericHandler();
var suffixHandler = new SuffixQuoteHandler(genericHandler);
var prefixHandler = new PrefixQuoteHandler(genericHandler);
var presuffixHandler = new PrefixQuoteHandler(suffixHandler);
presuffixHandler.Handle("\"Prefixed");
presuffixHandler.Handle("Clear");
presuffixHandler.Handle("Suffixed\"");
presuffixHandler.Handle("\"Both\"");

interface IHandler
{
	public void Handle(string request);
}
class GenericHandler : IHandler
{
	public void Handle(string request)
	{
		$"Generically handling {request}".Dump();
	}
}
class PrefixQuoteHandler : IHandler
{
	private IHandler _higherHandler { get; set; }
	public PrefixQuoteHandler(IHandler higherHandler)
	{
		this._higherHandler = higherHandler;
	}
	public void Handle(string request)
	{
		if (request.StartsWith("\""))
			$"Handling prefix {request}".Dump();
		else 
			this._higherHandler.Handle(request);
	}
}
class SuffixQuoteHandler : IHandler
{
	private IHandler _higherHandler { get; set; }
	public SuffixQuoteHandler (IHandler higherHandler)
	{
		this._higherHandler = higherHandler;
	}
	public void Handle(string request)
	{
		if (request.EndsWith("\""))
			$"Handling suffix {request}".Dump();
		else
			this._higherHandler.Handle(request);
	}
}

