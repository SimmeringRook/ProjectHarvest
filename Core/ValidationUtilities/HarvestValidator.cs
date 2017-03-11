using System.Windows.Forms;

namespace Core.ValidationUtilities
{
    public static class HarvestValidator
    {
        private static readonly string _nameErrorMessage = "Only A-Z and 0-9 are permitted values.";
        private static readonly string _amountErrorMessage = "Only 0-9 and and one '.' are permitted. (123.45)";
        public static bool Validate(TextBox inputTextbox, string regexPattern, ErrorProvider formErrorProvider)
        {
            if (string.IsNullOrWhiteSpace(inputTextbox.Text))
            {
                formErrorProvider.SetError(inputTextbox, "This field can not be empty.");
                return false;
            }
                
            if (System.Text.RegularExpressions.Regex.IsMatch(inputTextbox.Text, regexPattern) == false)
            {
                string errorMessage = (regexPattern.Equals(HarvestRegex.Amount))
                    ? _amountErrorMessage
                    : _nameErrorMessage;
                formErrorProvider.SetError(inputTextbox, errorMessage);
                return false;
            }

            formErrorProvider.SetError(inputTextbox, string.Empty);
            return true;
        }
    }

    public static class HarvestRegex
    {
        public static readonly string Amount = @"^\d*\.?\d{0,2}$";
        public static readonly string Name = @"^[\w ]*$";
    }
}
