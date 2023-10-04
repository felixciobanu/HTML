using System.Collections;

namespace UiS.Dat240.Lab1.Queues;

public interface IStringQueue
{
    int Length { get; }
    void Enqueue(string value);
    string Dequeue();
}

public class StringQueue : IStringQueue
{
    private readonly ObjectQueue _alternativeQueue = new ObjectQueue();
    private string[] _queueQ = Array.Empty<string>();

    

    public int Length
    {
        get { return _alternativeQueue.Length; }
    }

    public void Enqueue(string value)
    {
        _alternativeQueue.Enqueue(value);
    }

    public string Dequeue()
    {
        return (string)_alternativeQueue.Dequeue();
    }

    public void Grow()
    {
        if (_alternativeQueue.Length == 0)
        {
            Array.Resize(ref _queueQ, 1);
        }
        Array.Resize(ref _queueQ, _queueQ.Length * 2);
    }
}
/*
public class StringQueue : IStringQueue
{
    private string[] _queueQ = Array.Empty<string>();

    private int _queueLength = 0;

    public int Length
    {
        get { return _queueLength; }
    }

    public void Enqueue(string value)
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

    public string Dequeue()
    {
        if (Length > 0)
        {
            var removeEl = _queueQ.First();
            _queueQ = _queueQ.Skip(1).ToArray();
            _queueLength--;
            return removeEl;
        }
        else
        {
            throw new NullReferenceException();
        }
    }

    public void Grow()
    {
        if (_queueLength == 0)
        {
            Array.Resize(ref _queueQ, 1);
        }
        Array.Resize(ref _queueQ, _queueQ.Length * 2);
    }
}
*/