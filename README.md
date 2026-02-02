# 🎮 WinForms 2D Game

A 2D action game built with Windows Forms and C# featuring animations, collision detection, and sound effects.

## 🎯 Features

- **Animated Character**: 4-direction movement with sprite animations
- **Enemy AI**: Randomly spawning enemies that move across the screen
- **Fireball Combat**: Shoot fireballs with animated projectiles
- **Health System**: Player health with visual feedback
- **Score Tracking**: High score saved to file
- **Sound Effects**: Integrated sound manager for game events
- **Screen Shake**: Visual feedback on hits

## 🎮 Gameplay

### Objective
Survive as long as possible by dodging enemies and shooting them with fireballs.

### Controls
- `NumPad 4`: Move Left
- `NumPad 6`: Move Right
- `NumPad 8`: Move Up
- `NumPad 2`: Move Down
- `NumPad 7`: Shoot Fireball

### Game Mechanics
- Enemies spawn from the left and move right
- Each enemy hit increases your score
- Colliding with enemies reduces health
- Game ends when health reaches zero

## 🛠️ Technologies Used

- **Language**: C# (.NET Framework)
- **GUI**: Windows Forms
- **Graphics**: System.Drawing for animations
- **Audio**: System.Media.SoundPlayer
- **File I/O**: JSON/Text files for save data
