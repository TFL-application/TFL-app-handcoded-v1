using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLAppHandcoded
{
    public class ListNode<T>
    {
        private T item ;
        private ListNode<T> next ;

        //public ListNode()
        //{
        //    item = null ;
        //    next = null ;
        //}

        public ListNode( T item )
        {
            this.item = item ;
            this.next = null ;
        }

        public ListNode( T item, ListNode<T> next)
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

        public void setItem( T item ) 
        { 
            this.item = item ; 
        }

        public void setNext( ListNode<T> next ) 
        { 
            this.next = next ; 
        }

        public T getItem() 
        { 
            return this.item ; 
        }

        public ListNode<T> getNext() 
        { 
            return this.next ; 
        }

    }  // ListNode

}
