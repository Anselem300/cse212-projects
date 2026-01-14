using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// Test cases for PriorityQueue
[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add one item to the queue and remove it
    // Expected Result: The value of the dequeued item should match the item added
    // Defect(s) Found: If Dequeue doesn't return the correct item, the queue logic is broken
    public void TestPriorityQueue_SingleItem()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5); // Single item with priority 5
        var item = pq.Dequeue();
        Assert.AreEqual("A", item);
    }

    [TestMethod]
    // Scenario: Add multiple items with different priorities
    // Expected Result: The item with the highest priority is removed first
    // Defect(s) Found: If Dequeue doesn't pick the highest priority, the priority logic is broken
    public void TestPriorityQueue_HighestPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 3);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 2);

        var item = pq.Dequeue();
        Assert.AreEqual("B", item); // Highest priority is 5

        item = pq.Dequeue();
        Assert.AreEqual("A", item); // Next highest is 3

        item = pq.Dequeue();
        Assert.AreEqual("C", item); // Last is 2
    }

    [TestMethod]
    // Scenario: Add multiple items with the same highest priority
    // Expected Result: The item closest to the front is removed first
    // Defect(s) Found: If FIFO isn't maintained for same priority, test fails
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        var item = pq.Dequeue();
        Assert.AreEqual("A", item); // "A" was first with priority 5

        item = pq.Dequeue();
        Assert.AreEqual("B", item); // "B" is next with same priority

        item = pq.Dequeue();
        Assert.AreEqual("C", item); // Last item
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: If exception is missing or message is wrong
    public void TestPriorityQueue_EmptyQueue()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    // Add more test cases as needed, for example adding items mid-queue, mix of priorities, etc.
}
