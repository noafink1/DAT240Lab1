namespace UiS.Dat240.Lab1.Queues;
using System.Collections;
using System.Collections.Generic;

public interface IGenericQueue<T>
{
    int Length { get; }
    void Enqueue(T value);
    T Dequeue();
}

public class GenericQueue<T> : IGenericQueue<T>, IEnumerable<T> {
    private T[] myArray = new T[1];
    private int arraySize = 0;
    public int Length 
    { 
        get {return arraySize;} 
    }
    public void Enqueue(T value) {
        if(myArray.Length == arraySize) {
            Grow();
        }
        myArray[arraySize] = value;
        arraySize++;
    }
    public T Dequeue() {
        if(arraySize == 0) {
            throw new Exception();
        }
            T firstValue = myArray[0];
            for(int i=0;i<arraySize-1;i++) {
                myArray[i] = myArray[i+1];
            }
            myArray[arraySize-1] = default;
            arraySize--;
            return firstValue;
    }
    private void Grow() {
        T[] oldArray = myArray;
        myArray = new T[arraySize*2];
        for(int i =0;i<oldArray.Length;i++) {
            myArray[i] = oldArray[i];
        } 
    }
    public IEnumerator<T> GetEnumerator() {
        for(int i=0;i<arraySize;i++) {
            yield return myArray[i];
        }
    }
    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}
