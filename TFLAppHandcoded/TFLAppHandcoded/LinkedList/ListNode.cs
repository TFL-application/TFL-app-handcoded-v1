using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists_Week3
{
    class ListNode
    {
        private Object item ;
        private ListNode next ;

        public ListNode()
        {
            item = null ;
            next = null ;
        }

        public ListNode( Object item )
        {
            this.item = item ;
            this.next = null ;
        }

        public ListNode( Object item, ListNode next)
        {
            this.item = item ;
            this.next = next ;
        }

        public void print()
        {
            Console.Write($"The node value: {item.ToString()}, the next node value");
            if (next != null)
            {
                Object nextValue = next.getItem();
                Console.WriteLine($": {nextValue.ToString()}");
            }
            else
            {
                Console.WriteLine($" is null");
            }
        }

        public void setItem( Object item ) 
        { 
            this.item = item ; 
        }

        public void setNext( ListNode next ) 
        { 
            this.next = next ; 
        }

        public Object getItem() 
        { 
            return this.item ; 
        }

        public ListNode getNext() 
        { 
            return this.next ; 
        }

    }  // ListNode

}
