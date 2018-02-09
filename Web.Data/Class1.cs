using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Data
{
    [Table("Uf")]
    public class Uf
    {
        public Uf()
        {
            Cities = new HashSet<City>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Initials { get; set; }

        public ICollection<City> Cities {get;set;}
    }

    [Table("City")]
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int UfId { get; set; }

        [ForeignKey("UfId")]
        public Uf Uf { get; set; }
    }

    public class DatabaseContext: DbContext
    {
        
        public DbSet<Uf> Uf { get; set; }
        public DbSet<City> City { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connStr = "Server=.\\SqlExpress;Database=Live;User Id=sa;Password=senha;MultipleActiveResultSets=true;";
            optionsBuilder.UseSqlServer(connStr);
        }
    }
}
