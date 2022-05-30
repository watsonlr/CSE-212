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


class doublyLinkedList
    {
    /*
    Implement the LinkedList data structure.  The Node class below is an 
    inner class.  An inner class means that its real name is related to 
    the outer class.  To create a Node object outside of the class, we will need to 
    specify singlyLinkedList.Node
    */
    internal class Node {  
        public double data ;  
        public Node prev = null;  
        public Node next = null;  
        }  


    //Initialize an empty linked list.
    Node head = null;
    Node tail = null;

    void insert_head(double value)
        {
        /*
        Insert a new node at the front (i.e. the head) of the
        linked list.
        */
        // Create the new node
        Node newNode = new Node();
        // If the list is empty, then point both head and tail to the new node.
        newNode.data = value;
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
    void insert_tail(double value)
        {
        /*
        Insert a new node at the end (i.e. the tail) of the linked list.
        */
        // Create the new node
        Node newNode = new Node();
        // If the list is empty, then point both head and tail to the new node.
        newNode.data = value;
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

    void remove_tail()
        {
        /*
        Remove the last node of the linked list.
        */
        if (tail == null){ // list is null, so just return
            return;
            } else {
            tail = tail.prev;
            tail.next = null;
            }
        }
    void remove_head()
        {
        /*
        Remove the first node of the linked list.
        */
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
    Node find_a_node(double with_value){
        Node search = head;
        while (search.data != with_value) {
            search = search.next;
        }
        if (search.data == with_value) {
        return search; 
        } else {
        return null;
        }

    void insert_after(double newValue, double findValue) {
        /*
        Insert 'new_value' after the first occurance of 'value' in
        the linked list.
        */
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        // Create the new node
        Node foundNode = find_a_node(findValue);
        /* if the 'found_node' is the tail AND the values don't match, then abort
        // just insert it at the end
        */
        if (foundNode == tail ) {
            if (findValue != tail.data){
                Console.WriteLine("Tried to insert after a value :" + findValue + ": not found");
                else {
                insert_tail(newValue);
                }
            }
        // If wasn't the last one, so there's a node found with the value of interest
        else {
            Node newNode = new Node();
            newNode.data = newValue;
            newNode.prev = foundNode;
            newNode.next = foundNode.next;
            foundNode.next = newNode;
            }
        }
    }

    bool is_head(Node thisnode) { return (thisnode == head); }
    bool is_tail(Node thisnode) { return (thisnode == tail); }

    void remove_node(Node to_remove) {
        if (is_head(to_remove)) {remove_head();return;}
        if (is_tail(to_remove)) {remove_tail();return;}
        // Just someone in the middle
        to_remove.prev.next = to_remove.next; //change link previous
        to_remove.next.prev = to_remove.prev; //change link following
    }


    void remove_find(double findValue) {
        Node foundNode = find_a_node(findValue);
        if (foundNode == null) {
            Console.WriteLine("Tried to delete a node with unfound value :" + findValue + ": not found");
        else {
            remove_node(foundNode);
        }

    /////////////////////
    // End Problem 3 //
    /////////////////////




    /////////////////////
    // Start Problem 4 //
    /////////////////////
    def replace(self, old_value, new_value):
        /*
        Searrch for all instances of 'old_value' and replace the value 
        to 'new_value'.
        */
        pass

    //
    // End Problem 4 //
    //

    def __iter__(self):
        /*
        Iterate foward through the Linked List
        */
        curr = self.head  // Start at the begining since this is a forward iteration.
        while curr is not None:
            yield curr.data  // Provide (yield) each item to the user
            curr = curr.next // Go forward in the linked list

    //
    // Start Problem 5 //
    //
    def __reversed__(self):
        /*
        Iterate backward through the Linked List
        */
        yield "???"  // Replace this when you implement your solution

    //
    // End Problem 5 //
    //

    def __str__(self):
        /*
        Return a string representation of the linked list.
        */
        output = "linkedlist["
        first = True
        for value in self:
            if first:
                first = False
            else:
                output += ", "
            output += str(value)
        output += "]"
        return output

}

class testLinkedList {

// Sample Test Cases (may not be comprehensive) 
print("\n=========== PROBLEM 1 TESTS ===========")
ll = LinkedList()
ll.insert_tail(1)
ll.insert_head(2)
ll.insert_head(2)
ll.insert_head(2)
ll.insert_head(3)
ll.insert_head(4)
ll.insert_head(5)
print(ll) // linkedlist[5, 4, 3, 2, 2, 2, 1]
ll.insert_tail(0)
ll.insert_tail(-1)
print(ll) // linkedlist[5, 4, 3, 2, 2, 2, 1, 0, -1]

print("\n=========== PROBLEM 2 TESTS ===========")
ll.remove_tail()
print(ll) // linkedlist[5, 4, 3, 2, 2, 2, 1, 0]
ll.remove_tail()
print(ll) // linkedlist[5, 4, 3, 2, 2, 2, 1]

print("\n=========== PROBLEM 3 TESTS ===========")
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

print("\n=========== PROBLEM 4 TESTS ===========")
ll.replace(2, 10)
print(ll) // linkedlist[4, 3.5, 10, 10]
ll.replace(7, 5)
print(ll) // linkedlist[4, 3.5, 10, 10]
ll.replace(4, 100)
print(ll) // linkedlist[100, 3.5, 10, 10]


print("\n=========== PROBLEM 5 TESTS ===========")
print(list(reversed(ll)))  //// [10, 10, 3.5, 100]

}    