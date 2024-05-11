using System;
namespace TFLAppHandcoded
{
    public class LinkedList<T>
    {
        protected ListNode<T>? head;
        protected int length;

        public LinkedList()
        {
            this.head   = null ;
            this.length = 0 ;
        }

        public bool IsEmpty() { return this.length == 0; }
        public int GetLength() { return this.length; }
        public ListNode<T>? GetHead() { return this.head; }

        public ListNode<T>? FindItem(T item)
        {
            if (!this.IsEmpty())
            {
                ListNode<T>? current = this.head;

                while (current != null)
                {
                    if (current.GetItem().Equals(item))
                        return current;

                    current = current.GetNext();
                }
            }
            return null;
        }

        public bool IsItemIn(T item)
        {
            if (this.FindItem(item) != null)
                return true;

            return false;
        }

        public void InsertAtHead( T item )
        {
            ListNode<T> newItem = new ListNode<T>( item, this.head ) ;
            this.head = newItem ;
            this.length++;
        }

        public bool InsertAfter( T newItem, T afterItem )
        {
            ListNode<T>? afterNode = FindItem( afterItem ) ;

            if ( afterNode != null )
            {
                ListNode<T> newItemNode = new ListNode<T>( newItem, afterNode.GetNext() ) ;

                afterNode.SetNext( newItemNode ) ;

                this.length++ ;

                return true ;
            }
            return false ;
        }

        public void InsertAtTail(T item)
        {
            ListNode<T>? lastNode = this.head;
            for (int i = 1; i < length; i++)
            {
                lastNode = lastNode.GetNext();
            }

            lastNode.SetNext(new ListNode<T>(item));
            this.length++;
        }

        public T? DeleteHead()
        {
            T? deletedItem = this.head.GetItem();
            this.head = this.head.GetNext();
            this.length--;
            return deletedItem;
        }

        public bool DeleteItem(T item)
        {
            if (this.length == 0)
                return false;

            if (this.head.GetItem().Equals(item))
            {
                this.head = this.head.GetNext();
                length--;
                return true;
            }

            ListNode<T> currentNode = this.head;
            ListNode<T> nextNode = currentNode.GetNext();
            while (nextNode != null)
            {
                if (nextNode.GetItem().Equals(item))
                {
                    currentNode.SetNext(nextNode.GetNext());
                    length--;
                    return true;
                }

                currentNode = nextNode;
                nextNode = nextNode.GetNext();
            }
            return false;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.length];
            ListNode<T> currentNode = this.head;
            int i = 0;

            while (currentNode != null)
            {
                array[i] = currentNode.GetItem();
                currentNode = currentNode.GetNext();
                i++;
            }

            return array;
        }
    }
}