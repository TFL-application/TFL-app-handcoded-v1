using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLAppHandcoded
{
    // Lecture 3
    // Doubly Linked List class 


    ///////////////////////////////////////////////////////////////////////////////
    // WARNING: when updating a node's item, next or previous values remember that
    //          all of these could be "null". this means that you are trying to call:
    //          null.setNext(  node ) or null.getPrevious(), etc
    //          and all of these will cause a "run time ERROR".  so test to make 
    //          sure they are not "null" before calling a method on them.  
    //
    //          This is why there are a lot of "if (XXX != null) " tests in the code. 
    ///////////////////////////////////////////////////////////////////////////////

    public class DLinkedList
    {
        private const DLListNode NO_NODE          = null ;  // increases readbility 
        private const DLListNode NO_PREVIOUS_NODE = null ;  // better than "null" everywhere
        private const DLListNode NO_NEXT_NODE     = null ;

        // List "data structure": 
        protected DLListNode head   = NO_NODE;   // points to the head of the list
        protected int        length = 0 ;        // number of nodes in the list

        public DLinkedList()
        {
            head   = NO_NODE ;    // empty list
            length = 0 ;          // no nodes in the list
        }

        public bool isEmpty()
        {
            return ( length == 0 );       // or ( head == NO_NODE )
        }

        // 2 cases: (a) empty list, (b) non-empty list
        public void insertAtHead( Object item )
        {
            // creat a new head node for the item
            DLListNode newItemNode = new DLListNode( item, NO_PREVIOUS_NODE, head ) ;

            if ( head != NO_NODE)                   // check if empty list, i.e. no head node exists)
            { 
                // (b) non-empty list
                head.setPrevious( newItemNode ) ;   // set current head's previous link to the new head, i.e. newItemNode
            }

            // make newItemNode the head node
            head = newItemNode ;
            length++ ;
        }


        private DLListNode findItem( Object item )
        {
            DLListNode current = new DLListNode() ;  // use current node to point to nodes as traverse the list

            current = head;                          // start at the head node

            // while not reached end of the list & not found the item continue traversal
            while ( ( current != NO_NODE ) && ( !item.Equals( current.getItem() ) ) )
            {
                Console.WriteLine("findItem: current.item = " + current.getItem().ToString());

                current = current.getNext();  // move to next node in the list
            }

            if (current != NO_NODE)
            {
                    Console.WriteLine("findItem: FOUND current.item = " + current.getItem().ToString());
                    Console.WriteLine();
            }
            else 
            {
                Console.WriteLine("findItem: DID NOT FIND item = " + item.ToString());
                Console.WriteLine();
            }

            return current;
           
        }

        public bool insertAfter(Object newItem, Object afterItem)
        {
            Console.WriteLine("insertAfter( {0}, {1} ): search for {1} node", newItem.ToString(), afterItem.ToString() ) ;
            Console.WriteLine();

            DLListNode afterNode = findItem( afterItem ) ;  // find the afterItem's node

            if (afterNode != NO_NODE )
            {   
                // afterItem in list
                // create newItem's node, connect to its neighbour nodes, by setting its:
                // item     <-- newItem
                // previous <-- afterItem
                // next     <-- afterItem's next node

                DLListNode newItemNode = new DLListNode( newItem, afterNode, afterNode.getNext() );

                // connect newItem's neighbour nodes to itself by updating their links:
                newItemNode.getPrevious().setNext( newItemNode ) ;       // previous node's next --> newItem node

                if (newItemNode.getNext() != NO_NEXT_NODE )              // check next node exists
                {
                    newItemNode.getNext().setPrevious( newItemNode );    // next node's previous --> newItem node
                }

                length++ ;  // added a node

                return true ;
            }
            else
            {    // afterItem not in list
                return false ;
            }
        }

        // Item Node Deletion 3 case to consider: 
	//   (a) item not in list, 
	//   (b) item is head of list, 
	//   (c) item is in the list but not the head 

        public bool DeleteItem(Object deleteItem)
        {
            Console.WriteLine("DeleteItem( {0} ): search for {0} node", deleteItem.ToString() ) ;
            Console.WriteLine();

            DLListNode deleteItemNode = findItem(deleteItem);  // find the deleteItem's node in the list

            if ( deleteItemNode == NO_NODE )
            {
                // CASE (a) deleteItem is not in the list

                // ************************************************* 
                // ****** TUTORIAL EXERCISE: INSERT CODE HERE ****** 
                // *************************************************

                Console.WriteLine("Item is not found in the list");
            }
            else
            {
                if ( deleteItemNode == head )
                {
                    // CASE (b) deleteItem is the head node
                    Console.WriteLine("DeleteItem( {0} ): found as head of list", deleteItemNode.getItem());

                    // delete current head by making its next node the new head, i.e. 2nd node or null if no 2nd node. 

                    // ************************************************* 
                    // ****** TUTORIAL EXERCISE: INSERT CODE HERE ****** 
                    // *************************************************

                    head = deleteItemNode.getNext();
                    head.setPrevious(null);

                    Console.WriteLine("DeleteItem( {0} ): deleted head of list", deleteItemNode.getItem() );
                }
                else
                {
                    // CASE (c): deleteItem is in list but not the head

                    // disconnect deleteItem's node from its neighbour nodes, by updating their links:

                    // *************************************************
                    // ****** TUTORIAL EXERCISE: INSERT CODE HERE ****** 
                    // *************************************************

                    DLListNode nextItemNode = deleteItemNode.getNext();
                    DLListNode previousItemNode = deleteItemNode.getPrevious();

                    nextItemNode.setPrevious(previousItemNode);
                    previousItemNode.setNext(nextItemNode);

                    Console.WriteLine("DeleteItem( {0} ): deleted ", deleteItemNode.getItem());
                }

                length--;     // deleted a node
                return true ;
            }
            return false;
        }


        public void printList()
        {
            if ( head == NO_NODE )
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                DLListNode current = new DLListNode() ;

                current = head ;

                Console.WriteLine( "{0} Items in the list are:", length ) ;

                while (current != NO_NEXT_NODE )   // not at end of the list
                {
                    current.print();

                    current = current.getNext() ;
                }
            }
        }

    }  // DLinkedList

} // Lecture_3


