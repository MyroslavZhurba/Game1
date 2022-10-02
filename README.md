# Console game Tetris
![net](https://img.shields.io/badge/.NET_Core-3.1-isucces?style=plastic&logo)
![sharp](https://img.shields.io/badge/C%23-8.0-blue?style=plastic&logo)
![coverage](https://img.shields.io/github/languages/top/MyroslavZhurba/game-1?style=social)
## Desctription
The game is implemented on C#.

The program generates you a new figure at the begining and after every time your figure hits an obstacle (cause you cannot move your current figure).

It contains 5 different figures such as:
- T-figure
- S-figure
- L-figure
- Stick
- Sguare

Every figure can be rotated or moved in different directions.
Figures are falling down by themselves, so your time is limited. The mission is to hold out as long as possible!

When you fill any whole line with your figures, so that it has not any free space, the program deletes this line.
But if the same situation occurs in any column, unfortunately, it means that you have lost and the program writes "Game Over" to the console.  

This is a console game, to start it you just need to run the program.
## How to play
- <b>Move</b> your figure using arrows on your keyboard
- <b>Rotate</b> it by pressing the spacebar (figures can have different quantity of rotate directions)
