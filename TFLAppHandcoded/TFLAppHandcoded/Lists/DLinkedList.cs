using System;

namespace TFLAppHandcoded
{

    public class DLinkedList<T>
    {
        private DLListNode<T>? head;
        private int length;

        public DLinkedList()
        {
            this.head = null;
            this.length = 0;
        }

        public bool IsEmpty() { return this.length == 0; }
        public DLListNode<T>? GetHead() { return this.head; }

        private DLListNode<T>? FindItem(T item)
        {
            DLListNode<T>? current = head;

            while (current != null && !item.Equals(current.GetItem()))
                current = current.GetNext();

            return current;
        }

        public void InsertAtHead(T item)
        {
            DLListNode<T> newItemNode = new DLListNode<T>( item, null, this.head ) ;

            if (this.head != null)
                this.head.SetPrevious(newItemNode);

            this.head = newItemNode;
            this.length++;
        }

        public bool InsertAfter(T newItem, T afterItem)
        {
            DLListNode<T>? afterNode = FindItem(afterItem);

            if (afterNode != null)
            {
                DLListNode<T> newItemNode = new DLListNode<T>(newItem, afterNode, afterNode.getNext());

                newItemNode.GetPrevious().SetNext(newItemNode);

                if (newItemNode.GetNext() != null)
                    newItemNode.GetNext().SetPrevious( newItemNode );

                this.length++;
                return true;
            }
            return false;
        }

        public void InsertAtTail(T newItem)
        {
            if (!this.IsEmpty())
            {
                DLListNode<T>? lastNode = this.head;
                for (int i = 1; i < this.length; i++)
                    lastNode = lastNode.GetNext();

                lastNode.SetNext(new DLListNode<T>(newItem, lastNode, null));
            }
            else
            {
                this.InsertAtHead(newItem);
            }

            this.length++;
        }

        public bool DeleteItem(T deleteItem)
        {
            DLListNode<T>? deleteItemNode = FindItem(deleteItem);

            if (deleteItemNode != null)
            {
                DLListNode<T>? previousNode = deleteItemNode.GetPrevious();
                DLListNode<T>? nextNode = deleteItemNode.GetNext();

                if (deleteItemNode == this.head)
                {
                    this.head = nextNode;
                    if (nextNode != null)
                        deleteItemNode.SetPrevious(null);
                }
                else if (nextNode == null)
                {
                    previousNode.SetNext(null);
                }
                else
                {
                    previousNode.SetNext(nextNode);
                    nextNode.SetPrevious(previousNode);
                }
       
                length--; 
                return true;
            }
            return false;
        }
    }
}