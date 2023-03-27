using E_commerce.Models;
using Microsoft.EntityFrameworkCore;
namespace E_commerce.Data
{
    //le class AppDbContext herite class DbContext
    public class AppDbContext : DbContext
    {
        //bech nasna3 constractor  nekteb ctor 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //identifie the entity 
            //am : for actors movie id
            //definde a mobination for primary key actorid+movieId
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });
            //definde tha Actor_Movie to be the join table
            //definde the One To Many movie side with the forigenKey MovieId 
            modelBuilder.Entity<Actor_Movie>()
                .HasOne(m => m.Movie)
                .WithMany(am => am.Actors_Movies)
                .HasForeignKey(m => m.MovieId);
            //definde one TO many Actor side
            modelBuilder.Entity<Actor_Movie>()
                .HasOne(a => a.Actor)
                .WithMany(am => am.Actors_Movies)
                .HasForeignKey(a => a.ActorId);
            base.OnModelCreating(modelBuilder);

/*            modelBuilder.Entity<Movie>()
                .HasOne(c => c.Cinema)
                .WithMany(m => m.Movies)
                .HasForeignKey(c => c.CinemaId);
            modelBuilder.Entity<Movie>()
                .HasOne(p=>p.Producer)
                .WithMany(m=>m.Movies)
                .HasForeignKey(p=> p.ProducerId);*/
        }

        //define the tabels name in db to all the modules 
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
    }
}
