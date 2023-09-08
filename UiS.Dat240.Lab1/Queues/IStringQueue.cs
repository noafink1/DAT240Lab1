namespace UiS.Dat240.Lab1.Queues;

public interface IStringQueue
{
    int Length { get; }
    void Enqueue(string value);
    string Dequeue();
}

public class StringQueue : IStringQueue {
    private string[] myArray = new string[1];
    private GenericQueue<string> internalQueue = new GenericQueue<string>(); 
    public int Length 
    { 
        get {return internalQueue.Length;} 
    }
    public void Enqueue(string value) {
        internalQueue.Enqueue(value);
    }
    public string Dequeue() {
        return internalQueue.Dequeue();
    }
}
