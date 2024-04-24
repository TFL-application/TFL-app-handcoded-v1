using System;
namespace TFLAppHandcoded
{
    public class DLListNode<T> 
    {
        private T? item ;
        private DLListNode<T>? previous ;
        private DLListNode<T>? next ;

        public DLListNode( T item )
        {
            this.item     = item ;
            this.previous = null ;
            this.next     = null ;
        }

        public DLListNode(T item, DLListNode<T>? previous, DLListNode<T>? next)
        {
            this.item     = item ;
            this.previous = previous ;
            this.next     = next ;
        }

        public void SetItem( T? item ) { this.item = item ; }
        public void SetPrevious( DLListNode<T>? previous ) { this.previous = previous ; }
        public void SetNext( DLListNode<T>? next ) { this.next = next ; }

        public T? GetItem() {  return this.item ; }
        public DLListNode<T>? GetNext() { return this.next ; }
        public DLListNode<T>? GetPrevious() {  return this.previous ; }
    } 
}