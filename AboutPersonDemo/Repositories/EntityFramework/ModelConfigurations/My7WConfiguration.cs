﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories.EntityFramework.ModelConfigurations
{
    public class UserInfoConfiguration: EntityTypeConfiguration<UserInfo>
    {
        public UserInfoConfiguration()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(2000);
        }
    }
}
