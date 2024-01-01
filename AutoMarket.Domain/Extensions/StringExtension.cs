using System.Text;

namespace AutoMarket.Domain.Extensions
{
    public static class StringExtension
    {
        public static string Join(this List<string> words)
        {
            var strB = new StringBuilder();

            for (int i = 0; i < words.Count; i++)
            {
                strB.Append($"{i + 1}: {words[i]} ");
            }

            return strB.ToString();
        }
    }
}
