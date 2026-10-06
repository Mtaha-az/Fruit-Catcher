# 🍓 Fruit Catcher

An endless 2D arcade game built with **Unity** and **C#**. Catch the falling fruit in your basket, avoid the bombs, and try to beat your highest score. Developed during my game development internship.

## 🎮 Play the Game

### [▶ Play Fruit Catcher Online](https://portal.uetgamestudio.com/games/fruitcatcher)

No download needed. It runs in your browser on desktop and mobile.

## 📌 About the Game

Fruit falls from the top of the screen and you move a basket left and right to catch it. The game ends when you miss three fruits, or instantly if you catch a bomb. Your highest score is saved and shown every time you play, so there is always a number to beat. The longer you survive, the faster things fall.

## 🎯 Features

- **Endless gameplay:** keep catching fruit and build up your score
- **Simple, intuitive controls:** keyboard arrow keys on desktop and touch drag on mobile
- **Three misses and you're out:** every fruit that hits the ground removes one of your life objects, and the game ends when all of them are gone
- **Bomb hazard:** bombs begin falling after the first 15 seconds, and catching one ends the game immediately
- **Gentle start:** the game opens with three fixed fruits that spawn slowly. After those, fruit spawns twice as often and is chosen at random from the full set
- **Increasing difficulty:** the fall speed of fruit and bombs rises every 15 seconds, and the basket speed also increases gradually up to a maximum
- **Highest score tracking:** the best score is saved with `PlayerPrefs` and displayed alongside the current score
- **Basket that changes as you play:** the basket sprite updates as you catch fruit
- **Sound effects:** audio feedback for catching fruit and for game over
- **Animated UI:** game over panel and menus scale in smoothly, even while the game is paused, with different sizes for mobile and desktop
- **Game over menu** with Restart and Home options
- **Platform-aware layout:** on WebGL the game detects whether the player is on a mobile device and switches the canvas and background between the portrait mobile layout and the landscape desktop layout

## 🧩 Key Scripts

| Script | What it does |
|---|---|
| `BaskitController.cs` | Moves the basket with keyboard or touch input, keeps it inside the screen bounds, and slowly increases its speed |
| `InfiniteSpanwer.cs` | Spawns fruit at random spawn points, handles the slow opening sequence, then random fruit, and raises gravity over time |
| `BombsScript.cs` | Spawns bombs after a delay, with gravity that increases as the game goes on |
| `FruitsHealth.cs` / `BombHealth.cs` | Destroys fruit and bombs when they hit the bucket or the ground |
| `GroundTrigger.cs` | Counts missed fruit, removes one life object per miss, and shows the game over panel after the third |
| `BasketSprites.cs` | Plays the catch sound, changes the basket sprite as fruit is caught, and ends the game when a bomb is caught |
| `ScoreManager.cs` | Tracks the current score and saves and displays the highest score |
| `GameOver.cs` | Game over panel, Restart, Home, quit popup, and the instructions panel |
| `LevelCanvesManager.cs` / `MainPageCanvasManager.cs` | Mobile vs. web detection that switches canvases and backgrounds |

## 🛠️ Built With

| Technology | Purpose |
|---|---|
| Unity (2D) | Game engine |
| C# | Gameplay, spawning, and UI logic |
| TextMeshPro | Score display |
| WebGL | Browser deployment |
| PlayerPrefs | Saving the highest score |
| Git & GitHub | Version control |

## 📂 Project Structure

```
Fruit-Catcher/
├── Assets/           # Scenes, scripts, sprites, audio, prefabs
├── Packages/         # Unity package configuration
└── ProjectSettings/  # Unity project configuration
```

## ▶ How to Open the Project

1. Install Unity Hub and the Unity version listed in `ProjectSettings/ProjectVersion.txt`.
2. Clone the repository:
   ```
   git clone https://github.com/Mtaha-az/Fruit-Catcher.git
   ```
3. Add the folder in Unity Hub and open it.
4. Open the **Main Menu** scene from `Assets` and press **Play**.

## 👨‍💻 My Role

I designed and developed this game during my game development internship at UET Game Studio, including the gameplay, spawning and difficulty scaling, score tracking, UI, sound, and the mobile and desktop layouts.

## 📫 Contact

[GitHub: Mtaha-az](https://github.com/Mtaha-az)
