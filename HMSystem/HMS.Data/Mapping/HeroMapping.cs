using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMS.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMS.Data.Mapping
{
    public class HeroMapping 
    {
        public HeroMapping(EntityTypeBuilder<Hero> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Name).HasMaxLength(50).IsRequired();
        }
    }
}
