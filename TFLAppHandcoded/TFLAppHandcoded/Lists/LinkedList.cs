using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLAppHandcoded
{
    public class LinkedList
    {
        protected ListNode head   = null ;   // points to the head of the list
        protected int      length = 0 ;      // number of nodes in the list

        public LinkedList()
        {
            head   = null ;   // empty list
            length = 0 ;      // no nodes in the list
        }

        public int GetLength() { return length; }
        public Object GetHeadValue() { return head.getItem(); }

        public bool isEmpty()
        {
            return ( length == 0 ) ;       // or ( head == null )
        }

        public void insertAtHead( Object item )
        {
            ListNode newItem = new ListNode( item, head ) ;  // .next ) ;

            head = newItem ;

            length++;
        }

        // *** HAS A BUG? - so use Equals not != in while ***
        private ListNode findItem(Object item )
        {
            if ( !isEmpty() )
            {
                ListNode current = head ;

                while ( (current != null) && ( !( item.Equals( current.getItem() ) ) ) )
                {
                    Console.WriteLine();
                    Console.WriteLine("findItem: current.item = " + current.getItem().ToString());
                    Console.WriteLine();

                    current = current.getNext();
                }

                Console.WriteLine();
                Console.WriteLine("findItem: current.item = " + current.getItem().ToString());
                Console.WriteLine();

                return current ;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("findItem: afterNode = null");
                Console.WriteLine();

                return null;
            }
        }

        public bool insertAfter(Object newItem, Object afterItem )
        {
            ListNode afterNode = findItem( afterItem ) ;  // find the afterItem's node

            if ( afterNode != null )    // afterItem in list
            {

                // create newItem's node & set its next to afterItem's next
                ListNode newItemNode = new ListNode( newItem, afterNode.getNext() ) ;

                afterNode.setNext( newItemNode ) ;

                length++ ;

                return true ;
            }
            else
            {    // afterItem not in list
                return false ;
            }
        }


        public void printList()
        {
            if ( head == null )
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                ListNode current = head;

                Console.WriteLine("Items in the list are:");

                while ( current != null )   // not at end of the list
                {
                    // Console.WriteLine( current.getItem().ToString() ) ;
                    current.print();
                    current = current.getNext() ;
                }
            }
        }

        public Object deleteHead()
        {
            T deletedItem = head.getItem();
            head = head.getNext();
            length--;
            return deletedItem;
        }

        public void insertAtTail(Object item)
        {
            ListNode lastNode = head;
            for (int i = 1; i < length; i++)
            {
                lastNode = head.getNext();
            }

            lastNode.setNext(new ListNode(item));
            length++;
        }

    }  // LinkedList

}
