# Team Hangman-3 Refactoring Documentation

1. Redesigned the project structure: 
- Renamed the project name from "kpkproekt" to "Hangman-3";
- Extracted 3 different projects form the main class "Hangman.cs" - "Hangman.UI", "Hangman.Logic" and "Hangman.Tests";
- Extracted each class in a separate class with a good name: "HangmanGame", "HangmanWord", "Scoreboard", "GameContext", "ConsolePrinter" and many others;
- Introduced interfaces for the classes that share the same logic: "IDataManager", "ISorter", "IWord", "IWordProvider" and others;
- Implemented different design patterns to improve the quality of the code: Bridge, Proxy, Command, Strategy and others.

2. Reformatted the source code: 
- Removed all unneeded empty lines in the entire code, e.g. :

Before:
```c#
if (isRestartRequested)
    {
    
    
    
        break;
    }
```

After:
```c#
if (isRestartRequested)
    {
        break;
    }
```

- Inserted empty lines where needed in the entire code, e.g. :

Before:
```c#
static bool IsWordKnown()
    {
        for (int i = 0; i < unknownWord.Length; i++)
        {
            if (unknownWord[i] == '_')
            {
                return false;
            }
        }
        return true;
    }
```

After:
```c#
static bool IsWordKnown()
    {
        for (int i = 0; i < unknownWord.Length; i++)
        {
            if (unknownWord[i] == '_')
            {
                return false;
            }
        }
        
        return true;
    }
```
- Removed all static constants and methods from Hangman.cs and extracted them in their corresponding classes;
- Put { and } after all conditionals and loops (when missing);
- Character casing: variables and fields made camelCase; 
- Types, methods and constants made PascalCase;
- Formatted all access modifiers, using the HQC best practises;
- Replaced unnecessary static fields with properties. e.g. :

Before:
```c#
public static bool isCheated = false;
```
After:
```c#
bool HasCheated { get; set; }
```

3. Renamed variables, methods and constants, e.g. :
- In class HangmanWord: private static void gen() to public char[] GenerateHiddenWord();
- In class HangmanWord: static bool IsWordKnown() to public bool IsWordGuessed();
- In class Scoreboard: static void AddInScoreboard(Dictionary<string, int> score) to public void AddScore(int mistakes);
- In class Scoreboard: static void printboard(Dictionary<string, int> score) to public void PrintScore();
- and many others.

4. Introduced constants:
- public const string PropmtForUserGuess = "Enter a letter/command: ";
- public const string PromptForCommand = "Enter command - restart, top, exit: ";
- public const string WinMessage = "You won with {0} mistakes.";
- public const string WinByCheatingMessage = "You won with {0} mistakes but you have cheated. You are not allowed to enter into the scoreboard.";
- public const string PromptForUserName = "Please enter your name for the top scoreboard: ";
- public const string GoodbyeMessage = "Good bye!";
- public const string RevealedLetterMessage = "Good job! You revealed {0} letters.";
- public const string NotRevealedLetterMessage = "Sorry! There are no unrevealed letters \"{0}\".";
- public const string LetterHasBeenTriedMessage = "Sorry! You have tried entering \"{0}\" before!";
- public const string IncorrectGuessOrCommandMessage = "Incorrect guess or command!";
- public const string CurrentlyUsedLettersMessage = "Currently used letters: {0}";
- and many others;

5. Extracted different methods from "Hangman.cs", e.g. :
Before:
```c#
if (check(command))
    {
        bool isLetterInTheWord = false;
        int letterKnown = 0;
        char enteredSymbol = char.Parse(command);
        for (int i = 0; i < unknownWord.Length; i++)
        {
            if (theChosenWord[i] == enteredSymbol)
            {
                unknownWord[i] = enteredSymbol;
                letterKnown++;
                isLetterInTheWord = true;
            }
        }
        if (isLetterInTheWord)
        {
            Console.WriteLine("Good job! You revealed {0} letters.", letterKnown);
        }
        else
        {
            Console.WriteLine("Sorry! There are no unrevealed letters \"{0}\".", command);
            mistakeCounter++;
        }
    }
    else
    {
        Console.WriteLine("Incorrect guess or command!");
    }
```
After:
```c#
private int GetNumberOfLettersThatAreGuessed(string letter)
    {
        var lettersGuessed = 0;
        char enteredSymbol = char.Parse(letter);
        for (int i = 0; i < unknownWord.Length; i++)
        {
            if (theChosenWord[i] == enteredSymbol)
            {
                lettersGuessed++;
            }
        }
    
        return lettersGuessed;
    }

private bool IsLetterInTheWord(string letter)
    {
        bool isLetterInTheWord = false;
        char enteredSymbol = char.Parse(letter);
        for (int i = 0; i < unknownWord.Length; i++)
        {
            if (theChosenWord[i] == enteredSymbol)
            {
                unknownWord[i] = enteredSymbol;
                isLetterInTheWord = true;
            }
        }
    
        return isLetterInTheWord;
    }
    
private bool IsValidLetter(string input)
    {
        char enteredSymbol;
        if (char.TryParse(input, out enteredSymbol) &&
            ((int)enteredSymbol >= LowerBoundaryFromTheAsciiTable &&
             (int)enteredSymbol <= UpperBoundaryFromTheAsciiTable))
        {
            return true;
        }

        return false;
    }
```

6. Introduced new methods for improving the program, e.g. :
- In class "HangmanWord": public bool IsLetterGuessedForFirstTime(string letter), public int GetNumberOfLettersThatAreGuessed(string letter), public List<char> GetAllTriedLetters();
- In class "ConsolePrinter": public void Print(string currentText),  public void PrintLine(string currentText), public void ClearScreen();
- In class "HangmanGame": public void Run(),  private void EndCurrentGame(), private void ExecuteCommand(string commandName);
- and many others;

7. Extracted classes from the given code, e.g. :
- "Scoreboard.cs";
- "HangmanGame.cs";
- "HangmanWord.cs";
- "GameContext.cs";
- a lot of different commands;
- and others.

8. Introduced new classes for improving the program, e.g. :
- "HangmanWordProxy.cs";
- "ConsolePrinter.cs";
- "BaseWordProvider.cs";
- "SampleWordProvider.cs";
- "XmlWordProvider.cs";
- "JsonGameStateManager.cs";
- "XmlGameStateManager.cs";
- and others.

9. Introduced interfaces for the classes that share the same logic, e.g. :
- "IHangmanCommand.cs";
- "IDateManager.cs";
- "ISorter.cs";
- "IWord.cs";
- "IWordProvider.cs";
- and others;

10. Implemented the following Design Patterns for improving the program:
- Creational:
    - Double Locking Thread Safe Singleton - in class "SimpleRandomWordProvider.cs";
    - Lazy Initialization - in class "SimpleRandomWordProvider.cs";
    - Simple Factory - in class "CommandFactory.cs" for executing the concrete given command;
- Structural:
    - Facade - class "HangmanGame.cs" - method Run(), 
    - Bridge - the abstraction ISaveLoadManager uses the abstraction IDataManager to save and load information from files using XML (or JSON if you want) formats.
    - Proxy - client uses interface IWord, and its descendant HangmanWordProxy is validating input for the methods of HangmanWord and acting as a sort of a "protection proxy" for it.
- Behavioral:
    - Strategy: 
        - "IDateManager.cs" interface and classes "TextFileScoreboardDataManager.cs", "XmlGameStateManager.cs", "JsonGameStateManager.cs";
        - "IWordProvider.cs" interface and classes "BaseWordProvider.cs", "SimpleRandomWordProvider.cs" and "XmlWordProvider.cs";
        - "ISorter.cs" interface and classes "SelectionSorter.cs" and "ComparerSorter.cs".
    - Command - "ICommand.cs" and classes "RestartCommand.cs", "LoadCommand.cs", "SaveCommand", "HandleLetterCommand.cs" and all other commands;
    - Memento - class "Memento.cs" in combination with class "SaveLoadManager.cs" and methods public Memento Save() and public void Load(Memento gameState) in class "GameContext.cs" ;
 
11. Added the following new functionalities:
- saving and loading the current state of the game - using the Memento Design Pattern;
- saving the name of the players and their scores in an outer txt file and loading the scoreboard from the file;
- notifying the player if he already used the letter that he have entered;
- showing all currently used letters;

12. Description where we implemented the SOLID principles:
- Single Responsibility Principle:
    - class "ConsolePrinter.cs" prints only given messages;
    - Data manager classes only write and read information to/from files;
    - class "Scoreboard.cs" only deals with scores;

- Open/Closed Principle:
    - We can easily introduce new ways of providing a word, through the IWordProvider interface;
	- Same for sorting through the ISorter interface;
	- We can introduce new engine for diferent type of UI through the IEngine interface;

- Liskov Substitution Principle:
    - the base class "BaseWordProvider.cs" and it's inheritants "SimpleRandomWordProvider.cs" and "XmlWordProvider.cs";

- Interface Segregation Principle:
    - "IHangmanCommand.cs";
    - "IDateManager.cs";
    - "ISorter.cs";
    - "IWordProvider.cs";
    - and others;

- Dependency Inversion Principle:
    - All dependencies are resolved through constructor injection and method injections(e.g. all the Commands classes). Where possible empty constructors with "poor man's IoC" are used.

13. Unit Testing - Made Unit tests in all classes for all the methods.

14. Code coverage - NOT DONE YET!!!!!

15. Xml Documentation - Made xml documentation in all classes.

16. StyleCop - 0 Warnings and Errors.

The last four points must be further altered!!!!!