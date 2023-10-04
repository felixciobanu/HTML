using System;
using Microsoft.Extensions.DependencyInjection;
using UiS.Dat240.Lab1.Commands;
using UiS.Dat240.Lab1.Queues;

namespace UiS.Dat240.Lab1;

/// <summary>
/// This is a holder class which holds
/// the submissions for the different tasks
/// </summary>
public static class TestSubmissions
{
    // This is a test endpoint, make this function
    // return an instance of your implementation
    public static IStringQueue CreateStringQueue()
    {
        // TODO: Implement
        return new StringQueue();
    }

    public static IObjectQueue CreateObjectQueue()
    {
        // TODO: Implement
        return new ObjectQueue();
    }

    public static IGenericQueue<T> CreateGenericQueue<T>()
    {
        // TODO: Implement
        return new GenericQueue<T>();
    }

    public static IServiceProvider CreateServiceProvider()
    {
        // TODO: Implement
        // Creating a new collection or list of recipes on how to create classes.
        var collection = new ServiceCollection();
        
        // Register an interface in the container, which uses class to implement it
        // Singleton creates the class one time and returns the same class
        collection.AddSingleton<IStringQueue, StringQueue>();
        collection.AddSingleton<IObjectQueue, ObjectQueue>();
        collection.AddSingleton<IGenericQueue<string>, GenericQueue<string>>();
        collection.AddSingleton<ICommandHandler,AddHandler>();
        collection.AddSingleton<ICommandHandler,RemHandler>();
        collection.AddSingleton<ICommandHandler,SizeHandler>();
        var provider = collection.BuildServiceProvider(true);

        return provider;
    }
}
