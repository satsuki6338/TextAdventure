using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text text;
  
    private enum States { cell, cell_back, mirror, sheet_0, sheet_1,
        lock_1, lock_0, room_1, cellphone_1, cellphone_2, bad_end,
        corridor_0 };
    private States myState;

	// Use this for initialization
	void Start () {
        myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
        //for debugging, keep track of what state (stage) we're in
        print(myState);

        if (myState == States.cell)
        {
            State_Cell();
        }
        else if (myState == States.sheet_0)
        {
            State_Sheet_0();
        }
        else if (myState == States.lock_0)
        {
            State_Lock_0();
        }
        else if (myState == States.mirror)
        {
            State_Mirror();
        }
        else if (myState == States.cell_back)
        {
            State_Cell_Back();
        }
        else if (myState == States.sheet_1)
        {
            State_Sheet_1();
        }
        else if (myState == States.lock_1)
        {
            State_Lock_1();
        }
        else if (myState == States.room_1)
        {
            State_Room_1();
        }
        else if (myState == States.cellphone_1)
        {
            State_Cellphone_1();
        }
        else if (myState == States.cellphone_2)
        {
            State_Cellphone_2();
        }
        else if (myState == States.bad_end)
        {
            State_Bad_End();
        }
        else if (myState == States.corridor_0)
        {
            State_Corridor_0();
        }
	}

    #region State Handler methods
    void State_Cell()
    {
        text.text = "You wake up and find out "
                + "you are now in a prison cell."
                + " The door is locked from outside"
                + ". There are some dirty sheets on the bed,"
                + " a mirror on the wall, and an electric lock \n"
                + "What will you do? \n\n"
                + "Press S to view sheets, M to view mirror "
                + "and L to view lock";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.sheet_0;
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            myState = States.mirror;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.lock_0;
        }
    }
    void State_Sheet_0()
    {
        text.text = "You searched the sheets and found nothing useful \n\n"
            + "Press R to return";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell;
        }
    }
    void State_Lock_0()
    {
        text.text = "You looked at the lock. \n"
            + "It requires some kind of keycode.\n"
            + "You peaked through the lock hole. \n"
            + "It's pitch black and there's no one outside \n\n"
            + "Press R to return";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell;
        }
    }
    void State_Mirror()
    {
        text.text = "You examined the mirror. \n"
            + "It appears that you can remove it from the wall.\n"
            + "What will you do? \n\n"
            +"Press M to take off, R to return";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell;
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            myState = States.room_1;
        }
    }
    void State_Room_1()
    {
        text.text = "You found a hole behind the mirror "
            + "that leads to another cell. \n"
            + "You feel depressed because the hole leads to nowhere.\n"
            + "What will you do? \n\n"
            + "Press R to return to your original cell, C to continue "
            + "searching the second cell";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell_back;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            myState = States.cellphone_1;
        }
    }
    void State_Cell_Back()
    {
        text.text = "You returned to your original cell.\n"
            + "There is a hole on the wall, dirty sheets, and an electric lock.\n"
            + "What will you do? \n\n"
            + "Press M to go through the hole, S to search the sheets, and L to look at the lock.";
        if (Input.GetKeyDown(KeyCode.M))
        {
            myState = States.cellphone_1;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.sheet_1;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.lock_1;
        }
    }
    void State_Lock_1()
    {
        text.text = "You looked at the lock. \n"
            + "It requires some kind of keycode.\n"
            + "You peaked through the lock hole. \n"
            + "It's pitch black and there's no one outside \n\n"
            + "Press R to return";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell_back;
        }
    }
    void State_Sheet_1()
    {
        text.text = "You searched the sheets and found nothing useful \n\n"
            + "Press R to return";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell_back;
        }
    }
    void State_Cellphone_1()
    {
        text.text = "You hopelessly searched the room and suddenly "
            + "found a cellphone. \n"
            + "What will you do? \n\n"
            + "Press C to examine, R to return";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.room_1;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            myState = States.cellphone_2;
        }
    }
    void State_Cellphone_2()
    {
        text.text = "You examined the cellphone.\n"
            + "The phone seems to be connected to the prison's computer. \n"
            + "There are 2 options on the screen: \n"
            + "access_database(server_K, currentRoom.num). \n"
            + "brute_force(currentRoom.lock) \n"
            + "What will you do? \n\n"
            + "Press R to return, A to take 1st option, B to take 2nd option";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cellphone_1;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            myState = States.bad_end;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            myState = States.corridor_0;
        }
    }
    void State_Bad_End()
    {
        text.text = "You chose to brute force the electric lock. \n"
            + "The alarm goes off and strange gas slowly fills the room. \n"
            + "You feel hard to breath and slowly lose conciousness. \n\n"
            + "Press Enter to play again";
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Start();
        }
    }
    void State_Corridor_0()
    {
        text.text = "The phone accessed the given server, searched "
            + "and returned the 4 number pin code. \n"
            + "You try this on the lock and it opens. \n"
            + "You carefully get out of the room and navigate through the corridor.";
    }
    #endregion
}
