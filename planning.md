# Planning

## Questions
- Who is this for?
- Console app with in-memory storage only?
- Should all operation inputs and outputs be integers only?
- What's a reasonable default range for outputs? [0, 100] for addition and multiplication? [-100, 100] for subtraction, i.e. allow negative results? Or perhaps even [-100, 100] for all operations?
- Should trivial cases, like `10+0`, be excluded? If so, how do we determine what's trivial? (Dividends in the range [0, 100] implies trivial divisions are OK.)
- Should the user get the correct answer immediately, or should the game go immediately to the next round?
- How many rounds in a game by default? 5?
- How should the menu work? Choose a game or history by pressing numbers/letters? Or arrow keys and enter?
- Menu items: Addition, subtraction, multiplication, division, history, quit?
- How should previous games be visualized in the history?
- Should levels of difficulty be implemented using discrete levels e.g. difficulty 1 to 5? Or fully by user e.g. setting allowed range of output and/or max time per round?
- Does "Add a timer to track how long the user takes to finish the game" mean counting the time to play a game (consisting of a number of rounds), or counting the time the user spent in the application (and for example printing the time when quitting the application)?
