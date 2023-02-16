using System.Text;

namespace MasterMindConsoleApp
{
    /// <summary>
    /// </summary>
    public class PlayGame
    {
        private static Random _random = new Random();
        private GuessPlayer _guessAnalyzer;
        private List<GuessTimeModel> _timesModelList = new List<GuessTimeModel>(); // Initialiaze model list

        /// <summary>
        /// Generate random answer (code)
        /// </summary>
        public PlayGame() : this(GenerateCode()) { }

        /// <summary>
        /// </summary>
        /// <param name="code"></param>
        public PlayGame(string code)
        {
            Code = code;
            _guessAnalyzer = new GuessPlayer(Code); // Analyze the digit
        }

        /// <summary>
        /// Generate the code and append
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string GenerateCode(int length = 4)
        {
            var builder = new StringBuilder(length);
            for (var index = 0; index < length; index++)
                builder.Append(_random.Next(1, 6));
            return builder.ToString();
        }

        /// <summary>
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// </summary>
        public bool IsFinished { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="guess"></param>
        /// <returns></returns>
        public string Guess(string guess)
        {
            var noOfTime = new GuessTimeModel
            {
                Number = _timesModelList.Count + 1,
                Guess = guess,
                Response = _guessAnalyzer.Analyze(guess) // Add analyzed number
            };
            _timesModelList.Add(noOfTime);

            // Display if number is correct
            if (noOfTime.Response == "++++")
            {
                IsFinished = true;
                return $"Congratulations!, You have guessed the code!\n (within {noOfTime.Number} times)";
            }

            // Display if number is wrong and 10 tries have completed
            if (noOfTime.Number > 9)
            {
                IsFinished = true;

                return $"Sorry! :( \n You have lost! \n (the code was \"{Code}\")";
            }

            return noOfTime.Response;
        }
    }
}