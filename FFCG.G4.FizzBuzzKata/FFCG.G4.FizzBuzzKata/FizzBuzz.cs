namespace FFCG.G4.FizzBuzzKata
{
    public class FizzBuzz
    {
        public string GetResult(int number)
        {
            string result = string.Empty;

            if (number%3 == 0)
                result += "Fizz";
            if (number%5 == 0)
                result += "Buzz";

            return string.IsNullOrEmpty(result) 
                ? number.ToString() : result;
        }
    }
}