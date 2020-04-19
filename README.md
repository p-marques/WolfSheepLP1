# Wolf and Sheep

**Project 1 - Linguagens de Programação I 2019/2020**

**Videojogos - Universidade Lusófona**

### Authors

#### Pedro Dias Marques - 21900800

- Argument handling;
- Game logic;
- Player logic;
- User interface.

#### Pedro Fernandes - 21908084

- Board logic;
- Piece logic;
- Coordinates system;
- Report.

**Github:** [Link](https://github.com/p-marques/WolfSheepLP1)

## Solution Architecture

### The Flow

![flowchart](flowchart.png "Flowchart")

**Figura 1** - Program's flowchart. Made with [Draw.io](https://www.draw.io/).

The program starts by handling any given arguments. They are all optional, but once passed in they must be valid and serve to override default application settings.

**Available Commands**

- -h: ignores all other arguments, displays arguments help messages and closes the program;
- -s: the size of the board. Must be an even number between 8 and 16. Default is 8;
- -pw: the name of the player controlling the wolf piece. Length must be between 2 and 12. Default is Wolf Player;
- -ps: the name of the player controlling the sheep pieces. Length must be between 2 and 12. Default is Sheep Player.

If any arguments are found to be invalid an appropriate error message is displayed and the program closes.

Assuming that all passed in arguments are valid and -h wasn't invoked, an instance of Game is created and the game loop begins. The first thing to do consists of the Wolf Player deciding in witch of the top playable squares to place his piece. After that it can perform his first move. Then it's the Sheep Player's turn. He starts every one of his turns by first selecting witch piece he wishes to move. After that he can perform his move. The game will continue with this pattern, Wolf Player - Sheep Player - Repeat, until one of these conditions are met:

- The Wolf Player won. Conditions:
    - The Wolf Player has moved his game piece to one of the original starting positions of the Sheep Player's pieces.
- The Sheep Player won. Conditions:
    - The Sheep Player trapped the Wolf Player, leaving him with no possible moves.
- One of the players opted to exit the program by pressing ESCAPE during a round.

Before closing the program will always displays a game over screen, adding information about the winner if there is one.

### The Code

The program starts on the `Main()` method in the `Program` class. It starts by creating an instance of `ConsoleUserInterface`, class responsible for managing the user interface. This instance is made available through a static property named `UIManager`. Afterwards `Options.ParseOptionsFromArgs()` is invoked. This method will handle any given arguments and return an appropriate instance of `Options` that contains all necessary application settings. If any passed in argument is found to be invalid the program closes. If everything is ok, an instance of `Game` is created and `Game.Play()` is invoked, starting the game.

### Class Design

There was an attempt at objectifying everything about the game. This is perhaps at its most extreme with the usage of child classes for `Piece` in `WolfPiece` and `SheepPiece`. This could perhaps be considered unnecessary since all they do is override a single property but conceptually it made sense to us since functionally they are different, they look different, they move differently too. This results in clearer code too.

`ConsoleUserInterface` as responsible for maintaining the entire UI is a major class. Even though no Interface was created for the class to inherit from, especial care was taken to make sure that core application features are kept away from `ConsoleUserInterface`. All internal logic are handled by other classes, specially `Game` and `Board`. All that `Game` does is invoke `ConsoleUserInterface` giving him clear instructions and passing him only relevant data. This means that if desired the same code could be used for alternative UI solutions.

#### Usage of Enumerations and *Structs*

This application uses these enums: `Direction`, `OptionsParserResult` and `PlayerInputState`. These serve to limit available values when appropriate.

The *structs*: `ConsoleSettings`, for organization purposes, containing all default setting for the `ConsoleUserInterface`; `Coord` describes the position of a `Board Square` on the board. An override to the `ToString()` method is used; `Options` is used to hold application settings witch are set early in the application start and never changed again.