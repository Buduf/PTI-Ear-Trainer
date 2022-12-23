# PTI Ear Trainer
[![SonarCloud](https://sonarcloud.io/images/project_badges/sonarcloud-white.svg)](https://sonarcloud.io/summary/new_code?id=Buduf_PTI-Ear-Trainer)

## Building from command-line

First clone the repository and install [.NET 6.0 (or higher) SDK](https://dotnet.microsoft.com/download/dotnet/6.0).

To build PTI Ear Trainer, open a command prompt inside the project directory. Then type the following command:
`dotnet build -c Release -o build` the built files will be found in the newly created build directory. You can run the application with `PTI-Ear-Trainer.exe`.

## How to play
The game is simple.
It will play two notes, and you have to guess what interval was it exactly.
The different diffculties give you more and more opportuninity to chose from the intervals.
For example, in easy mode you can choose from 6 and on medium, you can choose from 9.

There are also 3 different game modes.
In practice mode, the game plays the music and you can choose a note.
In ranked mode, at the end of the game, your name and your point will be saved to the leaderboard.
After all, in survival mode the game runs until your first miss.
