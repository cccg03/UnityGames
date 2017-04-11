using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	
	public Text text;
	
	private enum States {
	sheets_0, lock_0, sheets_1, cell_mirror, lock_1, corridor_0, cell, mirror, freedom,	
	stairs_0, floor, closet_door, corridor_1, stairs_1, in_closet, corridor_2, stairs_2, corridor_3, courtyard
	};
	
	private States myState; 
	
	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		if 		(myState == States.cell) {cell();} 
		else if (myState == States.sheets_0) {sheets_0();} 
		else if (myState == States.lock_0) {lock_0();} 
		else if (myState == States.mirror) {mirror();}
		else if (myState == States.cell_mirror) {cell_mirror();} 
		else if (myState == States.sheets_1) {sheets_1();} 
		else if (myState == States.lock_1) {lock_1();}
		else if (myState == States.freedom) {freedom();}
		else if (myState == States.stairs_0) {stairs_0();}
		else if (myState == States.floor) {floor();}
		else if (myState == States.closet_door) {closet_door();}
		else if (myState == States.corridor_0) {corridor_0();}
		else if (myState == States.corridor_1) {corridor_1();}
		else if (myState == States.stairs_1) {stairs_1();}
		else if (myState == States.in_closet) {in_closet();}
		else if (myState == States.corridor_2) {corridor_2();}
		else if (myState == States.stairs_2) {stairs_2();}
		else if (myState == States.corridor_3) {corridor_3();}
		else if (myState == States.courtyard) {courtyard();}	
	}
	
		void cell() {
		text.text = "You wake up in a dark room. Your head hurts and you don't know where you are " +
			"or how you got here. In fact, you can't remember much of the last...who knows " +
				"how long. Your life's worth of memories are so blurry. All you know is that " +
				"you seem to be in a prison cell. There are sheets (S) on the bed, a mirror (M) on the wall, " +
				"and when you try the door handle (D) you can tell it's been locked from the outside.";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_0;
		} else if (Input.GetKeyDown(KeyCode.D)) {
			myState = States.lock_0;
		} else if (Input.GetKeyDown(KeyCode.M)) {
			myState = States.mirror;
		}
	}
	void sheets_0() {
		text.text = "These are gross and there's nothing here but a lingering smell that you almost recognize. What is it...? " +
					"You can't remember. Nothing is coming back to you yet. You should return (R) to your cell.";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}
	void lock_0() {
		text.text = "It's like you noticed from the beginning. Locked. You're not going anywhere. But maybe there's something " +
					"in your cell that will help you get out. Return (R) to your cell and keep looking...";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}
	void mirror() {
		text.text = "You notice a crack in that runs the length of the mirror. When you pull that section away you find a key! " +
					"Could this be your ticket out of here...? Only one way to find out. Take (T) it! Or return (R) to your miserable cell.";
		if (Input.GetKeyDown(KeyCode.T)) {
			myState = States.cell_mirror;
		} else if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}
	void cell_mirror() {
		text.text = "You're an adventurous one, aren't you? Head over to the lock (L) to see if the key works. Or maybe " +
					"those sheets (S) have something special about them this time?";
		if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_1;
		} else if (Input.GetKeyDown(KeyCode.S)) {
			myState	= States.sheets_1;
		}
	}
	void sheets_1() {
		text.text = "The only thing special about the sheets is that they seem to be mocking you for double-checking on them. " +
					" Head back (R) to your cell.";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}
	void lock_1() {
		text.text = "For some reason, the line \"If the boot fits...\" comes to your mind as the key slides easily into the lock. " +
					"With a flickada wrist, the lock makes a *click*. All you have to do is open (O) the door.";
		if (Input.GetKeyDown(KeyCode.O)) {
			myState = States.freedom;
		}
	}
	
	void freedom() {
		text.text = "The door, with some effort, slides open. You're free! From this cell, at least. Now you just have to make your " +
					"way out of here. Let's see...there are stairs (S) to your left, a door (D) on your right, and something " +
					"shiny on the floor (F)...";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.stairs_0;
		} else if (Input.GetKeyDown(KeyCode.D)) {
			myState	= States.closet_door;
		} else if (Input.GetKeyDown(KeyCode.F)) {
			myState = States.floor;
		}
	}
	
	void corridor_0() {
		text.text = "Back to your open cell door with the stairs (S) to your left, a door (D) on your right and that shiny thing on " + 
		"the floor (F).";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.stairs_0;
		} else if (Input.GetKeyDown(KeyCode.D)) {
			myState	= States.closet_door;
		} else if (Input.GetKeyDown(KeyCode.F)) {
			myState = States.floor;
		}
	}
	void stairs_0() {
		text.text = "As you make your way carefully up the stairs, you can see a door to the courtyard. Unfortunately, the door is " +
					"heavily guarded and there's no way you'll make it out in your current prison clothes. Better go back downstairs (R).";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_0;
		}
	}
	void closet_door() {
		text.text = "This door is locked. If only there was something you could use to pick it...better go back (R) and look around.";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_0;
		}
	}
	void floor() {
		text.text = "You head over to the shiny thing and see that it's a hairclip - what luck! You spent years unlocking your bedroom " +
					"door when your younger brother would lock you out at night. Take it? (Y)/(N)?";
		if (Input.GetKeyDown(KeyCode.N)) {
			myState = States.corridor_0;
		} else if (Input.GetKeyDown(KeyCode.Y)) {
			myState = States.corridor_1;
		}
	}
	void corridor_1() {
		text.text = "Back to your open cell door with the stairs (S) to your left and that door (D) on your right.";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.stairs_1;
		} else if (Input.GetKeyDown(KeyCode.D)) {
			myState	= States.in_closet;
		} 
	}
	void stairs_1() {
		text.text = "You could certainly attempt picking the lock from the inside, but you would still be shot on site. Probably " +
					"a good idea to head back (R) and find something that will help you get out.";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_1;
		}
	}			
	void in_closet() {
		text.text = "You have a brief flashback of your screaming brother as you open the door to what appears to be a supply " +
					"closet of somekind. Thankfully, nothing jumps out you here, though your eye catches a custodial outfit and " +
					"mop bucket. Do you want to put it on? (Y)/(N)";					 				
		if (Input.GetKeyDown(KeyCode.Y)) {
			myState = States.corridor_3;
		} else if (Input.GetKeyDown(KeyCode.N)) {
			myState	= States.corridor_2;
		} 			
	}			
	void corridor_2() {
		text.text = "You're back in that corridor with nothing but the stairs (S) and a hundred guards between you and freedom. There's " +
					"still that closet (C) with a convenient disguise, however..."; 					 				
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.stairs_2;
		} else if (Input.GetKeyDown(KeyCode.C)) {
			myState	= States.in_closet;
		} 						
	}			
	void stairs_2() {
		text.text = "You throw caution to the wind and pick the lock at the top of the stairs, making a run for it as literally one thousand " +
					"bullets enter you from each side. You are dead, but you didn't die in a cold bed, wondering if you would ever make it out." +
					" Now you know you definitely wouldn't. Press Space to start again."; 					 				
		if (Input.GetKeyDown(KeyCode.Space)) {
			myState = States.cell;
			}			
		}
	void corridor_3() {
		text.text = "This is it. You look like a bonafide custodian, though with a few more scars than usual. It's risky, but you can " +
					"probably make it out of those stairs (S) now that you have a convincing disguise. Or you can take it back off (O).";
		if (Input.GetKeyDown(KeyCode.O)) {
			myState = States.corridor_2;
		} else if (Input.GetKeyDown(KeyCode.S)) {
			myState	= States.courtyard;
		} 							
	}
	void courtyard(){
		text.text = "The sunshine is blinding, but at least you're not dead. You made it out. Now you need to figure out how you got here " +
					"in the first place...\nPress Space to start again.";
		if (Input.GetKeyDown(KeyCode.Space)) {
			myState = States.cell;	
		}
	}						
}