# MazeKeeper

This project is a 3D horror maze game created in Unity. The player must navigate through a maze while being hunted by a teleporting enemy. The enemy constantly tracks the player's location using Unity's NavMesh system. Looking directly at the enemy causes it to stop for two seconds before teleporting to a random corner of the maze and resuming its chase. If the enemy catches the player, the player is returned to the starting position while the enemy teleports away to continue the hunt.

## Instructions for Build and Use

Steps to build and/or run the software:

1. Open the project in Unity.
2. Open the main game scene.
3. Press the **Play** button in the Unity Editor, or build the project through **File > Build Settings** and run the generated executable.

Instructions for using the software:

1. Use the **W, A, S, and D** keys to move around the maze.
2. Move the mouse to look around.
3. Avoid being caught by the enemy while exploring the maze.
4. Looking directly at the enemy will temporarily stop it before it teleports to another corner of the maze.
5. If the enemy catches you, you will be teleported back to the starting position and must continue navigating the maze.

## Development Environment

To recreate the development environment, you need the following software and/or libraries with the specified versions:

* Unity (Version used for the project)
* C#
* Unity AI Navigation (NavMesh) Package
* Visual Studio or Visual Studio Code (for C# scripting)

## Useful Websites to Learn More

I found these websites useful in developing this software:

* https://docs.unity3d.com/
* https://learn.unity.com/
* https://docs.unity3d.com/Manual/nav-NavigationSystem.html

## Future Work

The following items I plan to fix, improve, and/or add to this project in the future:

* [ ] Add collectible objectives or keys to escape the maze.
* [ ] Improve the enemy AI so it teleports to smarter locations and avoids teleporting into the player's view.
* [ ] Add sound effects, background music, and ambient horror effects.
* [ ] Create a win condition and ending screen.
* [ ] Add a main menu, pause menu, and settings options.
* [ ] Improve the maze visuals with lighting, textures, and environmental props.
* [ ] Add difficulty settings that change the enemy's speed and behavior.
