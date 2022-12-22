using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Exercise1
{
    [Serializable, XmlRoot(ElementName = "orders")]

    public class OrdersList
    {
        [XmlElement(ElementName = "order")]
        public List<Order> Orders { get; set; }
    }

    [Serializable, XmlRoot(ElementName = "order")]
    public class Order
    {
        [XmlElement(ElementName = "no")]
        public int Number { get; set; }

        [XmlElement(ElementName = "reg_date")]
        public string RegDate { get; set; }

        [XmlElement(ElementName = "sum")]
        public decimal Sum { get; set; }

        [XmlElement(ElementName = "product")]
        public List<Product> Products { get; set; }


        [XmlElement(ElementName = "user")]
        public User User { get; set; }
    }

    public class User
    {
        [XmlElement(ElementName = "fio")]
        public string Fio { get; set; }

        [XmlElement(ElementName = "email")]
        public string Email { get; set; }
    }

    public class Product
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "quantity")]
        public int Quantity { get; set; }

        [XmlElement(ElementName = "price")]
        public decimal Price { get; set; }
    }
}
