# Planning

## Clarifications
*Quoted answers come from [ChatGPT](https://chat.openai.com/) who plays the role of external stakeholder (i.e. customer).*

- Who is this for?
  - >*This app is for anyone who wants to practice math skills and enjoy a fun, educational game.*
- Console app with in-memory storage only?
  - >*Yes, a console app with in-memory storage is sufficient. No need for database storage.*
- Should all operation inputs and outputs be integers only?
  - >*Yes, all operation inputs and outputs should be integers only. No fractions or decimals in the game.*
- What's a reasonable default range for outputs? [0, 100] for addition and multiplication? [-100, 100] for subtraction, i.e. allow negative results? Or perhaps even [-100, 100] for all operations?
  - >*Let's go with [-100, 100] for all operations, including addition and multiplication, to add variety and challenge for players.*
- Should trivial cases, like `10+0`, be excluded? If so, how do we determine what's trivial? (Dividends in the range [0, 100] implies trivial divisions are OK.)
  - >*Trivial cases like `10+0` should be included to ensure a wide range of questions. No need to exclude them; they can be a part of the game.*
- Should the user get to see the correct answer and "press enter to continue", or should the game immediately clear the screen and go to the next round?
  - >*Let's make it more engaging. Show the correct answer and let the user press enter to continue to the next round.*
- How many rounds in a game by default? 5?
  - >*Five rounds as the default sounds reasonable. It provides a decent challenge without being too long.*
- How should the menu work? Choose a game or history by pressing numbers/letters? Or arrow keys and enter?
  - >*Let's keep it simple. Users can choose options by pressing numbers or letters corresponding to the menu items, followed by Enter.*
- Menu items: Addition, subtraction, multiplication, division, history, quit?
  - Yes.
- How should previous games be visualized in the history?
  - >*Display each round with the question, given answer, and correct answer, along with final statistics like the number of correct answers and time taken. This will help users track their progress and performance.*
- Should levels of difficulty be implemented using discrete levels e.g. difficulty 1 to 5? Or fully by user e.g. setting allowed range of output and/or (if implemented) max time per round?
  - >*Let's offer discrete levels of difficulty from 1 to 5 based on allowed output range. This simplifies the user experience and provides clear progression.*
  - So pre-determined number ranges? What should the five ranges be?
  - >*Yes, let's use pre-determined number ranges for the five difficulty levels: -10 to 10, -25 to 25, -50 to 50, -75 to 75, -100 to 100. These ranges offer increasing challenges.*
- Does "Add a timer to track how long the user takes to finish the game" mean counting the time to play a game (consisting of a number of rounds), or counting the time the user spent in the application (and for example printing the time when quitting the application)?
  - >*Let's count the time to play a game, specifically measuring the time taken to complete each round within the game. This adds an element of challenge and motivation for the players.*

### More Questions & Decisions
- What if the user enters invalid input (such as letters)? Would it count as the wrong answer, or should the question be restated after a warning?
  - >*If the user enters invalid input, give a warning and restate the question to allow them to try again. Let's make the experience user-friendly.*
- Should the user be able to cancel a running game (mid-round)? If so, should it be shown in the history?
  - >*Yes, users can cancel a running game mid-round. It's not necessary to show canceled games in the history to keep it focused on completed games.*
  - How would a user cancel?
    - By entering `q` instead of a number.
- What if there are too many games/rounds in the history to show? Should it be capped, or should the user be expected to scroll? Or should we print a number of lines and "press enter to view more"?
  - >*Let's keep it user-friendly. Display a certain number of lines and add "press enter to view more" for easy navigation in the history.*

## MVP Functionality

### Necessary Functionality
- Menu (showing & taking input)
- Game round (showing & taking input)
- Storing history
- Showing history

### Possible Later Functionality
- Random game mode
- Settings: difficulty
- Settings: number of rounds
- Game round timer (taking time & storing & showing in history)

## User Interface
Menu like:
```text
Math Game
=========

1. Play [A]ddition
2. Play [S]ubtraction
3. Play [M]ultiplication
4. Play [D]ivision
5. Show [H]istory
6. [Q]uit

Press a number or letter key to choose.
```

Game like:
```text
Addition
========

Round 2/5: What is 15+13? 29

The correct answer was 28.
Press enter to continue
or q to quit to menu.
```

History like:
```text
History
========

[13/1 14:15] Addition (4/5 correct)
  1) 7+7? Got 14.
  2) 15+13? Got 29, expected 28.
  3) 9+7? Got 16.
  4) 13+2? Got 15.
  5) 15+10? Got 25.

Press enter to continue.
```
