using System;

namespace TFLAppHandcoded
{
    public class WeightedLinkedList<O, W>
    {
        protected WeightedListNode<O, W>? head;   // points to the head of the list
        protected int length;      // number of nodes in the list

        public WeightedLinkedList()
        {
            this.head = null;
            this.length = 0;
        }

        public bool IsEmpty() { return this.length == 0; }
        public WeightedListNode<O, W>? GetHead() { return this.head; }

        private WeightedListNode<O, W>? FindItem(O item)
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
    } 
}
