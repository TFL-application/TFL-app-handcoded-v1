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

        private ListNode<T>? FindItem(T item)
        {
            if (!this.IsEmpty())
            {
                ListNode<T>? current = this.head;

                while ((current != null) && (!(item.Equals(current.GetItem()))))
                {
                    current = current.GetNext();
                }

                return current;
            }
            return null;
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
    }
}