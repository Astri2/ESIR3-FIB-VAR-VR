# VR Project Report 

						

THIÉBAUD Malo & CAILLÉ Charlotte

# The application

The scene is a medieval room.  
We start in front of a chest but we cannot interact with it. The lock is glowing, meaning something is up with it…  
The goal is to find a way to open the chest and enjoy the cookies inside\!  
You can interact with several objects and change settings through interactions in the game.

# Technical details  
The project has been developed using Unity 6000.2.6f1.  
Here is a link to the github repository: [https://github.com/Astri2/ESIR3-FIB-VAR-VR](https://github.com/Astri2/ESIR3-FIB-VAR-VR). You can simply clone and you should be able to run the game from Unity Editor.  
Here is a link to the apk download:   
[https://github.com/Astri2/ESIR3-FIB-VAR-VR/releases/tag/v1.1](https://github.com/Astri2/ESIR3-FIB-VAR-VR/releases/tag/v1.1). It has been tested on the Meta Quest 3 headset.

# Tutorial

To grab an object, approach the left controller and press the grab button. If you are close enough to grab the object your hand changes colour. You can also press A on your right controller to toggle the “hand mode”, allowing you to grab objects using your right hand as well if you want to.  

To move inside the scene you have two choices: you can use the joystick of the left controller or use teleportation spheres. To change from one to another the handle of the “menu” must be moved to the other side.  


To use the teleportation sphere, use the right controller to point the sphere where you want to go and press the grab button.  

It is possible to move up and down by using the right joystick, allowing the player to reach higher or lower grounds. This can come handy if the player drops an item on the ground and doesn’t want to crouch to get it back.

To personalize the colour of the glow of the interactables objects, go to the colour picker. Point at the new colour with the ray that appears at the right hand and select it by pressing the grab button.  

If you want to unlock the chest, you need to grab the key and pass it on the lock. The lock will disappear after a little animation and it will be possible to interact with the chest.  

To eat a cookie, grab it, bring it to you and press the X button on the left controller.

But there is more\! You can actually grab the cookie with your second hand as well (remember that pressing A on the right controller allows you to enable the hand). You can then scale up the cookie and get a **giant cookie**\!\!\!  

# Control Mechanisms  
As shown above, two control mechanisms have been implemented:

- Change of locomotion mode through the “Movement Menu”.  
- Change of glowing color through the Color Picker.

# Player guidance

Several features are present to help the user to feel comfortable and understand the environment he’s evolving into:

- The user can switch between two modes of locomotion (Free movement using a thumbstick and teleportation). Both modes have been coded by us, we did not use the implementation given by the XR library.  
- The free movement uses acceleration and terminal velocity to smooth the movement as much as possible (it is very slow because we were getting headaches quickly with VR).  
- Every interactable object in the scene will start to glow periodically when the player gets close enough. This allows the user to know he can interact with the object rather than trying to grab every single object of the scene.  
- Whenever the player is close enough to an object to grab it, or points the laser at it, the hand will change color to give an indication to the player.  
- Finally we added a sound effect to the teleportation. The objective is to send a signal to the brain that something is happening before the image changes.

# Demo

Here is a link to the demo video: [https://www.youtube.com/watch?v=u1CjvsdeHrY](https://www.youtube.com/watch?v=u1CjvsdeHrY)  
Please note that there will be some small changes with the final application because we had to use someone else’s computer to record the video and we have made some small improvements to the project since then (interactable books, cookie scaling, audio and in-game indications).
