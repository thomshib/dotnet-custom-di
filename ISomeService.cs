
public interface ISomeService{

    void PrintMessage();
}


public class SomeServiceOne : ISomeService
{
    private readonly IRandomGuidProvider _provider;

    public SomeServiceOne(IRandomGuidProvider provider)
    {
        _provider = provider;
    }
    public void PrintMessage()
    {
        Console.WriteLine(_provider.RandomGuid.ToString());
    }
}