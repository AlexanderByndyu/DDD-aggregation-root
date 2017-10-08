namespace Infrastructure
{
    public class UnitOfWorkFactory
    {
        public UnitOfWork Create()
        {
            return new UnitOfWork();
        }
    }
}