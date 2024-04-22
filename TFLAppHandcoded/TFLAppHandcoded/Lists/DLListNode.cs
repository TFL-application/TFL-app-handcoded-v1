using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLAppHandcoded
{
    // Lecture 3
    // Doubly Linked List Node 
    public class DLListNode  // : ListNode
    {
        private Object     item ;
        private DLListNode previous ;
        private DLListNode next ;

        public DLListNode()
        {
            this.item     = null;
            this.next     = null;
            this.previous = null;
        }

        public DLListNode( Object item )
        {
            this.item     = item ;
            this.previous = null ;
            this.next     = null ;
        }

        public DLListNode( Object item, DLListNode previous, DLListNode next )
        {
            this.item     = item ;
            this.previous = previous ;
            this.next     = next ;
        }

        public void setItem( Object item )
        {
            this.item = item ;
        }

        public void setPrevious( DLListNode previous )
        {
            this.previous = previous ;
        }
        public void setNext( DLListNode next )
        {
            this.next = next ;
        }

        public Object getItem()
        {
            return this.item ;
        }

        public DLListNode getNext()
        {
            return this.next ;
        }
        public DLListNode getPrevious()
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


