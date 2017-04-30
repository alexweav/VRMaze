# VRMaze

Using Unity 5.5.1, we are developing a Virtual Reality(VR) Maze game. Unity is a cross-platform gaming engine, most commonly used to develop games. The game is designed for the Android (and iOS platform) using Google VR DevKit v1.20.

## Tools 
- **Unity 5.5.1**, asset development
- **Visual Studio 2015 Community**, script and test development
- **Unity Monodev**, alternate script and test develpoment
- **GitHub**, Configuration management
- **ZenHub**, Project management
- **Travis CI**, continuous integration and validation, automated builds and tests
- **Slack**, communication
- **Google Drive/Docs/Sheet**,  documentation management
- **Google VR DevKit**, Google development kit for Google Cardboard VR

# Installation Instructions for Andriod Devices
### Requirements
- Android Device
- Android 4.4 ‘KitKat’ +
- VR Headset for mobile phones
### Installation
- Open up the download file from release notes below, from your Android device.
- Select the build you want to test
- Allow the app to download to device
### Release Notes
- [VRMaze 4-29-17 (188MB)](https://drive.google.com/open?id=0B89D1zEkAyAIYVdHZUV6NlRyOXM)
	- In game pause menu is now added. Allows player to pause current game with the option to return to the main menu.
	- Minimap is now displayed in the upper right hand corner. Maze appears based on which cells the player has walked over.
	- Add Time Trials game mode.
	- VRMaze detects is the game has been sent to the background. Will later automatically pause the game.
	- Live timer has been added to track how long the player has been in the maze.
	- Tutorial mode has been updated. User now has to complete tasks that help them learn VRMaze controls.
	- Teleport collectable if currently working and detectable on the minimap. Only in Free Roam Mode.
- [VRMaze 4-2-17 (187MB)](https://drive.google.com/open?id=0B62QyooVl2uabjBmb09VcUpodzA)
    - Game no longer has a white screen when coming back from background
- [VRMaze 3-19-17](https://drive.google.com/open?id=0B62QyooVl2uadkxWblRYc3dTRTQ)
    - Maze now generates randomly, no more static maze
    - Textures have been added
    - Movement speed holds its current state unless player looks up to stop
    - Light has been adjusted to remove shadows for testing
 # Installation Instructions for Unity
### Requirements
- [Unity v5.5.1](https://unity3d.com/get-unity/download/archive?_ga=1.262415500.188541325.1488401089)
### Installation
- Download VRMaze repository to your machine
- Open unity and locate “VRMaze” on your machine
- Once the project is loaded, run the project with only ‘MainMenu’ scene
- Press play on the top of Unity program
### Controls
- Use ‘ALT‘ + Mouse to control the in-game player
- If you look down towards the floor the player will start moving forward
- To stop forward progression,the character must look slightly up.



