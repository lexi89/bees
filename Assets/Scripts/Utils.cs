namespace Bees
{
    public static class Utils
    {
        public static string CleanName(string newName)
        {
            string cloneString = "(Clone)"; // clone string is always on the end.
            if (newName.Contains(cloneString))
            {
                return newName.Substring(0, newName.IndexOf(cloneString));
            }
            return newName;
        }
    }
}