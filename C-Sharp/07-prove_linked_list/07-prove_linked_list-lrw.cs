/********
CSE212 
(c) BYU-Idaho
07-Prove - Problems

It is a violation of BYU-Idaho Honor Code to post or share this code with others or 
to post it online.  Storage into a personal and private repository (e.g. private
GitHub repository, unshared Google Drive folder) is acceptable.

//--- Created from: dotnet new console. See https://aka.ms/new-console-template for more information ---//
********/
Console.WriteLine("CSE212:  07-Prove - Problems");  // Comment out this line


testing run_tests = new testing();

run_tests.test1();
run_tests.test2();
run_tests.test3();

public class testing {
    doublyLinkedList dll = new doublyLinkedList();

    public void test1(){
        Console.WriteLine("\n=========== PROBLEM 1 TESTS ===========");
        dll.insert_tail(1);
        dll.insert_tail(1);
        dll.insert_head(2);
        dll.insert_head(2);
        dll.insert_head(2);
        dll.insert_head(3);
        dll.insert_head(4);
        dll.insert_head(5);
        dll.showList(dll.head); // linkedlist[5, 4, 3, 2, 2, 2, 1]
        dll.insert_tail(0);
        dll.insert_tail(-1);
        dll.showList(dll.head); // linkedlist[5, 4, 3, 2, 2, 2, 1, 0, -1]
        }
    public void test2(){
        Console.WriteLine("\n\n=========== PROBLEM 2 TESTS ===========");
        dll.remove_tail();
        dll.showList(dll.head); // linkedlist[5, 4, 3, 2, 2, 2, 1, 1, 0]
        dll.remove_tail();
        dll.showList(dll.head); // linkedlist[5, 4, 3, 2, 2, 2, 1, 1]
        }
    public void test3(){
        Console.WriteLine("\n=========== PROBLEM 3 TESTS ===========");
        dll.insert_after(3, 3.5);
        dll.insert_after(5, 6);
        dll.showList(dll.head); // linkedlist[5, 6, 4, 3, 3.5, 2, 2, 2, 1]
        dll.remove_find(-1);
        dll.showList(dll.head); // linkedlist[5, 6, 4, 3, 3.5, 2, 2, 2, 1]
        dll.remove_find(3);
        dll.showList(dll.head); // linkedlist[5, 6, 4, 3.5, 2, 2, 2, 1]
        dll.remove_find(6);
        dll.showList(dll.head); // linkedlist[5, 4, 3.5, 2, 2, 2, 1]
        dll.remove_find(1);
        dll.showList(dll.head); // linkedlist[5, 4, 3.5, 2, 2, 2]
        dll.remove_find(7);
        dll.showList(dll.head); // linkedlist[5, 4, 3.5, 2, 2, 2]
        dll.remove_find(5);
        dll.showList(dll.head); // linkedlist[4, 3.5, 2, 2, 2]
        dll.remove_find(2);
        dll.showList(dll.head); // linkedlist[4, 3.5, 2, 2]
        }
    }

public class doublyLinkedList
    {
    /*
    Implement the LinkedList data structure.  The Node class below is an 
    inner class.  An inner class means that its real name is related to 
    the outer class.  To create a Node object outside of the class, we will need to 
    specify singlyLinkedList.Node
    */
    public class Node {  
        public double data ;  
        public Node prev = null;  
        public Node next = null;  
        }  


    public Node head = null;
    public Node tail = null;

    public Node ll = new Node();

    public void showList(Node list_to_show) {
        Node p = new Node() ;
        // p=list_to_show;
        p = head;
        Console.Write("[");
        do {
            Console.Write(p.data);
            if (p.next !=null)
                {Console.Write(", ");}
            else {
                Console.WriteLine("]");
                }
            p=p.next;
            }
        while(p!=null);
        }

    public void insert_head(double value)
        {
        /*
        Insert a new node at the front (i.e. the head) of the
        linked list.
        */
        // Create the new node
        Node newNode = new Node();
        // If the list is empty, then point both head and tail to the new node.
        newNode.data = value;
        // Console.WriteLine("Inserting Head: " + value);
        newNode.prev = null;    // Nobody in front of a new node at the front
        if (head == null){
            head = newNode;
            tail = newNode;
            }
        // If the list is not empty, then only the head will be affected.
        else {
            newNode.next = head;    // Connect new node to the previous head
            head.prev = newNode;    // Connect the previous head to the new node
            head = newNode;         // Update the head to point to the new node
            }
        }

    /////////////////////
    // Start Problem 1 //
    /////////////////////
    public void insert_tail(double value)
        {
        /*
        Insert a new node at the end (i.e. the tail) of the linked list.
        */
        // Create the new node
        Node newNode = new Node();
        // If the list is empty, then point both head and tail to the new node.
        newNode.data = value;
        // Console.WriteLine("Inserting Tail: " + value);
        newNode.next = null;    // Nobody after a new node at the tail
        if (tail == null){
            head = newNode;
            tail = newNode;
            }
        // If the list is not empty, then only the tail will be affected.
        else {
            tail.next = newNode;    // Connect previous tail to the newNode
            newNode.prev = tail;    // Connect new node to the previous tail
            tail = newNode;         // Update the tail to point to the new node
            }
        }

    /////////////////////
    // Start Problem 2 //
    /////////////////////

    public void remove_tail()
        {
        /* Remove the last node of the linked list.  */
        if (tail == null){ // list is null, so just return
            return;
            } else {
            tail = tail.prev;
            tail.next = null;
            }
        }
    public void remove_head()
        {
        /* Remove the first node of the linked list.  */
        if (head == null){ // list is null, so just return
            return;
            } else {
            head = head.next;
            head.prev = null;
            }
        }

    /////////////////////
    // End Problem 2 //
    /////////////////////

    /////////////////////
    // Start Problem 3 //
    /////////////////////
    Node find_a_node(Node search_from, double with_value){
        Node search = head;
        while (search.data != with_value) {
            search = search.next;
            }
        if (search.data == with_value) {
            return search; 
            } else {
            return null;
            }
        }

    public void insert_after(double newValue, double findValue) {
        /*
        Insert 'new_value' after the first occurance of 'value' in
        the linked list.
        */
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        // Create the new node
        Node foundNode = find_a_node(head,findValue);
        /* if the 'found_node' is the tail AND the values don't match, then abort
        // just insert it at the end
        */
        if (foundNode == tail ) {
            if (findValue != tail.data)
                {
                Console.WriteLine("Tried to insert after a value :" + findValue + ": not found");
                }
                else {
                insert_tail(newValue);
                }
            } else { // If wasn't the last one, so there's a node found with the value of interest
            Node newNode = new Node();
            newNode.data = newValue;
            newNode.prev = foundNode;
            newNode.next = foundNode.next;
            foundNode.next = newNode;
            }
            }

    public bool is_head(Node thisnode) { return (thisnode == head); }
    public bool is_tail(Node thisnode) { return (thisnode == tail); }

    public void remove_node(Node to_remove) {
        if (is_head(to_remove)) {remove_head();return;}
        if (is_tail(to_remove)) {remove_tail();return;}
        // Just someone in the middle
        to_remove.prev.next = to_remove.next; //change link previous
        to_remove.next.prev = to_remove.prev; //change link following
        }

    public void remove_find(double findValue) {
        Node foundNode = find_a_node(head,findValue);
        if (foundNode == null) {
            Console.WriteLine("Tried to delete a node with unfound value :" + findValue + ": not found");
            }
        else {
            remove_node(foundNode);
            }
        }

    /////////////////////
    // End Problem 3 //
    /////////////////////




    /////////////////////
    // Start Problem 4 //
    /////////////////////
    /* Search for all instances of 'old_value' and replace the value to 'new_value'.  */
    public void replace(double old_value, double new_value) {
        Node found = find_a_node(head,old_value);
        while ((found != tail) && (found.data == old_value )) {
            found.data = new_value;
            found = find_a_node(found.next,old_value);  // start search from the next location
            }
        }
    /////////////////////
    // End Problem 4 //
    /////////////////////

    /////////////////////
    // Start Problem 5 //
    /////////////////////
    Node reversed_ll(Node tail_to_become_head) {
        /* Algorithm for reversing the list:
            Is the list empty or one element? If yes, then it is already reversed.
            Otherwise, create a new empty list.

            In a loop, remove the first item from the old list and add it to the start of the new list.
            Loop until the first list is empty.
        */
        Node reversed_ll = new Node(); //start a new list
        reversed_ll = tail_to_become_head;
        reversed_ll.data = tail_to_become_head.data;
        reversed_ll.next = tail_to_become_head.prev;
        reversed_ll.prev = null;
        while (tail_to_become_head.prev != null) {
            Node addReversed = new Node(); //start a new list
            addReversed.next = tail_to_become_head.prev;
            addReversed.data = tail_to_become_head.data;
            }
        return reversed_ll;
        }
    }
        

    /////////////////////
    // End Problem 5 //
    /////////////////////

// Sample Test Cases (may not be comprehensive) 
/* 

Console.WriteLine("\n=========== PROBLEM 3 TESTS ===========")
ll.insert_after(3, 3.5)
ll.insert_after(5, 6)
print(ll) // linkedlist[5, 6, 4, 3, 3.5, 2, 2, 2, 1]
ll.remove(-1)
print(ll) // linkedlist[5, 6, 4, 3, 3.5, 2, 2, 2, 1]
ll.remove(3)
print(ll) // linkedlist[5, 6, 4, 3.5, 2, 2, 2, 1]
ll.remove(6)
print(ll) // linkedlist[5, 4, 3.5, 2, 2, 2, 1]
ll.remove(1)
print(ll) // linkedlist[5, 4, 3.5, 2, 2, 2]
ll.remove(7)
print(ll) // linkedlist[5, 4, 3.5, 2, 2, 2]
ll.remove(5)
print(ll) // linkedlist[4, 3.5, 2, 2, 2]
ll.remove(2)
print(ll) // linkedlist[4, 3.5, 2, 2]

Console.WriteLine("\n=========== PROBLEM 4 TESTS ===========")
ll.replace(2, 10)
print(ll) // linkedlist[4, 3.5, 10, 10]
ll.replace(7, 5)
print(ll) // linkedlist[4, 3.5, 10, 10]
ll.replace(4, 100)
print(ll) // linkedlist[100, 3.5, 10, 10]


Console.WriteLine("\n=========== PROBLEM 5 TESTS ===========")
print(list(reversed(ll)))  //// [10, 10, 3.5, 100]
*/