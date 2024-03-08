namespace Chronical.App.Services.Implementations
{
    public static class ArrayExtensions
    {
        public static bool IsNullOrEmpty<T>(this T[]? array)
        {
            return (array is null || array.Count() == 0);
        }
    }
}
