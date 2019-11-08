using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories.EntityFramework.ModelConfigurations
{
    public class OrderInfoConfiguration : EntityTypeConfiguration<OrderInfo>
    {
        public OrderInfoConfiguration()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.OrderCode)
                .IsRequired()
                .HasMaxLength(50);
            Property(c => c.CreateTime)
                .IsRequired();
            Property(c => c.UserID)
                .IsRequired();
        }
    }
}
