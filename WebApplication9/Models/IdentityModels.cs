using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication9.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<ClosedQuestion> ClosedQuestions { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Course> Courses { get; set; }
        //public DbSet<CourseDescription> CourseDescriptions{ get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<OpenQuestion> OpenQuestions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestResult> TestResults { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>().HasKey(x => x.AdministratorID);
            base.OnModelCreating(modelBuilder);
        }
    }
    
    
}