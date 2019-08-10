using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkingWithEFCore
{
    public class Category
    {
        // Эти свойства соотносятся со столбцами в БД
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        
        // Определяет свойство navigation для связанных строк
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            // Чтобы позволить разработчикам добавлять товары в Category,
            // мы должны инициализировать свойства navigation пустым списком
            this.Products = new List<Product>();
        }
    }
}
