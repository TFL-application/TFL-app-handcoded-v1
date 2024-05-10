using System;

namespace TFLAppHandcoded
{
    public class WeightedLinkedList<O, W>
    {
        public WeightedListNode<O, W>? head;   // points to the head of the list
        public int length;      // number of nodes in the list

        public WeightedLinkedList()
        {
            this.head = null;
            this.length = 0;
        }

        public WeightedLinkedList(O firstItem, W itemWeight)
        {
            this.head = new WeightedListNode<O, W>(firstItem, itemWeight);
            this.length = 1;
        }

        public bool IsEmpty() { return this.length == 0; }
        public int GetLength() { return this.length; }
        public WeightedListNode<O, W>? GetHead() { return this.head; }

        public WeightedListNode<O, W>? FindItem(O item)
        {
            if (!IsEmpty())
            {
                WeightedListNode<O, W>? current = this.head;

                while (current != null && !item.Equals(current.GetItem()))
                    current = current.GetNext();

                return current;
            }
            return null;
        }

      
        public W? FindNodeWeight(O item)
        {
            if (!IsEmpty())
            {
                WeightedListNode<O, W>? current = this.head;

                while (current != null && !item.Equals(current.GetItem()))
                    current = current.GetNext();

                if (current != null)
                    return current.GetWeight();
            }
            Console.WriteLine($"Item with value  {item} not found");
            return default;
        }

        public void InsertAtHead(O item, W weight)
        {
            WeightedListNode<O, W> newItem = new WeightedListNode<O, W>(item, weight, this.head);
            this.head = newItem;
            this.length++;
        }

        public bool InsertAfter(O newItem, W newItemWeight, O afterItem)
        {
            WeightedListNode<O, W>? afterNode = FindItem(afterItem);

            if (afterNode != null)  
            {
                WeightedListNode<O, W> newItemNode =
                    new WeightedListNode<O, W>(newItem, newItemWeight, afterNode.GetNext());

                afterNode.SetNext(newItemNode);
                this.length++;
                return true;
            }
            return false;
        }

        public void InsertAtTail(O newItem, W newItemWeight)
        {
            if (!this.IsEmpty())
            {
                WeightedListNode<O, W>? lastNode = this.head;
                for (int i = 1; i < this.length; i++)
                    lastNode = lastNode.GetNext();

                lastNode.SetNext(new WeightedListNode<O, W>(newItem, newItemWeight));
            }
            else
            {
                this.InsertAtHead(newItem, newItemWeight);
            }

            this.length++;
        }

        public O? DeleteHead()
        {
            O? deletedItem = this.head.GetItem();
            this.head = this.head.GetNext();
            this.length--;
            return deletedItem;
        }

        public void PrintList()
        {
            WeightedListNode<O, W> currentNode = this.head;
            Console.WriteLine($"List Length: {this.length}");
            for (int i = 1; i <= this.length; i++)
            {
                Console.WriteLine($"{i}. " +
                    $"Object: {currentNode.GetItem().ToString()}, " +
                    $"Weight: {currentNode.GetWeight().ToString()}");
                currentNode = currentNode.GetNext();
            }
        }

        public void ReverseList()
        {
            if (this.length > 1)
            {
                WeightedListNode<O, W> currentNode = this.head;
                WeightedListNode<O, W> nextNode = currentNode.GetNext();

                currentNode.SetNext(null);

                while (nextNode != null)
                {
                    currentNode = nextNode;
                    nextNode = nextNode.GetNext();
                    currentNode.SetNext(this.head);
                    this.head = currentNode;
                }
            }
        }

        public override string ToString()
        {
            WeightedListNode<O, W> currentNode = this.head;
            string s = $"Head: {currentNode.GetItem().ToString()} / {currentNode.GetWeight().ToString()}";
            currentNode = currentNode.GetNext();
            for (int i = 1; i < this.length; i++)
            {
                s = s + $" -> {currentNode.GetItem().ToString()} / {currentNode.GetWeight().ToString()}";
                currentNode = currentNode.GetNext();
            }
            return s;
        }
    } 
}
