using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLAppHandcoded
{
    public class WeightedListNode<O, W>
    {
        private O? item;
        private W? weight;
        private WeightedListNode<O, W>? next;

        public WeightedListNode() { }

        public WeightedListNode(O item, W weight)
        {
            this.item = item;
            this.weight = weight;
            this.next = null;
        }

        public WeightedListNode(O item, W weight, WeightedListNode<O, W> next)
        {
            this.item = item;
            this.weight = weight;
            this.next = next;
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

        public void setItem(O item)
        {
            this.item = item;
        }

        public void setWeight(W weight)
        {
            this.weight = weight;
        }

        public void setNext(WeightedListNode<O, W> next)
        {
            this.next = next;
        }

        public O getItem()
        {
            return this.item;
        }

        public W getWeight()
        {
            return this.weight;
        }

        public WeightedListNode<O, W> getNext()
        {
            return this.next;
        }

    }  // ListNode

}
