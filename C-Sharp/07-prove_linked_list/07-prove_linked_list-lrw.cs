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
run_tests.test4();
run_tests.test5();

public class testing {
    doublyLinkedList dll = new doublyLinkedList();
    public enum show_type {forward, backward, both};


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
        dll.showList(dll.head,show_type.forward); // linkedlist[5, 4, 3, 2, 2, 2, 1]
        dll.insert_tail(0);
        dll.insert_tail(-1);
        dll.showList(dll.head,show_type.forward); // linkedlist[5, 4, 3, 2, 2, 2, 1, 0, -1]
        }
    public void test2(){
        Console.WriteLine("\n\n=========== PROBLEM 2 TESTS ===========");
        dll.remove_tail();
        dll.showList(dll.head,show_type.forward); // linkedlist[5, 4, 3, 2, 2, 2, 1, 1, 0]
        dll.remove_tail();
        dll.showList(dll.head,show_type.forward); // linkedlist[5, 4, 3, 2, 2, 2, 1, 1]
        }
    public void test3(){
        Console.WriteLine("\n=========== PROBLEM 3 TESTS ===========");
        //dll.showList(); // linkedlist[5, 6, 4, 3, 3.5, 2, 2, 2, 1]
        dll.insert_after(3, 3.5);
        //Console.WriteLine("\n dll.insert_after(3, 3.5)");
        dll.showList(dll.head,show_type.forward); // linkedlist[5, 6, 4, 3, 3.5, 2, 2, 2, 1]
        //Console.WriteLine("\n dll.insert_after(5,6)");
        dll.insert_after(5, 6);
        dll.showList(dll.head,show_type.forward); // linkedlist[5, 6, 4, 3, 3.5, 2, 2, 2, 1]
        dll.remove_tail();
        dll.showList(dll.head,show_type.forward); // linkedlist[5, 6, 4, 3, 3.5, 2, 2, 2]
        dll.remove_find(-1);
        dll.showList(dll.head,show_type.forward); // linkedlist[5, 6, 4, 3, 3.5, 2, 2, 2, 1]
        dll.remove_find(3);
        dll.showList(dll.head,show_type.forward); // linkedlist[5, 6, 4, 3.5, 2, 2, 2, 1]
        dll.remove_find(6);
        dll.showList(dll.head,show_type.forward); // linkedlist[5, 4, 3.5, 2, 2, 2, 1]
        dll.remove_find(1);
        dll.showList(dll.head,show_type.forward); // linkedlist[5, 4, 3.5, 2, 2, 2]
        dll.remove_find(7);
        dll.showList(dll.head,show_type.forward); // linkedlist[5, 4, 3.5, 2, 2, 2]
        dll.remove_find(5);
        dll.showList(dll.head,show_type.forward); // linkedlist[4, 3.5, 2, 2, 2]
        dll.remove_find(2);
        dll.showList(dll.head,show_type.forward); // linkedlist[4, 3.5, 2, 2]
        // should be  all
        }
    public void test4(){
        Console.WriteLine("\n=========== PROBLEM 4 TESTS ===========");
        dll.replace(2, 10);
        dll.showList(dll.head,show_type.forward); // linkedlist[4, 3.5, 10, 10]
        dll.replace(7, 5);
        dll.showList(dll.head,show_type.forward); // linkedlist[4, 3.5, 10, 10]
        dll.replace(4, 100);
        dll.showList(dll.head,show_type.forward); // linkedlist[100, 3.5, 10, 10]
    }

    public void test5(){
        Console.WriteLine("\n=========== PROBLEM 5 TESTS ===========");
        dll.insert_tail(11);
        dll.insert_tail(12);
        dll.reverse();
        // dll.showList(dll.r_head,show_type.forward);  //// [10, 10, 3.5, 100]
        dll.showList(dll.head,show_type.forward); // linkedlist[100, 3.5, 10, 10]
        dll.showList(dll.tail,show_type.backward); // linkedlist[100, 3.5, 10, 10]
        Console.WriteLine();
        dll.showList(dll.r_head,show_type.forward);  //// [10, 10, 3.5, 100]
        dll.showList(dll.r_tail,show_type.backward);  //// [10, 10, 3.5, 100]
        // dll.showList(dll.r_tail,show_type.backward);  //// [10, 10, 3.5, 100]
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
    public Node r_head = null;
    public Node r_tail = null;

    public Node ll = new Node();
    public Node rll = new Node(); //reversed version

    public void showList(Node starting_at,show_type showlist) {
        Node p = new Node() ;
        // p=list_to_show;
        // forward dir True means show forward
        p = starting_at;
        bool show_back = ((showlist == show_type.backward) || (showlist == show_type.both));
        bool show_front = ((showlist == show_type.forward) || (showlist == show_type.both));
        if (show_front) {
            Console.Write("\tForward:\t[");
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

        if (show_back) {
            Console.Write("\tBackward:\t[");
            p = tail;
            do {
                Console.Write(p.data);
                if (p.prev !=null)
                    {Console.Write(", ");}
                else {
                    Console.WriteLine("]");
                    }
                p=p.prev;
                }
            while(p!=null);
            }
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
        
        Node search = new Node();
        search = search_from;
        // Console.WriteLine("\nSearch from head is: " + search.data + " looking for with_value " + with_value +"\n");
        while ((search.data != with_value) && (search != tail)) {
            search = search.next;
            }
        if (search.data == with_value) {
            return search; 
            } else {
            // Console.WriteLine("\nSearch FAILED looking for: " + with_value + "  got: " + search.data );
            return null;
            }
        }

    public void insert_after(double findValue, double newValue) {
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
            foundNode.next.prev = newNode;
            foundNode.next = newNode;
            }
            }

    public bool is_head(Node thisnode) { return (thisnode == head); }
    public bool is_tail(Node thisnode) { return (thisnode == tail); }
    public bool is_empty() { return ((tail == null) && (head==null)); }

    public void remove_node(Node to_remove) {
        if (is_head(to_remove)) {
            // Console.WriteLine("Removing a found head");
            remove_head();return;}
        if (is_tail(to_remove)) {
            // Console.WriteLine("Removing a found tail");
            remove_tail();return;}
            /* Just someone in the middle
            Console.WriteLine("Removing in the middle: " + to_remove.data);
            Console.Write("Removing in the middle previous is: " + to_remove.prev.data);
            Console.WriteLine("\tNext is: " + to_remove.next.data);
            */
        to_remove.next.prev = to_remove.prev; //change link following
        to_remove.prev.next = to_remove.next; //change link previous
        //??????????
        }

    public void remove_find(double findValue) {
        Node foundNode = find_a_node(head,findValue);
        if (foundNode == null) {
            Console.WriteLine("Tried to delete a node with unfound value :" + findValue + ": not found");
            }
        else {
            // Console.WriteLine("Remove a find, found :" + foundNode.data );
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
            Node found = new Node();
            found = head;
            do {
                found = find_a_node(found,old_value);
                if (found == null) {return;}
                found.data = new_value;
                found = found.next;
                }
            while ((found != null) && (found.data == old_value )) ;
        }
    /////////////////////
    // End Problem 4 //
    /////////////////////

    /////////////////////
    // Start Problem 5 //
    /////////////////////
    public void reverse() {
        /* Algorithm for reversing the list:
            Is the list empty or one element? If yes, then it is already reversed.
            Otherwise, create a new empty list.
            In a loop,the first item from the old list and add it to the start of the new list.
            Loop until the first list is empty.

            This leaves the dll inplace and creates a rdll 

        */
        /// But if we get here, there are more than one node
        // start with the tail of the ll and put it into a new rll
        Node reverse_ptr = tail;  // use this pointer to walk backwords thru the dll
        Node just_added = new Node(); //Storage list is rdll
        Node hold_prev = new Node(); //per each item on the list


        // Case of a single node to be reversed.
    if ((head == tail) && (head != null)) {
        Node reversed_ll = new Node(); //start a new list
        reversed_ll.data = head.data; //start a new list
        reversed_ll.next = null; //start a new list
        reversed_ll.prev = null; //start a new list
        r_head = reversed_ll;
        r_tail = reversed_ll;
        return;
        }
    

    while (reverse_ptr != null)  // walk backward thru the list 
        {
        Node  add_to_end = new Node(); //per each item on the list
        r_tail = add_to_end;
        if (r_head == null) { // set the first node
            add_to_end.prev = null;
            add_to_end.data = reverse_ptr.data;
            add_to_end.next = null;
            // Console.WriteLine("Reverse first one added: " + add_to_end.data);
            reverse_ptr = reverse_ptr.prev;  // go to the 2nd node
            hold_prev = add_to_end;
            r_head = add_to_end;  // Now r_head points to the first one in the new list
        } else {  // add to the end
            // still pointint to the previous
            hold_prev.next = add_to_end;
            add_to_end.prev = hold_prev;
            add_to_end.data = reverse_ptr.data;
            add_to_end.next =  null;
            // Console.Write("Reverse added: " + reverse_ptr.data);
            // Console.WriteLine("\t\tvalue of previous node is : " + add_to_end.prev.data);
            Console.WriteLine("\t\tvalue of tail is : " + r_tail.data);
            reverse_ptr = reverse_ptr.prev; // walk backwards
            hold_prev = add_to_end;
            this.showList(this.r_head,show_type.forward);  //// [10, 10, 3.5, 100]
            this.showList(this.r_tail,show_type.backward);  //// [10, 10, 3.5, 100]
            }
        }
    }
}
}