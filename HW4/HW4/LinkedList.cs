using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4
{
class LinkedList : IList {

        //makes the beginning and the end of the list equal to nothing
        private Node head = null;
        private Node tail = null;
        private int count = 0;

        //count property
        public int Count {
            get 
            {
                return count;
            }
        }
        public void Add(string data) 
        {
            //creates a node containing the data for the list
            Node dataNode = new Node(data);

            //if there isn't anything in the list, it means that something
            //needs to be added to the start
            if (head == null) 
            {
                head = dataNode;
                tail = dataNode;

                count++;
                return;
            }
            //otherwise, the list has elements stored

            //moves the previous node to the end
            dataNode.Previous = tail;
            
            //sets end to the new string
            tail = dataNode;

            //tells the old tail about the new tail
            tail.Previous.Next = tail;

            count++;
        }

        public void Clear() 
        {
            //resets all attributes
            head = null;
            tail = null;
            count = 0;
        }

        public string GetElement(int index) 
        {
            //checks for invalid indices
            if (index < 0 || index >= count)
            {
                return null;
            }

            int counter = 0;
            Node current = head;

            while(counter != index)
            {
                counter++;

                //changes the start of the node
                current = current.Next;
            }

            //reurns the string that the node holds

            return current.Data;
        }

        //Inserts a new node at a specific index
        public void Insert(string data, int index) 
        {
            Node newNode = new Node(data);

            if(index <= 0)
            {
                if (count != 0)
                {
                    newNode.Next = head;
                    head = newNode;
                    head.Next.Previous = head;

                    count++;
                }
                else
                {
                    Add(data);
                }
            }

            else if(index >= count)
            {
                Add(data);
            }

            else
            {
                int counter = 0;
                Node current = head;

                while (counter != index)
                {
                    counter++;

                    //changes the start of the node
                    current = current.Next;
                }

                newNode.Previous = current.Previous;
                newNode.Next = current;
                current.Previous.Next = newNode;
                current.Previous = newNode;

                count++;
            }
        }

        //Removes an element at an index
        public string Remove(int index) 
        {

            //element does not exist
            if(index < 0 || index >= count)
            {
                return null;
            }

            //creates an empty string
            string s = " ";

            //adds the element to the list, makes it the head
            if (index == 0)
            {
                s = head.Data;
                if (head.Next != null)
                {
                    
                    head = head.Next;
                    head.Previous = null;

                    count--;
                }

                else
                {
                    head = null;

                    count--;
                }

                return s;
            } 

            //logic for if the element is at the tail of the node
            else if(index == count - 1)
            {
                s = tail.Data;
                tail = tail.Previous;
                tail.Next = null;

                count--;

                return s;
            }

            else
            {
                int counter = 0;
                Node current = head;

                while (counter != index)
                {
                    counter++;

                    //changes the start of the node
                    current = current.Next;
                }

                s = current.Data;

                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;

                count--;

                return s;
            }
        }
    }
}
