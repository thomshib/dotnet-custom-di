public class DIServiceCollection{

    private readonly List<ServiceDescriptor> _serviceDescriptors = new List<ServiceDescriptor>();

    internal void RegisterTransient<TService, TImplementation>()
    {
       _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient));

    }

     internal void RegisterSingleton<TService, TImplementation>()
    {
       _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Singleton));
       
    }

    internal DIContainer GenerateContainer()
    {
        return new DIContainer(_serviceDescriptors);
    }
}