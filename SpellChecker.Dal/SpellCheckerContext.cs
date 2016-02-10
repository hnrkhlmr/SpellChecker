using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SpellChecker.Dal.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;

namespace SpellChecker.Dal
{
    public class SpellCheckerContext : IdentityDbContext<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public SpellCheckerContext()
            : base("name=SpellCheckerConnection")
        {
            //Database.SetInitializer<SpellCheckerContext>(new SpellCheckerDbInitializerDropCreateDatabaseAlways());
        }

        public static SpellCheckerContext Create()
	    {
            return new SpellCheckerContext();
	    }

        public DbSet<Word> Words { get; set; }
        public DbSet<SpellingBeeTest> SpellingBeeTests { get; set; }
        public DbSet<SearchTag> SearchTags { get; set; }
        public DbSet<UserTest> UserTests { get; set; }
        public DbSet<TestWord> TestWords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<CustomUserRole>().ToTable("MyUserRoles");
            modelBuilder.Entity<CustomUserLogin>().ToTable("MyUserLogins");
            modelBuilder.Entity<CustomUserClaim>().ToTable("MyUserClaims");
            modelBuilder.Entity<CustomRole>().ToTable("MyRoles");
        }
    }

    public class SpellCheckerDbInitializerDropCreateDatabaseAlways : DropCreateDatabaseAlways<SpellCheckerContext>
    {
        protected override void Seed(SpellCheckerContext context)
        {
            Seeder.InitializeIdentityForEF(context);
            base.Seed(context);
        }        
    }

    public class SpellCheckerDbInitializerDropCreateDatabaseIfModelChanges : DropCreateDatabaseIfModelChanges<SpellCheckerContext>
    {
        protected override void Seed(SpellCheckerContext context)
        {
            Seeder.InitializeIdentityForEF(context);
            base.Seed(context);
        }
    }

    public class SpellCheckerDbInitializerCreateDatabaseIfNotExists : CreateDatabaseIfNotExists<SpellCheckerContext>
    {
        protected override void Seed(SpellCheckerContext context)
        {
            Seeder.InitializeIdentityForEF(context);
            base.Seed(context);
        }
    }

    public class Seeder
    {
        public static void InitializeIdentityForEF(SpellCheckerContext context)
        {
            CreateUsersAndRoles(context);
            //SpellingBeeTest 1
            var spellingBeeTest = new SpellingBeeTest()
            {
                Name = "First IESH Spelling Bee 4th grade 2016",
                Tags = new List<SearchTag> { new SearchTag { Text = "weekdays" }, new SearchTag { Text = "months" } },
                Words = new List<SpellChecker.Dal.DomainObjects.Word> {
                    #region start words
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "cheese", SwedishText = "ost" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "cauliflower", SwedishText = "blomkål" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "mushrooms", SwedishText = "champinjon" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "meat", SwedishText = "kött" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "cucumber", SwedishText = "gurka" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "garlic", SwedishText = "vitlök" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "pineapple", SwedishText = "ananas" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "peas", SwedishText = "ärtor" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "cabbage", SwedishText = "kål" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "potatoes", SwedishText = "potatis" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "grapes", SwedishText = "vindruvor" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "beans", SwedishText = "bönor" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "orange", SwedishText = "apelsin" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "chicken", SwedishText = "kyckling" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "peach", SwedishText = "persika" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "bread", SwedishText = "bröd" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "fish", SwedishText = "fisk" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "eggs", SwedishText = "ägg" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "pumpkin", SwedishText = "pumpa" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "butter", SwedishText = "smör" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "fresh", SwedishText = "färsk" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "raw", SwedishText = "rå" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "ripe", SwedishText = "mogen" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "rotten", SwedishText = "rutten" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "creamy", SwedishText = "krämig" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "crunchy", SwedishText = "knaprig" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "salty", SwedishText = "salt" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "savoury", SwedishText = "välsmakande" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "sour", SwedishText = "sur" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "spicy", SwedishText = "kryddad" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "sweet", SwedishText = "söt" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "monday", SwedishText = "måndag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "tuesday", SwedishText = "tisdag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "wednesday", SwedishText = "onsdag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "thursday", SwedishText = "torsdag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "friday", SwedishText = "fredag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "saturday", SwedishText = "lördag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "sunday", SwedishText = "söndag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "be", SwedishText = "vara" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "have", SwedishText = "ha" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "do", SwedishText = "göra" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "say", SwedishText = "säga" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "go", SwedishText = "gå" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "get", SwedishText = "få" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "make", SwedishText = "gör" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "know", SwedishText = "veta" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "think", SwedishText = "tror" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "take", SwedishText = "ta" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "see", SwedishText = "se" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "come", SwedishText = "komma" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "want", SwedishText = "vill" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "use", SwedishText = "använda" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "find", SwedishText = "hitta" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "give", SwedishText = "ge" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "tell", SwedishText = "berätta" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "work", SwedishText = "arbete" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "call", SwedishText = "ringa upp" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "try", SwedishText = "försöka" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "ask", SwedishText = "fråga" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "need", SwedishText = "behöva" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "feel", SwedishText = "känna" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "become", SwedishText = "bli" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "leave", SwedishText = "lämna" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "mean", SwedishText = "betyda" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "keep", SwedishText = "behålla" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "let", SwedishText = "låta" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "begin", SwedishText = "börja" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "seem", SwedishText = "verka" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "help", SwedishText = "hjälp" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "show", SwedishText = "visa" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "hear", SwedishText = "höra" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "play", SwedishText = "spela" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "run", SwedishText = "springa" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "move", SwedishText = "flytta" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "live", SwedishText = "bo" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "believe", SwedishText = "tro" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "bring", SwedishText = "hämta" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "happen", SwedishText = "hända" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "write", SwedishText = "skriva" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "sit", SwedishText = "sitta" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "stand", SwedishText = "stå" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "lose", SwedishText = "förlora" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "pay", SwedishText = "betala" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "meet", SwedishText = "träffa" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "include", SwedishText = "innehålla" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "continue", SwedishText = "fortsätta" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "set", SwedishText = "ställa" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "learn", SwedishText = "lära" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "january", SwedishText = "januari" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "february", SwedishText = "februari" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "march", SwedishText = "mars" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "april", SwedishText = "april" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "may", SwedishText = "maj" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "june", SwedishText = "juni" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "july", SwedishText = "juli" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "august", SwedishText = "augusti" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "september", SwedishText = "september" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "october", SwedishText = "oktober" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "november", SwedishText = "november" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "december", SwedishText = "december" },
                    #endregion
                }
            };
            context.SpellingBeeTests.AddOrUpdate(s => s.Name, spellingBeeTest);
            context.SaveChanges();

            //SpellingBeeTest Weekdays
            var spellingBeeTestWeekDays = new SpellingBeeTest()
            {
                Name = "Weekdays",
                Tags = new List<SearchTag> { new SearchTag { Text = "weekdays" } },
                Words = new List<SpellChecker.Dal.DomainObjects.Word>
                {
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "monday", SwedishText = "måndag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "tuesday", SwedishText = "tisdag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "wednesday", SwedishText = "onsdag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "thursday", SwedishText = "torsdag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "friday", SwedishText = "fredag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "saturday", SwedishText = "lördag" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "sunday", SwedishText = "söndag" }
                }
            };
            context.SpellingBeeTests.AddOrUpdate(s => s.Name, spellingBeeTestWeekDays);
            context.SaveChanges();

            //SpellingBeeTest Months
            var spellingBeeTestMonths = new SpellingBeeTest()
            {
                Name = "Months",
                Tags = new List<SearchTag> { new SearchTag { Text = "months" } },
                Words = new List<SpellChecker.Dal.DomainObjects.Word>
                {
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "january", SwedishText = "januari" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "february", SwedishText = "februari" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "march", SwedishText = "mars" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "april", SwedishText = "april" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "may", SwedishText = "maj" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "june", SwedishText = "juni" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "july", SwedishText = "juli" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "august", SwedishText = "augusti" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "september", SwedishText = "september" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "october", SwedishText = "oktober" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "november", SwedishText = "november" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "december", SwedishText = "december" }                    
                }
            };

            context.SpellingBeeTests.AddOrUpdate(s => s.Name, spellingBeeTestMonths);
            context.SaveChanges();
            //SpellingBeeTest Months
            var spellingBeeTestWeeklyWordsWeek6 = new SpellingBeeTest()
            {
                Name = "Veckans ord v6 2016",
                Tags = new List<SearchTag> { new SearchTag { Text = "week6" } },
                Words = new List<SpellChecker.Dal.DomainObjects.Word>
                {
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "glömde", SwedishText = "glömde" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "rymde", SwedishText = "rymde" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "tömt", SwedishText = "tömt" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "skrämt", SwedishText = "skrämt" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "svamla", SwedishText = "svamla" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "fastklämt", SwedishText = "fastklämt" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "husnumret", SwedishText = "husnumret" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "välkomna", SwedishText = "välkomna" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "hamrar", SwedishText = "hamrar" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "slumrar", SwedishText = "slumrar" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "bestämt", SwedishText = "bestämt" },
                    new SpellChecker.Dal.DomainObjects.Word { EnglishText = "berömd", SwedishText = "berömd" },
                    
                }
            };
            context.SpellingBeeTests.AddOrUpdate(s => s.Name, spellingBeeTestWeeklyWordsWeek6);
            context.SaveChanges();
        }

        private static void CreateUsersAndRoles(SpellChecker.Dal.SpellCheckerContext context)
        {
            var roleAdmin = new CustomRole("Admin");
            context.Roles.AddOrUpdate(r => r.Name, roleAdmin);

            // vanlig användare roll
            var roleBee = new CustomRole("Bee");
            context.Roles.AddOrUpdate(r => r.Name, roleBee);
            context.SaveChanges();

            var hasher = new PasswordHasher();

            //Admin user
            var userAdmin = new ApplicationUser();
            userAdmin.UserName = "admin@admin.com";
            userAdmin.Email = "admin@admin.com";
            userAdmin.SecurityStamp = Guid.NewGuid().ToString();
            userAdmin.PasswordHash = hasher.HashPassword("P@ssw0rd");
            context.Users.AddOrUpdate(u => u.UserName, userAdmin);
            context.SaveChanges();

            //mig själv som vanlig användare
            var userBee = new ApplicationUser();
            userBee.UserName = "bee@bee.com";
            userBee.Email = "bee@bee.com";
            userBee.SecurityStamp = Guid.NewGuid().ToString();
            userBee.PasswordHash = hasher.HashPassword("P@ssw0rd");
            context.Users.AddOrUpdate(u => u.UserName, userBee);
            context.SaveChanges();

            //roller
            if (!context.Set<CustomUserRole>().Any(c => c.RoleId.Equals(roleAdmin.Id) && c.UserId.Equals(userAdmin.Id)))
            {
                var userRoleAdmin = new CustomUserRole();
                userRoleAdmin.RoleId = roleAdmin.Id;
                userRoleAdmin.UserId = userAdmin.Id;
                context.Set<CustomUserRole>().Add(userRoleAdmin);
                userAdmin.Roles.Add(userRoleAdmin);
                context.Users.AddOrUpdate(u => u.UserName, userAdmin);
                context.SaveChanges();
            }

            if (!context.Set<CustomUserRole>().Any(c => c.RoleId.Equals(roleBee.Id) && c.UserId.Equals(userAdmin.Id)))
            {
                var userRoleBeeForAdmin = new CustomUserRole();
                userRoleBeeForAdmin.RoleId = roleBee.Id;
                userRoleBeeForAdmin.UserId = userAdmin.Id;
                userAdmin.Roles.Add(userRoleBeeForAdmin);
                context.Set<CustomUserRole>().Add(userRoleBeeForAdmin);
                context.Users.AddOrUpdate(u => u.UserName, userAdmin);
                context.SaveChanges();
            }

            if (!context.Set<CustomUserRole>().Any(c => c.RoleId.Equals(roleBee.Id) && c.UserId.Equals(userBee.Id)))
            {
                var userRoleBee = new CustomUserRole();
                userRoleBee.RoleId = roleBee.Id;
                userRoleBee.UserId = userBee.Id;
                userBee.Roles.Add(userRoleBee);
                context.Set<CustomUserRole>().Add(userRoleBee);
                context.Users.AddOrUpdate(u => u.UserName, userBee);
                context.SaveChanges();
            }
        }
    }
}
