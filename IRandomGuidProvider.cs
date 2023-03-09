

public interface IRandomGuidProvider{

    Guid RandomGuid{get;}
}

public class RandomGuidProvider : IRandomGuidProvider
{
    public Guid RandomGuid => Guid.NewGuid();
}