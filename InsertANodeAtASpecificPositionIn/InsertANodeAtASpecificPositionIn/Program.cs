using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertANodeAtASpecificPositionIn
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
            public void InsertNode(int nodeData)
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    this.tail.next = node;
                }

                this.tail = node;
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

        static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode head, int data, int position)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);

            int startAt = 0;
            if (position == 0)
            {
                //insert to head 
                newNode.next = head;
                return newNode;// which is the new head. 
            }
            SinglyLinkedListNode current = head; 
            while(startAt < position -1)
            {

                current = current.next;
                startAt++; 
            }

            
            
            SinglyLinkedListNode temp = current.next;
            current.next = newNode;
            newNode.next = temp; 
            
            return head; // returns in every other case



        }

        static void Main(string[] args)
        {
            SinglyLinkedList llist = new SinglyLinkedList();

            int llistCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llistCount; i++)
            {
                int llistItem = i;
                llist.InsertNode(llistItem);
            }

            int data = 100;

            int position = 5;

            SinglyLinkedListNode llist_head = insertNodeAtPosition(llist.head, data, position);

            PrintSinglyLinkedList(llist_head);
        }
    }
}
