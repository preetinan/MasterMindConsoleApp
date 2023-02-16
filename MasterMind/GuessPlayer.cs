using System.Text;

namespace MasterMindConsoleApp
{
    /// <summary>
    /// </summary>
    public class GuessPlayer
    {
        /// <summary>
        /// </summary>
        private readonly string _code;

        public GuessPlayer(string code)
        {
            _code = code;
        }

        /// <summary>
        /// Analyze the given number and append it
        /// </summary>
        /// <param name="guess"></param>
        /// <returns></returns>
        public string Analyze(string guess)
        {
            var builder = new StringBuilder(guess.Length);
            for (var index = 0; index < guess.Length; index++)
            {
                var digit = guess[index];
                var response = ' ';

                if (_code.Contains(digit))
                    response = _code[index] == digit ? '+' : '-';

                builder.Append(response);
            }
            return builder.ToString();
        }
    }
}