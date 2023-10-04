using UiS.Dat240.Lab1.Queues;

namespace UiS.Dat240.Lab1.Commands;

public interface ICommandHandler
{
    string Name { get; }
    void Handle(string args);
}
// Example of setup of the AddHandler class
public class AddHandler : ICommandHandler
{
    // The name of the command
    public string Name => "add";

    private readonly IStringQueue _stringQueue;
    // Since we are going to register the AddHandler in the dependency injection, 
    // then we can request other service from DI as constructor parameters.
    // This is the constructor of the class
    public AddHandler(IStringQueue stringQueue)
    {
        // The request service should also be stored and used later in the class
        _stringQueue = stringQueue;
    }

    // The function to be executed when the user write the command name
    public void Handle(string args)
    {
        // Implement command handler functionality.
        _stringQueue.Enqueue(args);
    }
}
public class RemHandler : ICommandHandler
{
    // The name of the command
    public string Name => "rem";

    private readonly IStringQueue _stringQueue;
    public RemHandler(IStringQueue stringQueue)
    {
        // The request service should also be stored and used later in the class
        _stringQueue = stringQueue;
    }

    // The function to be executed when the user write the command name
    public void Handle(string args)
    {
        // Implement command handler functionality.
        try{
            Console.WriteLine(_stringQueue.Dequeue());
        }
        catch{
            Console.Write("empty array");
        }
    }
}
public class SizeHandler : ICommandHandler
{
    // The name of the command
    public string Name => "size";

    private readonly IStringQueue _stringQueue;
    public SizeHandler(IStringQueue stringQueue)
    {
        // The request service should also be stored and used later in the class
        _stringQueue = stringQueue;
    }

    // The function to be executed when the user write the command name
    public void Handle(string args)
    {
        // Implement command handler functionality.
       Console.Write(_stringQueue.Length); 
    }
}
