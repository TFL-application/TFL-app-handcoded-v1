using System;
namespace TFLAppHandcoded
{
    public class ListNode<T>
    {
        private T? item ;
        private ListNode<T>? next ;

        public ListNode(T item)
        {
            this.item = item ;
            this.next = null ;
        }

        public ListNode(T item, ListNode<T>? next)
        {
            this.item = item ;
            this.next = next ;
        }

        public void SetItem( T? item ) {  this.item = item ; }
        public void SetNext( ListNode<T>? next ) { this.next = next ; }

        public T? GetItem() { return this.item ; }
        public ListNode<T>? GetNext() { return this.next ; }
    } 
}