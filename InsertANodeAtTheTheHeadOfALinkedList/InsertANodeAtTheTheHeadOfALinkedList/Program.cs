using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertANodeAtTheTheHeadOfALinkedList
{
    class Program
    {
        class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }
        }

        class SinglyLinkedList
        {
            public SinglyLinkedListNode head;
            public SinglyLinkedListNode tail;

            public SinglyLinkedList()
            {
                this.head = null;
                this.tail = null;
            }

        }
        static void PrintSinglyLinkedList(SinglyLinkedListNode node)
        {
            while (node != null)
            {
                Console.WriteLine(node.data);

                node = node.next;

            }
        }
        static void Main(string[] args)
        {
            SinglyLinkedList llist = new SinglyLinkedList();
            int llistCount = 31;
            for (int i = 0; i < llistCount; i++)
            {
                int llistItem = i;
                SinglyLinkedListNode llist_head = insertNodeAtHead(llist.head, llistItem);
                llist.head = llist_head;

            }
            PrintSinglyLinkedList(llist.head);
        }
        static SinglyLinkedListNode insertNodeAtHead(SinglyLinkedListNode llist, int data)
        {
            SinglyLinkedListNode head = new SinglyLinkedListNode(data);
            if(llist == null)
            {
                llist = head; 
            } 
            else
            {
                head.next = llist;
            }
            
            return  head; 
        }
    }
}
