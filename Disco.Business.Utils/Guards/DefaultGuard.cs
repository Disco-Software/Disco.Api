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
    }
}
