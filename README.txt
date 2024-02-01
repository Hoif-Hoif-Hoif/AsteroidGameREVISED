Repo: 
https://github.com/Hoif-Hoif-Hoif/AsteroidGameREVISED/tree/main

For my revision of this assignment I decided to create my own quick asteroid game and add my tools to that one, rather than add it to the pre-existing game. Primarily this was done so that I could focus and isolate issues I had with the editor and UI tools and thus easier understand how they work and resolve it.

The game itself is very basic 2D space shooter where you must shoot at asteroids swung at you. After setting up the basic gameplay I proceeded with adding scriptable objects (Named Entity) to both the asteroids and ship to store values such as HP and speed. These Scriptable Objects were then to be modified via the UI Tools (TheEditorWindow).

By far the trickiest part was setting up the UI Tool itself. While very rudimentary it works as I've intended, allowing you to input values which are then applied to their respective objects. Changing things both outside and in-game.

After feedback I added in variants to the asteroids of which can be detected by clicking on them in the scene tree and edited via the UI tool.
#
The main benefit of scriptable objects from my experience is their versatility and consistent data (in terms of being applied universally irrespective of instances). In addition it's their ability (combined with UI tools) to affect a lot of the game at once and while it's running. While not the most practical for a small game perhaps, I can certainly see its use in a bigger game.