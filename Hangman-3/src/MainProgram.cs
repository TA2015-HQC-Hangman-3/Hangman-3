namespace Hangman
{
    using System;
    using System.Collections.Generic;

    using Commands;

    public class MainProgram
    {
        static void Main()
        {
            var context = new GameContext(new SimpleRandomWordProvider(), new Scoreboard());
            var engine = new Engine(context, new CommandFactory());
            engine.Run();
        }
    }
}
