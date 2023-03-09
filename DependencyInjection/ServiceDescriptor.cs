public class ServiceDescriptor
{
    public Type ServiceType { get; internal set; }
    public Type ImplementationType { get; internal set; }
    public object Implementation { get;  internal set;}
    public ServiceLifetime Lifetime { get; set; }

    public ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifetime lifetime)
    {
        this.ServiceType = serviceType;
        this.ImplementationType = implementationType;
        this.Lifetime = lifetime;
    }

 
}