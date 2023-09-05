# swapicons
C# Unity script to fade out a sprite, swap it with another and fade in

Add this script to any game object with a SpriteRenderer attached.

## Requirements
- game object must have a `SpriteRenderer`
- must have a collider2D with `Is trigger` turned on
- script will expose an `Alt Icon` property where you need to drag a sprite to it in the editor
- your player character needs to have the "Player" `tag` attached to it (line 46 in the script relies on this)

### Notes
This was created for 2D objects but can be easily adapted to 3D by simply replacing all `2D` occurrences with `3D` :)

### Motivation
I couldn't find a good way to create a fade in, swap and fade out example anywhere. 
So after much fussing around I created this solution which seems to work very well. 

### Caveats
- don't call this inside an `Update()` method!
- it will cause issues
- Coroutines should not be called inside methods that themselves are called every frame unless you know exactly what you're doing
- you shouldn't need to call this anywhere really. It's written so it works out of the box as soon as you player triggers the 2D collider
