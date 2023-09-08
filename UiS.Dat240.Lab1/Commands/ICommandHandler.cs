using System.Windows.Input;
using UiS.Dat240.Lab1.Queues;

namespace UiS.Dat240.Lab1.Commands;

public interface ICommandHandler
{
    string Name { get; }
    void Handle(string args);
}

public class AddHandler : ICommandHandler {
    public string Name => "add";
    private readonly IStringQueue stringQueue;
    // Constructor
    public AddHandler(IStringQueue stringQueue) {
        this.stringQueue = stringQueue;
    }

    // The function to be executed when the user writes the command name
    public void Handle(string args) {
        stringQueue.Enqueue(args);
    }
}

public class RemHandler : ICommandHandler {
    public string Name => "rem";
    private readonly IStringQueue stringQueue;
    // Constructor
    public RemHandler(IStringQueue stringQueue) {
        this.stringQueue = stringQueue;
    }
    public void Handle(string args) {
        try {
            Console.WriteLine(stringQueue.Dequeue());
        } catch(Exception) {
            Console.WriteLine("Queue is empty");
        }
        
    }
}

public class SizeHandler : ICommandHandler {
    public string Name => "size";
    private readonly IStringQueue stringQueue;
    public SizeHandler(IStringQueue stringQueue) {
        this.stringQueue = stringQueue;
    }
    public void Handle(string args) {
        Console.WriteLine(stringQueue.Length);
    }
}
