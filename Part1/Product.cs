using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Part1
{
    public class Product
    {
        public String Name { get; set; }
        public decimal? Price { get; set; }

        public Product() { }

        public Product(String name, Decimal? price)
        {
            this.Name = name;
            this.Price = price;
        }

        public static List<Product> Get()
        {
            List<Product> list = new List<Product>();
            list.Add(new Product(name: "1", price: 1));
            list.Add(new Product() { Name = "2", Price = 2 });
            list.Add(new Product() { Name = "3" });
            return list;
        }

        /// <summary>
        /// 排序查询并且输出：
        /// 1、若如此做，则返回的结果不为NULL可用于循环
        /// 2、可空值类型属性Price与任何值比较军返回False，因此此处不需要提前判断
        /// </summary>
        public static void SearchExample()
        {
            foreach (Product item in Get().Where(it => it.Price > 0).OrderBy(it=>it.Price))
            {
                Console.Write(item.Name);
            }
        }
    }
}
