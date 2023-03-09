

public class DIContainer
{
    private List<ServiceDescriptor> _serviceDescriptors;

    public DIContainer(List<ServiceDescriptor> serviceDescriptors)
    {
        this._serviceDescriptors = serviceDescriptors;
    }


    internal object GetService(Type serviceType){

        var descriptor = _serviceDescriptors.SingleOrDefault( x => x.ServiceType == serviceType);

        if(descriptor == null){
            throw new Exception($" Service of type {serviceType.Name} is not registered");
        }

        if(descriptor.Implementation != null){
            return descriptor.Implementation;
        }

        // implementation is null here

        var actualtype  = descriptor.ImplementationType ?? descriptor.ServiceType;

        if(actualtype.IsAbstract || actualtype.IsInterface){
            throw new Exception("Cannot instantiate abstract class or interfaces");
        }

        //Get the constructor and constructor params to create constructor injected dependencies
        var constructorInfo = actualtype.GetConstructors().First();

        //recursively create constructor injected dependencies
        var parameters = constructorInfo.GetParameters()
            .Select( x => GetService(x.ParameterType)).ToArray();

        var implementation = Activator.CreateInstance(actualtype,parameters);

        if(descriptor.Lifetime == ServiceLifetime.Singleton) descriptor.Implementation = implementation;

        return implementation;


    }
    internal T GetService<T>()
    {
        return (T) GetService(typeof(T));
    }
}