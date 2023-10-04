namespace UiS.Dat240.Lab1.Queues;

public interface IObjectQueue
{
    int Length { get; }
    void Enqueue(object value);
    object Dequeue();
}

public class ObjectQueue : IObjectQueue
{
    private object[] _queueQ = Array.Empty<object>();

    // could be _queueQ.Length, but both work
    private int _queueLength = 0;

    public int Length
    {
        get { return _queueLength; }
    }

    public void Enqueue(object value)
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

    public object Dequeue()
    {
        if (Length > 0)
        {
            var copy = new object[_queueQ.Length - 1];

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
}
