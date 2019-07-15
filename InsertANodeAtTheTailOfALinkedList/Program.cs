using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace InsertANodeAtTheTailOfALinkedList
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

            public SinglyLinkedList()
            {
                this.head = null; 
                //not all SinglyLinkedList have a tail this problem 
                // would be alot easier if it had a tail 
                //not all linked list are created equally. 
            }
        }

        static void PrintSinglyLinkedList(SinglyLinkedListNode node)
        {
            while (node != null)
            {
                Console.WriteLine(node.data);

                node = node.next;

                //if (node != null)
                //{
                //    textWriter.Write(sep);
                //}
            }
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            
            SinglyLinkedList llist = new SinglyLinkedList();
            int llistCount = 32; 

            for(int i = 0; i < llistCount; i++)
            {
                int llistItem = i;
                SinglyLinkedListNode llist_head = insertNodeAtTail(llist.head, llistItem);
                llist.head = llist_head;
            }

            PrintSinglyLinkedList(llist.head);
            //textWriter.WriteLine();

            //textWriter.Flush();
            //textWriter.Close(); 
        }

        static SinglyLinkedListNode insertNodeAtTail (SinglyLinkedListNode head, int data)
        {
            if (head == null)
            {
                //update head so that it isn't null anymore 
                head = new SinglyLinkedListNode(data);
                return head;
                /*whats going on here? the problem states that in begining the head will be null so null can't have a next
                without this you will get the follow error (trust me I got it) 
                Unhandled Exception:
                System.NullReferenceException: Object reference not set to an instance of an object
                  at Solution.insertNodeAtTail (Solution+SinglyLinkedListNode head, System.Int32 data) [0x00011] in solution.cs:69 
                  at Solution.Main (System.String[] args) [0x0003f] in solution.cs:104 
                [ERROR] FATAL UNHANDLED EXCEPTION: System.NullReferenceException: Object reference not set to an instance of an object
                  at Solution.insertNodeAtTail (Solution+SinglyLinkedListNode head, System.Int32 data) [0x00011] in solution.cs:69 
                  at Solution.Main (System.String[] args) [0x0003f] in solution.cs:104 
             */
            }
            SinglyLinkedListNode current = head; 
            // here we need to loop to the end of the list but different than our print
            //So we will go unto current.next != null 
            /*
             Based on how a linked list work the node is created with a null pointer for next
             if we add to the linked list the tail of the linked list will have its next = null
             meaning no connection. 
             */
            while(current.next != null)
            {
                current = current.next; // iterate until breaking point. 
                /*
                Think about this entire loop like a for loop for an javaScript Array 
                for (let index = 0;  index < array.length; index++)
                its virtually the same  the head points to the first element or the 0 index
                though a linked list isn't the same as an array. We don't need each item to be 
                in a continous space of memory like an array. Which is why we use pointers instead 
                of indexs. But the process is equivalent  when iterating over the entire data structure
                
                */
            }

            // that the while loop is done we know that current.next points to null

            // create the  node  
            SinglyLinkedListNode node =  new SinglyLinkedListNode(data);
            //now the current tail is no longer going to be the tail 
            current.next = node;
            // always return the head node   
            /*
             for (int i = 0; i < llistCount; i++) {
            int llistItem = Convert.ToInt32(Console.ReadLine());
			SinglyLinkedListNode llist_head = insertNodeAtTail(llist.head, llistItem);
            llist.head = llist_head;
          	
            }
            the llist_head =  the return of the insertNodeAtTail   
            then the llist.head = llist_head 
            if we don't return the head what's going to happen is we will be treating the return like a tail
            thus we will only print out the last  element instead of everyone
             
             */
            return head; 

            /*
             The best thing to take from this is that  the tail of a linked list is optional but when you are inserting to tail it is probably 
             better and a easier process      
             
            create a newNode 
             this.tail.next =   newNode;    
             this.tail = newNode;  

            We can add to the tail in constant time  O(3) converts to  O(1)   while  
            the loop is needed without a this.tail parmater which takes  O(n) where n is the number of elements in our linked list. 
            Your linked list should have a tail.  But remember  having a head and tail doesn't make it a doublly linked list 
            Whether or not a linked list is single or double comes from the directions the linked list can move in.  If it can only go in one direction 
            its  a single but if it can go forward or backward like your mp3 player previous and next  then yes  it is a doublely linked list 
            if it repeats your playlist after the last song is played and starts from the beginning it is a cicularly linked list    
            and if it can still go in 
            both directions it is a doubly circularly linked list. 
             */

        }
    }
}
