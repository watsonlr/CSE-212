/********
CSE212 
(c) BYU-Idaho
04-Prove - Problem 1

It is a violation of BYU-Idaho Honor Code to post or share this code with others or 
to post it online. Storage into a personal and private repository (e.g. private
GitHub repository, unshared Google Drive folder) is acceptable.

//--- Created from: dotnet new console. See https://aka.ms/new-console-template for more information ---//
********/
using System.Collections.Generic;
using System;
Console.WriteLine("CSE212:  04-Prove - Problem 1");  // Comment out this line


turnsQueue theTurnsQueue  = new turnsQueue();

// TESTING HERE   -- can take out all the printing diagnostics sanity checks.
theTurnsQueue.add_person("Bob", 2); theTurnsQueue.theQueue.printWholeQueue();
theTurnsQueue.add_person("Tim", 3); theTurnsQueue.theQueue.printWholeQueue();
theTurnsQueue.add_person("Sue", 1);
theTurnsQueue.theQueue.printWholeQueue();
theTurnsQueue.get_next_person();
theTurnsQueue.theQueue.printWholeQueue();
theTurnsQueue.get_next_person();
theTurnsQueue.theQueue.printWholeQueue();
theTurnsQueue.get_next_person();
theTurnsQueue.theQueue.printWholeQueue();
theTurnsQueue.get_next_person();
theTurnsQueue.theQueue.printWholeQueue();
theTurnsQueue.get_next_person();
theTurnsQueue.theQueue.printWholeQueue();
theTurnsQueue.get_next_person();
theTurnsQueue.theQueue.printWholeQueue();
theTurnsQueue.get_next_person();
theTurnsQueue.theQueue.printWholeQueue();
theTurnsQueue.add_person("Lynn", 2);
theTurnsQueue.add_person("Sandy", 5);
theTurnsQueue.add_person("Jeff", 3);
theTurnsQueue.add_person("Doug", 1);
theTurnsQueue.get_next_person();
theTurnsQueue.get_next_person();
theTurnsQueue.get_next_person();
theTurnsQueue.get_next_person();
theTurnsQueue.get_next_person();
theTurnsQueue.get_next_person();
theTurnsQueue.get_next_person();
theTurnsQueue.get_next_person();
theTurnsQueue.add_person("George", 3);
theTurnsQueue.get_next_person();
theTurnsQueue.add_person("Bob", 2);
theTurnsQueue.add_person("Tim", 0);
theTurnsQueue.add_person("Sue", 3);
theTurnsQueue.get_next_person();
theTurnsQueue.get_next_person();
theTurnsQueue.get_next_person();
theTurnsQueue.get_next_person();
theTurnsQueue.get_next_person();
// END OF TEST


//     
public class Queue {
    public List<Person> theQueue = new List<Person>();
    // 
    public void EnQueue(Person to_add) {
        //         Add an item to the queue
        // Console.WriteLine("Node_to_add priority:  " + node_to_add.priority);
        // Console.WriteLine("Enqueueing:  " + node_to_add.ToString());
        theQueue.Add(to_add);
        }

    public Person DeQueue() {
        Person empty = new Person("Empty",-1);
        if (theQueue.Count == 0) {
            Console.WriteLine("Queue EMPTY");
            return empty;
            }
        Person toreturn = theQueue[0];
        // Remove the next item from the queue. 
        theQueue.RemoveAt(0);
        return toreturn;
        }

    public bool is_empty() {
        return (theQueue.Count == 0);
        }

    public void printWholeQueue(){
        Console.WriteLine("\t\tQueue Count is:  " +theQueue.Count);
        for(int i=0;i<theQueue.Count; i++) {
            Console.WriteLine("\t\t[" + i + "]\t" + theQueue[i].name + "\t turns:\t" + theQueue[i].turns);
        }
    // Console.WriteLine("Items in Queue:" + thePriorityQueue.Count());


        }

    public int Count() {
        return theQueue.Count;
        }
    }

public class turnsQueue{
    // 
    //     This queue is circular.  When people are added via add_person, then they are added to the 
    //     back of the queue (per FIFO rules).  When get_next_person is called, the next person
    //     in the queue is displayed and then they are placed back into the back of the queue.  Thus,
    //     each person stays in the queue and is given turns.  When a person is added to the queue, 
    //     a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
    //     less than they will stay in the queue forever.  If a person is out of turns then they will 
    //     not be added back into the queue.
    //     
    // has specialized add/delete instruction that make this circular
    public Queue theQueue = new Queue();
    // the variable and the methods implement circular with 'turns' rules
    // note that the enqueue and dequeue are just part of the Queue class itself, and not done here
    public void add_person(string name, int turns) {
        Person newone = new Person(name, turns);
        theQueue.EnQueue(newone);
    }
    public Person get_next_person() {
        /* Look at the end of the Queue and:
           Deque the guy (end of the queue)
           if this is his last turn (turns == 0), then do nothing
           if it's not his last turn, then get the value, and just decrease his turns count
           */
        Person person_to_take_a_turn = theQueue.DeQueue();
        person_to_take_a_turn.turns--;
        if (person_to_take_a_turn.turns > 0) {
            theQueue.EnQueue(person_to_take_a_turn);
            }
        person_to_take_a_turn.showMe();
        return person_to_take_a_turn;
        }
    }


public class Person {
//         A person is defined with a name and a number of turns.
    public string name; 
    public int turns; 

    public Person(string name_in, int turns_in) {
        name = name_in;
        turns = turns_in;
    }
    public void showMe(){
        Console.WriteLine("Name: "+ name + "\t\tTurns left: " + turns);
        }
    // 
    //             Support the display of single person.
    //             
}

// 
//         Add new people to the queue with a name and number of turns
//         
//         Get the next person in the queue and display them.  The person should
//         go to the back of the queue again unless the turns variable shows that they 
//         have no more turns left.  Note that a turns value of 0 or less means the 
//         person has an infinite number of turns.  An error message is displayed 
//         if the queue is empty.
//         
// 
