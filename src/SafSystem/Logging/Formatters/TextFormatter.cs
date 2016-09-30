using System.Text;

namespace Ataoge.Logging.Formatters
{
    public class TextFormatter : LogFormatter
    {
        /// <overloads>
        /// Formats the <see cref="LogEntry"/> object by replacing tokens with values
        /// </overloads>
        /// <summary>
        /// Formats the <see cref="LogEntry"/> object by replacing tokens with values.
        /// </summary>
        /// <param name="log">Log entry to format.</param>
        /// <returns>Formatted string with tokens replaced with property values.</returns>
        public override string Format(LogEntry log)
        {
            StringBuilder output = new StringBuilder();

            //this.formatter.Format(log, output);

            return output.ToString();
        }
    }
}