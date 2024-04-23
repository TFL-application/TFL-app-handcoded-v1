using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLAppHandcoded
{
    // Lecture 3
    // Doubly Linked List Node 
    public class DLListNode<T>  // : ListNode
    {
        private T item ;
        private DLListNode<T> previous ;
        private DLListNode<T> next ;

        public DLListNode()
        {
            //this.item     = null;
            //this.next     = null;
            //this.previous = null;
        }

        public DLListNode( T item )
        {
            this.item     = item ;
            this.previous = null ;
            this.next     = null ;
        }

        public DLListNode( T item, DLListNode<T> previous, DLListNode<T> next )
        {
            this.item     = item ;
            this.previous = previous ;
            this.next     = next ;
        }

        public void setItem( T item )
        {
            this.item = item ;
        }

        public void setPrevious( DLListNode<T> previous )
        {
            this.previous = previous ;
        }
        public void setNext( DLListNode<T> next )
        {
            this.next = next ;
        }

        public T getItem()
        {
            return this.item ;
        }

        public DLListNode<T> getNext()
        {
            return this.next ;
        }
        public DLListNode<T> getPrevious()
        {
            return this.previous ;
        }

        public void print()
        {
            // print "NULL" if a variable is "null"
            string itemValue     = ( item     == null ? "NULL" : item.ToString() ) ;

            string previousValue = ( previous == null ? "NULL" : previous.getItem().ToString() ) ;

            string nextValue     = ( next     == null ? "NULL" : next.getItem().ToString() ) ; 


            Console.WriteLine( "DLLnode[ item = " + itemValue     + ", \t" +
                               "previous --> "    + previousValue + ", \t" +
                               "next --> "        + nextValue            + " ]" ) ;

        }

    } // DLListNode

} // Lecture 3


