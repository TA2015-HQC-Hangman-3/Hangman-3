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

5. Extraction of methods ...
6. Introducing classes ...
7. Introducing interfaces ...
8. Implemented Design Patterns ...
9. New Functionalities ...
10. Description where we use the SOLID principles ...
11. Unit Testing ...
12. Documentation ...