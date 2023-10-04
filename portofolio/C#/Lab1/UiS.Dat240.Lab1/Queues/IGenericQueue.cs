using System.Collections;

namespace UiS.Dat240.Lab1.Queues;

public interface IGenericQueue<T> : IEnumerable<T>
{
    int Length { get; }
    void Enqueue(T value);
    T Dequeue();
}

public class GenericQueue<T> : IGenericQueue<T>
{
    private T[] _queueQ = Array.Empty<T>();

    private int _queueLength = 0;

    public int Length
    {
        get { return _queueLength; }
    }

    public void Enqueue(T value)
    {
        if (value != null)
        {
            if (_queueLength >= _queueQ.Length)
            {
                Grow();
            }

            _queueQ[Length] = value;
            _queueLength++;
        }
    }

    public T Dequeue()
    {
        if (Length > 0)
        {
            var copy = new T[_queueQ.Length - 1];

            for (var i = 0; i < _queueQ.Length - 1; i++)
            {
                copy[i] = _queueQ[i + 1];
            }

            var removeEl = _queueQ[0];
            _queueQ = copy;
            _queueLength--;
            return removeEl;
        }
        else
        {
            throw new NullReferenceException();
        }
    }

    private void Grow()
    {
        if (_queueLength == 0)
        {
            Array.Resize(ref _queueQ, 1);
        }

        Array.Resize(ref _queueQ, _queueQ.Length * 2);
    }


    public IEnumerator<T> GetEnumerator()
    {
        for (var i = 0; i < Length; i++)
        {
            yield return _queueQ[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}