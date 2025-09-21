# Bubble Chase

## Play the Game
**Unity Play Link**: (https://play.unity.com/en/games/d6410132-b270-4274-b402-a66cfcdd8304/bubble-chase)

## Game Overview
Play as a mermaid in a small ocean surrounded by dangerous bubbles! Swim away from them before they pop you, and try to survive for as long as you can.

### Controls
- A mouse is reccomended
- The mermaid will move toward your mouse pointer as long as it is pressed.
- Release the button to stop speeding her up, but remember that momentum is strong underwater!

### How to Play
Steer the mermaid away from the bubbles and the walls for as long as possible.

## Base Game Implementation

### Completion Status
- [x] Player movement and controls
- [x] Obstacle spawning system
- [x] Collision detection
- [x] Score system
- [x] Game over state
- [X] Visual Upgrades
- [X] Sounds
- [X] Borders Dissapear
- [X] Difficulty Scaling
- [ ] High Score Rememberance
- [ ] Character Customization

### Known Bugs
- The mermaid's speed in the WebGL version is extremly slow.
  - changing settings/variables in the game has no effcect on this.

### Limitations
- The game does not have a large difficulty ramp-up
- No mobile or button controlls

## Extensions Implemented

### 1. Create a Cohesive Color Scheme (2 points)
**Implementation**: Most objects were replaced with new sprites, the Borders were re-colored to be a darker and more saturated version of one of the background colors.
**Game Impact**: It changes the aesthetics, making it more fun and easier to understand visually.
**Technical Details**: Recoloring an object's default sprite.
**Known Issues**: N/A

### 2. Change your entire Game Concept (3 points)
**Implementation**: I used PixelStudio to create custom sprites for the obstacles, player, background, and particles. The background was a square I could tile to cover the whole area. The mermaid has 2 versions, one for when it is moving and one for when it is not. The bubbles and particles are just simple png files.
**Game Impact**: More ineresting to play and more unique theme. The assets matcheachother and add to the overall *unity* of the game. (haha I'm so funny)
**Technical Details**: I imported my assets as png files and replaced the original sprites of each object/prefab with my new ones. SOme collision boxes were changed to reflect the new sprites.
**Known Issues**: N/A

### 3. Swap out your sprites (3 points)
**Implementation**: See above
**Game Impact**: ^^
**Technical Details**: ^^
**Known Issues**: N/A

### 4. Destroy Borders on Game-Over (4 points)
**Implementation**: I added a section to my PlayerController script to make the borders inactive when the player dies.
**Game Impact**: When the player dies the screen becomes a lot less distracting, as the bubbles all fly away without borders to bounce them back in.
**Technical Details**: Set the borders active when a new game started, and inactive when the player died.
**Known Issues**: N/A

### 5. Add ambient background particles (4 points)
**Implementation**: Created a particle system and increased the range to spawn them everywhere on screen. Changed some settings so that they will move in semi-random directions, with a trend towards the top of the screen.
**Game Impact**: Makes the background more dynamic, adds to the immersion.
**Technical Details**: Added a particle system and tweaked its settings.
**Known Issues**: N/A

### 6. Increase difficulty over time (5 points)
**Implementation**: I increased the bounciness of the Obstacle material to 1.05, meaning each time they bounce against any surface they gain a very small amount of force. 
**Game Impact**: The longer the player survives the more difficult it is to avoid obstacles, so it adds a small difficulty-ramp.
**Technical Details**: Changed bounciness of a material.
**Known Issues**: N/A

### 7. Add sound effects and background music (5 points)
**Implementation**: I added 3 sound effects to the game: ambient background music, splashing when the mermaid moves, and a pop on the players death.
**Game Impact**: It adds a lot of interest to the game by giving it auditory input in addition to visual. I also think it makes it more clear when the mermaid is being sped up vs is coasting, and a more definitive end with the pop.
**Technical Details**: Added audio sources to the main scene or pre-existing objects to ensure they were active at the right times.
**Known Issues**: N/A

### 8. Animate booster graphic with audio (6 points)
**Implementation**: I created a sprite for the mermaid when she is coasting and one for when she is accelerating, and switch which one is active when the mouse is pressed or released. The difficult part with this was that the moving sprite was larger that the idle one, so I had to scale it down and change the collision box to make the game still possible to play. The tips of her tail and hands are not included in the collision box when she os moving, this makes sure players don't die when they start to move her and have a little leeway in small overlaps with bubbles.
**Game Impact**: It makes it more clear when she is moving, and adds feedback to the players actions.
**Technical Details**: Had 2 sprites and switched which was active based on mouse input.
**Known Issues**: N/A

## Credits
- Sound assets:
  - Background music from:
  - Bubble pop effect from:
  - Mermaid swiming effect from:
- Visual Assets:
  - All assets created by me with the software PixelStudio
    - Coincidentaly, PixelStudio was created in Unity

## Reflection
**Total Points Claimed**: Base: 80% + Extensions: 32% = 112% (I could be wrong about getting the points from animating the booster graphic w/ sound effects, in that case it is 106%)

**Challenges**: 
- Getting all of the movement settings properly tuned in to be challenging but not overly frustrating was difficult, as changing one of them meant the others needed ot be adjusted to reflect it.
- Additionally, getting the custom sprite into the particle effects required making a whole new material with specific settings. The first test had solid black squares for the sprites, and I had to change the type of texture it was rendering to fix it.
- The mermaid sprites being different sized was a large problem until I scaled one down and changed the collision boxes, as it was nearly impossible to play with the original settings.

**Learning Outcomes**: I learned a lot about how the Unity platform works, and how to use it most effectivly with prefabs, custom scripts, public variables, and built-in settings.

## Development Notes
I had a great time!
