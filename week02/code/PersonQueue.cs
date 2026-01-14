/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the queue
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
    {
        // FIXED: Add to the end of the list to maintain FIFO order
        _queue.Add(person);
    }

    /// <summary>
    /// Remove and return the first person in the queue
    /// </summary>
    /// <returns>The person removed from the front of the queue</returns>
    public Person Dequeue()
    {
        var person = _queue[0];
        _queue.RemoveAt(0);
        return person;
    }

    /// <summary>
    /// Check if the queue is empty
    /// </summary>
    /// <returns>True if the queue is empty; otherwise, false</returns>
    public bool IsEmpty()
    {
        return Length == 0;
    }

    /// <summary>
    /// Returns a string representation of the queue
    /// </summary>
    /// <returns>A string representing the queue contents</returns>
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}
