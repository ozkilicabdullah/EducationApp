namespace Education.Core.Utils
{
    public static class EnumerationExtension
    {
        public static string Description(this Enum value)
        {
            // get attributes  
            var field = value.GetType().GetField(value.ToString());
            var attributes = field.GetCustomAttributes(false);

            // Description is in a hidden Attribute class called DisplayAttribute
            // Not to be confused with DisplayNameAttribute
            dynamic displayAttribute = null;

            if (attributes.Any())
            {
                displayAttribute = attributes.ElementAt(0);
            }

            // return description
            return displayAttribute?.Description ?? "Description Not Found";
        }
    }
    public static class CommonOperations
    {
        public static string ClearGSMNumber(string gsm, bool clearFirstZeros = false, bool clearPlus = true, bool clearFirstNineNumber = false)
        {
            if (!string.IsNullOrWhiteSpace(gsm))
            {
                gsm = gsm.Trim();
                gsm = gsm.Replace("-", "");
                gsm = gsm.Replace("(", "");
                gsm = gsm.Replace(")", "");
                gsm = gsm.Replace(".", "");

                if (clearPlus)
                {
                    gsm = gsm.Replace("+", "");
                }

                if (clearFirstNineNumber)
                {
                    if (gsm.StartsWith("09"))
                    {
                        gsm = gsm.TrimStart('0').TrimStart('9');
                    }

                    if (gsm.StartsWith("9"))
                    {
                        gsm = gsm.TrimStart('9');
                    }
                }

                if (clearFirstZeros)
                {
                    if (gsm.StartsWith("00"))
                    {
                        gsm = gsm.TrimStart('0').TrimStart('0');
                    }

                    if (gsm.StartsWith("0"))
                    {
                        gsm = gsm.TrimStart('0');
                    }
                }
            }

            return gsm;
        }
    }
}
