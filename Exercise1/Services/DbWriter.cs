using System;
using System.Linq;

namespace Exercise1
{
    public abstract class DbWriter<T> : Carrier<T> where T : class
    {
        public DbWriter(IDataReader<T> dataRreader) : base(dataRreader)
        { }

        public override bool TryTransfer(object from)
        {
            if (!dataReader.TryRead(from, out T result)) return false;
            if (!TryWrite(result)) return false;
            return true;
        }

        protected abstract bool TryWrite(T result);
    }

    public class OrdersListWriter : DbWriter<OrdersList>
    {
        public OrdersListWriter(IDataReader<OrdersList> dataRreader) : base(dataRreader)
        { }
        protected override bool TryWrite(OrdersList result) => result.Orders.All(TryAddUniqueOrder);

        private bool TryAddUniqueOrder(Order order)
        {
            try
            {
                Customers customer = AddUnuqueCustomer(order.User);
                Purchases purchase = AddUnuquePurchase(order, customer);

                order.Products.ForEach(product => AddUnuqueOrderedProduct(product, purchase));

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private Customers AddUnuqueCustomer(User user)
        {
            using OrdersDbContext context = new();
            Customers customer = context.Customers.FirstOrDefault(c => user.Fio == c.Name && user.Email == c.Email)
               ?? context.Customers.Add(new Customers() { Name = user.Fio, Email = user.Email }).Entity;
            context.SaveChanges();

            return customer;

        }

        private Purchases AddUnuquePurchase(Order order, Customers customer)
        {
            using OrdersDbContext context = new();

            Purchases purchase = context.Purchses.FirstOrDefault(p =>
                p.CustomerId == customer.Id && p.OrderNumber == order.Number &&
                p.RegistrationDate == DateTime.Parse(order.RegDate) && p.Sum == order.Sum)
                ?? context.Purchses.Add(new Purchases()
                {
                    CustomerId = customer.Id,
                    OrderNumber = order.Number,
                    RegistrationDate = DateTime.Parse(order.RegDate),
                    Sum = order.Sum
                }).Entity;
            context.SaveChanges();

            return purchase;

        }
        private OrderedProducts AddUnuqueOrderedProduct(Product product, Purchases purchase)
        {
            using OrdersDbContext context = new();
            OrderedProducts orderedProduct = context.OrderedProducts.FirstOrDefault(o =>
                o.PurchaseId == purchase.Id && o.Name == product.Name &&
                o.Price == product.Price && o.Quantity == product.Quantity)
                ?? context.OrderedProducts.Add(new OrderedProducts()
                {
                    PurchaseId = purchase.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity
                }).Entity;

            context.SaveChanges();

            return orderedProduct;
        }

    }
}
