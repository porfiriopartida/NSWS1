# NSWS1
2D Unity Workshop

This is the step by step without pictures, I have to add them ;(

Nearsoft Workshop
Unity 2D # 1 by Porfirio Partida (2 hours)

If you have not yet downloaded Unity, you must start it now as it is around 6gb of total download

Download here - http://unity3d.com/es/get-unity 

I’m using the latest stable version of Unity, this course was done using Unity 5.2.2
About the Course
The idea is to cover a general idea of:
About the instructor 
What have I done
About Unity 
What can you do?
What are the alternatives?
Why Unity?
Beginner principles of:
The Unity interface 
Start a 2D project
Organize the layout
Sprites Handling 
Adding your own sprite
Animation Basics
Use the Asset store
Physics 
RigidBody
Colliders
Layers
Prefabs
Find Objects
Basic win/lose condition



About Unity  

Unity is a flexible and powerful development platform for creating multiplatform 3D and 2D games and interactive experiences. It's a complete ecosystem for anyone who aims to build a business on creating high-end content and connecting to their most loyal and enthusiastic players and customers. 

Site: http://unity3d.com/unity 
What can you do?
It is up to you
2D platform, puzzles, rpgs or 3d mobas, this engine is powerful and it really just needs you to start using it to build your dream game.


Can I make money with Unity without paying them?
Yes, unless you are earning above $100k you can keep using free Unity, otherwise you will have to buy a Pro license
What are the alternatives?
Unreal 3D
JMonkeyEngine 3D
Gamemaker 2D
It depends on what you want to compare against since some are 2d, 3d, 2.5d or all in one oriented.
https://en.wikipedia.org/wiki/List_of_game_engines 

Why Unity?
It’s Free (unless you go for a Pro edition, $75/mo or $1500)
Tons of Documentation
Tons of Tutorials


You can decide to go for mobile, desktop, web or even console development (if you have the credentials).





Setting up from git:
https://github.com/ppartida/NSWS1 
git clone https://github.com/ppartida/NSWS1.git 



Git hint:
For version control you can switch your asset serialization and put it in “Force Text”.

For this project we did not use this feature ); until it was kind of late. It changed from branch 14.

The Unity Interface
Unity has a lot of tools and one can easily get lost with them, at least I did, this is just a walkthrough to the general interface and a little bit of layout organization.
Starting a 2D project:
Open Unity and create a new project
Select 2D
Select the pre imported asset packages
Mark 2D
	Done
Click Create Project





Once you imported you can see some files in the project tab that are included using the 2D assets package.



The main layout should include:
Hierarchy:
Project
Console
Animation
Scene
Game
Asset Store
Inspector

The hierarchy is where we have all our living objects, by default we can only see the Camera. You can add groups, 2d objects, ui elements, etc.

The project has all our assets/files such as scripts, sprites, prefabs, etc., comes with a search box.

The console is not that different from a regular console where you can see logs and helps you with debugging.

Animation is where you manage your animations (keyframes, events, etc.) we won’t talk too much about this ): I’m still too noob for all features involved here.

Scene this is where you can drop your elements and where your game objects live and you need at least one scene for your game, also, when the game is running, this section helps you debugging. 
From Unity3d.com:
“Scenes contain the objects of your game. They can be used to create a main menu, individual levels, and anything else. Think of each unique Scene file as a unique level. In each Scene, you will place your environments, obstacles, and decorations, essentially designing and building your game in pieces”

Game. This is where the game runs and you can see how the end user is going to see your game or a general idea of it, while playing, the Game tab takes control and optionally you can make it full screen. Bottom line, this is where the game runs. It will start in your current scene. You cannot zoom in or edit from the game tab, you have to do it from an inspector or scene instead.

Asset store: This is your assets store, some of which are free and some are not, we will use it later (in like 5 more minutes)

Inspector: this is your “properties” tab, as you select entities you will see the inspector tab changing and displaying different inputs, from sizes to positions or names or a place to add components to a Game Object.

Challenge - Install Unity Remote to your phone 
https://play.google.com/store/apps/details?id=com.unity3d.androidremote 
https://itunes.apple.com/us/app/unity-remote-4/id871767552?mt=8 (not sure if it works)
Unity Remote is a software application that makes your Android device act as a remote control for your project in Unity Editor. This is useful for rapid development when you don't want to compile and deploy your project to Android device for each change and prefer to use the Unity Editor Game window instead.

Go to the sprites directory under projects > Standard Assets > 2D > Sprites
Drag RobotBoyWalkSprite to the scene and play Magic : D


Organize the layout
You can either discard your changes and run git pull SETUP_001 OR just keep going.

For the layout it is important that you use the one you feel more comfortable with, you can edit it from:


Grab the tabs and arrange as desired and/or see the current common layouts, try to have available all debug ones, add a new tab like Animator (Not Animation)


In the Animator tab you can see the state of an animation as well as parameters that can be used for transitions that affect your animations, we’ll cover that later.

Play the scene with your new layout, make changes to the scene like scaling the GameObject of the robot, try to save and then stop and play the game again.

What happened?

Stop the game and then try to save (Cmd + S) - use your preferred name (I’ll name mine Main).




Adding your own sprite:
Throw your changes and checkout ORGANIZE_LAYOUT_002, otherwise, keep going.

Activity: Get your own spritesheet from anywhere on the web and add it to Unity (1 minute), drop it to your assets directory and find it in Unity under the project tab.

Find your sprite in your assets directory and drag it to the scene.
Delete the robot game object.
Cry for your sprite not being ready.

Click your sprite (not the game object) and change the sprite mode to multiple and then go to Sprite Editor in the inspector tab.


Using this one: https://raw.githubusercontent.com/ppartida/NSWS1/76012afee2055316ef616d5bd2c52d59dc9f6a8d/Assets/megaman_running.png


For now we can try to find a grid based spritesheet and use the slice tool adding the required rows and columns followed by slice and apply.

Animation Basics
You can throw your changes and use ACTIVITY_SPRITESHEETS_003

As you can see there are some interactions that are not desirable because of how the grid is sliced OR just because we have too many sprites in our sheet.


Grab the sprite and play, you may see a very weird interaction like everything in one animation. To avoid this we will have to select only one piece of the animation and add it to the scene.

First we will select our gameobject and add a clip / animation under the Animation tab.



With the object selected we can create multiple clips, for now we can create idle and run, while in idle we will change the sample to 2 and grab the 2 related sprites to the timeframe section


We will create a new clip and add sprites to it


For the run we will go with 9 samples + 3 sprites , you can play with your configuration here until it suits your needs.

Our animator should look something like this:

If we play the game, it will just run the idle animation. For this we need to add something called a “Transition” that will help us to switch the animation.

Right click the Idle Animation and add a transition to run, then do the same back.

Under the Animator tab add a new parameter, something like isRunning as a boolean, it should add a new item with a checkbox next to it.

Select your game object and add a new script, to do so, we click Add Component in the Inspector tab, we will name this one MegamanController.



You should be able to double click the script, it will open in MonoDevelop.

For now we will just use the keyboard axis input and use that to set the isRunning flag on to our animator.

In Unity we can add references using the GetComponent with the class type if there is only that one object it will be retrieved. Our controller will look like this:

using UnityEngine;
using System.Collections;

public class MegamanController : MonoBehaviour {
    public Animator MyAnimator;

    // Use this for initialization
    void Start () {
        MyAnimator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update () {
        bool isHorizontal = Input.GetAxis ("Horizontal") > 0.2;
        MyAnimator.SetBool("isRunning", isHorizontal);
    }
}
Then we go back to our Animator and click the idle animation, under transitions we should have a new one called idle -> run if we click it  we will have a section that holds conditions, select isRunning and make sure it is set as true, do the same for the run transition but this time with isRunning set to false.


Play your game with the Game tab selected, use your keyboard and see the animation interaction, with this you should be able to manage animation transitions and then build a complex transition interaction such as the 2d Robot from the preimported packages 




Flip + Fix animation
Throw your changes and checkout the branch ACTIVITY_SPRITESHEETS_004, otherwise let’s keep going.

Now that we’re into code we will update our current code to apply a transformation that scales the x of our sprite to x*-1, meaning we will flip it, we will do this when the Horizontal is negative (we get values depending on the Horizontal state)

        void Start () {
                MyAnimator = GetComponent<Animator>();
        }

+       bool facingRight = true;
        // Update is called once per frame
        void Update () {
-               bool isHorizontal = Input.GetAxis ("Horizontal") > 0.2;
+               float hVal = Input.GetAxis ("Horizontal");
+               bool isHorizontal = hVal != 0;
+
+               if (hVal > 0 && !facingRight || hVal < 0 && facingRight){
+                       switchSide();
+               }
                MyAnimator.SetBool("isRunning", isHorizontal);
        }
+       void switchSide(){
+               facingRight = !facingRight;
+               transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
+       }
}

If we run this we will have to face a problem with our spritesheet (if not then you got a good spritesheet), we can go to the sprite editor and fix by selecting the edges of our current sprite, that will cause our sprite animation to receive the change and get fixed in the scene.


Using the Assets Store

Throw your changes and checkout the branch FLIP_005, otherwise let’s keep going.

Now we will download a couple of assets from the asset store, look up for the 2d Package. To do so press command 9 OR go to window > Asset Store, look for the search box and type 2D pack, you can give a try to different packages or searches depending on your needs, in this case we will download the first free result that was added by Unity Technologies 

Click it and press Import (or download)
It includes from audio managers to Physics Settings, Sprites and other stuff, we can import everything, for the time being I’ll just import the Grass Sprite, sky for background and a couple of sounds like background music or explosion wav. They will be imported using their directory structure under Example Games.

Some of those sprites are already setup to be used so you don’t need to slice them. In this case we will go to our sprites directory and add the grass sprite to the scene as well as the skytilesprite, just grab them into it.

If your character got behind you will have to update the sorting layer and put the background to the lower number in the layer and the player in the front.

Add a grass sprite and resize as you want to be the floor, put the background in the position you want, then play the game.

Since the sky imported asset has an animation, we will just disable it or it will keep blinking.

Let’s add an additional floor at some point of the scene.
Create an empty object for the ground and add the grass as children to it.

Select the just created grass and copy and paste it.
A helper to move things next to the other is pressing the key V near the corner that we want to align as.

2d Basic Physics
We can continue from branch ASSETS_STORE_006
The Rigid Body 
Unity comes with a powerful physics engine, in order to use it we will need to make our players and entities have a rigid body, that means they exist in the world, we will not add this to our background as it is just going to be a plain image there, it does not mean it has to be static, just that the physics like gravity will not affect it, unless we want to.

Select your player and add a new component RigidBody2d
Select the all the grass elements and add a rigidbody as well.
Name your group of grass elements as Ground

Run the game, everything falls, right? That’s fine for our player, but not for the ground, we will put the ground as Kinematic using the inspector, you will need to select all the grass sprite elements.

Now running it the player keeps going through and the floor stays there. Now we need a collider.
The Collider
We can add a collider using groups or by element, we have to select our player and add a new component for BoxCollider 2D, this will add a green rectangle around the player, this can be updated to have a better size depending on our needs, we can have multiple colliders or add materials to determine friction and bounciness.

Activity: 
Add colliders to the grass elements too and adjust them to fit the right size.

Now let’s add a new piece of script that allows us to move the character, for this we can use a velocity to its horizontal axis 

            MyRigidbody.velocity = new Vector2(hVal * MovementSpeed, MyRigidbody.velocity.y);

In this case, we could check for the horizontal axis value is different than 0,

Now add space to trigger a jump, to do so we will have to set up the input (or read which has the trigger attached to the space) under Edit -> Project Settings -> Inupt, we can add a new input by increasing the size of the list or lookup for Jump, it is attached to space, then we need to use GetButtonDown(“Jump”) to make a reference to that button being pressed.
The force code looks like:

        if(isSpace){
            MyRigidbody.AddForce(new Vector2(0, JumpForce));
        }

If your player is rolling while walking around then make sure you have the Rigidbody2D constraint Freeze Rotation Z checked.







Activity: Add the Jumping Animation
Hints: 
Create a variable in your animator
Add a new animation
Create the needed transitions


If you feel a delay in between animations we need to set the blend time to 0 and uncheck the Has Exit Time for all your transitions.

If you have time, feel free to add more animations.





LAYER MASKS
Continue from PHYSICS_007

Even that layers are not related to Physics on their own, they are very helpful to group things up and apply certain physics to different things, for instance, if we want to add coins and enemies but we don’t want to apply physics to them vs the player, meaning we cannot walk over them as we do on the ground, we can create a layer called GROUND or we can just add different layers and group things as Enemies, Pickables, Ground, etc. And if we want to be able to walk on everything but Pickables and Enemies, we can create a collider under the player that reacts only to what we consider ground, here is where layer masks apply.

We will need to create a layer for Background, Camera, Enemies, Pickables, Surface/Ground/etc, Then a LayerMask that excludes everything, this will be used to create a new field called isGrounded and if it is not grounded we can show the jumping animation.

Do this from the inspector selecting each of the groups or game objects as needed.
Once you select an object, go to Layers (Default) and select add Layer, you’ll see a menu like the left one, make the layers you will need. Select the Ground then select the GROUND layer, say yes to the group setting (it will update the children) Do the same for the other elements (to the layer that makes sense)

Now let’s add an empty object with a collider that will follow the user (add the object as child of player), add a new mask layer to the object.
Select your new empty object (name it groundCheck), you can make it visual from the inspector cube icon.


You can move it once inside the player to be near the feet.








Create a new variable called isGround in your class and add it to the animator
Go back to the top of your class and add a new field for the WhatIsGround, the Transform for GroundCheck  and the GroundCheckRadius:

[SerializeField] private LayerMask WhatIsGround;
[SerializeField] private Transform GroundCheck; 
float groundCheckRadius = 3f;

Some where in your update method add a check for the collision in between everything that is ground and the groundCheck (your feet) to know if you are falling/jumping vs you’re grounded.

Go to the player game object and drag the groundCheck into the Ground Check field in the inspector, if it is a valid Transform entity it will be added and then you can use it in your MegamanController.
Click again the Player GameObject and Update the What is Ground field, set it to Everything, and then click the dropdown again to remove anything that you don’t want to walk on.
This is how mine looks like. Remember that this is going to be used to detect a collision that will remove the Jump animation if the user is grounded.

Now let’s add a new script for the camera that will cause a follow interaction, we will use a simple follow using a pre imported script.
We will attach that script to the current camera by adding a 
new component and look up for Camera Follow, if it is not present you can import it from the Flappy Bird project in the 2d pack.
You will have a field to add a Target (Transform), grab the player to that field.



With our current state we can notice that
1 - We keep falling
2 - The background does not move, we can see the part of the background without image


In order to fix this we will use a second camera that displays the background only

First we will set our main camera to use a Depth Only Clear flag or it will override the bg camera with a plain color.


We’ll create a second camera under the hierarchy and call it bg camera or Hud Camera, anything that lets you know this is a secondary camera with “fixed” content

Make this second camera to use a Culling Mask of BACKGROUND, the main Camera also needs to remove this from the Culling Mask, also remove the audio listener for the background one or you keep getting a warning about having 2 audio listeners in the same scene.





Optionally we can move the background and the secondary camera out of the main camera section



Let’s re play to see how the bg is now always present.


Basic HUD
Add a text object, name it score
Notice it created within a canvas, Right click the canvas and add a slider
While selecting the canvas, drag the main camera to the Render Camera property




Customize your Slider using an image or fill, up to you. Update the min/max values and set the current value to the max. I’ll use 0 - 100, uncheck the interactable checkbox so it just updates via code. Update Fill and Fill area to 0 left/right and hide the image for the handler.

Add two new UI fields to your player

using UnityEngine.UI;
….
    public Text scoreText;
    public Slider healthBar;

drag the hud entities 

Change the text value to “Score: 0” and center it.
Make the score to be updatable on collision of anything.
    public Text scoreText;
    private int score = 0;
...
    scoreText.text = "Score: " + score;
...
    void OnTriggerEnter2D(Collider2D other)
    {
        //print (other.transform.ToString());
        this.score++;
    }
//TODO: Review if this is a good practice or what is?

    




Activity: Fix the double jump and make the Camera follow you on Y axis (it is just doing it on X)

Fix double jump, make the jump action available only if the character is grounded, otherwise you can keep jumping in the air.

if(isJump){
if(isGrounded && isJump){
            MyRigidbody.AddForce(new Vector2(0, JumpForce));

Now let’s update the camera follow attached to the main Camera with this code:

        transform.position = new Vector3 (target.position.x + xOffset, followY ? target.position.y:transform.position.y, transform.position.z);


This is just an imported script that is following in the X axis, if we want the camera to follow Y then we can use that and add that configuration if we want it.

Optional (go back to the main scene and re add the hud code and attach it to its own camera)

Another way to define your HUD is using Overlay mode for Canvas instead of attach it to the camera:


Adjust the pivot and the X, Y
Shooting 

Download a new bullet sprite or use [ https://raw.githubusercontent.com/ppartida/NSWS1/2e5fe9ad849632295fe983bfde498cc8ca6d771b/Assets/BulletBillWii.png ]
Create a new folder under assets, call it Resources
Drag and drop your player to the Resources section.
Save your current scene and Create a new one, name it sandbox.
Add a grass so we can stand there, make it kinematic with rigid body and collider.


Create a new empty object and add it to the player, move it to where the gun end will be.
Add a new audio source for the gun and select the explosion (import it from the 2d assets if needed)
Add a new Script component to the player, call it PlayerShooting.

Drag the Bullet to the scene and update it as needed (size/rotation/sprites) etc.
Our current example is just a plain image so we just resize it.

In the PlayerShooting script we will create 


Prefabs & Bullets

We will need to add a spawner of the bullet
We need a bullet sprite, we may make it as a prefab so it can be used in code

Create a public field and drag the prefab so it can be cloned using something like:


	GameObject getBullet(){
		GameObject clonedBullet = Instantiate (bulletBill, transform.position, transform.rotation) as GameObject;
		return clonedBullet;
	}

And in the BulletController you can call:  Destroy(this.gameObject); after certain conditions like time, collide, etc.

Revert value to prefab

Find Object
Starts from: 011_SHOOT_PREFAB

One of the issues we may have noticed is that the bullet is shooting always pointing to the right (depending on the asset), if we want to switch it based on the player we will have to add a reference of the player to the bullet interaction, which will cause prefab issues similar to the ones with the camera. Instead of doing that, we will use a function called 
FindGameObjectWithTag
Part of the  GameObject
To do so, we will add these pieces of code to the PlayerShooting controller:

+	MegamanController playerController;
+	void Start(){
+		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<MegamanController>();
+	}

	GameObject getBullet(){
		GameObject clonedBullet = Instantiate (bulletBill, transform.position, transform.rotation) as GameObject;
+		Vector3 bulletScale = clonedBullet.transform.localScale;
+		int side = playerController.isFacingRight() ? -1 : 1;
+		clonedBullet.transform.localScale = new Vector3 ( bulletScale.x * (side), bulletScale.y, 1);
		return clonedBullet;
	}

There could be a problem if you want to use the same player as an enemy or as a second player, there would be multiple players, instead of using the find by tag, we can navigate through parents until we hit the player, since Gun is the game object where player shooting lives, we can go to Gun’s parent.

Activity: Try to replace with a prefab the player instead of the one built in the scene.

Drag and drop the game object to a resources directory if not already.
Delete the game object
Drag back the prefab
Run and see the error with the camera
Use get by tag with the camera to use that transform instead of set using the GUI

Activity: Add force to the bullet so it moves.

Restore Text and Health Bar objects.
Hint: you can assign a tag to those elements and load them in the main user controller, then you can create a method that will access those elements on different actions, that way you can show the score system to the user.

scoreText = GameObject.FindGameObjectWithTag ("HUD_SCORE").GetComponent<Text>();
healthBar = GameObject.FindGameObjectWithTag ("HUD_HEALTH_BAR").GetComponent<Slider>();



Collide bullet
Starts on: 012_FIND_OBJECT

ACTIVITY allow the bullet to destroy the enemy:
Bonus: Give HP (not visible) to the enemy.

Create an addScore public method to the megaman controller.
Initialize the player Controller from the Bullet Controller.
Create a prefab of the enemy
Give a tag NPC_ENEMY to the enemy
Add 	void OnTriggerEnter2D(Collider2D other) to the BulletController, you can reference the other object (the one being collided with the bullet, and check for the tags or other attributes of that object. For now this should just destroy both the bullet and the hit npc

Lose Condition: Touch an enemy
Starts on: 013_COLLIDE_BULLET

You can use a method inside your controller called OnTriggerEnter2D that accepts a Collider2D as argument then we will parse the given object to see if it is an enemy. To do so, we will add a tag to the enemies and use 
void OnTriggerEnter2D(Collider2D other)
{
        GameObject obj = other.transform.gameObject;
        if(obj){
                string tag = obj.tag;
                if(tag.Equals("NPC_ENEMY")){
                        playerController.addScore (1);
                        Destroy(obj);
                        Destroy (this.gameObject);
                }
        }

}

We can do something similar on the megaman controller and call an add damage function when the user collides with an enemy.


Use void OnTriggerEnter2D(Collider2D other) to cause damage while touching the enemies.

We can declare a function that receives damage for this matter

Improving the animations for damage receiving:

Also we will improve our animation by creating a new animation for receiving damage, we have to select the controller for that animation (same name as the animation) and make it not be a loop, finally add a new event under the animation timeline and make it call a function called “damageEnd()” then that should end the animation.



	void damageEnd(){
		MyAnimator.SetBool("isDamaged", false);
	}

	public void addDamage(int dmg){
		MyAnimator.SetBool("isDamaged", true);
		this.currentHP -= dmg;
	}


The lose condition depends on your game design, it could be from losing hp and make it a game over, restart the current level, make the user lose a life, etc.

For now we will define a “die” method and add there some behavior as well as a “revive” that would do the opposite.

On die:
Show the dying animation
Prevent the user from moving, shooting or receiving damage interactions.
Stop the camera
Call Revive 
On revive:
Stop any damage/death animation
Re position the character to an origin point
Allow any action, such as movement, shooting, incoming damage.

Things that cause death:
HP is 0
Out of the screen ( y < -10 )

Win Condition: Touch a Flag
Starts on: 014_LOSE_CONDITION

In a similar way to the lose condition, since this depends in our logic and our game, we can decide what is to be a win, a reward or a full game finished.

In this case we want to be able to touch a flag and that should take us to to the next level.
Build a second scene and call it Level2, rename your main or create a new scene for Level1.
Make use of the function:  Application.LoadLevel(“Level”+currentLevel);

The next level (current available 1 and 2)

Additionally, at this point you may want to keep track of the status of your score or health bar (as well as items you may have win as you play)

To do so you can help yourself with the PlayerPrefs utility
		PlayerPrefs.SetInt("key", valueToBeSet);
		PlayerPrefs.GetInt("Current", defaultValue);


	public void win(){
		PlayerPrefs.SetInt("score", score);
		PlayerPrefs.SetInt("currentHP", currentHP);

		loadNextScene ();
	}
	
	public void loadNextScene()
	{

		int currentLv = PlayerPrefs.GetInt("Current", 1);
		currentLv++;
		
		if (currentLv > 2)
		{ // Update if adding more levels.
			currentLv = 1;
		}
		PlayerPrefs.SetInt("Current", currentLv);
		Application.LoadLevel("Level" + currentLv);
	}






Give life to an enemy:
Starts on: 015_WIN_CONDITION

Add new levels:
Starts on: 016_ENEMY_CONTROLLER

Add new skills to megaman:
Starts on: 017_PLAYER_IMPROVEMENTS






Notes & references:

Best Practices
http://devmag.org.za/2012/07/12/50-tips-for-working-with-unity-best-practices/

2d tutorials
http://unity3d.com/es/learn/tutorials/topics/2d-game-creation 

Documentation:
http://docs.unity3d.com/Manual/index.html 

Bullets + Prefab example:
http://answers.unity3d.com/questions/19710/shooting-a-bullet-projectile-properly.html 
