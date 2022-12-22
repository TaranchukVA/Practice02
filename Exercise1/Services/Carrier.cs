namespace Exercise1
{
    public abstract class Carrier<T> where T : class
    {
        protected IDataReader<T> dataReader;

        public Carrier(IDataReader<T> dataReader)
        {
            this.dataReader = dataReader;
        }

        public abstract bool TryTransfer(object from);
    }
}
