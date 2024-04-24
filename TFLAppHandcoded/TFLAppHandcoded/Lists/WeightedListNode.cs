using System;

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

        public WeightedListNode(O item, W weight, WeightedListNode<O, W>? next)
        {
            this.item = item;
            this.weight = weight;
            this.next = next;
        }

        public void SetItem(O? item) { this.item = item; }
        public void SetWeight(W? weight) { this.weight = weight; }
        public void SetNext(WeightedListNode<O, W>? next) { this.next = next; }

        public O? GetItem() { return this.item; }
        public W? GetWeight() { return this.weight; }
        public WeightedListNode<O, W>? GetNext() { return this.next; }
    } 

}
