using System.Collections.Generic;
using System.Linq;


namespace Ice_Cream.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public void AddItem(Product product, int id)
        {

            CartLine line = Lines.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Product = product,
                    ID = product.ProductID,
                });
            }
        }
        public void RemoveById(long productid)
        {
            Lines.RemoveAll(p => p.Product.ProductID == productid);
        }

        public decimal ComputeTotalValue()
            => Lines.Sum(e => e.Product.Price * 1);
        public void Clear() => Lines.Clear();

    }
    public class CartLine
    {
        public long ID { get; set; }
        public Product Product { get; set; }
    }
}
