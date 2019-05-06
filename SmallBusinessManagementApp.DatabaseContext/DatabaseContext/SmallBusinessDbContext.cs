using System.Data.Entity;
using SmallBusinessManagementApp.Models;
using SmallBusinessManagementApp.Models.Models;
using SmallBusinessManagementApp.Models.Models.Purchase;
using SmallBusinessManagementApp.Models.Models.Sales;


namespace SmallBusinessManagementApp.DatabaseContext.DatabaseContext
{
    public class SmallBusinessDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerFiles> CustomerFiles { get; set; }
        public DbSet<ProductFiles> ProductFiles { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetails> PurchasesDetailses { get; set; }
        public DbSet<Sales> Saleses { get; set; }
        public DbSet<SalesDetails> SalesDetailses { get; set; } 

        //public DbSet<ProductVM> ProdectVms { get; set; }
    }
}