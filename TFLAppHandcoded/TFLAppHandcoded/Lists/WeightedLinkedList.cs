using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLAppHandcoded
{
    public class WeightedLinkedList<O, W>
    {
        protected WeightedListNode<O, W> head = null;   // points to the head of the list
        protected int length = 0;      // number of nodes in the list

        public WeightedLinkedList()
        {
            head = null;   // empty list
            length = 0;      // no nodes in the list
        }

        public bool isEmpty()
        {
            return (length == 0);       // or ( head == null )
        }

        public void insertAtHead(O item, W weight)
        {
            WeightedListNode<O, W> newItem = new WeightedListNode<O, W>(item, weight, head);  // .next ) ;

            head = newItem;

            length++;
        }

        // *** HAS A BUG? - so use Equals not != in while ***
        private WeightedListNode<O, W> findItem(O item)
        {
            if (!isEmpty())
            {
                WeightedListNode<O, W> current = new WeightedListNode<O, W>();

                current = head;

                while ((current != null) && (!(item.Equals(current.getItem()))))
                {
                    //Console.WriteLine();
                    //Console.WriteLine("findItem: current.item = " + current.getItem().ToString());
                    //Console.WriteLine();

                    current = current.getNext();
                }

                //Console.WriteLine();
                //Console.WriteLine("findItem: current.item = " + current.getItem().ToString());
                //Console.WriteLine();

                return current;
            }
            else
            {
                //Console.WriteLine();
                //Console.WriteLine("findItem: afterNode = null");
                //Console.WriteLine();

                return null;
            }
        }

        public bool insertAfter(O newItem, W newItemWeight, O afterItem)
        {
            WeightedListNode<O, W> afterNode = findItem(afterItem);  // find the afterItem's node

            if (afterNode != null)    // afterItem in list
            {

                // create newItem's node & set its next to afterItem's next
                WeightedListNode<O, W> newItemNode = new WeightedListNode<O, W>(newItem, newItemWeight, afterNode.getNext());

                afterNode.setNext(newItemNode);

                length++;

                return true;
            }
            else
            {    // afterItem not in list
                return false;
            }
        }


        public void printList()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                WeightedListNode<O, W> current = new WeightedListNode<O, W>();

                current = head;

                Console.WriteLine("Items in the list are:");

                while (current != null)   // not at end of the list
                {
                    // Console.WriteLine( current.getItem().ToString() ) ;
                    current.print();
                    current = current.getNext();
                }
            }
        }

        public O deleteHead()
        {
            O deletedItem = head.getItem();
            head = head.getNext();
            length--;
            return deletedItem;
        }

        public void insertAtTail(O newItem, W newItemWeight)
        {
            WeightedListNode<O, W> lastNode = head;
            for (int i = 1; i < length; i++)
            {
                lastNode = head.getNext();
            }

            lastNode.setNext(new WeightedListNode<O, W>(newItem, newItemWeight));
            length++;
        }
    }  // LinkedList

}
