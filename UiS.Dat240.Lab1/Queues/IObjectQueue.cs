namespace UiS.Dat240.Lab1.Queues;

public interface IObjectQueue
{
    int Length { get; }
    void Enqueue(object value);
    object Dequeue();
}

public class ObjectQueue : IObjectQueue {
    private object[] myArray = new object[1];
    private GenericQueue<object> internalQueue = new GenericQueue<object>();
    public int Length 
    { 
        get {return internalQueue.Length;} 
    }
    public void Enqueue(object value) {
        internalQueue.Enqueue(value);
    }
    public object Dequeue() {
        return internalQueue.Dequeue();
    }
}
