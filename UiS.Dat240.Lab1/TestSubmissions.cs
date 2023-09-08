using System;
using System.Xml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
        return new StringQueue();
    }

    public static IObjectQueue CreateObjectQueue()
    {
        return new ObjectQueue();
    }

    public static IGenericQueue<T> CreateGenericQueue<T>()
    {
        return new GenericQueue<T>();
    }

    public static IServiceProvider CreateServiceProvider()
    {
        // Creating a new collection/list of recipes on how to create classes
        var collection = new ServiceCollection();

        collection.AddSingleton<IStringQueue, StringQueue>();
        collection.AddSingleton<IObjectQueue, ObjectQueue>();
        collection.AddSingleton<IGenericQueue<string>, GenericQueue<string>>(); 
        collection.AddTransient<ICommandHandler,AddHandler>();
        collection.AddTransient<ICommandHandler,RemHandler>();
        collection.AddTransient<ICommandHandler,SizeHandler>();
        return collection.BuildServiceProvider();
    }
}
