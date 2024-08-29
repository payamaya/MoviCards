using System.ComponentModel.DataAnnotations;

namespace MovieCardsAPI.Validations
{
    public class RatingNrMaxValue : ValidationAttribute
    {
        private int _max;

        public RatingNrMaxValue(int max)
        {
            _max = max;
        }

        public override bool IsValid(object? value)
        {
            if (value is string input)
            {
                var num=  input.Trim().Split().Last();
            return int.TryParse(num, out int result) && result <= _max;
            }
            return false;
        }
    }
}
