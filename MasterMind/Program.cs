namespace MasterMindConsoleApp
{
    /// <summary>
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            // Load instructions
            try
            {
                string instructions = File.ReadAllText(@".\Resources\Instructions.txt");
                Console.Write(instructions);
            }
            catch
            {
                throw;
            }

            // Initiate the game
            var game = new PlayGame();
            do
            {
                Console.Write("\n> ");
                var guess = Console.ReadLine(); // Guess user input
                if (guess != null)
                {
                    Console.WriteLine(game.Guess(guess));
                }
                else
                {
                    Console.WriteLine("Oops! Something went wrong!");
                }
            }
            while (!game.IsFinished); // Run until the game is finished.
        }
    }
}