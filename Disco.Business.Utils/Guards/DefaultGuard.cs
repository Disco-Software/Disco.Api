namespace Disco.Business.Utils.Guards
{
    public static class DefaultGuard
    {
        public static void ArgumentNull<T>(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
        }

        public static void ArgumentNull(int item)
        {
            if (item == 0)
            {
                throw new ArgumentNullException();
            }
        }

        public static void ArgumentNull(string item)
        {
            if (string.IsNullOrWhiteSpace(item))
            {
                throw new ArgumentNullException();
            }
        }
    }
}
