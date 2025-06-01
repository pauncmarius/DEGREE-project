//FCUnireaDbContext
using FCUnirea.Domain.Entities;
using FCUnirea.Persistance.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//add-migration CreateDatabase -o Data/Migrations

namespace FCUnirea.Persistance.Data
{
    public class FCUnireaDbContext : DbContext
    {
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Competitions> Competitions { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<PlayerStatisticsPerGame> PlayerStatisticsPerGame { get; set; }
        public DbSet<PlayerStatisticsPerCompetition> PlayerStatisticsPerCompetition { get; set; }
        public DbSet<Seats> Seats { get; set; }
        public DbSet<Stadiums> Stadiums { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<TeamStatistics> TeamStatistics { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Users> Users { get; set; }

        public FCUnireaDbContext(DbContextOptions<FCUnireaDbContext> options) : base(options) { }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=FCUnirea;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CommentsMapping.Map(modelBuilder);
            CompetitionsMapping.Map(modelBuilder);
            GamesMapping.Map(modelBuilder);
            NewsMapping.Map(modelBuilder);
            PlayersMapping.Map(modelBuilder);
            PlayerStatisticsPerCompetitionMapping.Map(modelBuilder);
            PlayerStatisticsPerGameMapping.Map(modelBuilder);
            SeatsMapping.Map(modelBuilder);
            StadiumsMapping.Map(modelBuilder);
            TeamsMapping.Map(modelBuilder);
            TeamStatisticsMapping.Map(modelBuilder);
            TicketsMapping.Map(modelBuilder);
            UsersMapping.Map(modelBuilder);
            SeedDatabase(modelBuilder);
        }

        private static void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(new List<Users>{
                new Users
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@fcunirea.ro",
                    FirstName = "Admin",
                    LastName = "Unirea",
                    PhoneNumber = "0712345678",
                    Password = "aJJ6n23eBDAvvkgbNkbqVw==:Rkl+y/HGK2F3orm8uko70zncakYXDXmWAcTEheRZJCg=",
                    Role = UserRole.Admin
                },
                new Users { Id = 2, Username = "ion.popescu", Email = "ion.popescu@fcunirea.ro", FirstName = "Ion", LastName = "Popescu", PhoneNumber = "0700000001", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 3, Username = "ana.ionescu", Email = "ana.ionescu@fcunirea.ro", FirstName = "Ana", LastName = "Ionescu", PhoneNumber = "0700000002", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 4, Username = "george.marin", Email = "george.marin@fcunirea.ro", FirstName = "George", LastName = "Marin", PhoneNumber = "0700000003", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 5, Username = "elena.dumitru", Email = "elena.dumitru@fcunirea.ro", FirstName = "Elena", LastName = "Dumitru", PhoneNumber = "0700000004", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 6, Username = "mihai.stan", Email = "mihai.stan@fcunirea.ro", FirstName = "Mihai", LastName = "Stan", PhoneNumber = "0700000005", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 7, Username = "bianca.toma", Email = "bianca.toma@fcunirea.ro", FirstName = "Bianca", LastName = "Toma", PhoneNumber = "0700000006", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 8, Username = "alex.vasilescu", Email = "alex.vasilescu@fcunirea.ro", FirstName = "Alex", LastName = "Vasilescu", PhoneNumber = "0700000007", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 9, Username = "diana.radu", Email = "diana.radu@fcunirea.ro", FirstName = "Diana", LastName = "Radu", PhoneNumber = "0700000008", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 10, Username = "tudor.matei", Email = "tudor.matei@fcunirea.ro", FirstName = "Tudor", LastName = "Matei", PhoneNumber = "0700000009", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 11, Username = "andreea.ilie", Email = "andreea.ilie@fcunirea.ro", FirstName = "Andreea", LastName = "Ilie", PhoneNumber = "0700000010", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 12, Username = "claudiu.dobre", Email = "claudiu.dobre@fcunirea.ro", FirstName = "Claudiu", LastName = "Dobre", PhoneNumber = "0700000011", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 13, Username = "raluca.georgescu", Email = "raluca.georgescu@fcunirea.ro", FirstName = "Raluca", LastName = "Georgescu", PhoneNumber = "0700000012", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 14, Username = "ionut.moldovan", Email = "ionut.moldovan@fcunirea.ro", FirstName = "Ionut", LastName = "Moldovan", PhoneNumber = "0700000013", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 15, Username = "carmen.pop", Email = "carmen.pop@fcunirea.ro", FirstName = "Carmen", LastName = "Pop", PhoneNumber = "0700000014", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 16, Username = "vlad.enache", Email = "vlad.enache@fcunirea.ro", FirstName = "Vlad", LastName = "Enache", PhoneNumber = "0700000015", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 17, Username = "irina.voicu", Email = "irina.voicu@fcunirea.ro", FirstName = "Irina", LastName = "Voicu", PhoneNumber = "0700000016", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 18, Username = "sebastian.cristea", Email = "sebastian.cristea@fcunirea.ro", FirstName = "Sebastian", LastName = "Cristea", PhoneNumber = "0700000017", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 19, Username = "simona.marinescu", Email = "simona.marinescu@fcunirea.ro", FirstName = "Simona", LastName = "Marinescu", PhoneNumber = "0700000018", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 20, Username = "rares.sava", Email = "rares.sava@fcunirea.ro", FirstName = "Rares", LastName = "Sava", PhoneNumber = "0700000019", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 21, Username = "paula.mateescu", Email = "paula.mateescu@fcunirea.ro", FirstName = "Paula", LastName = "Mateescu", PhoneNumber = "0700000020", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 22, Username = "alin.badea", Email = "alin.badea@fcunirea.ro", FirstName = "Alin", LastName = "Badea", PhoneNumber = "0700000021", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 23, Username = "adelina.dragan", Email = "adelina.dragan@fcunirea.ro", FirstName = "Adelina", LastName = "Dragan", PhoneNumber = "0700000022", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 24, Username = "lucian.simeon", Email = "lucian.simeon@fcunirea.ro", FirstName = "Lucian", LastName = "Simeon", PhoneNumber = "0700000023", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 25, Username = "gabriela.radulescu", Email = "gabriela.radulescu@fcunirea.ro", FirstName = "Gabriela", LastName = "Radulescu", PhoneNumber = "0700000024", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 26, Username = "vasile.ciobanu", Email = "vasile.ciobanu@fcunirea.ro", FirstName = "Vasile", LastName = "Ciobanu", PhoneNumber = "0700000025", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 27, Username = "oana.manole", Email = "oana.manole@fcunirea.ro", FirstName = "Oana", LastName = "Manole", PhoneNumber = "0700000026", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 28, Username = "cornel.ardelean", Email = "cornel.ardelean@fcunirea.ro", FirstName = "Cornel", LastName = "Ardelean", PhoneNumber = "0700000027", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 29, Username = "camelia.pavel", Email = "camelia.pavel@fcunirea.ro", FirstName = "Camelia", LastName = "Pavel", PhoneNumber = "0700000028", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 30, Username = "grigore.nastase", Email = "grigore.nastase@fcunirea.ro", FirstName = "Grigore", LastName = "Nastase", PhoneNumber = "0700000029", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer },
                new Users { Id = 31, Username = "veronica.filip", Email = "veronica.filip@fcunirea.ro", FirstName = "Veronica", LastName = "Filip", PhoneNumber = "0700000030", Password = "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", Role = UserRole.Customer }
            });

            modelBuilder.Entity<Competitions>().HasData(new List<Competitions>()
            {
                new Competitions() { Id = 1, CompetitionName = "Liga 1", CompetitionType = CompetitionType.NationalLeague },
                new Competitions() { Id = 2, CompetitionName = "Cupa Romaniei", CompetitionType = CompetitionType.NationalCup },
                new Competitions() { Id = 3, CompetitionName = "Champions League", CompetitionType = CompetitionType.ChampionsLeague },
                new Competitions() { Id = 4, CompetitionName = "Liga 1 U21", CompetitionType = CompetitionType.NationalLeague },
                new Competitions() { Id = 5, CompetitionName = "Liga 1 Tineret", CompetitionType = CompetitionType.NationalLeague },
                new Competitions() { Id = 6, CompetitionName = "Champions League Knockout stage", CompetitionType = CompetitionType.ChampionsLeague }
            });

            modelBuilder.Entity<Teams>().HasData(new List<Teams>
            {
                new Teams { Id = 1, TeamName = "FC Unirea", TeamType = TeamType.Adult, IsInternal = true, Description = "FC Unirea a fost fondată în anul 1923, având ca scop promovarea " +
                "valorilor sportive și dezvoltarea fotbalului la nivel local. De-a lungul anilor, clubul a reușit să atragă numeroși tineri talentați din regiune, devenind rapid un punct " +
                "de referință pentru fotbalul comunitar.\n\nEchipa a debutat în ligile inferioare, dar datorită muncii susținute și implicării staff-ului, FC Unirea a obținut promovări " +
                "succesive, ajungând să participe în competiții naționale și ulterior europene. Performanțele notabile includ câștigarea campionatului regional în 2012 și participarea constantă " +
                "în primele eșaloane ale fotbalului românesc începând cu sezonul 2015-2016. ", CoachName = "Petrica Florea" },
                new Teams { Id = 11, TeamName = "FC Unirea U21", TeamType = TeamType.U21, IsInternal = true, Description = "FC Unirea U21 a fost înființată ca parte a strategiei de dezvoltare a " +
                "clubului FC Unirea, având ca principal obiectiv creșterea și promovarea tinerilor jucători către echipa de seniori. Echipa a luat naștere în anul 1993, din dorința de a oferi o " +
                "rampă de lansare pentru fotbaliștii talentați cu vârste sub 21 de ani.\n\nÎncă de la început, FC Unirea U21 a participat în competițiile naționale de juniori și tineret, " +
                "obținând rezultate remarcabile și construind o reputație solidă pentru profesionalism și implicare. Mulți dintre jucătorii promovați din cadrul acestei echipe au ajuns ulterior " +
                "să evolueze cu succes la nivel de seniori, contribuind la performanțele clubului-mamă.\n\nPrin accentul pus pe formare, disciplină și joc de echipă, FC Unirea U21 a devenit " +
                "un pilon esențial în structura clubului, reprezentând legătura directă dintre academia de juniori și prima echipă. Clubul investește constant în infrastructură, staff și programe " +
                "de pregătire pentru a asigura continuitatea valorilor și performanțelor fotbalistice. ", CoachName = "Mihai Olaru" },
                new Teams { Id = 21, TeamName = "FC Unirea Youth", TeamType = TeamType.Kids, IsInternal = true, Description = "FC Unirea Youth reprezintă segmentul de juniori al clubului FC Unirea," +
                " fiind dedicat dezvoltării copiilor și adolescenților pasionați de fotbal. Echipa a fost creată în anul 1990 ca răspuns la dorința clubului de a construi o academie puternică și de " +
                "a forma jucători încă de la cele mai fragede vârste.\n\nScopul principal al FC Unirea Youth este identificarea și formarea tinerelor talente, oferindu-le acestora condiții " +
                "moderne de pregătire, antrenori calificați și participarea la competiții locale și regionale. De-a lungul anilor, această structură a devenit un adevărat incubator de jucători pentru " +
                "club, numeroși fotbaliști ajungând ulterior să evolueze pentru FC Unirea U21 sau chiar la nivel de seniori.\n\nPrin activitatea sa, FC Unirea Youth promovează nu doar performanța " +
                "sportivă, ci și valorile educației, fair-play-ului și respectului față de adversar. Clubul continuă să investească în infrastructură și în programe de formare, consolidându-și statutul " +
                "de centru de excelență pentru tinerii fotbaliști din regiune. ", CoachName = "Nica Cercel" },

                // Id: 2–10 (echipe externe simulate)
                new Teams { Id = 2, TeamName = "Steaua Sud", TeamType = TeamType.Adult, IsInternal = false, Description = "Echipă externă din București", CoachName = "Radu Voicu" },
                new Teams { Id = 3, TeamName = "Dinamo Est", TeamType = TeamType.Adult, IsInternal = false, Description = "Club extern din Est", CoachName = "Adrian Luca" },
                new Teams { Id = 4, TeamName = "Rapid Nord", TeamType = TeamType.Adult, IsInternal = false, Description = "Echipă tradițională externă", CoachName = "Cezar Năstase" },
                new Teams { Id = 5, TeamName = "Petrolul Vest", TeamType = TeamType.Adult, IsInternal = false, Description = "Echipă externă din Ploiești", CoachName = "Marius Costache" },
                new Teams { Id = 6, TeamName = "Universitatea Brașov", TeamType = TeamType.Adult, IsInternal = false, Description = "Echipă din centru", CoachName = "Paul Dobre" },
                new Teams { Id = 7, TeamName = "CSM Cluj", TeamType = TeamType.Adult, IsInternal = false, Description = "Echipă externă din Cluj", CoachName = "Ovidiu Stan" },
                new Teams { Id = 8, TeamName = "Gloria Buzău", TeamType = TeamType.Adult, IsInternal = false, Description = "Echipă din Buzău", CoachName = "Toma Marinescu" },
                new Teams { Id = 9, TeamName = "Viitorul Constanța", TeamType = TeamType.Adult, IsInternal = false, Description = "Club tânăr și ambițios", CoachName = "Cristian Filip" },
                new Teams { Id = 10, TeamName = "CS Mioveni", TeamType = TeamType.Adult, IsInternal = false, Description = "Echipă argeșeană", CoachName = "Ilie Andrei" },

                // Id: 12–20
                new Teams { Id = 12, TeamName = "U21 Voluntari", TeamType = TeamType.U21, IsInternal = false, Description = "Echipă externă U21", CoachName = "Eugen Varga" },
                new Teams { Id = 13, TeamName = "U21 Farul", TeamType = TeamType.U21, IsInternal = false, Description = "Farul Constanța U21", CoachName = "Victor Drăghici" },
                new Teams { Id = 14, TeamName = "U21 Sepsi", TeamType = TeamType.U21, IsInternal = false, Description = "Sepsi OSK U21", CoachName = "Ervin Balogh" },
                new Teams { Id = 15, TeamName = "U21 Poli Iași", TeamType = TeamType.U21, IsInternal = false, Description = "Tineret Poli", CoachName = "George Călinescu" },
                new Teams { Id = 16, TeamName = "U21 UTA", TeamType = TeamType.U21, IsInternal = false, Description = "Arad U21", CoachName = "Remus Cernat" },
                new Teams { Id = 17, TeamName = "U21 Argeș", TeamType = TeamType.U21, IsInternal = false, Description = "Pitești U21", CoachName = "Mihai Răducan" },
                new Teams { Id = 18, TeamName = "U21 Hermannstadt", TeamType = TeamType.U21, IsInternal = false, Description = "Sibiu U21", CoachName = "Dan Tănase" },
                new Teams { Id = 19, TeamName = "U21 Botoșani", TeamType = TeamType.U21, IsInternal = false, Description = "Nord U21", CoachName = "Florin Istrate" },
                new Teams { Id = 20, TeamName = "U21 Slatina", TeamType = TeamType.U21, IsInternal = false, Description = "Oltenia U21", CoachName = "Marius Ilie" },

                // Id: 22–30
                new Teams { Id = 22, TeamName = "Youth Galați", TeamType = TeamType.Kids, IsInternal = false, Description = "Grupa mică externă", CoachName = "Lavinia Andrei" },
                new Teams { Id = 23, TeamName = "Youth Hunedoara", TeamType = TeamType.Kids, IsInternal = false, Description = "Copii sub 13 ani", CoachName = "Răzvan Cioran" },
                new Teams { Id = 24, TeamName = "Youth Târgoviște", TeamType = TeamType.Kids, IsInternal = false, Description = "Târgoviște Kids", CoachName = "Silviu Coman" },
                new Teams { Id = 25, TeamName = "Youth Vaslui", TeamType = TeamType.Kids, IsInternal = false, Description = "Zona Moldova", CoachName = "Mihai Leahu" },
                new Teams { Id = 26, TeamName = "Youth Baia Mare", TeamType = TeamType.Kids, IsInternal = false, Description = "Nord-Vest", CoachName = "Adrian Cârciumaru" },
                new Teams { Id = 27, TeamName = "Youth Craiova", TeamType = TeamType.Kids, IsInternal = false, Description = "Oltenia Kids", CoachName = "Viorel Neagu" },
                new Teams { Id = 28, TeamName = "Youth Ploiești", TeamType = TeamType.Kids, IsInternal = false, Description = "Muntenia copii", CoachName = "Andrei Moga" },
                new Teams { Id = 29, TeamName = "Youth Oradea", TeamType = TeamType.Kids, IsInternal = false, Description = "Echipă externă pentru juniori", CoachName = "Emil Crețu" },
                new Teams { Id = 30, TeamName = "Youth Arad", TeamType = TeamType.Kids, IsInternal = false, Description = "Vest Kids", CoachName = "Flavius Pop" },

                //Id: 31–40 (echipe externe simulate pentru cupa)
                new Teams { Id = 31, TeamName = "Steaua Galati", TeamType = TeamType.Adult, IsInternal = false, Description = "Club extern din liga a III-a", CoachName = "Radu Cârciumaru" },
                new Teams { Id = 32, TeamName = "Steaua Braila", TeamType = TeamType.Adult, IsInternal = false, Description = "Club extern din liga a II-a", CoachName = "Radu Tănase" },
                new Teams { Id = 33, TeamName = "Dinamo Giugiu", TeamType = TeamType.Adult, IsInternal = false, Description = "Club extern din liga a III-a", CoachName = "Adrian Cioran" },
                new Teams { Id = 34, TeamName = "Rapid Ploieti", TeamType = TeamType.Adult, IsInternal = false, Description = "Club extern din liga a II-a", CoachName = "Cezar Năstase" },
                new Teams { Id = 35, TeamName = "Petrolul Focsani", TeamType = TeamType.Adult, IsInternal = false, Description = "Club extern din liga a III-a", CoachName = "Istrate Costache" },
                new Teams { Id = 36, TeamName = "Universitatea Cluj", TeamType = TeamType.Adult, IsInternal = false, Description = "Club extern din liga a II-a", CoachName = "Paul Dobre" },
                new Teams { Id = 37, TeamName = "CSM Arad", TeamType = TeamType.Adult, IsInternal = false, Description = "Club extern din liga a III-a", CoachName = "Ovidiu Istrate" },
                new Teams { Id = 38, TeamName = "Gloria Bistrita", TeamType = TeamType.Adult, IsInternal = false, Description = "Club extern din liga a II-a", CoachName = "Florin Marinescu" },
                new Teams { Id = 39, TeamName = "Viitorul Olt", TeamType = TeamType.Adult, IsInternal = false, Description = "Club extern din liga a III-a", CoachName = "Cristian Filip" },
                new Teams { Id = 40, TeamName = "CS Otila", TeamType = TeamType.Adult, IsInternal = false, Description = "Club extern din liga a II-a", CoachName = "Ilie Florin" },

                // Id: 41–50 (echipe externe simulate pentru cupa campionilor)
                new Teams { Id = 41, TeamName = "Steaua Belgrad", TeamType = TeamType.Adult, IsInternal = false, Description = "Club Sarb", CoachName = "Radu Gok" },
                new Teams { Id = 42, TeamName = "Dinamo Zagreb", TeamType = TeamType.Adult, IsInternal = false, Description = "Club Croat", CoachName = "Adrian Petrovic" },
                new Teams { Id = 43, TeamName = "Olympiakos", TeamType = TeamType.Adult, IsInternal = false, Description = "Club Grec", CoachName = "Cezar Papadopoulos" },
                new Teams { Id = 44, TeamName = "Fenerbahce", TeamType = TeamType.Adult, IsInternal = false, Description = "Club Turc", CoachName = "Marius Yilmaz" },
                new Teams { Id = 45, TeamName = "Barcelona", TeamType = TeamType.Adult, IsInternal = false, Description = "Club Spaniol", CoachName = "Pablo Garcia" },
                new Teams { Id = 46, TeamName = "Bayern Munchen", TeamType = TeamType.Adult, IsInternal = false, Description = "Club German", CoachName = "Hans Müller" },
                new Teams { Id = 47, TeamName = "Paris Saint-Germain", TeamType = TeamType.Adult, IsInternal = false, Description = "Club Francez", CoachName = "Jean Dupont" },
                new Teams { Id = 48, TeamName = "Manchester City", TeamType = TeamType.Adult, IsInternal = false, Description = "Club Englez", CoachName = "John Smith" },
                new Teams { Id = 49, TeamName = "Juventus", TeamType = TeamType.Adult, IsInternal = false, Description = "Club Italian", CoachName = "Marco Rossi" }
            });

            modelBuilder.Entity<Players>().HasData(new List<Players>() {
                //Adults
                new Players() { Id = 1, PlayerName = "Stefan Popescu", Position = Position.Defender, BirthDate = new DateTime(1996, 3, 18), Player_TeamsId = 1 },
                new Players() { Id = 2, PlayerName = "Daniel Stan", Position = Position.Atacker, BirthDate = new DateTime(2003, 3, 26), Player_TeamsId = 1 },
                new Players() { Id = 3, PlayerName = "Mihai Toma", Position = Position.Midfielder, BirthDate = new DateTime(2000, 12, 13), Player_TeamsId = 1 },
                new Players() { Id = 4, PlayerName = "Radu Ilie", Position = Position.Defender, BirthDate = new DateTime(1999, 10, 28), Player_TeamsId = 1 },
                new Players() { Id = 5, PlayerName = "Daniel Matei", Position = Position.Midfielder, BirthDate = new DateTime(1994, 5, 10), Player_TeamsId = 1 },
                new Players() { Id = 6, PlayerName = "Alex Vasilescu", Position = Position.Atacker, BirthDate = new DateTime(1994, 9, 17), Player_TeamsId = 1 },
                new Players() { Id = 7, PlayerName = "Daniel Radulescu", Position = Position.Goalkeeper, BirthDate = new DateTime(1992, 12, 17), Player_TeamsId = 1 },
                new Players() { Id = 8, PlayerName = "Alex Lazar", Position = Position.Defender, BirthDate = new DateTime(1995, 5, 2), Player_TeamsId = 1 },
                new Players() { Id = 9, PlayerName = "Sergiu Chiriac", Position = Position.Midfielder, BirthDate = new DateTime(1990, 7, 5), Player_TeamsId = 1 },
                new Players() { Id = 10, PlayerName = "Andrei Enache", Position = Position.Defender, BirthDate = new DateTime(1998, 4, 17), Player_TeamsId = 1 },
                new Players() { Id = 11, PlayerName = "Denis Chiriac", Position = Position.Goalkeeper, BirthDate = new DateTime(1997, 3, 15), Player_TeamsId = 1 },
                new Players() { Id = 12, PlayerName = "Denis Neagu", Position = Position.Midfielder, BirthDate = new DateTime(1999, 12, 27), Player_TeamsId = 1 },
                new Players() { Id = 13, PlayerName = "Alin Neagu", Position = Position.Goalkeeper, BirthDate = new DateTime(2006, 8, 7), Player_TeamsId = 1 },
                new Players() { Id = 14, PlayerName = "Denis Ilie", Position = Position.Atacker, BirthDate = new DateTime(1991, 1, 12), Player_TeamsId = 1 },
                new Players() { Id = 15, PlayerName = "George Ilie", Position = Position.Midfielder, BirthDate = new DateTime(2004, 8, 12), Player_TeamsId = 1 },
                new Players() { Id = 16, PlayerName = "Gabriel Vasilescu", Position = Position.Midfielder, BirthDate = new DateTime(2005, 9, 5), Player_TeamsId = 1 },
                new Players() { Id = 17, PlayerName = "Andrei Neagu", Position = Position.Defender, BirthDate = new DateTime(2004, 12, 11), Player_TeamsId = 1 },
                new Players() { Id = 18, PlayerName = "Ionut Radulescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2004, 12, 11), Player_TeamsId = 1 },
                new Players() { Id = 19, PlayerName = "Robert Vasilescu", Position = Position.Defender, BirthDate = new DateTime(1996, 4, 28), Player_TeamsId = 1 },
                new Players() { Id = 20, PlayerName = "Vlad Enache", Position = Position.Defender, BirthDate = new DateTime(1990, 9, 28), Player_TeamsId = 1 },
                new Players() { Id = 21, PlayerName = "Daniel Barbu", Position = Position.Midfielder, BirthDate = new DateTime(1992, 12, 8), Player_TeamsId = 2 },
                new Players() { Id = 22, PlayerName = "Tudor Enache", Position = Position.Midfielder, BirthDate = new DateTime(1991, 8, 13), Player_TeamsId = 2 },
                new Players() { Id = 23, PlayerName = "Daniel Cojocaru", Position = Position.Midfielder, BirthDate = new DateTime(1990, 12, 14), Player_TeamsId = 2 },
                new Players() { Id = 24, PlayerName = "Radu Radulescu", Position = Position.Defender, BirthDate = new DateTime(1990, 11, 8), Player_TeamsId = 2 },
                new Players() { Id = 25, PlayerName = "Vlad Chiriac", Position = Position.Atacker, BirthDate = new DateTime(2000, 4, 22), Player_TeamsId = 2 },
                new Players() { Id = 26, PlayerName = "Cristian Vasilescu", Position = Position.Goalkeeper, BirthDate = new DateTime(1999, 2, 20), Player_TeamsId = 2 },
                new Players() { Id = 27, PlayerName = "Mihai Georgescu", Position = Position.Defender, BirthDate = new DateTime(2006, 2, 27), Player_TeamsId = 2 },
                new Players() { Id = 28, PlayerName = "Stefan Diaconu", Position = Position.Defender, BirthDate = new DateTime(1992, 10, 16), Player_TeamsId = 2 },
                new Players() { Id = 29, PlayerName = "Sergiu Ionescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2004, 5, 26), Player_TeamsId = 2 },
                new Players() { Id = 30, PlayerName = "Radu Enache", Position = Position.Goalkeeper, BirthDate = new DateTime(1990, 10, 15), Player_TeamsId = 2 },
                new Players() { Id = 31, PlayerName = "Radu Georgescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2005, 4, 14), Player_TeamsId = 2 },
                new Players() { Id = 32, PlayerName = "Ionut Neagu", Position = Position.Midfielder, BirthDate = new DateTime(2005, 8, 23), Player_TeamsId = 2 },
                new Players() { Id = 33, PlayerName = "Radu Cojocaru", Position = Position.Defender, BirthDate = new DateTime(1993, 5, 20), Player_TeamsId = 2 },
                new Players() { Id = 34, PlayerName = "Gabriel Enache", Position = Position.Goalkeeper, BirthDate = new DateTime(2002, 9, 21), Player_TeamsId = 2 },
                new Players() { Id = 35, PlayerName = "Vlad Popescu", Position = Position.Midfielder, BirthDate = new DateTime(1990, 11, 21), Player_TeamsId = 2 },
                new Players() { Id = 36, PlayerName = "Andrei Neagu", Position = Position.Midfielder, BirthDate = new DateTime(2004, 9, 11), Player_TeamsId = 2 },
                new Players() { Id = 37, PlayerName = "Tudor Enache", Position = Position.Midfielder, BirthDate = new DateTime(2005, 4, 17), Player_TeamsId = 2 },
                new Players() { Id = 38, PlayerName = "Andrei Marin", Position = Position.Defender, BirthDate = new DateTime(1999, 3, 3), Player_TeamsId = 2 },
                new Players() { Id = 39, PlayerName = "Alin Marin", Position = Position.Defender, BirthDate = new DateTime(2002, 3, 5), Player_TeamsId = 2 },
                new Players() { Id = 40, PlayerName = "Robert Stan", Position = Position.Defender, BirthDate = new DateTime(2004, 2, 15), Player_TeamsId = 2 },
                new Players() { Id = 41, PlayerName = "Daniel Ilie", Position = Position.Goalkeeper, BirthDate = new DateTime(1999, 9, 2), Player_TeamsId = 3 },
                new Players() { Id = 42, PlayerName = "George Ionescu", Position = Position.Midfielder, BirthDate = new DateTime(2006, 1, 7), Player_TeamsId = 3 },
                new Players() { Id = 43, PlayerName = "Robert Neagu", Position = Position.Midfielder, BirthDate = new DateTime(1991, 2, 19), Player_TeamsId = 3 },
                new Players() { Id = 44, PlayerName = "Mihai Chiriac", Position = Position.Atacker, BirthDate = new DateTime(1999, 8, 18), Player_TeamsId = 3 },
                new Players() { Id = 45, PlayerName = "Radu Marin", Position = Position.Goalkeeper, BirthDate = new DateTime(2002, 8, 22), Player_TeamsId = 3 },
                new Players() { Id = 46, PlayerName = "Robert Vasilescu", Position = Position.Defender, BirthDate = new DateTime(1996, 7, 4), Player_TeamsId = 3 },
                new Players() { Id = 47, PlayerName = "Tudor Dumitrescu", Position = Position.Atacker, BirthDate = new DateTime(1996, 12, 9), Player_TeamsId = 3 },
                new Players() { Id = 48, PlayerName = "Sergiu Marin", Position = Position.Atacker, BirthDate = new DateTime(1995, 1, 24), Player_TeamsId = 3 },
                new Players() { Id = 49, PlayerName = "Cristian Chiriac", Position = Position.Defender, BirthDate = new DateTime(1990, 2, 24), Player_TeamsId = 3 },
                new Players() { Id = 50, PlayerName = "Cristian Barbu", Position = Position.Midfielder, BirthDate = new DateTime(1996, 7, 22), Player_TeamsId = 3 },
                new Players() { Id = 51, PlayerName = "Cristian Marin", Position = Position.Midfielder, BirthDate = new DateTime(1994, 8, 28), Player_TeamsId = 3 },
                new Players() { Id = 52, PlayerName = "Daniel Dumitrescu", Position = Position.Atacker, BirthDate = new DateTime(2004, 11, 10), Player_TeamsId = 3 },
                new Players() { Id = 53, PlayerName = "Cristian Toma", Position = Position.Defender, BirthDate = new DateTime(1991, 6, 19), Player_TeamsId = 3 },
                new Players() { Id = 54, PlayerName = "Andrei Radulescu", Position = Position.Goalkeeper, BirthDate = new DateTime(1996, 8, 13), Player_TeamsId = 3 },
                new Players() { Id = 55, PlayerName = "Daniel Chiriac", Position = Position.Defender, BirthDate = new DateTime(2005, 11, 20), Player_TeamsId = 3 },
                new Players() { Id = 56, PlayerName = "Alex Toma", Position = Position.Atacker, BirthDate = new DateTime(1991, 12, 18), Player_TeamsId = 3 },
                new Players() { Id = 57, PlayerName = "Denis Popescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2003, 8, 27), Player_TeamsId = 3 },
                new Players() { Id = 58, PlayerName = "Radu Neagu", Position = Position.Defender, BirthDate = new DateTime(1990, 9, 15), Player_TeamsId = 3 },
                new Players() { Id = 59, PlayerName = "Radu Lazar", Position = Position.Defender, BirthDate = new DateTime(2000, 11, 4), Player_TeamsId = 3 },
                new Players() { Id = 60, PlayerName = "Eduard Stan", Position = Position.Defender, BirthDate = new DateTime(1994, 1, 25), Player_TeamsId = 3 },
                new Players() { Id = 61, PlayerName = "Mihai Georgescu", Position = Position.Midfielder, BirthDate = new DateTime(1990, 6, 19), Player_TeamsId = 4 },
                new Players() { Id = 62, PlayerName = "Gabriel Vasilescu", Position = Position.Goalkeeper, BirthDate = new DateTime(1997, 3, 11), Player_TeamsId = 4 },
                new Players() { Id = 63, PlayerName = "Ionut Petrescu", Position = Position.Midfielder, BirthDate = new DateTime(2003, 1, 18), Player_TeamsId = 4 },
                new Players() { Id = 64, PlayerName = "Gabriel Marin", Position = Position.Defender, BirthDate = new DateTime(2004, 3, 25), Player_TeamsId = 4 },
                new Players() { Id = 65, PlayerName = "Adrian Ilie", Position = Position.Defender, BirthDate = new DateTime(1995, 1, 19), Player_TeamsId = 4 },
                new Players() { Id = 66, PlayerName = "Cristian Georgescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2000, 5, 25), Player_TeamsId = 4 },
                new Players() { Id = 67, PlayerName = "Stefan Vasilescu", Position = Position.Midfielder, BirthDate = new DateTime(2001, 6, 7), Player_TeamsId = 4 },
                new Players() { Id = 68, PlayerName = "Andrei Matei", Position = Position.Midfielder, BirthDate = new DateTime(1995, 2, 7), Player_TeamsId = 4 },
                new Players() { Id = 69, PlayerName = "Daniel Toma", Position = Position.Goalkeeper, BirthDate = new DateTime(1999, 10, 13), Player_TeamsId = 4 },
                new Players() { Id = 70, PlayerName = "Radu Neagu", Position = Position.Midfielder, BirthDate = new DateTime(1993, 2, 19), Player_TeamsId = 4 },
                new Players() { Id = 71, PlayerName = "Sergiu Toma", Position = Position.Defender, BirthDate = new DateTime(1993, 11, 19), Player_TeamsId = 4 },
                new Players() { Id = 72, PlayerName = "Paul Barbu", Position = Position.Midfielder, BirthDate = new DateTime(2000, 11, 28), Player_TeamsId = 4 },
                new Players() { Id = 73, PlayerName = "Mihai Cojocaru", Position = Position.Atacker, BirthDate = new DateTime(1996, 8, 2), Player_TeamsId = 4 },
                new Players() { Id = 74, PlayerName = "Daniel Popescu", Position = Position.Atacker, BirthDate = new DateTime(1996, 1, 25), Player_TeamsId = 4 },
                new Players() { Id = 75, PlayerName = "Cristian Matei", Position = Position.Atacker, BirthDate = new DateTime(2004, 8, 22), Player_TeamsId = 4 },
                new Players() { Id = 76, PlayerName = "Mihai Vasilescu", Position = Position.Atacker, BirthDate = new DateTime(1991, 6, 14), Player_TeamsId = 4 },
                new Players() { Id = 77, PlayerName = "Cristian Enache", Position = Position.Goalkeeper, BirthDate = new DateTime(1991, 12, 2), Player_TeamsId = 4 },
                new Players() { Id = 78, PlayerName = "Stefan Matei", Position = Position.Defender, BirthDate = new DateTime(2002, 1, 21), Player_TeamsId = 4 },
                new Players() { Id = 79, PlayerName = "Tudor Vasilescu", Position = Position.Goalkeeper, BirthDate = new DateTime(1999, 7, 28), Player_TeamsId = 4 },
                new Players() { Id = 80, PlayerName = "Stefan Barbu", Position = Position.Atacker, BirthDate = new DateTime(2005, 12, 21), Player_TeamsId = 4 },
                new Players() { Id = 81, PlayerName = "Alin Lazar", Position = Position.Goalkeeper, BirthDate = new DateTime(1992, 6, 1), Player_TeamsId = 5 },
                new Players() { Id = 82, PlayerName = "Adrian Ionescu", Position = Position.Defender, BirthDate = new DateTime(2002, 4, 24), Player_TeamsId = 5 },
                new Players() { Id = 83, PlayerName = "Tudor Vasilescu", Position = Position.Midfielder, BirthDate = new DateTime(2004, 6, 28), Player_TeamsId = 5 },
                new Players() { Id = 84, PlayerName = "Vlad Toma", Position = Position.Goalkeeper, BirthDate = new DateTime(1999, 11, 24), Player_TeamsId = 5 },
                new Players() { Id = 85, PlayerName = "Sergiu Popescu", Position = Position.Goalkeeper, BirthDate = new DateTime(1993, 7, 2), Player_TeamsId = 5 },
                new Players() { Id = 86, PlayerName = "Denis Petrescu", Position = Position.Goalkeeper, BirthDate = new DateTime(1994, 9, 24), Player_TeamsId = 5 },
                new Players() { Id = 87, PlayerName = "Adrian Chiriac", Position = Position.Atacker, BirthDate = new DateTime(2003, 5, 16), Player_TeamsId = 5 },
                new Players() { Id = 88, PlayerName = "Gabriel Popescu", Position = Position.Atacker, BirthDate = new DateTime(1992, 3, 11), Player_TeamsId = 5 },
                new Players() { Id = 89, PlayerName = "Denis Toma", Position = Position.Midfielder, BirthDate = new DateTime(1991, 2, 17), Player_TeamsId = 5 },
                new Players() { Id = 90, PlayerName = "Ionut Petrescu", Position = Position.Midfielder, BirthDate = new DateTime(1991, 10, 9), Player_TeamsId = 5 },
                new Players() { Id = 91, PlayerName = "Vlad Voicu", Position = Position.Midfielder, BirthDate = new DateTime(1994, 3, 17), Player_TeamsId = 5 },
                new Players() { Id = 92, PlayerName = "Alin Georgescu", Position = Position.Atacker, BirthDate = new DateTime(1996, 12, 1), Player_TeamsId = 5 },
                new Players() { Id = 93, PlayerName = "Paul Petrescu", Position = Position.Goalkeeper, BirthDate = new DateTime(1994, 3, 13), Player_TeamsId = 5 },
                new Players() { Id = 94, PlayerName = "Radu Lazar", Position = Position.Goalkeeper, BirthDate = new DateTime(1992, 6, 13), Player_TeamsId = 5 },
                new Players() { Id = 95, PlayerName = "Denis Stan", Position = Position.Midfielder, BirthDate = new DateTime(1996, 4, 2), Player_TeamsId = 5 },
                new Players() { Id = 96, PlayerName = "Gabriel Popescu", Position = Position.Midfielder, BirthDate = new DateTime(1991, 12, 20), Player_TeamsId = 5 },
                new Players() { Id = 97, PlayerName = "Gabriel Voicu", Position = Position.Midfielder, BirthDate = new DateTime(1992, 6, 25), Player_TeamsId = 5 },
                new Players() { Id = 98, PlayerName = "Eduard Dumitrescu", Position = Position.Midfielder, BirthDate = new DateTime(2003, 5, 4), Player_TeamsId = 5 },
                new Players() { Id = 99, PlayerName = "Radu Georgescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2001, 1, 14), Player_TeamsId = 5 },
                new Players() { Id = 100, PlayerName = "Adrian Petrescu", Position = Position.Defender, BirthDate = new DateTime(2003, 2, 11), Player_TeamsId = 5 },
                new Players() { Id = 101, PlayerName = "Radu Marin", Position = Position.Defender, BirthDate = new DateTime(1992, 3, 13), Player_TeamsId = 6 },
                new Players() { Id = 102, PlayerName = "Vlad Voicu", Position = Position.Atacker, BirthDate = new DateTime(1991, 8, 14), Player_TeamsId = 6 },
                new Players() { Id = 103, PlayerName = "Denis Dumitrescu", Position = Position.Atacker, BirthDate = new DateTime(1993, 10, 13), Player_TeamsId = 6 },
                new Players() { Id = 104, PlayerName = "Adrian Voicu", Position = Position.Atacker, BirthDate = new DateTime(1992, 8, 9), Player_TeamsId = 6 },
                new Players() { Id = 105, PlayerName = "Radu Ilie", Position = Position.Midfielder, BirthDate = new DateTime(1994, 3, 2), Player_TeamsId = 6 },
                new Players() { Id = 106, PlayerName = "Sergiu Toma", Position = Position.Goalkeeper, BirthDate = new DateTime(1997, 6, 20), Player_TeamsId = 6 },
                new Players() { Id = 107, PlayerName = "Robert Radulescu", Position = Position.Defender, BirthDate = new DateTime(1995, 8, 19), Player_TeamsId = 6 },
                new Players() { Id = 108, PlayerName = "Alin Diaconu", Position = Position.Atacker, BirthDate = new DateTime(1992, 8, 27), Player_TeamsId = 6 },
                new Players() { Id = 109, PlayerName = "Eduard Enache", Position = Position.Midfielder, BirthDate = new DateTime(1999, 11, 18), Player_TeamsId = 6 },
                new Players() { Id = 110, PlayerName = "Vlad Cojocaru", Position = Position.Midfielder, BirthDate = new DateTime(2000, 5, 20), Player_TeamsId = 6 },
                new Players() { Id = 111, PlayerName = "Paul Matei", Position = Position.Defender, BirthDate = new DateTime(2006, 6, 17), Player_TeamsId = 6 },
                new Players() { Id = 112, PlayerName = "Florin Georgescu", Position = Position.Defender, BirthDate = new DateTime(2004, 6, 10), Player_TeamsId = 6 },
                new Players() { Id = 113, PlayerName = "Alin Ionescu", Position = Position.Atacker, BirthDate = new DateTime(2004, 7, 4), Player_TeamsId = 6 },
                new Players() { Id = 114, PlayerName = "Alex Diaconu", Position = Position.Atacker, BirthDate = new DateTime(1991, 7, 15), Player_TeamsId = 6 },
                new Players() { Id = 115, PlayerName = "Stefan Chiriac", Position = Position.Defender, BirthDate = new DateTime(1994, 8, 5), Player_TeamsId = 6 },
                new Players() { Id = 116, PlayerName = "Gabriel Lazar", Position = Position.Goalkeeper, BirthDate = new DateTime(1993, 4, 18), Player_TeamsId = 6 },
                new Players() { Id = 117, PlayerName = "Daniel Popescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2000, 3, 16), Player_TeamsId = 6 },
                new Players() { Id = 118, PlayerName = "Cristian Marin", Position = Position.Goalkeeper, BirthDate = new DateTime(1998, 6, 16), Player_TeamsId = 6 },
                new Players() { Id = 119, PlayerName = "Alex Enache", Position = Position.Midfielder, BirthDate = new DateTime(2003, 3, 2), Player_TeamsId = 6 },
                new Players() { Id = 120, PlayerName = "Denis Neagu", Position = Position.Defender, BirthDate = new DateTime(2006, 7, 26), Player_TeamsId = 6 },
                new Players() { Id = 121, PlayerName = "Mihai Enache", Position = Position.Goalkeeper, BirthDate = new DateTime(1998, 3, 20), Player_TeamsId = 7 },
                new Players() { Id = 122, PlayerName = "Mihai Ionescu", Position = Position.Midfielder, BirthDate = new DateTime(2001, 1, 12), Player_TeamsId = 7 },
                new Players() { Id = 123, PlayerName = "George Chiriac", Position = Position.Goalkeeper, BirthDate = new DateTime(2004, 2, 20), Player_TeamsId = 7 },
                new Players() { Id = 124, PlayerName = "Gabriel Lazar", Position = Position.Midfielder, BirthDate = new DateTime(1999, 7, 6), Player_TeamsId = 7 },
                new Players() { Id = 125, PlayerName = "Alex Cojocaru", Position = Position.Goalkeeper, BirthDate = new DateTime(2000, 10, 1), Player_TeamsId = 7 },
                new Players() { Id = 126, PlayerName = "George Stan", Position = Position.Goalkeeper, BirthDate = new DateTime(1990, 2, 26), Player_TeamsId = 7 },
                new Players() { Id = 127, PlayerName = "Daniel Barbu", Position = Position.Goalkeeper, BirthDate = new DateTime(1995, 11, 19), Player_TeamsId = 7 },
                new Players() { Id = 128, PlayerName = "Vlad Radulescu", Position = Position.Midfielder, BirthDate = new DateTime(1998, 1, 7), Player_TeamsId = 7 },
                new Players() { Id = 129, PlayerName = "Denis Voicu", Position = Position.Goalkeeper, BirthDate = new DateTime(2003, 6, 20), Player_TeamsId = 7 },
                new Players() { Id = 130, PlayerName = "Denis Radulescu", Position = Position.Midfielder, BirthDate = new DateTime(2001, 6, 11), Player_TeamsId = 7 },
                new Players() { Id = 131, PlayerName = "Alex Neagu", Position = Position.Goalkeeper, BirthDate = new DateTime(2000, 12, 16), Player_TeamsId = 7 },
                new Players() { Id = 132, PlayerName = "Vlad Toma", Position = Position.Defender, BirthDate = new DateTime(2005, 7, 12), Player_TeamsId = 7 },
                new Players() { Id = 133, PlayerName = "Stefan Vasilescu", Position = Position.Defender, BirthDate = new DateTime(1998, 11, 15), Player_TeamsId = 7 },
                new Players() { Id = 134, PlayerName = "Gabriel Radulescu", Position = Position.Atacker, BirthDate = new DateTime(1994, 12, 26), Player_TeamsId = 7 },
                new Players() { Id = 135, PlayerName = "Mihai Vasilescu", Position = Position.Atacker, BirthDate = new DateTime(2001, 11, 4), Player_TeamsId = 7 },
                new Players() { Id = 136, PlayerName = "Stefan Neagu", Position = Position.Defender, BirthDate = new DateTime(1990, 11, 26), Player_TeamsId = 7 },
                new Players() { Id = 137, PlayerName = "Alin Dumitrescu", Position = Position.Midfielder, BirthDate = new DateTime(1999, 5, 6), Player_TeamsId = 7 },
                new Players() { Id = 138, PlayerName = "Stefan Matei", Position = Position.Goalkeeper, BirthDate = new DateTime(1992, 11, 21), Player_TeamsId = 7 },
                new Players() { Id = 139, PlayerName = "Mihai Cojocaru", Position = Position.Defender, BirthDate = new DateTime(2000, 6, 26), Player_TeamsId = 7 },
                new Players() { Id = 140, PlayerName = "Radu Neagu", Position = Position.Midfielder, BirthDate = new DateTime(1997, 11, 18), Player_TeamsId = 7 },
                new Players() { Id = 141, PlayerName = "Tudor Lazar", Position = Position.Defender, BirthDate = new DateTime(2003, 6, 16), Player_TeamsId = 8 },
                new Players() { Id = 142, PlayerName = "Daniel Vasilescu", Position = Position.Atacker, BirthDate = new DateTime(1999, 2, 22), Player_TeamsId = 8 },
                new Players() { Id = 143, PlayerName = "Tudor Cojocaru", Position = Position.Atacker, BirthDate = new DateTime(1996, 12, 26), Player_TeamsId = 8 },
                new Players() { Id = 144, PlayerName = "Eduard Popescu", Position = Position.Goalkeeper, BirthDate = new DateTime(1993, 5, 14), Player_TeamsId = 8 },
                new Players() { Id = 145, PlayerName = "Robert Georgescu", Position = Position.Midfielder, BirthDate = new DateTime(2003, 9, 27), Player_TeamsId = 8 },
                new Players() { Id = 146, PlayerName = "Cristian Ionescu", Position = Position.Atacker, BirthDate = new DateTime(1998, 1, 19), Player_TeamsId = 8 },
                new Players() { Id = 147, PlayerName = "Cristian Neagu", Position = Position.Atacker, BirthDate = new DateTime(1998, 3, 11), Player_TeamsId = 8 },
                new Players() { Id = 148, PlayerName = "Ionut Marin", Position = Position.Goalkeeper, BirthDate = new DateTime(1992, 6, 9), Player_TeamsId = 8 },
                new Players() { Id = 149, PlayerName = "Cristian Barbu", Position = Position.Midfielder, BirthDate = new DateTime(2001, 1, 16), Player_TeamsId = 8 },
                new Players() { Id = 150, PlayerName = "Eduard Marin", Position = Position.Defender, BirthDate = new DateTime(2004, 1, 17), Player_TeamsId = 8 },
                new Players() { Id = 151, PlayerName = "Eduard Ilie", Position = Position.Goalkeeper, BirthDate = new DateTime(1993, 6, 14), Player_TeamsId = 8 },
                new Players() { Id = 152, PlayerName = "Tudor Voicu", Position = Position.Atacker, BirthDate = new DateTime(1991, 8, 3), Player_TeamsId = 8 },
                new Players() { Id = 153, PlayerName = "Florin Ionescu", Position = Position.Atacker, BirthDate = new DateTime(2002, 5, 11), Player_TeamsId = 8 },
                new Players() { Id = 154, PlayerName = "Daniel Voicu", Position = Position.Midfielder, BirthDate = new DateTime(1991, 1, 23), Player_TeamsId = 8 },
                new Players() { Id = 155, PlayerName = "Florin Cojocaru", Position = Position.Goalkeeper, BirthDate = new DateTime(2001, 12, 23), Player_TeamsId = 8 },
                new Players() { Id = 156, PlayerName = "Sergiu Diaconu", Position = Position.Goalkeeper, BirthDate = new DateTime(1990, 11, 19), Player_TeamsId = 8 },
                new Players() { Id = 157, PlayerName = "Tudor Marin", Position = Position.Midfielder, BirthDate = new DateTime(2004, 9, 6), Player_TeamsId = 8 },
                new Players() { Id = 158, PlayerName = "Tudor Marin", Position = Position.Midfielder, BirthDate = new DateTime(1999, 9, 26), Player_TeamsId = 8 },
                new Players() { Id = 159, PlayerName = "Vlad Toma", Position = Position.Goalkeeper, BirthDate = new DateTime(1998, 11, 1), Player_TeamsId = 8 },
                new Players() { Id = 160, PlayerName = "Tudor Stan", Position = Position.Goalkeeper, BirthDate = new DateTime(2006, 7, 11), Player_TeamsId = 8 },
                new Players() { Id = 161, PlayerName = "Florin Petrescu", Position = Position.Midfielder, BirthDate = new DateTime(2005, 7, 28), Player_TeamsId = 9 },
                new Players() { Id = 162, PlayerName = "Eduard Petrescu", Position = Position.Atacker, BirthDate = new DateTime(1992, 5, 22), Player_TeamsId = 9 },
                new Players() { Id = 163, PlayerName = "Radu Vasilescu", Position = Position.Defender, BirthDate = new DateTime(1996, 4, 24), Player_TeamsId = 9 },
                new Players() { Id = 164, PlayerName = "Cristian Stan", Position = Position.Goalkeeper, BirthDate = new DateTime(1992, 11, 25), Player_TeamsId = 9 },
                new Players() { Id = 165, PlayerName = "Adrian Marin", Position = Position.Atacker, BirthDate = new DateTime(1990, 6, 6), Player_TeamsId = 9 },
                new Players() { Id = 166, PlayerName = "Cristian Ilie", Position = Position.Goalkeeper, BirthDate = new DateTime(1997, 6, 11), Player_TeamsId = 9 },
                new Players() { Id = 167, PlayerName = "Sergiu Enache", Position = Position.Goalkeeper, BirthDate = new DateTime(2001, 8, 22), Player_TeamsId = 9 },
                new Players() { Id = 168, PlayerName = "Tudor Toma", Position = Position.Defender, BirthDate = new DateTime(1992, 9, 11), Player_TeamsId = 9 },
                new Players() { Id = 169, PlayerName = "Adrian Enache", Position = Position.Atacker, BirthDate = new DateTime(1998, 8, 14), Player_TeamsId = 9 },
                new Players() { Id = 170, PlayerName = "Gabriel Vasilescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2000, 1, 8), Player_TeamsId = 9 },
                new Players() { Id = 171, PlayerName = "Adrian Petrescu", Position = Position.Midfielder, BirthDate = new DateTime(1991, 6, 6), Player_TeamsId = 9 },
                new Players() { Id = 172, PlayerName = "Tudor Lazar", Position = Position.Atacker, BirthDate = new DateTime(1997, 7, 20), Player_TeamsId = 9 },
                new Players() { Id = 173, PlayerName = "Gabriel Matei", Position = Position.Goalkeeper, BirthDate = new DateTime(2002, 5, 14), Player_TeamsId = 9 },
                new Players() { Id = 174, PlayerName = "Adrian Ilie", Position = Position.Midfielder, BirthDate = new DateTime(2003, 3, 18), Player_TeamsId = 9 },
                new Players() { Id = 175, PlayerName = "Ionut Voicu", Position = Position.Atacker, BirthDate = new DateTime(1994, 4, 17), Player_TeamsId = 9 },
                new Players() { Id = 176, PlayerName = "Eduard Enache", Position = Position.Midfielder, BirthDate = new DateTime(2000, 8, 3), Player_TeamsId = 9 },
                new Players() { Id = 177, PlayerName = "Cristian Barbu", Position = Position.Goalkeeper, BirthDate = new DateTime(1999, 4, 4), Player_TeamsId = 9 },
                new Players() { Id = 178, PlayerName = "Gabriel Vasilescu", Position = Position.Goalkeeper, BirthDate = new DateTime(1997, 12, 15), Player_TeamsId = 9 },
                new Players() { Id = 179, PlayerName = "Andrei Matei", Position = Position.Midfielder, BirthDate = new DateTime(1992, 7, 8), Player_TeamsId = 9 },
                new Players() { Id = 180, PlayerName = "Florin Popescu", Position = Position.Midfielder, BirthDate = new DateTime(1997, 5, 10), Player_TeamsId = 9 },
                new Players() { Id = 181, PlayerName = "Mihai Radulescu", Position = Position.Defender, BirthDate = new DateTime(1995, 2, 11), Player_TeamsId = 10 },
                new Players() { Id = 182, PlayerName = "Sergiu Toma", Position = Position.Defender, BirthDate = new DateTime(2005, 11, 1), Player_TeamsId = 10 },
                new Players() { Id = 183, PlayerName = "Stefan Voicu", Position = Position.Midfielder, BirthDate = new DateTime(2004, 4, 26), Player_TeamsId = 10 },
                new Players() { Id = 184, PlayerName = "Alex Voicu", Position = Position.Atacker, BirthDate = new DateTime(2003, 6, 3), Player_TeamsId = 10 },
                new Players() { Id = 185, PlayerName = "Daniel Ilie", Position = Position.Midfielder, BirthDate = new DateTime(1991, 5, 2), Player_TeamsId = 10 },
                new Players() { Id = 186, PlayerName = "Florin Lazar", Position = Position.Atacker, BirthDate = new DateTime(2002, 5, 4), Player_TeamsId = 10 },
                new Players() { Id = 187, PlayerName = "Cristian Matei", Position = Position.Atacker, BirthDate = new DateTime(2006, 12, 15), Player_TeamsId = 10 },
                new Players() { Id = 188, PlayerName = "Radu Diaconu", Position = Position.Midfielder, BirthDate = new DateTime(1996, 12, 11), Player_TeamsId = 10 },
                new Players() { Id = 189, PlayerName = "Tudor Ilie", Position = Position.Goalkeeper, BirthDate = new DateTime(1996, 2, 28), Player_TeamsId = 10 },
                new Players() { Id = 190, PlayerName = "Robert Petrescu", Position = Position.Defender, BirthDate = new DateTime(1992, 2, 12), Player_TeamsId = 10 },
                new Players() { Id = 191, PlayerName = "Gabriel Chiriac", Position = Position.Defender, BirthDate = new DateTime(2000, 12, 6), Player_TeamsId = 10 },
                new Players() { Id = 192, PlayerName = "Radu Cojocaru", Position = Position.Midfielder, BirthDate = new DateTime(1992, 11, 10), Player_TeamsId = 10 },
                new Players() { Id = 193, PlayerName = "Daniel Ionescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2001, 11, 21), Player_TeamsId = 10 },
                new Players() { Id = 194, PlayerName = "Radu Ionescu", Position = Position.Defender, BirthDate = new DateTime(2006, 6, 20), Player_TeamsId = 10 },
                new Players() { Id = 195, PlayerName = "Florin Toma", Position = Position.Goalkeeper, BirthDate = new DateTime(1995, 6, 23), Player_TeamsId = 10 },
                new Players() { Id = 196, PlayerName = "Sergiu Toma", Position = Position.Midfielder, BirthDate = new DateTime(1993, 2, 22), Player_TeamsId = 10 },
                new Players() { Id = 197, PlayerName = "George Diaconu", Position = Position.Defender, BirthDate = new DateTime(1993, 11, 17), Player_TeamsId = 10 },
                new Players() { Id = 198, PlayerName = "Gabriel Radulescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2000, 8, 7), Player_TeamsId = 10 },
                new Players() { Id = 199, PlayerName = "Mihai Diaconu", Position = Position.Midfielder, BirthDate = new DateTime(2003, 1, 5), Player_TeamsId = 10 },
                new Players() { Id = 200, PlayerName = "Eduard Marin", Position = Position.Midfielder, BirthDate = new DateTime(2001, 6, 24), Player_TeamsId = 10 },
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //u21
                new Players() { Id = 201, PlayerName = "Cristian Ilie", Position = Position.Atacker, BirthDate = new DateTime(2005, 9, 15), Player_TeamsId = 11 },
                new Players() { Id = 202, PlayerName = "Robert Ionescu", Position = Position.Atacker, BirthDate = new DateTime(2004, 10, 13), Player_TeamsId = 11 },
                new Players() { Id = 203, PlayerName = "Denis Lazar", Position = Position.Goalkeeper, BirthDate = new DateTime(2004, 1, 27), Player_TeamsId = 11 },
                new Players() { Id = 204, PlayerName = "Daniel Ilie", Position = Position.Midfielder, BirthDate = new DateTime(2008, 11, 3), Player_TeamsId = 11 },
                new Players() { Id = 205, PlayerName = "Eduard Georgescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2006, 11, 6), Player_TeamsId = 11 },
                new Players() { Id = 206, PlayerName = "Alex Matei", Position = Position.Midfielder, BirthDate = new DateTime(2005, 12, 1), Player_TeamsId = 11 },
                new Players() { Id = 207, PlayerName = "George Diaconu", Position = Position.Defender, BirthDate = new DateTime(2006, 1, 4), Player_TeamsId = 11 },
                new Players() { Id = 208, PlayerName = "Alin Dumitrescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2008, 8, 7), Player_TeamsId = 11 },
                new Players() { Id = 209, PlayerName = "Adrian Toma", Position = Position.Defender, BirthDate = new DateTime(2007, 10, 12), Player_TeamsId = 11 },
                new Players() { Id = 210, PlayerName = "Alin Diaconu", Position = Position.Defender, BirthDate = new DateTime(2004, 10, 27), Player_TeamsId = 11 },
                new Players() { Id = 211, PlayerName = "Eduard Diaconu", Position = Position.Goalkeeper, BirthDate = new DateTime(2005, 6, 26), Player_TeamsId = 11 },
                new Players() { Id = 212, PlayerName = "Alin Voicu", Position = Position.Defender, BirthDate = new DateTime(2005, 6, 2), Player_TeamsId = 11 },
                new Players() { Id = 213, PlayerName = "Robert Cojocaru", Position = Position.Midfielder, BirthDate = new DateTime(2008, 4, 1), Player_TeamsId = 11 },
                new Players() { Id = 214, PlayerName = "Robert Radulescu", Position = Position.Atacker, BirthDate = new DateTime(2007, 4, 16), Player_TeamsId = 11 },
                new Players() { Id = 215, PlayerName = "Sergiu Radulescu", Position = Position.Defender, BirthDate = new DateTime(2005, 3, 25), Player_TeamsId = 11 },
                new Players() { Id = 216, PlayerName = "Florin Matei", Position = Position.Atacker, BirthDate = new DateTime(2005, 9, 11), Player_TeamsId = 11 },
                new Players() { Id = 217, PlayerName = "Sergiu Neagu", Position = Position.Atacker, BirthDate = new DateTime(2004, 1, 28), Player_TeamsId = 11 },
                new Players() { Id = 218, PlayerName = "Robert Dumitrescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2007, 7, 12), Player_TeamsId = 11 },
                new Players() { Id = 219, PlayerName = "Denis Cojocaru", Position = Position.Midfielder, BirthDate = new DateTime(2007, 1, 27), Player_TeamsId = 11 },
                new Players() { Id = 220, PlayerName = "Eduard Popescu", Position = Position.Atacker, BirthDate = new DateTime(2004, 2, 13), Player_TeamsId = 11 },
                new Players() { Id = 221, PlayerName = "Vlad Diaconu", Position = Position.Atacker, BirthDate = new DateTime(2007, 12, 9), Player_TeamsId = 12 },
                new Players() { Id = 222, PlayerName = "Paul Neagu", Position = Position.Midfielder, BirthDate = new DateTime(2008, 9, 23), Player_TeamsId = 12 },
                new Players() { Id = 223, PlayerName = "Adrian Stan", Position = Position.Midfielder, BirthDate = new DateTime(2007, 3, 22), Player_TeamsId = 12 },
                new Players() { Id = 224, PlayerName = "Vlad Ionescu", Position = Position.Atacker, BirthDate = new DateTime(2006, 5, 10), Player_TeamsId = 12 },
                new Players() { Id = 225, PlayerName = "Alin Marin", Position = Position.Defender, BirthDate = new DateTime(2006, 1, 6), Player_TeamsId = 12 },
                new Players() { Id = 226, PlayerName = "Vlad Popescu", Position = Position.Midfielder, BirthDate = new DateTime(2006, 2, 26), Player_TeamsId = 12 },
                new Players() { Id = 227, PlayerName = "George Voicu", Position = Position.Atacker, BirthDate = new DateTime(2004, 6, 25), Player_TeamsId = 12 },
                new Players() { Id = 228, PlayerName = "Tudor Enache", Position = Position.Atacker, BirthDate = new DateTime(2004, 6, 22), Player_TeamsId = 12 },
                new Players() { Id = 229, PlayerName = "Tudor Vasilescu", Position = Position.Midfielder, BirthDate = new DateTime(2007, 12, 6), Player_TeamsId = 12 },
                new Players() { Id = 230, PlayerName = "Eduard Marin", Position = Position.Defender, BirthDate = new DateTime(2007, 10, 18), Player_TeamsId = 12 },
                new Players() { Id = 231, PlayerName = "Stefan Georgescu", Position = Position.Atacker, BirthDate = new DateTime(2007, 6, 9), Player_TeamsId = 12 },
                new Players() { Id = 232, PlayerName = "Vlad Marin", Position = Position.Defender, BirthDate = new DateTime(2005, 10, 10), Player_TeamsId = 12 },
                new Players() { Id = 233, PlayerName = "Gabriel Radulescu", Position = Position.Midfielder, BirthDate = new DateTime(2007, 8, 13), Player_TeamsId = 12 },
                new Players() { Id = 234, PlayerName = "Sergiu Toma", Position = Position.Goalkeeper, BirthDate = new DateTime(2008, 5, 8), Player_TeamsId = 12 },
                new Players() { Id = 235, PlayerName = "Daniel Popescu", Position = Position.Midfielder, BirthDate = new DateTime(2006, 12, 18), Player_TeamsId = 12 },
                new Players() { Id = 236, PlayerName = "Ionut Diaconu", Position = Position.Goalkeeper, BirthDate = new DateTime(2004, 6, 19), Player_TeamsId = 12 },
                new Players() { Id = 237, PlayerName = "Adrian Ionescu", Position = Position.Midfielder, BirthDate = new DateTime(2005, 2, 1), Player_TeamsId = 12 },
                new Players() { Id = 238, PlayerName = "Gabriel Petrescu", Position = Position.Atacker, BirthDate = new DateTime(2006, 3, 9), Player_TeamsId = 12 },
                new Players() { Id = 239, PlayerName = "Adrian Lazar", Position = Position.Goalkeeper, BirthDate = new DateTime(2005, 11, 17), Player_TeamsId = 12 },
                new Players() { Id = 240, PlayerName = "Alin Popescu", Position = Position.Midfielder, BirthDate = new DateTime(2007, 5, 27), Player_TeamsId = 12 },
                new Players() { Id = 241, PlayerName = "Andrei Matei", Position = Position.Atacker, BirthDate = new DateTime(2004, 1, 22), Player_TeamsId = 13 },
                new Players() { Id = 242, PlayerName = "Florin Voicu", Position = Position.Atacker, BirthDate = new DateTime(2008, 3, 22), Player_TeamsId = 13 },
                new Players() { Id = 243, PlayerName = "Stefan Matei", Position = Position.Defender, BirthDate = new DateTime(2008, 1, 8), Player_TeamsId = 13 },
                new Players() { Id = 244, PlayerName = "Alin Petrescu", Position = Position.Defender, BirthDate = new DateTime(2007, 6, 27), Player_TeamsId = 13 },
                new Players() { Id = 245, PlayerName = "Adrian Ionescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2007, 2, 20), Player_TeamsId = 13 },
                new Players() { Id = 246, PlayerName = "Vlad Dumitrescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2005, 8, 19), Player_TeamsId = 13 },
                new Players() { Id = 247, PlayerName = "Eduard Diaconu", Position = Position.Goalkeeper, BirthDate = new DateTime(2005, 3, 10), Player_TeamsId = 13 },
                new Players() { Id = 248, PlayerName = "Mihai Neagu", Position = Position.Goalkeeper, BirthDate = new DateTime(2006, 7, 15), Player_TeamsId = 13 },
                new Players() { Id = 249, PlayerName = "Paul Enache", Position = Position.Defender, BirthDate = new DateTime(2007, 5, 25), Player_TeamsId = 13 },
                new Players() { Id = 250, PlayerName = "Vlad Marin", Position = Position.Atacker, BirthDate = new DateTime(2004, 9, 24), Player_TeamsId = 13 },
                new Players() { Id = 251, PlayerName = "Alex Radulescu", Position = Position.Atacker, BirthDate = new DateTime(2007, 8, 13), Player_TeamsId = 13 },
                new Players() { Id = 252, PlayerName = "Vlad Barbu", Position = Position.Goalkeeper, BirthDate = new DateTime(2005, 9, 10), Player_TeamsId = 13 },
                new Players() { Id = 253, PlayerName = "George Neagu", Position = Position.Goalkeeper, BirthDate = new DateTime(2004, 2, 26), Player_TeamsId = 13 },
                new Players() { Id = 254, PlayerName = "Paul Diaconu", Position = Position.Atacker, BirthDate = new DateTime(2005, 7, 14), Player_TeamsId = 13 },
                new Players() { Id = 255, PlayerName = "Mihai Cojocaru", Position = Position.Midfielder, BirthDate = new DateTime(2007, 3, 9), Player_TeamsId = 13 },
                new Players() { Id = 256, PlayerName = "George Petrescu", Position = Position.Midfielder, BirthDate = new DateTime(2004, 6, 10), Player_TeamsId = 13 },
                new Players() { Id = 257, PlayerName = "Adrian Barbu", Position = Position.Midfielder, BirthDate = new DateTime(2004, 7, 17), Player_TeamsId = 13 },
                new Players() { Id = 258, PlayerName = "Adrian Radulescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2008, 4, 13), Player_TeamsId = 13 },
                new Players() { Id = 259, PlayerName = "Mihai Toma", Position = Position.Atacker, BirthDate = new DateTime(2006, 8, 5), Player_TeamsId = 13 },
                new Players() { Id = 260, PlayerName = "Robert Stan", Position = Position.Midfielder, BirthDate = new DateTime(2004, 8, 13), Player_TeamsId = 13 },
                new Players() { Id = 261, PlayerName = "Alex Barbu", Position = Position.Defender, BirthDate = new DateTime(2007, 5, 27), Player_TeamsId = 14 },
                new Players() { Id = 262, PlayerName = "Florin Voicu", Position = Position.Midfielder, BirthDate = new DateTime(2007, 9, 15), Player_TeamsId = 14 },
                new Players() { Id = 263, PlayerName = "Cristian Barbu", Position = Position.Goalkeeper, BirthDate = new DateTime(2006, 6, 3), Player_TeamsId = 14 },
                new Players() { Id = 264, PlayerName = "Robert Lazar", Position = Position.Goalkeeper, BirthDate = new DateTime(2004, 1, 16), Player_TeamsId = 14 },
                new Players() { Id = 265, PlayerName = "Vlad Dumitrescu", Position = Position.Defender, BirthDate = new DateTime(2004, 1, 24), Player_TeamsId = 14 },
                new Players() { Id = 266, PlayerName = "Paul Lazar", Position = Position.Defender, BirthDate = new DateTime(2005, 12, 2), Player_TeamsId = 14 },
                new Players() { Id = 267, PlayerName = "Cristian Matei", Position = Position.Defender, BirthDate = new DateTime(2005, 10, 3), Player_TeamsId = 14 },
                new Players() { Id = 268, PlayerName = "Radu Toma", Position = Position.Midfielder, BirthDate = new DateTime(2004, 1, 8), Player_TeamsId = 14 },
                new Players() { Id = 269, PlayerName = "Daniel Cojocaru", Position = Position.Atacker, BirthDate = new DateTime(2007, 9, 16), Player_TeamsId = 14 },
                new Players() { Id = 270, PlayerName = "Florin Petrescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2008, 2, 15), Player_TeamsId = 14 },
                new Players() { Id = 271, PlayerName = "Cristian Voicu", Position = Position.Goalkeeper, BirthDate = new DateTime(2008, 7, 27), Player_TeamsId = 14 },
                new Players() { Id = 272, PlayerName = "George Ionescu", Position = Position.Midfielder, BirthDate = new DateTime(2008, 9, 6), Player_TeamsId = 14 },
                new Players() { Id = 273, PlayerName = "Radu Ilie", Position = Position.Midfielder, BirthDate = new DateTime(2004, 1, 7), Player_TeamsId = 14 },
                new Players() { Id = 274, PlayerName = "Alex Marin", Position = Position.Goalkeeper, BirthDate = new DateTime(2007, 11, 21), Player_TeamsId = 14 },
                new Players() { Id = 275, PlayerName = "Daniel Barbu", Position = Position.Goalkeeper, BirthDate = new DateTime(2005, 9, 28), Player_TeamsId = 14 },
                new Players() { Id = 276, PlayerName = "Stefan Barbu", Position = Position.Defender, BirthDate = new DateTime(2004, 3, 20), Player_TeamsId = 14 },
                new Players() { Id = 277, PlayerName = "Mihai Ilie", Position = Position.Atacker, BirthDate = new DateTime(2004, 12, 18), Player_TeamsId = 14 },
                new Players() { Id = 278, PlayerName = "Gabriel Petrescu", Position = Position.Defender, BirthDate = new DateTime(2004, 8, 19), Player_TeamsId = 14 },
                new Players() { Id = 279, PlayerName = "Alex Radulescu", Position = Position.Atacker, BirthDate = new DateTime(2007, 1, 3), Player_TeamsId = 14 },
                new Players() { Id = 280, PlayerName = "Daniel Georgescu", Position = Position.Midfielder, BirthDate = new DateTime(2008, 5, 19), Player_TeamsId = 14 },
                new Players() { Id = 281, PlayerName = "Tudor Vasilescu", Position = Position.Midfielder, BirthDate = new DateTime(2006, 10, 16), Player_TeamsId = 15 },
                new Players() { Id = 282, PlayerName = "Eduard Popescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2007, 12, 6), Player_TeamsId = 15 },
                new Players() { Id = 283, PlayerName = "Daniel Cojocaru", Position = Position.Atacker, BirthDate = new DateTime(2008, 7, 22), Player_TeamsId = 15 },
                new Players() { Id = 284, PlayerName = "Alex Georgescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2007, 6, 26), Player_TeamsId = 15 },
                new Players() { Id = 285, PlayerName = "Gabriel Lazar", Position = Position.Goalkeeper, BirthDate = new DateTime(2005, 10, 16), Player_TeamsId = 15 },
                new Players() { Id = 286, PlayerName = "Stefan Neagu", Position = Position.Atacker, BirthDate = new DateTime(2007, 1, 1), Player_TeamsId = 15 },
                new Players() { Id = 287, PlayerName = "Gabriel Ionescu", Position = Position.Atacker, BirthDate = new DateTime(2008, 12, 20), Player_TeamsId = 15 },
                new Players() { Id = 288, PlayerName = "Ionut Neagu", Position = Position.Defender, BirthDate = new DateTime(2006, 10, 18), Player_TeamsId = 15 },
                new Players() { Id = 289, PlayerName = "Alex Voicu", Position = Position.Atacker, BirthDate = new DateTime(2004, 2, 23), Player_TeamsId = 15 },
                new Players() { Id = 290, PlayerName = "Vlad Voicu", Position = Position.Midfielder, BirthDate = new DateTime(2005, 8, 18), Player_TeamsId = 15 },
                new Players() { Id = 291, PlayerName = "Adrian Barbu", Position = Position.Midfielder, BirthDate = new DateTime(2008, 1, 15), Player_TeamsId = 15 },
                new Players() { Id = 292, PlayerName = "Stefan Diaconu", Position = Position.Midfielder, BirthDate = new DateTime(2005, 5, 15), Player_TeamsId = 15 },
                new Players() { Id = 293, PlayerName = "Robert Matei", Position = Position.Defender, BirthDate = new DateTime(2007, 7, 25), Player_TeamsId = 15 },
                new Players() { Id = 294, PlayerName = "Alin Voicu", Position = Position.Goalkeeper, BirthDate = new DateTime(2008, 9, 7), Player_TeamsId = 15 },
                new Players() { Id = 295, PlayerName = "Stefan Diaconu", Position = Position.Atacker, BirthDate = new DateTime(2006, 9, 21), Player_TeamsId = 15 },
                new Players() { Id = 296, PlayerName = "Radu Ilie", Position = Position.Defender, BirthDate = new DateTime(2007, 12, 18), Player_TeamsId = 15 },
                new Players() { Id = 297, PlayerName = "Alex Marin", Position = Position.Defender, BirthDate = new DateTime(2005, 1, 26), Player_TeamsId = 15 },
                new Players() { Id = 298, PlayerName = "Denis Marin", Position = Position.Defender, BirthDate = new DateTime(2008, 7, 6), Player_TeamsId = 15 },
                new Players() { Id = 299, PlayerName = "Alex Cojocaru", Position = Position.Defender, BirthDate = new DateTime(2006, 7, 13), Player_TeamsId = 15 },
                new Players() { Id = 300, PlayerName = "Eduard Ilie", Position = Position.Atacker, BirthDate = new DateTime(2005, 7, 10), Player_TeamsId = 15 },
                new Players() { Id = 301, PlayerName = "Andrei Dumitrescu", Position = Position.Midfielder, BirthDate = new DateTime(2006, 8, 13), Player_TeamsId = 16 },
                new Players() { Id = 302, PlayerName = "Vlad Lazar", Position = Position.Goalkeeper, BirthDate = new DateTime(2004, 11, 17), Player_TeamsId = 16 },
                new Players() { Id = 303, PlayerName = "Florin Diaconu", Position = Position.Goalkeeper, BirthDate = new DateTime(2008, 2, 16), Player_TeamsId = 16 },
                new Players() { Id = 304, PlayerName = "Eduard Neagu", Position = Position.Goalkeeper, BirthDate = new DateTime(2007, 9, 21), Player_TeamsId = 16 },
                new Players() { Id = 305, PlayerName = "Sergiu Radulescu", Position = Position.Midfielder, BirthDate = new DateTime(2005, 5, 2), Player_TeamsId = 16 },
                new Players() { Id = 306, PlayerName = "Tudor Voicu", Position = Position.Midfielder, BirthDate = new DateTime(2005, 3, 26), Player_TeamsId = 16 },
                new Players() { Id = 307, PlayerName = "George Marin", Position = Position.Atacker, BirthDate = new DateTime(2008, 7, 9), Player_TeamsId = 16 },
                new Players() { Id = 308, PlayerName = "Paul Radulescu", Position = Position.Atacker, BirthDate = new DateTime(2007, 7, 22), Player_TeamsId = 16 },
                new Players() { Id = 309, PlayerName = "Daniel Diaconu", Position = Position.Atacker, BirthDate = new DateTime(2007, 11, 27), Player_TeamsId = 16 },
                new Players() { Id = 310, PlayerName = "Sergiu Ionescu", Position = Position.Midfielder, BirthDate = new DateTime(2004, 7, 8), Player_TeamsId = 16 },
                new Players() { Id = 311, PlayerName = "Gabriel Vasilescu", Position = Position.Atacker, BirthDate = new DateTime(2007, 1, 23), Player_TeamsId = 16 },
                new Players() { Id = 312, PlayerName = "Ionut Popescu", Position = Position.Atacker, BirthDate = new DateTime(2004, 3, 13), Player_TeamsId = 16 },
                new Players() { Id = 313, PlayerName = "Paul Toma", Position = Position.Atacker, BirthDate = new DateTime(2005, 4, 5), Player_TeamsId = 16 },
                new Players() { Id = 314, PlayerName = "Tudor Enache", Position = Position.Atacker, BirthDate = new DateTime(2006, 4, 26), Player_TeamsId = 16 },
                new Players() { Id = 315, PlayerName = "Sergiu Petrescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2006, 2, 21), Player_TeamsId = 16 },
                new Players() { Id = 316, PlayerName = "Alex Popescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2004, 2, 11), Player_TeamsId = 16 },
                new Players() { Id = 317, PlayerName = "Andrei Petrescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2006, 8, 9), Player_TeamsId = 16 },
                new Players() { Id = 318, PlayerName = "Cristian Radulescu", Position = Position.Defender, BirthDate = new DateTime(2006, 5, 21), Player_TeamsId = 16 },
                new Players() { Id = 319, PlayerName = "Vlad Stan", Position = Position.Midfielder, BirthDate = new DateTime(2005, 7, 2), Player_TeamsId = 16 },
                new Players() { Id = 320, PlayerName = "Alin Enache", Position = Position.Defender, BirthDate = new DateTime(2008, 9, 4), Player_TeamsId = 16 },
                new Players() { Id = 321, PlayerName = "Denis Vasilescu", Position = Position.Midfielder, BirthDate = new DateTime(2004, 11, 19), Player_TeamsId = 17 },
                new Players() { Id = 322, PlayerName = "George Dumitrescu", Position = Position.Defender, BirthDate = new DateTime(2004, 8, 1), Player_TeamsId = 17 },
                new Players() { Id = 323, PlayerName = "Andrei Barbu", Position = Position.Goalkeeper, BirthDate = new DateTime(2008, 11, 24), Player_TeamsId = 17 },
                new Players() { Id = 324, PlayerName = "Florin Vasilescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2008, 11, 20), Player_TeamsId = 17 },
                new Players() { Id = 325, PlayerName = "Alin Ilie", Position = Position.Midfielder, BirthDate = new DateTime(2007, 9, 2), Player_TeamsId = 17 },
                new Players() { Id = 326, PlayerName = "Eduard Neagu", Position = Position.Midfielder, BirthDate = new DateTime(2005, 4, 5), Player_TeamsId = 17 },
                new Players() { Id = 327, PlayerName = "Eduard Georgescu", Position = Position.Atacker, BirthDate = new DateTime(2007, 8, 9), Player_TeamsId = 17 },
                new Players() { Id = 328, PlayerName = "Sergiu Voicu", Position = Position.Goalkeeper, BirthDate = new DateTime(2004, 5, 18), Player_TeamsId = 17 },
                new Players() { Id = 329, PlayerName = "Alex Cojocaru", Position = Position.Midfielder, BirthDate = new DateTime(2004, 5, 23), Player_TeamsId = 17 },
                new Players() { Id = 330, PlayerName = "Adrian Vasilescu", Position = Position.Defender, BirthDate = new DateTime(2008, 11, 2), Player_TeamsId = 17 },
                new Players() { Id = 331, PlayerName = "Daniel Matei", Position = Position.Defender, BirthDate = new DateTime(2007, 12, 11), Player_TeamsId = 17 },
                new Players() { Id = 332, PlayerName = "George Popescu", Position = Position.Defender, BirthDate = new DateTime(2004, 2, 28), Player_TeamsId = 17 },
                new Players() { Id = 333, PlayerName = "Alex Voicu", Position = Position.Defender, BirthDate = new DateTime(2007, 8, 27), Player_TeamsId = 17 },
                new Players() { Id = 334, PlayerName = "Cristian Diaconu", Position = Position.Defender, BirthDate = new DateTime(2005, 3, 26), Player_TeamsId = 17 },
                new Players() { Id = 335, PlayerName = "Sergiu Georgescu", Position = Position.Atacker, BirthDate = new DateTime(2007, 5, 13), Player_TeamsId = 17 },
                new Players() { Id = 336, PlayerName = "Robert Barbu", Position = Position.Midfielder, BirthDate = new DateTime(2008, 12, 1), Player_TeamsId = 17 },
                new Players() { Id = 337, PlayerName = "Mihai Enache", Position = Position.Midfielder, BirthDate = new DateTime(2007, 3, 17), Player_TeamsId = 17 },
                new Players() { Id = 338, PlayerName = "Gabriel Marin", Position = Position.Midfielder, BirthDate = new DateTime(2008, 4, 15), Player_TeamsId = 17 },
                new Players() { Id = 339, PlayerName = "Denis Cojocaru", Position = Position.Midfielder, BirthDate = new DateTime(2005, 2, 20), Player_TeamsId = 17 },
                new Players() { Id = 340, PlayerName = "Florin Lazar", Position = Position.Midfielder, BirthDate = new DateTime(2007, 1, 8), Player_TeamsId = 17 },
                new Players() { Id = 341, PlayerName = "Adrian Marin", Position = Position.Atacker, BirthDate = new DateTime(2006, 9, 25), Player_TeamsId = 18 },
                new Players() { Id = 342, PlayerName = "Stefan Ionescu", Position = Position.Atacker, BirthDate = new DateTime(2004, 9, 17), Player_TeamsId = 18 },
                new Players() { Id = 343, PlayerName = "Alex Voicu", Position = Position.Goalkeeper, BirthDate = new DateTime(2008, 9, 11), Player_TeamsId = 18 },
                new Players() { Id = 344, PlayerName = "Adrian Chiriac", Position = Position.Defender, BirthDate = new DateTime(2004, 3, 24), Player_TeamsId = 18 },
                new Players() { Id = 345, PlayerName = "Tudor Toma", Position = Position.Atacker, BirthDate = new DateTime(2006, 4, 27), Player_TeamsId = 18 },
                new Players() { Id = 346, PlayerName = "Gabriel Matei", Position = Position.Midfielder, BirthDate = new DateTime(2008, 6, 11), Player_TeamsId = 18 },
                new Players() { Id = 347, PlayerName = "Adrian Marin", Position = Position.Midfielder, BirthDate = new DateTime(2006, 1, 27), Player_TeamsId = 18 },
                new Players() { Id = 348, PlayerName = "Andrei Enache", Position = Position.Goalkeeper, BirthDate = new DateTime(2006, 3, 5), Player_TeamsId = 18 },
                new Players() { Id = 349, PlayerName = "Daniel Barbu", Position = Position.Defender, BirthDate = new DateTime(2004, 1, 9), Player_TeamsId = 18 },
                new Players() { Id = 350, PlayerName = "Daniel Diaconu", Position = Position.Defender, BirthDate = new DateTime(2004, 8, 11), Player_TeamsId = 18 },
                new Players() { Id = 351, PlayerName = "Radu Enache", Position = Position.Midfielder, BirthDate = new DateTime(2005, 10, 13), Player_TeamsId = 18 },
                new Players() { Id = 352, PlayerName = "Tudor Radulescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2004, 2, 10), Player_TeamsId = 18 },
                new Players() { Id = 353, PlayerName = "Gabriel Matei", Position = Position.Atacker, BirthDate = new DateTime(2006, 8, 25), Player_TeamsId = 18 },
                new Players() { Id = 354, PlayerName = "Stefan Petrescu", Position = Position.Midfielder, BirthDate = new DateTime(2005, 11, 21), Player_TeamsId = 18 },
                new Players() { Id = 355, PlayerName = "Sergiu Neagu", Position = Position.Defender, BirthDate = new DateTime(2005, 9, 18), Player_TeamsId = 18 },
                new Players() { Id = 356, PlayerName = "Eduard Matei", Position = Position.Atacker, BirthDate = new DateTime(2006, 12, 17), Player_TeamsId = 18 },
                new Players() { Id = 357, PlayerName = "Eduard Matei", Position = Position.Goalkeeper, BirthDate = new DateTime(2008, 2, 15), Player_TeamsId = 18 },
                new Players() { Id = 358, PlayerName = "Robert Vasilescu", Position = Position.Midfielder, BirthDate = new DateTime(2008, 4, 25), Player_TeamsId = 18 },
                new Players() { Id = 359, PlayerName = "Tudor Radulescu", Position = Position.Midfielder, BirthDate = new DateTime(2007, 7, 19), Player_TeamsId = 18 },
                new Players() { Id = 360, PlayerName = "Paul Popescu", Position = Position.Midfielder, BirthDate = new DateTime(2008, 11, 11), Player_TeamsId = 18 },
                new Players() { Id = 361, PlayerName = "Mihai Neagu", Position = Position.Defender, BirthDate = new DateTime(2007, 8, 17), Player_TeamsId = 19 },
                new Players() { Id = 362, PlayerName = "Vlad Marin", Position = Position.Defender, BirthDate = new DateTime(2007, 12, 9), Player_TeamsId = 19 },
                new Players() { Id = 363, PlayerName = "Stefan Vasilescu", Position = Position.Defender, BirthDate = new DateTime(2007, 8, 13), Player_TeamsId = 19 },
                new Players() { Id = 364, PlayerName = "Cristian Ionescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2005, 4, 19), Player_TeamsId = 19 },
                new Players() { Id = 365, PlayerName = "Cristian Cojocaru", Position = Position.Defender, BirthDate = new DateTime(2004, 3, 8), Player_TeamsId = 19 },
                new Players() { Id = 366, PlayerName = "Denis Dumitrescu", Position = Position.Midfielder, BirthDate = new DateTime(2006, 10, 11), Player_TeamsId = 19 },
                new Players() { Id = 367, PlayerName = "Sergiu Dumitrescu", Position = Position.Defender, BirthDate = new DateTime(2008, 11, 7), Player_TeamsId = 19 },
                new Players() { Id = 368, PlayerName = "Robert Ilie", Position = Position.Midfielder, BirthDate = new DateTime(2007, 2, 27), Player_TeamsId = 19 },
                new Players() { Id = 369, PlayerName = "Paul Lazar", Position = Position.Atacker, BirthDate = new DateTime(2004, 11, 3), Player_TeamsId = 19 },
                new Players() { Id = 370, PlayerName = "Daniel Petrescu", Position = Position.Atacker, BirthDate = new DateTime(2005, 2, 22), Player_TeamsId = 19 },
                new Players() { Id = 371, PlayerName = "Sergiu Vasilescu", Position = Position.Defender, BirthDate = new DateTime(2004, 2, 3), Player_TeamsId = 19 },
                new Players() { Id = 372, PlayerName = "Gabriel Ionescu", Position = Position.Atacker, BirthDate = new DateTime(2004, 10, 11), Player_TeamsId = 19 },
                new Players() { Id = 373, PlayerName = "Ionut Ilie", Position = Position.Midfielder, BirthDate = new DateTime(2005, 8, 4), Player_TeamsId = 19 },
                new Players() { Id = 374, PlayerName = "Tudor Toma", Position = Position.Midfielder, BirthDate = new DateTime(2006, 12, 18), Player_TeamsId = 19 },
                new Players() { Id = 375, PlayerName = "Stefan Stan", Position = Position.Atacker, BirthDate = new DateTime(2008, 11, 12), Player_TeamsId = 19 },
                new Players() { Id = 376, PlayerName = "Mihai Ilie", Position = Position.Defender, BirthDate = new DateTime(2007, 6, 23), Player_TeamsId = 19 },
                new Players() { Id = 377, PlayerName = "Mihai Marin", Position = Position.Midfielder, BirthDate = new DateTime(2007, 2, 9), Player_TeamsId = 19 },
                new Players() { Id = 378, PlayerName = "Gabriel Radulescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2007, 1, 6), Player_TeamsId = 19 },
                new Players() { Id = 379, PlayerName = "Alex Vasilescu", Position = Position.Defender, BirthDate = new DateTime(2007, 11, 6), Player_TeamsId = 19 },
                new Players() { Id = 380, PlayerName = "Ionut Ionescu", Position = Position.Midfielder, BirthDate = new DateTime(2007, 7, 7), Player_TeamsId = 19 },
                new Players() { Id = 381, PlayerName = "Ionut Dumitrescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2005, 9, 11), Player_TeamsId = 20 },
                new Players() { Id = 382, PlayerName = "Alin Chiriac", Position = Position.Atacker, BirthDate = new DateTime(2008, 12, 9), Player_TeamsId = 20 },
                new Players() { Id = 383, PlayerName = "Robert Voicu", Position = Position.Atacker, BirthDate = new DateTime(2005, 4, 17), Player_TeamsId = 20 },
                new Players() { Id = 384, PlayerName = "Mihai Popescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2004, 10, 28), Player_TeamsId = 20 },
                new Players() { Id = 385, PlayerName = "Stefan Radulescu", Position = Position.Atacker, BirthDate = new DateTime(2004, 12, 18), Player_TeamsId = 20 },
                new Players() { Id = 386, PlayerName = "Alin Voicu", Position = Position.Atacker, BirthDate = new DateTime(2006, 4, 21), Player_TeamsId = 20 },
                new Players() { Id = 387, PlayerName = "Mihai Georgescu", Position = Position.Midfielder, BirthDate = new DateTime(2008, 7, 20), Player_TeamsId = 20 },
                new Players() { Id = 388, PlayerName = "Radu Toma", Position = Position.Midfielder, BirthDate = new DateTime(2007, 12, 24), Player_TeamsId = 20 },
                new Players() { Id = 389, PlayerName = "Sergiu Diaconu", Position = Position.Defender, BirthDate = new DateTime(2005, 9, 2), Player_TeamsId = 20 },
                new Players() { Id = 390, PlayerName = "Adrian Dumitrescu", Position = Position.Midfielder, BirthDate = new DateTime(2006, 6, 14), Player_TeamsId = 20 },
                new Players() { Id = 391, PlayerName = "Stefan Georgescu", Position = Position.Midfielder, BirthDate = new DateTime(2007, 1, 3), Player_TeamsId = 20 },
                new Players() { Id = 392, PlayerName = "Andrei Barbu", Position = Position.Midfielder, BirthDate = new DateTime(2007, 11, 7), Player_TeamsId = 20 },
                new Players() { Id = 393, PlayerName = "Tudor Georgescu", Position = Position.Midfielder, BirthDate = new DateTime(2006, 7, 9), Player_TeamsId = 20 },
                new Players() { Id = 394, PlayerName = "Daniel Popescu", Position = Position.Defender, BirthDate = new DateTime(2004, 7, 2), Player_TeamsId = 20 },
                new Players() { Id = 395, PlayerName = "Florin Lazar", Position = Position.Goalkeeper, BirthDate = new DateTime(2008, 12, 9), Player_TeamsId = 20 },
                new Players() { Id = 396, PlayerName = "Paul Cojocaru", Position = Position.Atacker, BirthDate = new DateTime(2006, 11, 4), Player_TeamsId = 20 },
                new Players() { Id = 397, PlayerName = "Vlad Georgescu", Position = Position.Midfielder, BirthDate = new DateTime(2005, 4, 7), Player_TeamsId = 20 },
                new Players() { Id = 398, PlayerName = "Andrei Cojocaru", Position = Position.Defender, BirthDate = new DateTime(2004, 4, 2), Player_TeamsId = 20 },
                new Players() { Id = 399, PlayerName = "Radu Enache", Position = Position.Goalkeeper, BirthDate = new DateTime(2007, 3, 17), Player_TeamsId = 20 },
                new Players() { Id = 400, PlayerName = "George Ionescu", Position = Position.Atacker, BirthDate = new DateTime(2008, 10, 9), Player_TeamsId = 20 },
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //kids
                new Players() { Id = 401, PlayerName = "Paul Radulescu", Position = Position.Atacker, BirthDate = new DateTime(2011, 10, 11), Player_TeamsId = 21 },
                new Players() { Id = 402, PlayerName = "Cristian Matei", Position = Position.Defender, BirthDate = new DateTime(2011, 3, 15), Player_TeamsId = 21 },
                new Players() { Id = 403, PlayerName = "Vlad Ilie", Position = Position.Defender, BirthDate = new DateTime(2012, 12, 27), Player_TeamsId = 21 },
                new Players() { Id = 404, PlayerName = "Alin Vasilescu", Position = Position.Midfielder, BirthDate = new DateTime(2012, 9, 16), Player_TeamsId = 21 },
                new Players() { Id = 405, PlayerName = "Andrei Ionescu", Position = Position.Midfielder, BirthDate = new DateTime(2009, 9, 22), Player_TeamsId = 21 },
                new Players() { Id = 406, PlayerName = "Ionut Neagu", Position = Position.Defender, BirthDate = new DateTime(2009, 8, 2), Player_TeamsId = 21 },
                new Players() { Id = 407, PlayerName = "Vlad Ionescu", Position = Position.Midfielder, BirthDate = new DateTime(2011, 7, 4), Player_TeamsId = 21 },
                new Players() { Id = 408, PlayerName = "Gabriel Ionescu", Position = Position.Defender, BirthDate = new DateTime(2011, 8, 10), Player_TeamsId = 21 },
                new Players() { Id = 409, PlayerName = "Adrian Cojocaru", Position = Position.Goalkeeper, BirthDate = new DateTime(2012, 8, 19), Player_TeamsId = 21 },
                new Players() { Id = 410, PlayerName = "Sergiu Enache", Position = Position.Midfielder, BirthDate = new DateTime(2011, 4, 14), Player_TeamsId = 21 },
                new Players() { Id = 411, PlayerName = "Paul Vasilescu", Position = Position.Defender, BirthDate = new DateTime(2011, 10, 6), Player_TeamsId = 21 },
                new Players() { Id = 412, PlayerName = "Alex Vasilescu", Position = Position.Midfielder, BirthDate = new DateTime(2010, 2, 8), Player_TeamsId = 21 },
                new Players() { Id = 413, PlayerName = "Alin Ionescu", Position = Position.Atacker, BirthDate = new DateTime(2009, 4, 6), Player_TeamsId = 21 },
                new Players() { Id = 414, PlayerName = "Adrian Toma", Position = Position.Midfielder, BirthDate = new DateTime(2009, 11, 24), Player_TeamsId = 21 },
                new Players() { Id = 415, PlayerName = "Alin Neagu", Position = Position.Goalkeeper, BirthDate = new DateTime(2010, 5, 18), Player_TeamsId = 21 },
                new Players() { Id = 416, PlayerName = "Vlad Neagu", Position = Position.Midfielder, BirthDate = new DateTime(2011, 12, 22), Player_TeamsId = 21 },
                new Players() { Id = 417, PlayerName = "George Neagu", Position = Position.Atacker, BirthDate = new DateTime(2010, 4, 12), Player_TeamsId = 21 },
                new Players() { Id = 418, PlayerName = "Cristian Chiriac", Position = Position.Goalkeeper, BirthDate = new DateTime(2010, 4, 15), Player_TeamsId = 21 },
                new Players() { Id = 419, PlayerName = "Ionut Ilie", Position = Position.Midfielder, BirthDate = new DateTime(2010, 12, 20), Player_TeamsId = 21 },
                new Players() { Id = 420, PlayerName = "Ionut Diaconu", Position = Position.Atacker, BirthDate = new DateTime(2009, 1, 18), Player_TeamsId = 21 },
                new Players() { Id = 421, PlayerName = "Florin Marin", Position = Position.Atacker, BirthDate = new DateTime(2009, 2, 19), Player_TeamsId = 22 },
                new Players() { Id = 422, PlayerName = "Tudor Dumitrescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2012, 6, 1), Player_TeamsId = 22 },
                new Players() { Id = 423, PlayerName = "Radu Marin", Position = Position.Atacker, BirthDate = new DateTime(2012, 12, 14), Player_TeamsId = 22 },
                new Players() { Id = 424, PlayerName = "Alex Radulescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2011, 11, 27), Player_TeamsId = 22 },
                new Players() { Id = 425, PlayerName = "Gabriel Toma", Position = Position.Goalkeeper, BirthDate = new DateTime(2010, 6, 23), Player_TeamsId = 22 },
                new Players() { Id = 426, PlayerName = "Denis Ilie", Position = Position.Atacker, BirthDate = new DateTime(2012, 4, 12), Player_TeamsId = 22 },
                new Players() { Id = 427, PlayerName = "Florin Neagu", Position = Position.Defender, BirthDate = new DateTime(2010, 1, 22), Player_TeamsId = 22 },
                new Players() { Id = 428, PlayerName = "Adrian Voicu", Position = Position.Defender, BirthDate = new DateTime(2012, 8, 2), Player_TeamsId = 22 },
                new Players() { Id = 429, PlayerName = "George Toma", Position = Position.Defender, BirthDate = new DateTime(2009, 10, 2), Player_TeamsId = 22 },
                new Players() { Id = 430, PlayerName = "Vlad Vasilescu", Position = Position.Defender, BirthDate = new DateTime(2012, 1, 15), Player_TeamsId = 22 },
                new Players() { Id = 431, PlayerName = "Alin Barbu", Position = Position.Atacker, BirthDate = new DateTime(2011, 8, 14), Player_TeamsId = 22 },
                new Players() { Id = 432, PlayerName = "Sergiu Chiriac", Position = Position.Atacker, BirthDate = new DateTime(2010, 11, 24), Player_TeamsId = 22 },
                new Players() { Id = 433, PlayerName = "Cristian Lazar", Position = Position.Midfielder, BirthDate = new DateTime(2011, 9, 26), Player_TeamsId = 22 },
                new Players() { Id = 434, PlayerName = "Daniel Marin", Position = Position.Goalkeeper, BirthDate = new DateTime(2011, 2, 16), Player_TeamsId = 22 },
                new Players() { Id = 435, PlayerName = "Robert Neagu", Position = Position.Defender, BirthDate = new DateTime(2011, 1, 13), Player_TeamsId = 22 },
                new Players() { Id = 436, PlayerName = "Radu Lazar", Position = Position.Midfielder, BirthDate = new DateTime(2009, 11, 26), Player_TeamsId = 22 },
                new Players() { Id = 437, PlayerName = "Alex Vasilescu", Position = Position.Defender, BirthDate = new DateTime(2009, 5, 1), Player_TeamsId = 22 },
                new Players() { Id = 438, PlayerName = "Tudor Lazar", Position = Position.Midfielder, BirthDate = new DateTime(2010, 8, 11), Player_TeamsId = 22 },
                new Players() { Id = 439, PlayerName = "Alex Dumitrescu", Position = Position.Midfielder, BirthDate = new DateTime(2012, 7, 24), Player_TeamsId = 22 },
                new Players() { Id = 440, PlayerName = "Andrei Petrescu", Position = Position.Defender, BirthDate = new DateTime(2012, 4, 21), Player_TeamsId = 22 },
                new Players() { Id = 441, PlayerName = "Cristian Neagu", Position = Position.Atacker, BirthDate = new DateTime(2010, 2, 20), Player_TeamsId = 23 },
                new Players() { Id = 442, PlayerName = "Florin Barbu", Position = Position.Defender, BirthDate = new DateTime(2010, 7, 19), Player_TeamsId = 23 },
                new Players() { Id = 443, PlayerName = "Gabriel Barbu", Position = Position.Midfielder, BirthDate = new DateTime(2012, 8, 22), Player_TeamsId = 23 },
                new Players() { Id = 444, PlayerName = "Robert Voicu", Position = Position.Goalkeeper, BirthDate = new DateTime(2009, 12, 13), Player_TeamsId = 23 },
                new Players() { Id = 445, PlayerName = "Andrei Popescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2011, 11, 2), Player_TeamsId = 23 },
                new Players() { Id = 446, PlayerName = "Stefan Lazar", Position = Position.Defender, BirthDate = new DateTime(2011, 5, 15), Player_TeamsId = 23 },
                new Players() { Id = 447, PlayerName = "Andrei Marin", Position = Position.Atacker, BirthDate = new DateTime(2011, 7, 27), Player_TeamsId = 23 },
                new Players() { Id = 448, PlayerName = "Mihai Matei", Position = Position.Midfielder, BirthDate = new DateTime(2010, 1, 24), Player_TeamsId = 23 },
                new Players() { Id = 449, PlayerName = "Stefan Neagu", Position = Position.Atacker, BirthDate = new DateTime(2011, 5, 8), Player_TeamsId = 23 },
                new Players() { Id = 450, PlayerName = "Ionut Dumitrescu", Position = Position.Midfielder, BirthDate = new DateTime(2011, 9, 18), Player_TeamsId = 23 },
                new Players() { Id = 451, PlayerName = "Gabriel Popescu", Position = Position.Atacker, BirthDate = new DateTime(2009, 12, 2), Player_TeamsId = 23 },
                new Players() { Id = 452, PlayerName = "Alin Popescu", Position = Position.Atacker, BirthDate = new DateTime(2009, 10, 17), Player_TeamsId = 23 },
                new Players() { Id = 453, PlayerName = "Daniel Popescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2009, 6, 11), Player_TeamsId = 23 },
                new Players() { Id = 454, PlayerName = "Eduard Popescu", Position = Position.Defender, BirthDate = new DateTime(2010, 3, 15), Player_TeamsId = 23 },
                new Players() { Id = 455, PlayerName = "Robert Voicu", Position = Position.Atacker, BirthDate = new DateTime(2011, 5, 18), Player_TeamsId = 23 },
                new Players() { Id = 456, PlayerName = "Mihai Dumitrescu", Position = Position.Midfielder, BirthDate = new DateTime(2009, 3, 5), Player_TeamsId = 23 },
                new Players() { Id = 457, PlayerName = "Cristian Lazar", Position = Position.Defender, BirthDate = new DateTime(2012, 11, 4), Player_TeamsId = 23 },
                new Players() { Id = 458, PlayerName = "Sergiu Neagu", Position = Position.Goalkeeper, BirthDate = new DateTime(2012, 3, 25), Player_TeamsId = 23 },
                new Players() { Id = 459, PlayerName = "Tudor Marin", Position = Position.Atacker, BirthDate = new DateTime(2009, 5, 10), Player_TeamsId = 23 },
                new Players() { Id = 460, PlayerName = "Alin Voicu", Position = Position.Defender, BirthDate = new DateTime(2012, 12, 16), Player_TeamsId = 23 },
                new Players() { Id = 461, PlayerName = "Daniel Georgescu", Position = Position.Defender, BirthDate = new DateTime(2012, 1, 17), Player_TeamsId = 24 },
                new Players() { Id = 462, PlayerName = "Eduard Cojocaru", Position = Position.Atacker, BirthDate = new DateTime(2011, 1, 7), Player_TeamsId = 24 },
                new Players() { Id = 463, PlayerName = "Mihai Voicu", Position = Position.Defender, BirthDate = new DateTime(2009, 12, 6), Player_TeamsId = 24 },
                new Players() { Id = 464, PlayerName = "Vlad Neagu", Position = Position.Midfielder, BirthDate = new DateTime(2011, 11, 28), Player_TeamsId = 24 },
                new Players() { Id = 465, PlayerName = "Cristian Voicu", Position = Position.Goalkeeper, BirthDate = new DateTime(2009, 2, 14), Player_TeamsId = 24 },
                new Players() { Id = 466, PlayerName = "Alin Ionescu", Position = Position.Atacker, BirthDate = new DateTime(2011, 1, 1), Player_TeamsId = 24 },
                new Players() { Id = 467, PlayerName = "Gabriel Radulescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2010, 11, 19), Player_TeamsId = 24 },
                new Players() { Id = 468, PlayerName = "Florin Ilie", Position = Position.Atacker, BirthDate = new DateTime(2009, 11, 4), Player_TeamsId = 24 },
                new Players() { Id = 469, PlayerName = "Alex Georgescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2011, 7, 7), Player_TeamsId = 24 },
                new Players() { Id = 470, PlayerName = "Tudor Georgescu", Position = Position.Atacker, BirthDate = new DateTime(2011, 10, 9), Player_TeamsId = 24 },
                new Players() { Id = 471, PlayerName = "Sergiu Lazar", Position = Position.Atacker, BirthDate = new DateTime(2010, 8, 15), Player_TeamsId = 24 },
                new Players() { Id = 472, PlayerName = "Tudor Enache", Position = Position.Defender, BirthDate = new DateTime(2010, 1, 24), Player_TeamsId = 24 },
                new Players() { Id = 473, PlayerName = "Mihai Radulescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2010, 8, 13), Player_TeamsId = 24 },
                new Players() { Id = 474, PlayerName = "Daniel Petrescu", Position = Position.Atacker, BirthDate = new DateTime(2012, 8, 1), Player_TeamsId = 24 },
                new Players() { Id = 475, PlayerName = "Stefan Neagu", Position = Position.Atacker, BirthDate = new DateTime(2011, 4, 3), Player_TeamsId = 24 },
                new Players() { Id = 476, PlayerName = "Alex Popescu", Position = Position.Midfielder, BirthDate = new DateTime(2010, 9, 12), Player_TeamsId = 24 },
                new Players() { Id = 477, PlayerName = "Robert Ilie", Position = Position.Atacker, BirthDate = new DateTime(2009, 3, 7), Player_TeamsId = 24 },
                new Players() { Id = 478, PlayerName = "Tudor Diaconu", Position = Position.Midfielder, BirthDate = new DateTime(2009, 7, 23), Player_TeamsId = 24 },
                new Players() { Id = 479, PlayerName = "Florin Marin", Position = Position.Midfielder, BirthDate = new DateTime(2010, 7, 14), Player_TeamsId = 24 },
                new Players() { Id = 480, PlayerName = "Stefan Georgescu", Position = Position.Midfielder, BirthDate = new DateTime(2012, 5, 21), Player_TeamsId = 24 },
                new Players() { Id = 481, PlayerName = "Ionut Radulescu", Position = Position.Atacker, BirthDate = new DateTime(2010, 5, 27), Player_TeamsId = 25 },
                new Players() { Id = 482, PlayerName = "Tudor Neagu", Position = Position.Midfielder, BirthDate = new DateTime(2009, 2, 14), Player_TeamsId = 25 },
                new Players() { Id = 483, PlayerName = "Tudor Barbu", Position = Position.Defender, BirthDate = new DateTime(2011, 11, 20), Player_TeamsId = 25 },
                new Players() { Id = 484, PlayerName = "Robert Diaconu", Position = Position.Defender, BirthDate = new DateTime(2009, 3, 3), Player_TeamsId = 25 },
                new Players() { Id = 485, PlayerName = "Florin Petrescu", Position = Position.Atacker, BirthDate = new DateTime(2009, 1, 4), Player_TeamsId = 25 },
                new Players() { Id = 486, PlayerName = "Ionut Ilie", Position = Position.Goalkeeper, BirthDate = new DateTime(2009, 7, 6), Player_TeamsId = 25 },
                new Players() { Id = 487, PlayerName = "Florin Enache", Position = Position.Defender, BirthDate = new DateTime(2010, 12, 5), Player_TeamsId = 25 },
                new Players() { Id = 488, PlayerName = "Adrian Ionescu", Position = Position.Atacker, BirthDate = new DateTime(2011, 9, 12), Player_TeamsId = 25 },
                new Players() { Id = 489, PlayerName = "Ionut Georgescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2012, 10, 13), Player_TeamsId = 25 },
                new Players() { Id = 490, PlayerName = "Daniel Barbu", Position = Position.Midfielder, BirthDate = new DateTime(2009, 11, 27), Player_TeamsId = 25 },
                new Players() { Id = 491, PlayerName = "Alex Ionescu", Position = Position.Atacker, BirthDate = new DateTime(2011, 9, 20), Player_TeamsId = 25 },
                new Players() { Id = 492, PlayerName = "Mihai Cojocaru", Position = Position.Goalkeeper, BirthDate = new DateTime(2012, 12, 6), Player_TeamsId = 25 },
                new Players() { Id = 493, PlayerName = "Florin Barbu", Position = Position.Defender, BirthDate = new DateTime(2009, 7, 3), Player_TeamsId = 25 },
                new Players() { Id = 494, PlayerName = "Paul Enache", Position = Position.Midfielder, BirthDate = new DateTime(2009, 11, 4), Player_TeamsId = 25 },
                new Players() { Id = 495, PlayerName = "Tudor Stan", Position = Position.Defender, BirthDate = new DateTime(2011, 8, 11), Player_TeamsId = 25 },
                new Players() { Id = 496, PlayerName = "George Lazar", Position = Position.Midfielder, BirthDate = new DateTime(2009, 5, 20), Player_TeamsId = 25 },
                new Players() { Id = 497, PlayerName = "George Ionescu", Position = Position.Midfielder, BirthDate = new DateTime(2011, 2, 12), Player_TeamsId = 25 },
                new Players() { Id = 498, PlayerName = "Eduard Marin", Position = Position.Atacker, BirthDate = new DateTime(2010, 10, 21), Player_TeamsId = 25 },
                new Players() { Id = 499, PlayerName = "Andrei Lazar", Position = Position.Defender, BirthDate = new DateTime(2009, 12, 8), Player_TeamsId = 25 },
                new Players() { Id = 500, PlayerName = "George Voicu", Position = Position.Midfielder, BirthDate = new DateTime(2011, 5, 21), Player_TeamsId = 25 },
                new Players() { Id = 501, PlayerName = "Alex Ionescu", Position = Position.Defender, BirthDate = new DateTime(2010, 3, 5), Player_TeamsId = 26 },
                new Players() { Id = 502, PlayerName = "Adrian Cojocaru", Position = Position.Goalkeeper, BirthDate = new DateTime(2011, 5, 8), Player_TeamsId = 26 },
                new Players() { Id = 503, PlayerName = "Cristian Toma", Position = Position.Goalkeeper, BirthDate = new DateTime(2010, 6, 17), Player_TeamsId = 26 },
                new Players() { Id = 504, PlayerName = "Daniel Enache", Position = Position.Midfielder, BirthDate = new DateTime(2009, 9, 3), Player_TeamsId = 26 },
                new Players() { Id = 505, PlayerName = "Daniel Popescu", Position = Position.Atacker, BirthDate = new DateTime(2012, 9, 20), Player_TeamsId = 26 },
                new Players() { Id = 506, PlayerName = "Florin Voicu", Position = Position.Midfielder, BirthDate = new DateTime(2011, 5, 8), Player_TeamsId = 26 },
                new Players() { Id = 507, PlayerName = "Paul Enache", Position = Position.Defender, BirthDate = new DateTime(2011, 12, 5), Player_TeamsId = 26 },
                new Players() { Id = 508, PlayerName = "Stefan Enache", Position = Position.Defender, BirthDate = new DateTime(2011, 2, 24), Player_TeamsId = 26 },
                new Players() { Id = 509, PlayerName = "Stefan Popescu", Position = Position.Midfielder, BirthDate = new DateTime(2009, 10, 21), Player_TeamsId = 26 },
                new Players() { Id = 510, PlayerName = "Tudor Petrescu", Position = Position.Defender, BirthDate = new DateTime(2012, 11, 25), Player_TeamsId = 26 },
                new Players() { Id = 511, PlayerName = "Stefan Georgescu", Position = Position.Atacker, BirthDate = new DateTime(2012, 4, 21), Player_TeamsId = 26 },
                new Players() { Id = 512, PlayerName = "Denis Neagu", Position = Position.Defender, BirthDate = new DateTime(2009, 4, 18), Player_TeamsId = 26 },
                new Players() { Id = 513, PlayerName = "Denis Stan", Position = Position.Midfielder, BirthDate = new DateTime(2012, 11, 6), Player_TeamsId = 26 },
                new Players() { Id = 514, PlayerName = "Ionut Ionescu", Position = Position.Midfielder, BirthDate = new DateTime(2011, 11, 27), Player_TeamsId = 26 },
                new Players() { Id = 515, PlayerName = "Eduard Toma", Position = Position.Midfielder, BirthDate = new DateTime(2011, 8, 21), Player_TeamsId = 26 },
                new Players() { Id = 516, PlayerName = "Ionut Neagu", Position = Position.Midfielder, BirthDate = new DateTime(2009, 1, 6), Player_TeamsId = 26 },
                new Players() { Id = 517, PlayerName = "Denis Cojocaru", Position = Position.Midfielder, BirthDate = new DateTime(2012, 6, 13), Player_TeamsId = 26 },
                new Players() { Id = 518, PlayerName = "Radu Lazar", Position = Position.Atacker, BirthDate = new DateTime(2012, 5, 13), Player_TeamsId = 26 },
                new Players() { Id = 519, PlayerName = "Stefan Petrescu", Position = Position.Midfielder, BirthDate = new DateTime(2009, 4, 14), Player_TeamsId = 26 },
                new Players() { Id = 520, PlayerName = "George Popescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2009, 2, 19), Player_TeamsId = 26 },
                new Players() { Id = 521, PlayerName = "Vlad Ionescu", Position = Position.Atacker, BirthDate = new DateTime(2010, 9, 7), Player_TeamsId = 27 },
                new Players() { Id = 522, PlayerName = "Alin Vasilescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2009, 1, 8), Player_TeamsId = 27 },
                new Players() { Id = 523, PlayerName = "Daniel Dumitrescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2011, 9, 28), Player_TeamsId = 27 },
                new Players() { Id = 524, PlayerName = "Gabriel Vasilescu", Position = Position.Atacker, BirthDate = new DateTime(2011, 5, 12), Player_TeamsId = 27 },
                new Players() { Id = 525, PlayerName = "Alex Georgescu", Position = Position.Midfielder, BirthDate = new DateTime(2011, 7, 15), Player_TeamsId = 27 },
                new Players() { Id = 526, PlayerName = "Radu Ilie", Position = Position.Defender, BirthDate = new DateTime(2012, 9, 20), Player_TeamsId = 27 },
                new Players() { Id = 527, PlayerName = "Mihai Dumitrescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2011, 2, 23), Player_TeamsId = 27 },
                new Players() { Id = 528, PlayerName = "Alin Neagu", Position = Position.Midfielder, BirthDate = new DateTime(2009, 9, 4), Player_TeamsId = 27 },
                new Players() { Id = 529, PlayerName = "Vlad Diaconu", Position = Position.Defender, BirthDate = new DateTime(2009, 4, 14), Player_TeamsId = 27 },
                new Players() { Id = 530, PlayerName = "Eduard Diaconu", Position = Position.Goalkeeper, BirthDate = new DateTime(2011, 6, 25), Player_TeamsId = 27 },
                new Players() { Id = 531, PlayerName = "Andrei Lazar", Position = Position.Atacker, BirthDate = new DateTime(2009, 6, 6), Player_TeamsId = 27 },
                new Players() { Id = 532, PlayerName = "Alex Neagu", Position = Position.Goalkeeper, BirthDate = new DateTime(2009, 3, 24), Player_TeamsId = 27 },
                new Players() { Id = 533, PlayerName = "Alex Lazar", Position = Position.Defender, BirthDate = new DateTime(2012, 11, 19), Player_TeamsId = 27 },
                new Players() { Id = 534, PlayerName = "Alex Petrescu", Position = Position.Atacker, BirthDate = new DateTime(2011, 10, 10), Player_TeamsId = 27 },
                new Players() { Id = 535, PlayerName = "Daniel Stan", Position = Position.Goalkeeper, BirthDate = new DateTime(2011, 7, 15), Player_TeamsId = 27 },
                new Players() { Id = 536, PlayerName = "Alin Cojocaru", Position = Position.Defender, BirthDate = new DateTime(2009, 8, 17), Player_TeamsId = 27 },
                new Players() { Id = 537, PlayerName = "Tudor Vasilescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2011, 10, 12), Player_TeamsId = 27 },
                new Players() { Id = 538, PlayerName = "Denis Ionescu", Position = Position.Midfielder, BirthDate = new DateTime(2009, 4, 7), Player_TeamsId = 27 },
                new Players() { Id = 539, PlayerName = "Andrei Enache", Position = Position.Atacker, BirthDate = new DateTime(2009, 5, 16), Player_TeamsId = 27 },
                new Players() { Id = 540, PlayerName = "Stefan Barbu", Position = Position.Midfielder, BirthDate = new DateTime(2011, 12, 27), Player_TeamsId = 27 },
                new Players() { Id = 541, PlayerName = "Ionut Matei", Position = Position.Goalkeeper, BirthDate = new DateTime(2009, 10, 6), Player_TeamsId = 28 },
                new Players() { Id = 542, PlayerName = "Vlad Dumitrescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2009, 11, 21), Player_TeamsId = 28 },
                new Players() { Id = 543, PlayerName = "Gabriel Chiriac", Position = Position.Goalkeeper, BirthDate = new DateTime(2009, 1, 23), Player_TeamsId = 28 },
                new Players() { Id = 544, PlayerName = "Florin Enache", Position = Position.Defender, BirthDate = new DateTime(2009, 8, 21), Player_TeamsId = 28 },
                new Players() { Id = 545, PlayerName = "Mihai Ilie", Position = Position.Goalkeeper, BirthDate = new DateTime(2012, 4, 22), Player_TeamsId = 28 },
                new Players() { Id = 546, PlayerName = "Cristian Vasilescu", Position = Position.Defender, BirthDate = new DateTime(2009, 2, 23), Player_TeamsId = 28 },
                new Players() { Id = 547, PlayerName = "Adrian Vasilescu", Position = Position.Atacker, BirthDate = new DateTime(2010, 4, 23), Player_TeamsId = 28 },
                new Players() { Id = 548, PlayerName = "Vlad Popescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2009, 8, 25), Player_TeamsId = 28 },
                new Players() { Id = 549, PlayerName = "Denis Matei", Position = Position.Defender, BirthDate = new DateTime(2010, 3, 17), Player_TeamsId = 28 },
                new Players() { Id = 550, PlayerName = "Daniel Petrescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2012, 1, 18), Player_TeamsId = 28 },
                new Players() { Id = 551, PlayerName = "Florin Enache", Position = Position.Defender, BirthDate = new DateTime(2011, 1, 22), Player_TeamsId = 28 },
                new Players() { Id = 552, PlayerName = "George Toma", Position = Position.Goalkeeper, BirthDate = new DateTime(2010, 7, 12), Player_TeamsId = 28 },
                new Players() { Id = 553, PlayerName = "Cristian Toma", Position = Position.Goalkeeper, BirthDate = new DateTime(2010, 11, 6), Player_TeamsId = 28 },
                new Players() { Id = 554, PlayerName = "Robert Radulescu", Position = Position.Defender, BirthDate = new DateTime(2010, 6, 28), Player_TeamsId = 28 },
                new Players() { Id = 555, PlayerName = "Andrei Lazar", Position = Position.Atacker, BirthDate = new DateTime(2011, 5, 27), Player_TeamsId = 28 },
                new Players() { Id = 556, PlayerName = "Ionut Popescu", Position = Position.Atacker, BirthDate = new DateTime(2009, 12, 11), Player_TeamsId = 28 },
                new Players() { Id = 557, PlayerName = "Mihai Neagu", Position = Position.Goalkeeper, BirthDate = new DateTime(2011, 8, 19), Player_TeamsId = 28 },
                new Players() { Id = 558, PlayerName = "Stefan Barbu", Position = Position.Midfielder, BirthDate = new DateTime(2012, 6, 8), Player_TeamsId = 28 },
                new Players() { Id = 559, PlayerName = "Florin Radulescu", Position = Position.Midfielder, BirthDate = new DateTime(2011, 7, 13), Player_TeamsId = 28 },
                new Players() { Id = 560, PlayerName = "Florin Ionescu", Position = Position.Atacker, BirthDate = new DateTime(2010, 8, 8), Player_TeamsId = 28 },
                new Players() { Id = 561, PlayerName = "Tudor Petrescu", Position = Position.Defender, BirthDate = new DateTime(2009, 3, 23), Player_TeamsId = 29 },
                new Players() { Id = 562, PlayerName = "Ionut Ionescu", Position = Position.Defender, BirthDate = new DateTime(2011, 9, 24), Player_TeamsId = 29 },
                new Players() { Id = 563, PlayerName = "Sergiu Toma", Position = Position.Goalkeeper, BirthDate = new DateTime(2010, 12, 3), Player_TeamsId = 29 },
                new Players() { Id = 564, PlayerName = "Denis Diaconu", Position = Position.Defender, BirthDate = new DateTime(2012, 9, 18), Player_TeamsId = 29 },
                new Players() { Id = 565, PlayerName = "Daniel Toma", Position = Position.Atacker, BirthDate = new DateTime(2011, 12, 25), Player_TeamsId = 29 },
                new Players() { Id = 566, PlayerName = "Alex Lazar", Position = Position.Defender, BirthDate = new DateTime(2011, 2, 15), Player_TeamsId = 29 },
                new Players() { Id = 567, PlayerName = "Eduard Diaconu", Position = Position.Midfielder, BirthDate = new DateTime(2012, 6, 18), Player_TeamsId = 29 },
                new Players() { Id = 568, PlayerName = "Cristian Ilie", Position = Position.Goalkeeper, BirthDate = new DateTime(2009, 10, 17), Player_TeamsId = 29 },
                new Players() { Id = 569, PlayerName = "Radu Voicu", Position = Position.Defender, BirthDate = new DateTime(2010, 3, 4), Player_TeamsId = 29 },
                new Players() { Id = 570, PlayerName = "Radu Petrescu", Position = Position.Defender, BirthDate = new DateTime(2009, 6, 1), Player_TeamsId = 29 },
                new Players() { Id = 571, PlayerName = "Florin Diaconu", Position = Position.Midfielder, BirthDate = new DateTime(2010, 9, 5), Player_TeamsId = 29 },
                new Players() { Id = 572, PlayerName = "Denis Marin", Position = Position.Defender, BirthDate = new DateTime(2009, 4, 10), Player_TeamsId = 29 },
                new Players() { Id = 573, PlayerName = "Robert Vasilescu", Position = Position.Atacker, BirthDate = new DateTime(2009, 4, 20), Player_TeamsId = 29 },
                new Players() { Id = 574, PlayerName = "Daniel Dumitrescu", Position = Position.Midfielder, BirthDate = new DateTime(2011, 9, 4), Player_TeamsId = 29 },
                new Players() { Id = 575, PlayerName = "Vlad Toma", Position = Position.Atacker, BirthDate = new DateTime(2010, 6, 1), Player_TeamsId = 29 },
                new Players() { Id = 576, PlayerName = "Florin Neagu", Position = Position.Defender, BirthDate = new DateTime(2011, 9, 1), Player_TeamsId = 29 },
                new Players() { Id = 577, PlayerName = "Ionut Toma", Position = Position.Defender, BirthDate = new DateTime(2012, 1, 23), Player_TeamsId = 29 },
                new Players() { Id = 578, PlayerName = "Adrian Matei", Position = Position.Atacker, BirthDate = new DateTime(2012, 9, 13), Player_TeamsId = 29 },
                new Players() { Id = 579, PlayerName = "Daniel Neagu", Position = Position.Goalkeeper, BirthDate = new DateTime(2012, 4, 10), Player_TeamsId = 29 },
                new Players() { Id = 580, PlayerName = "Robert Diaconu", Position = Position.Midfielder, BirthDate = new DateTime(2012, 2, 7), Player_TeamsId = 29 },
                new Players() { Id = 581, PlayerName = "Paul Voicu", Position = Position.Goalkeeper, BirthDate = new DateTime(2009, 12, 11), Player_TeamsId = 30 },
                new Players() { Id = 582, PlayerName = "Robert Stan", Position = Position.Atacker, BirthDate = new DateTime(2009, 12, 15), Player_TeamsId = 30 },
                new Players() { Id = 583, PlayerName = "Radu Toma", Position = Position.Midfielder, BirthDate = new DateTime(2010, 7, 2), Player_TeamsId = 30 },
                new Players() { Id = 584, PlayerName = "Eduard Diaconu", Position = Position.Goalkeeper, BirthDate = new DateTime(2010, 7, 24), Player_TeamsId = 30 },
                new Players() { Id = 585, PlayerName = "Vlad Marin", Position = Position.Defender, BirthDate = new DateTime(2011, 3, 5), Player_TeamsId = 30 },
                new Players() { Id = 586, PlayerName = "Radu Georgescu", Position = Position.Midfielder, BirthDate = new DateTime(2009, 2, 2), Player_TeamsId = 30 },
                new Players() { Id = 587, PlayerName = "Denis Dumitrescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2009, 12, 19), Player_TeamsId = 30 },
                new Players() { Id = 588, PlayerName = "Daniel Vasilescu", Position = Position.Midfielder, BirthDate = new DateTime(2011, 9, 23), Player_TeamsId = 30 },
                new Players() { Id = 589, PlayerName = "Radu Stan", Position = Position.Goalkeeper, BirthDate = new DateTime(2011, 5, 4), Player_TeamsId = 30 },
                new Players() { Id = 590, PlayerName = "Paul Marin", Position = Position.Atacker, BirthDate = new DateTime(2010, 5, 27), Player_TeamsId = 30 },
                new Players() { Id = 591, PlayerName = "Denis Matei", Position = Position.Defender, BirthDate = new DateTime(2009, 8, 19), Player_TeamsId = 30 },
                new Players() { Id = 592, PlayerName = "Mihai Stan", Position = Position.Goalkeeper, BirthDate = new DateTime(2010, 11, 27), Player_TeamsId = 30 },
                new Players() { Id = 593, PlayerName = "Eduard Neagu", Position = Position.Midfielder, BirthDate = new DateTime(2011, 11, 2), Player_TeamsId = 30 },
                new Players() { Id = 594, PlayerName = "Paul Neagu", Position = Position.Goalkeeper, BirthDate = new DateTime(2009, 3, 9), Player_TeamsId = 30 },
                new Players() { Id = 595, PlayerName = "Stefan Dumitrescu", Position = Position.Atacker, BirthDate = new DateTime(2012, 3, 13), Player_TeamsId = 30 },
                new Players() { Id = 596, PlayerName = "Stefan Diaconu", Position = Position.Midfielder, BirthDate = new DateTime(2012, 4, 5), Player_TeamsId = 30 },
                new Players() { Id = 597, PlayerName = "Daniel Lazar", Position = Position.Atacker, BirthDate = new DateTime(2012, 8, 26), Player_TeamsId = 30 },
                new Players() { Id = 598, PlayerName = "Eduard Popescu", Position = Position.Midfielder, BirthDate = new DateTime(2010, 10, 21), Player_TeamsId = 30 },
                new Players() { Id = 599, PlayerName = "Robert Chiriac", Position = Position.Goalkeeper, BirthDate = new DateTime(2010, 11, 3), Player_TeamsId = 30 },
                new Players() { Id = 600, PlayerName = "Mihai Neagu", Position = Position.Atacker, BirthDate = new DateTime(2010, 11, 11), Player_TeamsId = 30 },
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///cup
                new Players() { Id = 601, PlayerName = "Cosmin Ionescu", Position = Position.Defender, BirthDate = new DateTime(1998, 2, 26), Player_TeamsId = 31 },
                new Players() { Id = 602, PlayerName = "Ionut Ionescu", Position = Position.Midfielder, BirthDate = new DateTime(1992, 4, 19), Player_TeamsId = 31 },
                new Players() { Id = 603, PlayerName = "Vlad Voicu", Position = Position.Goalkeeper, BirthDate = new DateTime(2004, 9, 17), Player_TeamsId = 31 },
                new Players() { Id = 604, PlayerName = "Sorin Voicu", Position = Position.Atacker, BirthDate = new DateTime(2003, 9, 6), Player_TeamsId = 31 },
                new Players() { Id = 605, PlayerName = "Gabriel Zamfir", Position = Position.Defender, BirthDate = new DateTime(2003, 8, 13), Player_TeamsId = 31 },
                new Players() { Id = 606, PlayerName = "Stefan Nistor", Position = Position.Midfielder, BirthDate = new DateTime(1988, 10, 18), Player_TeamsId = 31 },
                new Players() { Id = 607, PlayerName = "Mihai Petrescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2004, 10, 5), Player_TeamsId = 31 },
                new Players() { Id = 608, PlayerName = "Florin Cojocaru", Position = Position.Atacker, BirthDate = new DateTime(1986, 12, 22), Player_TeamsId = 31 },
                new Players() { Id = 609, PlayerName = "Sorin Popa", Position = Position.Defender, BirthDate = new DateTime(2002, 6, 25), Player_TeamsId = 31 },
                new Players() { Id = 610, PlayerName = "Valentin Ionescu", Position = Position.Midfielder, BirthDate = new DateTime(2000, 3, 16), Player_TeamsId = 31 },
                new Players() { Id = 611, PlayerName = "Cristian Voicu", Position = Position.Goalkeeper, BirthDate = new DateTime(2004, 5, 12), Player_TeamsId = 31 },
                new Players() { Id = 612, PlayerName = "Gabriel Popa", Position = Position.Atacker, BirthDate = new DateTime(1998, 4, 5), Player_TeamsId = 31 },
                new Players() { Id = 613, PlayerName = "Stefan Georgescu", Position = Position.Defender, BirthDate = new DateTime(1989, 11, 9), Player_TeamsId = 31 },
                new Players() { Id = 614, PlayerName = "Gabriel Cojoc", Position = Position.Midfielder, BirthDate = new DateTime(2007, 10, 14), Player_TeamsId = 31 },
                new Players() { Id = 615, PlayerName = "Mihai Cristea", Position = Position.Goalkeeper, BirthDate = new DateTime(1989, 10, 25), Player_TeamsId = 31 },
                new Players() { Id = 616, PlayerName = "Alexandru Tudor", Position = Position.Atacker, BirthDate = new DateTime(1999, 3, 21), Player_TeamsId = 31 },
                new Players() { Id = 617, PlayerName = "Alexandru Neagu", Position = Position.Defender, BirthDate = new DateTime(1990, 2, 21), Player_TeamsId = 31 },
                new Players() { Id = 618, PlayerName = "Radu Cojoc", Position = Position.Midfielder, BirthDate = new DateTime(1997, 10, 24), Player_TeamsId = 31 },
                new Players() { Id = 619, PlayerName = "Alexandru Ionescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2005, 11, 1), Player_TeamsId = 31 },
                new Players() { Id = 620, PlayerName = "Denis Vasilescu", Position = Position.Atacker, BirthDate = new DateTime(1986, 10, 27), Player_TeamsId = 31 },
                new Players() { Id = 621, PlayerName = "Vlad Cojoc", Position = Position.Defender, BirthDate = new DateTime(2005, 1, 8), Player_TeamsId = 32 },
                new Players() { Id = 622, PlayerName = "Vlad Dumitrescu", Position = Position.Midfielder, BirthDate = new DateTime(1986, 8, 1), Player_TeamsId = 32 },
                new Players() { Id = 623, PlayerName = "Florin Tudor", Position = Position.Goalkeeper, BirthDate = new DateTime(1986, 7, 16), Player_TeamsId = 32 },
                new Players() { Id = 624, PlayerName = "Alexandru Tudor", Position = Position.Atacker, BirthDate = new DateTime(1992, 7, 7), Player_TeamsId = 32 },
                new Players() { Id = 625, PlayerName = "Mihai Zamfir", Position = Position.Defender, BirthDate = new DateTime(2007, 12, 4), Player_TeamsId = 32 },
                new Players() { Id = 626, PlayerName = "Gabriel Nistor", Position = Position.Midfielder, BirthDate = new DateTime(1985, 7, 20), Player_TeamsId = 32 },
                new Players() { Id = 627, PlayerName = "Cristian Cojocaru", Position = Position.Goalkeeper, BirthDate = new DateTime(1990, 4, 25), Player_TeamsId = 32 },
                new Players() { Id = 628, PlayerName = "Emil Georgescu", Position = Position.Atacker, BirthDate = new DateTime(2000, 4, 18), Player_TeamsId = 32 },
                new Players() { Id = 629, PlayerName = "Ionut Enache", Position = Position.Defender, BirthDate = new DateTime(1985, 10, 15), Player_TeamsId = 32 },
                new Players() { Id = 630, PlayerName = "Denis Zamfir", Position = Position.Midfielder, BirthDate = new DateTime(1994, 9, 19), Player_TeamsId = 32 },
                new Players() { Id = 631, PlayerName = "Radu Enache", Position = Position.Goalkeeper, BirthDate = new DateTime(1985, 2, 4), Player_TeamsId = 32 },
                new Players() { Id = 632, PlayerName = "George Petrescu", Position = Position.Atacker, BirthDate = new DateTime(1990, 12, 7), Player_TeamsId = 32 },
                new Players() { Id = 633, PlayerName = "Victor Popescu", Position = Position.Defender, BirthDate = new DateTime(1987, 11, 12), Player_TeamsId = 32 },
                new Players() { Id = 634, PlayerName = "Mihai Stan", Position = Position.Midfielder, BirthDate = new DateTime(2003, 1, 18), Player_TeamsId = 32 },
                new Players() { Id = 635, PlayerName = "Mihai Stan", Position = Position.Goalkeeper, BirthDate = new DateTime(2003, 4, 22), Player_TeamsId = 32 },
                new Players() { Id = 636, PlayerName = "Radu Georgescu", Position = Position.Atacker, BirthDate = new DateTime(2000, 2, 28), Player_TeamsId = 32 },
                new Players() { Id = 637, PlayerName = "Bogdan Voicu", Position = Position.Defender, BirthDate = new DateTime(1987, 8, 10), Player_TeamsId = 32 },
                new Players() { Id = 638, PlayerName = "Florin Petrescu", Position = Position.Midfielder, BirthDate = new DateTime(2004, 3, 25), Player_TeamsId = 32 },
                new Players() { Id = 639, PlayerName = "Emil Voicu", Position = Position.Goalkeeper, BirthDate = new DateTime(2006, 9, 5), Player_TeamsId = 32 },
                new Players() { Id = 640, PlayerName = "Mihai Popescu", Position = Position.Atacker, BirthDate = new DateTime(2000, 2, 9), Player_TeamsId = 32 },
                new Players() { Id = 641, PlayerName = "Cosmin Dumitrescu", Position = Position.Defender, BirthDate = new DateTime(1985, 6, 8), Player_TeamsId = 33 },
                new Players() { Id = 642, PlayerName = "Andrei Albu", Position = Position.Midfielder, BirthDate = new DateTime(1989, 2, 3), Player_TeamsId = 33 },
                new Players() { Id = 643, PlayerName = "Victor Enache", Position = Position.Goalkeeper, BirthDate = new DateTime(1991, 12, 23), Player_TeamsId = 33 },
                new Players() { Id = 644, PlayerName = "George Popescu", Position = Position.Atacker, BirthDate = new DateTime(1997, 8, 10), Player_TeamsId = 33 },
                new Players() { Id = 645, PlayerName = "Radu Ionescu", Position = Position.Defender, BirthDate = new DateTime(1996, 2, 3), Player_TeamsId = 33 },
                new Players() { Id = 646, PlayerName = "Sorin Cojocaru", Position = Position.Midfielder, BirthDate = new DateTime(1987, 3, 19), Player_TeamsId = 33 },
                new Players() { Id = 647, PlayerName = "Denis Cristea", Position = Position.Goalkeeper, BirthDate = new DateTime(2001, 4, 13), Player_TeamsId = 33 },
                new Players() { Id = 648, PlayerName = "Bogdan Neagu", Position = Position.Atacker, BirthDate = new DateTime(1992, 6, 24), Player_TeamsId = 33 },
                new Players() { Id = 649, PlayerName = "Florin Neagu", Position = Position.Defender, BirthDate = new DateTime(1986, 10, 11), Player_TeamsId = 33 },
                new Players() { Id = 650, PlayerName = "Victor Enache", Position = Position.Midfielder, BirthDate = new DateTime(1988, 7, 16), Player_TeamsId = 33 },
                new Players() { Id = 651, PlayerName = "Sorin Zamfir", Position = Position.Goalkeeper, BirthDate = new DateTime(2006, 8, 13), Player_TeamsId = 33 },
                new Players() { Id = 652, PlayerName = "Vlad Popescu", Position = Position.Atacker, BirthDate = new DateTime(1987, 2, 6), Player_TeamsId = 33 },
                new Players() { Id = 653, PlayerName = "Sorin Avram", Position = Position.Defender, BirthDate = new DateTime(1995, 9, 12), Player_TeamsId = 33 },
                new Players() { Id = 654, PlayerName = "Florin Petrescu", Position = Position.Midfielder, BirthDate = new DateTime(1994, 10, 25), Player_TeamsId = 33 },
                new Players() { Id = 655, PlayerName = "Emil Ionescu", Position = Position.Goalkeeper, BirthDate = new DateTime(1985, 9, 15), Player_TeamsId = 33 },
                new Players() { Id = 656, PlayerName = "Bogdan Dinu", Position = Position.Atacker, BirthDate = new DateTime(2007, 4, 25), Player_TeamsId = 33 },
                new Players() { Id = 657, PlayerName = "Andrei Avram", Position = Position.Defender, BirthDate = new DateTime(1995, 7, 16), Player_TeamsId = 33 },
                new Players() { Id = 658, PlayerName = "Valentin Cojoc", Position = Position.Midfielder, BirthDate = new DateTime(1998, 12, 4), Player_TeamsId = 33 },
                new Players() { Id = 659, PlayerName = "Emil Popescu", Position = Position.Goalkeeper, BirthDate = new DateTime(1997, 10, 20), Player_TeamsId = 33 },
                new Players() { Id = 660, PlayerName = "Denis Dinu", Position = Position.Atacker, BirthDate = new DateTime(2003, 10, 24), Player_TeamsId = 33 },
                new Players() { Id = 661, PlayerName = "Ionut Neagu", Position = Position.Defender, BirthDate = new DateTime(1988, 7, 19), Player_TeamsId = 34 },
                new Players() { Id = 662, PlayerName = "Vlad Dumitrescu", Position = Position.Midfielder, BirthDate = new DateTime(2002, 7, 6), Player_TeamsId = 34 },
                new Players() { Id = 663, PlayerName = "Andrei Enache", Position = Position.Goalkeeper, BirthDate = new DateTime(1988, 5, 26), Player_TeamsId = 34 },
                new Players() { Id = 664, PlayerName = "Gabriel Ionescu", Position = Position.Atacker, BirthDate = new DateTime(1985, 2, 10), Player_TeamsId = 34 },
                new Players() { Id = 665, PlayerName = "Stefan Tudor", Position = Position.Defender, BirthDate = new DateTime(1988, 12, 16), Player_TeamsId = 34 },
                new Players() { Id = 666, PlayerName = "Gabriel Cojoc", Position = Position.Midfielder, BirthDate = new DateTime(1985, 8, 25), Player_TeamsId = 34 },
                new Players() { Id = 667, PlayerName = "Andrei Avram", Position = Position.Goalkeeper, BirthDate = new DateTime(2001, 3, 14), Player_TeamsId = 34 },
                new Players() { Id = 668, PlayerName = "Adrian Albu", Position = Position.Atacker, BirthDate = new DateTime(1996, 1, 11), Player_TeamsId = 34 },
                new Players() { Id = 669, PlayerName = "Alexandru Dumitrescu", Position = Position.Defender, BirthDate = new DateTime(1998, 1, 11), Player_TeamsId = 34 },
                new Players() { Id = 670, PlayerName = "Radu Nistor", Position = Position.Midfielder, BirthDate = new DateTime(1987, 1, 14), Player_TeamsId = 34 },
                new Players() { Id = 671, PlayerName = "Radu Tudor", Position = Position.Goalkeeper, BirthDate = new DateTime(2006, 4, 25), Player_TeamsId = 34 },
                new Players() { Id = 672, PlayerName = "Emil Ionescu", Position = Position.Atacker, BirthDate = new DateTime(2007, 9, 5), Player_TeamsId = 34 },
                new Players() { Id = 673, PlayerName = "Gabriel Petrescu", Position = Position.Defender, BirthDate = new DateTime(2001, 3, 27), Player_TeamsId = 34 },
                new Players() { Id = 674, PlayerName = "Cosmin Popa", Position = Position.Midfielder, BirthDate = new DateTime(1996, 10, 28), Player_TeamsId = 34 },
                new Players() { Id = 675, PlayerName = "Gabriel Vasilescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2005, 10, 27), Player_TeamsId = 34 },
                new Players() { Id = 676, PlayerName = "Denis Tudor", Position = Position.Atacker, BirthDate = new DateTime(1986, 8, 18), Player_TeamsId = 34 },
                new Players() { Id = 677, PlayerName = "Stefan Nistor", Position = Position.Defender, BirthDate = new DateTime(1988, 9, 6), Player_TeamsId = 34 },
                new Players() { Id = 678, PlayerName = "Cristian Popa", Position = Position.Midfielder, BirthDate = new DateTime(1987, 10, 14), Player_TeamsId = 34 },
                new Players() { Id = 679, PlayerName = "Valentin Petrescu", Position = Position.Goalkeeper, BirthDate = new DateTime(1997, 2, 19), Player_TeamsId = 34 },
                new Players() { Id = 680, PlayerName = "Cosmin Petrescu", Position = Position.Atacker, BirthDate = new DateTime(1990, 6, 18), Player_TeamsId = 34 },
                new Players() { Id = 681, PlayerName = "Victor Georgescu", Position = Position.Defender, BirthDate = new DateTime(1985, 6, 11), Player_TeamsId = 35 },
                new Players() { Id = 682, PlayerName = "Radu Cojoc", Position = Position.Midfielder, BirthDate = new DateTime(1994, 7, 5), Player_TeamsId = 35 },
                new Players() { Id = 683, PlayerName = "Andrei Ionescu", Position = Position.Goalkeeper, BirthDate = new DateTime(2005, 10, 25), Player_TeamsId = 35 },
                new Players() { Id = 684, PlayerName = "Denis Cristea", Position = Position.Atacker, BirthDate = new DateTime(2004, 9, 24), Player_TeamsId = 35 },
                new Players() { Id = 685, PlayerName = "Valentin Avram", Position = Position.Defender, BirthDate = new DateTime(1986, 6, 23), Player_TeamsId = 35 },
                new Players() { Id = 686, PlayerName = "Alexandru Popa", Position = Position.Midfielder, BirthDate = new DateTime(1989, 7, 18), Player_TeamsId = 35 },
                new Players() { Id = 687, PlayerName = "Valentin Enache", Position = Position.Goalkeeper, BirthDate = new DateTime(1989, 5, 11), Player_TeamsId = 35 },
                new Players() { Id = 688, PlayerName = "Mihai Petrescu", Position = Position.Atacker, BirthDate = new DateTime(1991, 8, 1), Player_TeamsId = 35 },
                new Players() { Id = 689, PlayerName = "Valentin Petrescu", Position = Position.Defender, BirthDate = new DateTime(1997, 11, 16), Player_TeamsId = 35 },
                new Players() { Id = 690, PlayerName = "Sorin Vasilescu", Position = Position.Midfielder, BirthDate = new DateTime(1994, 8, 2), Player_TeamsId = 35 },
                new Players() { Id = 691, PlayerName = "Denis Tudor", Position = Position.Goalkeeper, BirthDate = new DateTime(2001, 4, 4), Player_TeamsId = 35 },
                new Players() { Id = 692, PlayerName = "Paul Popa", Position = Position.Atacker, BirthDate = new DateTime(1991, 7, 7), Player_TeamsId = 35 },
                new Players() { Id = 693, PlayerName = "Radu Vasilescu", Position = Position.Defender, BirthDate = new DateTime(1990, 3, 12), Player_TeamsId = 35 },
                new Players() { Id = 694, PlayerName = "Radu Enache", Position = Position.Midfielder, BirthDate = new DateTime(1999, 2, 3), Player_TeamsId = 35 },
                new Players() { Id = 695, PlayerName = "Valentin Popa", Position = Position.Goalkeeper, BirthDate = new DateTime(2001, 11, 10), Player_TeamsId = 35 },
                new Players() { Id = 696, PlayerName = "Vlad Stan", Position = Position.Atacker, BirthDate = new DateTime(1993, 5, 28), Player_TeamsId = 35 },
                new Players() { Id = 697, PlayerName = "Mihai Neagu", Position = Position.Defender, BirthDate = new DateTime(1987, 4, 5), Player_TeamsId = 35 },
                new Players() { Id = 698, PlayerName = "Bogdan Enache", Position = Position.Midfielder, BirthDate = new DateTime(1985, 12, 8), Player_TeamsId = 35 },
                new Players() { Id = 699, PlayerName = "Cosmin Neagu", Position = Position.Goalkeeper, BirthDate = new DateTime(1989, 11, 5), Player_TeamsId = 35 },
                new Players() { Id = 700, PlayerName = "Sorin Dumitrescu", Position = Position.Atacker, BirthDate = new DateTime(1990, 5, 15), Player_TeamsId = 35 },
                new Players() { Id = 701, PlayerName = "Bogdan Popa", Position = Position.Defender, BirthDate = new DateTime(2006, 5, 21), Player_TeamsId = 36 },
                new Players() { Id = 702, PlayerName = "Alexandru Neagu", Position = Position.Midfielder, BirthDate = new DateTime(2007, 11, 25), Player_TeamsId = 36 },
                new Players() { Id = 703, PlayerName = "Vlad Stan", Position = Position.Goalkeeper, BirthDate = new DateTime(2002, 3, 19), Player_TeamsId = 36 },
                new Players() { Id = 704, PlayerName = "Florin Neagu", Position = Position.Atacker, BirthDate = new DateTime(2005, 3, 21), Player_TeamsId = 36 },
                new Players() { Id = 705, PlayerName = "Bogdan Vasilescu", Position = Position.Defender, BirthDate = new DateTime(1987, 10, 27), Player_TeamsId = 36 },
                new Players() { Id = 706, PlayerName = "Emil Petrescu", Position = Position.Midfielder, BirthDate = new DateTime(1994, 6, 9), Player_TeamsId = 36 },
                new Players() { Id = 707, PlayerName = "Bogdan Zamfir", Position = Position.Goalkeeper, BirthDate = new DateTime(2000, 11, 15), Player_TeamsId = 36 },
                new Players() { Id = 708, PlayerName = "Valentin Dinu", Position = Position.Atacker, BirthDate = new DateTime(1993, 4, 1), Player_TeamsId = 36 },
                new Players() { Id = 709, PlayerName = "Adrian Petrescu", Position = Position.Defender, BirthDate = new DateTime(1998, 12, 7), Player_TeamsId = 36 },
                new Players() { Id = 710, PlayerName = "Cosmin Nistor", Position = Position.Midfielder, BirthDate = new DateTime(1991, 9, 28), Player_TeamsId = 36 },
                new Players() { Id = 711, PlayerName = "Gabriel Cojoc", Position = Position.Goalkeeper, BirthDate = new DateTime(1989, 4, 24), Player_TeamsId = 36 },
                new Players() { Id = 712, PlayerName = "Adrian Voicu", Position = Position.Atacker, BirthDate = new DateTime(2006, 11, 17), Player_TeamsId = 36 },
                new Players() { Id = 713, PlayerName = "Victor Ionescu", Position = Position.Defender, BirthDate = new DateTime(1996, 1, 24), Player_TeamsId = 36 },
                new Players() { Id = 714, PlayerName = "Florin Zamfir", Position = Position.Midfielder, BirthDate = new DateTime(1986, 11, 25), Player_TeamsId = 36 },
                new Players() { Id = 715, PlayerName = "Valentin Voicu", Position = Position.Goalkeeper, BirthDate = new DateTime(1993, 6, 22), Player_TeamsId = 36 },
                new Players() { Id = 716, PlayerName = "George Popescu", Position = Position.Atacker, BirthDate = new DateTime(1996, 5, 13), Player_TeamsId = 36 },
                new Players() { Id = 717, PlayerName = "Adrian Cojocaru", Position = Position.Defender, BirthDate = new DateTime(2005, 11, 7), Player_TeamsId = 36 },
                new Players() { Id = 718, PlayerName = "Adrian Nistor", Position = Position.Midfielder, BirthDate = new DateTime(1986, 12, 22), Player_TeamsId = 36 },
                new Players() { Id = 719, PlayerName = "Victor Voicu", Position = Position.Goalkeeper, BirthDate = new DateTime(2001, 5, 21), Player_TeamsId = 36 },
                new Players() { Id = 720, PlayerName = "Cosmin Voicu", Position = Position.Atacker, BirthDate = new DateTime(2006, 12, 14), Player_TeamsId = 36 },
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //champions league
                new Players() { Id = 801, PlayerName = "Nikola Mitrovic", Position = Position.Defender, BirthDate = new DateTime(1997, 6, 22), Player_TeamsId = 41 },
                new Players() { Id = 802, PlayerName = "Milos Jovic", Position = Position.Midfielder, BirthDate = new DateTime(1996, 8, 5), Player_TeamsId = 41 },
                new Players() { Id = 803, PlayerName = "Marko Stojkovic", Position = Position.Goalkeeper, BirthDate = new DateTime(2007, 3, 14), Player_TeamsId = 41 },
                new Players() { Id = 804, PlayerName = "Stefan Vesic", Position = Position.Atacker, BirthDate = new DateTime(1988, 8, 26), Player_TeamsId = 41 },
                new Players() { Id = 805, PlayerName = "Dusan Petrovic", Position = Position.Defender, BirthDate = new DateTime(1988, 11, 19), Player_TeamsId = 41 },
                new Players() { Id = 806, PlayerName = "Vladimir Savic", Position = Position.Midfielder, BirthDate = new DateTime(1988, 11, 28), Player_TeamsId = 41 },
                new Players() { Id = 807, PlayerName = "Aleksandar Radovanovic", Position = Position.Goalkeeper, BirthDate = new DateTime(1995, 1, 17), Player_TeamsId = 41 },
                new Players() { Id = 808, PlayerName = "Nemanja Zivkovic", Position = Position.Atacker, BirthDate = new DateTime(2003, 6, 23), Player_TeamsId = 41 },
                new Players() { Id = 809, PlayerName = "Luka Tadic", Position = Position.Defender, BirthDate = new DateTime(2000, 3, 27), Player_TeamsId = 41 },
                new Players() { Id = 810, PlayerName = "Jovan Popovic", Position = Position.Midfielder, BirthDate = new DateTime(1986, 6, 23), Player_TeamsId = 41 },
                new Players() { Id = 811, PlayerName = "Petar Milinkovic", Position = Position.Goalkeeper, BirthDate = new DateTime(2004, 6, 23), Player_TeamsId = 41 },
                new Players() { Id = 812, PlayerName = "Uros Milenkovic", Position = Position.Atacker, BirthDate = new DateTime(2005, 10, 7), Player_TeamsId = 41 },
                new Players() { Id = 813, PlayerName = "Branislav Pavlovic", Position = Position.Defender, BirthDate = new DateTime(1994, 6, 17), Player_TeamsId = 41 },
                new Players() { Id = 814, PlayerName = "Ivan Simic", Position = Position.Midfielder, BirthDate = new DateTime(2006, 6, 3), Player_TeamsId = 41 },
                new Players() { Id = 815, PlayerName = "Goran Kostic", Position = Position.Goalkeeper, BirthDate = new DateTime(1990, 9, 9), Player_TeamsId = 41 },
                new Players() { Id = 816, PlayerName = "Dragan Matic", Position = Position.Atacker, BirthDate = new DateTime(1988, 11, 7), Player_TeamsId = 41 },
                new Players() { Id = 817, PlayerName = "Slobodan Ristic", Position = Position.Defender, BirthDate = new DateTime(1994, 4, 11), Player_TeamsId = 41 },
                new Players() { Id = 818, PlayerName = "Zoran Gajic", Position = Position.Midfielder, BirthDate = new DateTime(1988, 10, 25), Player_TeamsId = 41 },
                new Players() { Id = 819, PlayerName = "Milan Nikolic", Position = Position.Goalkeeper, BirthDate = new DateTime(1992, 5, 13), Player_TeamsId = 41 },
                new Players() { Id = 820, PlayerName = "Bogdan Lazic", Position = Position.Atacker, BirthDate = new DateTime(2001, 10, 12), Player_TeamsId = 41 },
                new Players() { Id = 821, PlayerName = "Ivan Kovacic", Position = Position.Defender, BirthDate = new DateTime(2002, 12, 10), Player_TeamsId = 42 },
                new Players() { Id = 822, PlayerName = "Luka Perisic", Position = Position.Midfielder, BirthDate = new DateTime(1993, 11, 12), Player_TeamsId = 42 },
                new Players() { Id = 823, PlayerName = "Marko Brekalo", Position = Position.Goalkeeper, BirthDate = new DateTime(2004, 3, 1), Player_TeamsId = 42 },
                new Players() { Id = 824, PlayerName = "Josip Livakovic", Position = Position.Atacker, BirthDate = new DateTime(2005, 6, 13), Player_TeamsId = 42 },
                new Players() { Id = 825, PlayerName = "Ante Gvardiol", Position = Position.Defender, BirthDate = new DateTime(1995, 10, 8), Player_TeamsId = 42 },
                new Players() { Id = 826, PlayerName = "Karlo Orsic", Position = Position.Midfielder, BirthDate = new DateTime(1986, 11, 8), Player_TeamsId = 42 },
                new Players() { Id = 827, PlayerName = "Dario Melnjak", Position = Position.Goalkeeper, BirthDate = new DateTime(2002, 11, 12), Player_TeamsId = 42 },
                new Players() { Id = 828, PlayerName = "Tomislav Majer", Position = Position.Atacker, BirthDate = new DateTime(2005, 12, 26), Player_TeamsId = 42 },
                new Players() { Id = 829, PlayerName = "Stipe Juranovic", Position = Position.Defender, BirthDate = new DateTime(2004, 3, 24), Player_TeamsId = 42 },
                new Players() { Id = 830, PlayerName = "Fran Barisic", Position = Position.Midfielder, BirthDate = new DateTime(1985, 11, 25), Player_TeamsId = 42 },
                new Players() { Id = 831, PlayerName = "Domagoj Brozovic", Position = Position.Goalkeeper, BirthDate = new DateTime(2003, 11, 5), Player_TeamsId = 42 },
                new Players() { Id = 832, PlayerName = "Mario Budimir", Position = Position.Atacker, BirthDate = new DateTime(1986, 10, 12), Player_TeamsId = 42 },
                new Players() { Id = 833, PlayerName = "Filip Vrsaljko", Position = Position.Defender, BirthDate = new DateTime(1987, 11, 5), Player_TeamsId = 42 },
                new Players() { Id = 834, PlayerName = "Krunoslav Musa", Position = Position.Midfielder, BirthDate = new DateTime(1998, 5, 20), Player_TeamsId = 42 },
                new Players() { Id = 835, PlayerName = "Lovro Colak", Position = Position.Goalkeeper, BirthDate = new DateTime(1989, 2, 17), Player_TeamsId = 42 },
                new Players() { Id = 836, PlayerName = "Matija Skoric", Position = Position.Atacker, BirthDate = new DateTime(2000, 9, 1), Player_TeamsId = 42 },
                new Players() { Id = 837, PlayerName = "Nikola Palaversa", Position = Position.Defender, BirthDate = new DateTime(1989, 9, 8), Player_TeamsId = 42 },
                new Players() { Id = 838, PlayerName = "Petar Bradaric", Position = Position.Midfielder, BirthDate = new DateTime(2006, 8, 10), Player_TeamsId = 42 },
                new Players() { Id = 839, PlayerName = "Sime Tudor", Position = Position.Goalkeeper, BirthDate = new DateTime(1994, 11, 1), Player_TeamsId = 42 },
                new Players() { Id = 840, PlayerName = "Zvonimir Caleta-Car", Position = Position.Atacker, BirthDate = new DateTime(1997, 3, 1), Player_TeamsId = 42 },
                new Players() { Id = 841, PlayerName = "Giorgos Papadopoulos", Position = Position.Defender, BirthDate = new DateTime(2007, 6, 27), Player_TeamsId = 43 },
                new Players() { Id = 842, PlayerName = "Dimitris Stamatopoulos", Position = Position.Midfielder, BirthDate = new DateTime(1985, 12, 28), Player_TeamsId = 43 },
                new Players() { Id = 843, PlayerName = "Vasilis Karagounis", Position = Position.Goalkeeper, BirthDate = new DateTime(1997, 7, 11), Player_TeamsId = 43 },
                new Players() { Id = 844, PlayerName = "Kostas Ninis", Position = Position.Atacker, BirthDate = new DateTime(1986, 7, 25), Player_TeamsId = 43 },
                new Players() { Id = 845, PlayerName = "Nikolaos Mitroglou", Position = Position.Defender, BirthDate = new DateTime(1986, 3, 26), Player_TeamsId = 43 },
                new Players() { Id = 846, PlayerName = "Giannis Tzavellas", Position = Position.Midfielder, BirthDate = new DateTime(2002, 2, 22), Player_TeamsId = 43 },
                new Players() { Id = 847, PlayerName = "Anastasios Manolas", Position = Position.Goalkeeper, BirthDate = new DateTime(1987, 2, 8), Player_TeamsId = 43 },
                new Players() { Id = 848, PlayerName = "Panagiotis Samaris", Position = Position.Atacker, BirthDate = new DateTime(2006, 6, 7), Player_TeamsId = 43 },
                new Players() { Id = 849, PlayerName = "Christos Siovas", Position = Position.Defender, BirthDate = new DateTime(2007, 7, 16), Player_TeamsId = 43 },
                new Players() { Id = 850, PlayerName = "Andreas Bouchalakis", Position = Position.Midfielder, BirthDate = new DateTime(2007, 10, 9), Player_TeamsId = 43 },
                new Players() { Id = 851, PlayerName = "Spyros Kourbelis", Position = Position.Goalkeeper, BirthDate = new DateTime(1989, 12, 3), Player_TeamsId = 43 },
                new Players() { Id = 852, PlayerName = "Lefteris Zeca", Position = Position.Atacker, BirthDate = new DateTime(1994, 9, 19), Player_TeamsId = 43 },
                new Players() { Id = 853, PlayerName = "Stavros Giakoumakis", Position = Position.Defender, BirthDate = new DateTime(1986, 2, 13), Player_TeamsId = 43 },
                new Players() { Id = 854, PlayerName = "Apostolos Tsimikas", Position = Position.Midfielder, BirthDate = new DateTime(2007, 10, 4), Player_TeamsId = 43 },
                new Players() { Id = 855, PlayerName = "Antonis Koulouris", Position = Position.Goalkeeper, BirthDate = new DateTime(1999, 10, 22), Player_TeamsId = 43 },
                new Players() { Id = 856, PlayerName = "Marios Retsos", Position = Position.Atacker, BirthDate = new DateTime(1990, 2, 5), Player_TeamsId = 43 },
                new Players() { Id = 857, PlayerName = "Manolis Bakakis", Position = Position.Defender, BirthDate = new DateTime(2004, 5, 22), Player_TeamsId = 43 },
                new Players() { Id = 858, PlayerName = "Sotiris Masouras", Position = Position.Midfielder, BirthDate = new DateTime(2000, 6, 11), Player_TeamsId = 43 },
                new Players() { Id = 859, PlayerName = "Petros Lampropoulos", Position = Position.Goalkeeper, BirthDate = new DateTime(2004, 4, 28), Player_TeamsId = 43 },
                new Players() { Id = 860, PlayerName = "Thanasis Pelkas", Position = Position.Atacker, BirthDate = new DateTime(2007, 6, 26), Player_TeamsId = 43 },
                new Players() { Id = 861, PlayerName = "Emre Yilmaz", Position = Position.Defender, BirthDate = new DateTime(2002, 5, 21), Player_TeamsId = 44 },
                new Players() { Id = 862, PlayerName = "Mehmet Demir", Position = Position.Midfielder, BirthDate = new DateTime(2004, 6, 19), Player_TeamsId = 44 },
                new Players() { Id = 863, PlayerName = "Ahmet Kilic", Position = Position.Goalkeeper, BirthDate = new DateTime(2007, 2, 27), Player_TeamsId = 44 },
                new Players() { Id = 864, PlayerName = "Mustafa Ozturk", Position = Position.Atacker, BirthDate = new DateTime(1997, 12, 17), Player_TeamsId = 44 },
                new Players() { Id = 865, PlayerName = "Hakan Kaya", Position = Position.Defender, BirthDate = new DateTime(1997, 5, 14), Player_TeamsId = 44 },
                new Players() { Id = 866, PlayerName = "Murat Aydin", Position = Position.Midfielder, BirthDate = new DateTime(2001, 12, 24), Player_TeamsId = 44 },
                new Players() { Id = 867, PlayerName = "Ali Korkmaz", Position = Position.Goalkeeper, BirthDate = new DateTime(2007, 11, 19), Player_TeamsId = 44 },
                new Players() { Id = 868, PlayerName = "Serkan Gunes", Position = Position.Atacker, BirthDate = new DateTime(1996, 12, 5), Player_TeamsId = 44 },
                new Players() { Id = 869, PlayerName = "Burak Cetin", Position = Position.Defender, BirthDate = new DateTime(1997, 7, 13), Player_TeamsId = 44 },
                new Players() { Id = 870, PlayerName = "Cem Yildirim", Position = Position.Midfielder, BirthDate = new DateTime(2002, 9, 26), Player_TeamsId = 44 },
                new Players() { Id = 871, PlayerName = "Baris Sahin", Position = Position.Goalkeeper, BirthDate = new DateTime(1993, 3, 14), Player_TeamsId = 44 },
                new Players() { Id = 872, PlayerName = "Eren Erdogan", Position = Position.Atacker, BirthDate = new DateTime(1993, 8, 12), Player_TeamsId = 44 },
                new Players() { Id = 873, PlayerName = "Can Polat", Position = Position.Defender, BirthDate = new DateTime(2002, 8, 23), Player_TeamsId = 44 },
                new Players() { Id = 874, PlayerName = "Okan Turan", Position = Position.Midfielder, BirthDate = new DateTime(1995, 12, 14), Player_TeamsId = 44 },
                new Players() { Id = 875, PlayerName = "Sefa Acar", Position = Position.Goalkeeper, BirthDate = new DateTime(2003, 4, 5), Player_TeamsId = 44 },
                new Players() { Id = 876, PlayerName = "Gokhan Kara", Position = Position.Atacker, BirthDate = new DateTime(2006, 5, 4), Player_TeamsId = 44 },
                new Players() { Id = 877, PlayerName = "Yusuf Durmaz", Position = Position.Defender, BirthDate = new DateTime(1986, 9, 2), Player_TeamsId = 44 },
                new Players() { Id = 878, PlayerName = "Umut Aslan", Position = Position.Midfielder, BirthDate = new DateTime(1990, 5, 19), Player_TeamsId = 44 },
                new Players() { Id = 879, PlayerName = "Halil Dogan", Position = Position.Goalkeeper, BirthDate = new DateTime(1991, 4, 15), Player_TeamsId = 44 },
                new Players() { Id = 880, PlayerName = "Fatih Guler", Position = Position.Atacker, BirthDate = new DateTime(1995, 8, 21), Player_TeamsId = 44 },
                new Players() { Id = 881, PlayerName = "Jordi Garcia", Position = Position.Defender, BirthDate = new DateTime(2001, 8, 9), Player_TeamsId = 45 },
                new Players() { Id = 882, PlayerName = "Sergio Martinez", Position = Position.Midfielder, BirthDate = new DateTime(1997, 10, 18), Player_TeamsId = 45 },
                new Players() { Id = 883, PlayerName = "Andres Lopez", Position = Position.Goalkeeper, BirthDate = new DateTime(1985, 4, 13), Player_TeamsId = 45 },
                new Players() { Id = 884, PlayerName = "Pedro Hernandez", Position = Position.Atacker, BirthDate = new DateTime(1997, 9, 4), Player_TeamsId = 45 },
                new Players() { Id = 885, PlayerName = "Alejandro Gonzalez", Position = Position.Defender, BirthDate = new DateTime(1999, 10, 17), Player_TeamsId = 45 },
                new Players() { Id = 886, PlayerName = "Carlos Perez", Position = Position.Midfielder, BirthDate = new DateTime(1989, 1, 10), Player_TeamsId = 45 },
                new Players() { Id = 887, PlayerName = "Juan Sanchez", Position = Position.Goalkeeper, BirthDate = new DateTime(1988, 9, 18), Player_TeamsId = 45 },
                new Players() { Id = 888, PlayerName = "David Ramirez", Position = Position.Atacker, BirthDate = new DateTime(1985, 7, 15), Player_TeamsId = 45 },
                new Players() { Id = 889, PlayerName = "Manuel Torres", Position = Position.Defender, BirthDate = new DateTime(1987, 1, 1), Player_TeamsId = 45 },
                new Players() { Id = 890, PlayerName = "Francisco Flores", Position = Position.Midfielder, BirthDate = new DateTime(2002, 4, 15), Player_TeamsId = 45 },
                new Players() { Id = 891, PlayerName = "Ruben Ruiz", Position = Position.Goalkeeper, BirthDate = new DateTime(2007, 6, 1), Player_TeamsId = 45 },
                new Players() { Id = 892, PlayerName = "Antonio Alonso", Position = Position.Atacker, BirthDate = new DateTime(1994, 6, 11), Player_TeamsId = 45 },
                new Players() { Id = 893, PlayerName = "Miguel Moreno", Position = Position.Defender, BirthDate = new DateTime(1989, 2, 14), Player_TeamsId = 45 },
                new Players() { Id = 894, PlayerName = "Rafael Navarro", Position = Position.Midfielder, BirthDate = new DateTime(1995, 3, 9), Player_TeamsId = 45 },
                new Players() { Id = 895, PlayerName = "Jesus Serrano", Position = Position.Goalkeeper, BirthDate = new DateTime(2000, 3, 21), Player_TeamsId = 45 },
                new Players() { Id = 896, PlayerName = "Alvaro Jimenez", Position = Position.Atacker, BirthDate = new DateTime(1991, 2, 18), Player_TeamsId = 45 },
                new Players() { Id = 897, PlayerName = "Jose Molina", Position = Position.Defender, BirthDate = new DateTime(1998, 11, 5), Player_TeamsId = 45 },
                new Players() { Id = 898, PlayerName = "Victor Castro", Position = Position.Midfielder, BirthDate = new DateTime(2003, 9, 1), Player_TeamsId = 45 },
                new Players() { Id = 899, PlayerName = "Pablo Ortega", Position = Position.Goalkeeper, BirthDate = new DateTime(2006, 6, 7), Player_TeamsId = 45 },
                new Players() { Id = 900, PlayerName = "Lucas Delgado", Position = Position.Atacker, BirthDate = new DateTime(1986, 12, 21), Player_TeamsId = 45 },
                new Players() { Id = 901, PlayerName = "Lukas Müller", Position = Position.Defender, BirthDate = new DateTime(1997, 1, 18), Player_TeamsId = 46 },
                new Players() { Id = 902, PlayerName = "Maximilian Schmidt", Position = Position.Midfielder, BirthDate = new DateTime(1994, 12, 4), Player_TeamsId = 46 },
                new Players() { Id = 903, PlayerName = "Felix Schneider", Position = Position.Goalkeeper, BirthDate = new DateTime(1998, 12, 28), Player_TeamsId = 46 },
                new Players() { Id = 904, PlayerName = "Leon Fischer", Position = Position.Atacker, BirthDate = new DateTime(1997, 12, 6), Player_TeamsId = 46 },
                new Players() { Id = 905, PlayerName = "Julian Weber", Position = Position.Defender, BirthDate = new DateTime(2006, 2, 27), Player_TeamsId = 46 },
                new Players() { Id = 906, PlayerName = "Moritz Meyer", Position = Position.Midfielder, BirthDate = new DateTime(1986, 1, 5), Player_TeamsId = 46 },
                new Players() { Id = 907, PlayerName = "Florian Wagner", Position = Position.Goalkeeper, BirthDate = new DateTime(1988, 4, 24), Player_TeamsId = 46 },
                new Players() { Id = 908, PlayerName = "Tobias Becker", Position = Position.Atacker, BirthDate = new DateTime(1996, 7, 7), Player_TeamsId = 46 },
                new Players() { Id = 909, PlayerName = "Simon Hoffmann", Position = Position.Defender, BirthDate = new DateTime(2003, 11, 14), Player_TeamsId = 46 },
                new Players() { Id = 910, PlayerName = "Paul Schäfer", Position = Position.Midfielder, BirthDate = new DateTime(1998, 2, 12), Player_TeamsId = 46 },
                new Players() { Id = 911, PlayerName = "Nico Koch", Position = Position.Goalkeeper, BirthDate = new DateTime(1999, 1, 22), Player_TeamsId = 46 },
                new Players() { Id = 912, PlayerName = "Dominik Richter", Position = Position.Atacker, BirthDate = new DateTime(1988, 6, 5), Player_TeamsId = 46 },
                new Players() { Id = 913, PlayerName = "Marcel Klein", Position = Position.Defender, BirthDate = new DateTime(1995, 11, 9), Player_TeamsId = 46 },
                new Players() { Id = 914, PlayerName = "Fabian Wolf", Position = Position.Midfielder, BirthDate = new DateTime(1998, 11, 23), Player_TeamsId = 46 },
                new Players() { Id = 915, PlayerName = "Benedikt Neumann", Position = Position.Goalkeeper, BirthDate = new DateTime(2005, 1, 23), Player_TeamsId = 46 },
                new Players() { Id = 916, PlayerName = "Sebastian Schwarz", Position = Position.Atacker, BirthDate = new DateTime(1990, 8, 21), Player_TeamsId = 46 },
                new Players() { Id = 917, PlayerName = "Philipp Zimmermann", Position = Position.Defender, BirthDate = new DateTime(2003, 7, 22), Player_TeamsId = 46 },
                new Players() { Id = 918, PlayerName = "Johannes Braun", Position = Position.Midfielder, BirthDate = new DateTime(1998, 7, 7), Player_TeamsId = 46 },
                new Players() { Id = 919, PlayerName = "Patrick Krüger", Position = Position.Goalkeeper, BirthDate = new DateTime(1996, 2, 13), Player_TeamsId = 46 },
                new Players() { Id = 920, PlayerName = "Matthias Hofmann", Position = Position.Atacker, BirthDate = new DateTime(1987, 5, 28), Player_TeamsId = 46 },
                new Players() { Id = 921, PlayerName = "Pierre Dupont", Position = Position.Defender, BirthDate = new DateTime(1987, 10, 22), Player_TeamsId = 47 },
                new Players() { Id = 922, PlayerName = "Jean Durand", Position = Position.Midfielder, BirthDate = new DateTime(1995, 7, 26), Player_TeamsId = 47 },
                new Players() { Id = 923, PlayerName = "Michel Lefevre", Position = Position.Goalkeeper, BirthDate = new DateTime(1992, 3, 28), Player_TeamsId = 47 },
                new Players() { Id = 924, PlayerName = "Claude Martin", Position = Position.Atacker, BirthDate = new DateTime(1988, 2, 26), Player_TeamsId = 47 },
                new Players() { Id = 925, PlayerName = "Philippe Bernard", Position = Position.Defender, BirthDate = new DateTime(1996, 11, 13), Player_TeamsId = 47 },
                new Players() { Id = 926, PlayerName = "Alain Petit", Position = Position.Midfielder, BirthDate = new DateTime(2007, 7, 28), Player_TeamsId = 47 },
                new Players() { Id = 927, PlayerName = "Jacques Robert", Position = Position.Goalkeeper, BirthDate = new DateTime(1988, 11, 18), Player_TeamsId = 47 },
                new Players() { Id = 928, PlayerName = "Luc Richard", Position = Position.Atacker, BirthDate = new DateTime(1991, 4, 27), Player_TeamsId = 47 },
                new Players() { Id = 929, PlayerName = "Eric Simon", Position = Position.Defender, BirthDate = new DateTime(2002, 7, 11), Player_TeamsId = 47 },
                new Players() { Id = 930, PlayerName = "Nicolas Laurent", Position = Position.Midfielder, BirthDate = new DateTime(2001, 1, 28), Player_TeamsId = 47 },
                new Players() { Id = 931, PlayerName = "Bernard Michel", Position = Position.Goalkeeper, BirthDate = new DateTime(1987, 9, 9), Player_TeamsId = 47 },
                new Players() { Id = 932, PlayerName = "Olivier Garcia", Position = Position.Atacker, BirthDate = new DateTime(1993, 7, 4), Player_TeamsId = 47 },
                new Players() { Id = 933, PlayerName = "Laurent Moreau", Position = Position.Defender, BirthDate = new DateTime(1998, 9, 21), Player_TeamsId = 47 },
                new Players() { Id = 934, PlayerName = "Didier Fournier", Position = Position.Midfielder, BirthDate = new DateTime(1997, 2, 18), Player_TeamsId = 47 },
                new Players() { Id = 935, PlayerName = "Patrick Girard", Position = Position.Goalkeeper, BirthDate = new DateTime(2000, 5, 12), Player_TeamsId = 47 },
                new Players() { Id = 936, PlayerName = "Sebastien Andre", Position = Position.Atacker, BirthDate = new DateTime(1992, 7, 1), Player_TeamsId = 47 },
                new Players() { Id = 937, PlayerName = "Vincent Guerin", Position = Position.Defender, BirthDate = new DateTime(1991, 12, 7), Player_TeamsId = 47 },
                new Players() { Id = 938, PlayerName = "Antoine Boyer", Position = Position.Midfielder, BirthDate = new DateTime(1989, 3, 18), Player_TeamsId = 47 },
                new Players() { Id = 939, PlayerName = "Guillaume Garnier", Position = Position.Goalkeeper, BirthDate = new DateTime(2000, 9, 9), Player_TeamsId = 47 },
                new Players() { Id = 940, PlayerName = "Thierry Chevalier", Position = Position.Atacker, BirthDate = new DateTime(1990, 5, 14), Player_TeamsId = 47 },
                new Players() { Id = 941, PlayerName = "John Smith", Position = Position.Defender, BirthDate = new DateTime(1991, 2, 12), Player_TeamsId = 48 },
                new Players() { Id = 942, PlayerName = "James Jones", Position = Position.Midfielder, BirthDate = new DateTime(1985, 2, 14), Player_TeamsId = 48 },
                new Players() { Id = 943, PlayerName = "Robert Taylor", Position = Position.Goalkeeper, BirthDate = new DateTime(1988, 6, 27), Player_TeamsId = 48 },
                new Players() { Id = 944, PlayerName = "Michael Williams", Position = Position.Atacker, BirthDate = new DateTime(1998, 4, 16), Player_TeamsId = 48 },
                new Players() { Id = 945, PlayerName = "William Brown", Position = Position.Defender, BirthDate = new DateTime(2000, 7, 15), Player_TeamsId = 48 },
                new Players() { Id = 946, PlayerName = "David Davies", Position = Position.Midfielder, BirthDate = new DateTime(1998, 11, 17), Player_TeamsId = 48 },
                new Players() { Id = 947, PlayerName = "Richard Evans", Position = Position.Goalkeeper, BirthDate = new DateTime(1998, 12, 1), Player_TeamsId = 48 },
                new Players() { Id = 948, PlayerName = "Charles Thomas", Position = Position.Atacker, BirthDate = new DateTime(1999, 3, 10), Player_TeamsId = 48 },
                new Players() { Id = 949, PlayerName = "Joseph Roberts", Position = Position.Defender, BirthDate = new DateTime(1989, 5, 24), Player_TeamsId = 48 },
                new Players() { Id = 950, PlayerName = "Thomas Johnson", Position = Position.Midfielder, BirthDate = new DateTime(1999, 9, 17), Player_TeamsId = 48 },
                new Players() { Id = 951, PlayerName = "George Walker", Position = Position.Goalkeeper, BirthDate = new DateTime(1986, 12, 19), Player_TeamsId = 48 },
                new Players() { Id = 952, PlayerName = "Daniel Wright", Position = Position.Atacker, BirthDate = new DateTime(1994, 12, 18), Player_TeamsId = 48 },
                new Players() { Id = 953, PlayerName = "Paul Thompson", Position = Position.Defender, BirthDate = new DateTime(1988, 10, 27), Player_TeamsId = 48 },
                new Players() { Id = 954, PlayerName = "Mark White", Position = Position.Midfielder, BirthDate = new DateTime(1986, 4, 5), Player_TeamsId = 48 },
                new Players() { Id = 955, PlayerName = "Donald Edwards", Position = Position.Goalkeeper, BirthDate = new DateTime(2005, 3, 6), Player_TeamsId = 48 },
                new Players() { Id = 956, PlayerName = "Steven Green", Position = Position.Atacker, BirthDate = new DateTime(1999, 7, 5), Player_TeamsId = 48 },
                new Players() { Id = 957, PlayerName = "Edward Harris", Position = Position.Defender, BirthDate = new DateTime(2007, 10, 11), Player_TeamsId = 48 },
                new Players() { Id = 958, PlayerName = "Brian Lewis", Position = Position.Midfielder, BirthDate = new DateTime(2006, 3, 1), Player_TeamsId = 48 },
                new Players() { Id = 959, PlayerName = "Ronald Clarke", Position = Position.Goalkeeper, BirthDate = new DateTime(1997, 3, 7), Player_TeamsId = 48 },
                new Players() { Id = 960, PlayerName = "Anthony Hall", Position = Position.Atacker, BirthDate = new DateTime(1998, 8, 26), Player_TeamsId = 48 },
                new Players() { Id = 961, PlayerName = "Marco Rossi", Position = Position.Defender, BirthDate = new DateTime(1993, 5, 8), Player_TeamsId = 49 },
                new Players() { Id = 962, PlayerName = "Luca Russo", Position = Position.Midfielder, BirthDate = new DateTime(1986, 3, 14), Player_TeamsId = 49 },
                new Players() { Id = 963, PlayerName = "Matteo Ferrari", Position = Position.Goalkeeper, BirthDate = new DateTime(2003, 10, 7), Player_TeamsId = 49 },
                new Players() { Id = 964, PlayerName = "Alessandro Esposito", Position = Position.Atacker, BirthDate = new DateTime(1996, 9, 12), Player_TeamsId = 49 },
                new Players() { Id = 965, PlayerName = "Giovanni Bianchi", Position = Position.Defender, BirthDate = new DateTime(1996, 4, 1), Player_TeamsId = 49 },
                new Players() { Id = 966, PlayerName = "Andrea Romano", Position = Position.Midfielder, BirthDate = new DateTime(1990, 3, 16), Player_TeamsId = 49 },
                new Players() { Id = 967, PlayerName = "Davide Colombo", Position = Position.Goalkeeper, BirthDate = new DateTime(1987, 6, 26), Player_TeamsId = 49 },
                new Players() { Id = 968, PlayerName = "Francesco Ricci", Position = Position.Atacker, BirthDate = new DateTime(1991, 7, 2), Player_TeamsId = 49 },
                new Players() { Id = 969, PlayerName = "Simone Marino", Position = Position.Defender, BirthDate = new DateTime(2005, 6, 2), Player_TeamsId = 49 },
                new Players() { Id = 970, PlayerName = "Gabriele Greco", Position = Position.Midfielder, BirthDate = new DateTime(1994, 8, 10), Player_TeamsId = 49 },
                new Players() { Id = 971, PlayerName = "Federico Bruno", Position = Position.Goalkeeper, BirthDate = new DateTime(1993, 4, 13), Player_TeamsId = 49 },
                new Players() { Id = 972, PlayerName = "Stefano Gallo", Position = Position.Atacker, BirthDate = new DateTime(2001, 2, 23), Player_TeamsId = 49 },
                new Players() { Id = 973, PlayerName = "Roberto Costa", Position = Position.Defender, BirthDate = new DateTime(1996, 10, 24), Player_TeamsId = 49 },
                new Players() { Id = 974, PlayerName = "Antonio DeLuca", Position = Position.Midfielder, BirthDate = new DateTime(1988, 9, 26), Player_TeamsId = 49 },
                new Players() { Id = 975, PlayerName = "Paolo Mancini", Position = Position.Goalkeeper, BirthDate = new DateTime(1989, 4, 15), Player_TeamsId = 49 },
                new Players() { Id = 976, PlayerName = "Riccardo Lombardi", Position = Position.Atacker, BirthDate = new DateTime(1998, 12, 14), Player_TeamsId = 49 },
                new Players() { Id = 977, PlayerName = "Giuseppe Moretti", Position = Position.Defender, BirthDate = new DateTime(2001, 10, 4), Player_TeamsId = 49 },
                new Players() { Id = 978, PlayerName = "Nicola Barbieri", Position = Position.Midfielder, BirthDate = new DateTime(2005, 9, 28), Player_TeamsId = 49 },
                new Players() { Id = 979, PlayerName = "Fabio Fontana", Position = Position.Goalkeeper, BirthDate = new DateTime(2003, 8, 17), Player_TeamsId = 49 },
                new Players() { Id = 980, PlayerName = "Salvatore Santoro", Position = Position.Atacker, BirthDate = new DateTime(2000, 9, 24), Player_TeamsId = 49 }
            });

            modelBuilder.Entity<Stadiums>().HasData(new List<Stadiums>()
            {
                new Stadiums() { Id = 1, StadiumName = "Unirea Stadium", StadiumLocation = "Odobesti", Capacity = 10, IsInternal = true},
                new Stadiums() { Id = 11, StadiumName = "Unirea U21 Stadium", StadiumLocation = "Odobesti", Capacity = 10, IsInternal = true },
                new Stadiums() { Id = 21, StadiumName = "Unirea Youth Stadium", StadiumLocation = "Odobesti", Capacity = 10, IsInternal = true },
                //league
                new Stadiums() { Id = 2, StadiumName = "Stadionul București", StadiumLocation = "București", Capacity = 18, IsInternal = false },
                new Stadiums() { Id = 3, StadiumName = "Stadionul Cluj", StadiumLocation = "Cluj", Capacity = 13, IsInternal = false },
                new Stadiums() { Id = 4, StadiumName = "Stadionul Iași", StadiumLocation = "Iași", Capacity = 8, IsInternal = false },
                new Stadiums() { Id = 5, StadiumName = "Stadionul Timișoara", StadiumLocation = "Timișoara", Capacity = 25, IsInternal = false },
                new Stadiums() { Id = 6, StadiumName = "Stadionul Ploiești", StadiumLocation = "Ploiești", Capacity = 8, IsInternal = false },
                new Stadiums() { Id = 7, StadiumName = "Stadionul Oradea", StadiumLocation = "Oradea", Capacity = 14, IsInternal = false },
                new Stadiums() { Id = 8, StadiumName = "Stadionul Brașov", StadiumLocation = "Brașov", Capacity = 30, IsInternal = false },
                new Stadiums() { Id = 9, StadiumName = "Stadionul Constanța", StadiumLocation = "Constanța", Capacity = 29, IsInternal = false },
                new Stadiums() { Id = 10, StadiumName = "Stadionul Sibiu", StadiumLocation = "Sibiu", Capacity = 27, IsInternal = false },
                //u21 league
                new Stadiums() { Id = 12, StadiumName = "Stadionul Bacău", StadiumLocation = "Bacău", Capacity = 12, IsInternal = false },
                new Stadiums() { Id = 13, StadiumName = "Stadionul Galați", StadiumLocation = "Galați", Capacity = 21, IsInternal = false },
                new Stadiums() { Id = 14, StadiumName = "Stadionul Craiova", StadiumLocation = "Craiova", Capacity = 28, IsInternal = false },
                new Stadiums() { Id = 15, StadiumName = "Stadionul Baia Mare", StadiumLocation = "Baia Mare", Capacity = 21, IsInternal = false },
                new Stadiums() { Id = 16, StadiumName = "Stadionul Vaslui", StadiumLocation = "Vaslui", Capacity = 24, IsInternal = false },
                new Stadiums() { Id = 17, StadiumName = "Stadionul Târgu Mureș", StadiumLocation = "Târgu Mureș", Capacity = 22, IsInternal = false },
                new Stadiums() { Id = 18, StadiumName = "Stadionul Slatina", StadiumLocation = "Slatina", Capacity = 25, IsInternal = false },
                new Stadiums() { Id = 19, StadiumName = "Stadionul Botoșani", StadiumLocation = "Botoșani", Capacity = 18, IsInternal = false },
                new Stadiums() { Id = 20, StadiumName = "Stadionul Târgoviște", StadiumLocation = "Târgoviște", Capacity = 29, IsInternal = false },
                //kids league
                new Stadiums() { Id = 22, StadiumName = "Stadionul Alba Iulia", StadiumLocation = "Alba Iulia", Capacity = 12, IsInternal = false },
                new Stadiums() { Id = 23, StadiumName = "Stadionul Pitești", StadiumLocation = "Pitești", Capacity = 16, IsInternal = false },
                new Stadiums() { Id = 24, StadiumName = "Stadionul București", StadiumLocation = "București", Capacity = 11, IsInternal = false },
                new Stadiums() { Id = 25, StadiumName = "Stadionul Cluj", StadiumLocation = "Cluj", Capacity = 20, IsInternal = false },
                new Stadiums() { Id = 26, StadiumName = "Stadionul Iași", StadiumLocation = "Iași", Capacity = 20, IsInternal = false },
                new Stadiums() { Id = 27, StadiumName = "Stadionul Timișoara", StadiumLocation = "Timișoara", Capacity = 19, IsInternal = false },
                new Stadiums() { Id = 28, StadiumName = "Stadionul Ploiești", StadiumLocation = "Ploiești", Capacity = 18, IsInternal = false },
                new Stadiums() { Id = 29, StadiumName = "Stadionul Oradea", StadiumLocation = "Oradea", Capacity = 18, IsInternal = false },
                new Stadiums() { Id = 30, StadiumName = "Stadionul Brașov", StadiumLocation = "Brașov", Capacity = 21, IsInternal = false },
                //cup
                new Stadiums() { Id = 31, StadiumName = "Stadionul Galati", StadiumLocation = "Galati", Capacity = 22, IsInternal = false },
                new Stadiums() { Id = 32, StadiumName = "Stadionul Braila", StadiumLocation = "Braila", Capacity = 15, IsInternal = false },
                new Stadiums() { Id = 33, StadiumName = "Stadionul Giugiu", StadiumLocation = "Giugiu", Capacity = 17, IsInternal = false },
                new Stadiums() { Id = 34, StadiumName = "Stadionul Ploieti", StadiumLocation = "Ploieti", Capacity = 16, IsInternal = false },
                new Stadiums() { Id = 35, StadiumName = "Stadionul Focsani", StadiumLocation = "Focsani", Capacity = 14, IsInternal = false },
                new Stadiums() { Id = 36, StadiumName = "Stadionul Cluj", StadiumLocation = "Cluj", Capacity = 19, IsInternal = false },
                //cl
                new Stadiums() { Id = 41, StadiumName = "Stadionul Belgrad", StadiumLocation = "Belgrad", Capacity = 20, IsInternal = false },
                new Stadiums() { Id = 42, StadiumName = "Stadionul Zagreb", StadiumLocation = "Zagreb", Capacity = 12, IsInternal = false },
                new Stadiums() { Id = 43, StadiumName = "Stadionul Pireu", StadiumLocation = "Pireu", Capacity = 16, IsInternal = false },
                new Stadiums() { Id = 44, StadiumName = "Stadionul Istanbul", StadiumLocation = "Istanbul", Capacity = 11, IsInternal = false },
                new Stadiums() { Id = 45, StadiumName = "Stadionul Barcelona", StadiumLocation = "Barcelona", Capacity = 20, IsInternal = false },
                new Stadiums() { Id = 46, StadiumName = "Stadionul Munchen", StadiumLocation = "Munchen", Capacity = 20, IsInternal = false },
                new Stadiums() { Id = 47, StadiumName = "Stadionul Paris", StadiumLocation = "Paris", Capacity = 19, IsInternal = false },
                new Stadiums() { Id = 48, StadiumName = "Stadionul Manchester", StadiumLocation = "Manchester", Capacity = 18, IsInternal = false },
                new Stadiums() { Id = 49, StadiumName = "Stadionul Torino", StadiumLocation = "Torino", Capacity = 18, IsInternal = false }
            });

            modelBuilder.Entity<Seats>().HasData(new List<Seats>() {
                new Seats() { Id = 1, SeatType = SeatType.Vip, SeatName = "A1", SeatPrice = 150, Seat_StadiumsId = 1 },
                new Seats() { Id = 2, SeatType = SeatType.Vip, SeatName = "A2", SeatPrice = 150, Seat_StadiumsId = 1 },
                new Seats() { Id = 3, SeatType = SeatType.Standard, SeatName = "B1", SeatPrice = 50, Seat_StadiumsId = 1 },
                new Seats() { Id = 4, SeatType = SeatType.Standard, SeatName = "B2", SeatPrice = 50, Seat_StadiumsId = 1 },
                new Seats() { Id = 5, SeatType = SeatType.Standard, SeatName = "C1", SeatPrice = 50, Seat_StadiumsId = 1 },
                new Seats() { Id = 6, SeatType = SeatType.Standard, SeatName = "C2", SeatPrice = 50, Seat_StadiumsId = 1 },
                new Seats() { Id = 7, SeatType = SeatType.Standard, SeatName = "D1", SeatPrice = 50, Seat_StadiumsId = 1 },
                new Seats() { Id = 8, SeatType = SeatType.Standard, SeatName = "D2", SeatPrice = 50, Seat_StadiumsId = 1 },
                new Seats() { Id = 9, SeatType = SeatType.Standard, SeatName = "E1", SeatPrice = 50, Seat_StadiumsId = 1 },
                new Seats() { Id = 10, SeatType = SeatType.Standard, SeatName = "E2", SeatPrice = 50, Seat_StadiumsId = 1 },
                //u21
                new Seats() { Id = 11, SeatType = SeatType.Vip, SeatName = "A1", SeatPrice = 150, Seat_StadiumsId = 11 },
                new Seats() { Id = 12, SeatType = SeatType.Vip, SeatName = "A2", SeatPrice = 150, Seat_StadiumsId = 11 },
                new Seats() { Id = 13, SeatType = SeatType.Standard, SeatName = "B1", SeatPrice = 50, Seat_StadiumsId = 11 },
                new Seats() { Id = 14, SeatType = SeatType.Standard, SeatName = "B2", SeatPrice = 50, Seat_StadiumsId = 11 },
                new Seats() { Id = 15, SeatType = SeatType.Standard, SeatName = "C1", SeatPrice = 50, Seat_StadiumsId = 11 },
                new Seats() { Id = 16, SeatType = SeatType.Standard, SeatName = "C2", SeatPrice = 50, Seat_StadiumsId = 11 },
                new Seats() { Id = 17, SeatType = SeatType.Standard, SeatName = "D1", SeatPrice = 50, Seat_StadiumsId = 11 },
                new Seats() { Id = 18, SeatType = SeatType.Standard, SeatName = "D2", SeatPrice = 50, Seat_StadiumsId = 11 },
                new Seats() { Id = 19, SeatType = SeatType.Standard, SeatName = "E1", SeatPrice = 50, Seat_StadiumsId = 11 },
                new Seats() { Id = 20, SeatType = SeatType.Standard, SeatName = "E2", SeatPrice = 50, Seat_StadiumsId = 11 },
                //kids
                new Seats() { Id = 21, SeatType = SeatType.Vip, SeatName = "A1", SeatPrice = 150, Seat_StadiumsId = 21 },
                new Seats() { Id = 22, SeatType = SeatType.Vip, SeatName = "A2", SeatPrice = 150, Seat_StadiumsId = 21 },
                new Seats() { Id = 23, SeatType = SeatType.Standard, SeatName = "B1", SeatPrice = 50, Seat_StadiumsId = 21 },
                new Seats() { Id = 24, SeatType = SeatType.Standard, SeatName = "B2", SeatPrice = 50, Seat_StadiumsId = 21 },
                new Seats() { Id = 25, SeatType = SeatType.Standard, SeatName = "C1", SeatPrice = 50, Seat_StadiumsId = 21 },
                new Seats() { Id = 26, SeatType = SeatType.Standard, SeatName = "C2", SeatPrice = 50, Seat_StadiumsId = 21 },
                new Seats() { Id = 27, SeatType = SeatType.Standard, SeatName = "D1", SeatPrice = 50, Seat_StadiumsId = 21 },
                new Seats() { Id = 28, SeatType = SeatType.Standard, SeatName = "D2", SeatPrice = 50, Seat_StadiumsId = 21 },
                new Seats() { Id = 29, SeatType = SeatType.Standard, SeatName = "E1", SeatPrice = 50, Seat_StadiumsId = 21 },
                new Seats() { Id = 30, SeatType = SeatType.Standard, SeatName = "E2", SeatPrice = 50, Seat_StadiumsId = 21 }
            });

            modelBuilder.Entity<Games>().HasData(new List<Games>() {
                
            //program liga adults/u21/kids
            /*Etapa 3: 2 - 10, 3 - 1, 4 - 9, 5 - 8, 6 - 7
              Etapa 4: 10 - 7, 8 - 6, 9 - 5, 1 - 4, 2 - 3
              Etapa 5: 3 - 10, 4 - 2, 5 - 1, 6 - 9, 7 - 8
              Etapa 6: 10 - 8, 9 - 7, 1 - 6, 2 - 5, 3 - 4
              Etapa 7: 4 - 10, 5 - 3, 6 - 2, 7 - 1, 8 - 9
              Etapa 8: 10 - 9, 1 - 8, 2 - 7, 3 - 6, 4 - 5
              Etapa 9: 5 - 10, 6 - 4, 7 - 3, 8 - 2, 9 - 1
              Etapa 10: 10 - 1, 9 - 2, 8 - 3, 7 - 4, 6 - 5
              Etapa 11: 6 - 10, 5 - 7, 4 - 8, 3 - 9, 2 - 1
              Etapa 12: 10 - 2, 1 - 3, 9 - 4, 8 - 5, 7 - 6
              Etapa 13: 7 - 10, 6 - 8, 5 - 9, 4 - 1, 3 - 2
              Etapa 14: 10 - 3, 2 - 4, 1 - 5, 9 - 6, 8 - 7
              Etapa 15: 8 - 10, 7 - 9, 6 - 1, 5 - 2, 4 - 3
              Etapa 16: 10 - 4, 3 - 5, 2 - 6, 1 - 7, 9 - 8
              Etapa 17: 9 - 10, 8 - 1, 7 - 2, 6 - 3, 5 - 4
              Etapa 18: 10 - 5, 4 - 6, 3 - 7, 2 - 8, 1 - 9*/

                //etapa 1
                new Games() { Id = 1, GameDate = new DateTime(2025, 5, 1, 18, 0, 0), HomeTeamScore = 2, AwayTeamScore = 1, TicketsSold = 5, Game_HomeTeamId = 1, Game_AwayTeamId = 10,
                    Game_CompetitionsId = 1, Game_StadiumsId = 1, RefereeName = "Marius Popa", IsPlayed = true},
                new Games() { Id = 2, GameDate = new DateTime(2025, 5, 1, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 9, Game_HomeTeamId = 2, Game_AwayTeamId = 9,
                    Game_CompetitionsId = 1, Game_StadiumsId = 2, RefereeName = "Cătălin Gheorghe", IsPlayed = true},
                new Games() { Id = 3, GameDate = new DateTime(2025, 5, 1, 19, 0, 0), HomeTeamScore = 2, AwayTeamScore = 1, TicketsSold = 6, Game_HomeTeamId = 3, Game_AwayTeamId = 8,
                    Game_CompetitionsId = 1, Game_StadiumsId = 3, RefereeName = "Daniel Petrescu", IsPlayed = true},
                new Games() { Id = 4, GameDate = new DateTime(2025, 5, 1, 21, 0, 0), HomeTeamScore = 0, AwayTeamScore = 1, TicketsSold = 4, Game_HomeTeamId = 4, Game_AwayTeamId = 7,
                    Game_CompetitionsId = 1, Game_StadiumsId = 4, RefereeName = "Bogdan Neagu", IsPlayed = true},
                new Games() { Id = 5, GameDate = new DateTime(2025, 5, 1, 2, 0, 0), HomeTeamScore = 1, AwayTeamScore = 2, TicketsSold = 12, Game_HomeTeamId = 5, Game_AwayTeamId = 6,
                    Game_CompetitionsId = 1, Game_StadiumsId = 5, RefereeName = "Mihai Rusu", IsPlayed = true},
                new Games() { Id = 6,GameDate = new DateTime(2025, 5, 1, 0, 0, 0),HomeTeamScore = 0,AwayTeamScore = 0,TicketsSold = 5,Game_HomeTeamId = 11,Game_AwayTeamId = 20,
                    Game_CompetitionsId = 4,Game_StadiumsId = 11,RefereeName = "Paul Voicu" , IsPlayed = true },
                new Games() {Id = 7,GameDate = new DateTime(2025, 5, 1, 1, 0, 0),HomeTeamScore = 2,AwayTeamScore = 3,TicketsSold = 6,Game_HomeTeamId = 12,Game_AwayTeamId = 19,
                    Game_CompetitionsId = 4,Game_StadiumsId = 12,RefereeName = "Paul Voicu", IsPlayed = true},
                new Games() {Id = 8,GameDate = new DateTime(2025, 5, 1, 18, 0, 0),HomeTeamScore = 3,AwayTeamScore = 3,TicketsSold = 7,Game_HomeTeamId = 13,Game_AwayTeamId = 18,
                    Game_CompetitionsId = 4,Game_StadiumsId = 13,RefereeName = "Cosmin Ionescu", IsPlayed = true},
                new Games() {Id = 9,GameDate = new DateTime(2025, 5, 1, 6, 0, 0),HomeTeamScore = 2,AwayTeamScore = 1,TicketsSold = 8,Game_HomeTeamId = 14,Game_AwayTeamId = 17,
                    Game_CompetitionsId = 4,Game_StadiumsId = 14,RefereeName = "Radu Marin", IsPlayed = true},
                new Games() {Id = 10,GameDate = new DateTime(2025, 5, 1, 11, 0, 0),HomeTeamScore = 2,AwayTeamScore = 3,TicketsSold = 9,Game_HomeTeamId = 15,Game_AwayTeamId = 16,
                    Game_CompetitionsId = 4,Game_StadiumsId = 15,RefereeName = "Silviu Barbu", IsPlayed = true},
                new Games() {Id = 11,GameDate = new DateTime(2025, 5, 1, 3, 0, 0),HomeTeamScore = 2,AwayTeamScore = 1,TicketsSold = 5,Game_HomeTeamId = 21,Game_AwayTeamId = 26,
                    Game_CompetitionsId = 5,Game_StadiumsId = 21,RefereeName = "Florin Stan", IsPlayed = true},
                new Games() {Id = 12,GameDate = new DateTime(2025, 5, 1, 20, 0, 0),HomeTeamScore = 2,AwayTeamScore = 1,TicketsSold = 4,Game_HomeTeamId = 22,Game_AwayTeamId = 27,
                    Game_CompetitionsId = 5,Game_StadiumsId = 22,RefereeName = "Andrei Dumitrescu", IsPlayed = true},
                new Games() {Id = 13,GameDate = new DateTime(2025, 5, 1, 5, 0, 0),HomeTeamScore = 2,AwayTeamScore = 0,TicketsSold = 3,Game_HomeTeamId = 23,Game_AwayTeamId = 28,
                    Game_CompetitionsId = 5,Game_StadiumsId = 23,RefereeName = "Alexandru Vasilescu", IsPlayed = true},
                new Games() {Id = 14,GameDate = new DateTime(2025, 5, 1, 6, 0, 0),HomeTeamScore = 2,AwayTeamScore = 1,TicketsSold = 4,Game_HomeTeamId = 24,Game_AwayTeamId = 29,
                    Game_CompetitionsId = 5,Game_StadiumsId = 24,RefereeName = "George Ilie", IsPlayed = true},
                new Games() {Id = 15,GameDate = new DateTime(2025, 5, 1, 8, 0, 0),HomeTeamScore = 1,AwayTeamScore = 2,TicketsSold = 5,Game_HomeTeamId = 25,Game_AwayTeamId = 30,
                    Game_CompetitionsId = 5,Game_StadiumsId = 25,RefereeName = "Iulian Nistor", IsPlayed = true},
                //etapa 2

                new Games() { Id = 16, GameDate = new DateTime(2025, 5, 8, 18, 0, 0), HomeTeamScore = 2, AwayTeamScore = 1, TicketsSold = 22, Game_HomeTeamId = 10, Game_AwayTeamId = 6, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 10, RefereeName = "Cristian Ene", IsPlayed = true },
                new Games() { Id = 17, GameDate = new DateTime(2025, 5, 8, 20, 0, 0), HomeTeamScore = 1, AwayTeamScore = 3, TicketsSold = 12, Game_HomeTeamId = 7, Game_AwayTeamId = 5, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 7, RefereeName = "Paul Voicu", IsPlayed = true },
                new Games() { Id = 18, GameDate = new DateTime(2025, 5, 8, 19, 0, 0), HomeTeamScore = 2, AwayTeamScore = 2, TicketsSold = 23, Game_HomeTeamId = 8, Game_AwayTeamId = 4, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 8, RefereeName = "Iulian Nistor", IsPlayed = true },
                new Games() { Id = 19, GameDate = new DateTime(2025, 5, 8, 21, 0, 0), HomeTeamScore = 0, AwayTeamScore = 1, TicketsSold = 17, Game_HomeTeamId = 9, Game_AwayTeamId = 3, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 9, RefereeName = "Mihai Rusu", IsPlayed = true },
                new Games() { Id = 20, GameDate = new DateTime(2025, 5, 8, 2, 0, 0),  HomeTeamScore = 4, AwayTeamScore = 1, TicketsSold = 8, Game_HomeTeamId = 1, Game_AwayTeamId = 2, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 1, RefereeName = "Silviu Barbu", IsPlayed = true },
                new Games() { Id = 21, GameDate = new DateTime(2025, 5, 8, 0, 0, 0),  HomeTeamScore = 2, AwayTeamScore = 0, TicketsSold = 20, Game_HomeTeamId = 20,Game_AwayTeamId = 16, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 20,RefereeName = "Cătălin Gheorghe" , IsPlayed = true },
                new Games() { Id = 22, GameDate = new DateTime(2025, 5, 8, 1, 0, 0),  HomeTeamScore = 2, AwayTeamScore = 2, TicketsSold = 16, Game_HomeTeamId = 17,Game_AwayTeamId = 15, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 17,RefereeName = "Cătălin Gheorghe", IsPlayed = true },
                new Games() { Id = 23, GameDate = new DateTime(2025, 5, 8, 18, 0, 0), HomeTeamScore = 0, AwayTeamScore = 3, TicketsSold = 14, Game_HomeTeamId = 18,Game_AwayTeamId = 14, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 18,RefereeName = "Daniel Petrescu", IsPlayed = true },
                new Games() { Id = 24, GameDate = new DateTime(2025, 5, 8, 6, 0, 0),  HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 9, Game_HomeTeamId = 19,Game_AwayTeamId = 13, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 19,RefereeName = "Florin Stan", IsPlayed = true },
                new Games() { Id = 25, GameDate = new DateTime(2025, 5, 8, 11, 0, 0), HomeTeamScore = 0, AwayTeamScore = 2, TicketsSold = 5, Game_HomeTeamId = 11,Game_AwayTeamId = 12, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 11,RefereeName = "Cristian Ene", IsPlayed = true },
                new Games() { Id = 26, GameDate = new DateTime(2025, 5, 8, 3, 0, 0),  HomeTeamScore = 3, AwayTeamScore = 0, TicketsSold = 19, Game_HomeTeamId = 30,Game_AwayTeamId = 26, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 30,RefereeName = "Alexandru Vasilescu", IsPlayed = true },
                new Games() { Id = 27, GameDate = new DateTime(2025, 5, 8, 20, 0, 0), HomeTeamScore = 2, AwayTeamScore = 1, TicketsSold = 16, Game_HomeTeamId = 27,Game_AwayTeamId = 25, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 27,RefereeName = "Marius Popa", IsPlayed = true },
                new Games() { Id = 28, GameDate = new DateTime(2025, 5, 8, 5, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 2, TicketsSold = 11, Game_HomeTeamId = 28,Game_AwayTeamId = 24, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 28,RefereeName = "Andrei Dumitrescu", IsPlayed = true },
                new Games() { Id = 29, GameDate = new DateTime(2025, 5, 8, 6, 0, 0),  HomeTeamScore = 1, AwayTeamScore = 3, TicketsSold = 14, Game_HomeTeamId = 29,Game_AwayTeamId = 23, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 29,RefereeName = "George Ilie", IsPlayed = true },
                new Games() { Id = 30, GameDate = new DateTime(2025, 5, 8, 8, 0, 0),  HomeTeamScore = 2, AwayTeamScore = 2, TicketsSold = 9, Game_HomeTeamId = 21,Game_AwayTeamId = 22, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 21,RefereeName = "Radu Marin", IsPlayed = true },

                //etapa 3
                new Games() { Id = 31, GameDate = new DateTime(2025, 5, 15, 18, 0, 0), HomeTeamScore = 1, AwayTeamScore = 2, TicketsSold = 16, Game_HomeTeamId = 2, Game_AwayTeamId = 10, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 2, RefereeName = "Bogdan Neagu", IsPlayed = true },
                new Games() { Id = 32, GameDate = new DateTime(2025, 5, 15, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 1, TicketsSold = 10, Game_HomeTeamId = 3, Game_AwayTeamId = 1, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 3, RefereeName = "Cosmin Ionescu", IsPlayed = true },
                new Games() { Id = 33, GameDate = new DateTime(2025, 5, 15, 19, 0, 0), HomeTeamScore = 2, AwayTeamScore = 2, TicketsSold = 7, Game_HomeTeamId = 4, Game_AwayTeamId = 9, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 4, RefereeName = "Andrei Dumitrescu", IsPlayed = true },
                new Games() { Id = 34, GameDate = new DateTime(2025, 5, 15, 21, 0, 0), HomeTeamScore = 3, AwayTeamScore = 0, TicketsSold = 21, Game_HomeTeamId = 5, Game_AwayTeamId = 8, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 5, RefereeName = "Alexandru Vasilescu", IsPlayed = true },
                new Games() { Id = 35, GameDate = new DateTime(2025, 5, 15, 2, 0, 0), HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 5, Game_HomeTeamId = 6, Game_AwayTeamId = 7, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 6, RefereeName = "Marius Popa", IsPlayed = true },
                new Games() { Id = 36, GameDate = new DateTime(2025, 5, 15, 0, 0, 0), HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 8, Game_HomeTeamId = 12, Game_AwayTeamId = 20, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 12, RefereeName = "Paul Voicu", IsPlayed = true },
                new Games() { Id = 37, GameDate = new DateTime(2025, 5, 15, 1, 0, 0), HomeTeamScore = 0, AwayTeamScore = 2, TicketsSold = 11, Game_HomeTeamId = 13, Game_AwayTeamId = 11, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 13, RefereeName = "Paul Voicu", IsPlayed = true },
                new Games() { Id = 38, GameDate = new DateTime(2025, 5, 15, 18, 0, 0), HomeTeamScore = 4, AwayTeamScore = 3, TicketsSold = 25, Game_HomeTeamId = 14, Game_AwayTeamId = 19, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 14, RefereeName = "Daniel Petrescu", IsPlayed = true },
                new Games() { Id = 39, GameDate = new DateTime(2025, 5, 15, 6, 0, 0), HomeTeamScore = 2, AwayTeamScore = 0, TicketsSold = 15, Game_HomeTeamId = 15, Game_AwayTeamId = 18, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 15, RefereeName = "Radu Marin", IsPlayed = true },
                new Games() { Id = 40, GameDate = new DateTime(2025, 5, 15, 11, 0, 0), HomeTeamScore = 1, AwayTeamScore = 2, TicketsSold = 12, Game_HomeTeamId = 16, Game_AwayTeamId = 17, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 16, RefereeName = "Cosmin Ionescu", IsPlayed = true },
                new Games() { Id = 41, GameDate = new DateTime(2025, 5, 15, 3, 0, 0), HomeTeamScore = 0, AwayTeamScore = 3, TicketsSold = 7, Game_HomeTeamId = 22, Game_AwayTeamId = 30, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 22, RefereeName = "Silviu Barbu", IsPlayed = true },
                new Games() { Id = 42, GameDate = new DateTime(2025, 5, 15, 20, 0, 0), HomeTeamScore = 2, AwayTeamScore = 2, TicketsSold = 17, Game_HomeTeamId = 23, Game_AwayTeamId = 21, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 23, RefereeName = "Bogdan Neagu", IsPlayed = true },
                new Games() { Id = 43, GameDate = new DateTime(2025, 5, 15, 5, 0, 0), HomeTeamScore = 0, AwayTeamScore = 1, TicketsSold = 16, Game_HomeTeamId = 24, Game_AwayTeamId = 29, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 24, RefereeName = "Cătălin Gheorghe", IsPlayed = true },
                new Games() { Id = 44, GameDate = new DateTime(2025, 5, 15, 6, 0, 0), HomeTeamScore = 1, AwayTeamScore = 0, TicketsSold = 10, Game_HomeTeamId = 25, Game_AwayTeamId = 28, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 25, RefereeName = "Cristian Ene", IsPlayed = true },
                new Games() { Id = 45, GameDate = new DateTime(2025, 5, 15, 8, 0, 0), HomeTeamScore = 3, AwayTeamScore = 2, TicketsSold = 14, Game_HomeTeamId = 26, Game_AwayTeamId = 27, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 26, RefereeName = "Mihai Rusu", IsPlayed = true },

                //etapa 4
                new Games() { Id = 46, GameDate = new DateTime(2025, 5, 22, 18, 0, 0), HomeTeamScore = 2, AwayTeamScore = 1, TicketsSold = 16, Game_HomeTeamId = 10, Game_AwayTeamId = 7, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 10, RefereeName = "Florin Stan", IsPlayed = true },
                new Games() { Id = 47, GameDate = new DateTime(2025, 5, 22, 20, 0, 0), HomeTeamScore = 3, AwayTeamScore = 0, TicketsSold = 19, Game_HomeTeamId = 8, Game_AwayTeamId = 6, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 8, RefereeName = "Iulian Nistor", IsPlayed = true },
                new Games() { Id = 48, GameDate = new DateTime(2025, 5, 22, 19, 0, 0), HomeTeamScore = 2, AwayTeamScore = 2, TicketsSold = 25, Game_HomeTeamId = 9, Game_AwayTeamId = 5, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 9, RefereeName = "George Ilie", IsPlayed = true },
                new Games() { Id = 49, GameDate = new DateTime(2025, 5, 22, 21, 0, 0), HomeTeamScore = 1, AwayTeamScore = 2, TicketsSold = 7, Game_HomeTeamId = 1, Game_AwayTeamId = 4, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 1, RefereeName = "Alexandru Vasilescu", IsPlayed = true },
                new Games() { Id = 50, GameDate = new DateTime(2025, 5, 22, 2, 0, 0), HomeTeamScore = 2, AwayTeamScore = 0, TicketsSold = 12, Game_HomeTeamId = 2, Game_AwayTeamId = 3, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 2, RefereeName = "Radu Marin", IsPlayed = true },
                new Games() { Id = 51, GameDate = new DateTime(2025, 5, 22, 0, 0, 0), HomeTeamScore = 2, AwayTeamScore = 1, TicketsSold = 18, Game_HomeTeamId = 20, Game_AwayTeamId = 17, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 20, RefereeName = "Paul Voicu", IsPlayed = true },
                new Games() { Id = 52, GameDate = new DateTime(2025, 5, 22, 1, 0, 0), HomeTeamScore = 0, AwayTeamScore = 1, TicketsSold = 11, Game_HomeTeamId = 18, Game_AwayTeamId = 16, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 18, RefereeName = "Paul Voicu", IsPlayed = true },
                new Games() { Id = 53, GameDate = new DateTime(2025, 5, 22, 18, 0, 0), HomeTeamScore = 1, AwayTeamScore = 2, TicketsSold = 17, Game_HomeTeamId = 19, Game_AwayTeamId = 15, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 19, RefereeName = "Bogdan Neagu", IsPlayed = true },
                new Games() { Id = 54, GameDate = new DateTime(2025, 5, 22, 6, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 4, Game_HomeTeamId = 11, Game_AwayTeamId = 14, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 11, RefereeName = "Cristian Ene", IsPlayed = true },
                new Games() { Id = 55, GameDate = new DateTime(2025, 5, 22, 11, 0, 0), HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 10, Game_HomeTeamId = 12, Game_AwayTeamId = 13, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 12, RefereeName = "Silviu Barbu", IsPlayed = true },
                new Games() { Id = 56, GameDate = new DateTime(2025, 5, 22, 3, 0, 0), HomeTeamScore = 0, AwayTeamScore = 2, TicketsSold = 16, Game_HomeTeamId = 30, Game_AwayTeamId = 27, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 30, RefereeName = "Andrei Dumitrescu", IsPlayed = true },
                new Games() { Id = 57, GameDate = new DateTime(2025, 5, 22, 20, 0, 0), HomeTeamScore = 2, AwayTeamScore = 0, TicketsSold = 13, Game_HomeTeamId = 28, Game_AwayTeamId = 26, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 28, RefereeName = "Daniel Petrescu", IsPlayed = true },
                new Games() { Id = 58, GameDate = new DateTime(2025, 5, 22, 5, 0, 0), HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 7, Game_HomeTeamId = 29, Game_AwayTeamId = 25, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 29, RefereeName = "Cosmin Ionescu", IsPlayed = true },
                new Games() { Id = 59, GameDate = new DateTime(2025, 5, 22, 6, 0, 0), HomeTeamScore = 0, AwayTeamScore = 1, TicketsSold = 7, Game_HomeTeamId = 21, Game_AwayTeamId = 24, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 21, RefereeName = "Mihai Rusu", IsPlayed = true },
                new Games() { Id = 60, GameDate = new DateTime(2025, 5, 22, 8, 0, 0), HomeTeamScore = 2, AwayTeamScore = 2, TicketsSold = 13, Game_HomeTeamId = 22, Game_AwayTeamId = 23, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 22, RefereeName = "Iulian Nistor", IsPlayed = true },

                //etapa 5
                new Games() { Id = 61, GameDate = new DateTime(2025, 5, 29, 18, 0, 0), HomeTeamScore = 2, AwayTeamScore = 0, TicketsSold = 10, Game_HomeTeamId = 3, Game_AwayTeamId = 10, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 3, RefereeName = "Cătălin Gheorghe", IsPlayed = true },
                new Games() { Id = 62, GameDate = new DateTime(2025, 5, 29, 20, 0, 0), HomeTeamScore = 1, AwayTeamScore = 3, TicketsSold = 6, Game_HomeTeamId = 4, Game_AwayTeamId = 2, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 4, RefereeName = "George Ilie", IsPlayed = true },
                new Games() { Id = 63, GameDate = new DateTime(2025, 5, 29, 19, 0, 0), HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 19, Game_HomeTeamId = 5, Game_AwayTeamId = 1, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 5, RefereeName = "Florin Stan", IsPlayed = true },
                new Games() { Id = 64, GameDate = new DateTime(2025, 5, 29, 21, 0, 0), HomeTeamScore = 0, AwayTeamScore = 1, TicketsSold = 7, Game_HomeTeamId = 6, Game_AwayTeamId = 9, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 6, RefereeName = "Marius Popa", IsPlayed = true },
                new Games() { Id = 65, GameDate = new DateTime(2025, 5, 29, 2, 0, 0), HomeTeamScore = 2, AwayTeamScore = 2, TicketsSold = 8, Game_HomeTeamId = 7, Game_AwayTeamId = 8, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 7, RefereeName = "Marius Popa", IsPlayed = true },
                new Games() { Id = 66, GameDate = new DateTime(2025, 5, 29, 0, 0, 0), HomeTeamScore = 1, AwayTeamScore = 0, TicketsSold = 14, Game_HomeTeamId = 13, Game_AwayTeamId = 20, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 13, RefereeName = "Paul Voicu", IsPlayed = true },
                new Games() { Id = 67, GameDate = new DateTime(2025, 5, 29, 1, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 28, Game_HomeTeamId = 14, Game_AwayTeamId = 12, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 14, RefereeName = "Paul Voicu", IsPlayed = true },
                new Games() { Id = 68, GameDate = new DateTime(2025, 5, 29, 18, 0, 0), HomeTeamScore = 2, AwayTeamScore = 1, TicketsSold = 20, Game_HomeTeamId = 15, Game_AwayTeamId = 11, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 15, RefereeName = "Radu Marin", IsPlayed = true },
                new Games() { Id = 69, GameDate = new DateTime(2025, 5, 29, 6, 0, 0), HomeTeamScore = 0, AwayTeamScore = 3, TicketsSold = 24, Game_HomeTeamId = 16, Game_AwayTeamId = 19, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 16, RefereeName = "Cătălin Gheorghe", IsPlayed = true },
                new Games() { Id = 70, GameDate = new DateTime(2025, 5, 29, 11, 0, 0), HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 19, Game_HomeTeamId = 17, Game_AwayTeamId = 18, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 17, RefereeName = "Silviu Barbu", IsPlayed = true },
                new Games() { Id = 71, GameDate = new DateTime(2025, 5, 29, 3, 0, 0), HomeTeamScore = 2, AwayTeamScore = 0, TicketsSold = 11, Game_HomeTeamId = 23, Game_AwayTeamId = 30, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 23, RefereeName = "Cosmin Ionescu", IsPlayed = true },
                new Games() { Id = 72, GameDate = new DateTime(2025, 5, 29, 20, 0, 0), HomeTeamScore = 2, AwayTeamScore = 2, TicketsSold = 12, Game_HomeTeamId = 24, Game_AwayTeamId = 22, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 24, RefereeName = "Iulian Nistor", IsPlayed = true },
                new Games() { Id = 73, GameDate = new DateTime(2025, 5, 29, 5, 0, 0), HomeTeamScore = 3, AwayTeamScore = 1, TicketsSold = 9, Game_HomeTeamId = 25, Game_AwayTeamId = 21, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 25, RefereeName = "Alexandru Vasilescu", IsPlayed = true },
                new Games() { Id = 74, GameDate = new DateTime(2025, 5, 29, 6, 0, 0), HomeTeamScore = 1, AwayTeamScore = 2, TicketsSold = 11, Game_HomeTeamId = 26, Game_AwayTeamId = 29, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 26, RefereeName = "Daniel Petrescu", IsPlayed = true },
                new Games() { Id = 75, GameDate = new DateTime(2025, 5, 29, 8, 0, 0), HomeTeamScore = 2, AwayTeamScore = 1, TicketsSold = 8, Game_HomeTeamId = 27, Game_AwayTeamId = 28, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 27, RefereeName = "Bogdan Neagu", IsPlayed = true },

                //etapa 6
                new Games() { Id = 76, GameDate = new DateTime(2025, 6, 6, 18, 0, 0), HomeTeamScore = 2, AwayTeamScore = 1, TicketsSold = 17, Game_HomeTeamId = 10, Game_AwayTeamId = 8, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 10, RefereeName = "Cristian Ene", IsPlayed = true },
                new Games() { Id = 77, GameDate = new DateTime(2025, 6, 6, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 3, TicketsSold = 19, Game_HomeTeamId = 9, Game_AwayTeamId = 7, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 9, RefereeName = "Mihai Rusu", IsPlayed = true },
                new Games() { Id = 78, GameDate = new DateTime(2025, 6, 6, 19, 0, 0), HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 8, Game_HomeTeamId = 1, Game_AwayTeamId = 6, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 1, RefereeName = "George Ilie", IsPlayed = true },
                new Games() { Id = 79, GameDate = new DateTime(2025, 6, 6, 21, 0, 0), HomeTeamScore = 0, AwayTeamScore = 2, TicketsSold = 6, Game_HomeTeamId = 2, Game_AwayTeamId = 5, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 2, RefereeName = "Florin Stan", IsPlayed = true },
                new Games() { Id = 80, GameDate = new DateTime(2025, 6, 6, 2, 0, 0), HomeTeamScore = 2, AwayTeamScore = 2, TicketsSold = 11, Game_HomeTeamId = 3, Game_AwayTeamId = 4, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 3, RefereeName = "Andrei Dumitrescu", IsPlayed = true },
                new Games() { Id = 81, GameDate = new DateTime(2025, 6, 6, 0, 0, 0), HomeTeamScore = 1, AwayTeamScore = 0, TicketsSold = 21, Game_HomeTeamId = 20, Game_AwayTeamId = 18, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 20, RefereeName = "Radu Marin", IsPlayed = true },
                new Games() { Id = 82, GameDate = new DateTime(2025, 6, 6, 1, 0, 0), HomeTeamScore = 2, AwayTeamScore = 1, TicketsSold = 13, Game_HomeTeamId = 19, Game_AwayTeamId = 17, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 19, RefereeName = "Radu Marin", IsPlayed = true },
                new Games() { Id = 83, GameDate = new DateTime(2025, 6, 6, 18, 0, 0), HomeTeamScore = 0, AwayTeamScore = 2, TicketsSold = 8, Game_HomeTeamId = 11, Game_AwayTeamId = 16, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 11, RefereeName = "Paul Voicu", IsPlayed = true },
                new Games() { Id = 84, GameDate = new DateTime(2025, 6, 6, 6, 0, 0), HomeTeamScore = 1, AwayTeamScore = 0, TicketsSold = 10, Game_HomeTeamId = 12, Game_AwayTeamId = 15, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 12, RefereeName = "Florin Stan", IsPlayed = true },
                new Games() { Id = 85, GameDate = new DateTime(2025, 6, 6, 11, 0, 0), HomeTeamScore = 2, AwayTeamScore = 1, TicketsSold = 18, Game_HomeTeamId = 13, Game_AwayTeamId = 14, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 13, RefereeName = "Cosmin Ionescu", IsPlayed = true },
                new Games() { Id = 86, GameDate = new DateTime(2025, 6, 6, 3, 0, 0), HomeTeamScore = 3, AwayTeamScore = 2, TicketsSold = 15, Game_HomeTeamId = 30, Game_AwayTeamId = 28, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 30, RefereeName = "Iulian Nistor", IsPlayed = true },
                new Games() { Id = 87, GameDate = new DateTime(2025, 6, 6, 20, 0, 0), HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 13, Game_HomeTeamId = 29, Game_AwayTeamId = 27, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 29, RefereeName = "George Ilie", IsPlayed = true },
                new Games() { Id = 88, GameDate = new DateTime(2025, 6, 6, 5, 0, 0), HomeTeamScore = 0, AwayTeamScore = 1, TicketsSold = 7, Game_HomeTeamId = 21, Game_AwayTeamId = 26, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 21, RefereeName = "Marius Popa", IsPlayed = true },
                new Games() { Id = 89, GameDate = new DateTime(2025, 6, 6, 6, 0, 0), HomeTeamScore = 2, AwayTeamScore = 2, TicketsSold = 11, Game_HomeTeamId = 22, Game_AwayTeamId = 25, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 22, RefereeName = "Bogdan Neagu", IsPlayed = true },
                new Games() { Id = 90, GameDate = new DateTime(2025, 6, 6, 8, 0, 0), HomeTeamScore = 2, AwayTeamScore = 1, TicketsSold = 7, Game_HomeTeamId = 23, Game_AwayTeamId = 24, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 23, RefereeName = "Silviu Barbu", IsPlayed = true },

                //etapa 7
                new Games() { Id = 91, GameDate = new DateTime(2025, 6, 13, 18, 0, 0), HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 5, Game_HomeTeamId = 4, Game_AwayTeamId = 10, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 4, RefereeName = "Andrei Dumitrescu", IsPlayed = true },
                new Games() { Id = 92, GameDate = new DateTime(2025, 6, 13, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 2, TicketsSold = 23, Game_HomeTeamId = 5, Game_AwayTeamId = 3, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 5, RefereeName = "Daniel Petrescu", IsPlayed = true },
                new Games() { Id = 93, GameDate = new DateTime(2025, 6, 13, 19, 0, 0), HomeTeamScore = 2, AwayTeamScore = 1, TicketsSold = 15, Game_HomeTeamId = 6, Game_AwayTeamId = 2, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 6, RefereeName = "Cătălin Gheorghe", IsPlayed = true },
                new Games() { Id = 94, GameDate = new DateTime(2025, 6, 13, 21, 0, 0), HomeTeamScore = 3, AwayTeamScore = 0, TicketsSold = 12, Game_HomeTeamId = 7, Game_AwayTeamId = 1, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 7, RefereeName = "Alexandru Vasilescu", IsPlayed = true },
                new Games() { Id = 95, GameDate = new DateTime(2025, 6, 13, 2, 0, 0), HomeTeamScore = 2, AwayTeamScore = 2, TicketsSold = 19, Game_HomeTeamId = 8, Game_AwayTeamId = 9, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 8, RefereeName = "Mihai Rusu", IsPlayed = true },
                new Games() { Id = 96, GameDate = new DateTime(2025, 6, 13, 0, 0, 0), HomeTeamScore = 0, AwayTeamScore = 1, TicketsSold = 25, Game_HomeTeamId = 14, Game_AwayTeamId = 20, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 14, RefereeName = "Cristian Ene", IsPlayed = true },
                new Games() { Id = 97, GameDate = new DateTime(2025, 6, 13, 1, 0, 0), HomeTeamScore = 1, AwayTeamScore = 2, TicketsSold = 19, Game_HomeTeamId = 15, Game_AwayTeamId = 13, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 15, RefereeName = "Cristian Ene", IsPlayed = true },
                new Games() { Id = 98, GameDate = new DateTime(2025, 6, 13, 18, 0, 0), HomeTeamScore = 2, AwayTeamScore = 0, TicketsSold = 22, Game_HomeTeamId = 16, Game_AwayTeamId = 12, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 16, RefereeName = "Paul Voicu", IsPlayed = true },
                new Games() { Id = 99, GameDate = new DateTime(2025, 6, 13, 6, 0, 0), HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 17, Game_HomeTeamId = 17, Game_AwayTeamId = 11, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 17, RefereeName = "Daniel Petrescu", IsPlayed = true },
                new Games() { Id = 100, GameDate = new DateTime(2025, 5, 13, 11, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 14, Game_HomeTeamId = 18, Game_AwayTeamId = 19, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 18, RefereeName = "Mihai Rusu", IsPlayed = true },
                new Games() { Id = 101, GameDate = new DateTime(2025, 6, 13, 3, 0, 0), HomeTeamScore = 2, AwayTeamScore = 2, TicketsSold = 19, Game_HomeTeamId = 24, Game_AwayTeamId = 30, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 24, RefereeName = "Alexandru Vasilescu", IsPlayed = true },
                new Games() { Id = 102, GameDate = new DateTime(2025, 6, 13, 20, 0, 0), HomeTeamScore = 3, AwayTeamScore = 1, TicketsSold = 16, Game_HomeTeamId = 25, Game_AwayTeamId = 23, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 25, RefereeName = "George Ilie", IsPlayed = true },
                new Games() { Id = 103, GameDate = new DateTime(2025, 6, 13, 5, 0, 0), HomeTeamScore = 1, AwayTeamScore = 0, TicketsSold = 16, Game_HomeTeamId = 26, Game_AwayTeamId = 22, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 26, RefereeName = "Bogdan Neagu", IsPlayed = true },
                new Games() { Id = 104, GameDate = new DateTime(2025, 6, 13, 6, 0, 0), HomeTeamScore = 2, AwayTeamScore = 2, TicketsSold = 17, Game_HomeTeamId = 27, Game_AwayTeamId = 21, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 27, RefereeName = "Cristian Ene", IsPlayed = true },
                new Games() { Id = 105, GameDate = new DateTime(2025, 6, 13, 8, 0, 0), HomeTeamScore = 1, AwayTeamScore = 2, TicketsSold = 19, Game_HomeTeamId = 28, Game_AwayTeamId = 29, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 28, RefereeName = "Iulian Nistor", IsPlayed = true },

                //etapa 8
                new Games() { Id = 106, GameDate = new DateTime(2025, 6, 20, 18, 0, 0), HomeTeamScore = 1, AwayTeamScore = 3, TicketsSold = 18, Game_HomeTeamId = 10, Game_AwayTeamId = 9, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 10, RefereeName = "Silviu Barbu", IsPlayed = true },
                new Games() { Id = 107, GameDate = new DateTime(2025, 6, 20, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 8, Game_HomeTeamId = 1, Game_AwayTeamId = 8, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 1, RefereeName = "Cătălin Gheorghe", IsPlayed = true },
                new Games() { Id = 108, GameDate = new DateTime(2025, 6, 20, 19, 0, 0), HomeTeamScore = 2, AwayTeamScore = 1, TicketsSold = 13, Game_HomeTeamId = 2, Game_AwayTeamId = 7, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 2, RefereeName = "Cosmin Ionescu", IsPlayed = true },
                new Games() { Id = 109, GameDate = new DateTime(2025, 6, 20, 21, 0, 0), HomeTeamScore = 0, AwayTeamScore = 2, TicketsSold = 12, Game_HomeTeamId = 3, Game_AwayTeamId = 6, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 3, RefereeName = "Marius Popa", IsPlayed = true },
                new Games() { Id = 110, GameDate = new DateTime(2025, 6, 20, 2, 0, 0), HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 7, Game_HomeTeamId = 4, Game_AwayTeamId = 5, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 4, RefereeName = "Radu Marin", IsPlayed = true },
                new Games() { Id = 111, GameDate = new DateTime(2025, 6, 20, 0, 0, 0), HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 16, Game_HomeTeamId = 20, Game_AwayTeamId = 19,
                    Game_CompetitionsId = 4, Game_StadiumsId = 20, RefereeName = "Andrei Dumitrescu", IsPlayed = true },
                new Games() { Id = 112, GameDate = new DateTime(2025, 6, 20, 1, 0, 0), HomeTeamScore = 3, AwayTeamScore = 0, TicketsSold = 9, Game_HomeTeamId = 11, Game_AwayTeamId = 18,
                    Game_CompetitionsId = 4, Game_StadiumsId = 11, RefereeName = "Andrei Dumitrescu", IsPlayed = true },
                new Games() { Id = 113, GameDate = new DateTime(2025, 6, 20, 18, 0, 0), HomeTeamScore = 2, AwayTeamScore = 3, TicketsSold = 12, Game_HomeTeamId = 12, Game_AwayTeamId = 17,
                    Game_CompetitionsId = 4, Game_StadiumsId = 12, RefereeName = "Florin Stan", IsPlayed = true },
                new Games() { Id = 114, GameDate = new DateTime(2025, 6, 20, 6, 0, 0), HomeTeamScore = 1, AwayTeamScore = 0, TicketsSold = 12, Game_HomeTeamId = 13, Game_AwayTeamId = 16, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 13, RefereeName = "Cristian Ene", IsPlayed = true },
                new Games() { Id = 115, GameDate = new DateTime(2025, 6, 20, 11, 0, 0), HomeTeamScore = 0, AwayTeamScore = 2, TicketsSold = 14, Game_HomeTeamId = 14, Game_AwayTeamId = 15, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 14, RefereeName = "Marius Popa", IsPlayed = true },
                new Games() { Id = 116, GameDate = new DateTime(2025, 6, 20, 3, 0, 0), HomeTeamScore = 2, AwayTeamScore = 2, TicketsSold = 19, Game_HomeTeamId = 30, Game_AwayTeamId = 29, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 30, RefereeName = "Daniel Petrescu", IsPlayed = true },
                new Games() { Id = 117, GameDate = new DateTime(2025, 6, 20, 20, 0, 0), HomeTeamScore = 1, AwayTeamScore = 3, TicketsSold = 10, Game_HomeTeamId = 21, Game_AwayTeamId = 28, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 21, RefereeName = "Florin Stan", IsPlayed = true },
                new Games() { Id = 118, GameDate = new DateTime(2025, 6, 20, 5, 0, 0), HomeTeamScore = 0, AwayTeamScore = 2, TicketsSold = 15, Game_HomeTeamId = 22, Game_AwayTeamId = 27, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 22, RefereeName = "Cătălin Gheorghe", IsPlayed = true },
                new Games() { Id = 119, GameDate = new DateTime(2025, 6, 20, 6, 0, 0), HomeTeamScore = 2, AwayTeamScore = 1, TicketsSold = 17, Game_HomeTeamId = 23, Game_AwayTeamId = 26, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 23, RefereeName = "Bogdan Neagu", IsPlayed = true },
                new Games() { Id = 120, GameDate = new DateTime(2025, 6, 20, 8, 0, 0), HomeTeamScore = 0, AwayTeamScore = 1, TicketsSold = 18, Game_HomeTeamId = 24, Game_AwayTeamId = 25, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 24, RefereeName = "Andrei Dumitrescu", IsPlayed = true },

                //etapa 9
                new Games() { Id = 121, GameDate = new DateTime(2025, 6, 27, 18, 0, 0), HomeTeamScore = 2, AwayTeamScore = 1, TicketsSold = 13, Game_HomeTeamId = 5, Game_AwayTeamId = 10, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 5, RefereeName = "George Ilie", IsPlayed = true },
                new Games() { Id = 122, GameDate = new DateTime(2025, 6, 27, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 2, TicketsSold = 15, Game_HomeTeamId = 6, Game_AwayTeamId = 4, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 6, RefereeName = "Alexandru Vasilescu", IsPlayed = true },
                new Games() { Id = 123, GameDate = new DateTime(2025, 6, 27, 19, 0, 0), HomeTeamScore = 3, AwayTeamScore = 0, TicketsSold = 9, Game_HomeTeamId = 7, Game_AwayTeamId = 3, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 7, RefereeName = "Cosmin Ionescu", IsPlayed = true },
                new Games() { Id = 124, GameDate = new DateTime(2025, 6, 27, 21, 0, 0), HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 17, Game_HomeTeamId = 8, Game_AwayTeamId = 2, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 8, RefereeName = "Radu Marin", IsPlayed = true },
                new Games() { Id = 125, GameDate = new DateTime(2025, 6, 27, 2, 0, 0), HomeTeamScore = 1, AwayTeamScore = 2, TicketsSold = 11, Game_HomeTeamId = 9, Game_AwayTeamId = 1,
                    Game_CompetitionsId = 1, Game_StadiumsId = 9, RefereeName = "Silviu Barbu", IsPlayed = true },
                new Games() { Id = 126, GameDate = new DateTime(2025, 6, 27, 0, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 8, Game_HomeTeamId = 15, Game_AwayTeamId = 20, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 15, RefereeName = "Iulian Nistor", IsPlayed = true },
                new Games() { Id = 127, GameDate = new DateTime(2025, 6, 27, 1, 0, 0), HomeTeamScore = 2, AwayTeamScore = 1, TicketsSold = 14, Game_HomeTeamId = 16, Game_AwayTeamId = 14, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 16, RefereeName = "Iulian Nistor", IsPlayed = true },
                new Games() { Id = 128, GameDate = new DateTime(2025, 6, 27, 18, 0, 0), HomeTeamScore = 0, AwayTeamScore = 2, TicketsSold = 13, Game_HomeTeamId = 17, Game_AwayTeamId = 13,
                    Game_CompetitionsId = 4, Game_StadiumsId = 17, RefereeName = "Mihai Rusu", IsPlayed = true },
                new Games() { Id = 129, GameDate = new DateTime(2025, 6, 27, 6, 0, 0), HomeTeamScore = 1, AwayTeamScore = 0, TicketsSold = 7, Game_HomeTeamId = 18, Game_AwayTeamId = 12,
                    Game_CompetitionsId = 4, Game_StadiumsId = 18, RefereeName = "Paul Voicu", IsPlayed = true },
                new Games() { Id = 130, GameDate = new DateTime(2025, 6, 27, 11, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 9, Game_HomeTeamId = 19, Game_AwayTeamId = 11,
                    Game_CompetitionsId = 4, Game_StadiumsId = 19, RefereeName = "Cătălin Gheorghe", IsPlayed = true },
                new Games() { Id = 131, GameDate = new DateTime(2025, 6, 27, 3, 0, 0), HomeTeamScore = 1, AwayTeamScore = 3, TicketsSold = 16, Game_HomeTeamId = 25, Game_AwayTeamId = 30,
                    Game_CompetitionsId = 5, Game_StadiumsId = 25, RefereeName = "Florin Stan", IsPlayed = true },
                new Games() { Id = 132, GameDate = new DateTime(2025, 6, 27, 20, 0, 0), HomeTeamScore = 2, AwayTeamScore = 2, TicketsSold = 18, Game_HomeTeamId = 26, Game_AwayTeamId = 24,
                    Game_CompetitionsId = 5, Game_StadiumsId = 26, RefereeName = "Iulian Nistor", IsPlayed = true },
                new Games() { Id = 133, GameDate = new DateTime(2025, 6, 27, 5, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 10, Game_HomeTeamId = 27, Game_AwayTeamId = 23, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 27, RefereeName = "Mihai Rusu", IsPlayed = true },
                new Games() { Id = 134, GameDate = new DateTime(2025, 6, 27, 6, 0, 0), HomeTeamScore = 2, AwayTeamScore = 1, TicketsSold = 17, Game_HomeTeamId = 28, Game_AwayTeamId = 22,
                    Game_CompetitionsId = 5, Game_StadiumsId = 28, RefereeName = "Bogdan Neagu", IsPlayed = true },
                new Games() { Id = 135, GameDate = new DateTime(2025, 6, 27, 8, 0, 0), HomeTeamScore = 0, AwayTeamScore = 2, TicketsSold = 12, Game_HomeTeamId = 29, Game_AwayTeamId = 21,
                    Game_CompetitionsId = 5, Game_StadiumsId = 29, RefereeName = "Cosmin Ionescu", IsPlayed = true },

                //etapa 10
                new Games() { Id = 136, GameDate = new DateTime(2025, 7, 4, 18, 0, 0), HomeTeamScore = 2, AwayTeamScore = 0, TicketsSold = 16, Game_HomeTeamId = 10, Game_AwayTeamId = 1, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 10, RefereeName = "Cristian Ene", IsPlayed = true },
                new Games() { Id = 137, GameDate = new DateTime(2025, 7, 4, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 1, TicketsSold = 13, Game_HomeTeamId = 9, Game_AwayTeamId = 2, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 9, RefereeName = "Marius Popa", IsPlayed = true },
                new Games() { Id = 138, GameDate = new DateTime(2025, 7, 4, 19, 0, 0), HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 11, Game_HomeTeamId = 8, Game_AwayTeamId = 3, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 8, RefereeName = "Radu Marin", IsPlayed = true },
                new Games() { Id = 139, GameDate = new DateTime(2025, 7, 4, 21, 0, 0), HomeTeamScore = 3, AwayTeamScore = 0, TicketsSold = 18, Game_HomeTeamId = 7, Game_AwayTeamId = 4, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 7, RefereeName = "George Ilie", IsPlayed = true },
                new Games() { Id = 140, GameDate = new DateTime(2025, 7, 4, 2, 0, 0), HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 14, Game_HomeTeamId = 6, Game_AwayTeamId = 5, 
                    Game_CompetitionsId = 1, Game_StadiumsId = 6, RefereeName = "Silviu Barbu", IsPlayed = true },
                new Games() { Id = 141, GameDate = new DateTime(2025, 7, 4, 0, 0, 0), HomeTeamScore = 0, AwayTeamScore = 2, TicketsSold = 12, Game_HomeTeamId = 20, Game_AwayTeamId = 11, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 20, RefereeName = "Paul Voicu", IsPlayed = true },
                new Games() { Id = 142, GameDate = new DateTime(2025, 7, 4, 1, 0, 0), HomeTeamScore = 1, AwayTeamScore = 0, TicketsSold = 9, Game_HomeTeamId = 19, Game_AwayTeamId = 12, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 19, RefereeName = "Paul Voicu", IsPlayed = true },
                new Games() { Id = 143, GameDate = new DateTime(2025, 7, 4, 18, 0, 0), HomeTeamScore = 2, AwayTeamScore = 2, TicketsSold = 13, Game_HomeTeamId = 18, Game_AwayTeamId = 13, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 18, RefereeName = "Andrei Dumitrescu", IsPlayed = true },
                new Games() { Id = 144, GameDate = new DateTime(2025, 7, 4, 6, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 7, Game_HomeTeamId = 17, Game_AwayTeamId = 14, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 17, RefereeName = "Alexandru Vasilescu", IsPlayed = true },
                new Games() { Id = 145, GameDate = new DateTime(2025, 7, 4, 11, 0, 0), HomeTeamScore = 1, AwayTeamScore = 3, TicketsSold = 17, Game_HomeTeamId = 16, Game_AwayTeamId = 15, 
                    Game_CompetitionsId = 4, Game_StadiumsId = 16, RefereeName = "Daniel Petrescu", IsPlayed = true },
                new Games() { Id = 146, GameDate = new DateTime(2025, 7, 4, 3, 0, 0), HomeTeamScore = 0, AwayTeamScore = 1, TicketsSold = 10, Game_HomeTeamId = 30, Game_AwayTeamId = 21, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 30, RefereeName = "Iulian Nistor", IsPlayed = true },
                new Games() { Id = 147, GameDate = new DateTime(2025, 7, 4, 20, 0, 0), HomeTeamScore = 1, AwayTeamScore = 0, TicketsSold = 12, Game_HomeTeamId = 29, Game_AwayTeamId = 22, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 29, RefereeName = "Marius Popa", IsPlayed = true },
                new Games() { Id = 148, GameDate = new DateTime(2025, 7, 4, 5, 0, 0), HomeTeamScore = 2, AwayTeamScore = 2, TicketsSold = 11, Game_HomeTeamId = 28, Game_AwayTeamId = 23, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 28, RefereeName = "Daniel Petrescu", IsPlayed = true },
                new Games() { Id = 149, GameDate = new DateTime(2025, 7, 4, 6, 0, 0), HomeTeamScore = 3, AwayTeamScore = 1, TicketsSold = 14, Game_HomeTeamId = 27, Game_AwayTeamId = 24, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 27, RefereeName = "Radu Marin", IsPlayed = true },
                new Games() { Id = 150, GameDate = new DateTime(2025, 7, 4, 8, 0, 0), HomeTeamScore = 1, AwayTeamScore = 2, TicketsSold = 8, Game_HomeTeamId = 26, Game_AwayTeamId = 25, 
                    Game_CompetitionsId = 5, Game_StadiumsId = 26, RefereeName = "Bogdan Neagu", IsPlayed = true },

                //etapa 11
                new Games() { Id = 151, GameDate = new DateTime(2025, 7, 11, 18, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 6, Game_AwayTeamId =10,
                    Game_CompetitionsId = 1, Game_StadiumsId = 6, RefereeName = "Paul Voicu", IsPlayed = false},
                new Games() { Id = 152, GameDate = new DateTime(2025, 7, 11, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 5, Game_AwayTeamId = 7,
                    Game_CompetitionsId = 1, Game_StadiumsId = 5, RefereeName = "Silviu Barbu", IsPlayed = false},
                new Games() { Id = 153, GameDate = new DateTime(2025, 7, 11, 19, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 4, Game_AwayTeamId = 8,
                    Game_CompetitionsId = 1, Game_StadiumsId = 4, RefereeName = "Andrei Dumitrescu", IsPlayed = false},
                new Games() { Id = 154, GameDate = new DateTime(2025, 7, 11, 21, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 3, Game_AwayTeamId = 9,
                    Game_CompetitionsId = 1, Game_StadiumsId = 3, RefereeName = "Cosmin Ionescu", IsPlayed = false},
                new Games() { Id = 155, GameDate = new DateTime(2025, 7, 11, 2, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 2, Game_AwayTeamId = 1,
                    Game_CompetitionsId = 1, Game_StadiumsId = 2, RefereeName = "Mihai Rusu", IsPlayed = false},
                new Games() { Id = 156, GameDate = new DateTime(2025, 7, 11, 0, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 16,Game_AwayTeamId = 20,
                    Game_CompetitionsId = 4, Game_StadiumsId = 16,RefereeName = "Cristian Ene" , IsPlayed = false },
                new Games() { Id = 157, GameDate = new DateTime(2025, 7, 11, 1, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 15,Game_AwayTeamId = 17,
                    Game_CompetitionsId = 4, Game_StadiumsId = 15,RefereeName = "Cristian Ene", IsPlayed = false},
                new Games() { Id = 158, GameDate = new DateTime(2025, 7, 11, 18, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 14,Game_AwayTeamId = 18,
                    Game_CompetitionsId = 4, Game_StadiumsId = 14,RefereeName = "Florin Stan", IsPlayed = false},
                new Games() { Id = 159, GameDate = new DateTime(2025, 7, 11, 6, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 13,Game_AwayTeamId = 19,
                    Game_CompetitionsId = 4, Game_StadiumsId = 13,RefereeName = "George Ilie", IsPlayed = false},
                new Games() { Id = 160, GameDate = new DateTime(2025, 7, 11, 11, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 12,Game_AwayTeamId = 11,
                    Game_CompetitionsId = 4, Game_StadiumsId = 12,RefereeName = "Cătălin Gheorghe", IsPlayed = false},
                new Games() { Id = 161, GameDate = new DateTime(2025, 7, 11, 3, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 26,Game_AwayTeamId = 30,
                    Game_CompetitionsId = 5, Game_StadiumsId = 26,RefereeName = "Alexandru Vasilescu", IsPlayed = false},
                new Games() { Id = 162, GameDate = new DateTime(2025, 7, 11, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 25,Game_AwayTeamId = 27,
                    Game_CompetitionsId = 5, Game_StadiumsId = 25,RefereeName = "Daniel Petrescu", IsPlayed = false},
                new Games() { Id = 163, GameDate = new DateTime(2025, 7, 11, 5, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 24,Game_AwayTeamId = 28,
                    Game_CompetitionsId = 5, Game_StadiumsId = 24,RefereeName = "Cosmin Ionescu", IsPlayed = false},
                new Games() { Id = 164, GameDate = new DateTime(2025, 7, 11, 6, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 23,Game_AwayTeamId = 29,
                    Game_CompetitionsId = 5, Game_StadiumsId = 23,RefereeName = "George Ilie", IsPlayed = false},
                new Games() { Id = 165, GameDate = new DateTime(2025, 7, 11, 8, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 22,Game_AwayTeamId = 21,
                    Game_CompetitionsId = 5, Game_StadiumsId = 22,RefereeName = "Mihai Rusu", IsPlayed = false},
                //etapa 12
                new Games() { Id = 166, GameDate = new DateTime(2025, 7, 18, 18, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 10, Game_AwayTeamId =2,
                    Game_CompetitionsId = 1, Game_StadiumsId = 10, RefereeName = "Silviu Barbu", IsPlayed = false},
                new Games() { Id = 167, GameDate = new DateTime(2025, 7, 18, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 1, Game_AwayTeamId = 3,
                    Game_CompetitionsId = 1, Game_StadiumsId = 1, RefereeName = "Andrei Dumitrescu", IsPlayed = false},
                new Games() { Id = 168, GameDate = new DateTime(2025, 7, 18, 19, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 9, Game_AwayTeamId = 4,
                    Game_CompetitionsId = 1, Game_StadiumsId = 9, RefereeName = "Cristian Ene", IsPlayed = false},
                new Games() { Id = 169, GameDate = new DateTime(2025, 7, 18, 21, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 8, Game_AwayTeamId = 5,
                    Game_CompetitionsId = 1, Game_StadiumsId = 8, RefereeName = "Alexandru Vasilescu", IsPlayed = false},
                new Games() { Id = 170, GameDate = new DateTime(2025, 7, 18, 2, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 7, Game_AwayTeamId = 6,
                    Game_CompetitionsId = 1, Game_StadiumsId = 7, RefereeName = "Cătălin Gheorghe", IsPlayed = false},
                new Games() { Id = 171, GameDate = new DateTime(2025, 7, 18, 0, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 20,Game_AwayTeamId = 12,
                    Game_CompetitionsId = 4, Game_StadiumsId = 20,RefereeName = "Paul Voicu" , IsPlayed = false },
                new Games() { Id = 172, GameDate = new DateTime(2025, 7, 18, 1, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 11,Game_AwayTeamId = 13,
                    Game_CompetitionsId = 4, Game_StadiumsId = 11,RefereeName = "Paul Voicu", IsPlayed = false},
                new Games() { Id = 173, GameDate = new DateTime(2025, 7, 18, 18, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 19,Game_AwayTeamId = 14,
                    Game_CompetitionsId = 4, Game_StadiumsId = 19,RefereeName = "Bogdan Neagu", IsPlayed = false},
                new Games() { Id = 174, GameDate = new DateTime(2025, 7, 18, 6, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 18,Game_AwayTeamId = 15,
                    Game_CompetitionsId = 4, Game_StadiumsId = 18,RefereeName = "Iulian Nistor", IsPlayed = false},
                new Games() { Id = 175, GameDate = new DateTime(2025, 7, 18, 11, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 17,Game_AwayTeamId = 16,
                    Game_CompetitionsId = 4, Game_StadiumsId = 17,RefereeName = "Radu Marin", IsPlayed = false},
                new Games() { Id = 176, GameDate = new DateTime(2025, 7, 18, 3, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 30,Game_AwayTeamId = 22,
                    Game_CompetitionsId = 5, Game_StadiumsId = 30,RefereeName = "Marius Popa", IsPlayed = false},
                new Games() { Id = 177, GameDate = new DateTime(2025, 7, 18, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 21,Game_AwayTeamId = 23,
                    Game_CompetitionsId = 5, Game_StadiumsId = 21,RefereeName = "Florin Stan", IsPlayed = false},
                new Games() { Id = 178, GameDate = new DateTime(2025, 7, 18, 5, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 29,Game_AwayTeamId = 24,
                    Game_CompetitionsId = 5, Game_StadiumsId = 29,RefereeName = "Andrei Dumitrescu", IsPlayed = false},
                new Games() { Id = 179, GameDate = new DateTime(2025, 7, 18, 6, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 28,Game_AwayTeamId = 25,
                    Game_CompetitionsId = 5, Game_StadiumsId = 28,RefereeName = "Cosmin Ionescu", IsPlayed = false},
                new Games() { Id = 180, GameDate = new DateTime(2025, 7, 18, 8, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 27,Game_AwayTeamId = 26,
                    Game_CompetitionsId = 5, Game_StadiumsId = 27,RefereeName = "Cătălin Gheorghe", IsPlayed = false},
                //etapa 13
                new Games() { Id = 181, GameDate = new DateTime(2025, 7, 25, 18, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 7, Game_AwayTeamId =10,
                    Game_CompetitionsId = 1, Game_StadiumsId = 7, RefereeName = "Radu Marin", IsPlayed = false},
                new Games() { Id = 182, GameDate = new DateTime(2025, 7, 25, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 6, Game_AwayTeamId = 8,
                    Game_CompetitionsId = 1, Game_StadiumsId = 6, RefereeName = "Florin Stan", IsPlayed = false},
                new Games() { Id = 183, GameDate = new DateTime(2025, 7, 25, 19, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 5, Game_AwayTeamId = 9,
                    Game_CompetitionsId = 1, Game_StadiumsId = 5, RefereeName = "Iulian Nistor", IsPlayed = false},
                new Games() { Id = 184, GameDate = new DateTime(2025, 7, 25, 21, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 4, Game_AwayTeamId = 1,
                    Game_CompetitionsId = 1, Game_StadiumsId = 4, RefereeName = "Silviu Barbu", IsPlayed = false},
                new Games() { Id = 185, GameDate = new DateTime(2025, 7, 25, 2, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 3, Game_AwayTeamId = 2,
                    Game_CompetitionsId = 1, Game_StadiumsId = 3, RefereeName = "Cristian Ene", IsPlayed = false},
                new Games() { Id = 186, GameDate = new DateTime(2025, 7, 25, 0, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 17,Game_AwayTeamId = 20,
                    Game_CompetitionsId = 4, Game_StadiumsId = 17,RefereeName = "Marius Popa" , IsPlayed = false },
                new Games() { Id = 187, GameDate = new DateTime(2025, 7, 25, 1, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 16,Game_AwayTeamId = 18,
                    Game_CompetitionsId = 4, Game_StadiumsId = 16,RefereeName = "Marius Popa", IsPlayed = false},
                new Games() { Id = 188, GameDate = new DateTime(2025, 7, 25, 18, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 15,Game_AwayTeamId = 19,
                    Game_CompetitionsId = 4, Game_StadiumsId = 15,RefereeName = "Mihai Rusu", IsPlayed = false},
                new Games() { Id = 189, GameDate = new DateTime(2025, 7, 25, 6, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 14,Game_AwayTeamId = 11,
                    Game_CompetitionsId = 4, Game_StadiumsId = 14,RefereeName = "Alexandru Vasilescu", IsPlayed = false},
                new Games() { Id = 190, GameDate = new DateTime(2025, 7, 25, 11, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 13,Game_AwayTeamId = 12,
                    Game_CompetitionsId = 4, Game_StadiumsId = 13,RefereeName = "Daniel Petrescu", IsPlayed = false},
                new Games() { Id = 191, GameDate = new DateTime(2025, 7, 25, 3, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 27,Game_AwayTeamId = 30,
                    Game_CompetitionsId = 5, Game_StadiumsId = 27,RefereeName = "George Ilie", IsPlayed = false},
                new Games() { Id = 192, GameDate = new DateTime(2025, 7, 25, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 26,Game_AwayTeamId = 28,
                    Game_CompetitionsId = 5, Game_StadiumsId = 26,RefereeName = "Paul Voicu", IsPlayed = false},
                new Games() { Id = 193, GameDate = new DateTime(2025, 7, 25, 5, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 25,Game_AwayTeamId = 29,
                    Game_CompetitionsId = 5, Game_StadiumsId = 25,RefereeName = "Bogdan Neagu", IsPlayed = false},
                new Games() { Id = 194, GameDate = new DateTime(2025, 7, 25, 6, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 24,Game_AwayTeamId = 21,
                    Game_CompetitionsId = 5, Game_StadiumsId = 24,RefereeName = "Radu Marin", IsPlayed = false},
                new Games() { Id = 195, GameDate = new DateTime(2025, 7, 25, 8, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 23,Game_AwayTeamId = 22,
                    Game_CompetitionsId = 5, Game_StadiumsId = 23,RefereeName = "Silviu Barbu", IsPlayed = false},
                //etapa 14
                new Games() { Id = 196, GameDate = new DateTime(2025, 8, 2, 18, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 10, Game_AwayTeamId =3,
                    Game_CompetitionsId = 1, Game_StadiumsId = 10, RefereeName = "Iulian Nistor", IsPlayed = false},
                new Games() { Id = 197, GameDate = new DateTime(2025, 8, 2, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 2, Game_AwayTeamId = 4,
                    Game_CompetitionsId = 1, Game_StadiumsId = 2, RefereeName = "Andrei Dumitrescu", IsPlayed = false},
                new Games() { Id = 198, GameDate = new DateTime(2025, 8, 2, 19, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 1, Game_AwayTeamId = 5,
                    Game_CompetitionsId = 1, Game_StadiumsId = 1, RefereeName = "Alexandru Vasilescu", IsPlayed = false},
                new Games() { Id = 199, GameDate = new DateTime(2025, 8, 2, 21, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 9, Game_AwayTeamId = 6,
                    Game_CompetitionsId = 1, Game_StadiumsId = 9, RefereeName = "Cătălin Gheorghe", IsPlayed = false},
                new Games() { Id = 200, GameDate = new DateTime(2025, 8, 2, 2, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 8, Game_AwayTeamId = 7,
                    Game_CompetitionsId = 1, Game_StadiumsId = 8, RefereeName = "Cosmin Ionescu", IsPlayed = false},
                new Games() { Id = 201, GameDate = new DateTime(2025, 8, 2, 0, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 20,Game_AwayTeamId = 13,
                    Game_CompetitionsId = 4, Game_StadiumsId = 20,RefereeName = "Paul Voicu" , IsPlayed = false },
                new Games() { Id = 202, GameDate = new DateTime(2025, 8, 2, 1, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 12,Game_AwayTeamId = 14,
                    Game_CompetitionsId = 4, Game_StadiumsId = 12,RefereeName = "Paul Voicu", IsPlayed = false},
                new Games() { Id = 203, GameDate = new DateTime(2025, 8, 2, 18, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 11,Game_AwayTeamId = 15,
                    Game_CompetitionsId = 4, Game_StadiumsId = 11,RefereeName = "Daniel Petrescu", IsPlayed = false},
                new Games() { Id = 204, GameDate = new DateTime(2025, 8, 2, 6, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 19,Game_AwayTeamId = 16,
                    Game_CompetitionsId = 4, Game_StadiumsId = 19,RefereeName = "Florin Stan", IsPlayed = false},
                new Games() { Id = 205, GameDate = new DateTime(2025, 8, 2, 11, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 18,Game_AwayTeamId = 17,
                    Game_CompetitionsId = 4, Game_StadiumsId = 18,RefereeName = "Marius Popa", IsPlayed = false},
                new Games() { Id = 206, GameDate = new DateTime(2025, 8, 2, 3, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 30,Game_AwayTeamId = 23,
                    Game_CompetitionsId = 5, Game_StadiumsId = 30,RefereeName = "Cristian Ene", IsPlayed = false},
                new Games() { Id = 207, GameDate = new DateTime(2025, 8, 2, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 22,Game_AwayTeamId = 24,
                    Game_CompetitionsId = 5, Game_StadiumsId = 22,RefereeName = "George Ilie", IsPlayed = false},
                new Games() { Id = 208, GameDate = new DateTime(2025, 8, 2, 5, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 21,Game_AwayTeamId = 25,
                    Game_CompetitionsId = 5, Game_StadiumsId = 21,RefereeName = "Bogdan Neagu", IsPlayed = false},
                new Games() { Id = 209, GameDate = new DateTime(2025, 8, 2, 6, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 29,Game_AwayTeamId = 26,
                    Game_CompetitionsId = 5, Game_StadiumsId = 29,RefereeName = "Mihai Rusu", IsPlayed = false},
                new Games() { Id = 210, GameDate = new DateTime(2025, 8, 2, 8, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 28,Game_AwayTeamId = 27,
                    Game_CompetitionsId = 5, Game_StadiumsId = 28,RefereeName = "Paul Voicu", IsPlayed = false},
                //etapa 15
                new Games() { Id = 211, GameDate = new DateTime(2025, 8, 9, 18, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 8, Game_AwayTeamId =10,
                    Game_CompetitionsId = 1, Game_StadiumsId = 8, RefereeName = "Bogdan Neagu", IsPlayed = false},
                new Games() { Id = 212, GameDate = new DateTime(2025, 8, 9, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 7, Game_AwayTeamId = 9,
                    Game_CompetitionsId = 1, Game_StadiumsId = 7, RefereeName = "Marius Popa", IsPlayed = false},
                new Games() { Id = 213, GameDate = new DateTime(2025, 8, 9, 19, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 6, Game_AwayTeamId = 1,
                    Game_CompetitionsId = 1, Game_StadiumsId = 6, RefereeName = "Daniel Petrescu", IsPlayed = false},
                new Games() { Id = 214, GameDate = new DateTime(2025, 8, 9, 21, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 5, Game_AwayTeamId = 2,
                    Game_CompetitionsId = 1, Game_StadiumsId = 5, RefereeName = "Radu Marin", IsPlayed = false},
                new Games() { Id = 215, GameDate = new DateTime(2025, 8, 9, 2, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 4, Game_AwayTeamId = 3,
                    Game_CompetitionsId = 1, Game_StadiumsId = 4, RefereeName = "Cătălin Gheorghe", IsPlayed = false},
                new Games() { Id = 216, GameDate = new DateTime(2025, 8, 9, 0, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 18,Game_AwayTeamId = 20,
                    Game_CompetitionsId = 4, Game_StadiumsId = 18,RefereeName = "Silviu Barbu" , IsPlayed = false },
                new Games() { Id = 217, GameDate = new DateTime(2025, 8, 9, 1, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 17,Game_AwayTeamId = 19,
                    Game_CompetitionsId = 4, Game_StadiumsId = 17,RefereeName = "Silviu Barbu", IsPlayed = false},
                new Games() { Id = 218, GameDate = new DateTime(2025, 8, 9, 18, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 16,Game_AwayTeamId = 11,
                    Game_CompetitionsId = 4, Game_StadiumsId = 16,RefereeName = "Alexandru Vasilescu", IsPlayed = false},
                new Games() { Id = 219, GameDate = new DateTime(2025, 8, 9, 6, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 15,Game_AwayTeamId = 12,
                    Game_CompetitionsId = 4, Game_StadiumsId = 15,RefereeName = "Iulian Nistor", IsPlayed = false},
                new Games() { Id = 220, GameDate = new DateTime(2025, 8, 9, 11, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 14,Game_AwayTeamId = 13,
                    Game_CompetitionsId = 4, Game_StadiumsId = 14,RefereeName = "Mihai Rusu", IsPlayed = false},
                new Games() { Id = 221, GameDate = new DateTime(2025, 8, 9, 3, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 28,Game_AwayTeamId = 30,
                    Game_CompetitionsId = 5, Game_StadiumsId = 28,RefereeName = "Cosmin Ionescu", IsPlayed = false},
                new Games() { Id = 222, GameDate = new DateTime(2025, 8, 9, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 27,Game_AwayTeamId = 29,
                    Game_CompetitionsId = 5, Game_StadiumsId = 27,RefereeName = "George Ilie", IsPlayed = false},
                new Games() { Id = 223, GameDate = new DateTime(2025, 8, 9, 5, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 26,Game_AwayTeamId = 21,
                    Game_CompetitionsId = 5, Game_StadiumsId = 26,RefereeName = "Andrei Dumitrescu", IsPlayed = false},
                new Games() { Id = 224, GameDate = new DateTime(2025, 8, 9, 6, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 25,Game_AwayTeamId = 22,
                    Game_CompetitionsId = 5, Game_StadiumsId = 25,RefereeName = "Florin Stan", IsPlayed = false},
                new Games() { Id = 225, GameDate = new DateTime(2025, 8, 9, 8, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 24,Game_AwayTeamId = 23,
                    Game_CompetitionsId = 5, Game_StadiumsId = 24,RefereeName = "Cristian Ene", IsPlayed = false},
                //etapa 16
                new Games() { Id = 226, GameDate = new DateTime(2025, 8, 16, 18, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 10, Game_AwayTeamId =4,
                    Game_CompetitionsId = 1, Game_StadiumsId = 10, RefereeName = "George Ilie", IsPlayed = false},
                new Games() { Id = 227, GameDate = new DateTime(2025, 8, 16, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 3, Game_AwayTeamId = 5,
                    Game_CompetitionsId = 1, Game_StadiumsId = 3, RefereeName = "Alexandru Vasilescu", IsPlayed = false},
                new Games() { Id = 228, GameDate = new DateTime(2025, 8, 16, 19, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 2, Game_AwayTeamId = 6,
                    Game_CompetitionsId = 1, Game_StadiumsId = 2, RefereeName = "Mihai Rusu", IsPlayed = false},
                new Games() { Id = 229, GameDate = new DateTime(2025, 8, 16, 21, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 1, Game_AwayTeamId = 7,
                    Game_CompetitionsId = 1, Game_StadiumsId = 1, RefereeName = "Florin Stan", IsPlayed = false},
                new Games() { Id = 230, GameDate = new DateTime(2025, 8, 16, 2, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 9, Game_AwayTeamId = 8,
                    Game_CompetitionsId = 1, Game_StadiumsId = 9, RefereeName = "Andrei Dumitrescu", IsPlayed = false},
                new Games() { Id = 231, GameDate = new DateTime(2025, 8, 16, 0, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 20,Game_AwayTeamId = 14,
                    Game_CompetitionsId = 4, Game_StadiumsId = 20,RefereeName = "Cristian Ene" , IsPlayed = false },
                new Games() { Id = 232, GameDate = new DateTime(2025, 8, 16, 1, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 13,Game_AwayTeamId = 15,
                    Game_CompetitionsId = 4, Game_StadiumsId = 13,RefereeName = "Cristian Ene", IsPlayed = false},
                new Games() { Id = 233, GameDate = new DateTime(2025, 8, 16, 18, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 12,Game_AwayTeamId = 16,
                    Game_CompetitionsId = 4, Game_StadiumsId = 12,RefereeName = "Silviu Barbu", IsPlayed = false},
                new Games() { Id = 234, GameDate = new DateTime(2025, 8, 16, 6, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 11,Game_AwayTeamId = 17,
                    Game_CompetitionsId = 4, Game_StadiumsId = 11,RefereeName = "Iulian Nistor", IsPlayed = false},
                new Games() { Id = 235, GameDate = new DateTime(2025, 8, 16, 11, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 19,Game_AwayTeamId = 18,
                    Game_CompetitionsId = 4, Game_StadiumsId = 19,RefereeName = "Cosmin Ionescu", IsPlayed = false},
                new Games() { Id = 236, GameDate = new DateTime(2025, 8, 16, 3, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 30,Game_AwayTeamId = 24,
                    Game_CompetitionsId = 5, Game_StadiumsId = 30,RefereeName = "Cătălin Gheorghe", IsPlayed = false},
                new Games() { Id = 237, GameDate = new DateTime(2025, 8, 16, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 23,Game_AwayTeamId = 25,
                    Game_CompetitionsId = 5, Game_StadiumsId = 23,RefereeName = "Daniel Petrescu", IsPlayed = false},
                new Games() { Id = 238, GameDate = new DateTime(2025, 8, 16, 5, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 22,Game_AwayTeamId = 26,
                    Game_CompetitionsId = 5, Game_StadiumsId = 22,RefereeName = "Bogdan Neagu", IsPlayed = false},
                new Games() { Id = 239, GameDate = new DateTime(2025, 8, 16, 6, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 21,Game_AwayTeamId = 27,
                    Game_CompetitionsId = 5, Game_StadiumsId = 21,RefereeName = "Marius Popa", IsPlayed = false},
                new Games() { Id = 240, GameDate = new DateTime(2025, 8, 16, 8, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 29,Game_AwayTeamId = 28,
                    Game_CompetitionsId = 5, Game_StadiumsId = 29,RefereeName = "Paul Voicu", IsPlayed = false},
                //etapa 17
                new Games() { Id = 241, GameDate = new DateTime(2025, 8, 23, 18, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 9, Game_AwayTeamId =10,
                    Game_CompetitionsId = 1, Game_StadiumsId = 9, RefereeName = "Radu Marin", IsPlayed = false},
                new Games() { Id = 242, GameDate = new DateTime(2025, 8, 23, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 8, Game_AwayTeamId = 1,
                    Game_CompetitionsId = 1, Game_StadiumsId = 8, RefereeName = "Marius Popa", IsPlayed = false},
                new Games() { Id = 243, GameDate = new DateTime(2025, 8, 23, 19, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 7, Game_AwayTeamId = 2,
                    Game_CompetitionsId = 1, Game_StadiumsId = 7, RefereeName = "George Ilie", IsPlayed = false},
                new Games() { Id = 244, GameDate = new DateTime(2025, 8, 23, 21, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 6, Game_AwayTeamId = 3,
                    Game_CompetitionsId = 1, Game_StadiumsId = 6, RefereeName = "Florin Stan", IsPlayed = false},
                new Games() { Id = 245, GameDate = new DateTime(2025, 8, 23, 2, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 5, Game_AwayTeamId = 4,
                    Game_CompetitionsId = 1, Game_StadiumsId = 5, RefereeName = "Paul Voicu", IsPlayed = false},
                new Games() { Id = 246, GameDate = new DateTime(2025, 8, 23, 0, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 19,Game_AwayTeamId = 20,
                    Game_CompetitionsId = 4, Game_StadiumsId = 19,RefereeName = "Cristian Ene" , IsPlayed = false },
                new Games() { Id = 247, GameDate = new DateTime(2025, 8, 23, 1, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 18,Game_AwayTeamId = 11,
                    Game_CompetitionsId = 4, Game_StadiumsId = 18,RefereeName = "Cristian Ene", IsPlayed = false},
                new Games() { Id = 248, GameDate = new DateTime(2025, 8, 23, 18, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 17,Game_AwayTeamId = 12,
                    Game_CompetitionsId = 4, Game_StadiumsId = 17,RefereeName = "Iulian Nistor", IsPlayed = false},
                new Games() { Id = 249, GameDate = new DateTime(2025, 8, 23, 6, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 16,Game_AwayTeamId = 13,
                    Game_CompetitionsId = 4, Game_StadiumsId = 16,RefereeName = "Cosmin Ionescu", IsPlayed = false},
                new Games() { Id = 250, GameDate = new DateTime(2025, 8, 23, 11, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 15,Game_AwayTeamId = 14,
                    Game_CompetitionsId = 4, Game_StadiumsId = 15,RefereeName = "Alexandru Vasilescu", IsPlayed = false},
                new Games() { Id = 251, GameDate = new DateTime(2025, 8, 23, 3, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 29,Game_AwayTeamId = 30,
                    Game_CompetitionsId = 5, Game_StadiumsId = 29,RefereeName = "Silviu Barbu", IsPlayed = false},
                new Games() { Id = 252, GameDate = new DateTime(2025, 8, 23, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 28,Game_AwayTeamId = 21,
                    Game_CompetitionsId = 5, Game_StadiumsId = 28,RefereeName = "Cătălin Gheorghe", IsPlayed = false},
                new Games() { Id = 253, GameDate = new DateTime(2025, 8, 23, 5, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 27,Game_AwayTeamId = 22,
                    Game_CompetitionsId = 5, Game_StadiumsId = 27,RefereeName = "Daniel Petrescu", IsPlayed = false},
                new Games() { Id = 254, GameDate = new DateTime(2025, 8, 23, 6, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 26,Game_AwayTeamId = 23,
                    Game_CompetitionsId = 5, Game_StadiumsId = 26,RefereeName = "Andrei Dumitrescu", IsPlayed = false},
                new Games() { Id = 255, GameDate = new DateTime(2025, 8, 23, 8, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 25,Game_AwayTeamId = 24,
                    Game_CompetitionsId = 5, Game_StadiumsId = 25,RefereeName = "Mihai Rusu", IsPlayed = false},
                //etapa 18
                new Games() { Id = 256, GameDate = new DateTime(2025, 8, 30, 18, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 10, Game_AwayTeamId =5,
                    Game_CompetitionsId = 1, Game_StadiumsId = 10, RefereeName = "Bogdan Neagu", IsPlayed = false},
                new Games() { Id = 257, GameDate = new DateTime(2025, 8, 30, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 4, Game_AwayTeamId = 6,
                    Game_CompetitionsId = 1, Game_StadiumsId = 4, RefereeName = "Radu Marin", IsPlayed = false},
                new Games() { Id = 258, GameDate = new DateTime(2025, 8, 30, 19, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 3, Game_AwayTeamId = 7,
                    Game_CompetitionsId = 1, Game_StadiumsId = 3, RefereeName = "Cătălin Gheorghe", IsPlayed = false},
                new Games() { Id = 259, GameDate = new DateTime(2025, 8, 30, 21, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 2, Game_AwayTeamId = 8,
                    Game_CompetitionsId = 1, Game_StadiumsId = 2, RefereeName = "Andrei Dumitrescu", IsPlayed = false},
                new Games() { Id = 260, GameDate = new DateTime(2025, 8, 30, 2, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 1, Game_AwayTeamId = 9,
                    Game_CompetitionsId = 1, Game_StadiumsId = 1, RefereeName = "Bogdan Neagu", IsPlayed = false},
                new Games() { Id = 261, GameDate = new DateTime(2025, 8, 30, 0, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 20,Game_AwayTeamId = 15,
                    Game_CompetitionsId = 4, Game_StadiumsId = 20,RefereeName = "Florin Stan" , IsPlayed = false },
                new Games() { Id = 262, GameDate = new DateTime(2025, 8, 30, 1, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 14,Game_AwayTeamId = 16,
                    Game_CompetitionsId = 4, Game_StadiumsId = 14,RefereeName = "Florin Stan", IsPlayed = false},
                new Games() { Id = 263, GameDate = new DateTime(2025, 8, 30, 18, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 13,Game_AwayTeamId = 17,
                    Game_CompetitionsId = 4, Game_StadiumsId = 13,RefereeName = "Iulian Nistor", IsPlayed = false},
                new Games() { Id = 264, GameDate = new DateTime(2025, 8, 30, 6, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 12,Game_AwayTeamId = 18,
                    Game_CompetitionsId = 4, Game_StadiumsId = 12,RefereeName = "Radu Marin", IsPlayed = false},
                new Games() { Id = 265, GameDate = new DateTime(2025, 8, 30, 11, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 11,Game_AwayTeamId = 19,
                    Game_CompetitionsId = 4, Game_StadiumsId = 11,RefereeName = "Mihai Rusu", IsPlayed = false},
                new Games() { Id = 266, GameDate = new DateTime(2025, 8, 30, 3, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 30,Game_AwayTeamId = 25,
                    Game_CompetitionsId = 5, Game_StadiumsId = 30,RefereeName = "Marius Popa", IsPlayed = false},
                new Games() { Id = 267, GameDate = new DateTime(2025, 8, 30, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 24,Game_AwayTeamId = 26,
                    Game_CompetitionsId = 5, Game_StadiumsId = 24,RefereeName = "Daniel Petrescu", IsPlayed = false},
                new Games() { Id = 268, GameDate = new DateTime(2025, 8, 30, 5, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 23,Game_AwayTeamId = 27,
                    Game_CompetitionsId = 5, Game_StadiumsId = 23,RefereeName = "Alexandru Vasilescu", IsPlayed = false},
                new Games() { Id = 269, GameDate = new DateTime(2025, 8, 30, 6, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 22,Game_AwayTeamId = 28,
                    Game_CompetitionsId = 5, Game_StadiumsId = 22,RefereeName = "Silviu Barbu", IsPlayed = false},
                new Games() { Id = 270, GameDate = new DateTime(2025, 8, 30, 8, 0, 0),  HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 21,Game_AwayTeamId = 29,
                    Game_CompetitionsId = 5, Game_StadiumsId = 21,RefereeName = "Paul Voicu", IsPlayed = false},
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //cupa tur 1(optimi)
                new Games() { Id = 271, GameDate = new DateTime(2025, 4, 30, 10, 0, 0), HomeTeamScore = 1, AwayTeamScore = 0, TicketsSold = 10, Game_HomeTeamId = 1, Game_AwayTeamId = 10,
                    Game_CompetitionsId = 2, Game_StadiumsId = 1, RefereeName = "Radu Marin", IsPlayed = true},
                new Games() { Id = 272, GameDate = new DateTime(2025, 4, 30, 12, 0, 0), HomeTeamScore = 0, AwayTeamScore = 2, TicketsSold = 10, Game_HomeTeamId = 2, Game_AwayTeamId = 9,
                    Game_CompetitionsId = 2, Game_StadiumsId = 2, RefereeName = "Marius Popa", IsPlayed = true},
                new Games() { Id = 273, GameDate = new DateTime(2025, 4, 30, 14, 0, 0), HomeTeamScore = 1, AwayTeamScore = 0, TicketsSold = 10, Game_HomeTeamId = 3, Game_AwayTeamId = 31,
                    Game_CompetitionsId = 2, Game_StadiumsId = 3, RefereeName = "Florin Stan", IsPlayed = true},
                new Games() { Id = 274, GameDate = new DateTime(2025, 4, 30, 16, 0, 0), HomeTeamScore = 0, AwayTeamScore = 1, TicketsSold = 10, Game_HomeTeamId = 4, Game_AwayTeamId = 32,
                    Game_CompetitionsId = 2, Game_StadiumsId = 4, RefereeName = "Andrei Dumitrescu", IsPlayed = true},
                new Games() { Id = 275, GameDate = new DateTime(2025, 4, 30, 18, 0, 0), HomeTeamScore = 2, AwayTeamScore = 1, TicketsSold = 10, Game_HomeTeamId = 5, Game_AwayTeamId = 33,
                    Game_CompetitionsId = 2, Game_StadiumsId = 5, RefereeName = "Iulian Nistor", IsPlayed = true},
                new Games() { Id = 276, GameDate = new DateTime(2025, 4, 30, 20, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 10, Game_HomeTeamId = 6, Game_AwayTeamId = 34,
                    Game_CompetitionsId = 2, Game_StadiumsId = 6, RefereeName = "Cosmin Ionescu", IsPlayed = true},
                new Games() { Id = 277, GameDate = new DateTime(2025, 4, 30, 22, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 10, Game_HomeTeamId = 7, Game_AwayTeamId = 35,
                Game_CompetitionsId = 2, Game_StadiumsId = 7, RefereeName = "Alexandru Vasilescu", IsPlayed = true},
                new Games() { Id = 278, GameDate = new DateTime(2025, 4, 30, 8, 0, 0), HomeTeamScore = 1, AwayTeamScore = 0, TicketsSold = 10, Game_HomeTeamId = 8, Game_AwayTeamId = 36,
                    Game_CompetitionsId = 2, Game_StadiumsId = 8, RefereeName = "Silviu Barbu", IsPlayed = true},
                //cupa retur 1
                new Games() { Id = 279, GameDate = new DateTime(2025, 5, 7, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 2, TicketsSold = 10, Game_HomeTeamId = 10, Game_AwayTeamId = 1,
                    Game_CompetitionsId = 2, Game_StadiumsId = 10, RefereeName = "Radu Marin", IsPlayed = true},
                new Games() { Id = 280, GameDate = new DateTime(2025, 5, 7, 12, 0, 0), HomeTeamScore = 0, AwayTeamScore = 3, TicketsSold = 10, Game_HomeTeamId = 9, Game_AwayTeamId = 2,
                    Game_CompetitionsId = 2, Game_StadiumsId = 9, RefereeName = "Marius Popa", IsPlayed = true},
                new Games() { Id = 281, GameDate = new DateTime(2025, 5, 7, 14, 0, 0), HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 10, Game_HomeTeamId = 31, Game_AwayTeamId = 3,
                    Game_CompetitionsId = 2, Game_StadiumsId = 31, RefereeName = "Florin Stan", IsPlayed = true},
                new Games() { Id = 282, GameDate = new DateTime(2025, 5, 7, 16, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 10, Game_HomeTeamId = 32, Game_AwayTeamId = 4,
                    Game_CompetitionsId = 2, Game_StadiumsId = 32, RefereeName = "Andrei Dumitrescu", IsPlayed = true},
                new Games() { Id = 283, GameDate = new DateTime(2025, 5, 7, 18, 0, 0), HomeTeamScore = 2, AwayTeamScore = 0, TicketsSold = 10, Game_HomeTeamId = 33, Game_AwayTeamId = 5,
                    Game_CompetitionsId = 2, Game_StadiumsId = 33, RefereeName = "Iulian Nistor", IsPlayed = true},
                new Games() { Id = 284, GameDate = new DateTime(2025, 5, 7, 20, 0, 0), HomeTeamScore = 1, AwayTeamScore = 0, TicketsSold = 10, Game_HomeTeamId = 34, Game_AwayTeamId = 6,
                    Game_CompetitionsId = 2, Game_StadiumsId = 34, RefereeName = "Cosmin Ionescu", IsPlayed = true},
                new Games() { Id = 285, GameDate = new DateTime(2025, 5, 7, 22, 0, 0), HomeTeamScore = 0, AwayTeamScore = 3, TicketsSold = 10, Game_HomeTeamId = 35, Game_AwayTeamId = 7,
                    Game_CompetitionsId = 2, Game_StadiumsId = 35, RefereeName = "Alexandru Vasilescu", IsPlayed = true},
                new Games() { Id = 286, GameDate = new DateTime(2025, 5, 7, 8, 0, 0), HomeTeamScore = 3, AwayTeamScore = 1, TicketsSold = 10, Game_HomeTeamId = 36, Game_AwayTeamId = 8,
                    Game_CompetitionsId = 2, Game_StadiumsId = 36, RefereeName = "Silviu Barbu", IsPlayed = true },
                //cupa tur 2(sferturi)
                new Games() { Id = 287, GameDate = new DateTime(2025, 6, 1, 10, 0, 0), HomeTeamScore = 4, AwayTeamScore = 0, TicketsSold = 10, Game_HomeTeamId = 1, Game_AwayTeamId = 2,
                    Game_CompetitionsId = 2, Game_StadiumsId = 1, RefereeName = "Radu Marin", IsPlayed = true},
                new Games() { Id = 288, GameDate = new DateTime(2025, 6, 1, 12, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 10, Game_HomeTeamId = 3, Game_AwayTeamId = 32,
                    Game_CompetitionsId = 2, Game_StadiumsId = 3, RefereeName = "Marius Popa", IsPlayed = true},
                new Games() { Id = 289, GameDate = new DateTime(2025, 6, 1, 14, 0, 0), HomeTeamScore = 1, AwayTeamScore = 0, TicketsSold = 10, Game_HomeTeamId = 34, Game_AwayTeamId = 33,
                    Game_CompetitionsId = 2, Game_StadiumsId = 34, RefereeName = "Florin Stan", IsPlayed = true},
                new Games() { Id = 290, GameDate = new DateTime(2025, 6, 1, 16, 0, 0), HomeTeamScore = 3, AwayTeamScore = 3, TicketsSold = 10, Game_HomeTeamId = 7, Game_AwayTeamId = 36,
                    Game_CompetitionsId = 2, Game_StadiumsId = 7, RefereeName = "Andrei Dumitrescu", IsPlayed = true},
                //cupa retur 2
                new Games() { Id = 291, GameDate = new DateTime(2025, 6, 8, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 10, Game_HomeTeamId = 2, Game_AwayTeamId = 1,
                    Game_CompetitionsId = 2, Game_StadiumsId = 2, RefereeName = "Radu Marin", IsPlayed = true},
                new Games() { Id = 292, GameDate = new DateTime(2025, 6, 8, 12, 0, 0), HomeTeamScore = 0, AwayTeamScore = 1, TicketsSold = 10, Game_HomeTeamId = 32, Game_AwayTeamId = 3,
                    Game_CompetitionsId = 2, Game_StadiumsId = 32, RefereeName = "Marius Popa", IsPlayed = true},
                new Games() { Id = 293, GameDate = new DateTime(2025, 6, 8, 14, 0, 0), HomeTeamScore = 2, AwayTeamScore = 0, TicketsSold = 10, Game_HomeTeamId = 33, Game_AwayTeamId = 34,
                    Game_CompetitionsId = 2, Game_StadiumsId = 33, RefereeName = "Florin Stan", IsPlayed = true},
                new Games() { Id = 294, GameDate = new DateTime(2025, 6, 8, 16, 0, 0), HomeTeamScore = 0, AwayTeamScore = 1, TicketsSold = 10, Game_HomeTeamId = 36, Game_AwayTeamId = 7,
                    Game_CompetitionsId = 2, Game_StadiumsId = 36, RefereeName = "Andrei Dumitrescu", IsPlayed = true },
                //cupa tur 3(semi finala)
                new Games() { Id = 295, GameDate = new DateTime(2025, 7, 1, 10, 0, 0), HomeTeamScore = 3, AwayTeamScore = 0, TicketsSold = 10, Game_HomeTeamId = 1, Game_AwayTeamId = 3,
                    Game_CompetitionsId = 2, Game_StadiumsId = 1, RefereeName = "Radu Marin", IsPlayed = true},
                new Games() { Id = 296, GameDate = new DateTime(2025, 7, 1, 12, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 10, Game_HomeTeamId = 7, Game_AwayTeamId = 33,
                    Game_CompetitionsId = 2, Game_StadiumsId = 7, RefereeName = "Marius Popa", IsPlayed = true},
                //cupa retur 3
                new Games() { Id = 297, GameDate = new DateTime(2025, 7, 7, 10, 0, 0), HomeTeamScore = 2, AwayTeamScore = 3, TicketsSold = 10, Game_HomeTeamId = 3, Game_AwayTeamId = 1,
                    Game_CompetitionsId = 2, Game_StadiumsId = 3, RefereeName = "Andrei Dumitrescu", IsPlayed = true},
                new Games() { Id = 298, GameDate = new DateTime(2025, 7, 7, 12, 0, 0), HomeTeamScore = 1, AwayTeamScore = 0, TicketsSold = 10, Game_HomeTeamId = 33, Game_AwayTeamId = 7,
                Game_CompetitionsId = 2, Game_StadiumsId = 33, RefereeName = "Florin Stan", IsPlayed = true},
                //cupa tur 4(finala)
                new Games() { Id = 299, GameDate = new DateTime(2025, 7, 30, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 1, Game_AwayTeamId = 33,
                    Game_CompetitionsId = 2, Game_StadiumsId = 1, RefereeName = "Radu Marin", IsPlayed = false},
                //cupa retur 4
                new Games() { Id = 300, GameDate = new DateTime(2025, 8, 6, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 33, Game_AwayTeamId = 1,
                    Game_CompetitionsId = 2, Game_StadiumsId =33, RefereeName = "Marius Popa", IsPlayed = false},
                  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                 /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                
                //program:
                    /*
                    Etapa 1:  1-41, 42-49, 43-48, 44-47, 45-46
                    Etapa 2:  49-1, 41-42, 46-44, 47-43, 48-45
                    Etapa 3:  1-42, 43-41, 44-49, 45-48, 46-47
                    Etapa 4:  41-44, 42-43, 49-45, 47-1, 48-46
                    Etapa 5:  1-43, 44-42, 45-41, 46-49, 47-48
                    Etapa 6:  42-45, 43-44, 49-47, 41-46, 48-1
                    Etapa 7:  1-44, 45-43, 46-42, 47-41, 49-48
                    Etapa 8:  41-45, 42-47, 43-49, 44-48, 46-1
                    Etapa 9:  1-45, 47-46, 48-43, 49-44, 41-42
                    */

               //champions league tur 1(grupe)
                // Etapa 1 - 7 mai 2025
                new Games() { Id = 301, GameDate = new DateTime(2025, 5, 7, 10, 0, 0), HomeTeamScore = 2, AwayTeamScore = 2, TicketsSold = 6, Game_HomeTeamId = 1, Game_AwayTeamId = 41,
                Game_CompetitionsId = 3, Game_StadiumsId = 1, RefereeName = "Tomasz Nowak", IsPlayed = true },
                new Games() { Id = 302, GameDate = new DateTime(2025, 5, 7, 10, 0, 0), HomeTeamScore = 1, AwayTeamScore = 0, TicketsSold = 8, Game_HomeTeamId = 42, Game_AwayTeamId = 49,
                Game_CompetitionsId = 3, Game_StadiumsId = 42, RefereeName = "Marco Rossi", IsPlayed = true },
                new Games() { Id = 303, GameDate = new DateTime(2025, 5, 7, 10, 0, 0), HomeTeamScore = 3, AwayTeamScore = 2, TicketsSold = 5, Game_HomeTeamId = 43, Game_AwayTeamId = 48,
                Game_CompetitionsId = 3, Game_StadiumsId = 43, RefereeName = "Lars Andersen", IsPlayed = true },
                new Games() { Id = 304, GameDate = new DateTime(2025, 5, 7, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 2, TicketsSold = 7, Game_HomeTeamId = 44, Game_AwayTeamId = 47,
                Game_CompetitionsId = 3, Game_StadiumsId = 44, RefereeName = "Francesco Bianchi", IsPlayed = true },
                new Games() { Id = 305, GameDate = new DateTime(2025, 5, 7, 10, 0, 0), HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 9, Game_HomeTeamId = 45, Game_AwayTeamId = 46,
                Game_CompetitionsId = 3, Game_StadiumsId = 45, RefereeName = "Kevin O'Connor", IsPlayed = true },

                // Etapa 2 - 21 mai 2025
                new Games() { Id = 306, GameDate = new DateTime(2025, 5, 21, 10, 0, 0), HomeTeamScore = 3, AwayTeamScore = 0, TicketsSold = 7, Game_HomeTeamId = 49, Game_AwayTeamId = 1,
                Game_CompetitionsId = 3, Game_StadiumsId = 49, RefereeName = "Nikos Dimitriou", IsPlayed = true },
                new Games() { Id = 307, GameDate = new DateTime(2025, 5, 21, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 1, TicketsSold = 6, Game_HomeTeamId = 41, Game_AwayTeamId = 42,
                Game_CompetitionsId = 3, Game_StadiumsId = 41, RefereeName = "John Schmidt", IsPlayed = true },
                new Games() { Id = 308, GameDate = new DateTime(2025, 5, 21, 10, 0, 0), HomeTeamScore = 2, AwayTeamScore = 3, TicketsSold = 8, Game_HomeTeamId = 46, Game_AwayTeamId = 44,
                Game_CompetitionsId = 3, Game_StadiumsId = 46, RefereeName = "Carlos Pereira", IsPlayed = true },
                new Games() { Id = 309, GameDate = new DateTime(2025, 5, 21, 10, 0, 0), HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 6, Game_HomeTeamId = 47, Game_AwayTeamId = 43,
                Game_CompetitionsId = 3, Game_StadiumsId = 47, RefereeName = "Diego Alvarez", IsPlayed = true },
                new Games() { Id = 310, GameDate = new DateTime(2025, 5, 21, 10, 0, 0), HomeTeamScore = 1, AwayTeamScore = 0, TicketsSold = 6, Game_HomeTeamId = 48, Game_AwayTeamId = 45,
                Game_CompetitionsId = 3, Game_StadiumsId = 48, RefereeName = "Omer Kaplan", IsPlayed = true },

                // Etapa 3 - 4 iunie 2025
                new Games() { Id = 311, GameDate = new DateTime(2025, 6, 4, 10, 0, 0), HomeTeamScore = 2, AwayTeamScore = 1, TicketsSold = 6, Game_HomeTeamId = 1, Game_AwayTeamId = 42,
                Game_CompetitionsId = 3, Game_StadiumsId = 1, RefereeName = "Tomasz Nowak", IsPlayed = true },
                new Games() { Id = 312, GameDate = new DateTime(2025, 6, 4, 10, 0, 0), HomeTeamScore = 1, AwayTeamScore = 3, TicketsSold = 5, Game_HomeTeamId = 43, Game_AwayTeamId = 41,
                Game_CompetitionsId = 3, Game_StadiumsId = 43, RefereeName = "Marco Rossi", IsPlayed = true },
                new Games() { Id = 313, GameDate = new DateTime(2025, 6, 4, 10, 0, 0), HomeTeamScore = 2, AwayTeamScore = 0, TicketsSold = 8, Game_HomeTeamId = 44, Game_AwayTeamId = 49,
                Game_CompetitionsId = 3, Game_StadiumsId = 44, RefereeName = "Lars Andersen", IsPlayed = true },
                new Games() { Id = 314, GameDate = new DateTime(2025, 6, 4, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 1, TicketsSold = 6, Game_HomeTeamId = 45, Game_AwayTeamId = 48,
                Game_CompetitionsId = 3, Game_StadiumsId = 45, RefereeName = "Francesco Bianchi", IsPlayed = true },
                new Games() { Id = 315, GameDate = new DateTime(2025, 6, 4, 10, 0, 0), HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 8, Game_HomeTeamId = 46, Game_AwayTeamId = 47,
                Game_CompetitionsId = 3, Game_StadiumsId = 46, RefereeName = "Kevin O'Connor", IsPlayed = true },

                // Etapa 4 - 18 iunie 2025
                new Games() { Id = 316, GameDate = new DateTime(2025, 6, 18, 10, 0, 0), HomeTeamScore = 3, AwayTeamScore = 1, TicketsSold = 9, Game_HomeTeamId = 41, Game_AwayTeamId = 44,
                Game_CompetitionsId = 3, Game_StadiumsId = 41, RefereeName = "Nikos Dimitriou", IsPlayed = true },
                new Games() { Id = 317, GameDate = new DateTime(2025, 6, 18, 10, 0, 0), HomeTeamScore = 2, AwayTeamScore = 0, TicketsSold = 8, Game_HomeTeamId = 42, Game_AwayTeamId = 43,
                Game_CompetitionsId = 3, Game_StadiumsId = 42, RefereeName = "John Schmidt", IsPlayed = true },
                new Games() { Id = 318, GameDate = new DateTime(2025, 6, 18, 10, 0, 0), HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 7, Game_HomeTeamId = 49, Game_AwayTeamId = 45,
                Game_CompetitionsId = 3, Game_StadiumsId = 49, RefereeName = "Carlos Pereira", IsPlayed = true },
                new Games() { Id = 319, GameDate = new DateTime(2025, 6, 18, 10, 0, 0), HomeTeamScore = 2, AwayTeamScore = 0, TicketsSold = 6, Game_HomeTeamId = 47, Game_AwayTeamId = 1,
                Game_CompetitionsId = 3, Game_StadiumsId = 47, RefereeName = "Diego Alvarez", IsPlayed = true },
                new Games() { Id = 320, GameDate = new DateTime(2025, 6, 18, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 3, TicketsSold = 8, Game_HomeTeamId = 48, Game_AwayTeamId = 46,
                Game_CompetitionsId = 3, Game_StadiumsId = 48, RefereeName = "Omer Kaplan", IsPlayed = true },

                // Etapa 5 - 2 iulie 2025
                new Games() { Id = 321, GameDate = new DateTime(2025, 7, 2, 10, 0, 0), HomeTeamScore = 1, AwayTeamScore = 1, TicketsSold = 7, Game_HomeTeamId = 1, Game_AwayTeamId = 43,
                Game_CompetitionsId = 3, Game_StadiumsId = 1, RefereeName = "Tomasz Nowak", IsPlayed = true },
                new Games() { Id = 322, GameDate = new DateTime(2025, 7, 2, 10, 0, 0), HomeTeamScore = 2, AwayTeamScore = 2, TicketsSold = 6, Game_HomeTeamId = 44, Game_AwayTeamId = 42,
                Game_CompetitionsId = 3, Game_StadiumsId = 44, RefereeName = "Marco Rossi", IsPlayed = true },
                new Games() { Id = 323, GameDate = new DateTime(2025, 7, 2, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 3, TicketsSold = 5, Game_HomeTeamId = 45, Game_AwayTeamId = 41,
                Game_CompetitionsId = 3, Game_StadiumsId = 45, RefereeName = "Lars Andersen", IsPlayed = true },
                new Games() { Id = 324, GameDate = new DateTime(2025, 7, 2, 10, 0, 0), HomeTeamScore = 2, AwayTeamScore = 0, TicketsSold = 9, Game_HomeTeamId = 46, Game_AwayTeamId = 49,
                Game_CompetitionsId = 3, Game_StadiumsId = 46, RefereeName = "Francesco Bianchi", IsPlayed = true },
                new Games() { Id = 325, GameDate = new DateTime(2025, 7, 2, 10, 0, 0), HomeTeamScore = 2, AwayTeamScore = 2, TicketsSold = 8, Game_HomeTeamId = 47, Game_AwayTeamId = 48,
                Game_CompetitionsId = 3, Game_StadiumsId = 47, RefereeName = "Kevin O'Connor", IsPlayed = true },

                // Etapa 6 - 16 iulie 2025
                new Games() { Id = 326, GameDate = new DateTime(2025, 7, 16, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 42, Game_AwayTeamId = 45, 
                    Game_CompetitionsId = 3, Game_StadiumsId = 42, RefereeName = "Nikos Dimitriou", IsPlayed = false},
                new Games() { Id = 327, GameDate = new DateTime(2025, 7, 16, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 43, Game_AwayTeamId = 44, 
                    Game_CompetitionsId = 3, Game_StadiumsId = 43, RefereeName = "John Schmidt", IsPlayed = false},
                new Games() { Id = 328, GameDate = new DateTime(2025, 7, 16, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 49, Game_AwayTeamId = 47, 
                    Game_CompetitionsId = 3, Game_StadiumsId = 49, RefereeName = "Carlos Pereira", IsPlayed = false},
                new Games() { Id = 329, GameDate = new DateTime(2025, 7, 16, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 41, Game_AwayTeamId = 46, 
                    Game_CompetitionsId = 3, Game_StadiumsId = 41, RefereeName = "Diego Alvarez", IsPlayed = false},
                new Games() { Id = 330, GameDate = new DateTime(2025, 7, 16, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 48, Game_AwayTeamId = 1, 
                    Game_CompetitionsId = 3, Game_StadiumsId = 48, RefereeName = "Omer Kaplan", IsPlayed = false },

                // Etapa 7 - 30 iulie 2025
                new Games() { Id = 331, GameDate = new DateTime(2025, 7, 30, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 1, Game_AwayTeamId = 44, 
                    Game_CompetitionsId = 3, Game_StadiumsId = 1, RefereeName = "Tomasz Nowak", IsPlayed = false},
                new Games() { Id = 332, GameDate = new DateTime(2025, 7, 30, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 45, Game_AwayTeamId = 43, 
                    Game_CompetitionsId = 3, Game_StadiumsId = 45, RefereeName = "Marco Rossi", IsPlayed = false},
                new Games() { Id = 333, GameDate = new DateTime(2025, 7, 30, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 46, Game_AwayTeamId = 42, 
                    Game_CompetitionsId = 3, Game_StadiumsId = 46, RefereeName = "Lars Andersen", IsPlayed = false},
                new Games() { Id = 334, GameDate = new DateTime(2025, 7, 30, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 47, Game_AwayTeamId = 41, 
                    Game_CompetitionsId = 3, Game_StadiumsId = 47, RefereeName = "Francesco Bianchi", IsPlayed = false},
                new Games() { Id = 335, GameDate = new DateTime(2025, 7, 30, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 49, Game_AwayTeamId = 48, 
                    Game_CompetitionsId = 3, Game_StadiumsId = 49, RefereeName = "Kevin O'Connor", IsPlayed = false},

                // Etapa 8 - 13 august 2025
                new Games() { Id = 336, GameDate = new DateTime(2025, 8, 13, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 41, Game_AwayTeamId = 45, 
                    Game_CompetitionsId = 3, Game_StadiumsId = 41, RefereeName = "Nikos Dimitriou", IsPlayed = false},
                new Games() { Id = 337, GameDate = new DateTime(2025, 8, 13, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 42, Game_AwayTeamId = 47, 
                    Game_CompetitionsId = 3, Game_StadiumsId = 42, RefereeName = "John Schmidt", IsPlayed = false},
                new Games() { Id = 338, GameDate = new DateTime(2025, 8, 13, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 43, Game_AwayTeamId = 49, 
                    Game_CompetitionsId = 3, Game_StadiumsId = 43, RefereeName = "Carlos Pereira", IsPlayed = false},
                new Games() { Id = 339, GameDate = new DateTime(2025, 8, 13, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 44, Game_AwayTeamId = 48, 
                    Game_CompetitionsId = 3, Game_StadiumsId = 44, RefereeName = "Diego Alvarez", IsPlayed = false},
                new Games() { Id = 340, GameDate = new DateTime(2025, 8, 13, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 46, Game_AwayTeamId = 1, 
                    Game_CompetitionsId = 3, Game_StadiumsId = 46, RefereeName = "Omer Kaplan", IsPlayed = false},

                // Etapa 9 - 27 august 2025
                new Games() { Id = 341, GameDate = new DateTime(2025, 8, 27, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 1, Game_AwayTeamId = 45, 
                    Game_CompetitionsId = 3, Game_StadiumsId = 1, RefereeName = "Tomasz Nowak", IsPlayed = false},
                new Games() { Id = 342, GameDate = new DateTime(2025, 8, 27, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 47, Game_AwayTeamId = 46, 
                    Game_CompetitionsId = 3, Game_StadiumsId = 47, RefereeName = "Marco Rossi", IsPlayed = false},
                new Games() { Id = 343, GameDate = new DateTime(2025, 8, 27, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 48, Game_AwayTeamId = 43, 
                    Game_CompetitionsId = 3, Game_StadiumsId = 48, RefereeName = "Lars Andersen", IsPlayed = false},
                new Games() { Id = 344, GameDate = new DateTime(2025, 8, 27, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 49, Game_AwayTeamId = 44, 
                    Game_CompetitionsId = 3, Game_StadiumsId = 49, RefereeName = "Francesco Bianchi", IsPlayed = false},
                new Games() { Id = 345, GameDate = new DateTime(2025, 8, 27, 10, 0, 0), HomeTeamScore = 0, AwayTeamScore = 0, TicketsSold = 0, Game_HomeTeamId = 41, Game_AwayTeamId = 42, 
                    Game_CompetitionsId = 3, Game_StadiumsId = 41, RefereeName = "Kevin O'Connor", IsPlayed = false}
            });


            modelBuilder.Entity<Tickets>().HasData(new List<Tickets>()
            {
                //etapa 1
                new Tickets() { Id = 1, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 1, Ticket_GamesId = 1, Ticket_UsersId = 1 },
                new Tickets() { Id = 2, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 2, Ticket_GamesId = 1, Ticket_UsersId = 2 },
                new Tickets() { Id = 3, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 3, Ticket_GamesId = 1, Ticket_UsersId = 3 },
                new Tickets() { Id = 4, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 4, Ticket_GamesId = 1, Ticket_UsersId = 4 },
                new Tickets() { Id = 5, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 5, Ticket_GamesId = 1, Ticket_UsersId = 5 },

                new Tickets() { Id = 6, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 11, Ticket_GamesId = 6, Ticket_UsersId = 6 },
                new Tickets() { Id = 7, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 12, Ticket_GamesId = 6, Ticket_UsersId = 7 },
                new Tickets() { Id = 8, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 13, Ticket_GamesId = 6, Ticket_UsersId = 8 },
                new Tickets() { Id = 9, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 14, Ticket_GamesId = 6, Ticket_UsersId = 9 },
                new Tickets() { Id = 10, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 15, Ticket_GamesId = 6, Ticket_UsersId = 10 },

                new Tickets() { Id = 11, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 21, Ticket_GamesId = 11, Ticket_UsersId = 11 },
                new Tickets() { Id = 12, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 22, Ticket_GamesId = 11, Ticket_UsersId = 22 },
                new Tickets() { Id = 13, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 23, Ticket_GamesId = 11, Ticket_UsersId = 23 },
                new Tickets() { Id = 14, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 24, Ticket_GamesId = 11, Ticket_UsersId = 24 },
                new Tickets() { Id = 15, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 25, Ticket_GamesId = 11, Ticket_UsersId = 25 },

                //etapa 2
                new Tickets() { Id = 16, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 1, Ticket_GamesId = 20, Ticket_UsersId = 6 },
                new Tickets() { Id = 17, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 2, Ticket_GamesId = 20, Ticket_UsersId = 7 },
                new Tickets() { Id = 18, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 3, Ticket_GamesId = 20, Ticket_UsersId = 8 },
                new Tickets() { Id = 19, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 4, Ticket_GamesId = 20, Ticket_UsersId = 9 },
                new Tickets() { Id = 20, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 5, Ticket_GamesId = 20, Ticket_UsersId = 10 },
                new Tickets() { Id = 21, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 6, Ticket_GamesId = 20, Ticket_UsersId = 11 },
                new Tickets() { Id = 22, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 7, Ticket_GamesId = 20, Ticket_UsersId = 12 },
                new Tickets() { Id = 23, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 8, Ticket_GamesId = 20, Ticket_UsersId = 13 },

                new Tickets() { Id = 24, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 11, Ticket_GamesId = 25, Ticket_UsersId = 14 },
                new Tickets() { Id = 25, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 12, Ticket_GamesId = 25, Ticket_UsersId = 15 },
                new Tickets() { Id = 26, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 13, Ticket_GamesId = 25, Ticket_UsersId = 16 },
                new Tickets() { Id = 27, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 14, Ticket_GamesId = 25, Ticket_UsersId = 17 },
                new Tickets() { Id = 28, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 15, Ticket_GamesId = 25, Ticket_UsersId = 18 },

                new Tickets() { Id = 29, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 21, Ticket_GamesId = 30, Ticket_UsersId = 19 },
                new Tickets() { Id = 30, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 22, Ticket_GamesId = 30, Ticket_UsersId = 20 },
                new Tickets() { Id = 31, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 23, Ticket_GamesId = 30, Ticket_UsersId = 21 },
                new Tickets() { Id = 32, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 24, Ticket_GamesId = 30, Ticket_UsersId = 22 },
                new Tickets() { Id = 33, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 25, Ticket_GamesId = 30, Ticket_UsersId = 23 },
                new Tickets() { Id = 34, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 26, Ticket_GamesId = 30, Ticket_UsersId = 24 },
                new Tickets() { Id = 35, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 27, Ticket_GamesId = 30, Ticket_UsersId = 25 },
                new Tickets() { Id = 36, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 28, Ticket_GamesId = 30, Ticket_UsersId = 26 },
                new Tickets() { Id = 37, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 29, Ticket_GamesId = 30, Ticket_UsersId = 27 },

                //etapa 4
                new Tickets() { Id = 38, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 1, Ticket_GamesId = 49, Ticket_UsersId = 28 },
                new Tickets() { Id = 39, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 2, Ticket_GamesId = 49, Ticket_UsersId = 29 },
                new Tickets() { Id = 40, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 3, Ticket_GamesId = 49, Ticket_UsersId = 30 },
                new Tickets() { Id = 41, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 4, Ticket_GamesId = 49, Ticket_UsersId = 31 },
                new Tickets() { Id = 42, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 5, Ticket_GamesId = 49, Ticket_UsersId = 1 },
                new Tickets() { Id = 43, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 6, Ticket_GamesId = 49, Ticket_UsersId = 2 },
                new Tickets() { Id = 44, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 7, Ticket_GamesId = 49, Ticket_UsersId = 3 },

                new Tickets() { Id = 45, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 11, Ticket_GamesId = 54, Ticket_UsersId = 4 },
                new Tickets() { Id = 46, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 12, Ticket_GamesId = 54, Ticket_UsersId = 5 },
                new Tickets() { Id = 47, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 13, Ticket_GamesId = 54, Ticket_UsersId = 6 },
                new Tickets() { Id = 48, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 14, Ticket_GamesId = 54, Ticket_UsersId = 7 },

                new Tickets() { Id = 49, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 21, Ticket_GamesId = 59, Ticket_UsersId = 8 },
                new Tickets() { Id = 50, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 22, Ticket_GamesId = 59, Ticket_UsersId = 9 },
                new Tickets() { Id = 51, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 23, Ticket_GamesId = 59, Ticket_UsersId = 10 },
                new Tickets() { Id = 52, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 24, Ticket_GamesId = 59, Ticket_UsersId = 11 },
                new Tickets() { Id = 53, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 25, Ticket_GamesId = 59, Ticket_UsersId = 12 },
                new Tickets() { Id = 54, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 26, Ticket_GamesId = 59, Ticket_UsersId = 13 },
                new Tickets() { Id = 55, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 27, Ticket_GamesId = 59, Ticket_UsersId = 14 },

                //etapa 6
                new Tickets() { Id = 56, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 1, Ticket_GamesId = 78, Ticket_UsersId = 15 },
                new Tickets() { Id = 57, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 2, Ticket_GamesId = 78, Ticket_UsersId = 16 },
                new Tickets() { Id = 58, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 3, Ticket_GamesId = 78, Ticket_UsersId = 17 },
                new Tickets() { Id = 59, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 4, Ticket_GamesId = 78, Ticket_UsersId = 18 },
                new Tickets() { Id = 60, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 5, Ticket_GamesId = 78, Ticket_UsersId = 19 },
                new Tickets() { Id = 61, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 6, Ticket_GamesId = 78, Ticket_UsersId = 20 },
                new Tickets() { Id = 62, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 7, Ticket_GamesId = 78, Ticket_UsersId = 21 },
                new Tickets() { Id = 63, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 8, Ticket_GamesId = 78, Ticket_UsersId = 22 },

                new Tickets() { Id = 64, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 11, Ticket_GamesId = 83, Ticket_UsersId = 23 },
                new Tickets() { Id = 65, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 12, Ticket_GamesId = 83, Ticket_UsersId = 24 },
                new Tickets() { Id = 66, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 13, Ticket_GamesId = 83, Ticket_UsersId = 25 },
                new Tickets() { Id = 67, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 14, Ticket_GamesId = 83, Ticket_UsersId = 26 },
                new Tickets() { Id = 68, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 15, Ticket_GamesId = 83, Ticket_UsersId = 27 },
                new Tickets() { Id = 69, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 16, Ticket_GamesId = 83, Ticket_UsersId = 28 },
                new Tickets() { Id = 70, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 17, Ticket_GamesId = 83, Ticket_UsersId = 29 },
                new Tickets() { Id = 71, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 18, Ticket_GamesId = 83, Ticket_UsersId = 30 },

                new Tickets() { Id = 72, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 21, Ticket_GamesId = 88, Ticket_UsersId = 31 },
                new Tickets() { Id = 73, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 22, Ticket_GamesId = 88, Ticket_UsersId = 1 },
                new Tickets() { Id = 74, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 23, Ticket_GamesId = 88, Ticket_UsersId = 2 },
                new Tickets() { Id = 75, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 24, Ticket_GamesId = 88, Ticket_UsersId = 3 },
                new Tickets() { Id = 76, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 25, Ticket_GamesId = 88, Ticket_UsersId = 4 },
                new Tickets() { Id = 77, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 26, Ticket_GamesId = 88, Ticket_UsersId = 5 },
                new Tickets() { Id = 78, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 27, Ticket_GamesId = 88, Ticket_UsersId = 6 },

                //etapa 8
                new Tickets() { Id = 79, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 1, Ticket_GamesId = 107, Ticket_UsersId = 7 },
                new Tickets() { Id = 80, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 2, Ticket_GamesId = 107, Ticket_UsersId = 8 },
                new Tickets() { Id = 81, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 3, Ticket_GamesId = 107, Ticket_UsersId = 9 },
                new Tickets() { Id = 82, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 4, Ticket_GamesId = 107, Ticket_UsersId = 10 },
                new Tickets() { Id = 83, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 5, Ticket_GamesId = 107, Ticket_UsersId = 11 },
                new Tickets() { Id = 84, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 6, Ticket_GamesId = 107, Ticket_UsersId = 12 },
                new Tickets() { Id = 85, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 7, Ticket_GamesId = 107, Ticket_UsersId = 13 },
                new Tickets() { Id = 86, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 8, Ticket_GamesId = 107, Ticket_UsersId = 14 },

                new Tickets() { Id = 87, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 11, Ticket_GamesId = 112, Ticket_UsersId = 15 },
                new Tickets() { Id = 88, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 12, Ticket_GamesId = 112, Ticket_UsersId = 16 },
                new Tickets() { Id = 89, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 13, Ticket_GamesId = 112, Ticket_UsersId = 17 },
                new Tickets() { Id = 90, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 14, Ticket_GamesId = 112, Ticket_UsersId = 18 },
                new Tickets() { Id = 91, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 15, Ticket_GamesId = 112, Ticket_UsersId = 19 },
                new Tickets() { Id = 92, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 16, Ticket_GamesId = 112, Ticket_UsersId = 20 },
                new Tickets() { Id = 93, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 17, Ticket_GamesId = 112, Ticket_UsersId = 21 },
                new Tickets() { Id = 94, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 18, Ticket_GamesId = 112, Ticket_UsersId = 22 },
                new Tickets() { Id = 95, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 19, Ticket_GamesId = 112, Ticket_UsersId = 23 },

                new Tickets() { Id = 96, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 21, Ticket_GamesId = 117, Ticket_UsersId = 24 },
                new Tickets() { Id = 97, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 22, Ticket_GamesId = 117, Ticket_UsersId = 25 },
                new Tickets() { Id = 98, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 23, Ticket_GamesId = 117, Ticket_UsersId = 26 },
                new Tickets() { Id = 99, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 24, Ticket_GamesId = 117, Ticket_UsersId = 27 },
                new Tickets() { Id = 100, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 25, Ticket_GamesId = 117, Ticket_UsersId = 28 },
                new Tickets() { Id = 101, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 26, Ticket_GamesId = 117, Ticket_UsersId = 29 },
                new Tickets() { Id = 102, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 27, Ticket_GamesId = 117, Ticket_UsersId = 30 },
                new Tickets() { Id = 103, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 28, Ticket_GamesId = 117, Ticket_UsersId = 31 },
                new Tickets() { Id = 104, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 29, Ticket_GamesId = 117, Ticket_UsersId = 1 },
                new Tickets() { Id = 105, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 30, Ticket_GamesId = 117, Ticket_UsersId = 2 },


                //cupa Romaniei
                //cupa tur 1(optimi)
                new Tickets() { Id = 106, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 1, Ticket_GamesId = 271, Ticket_UsersId = 3 },
                new Tickets() { Id = 107, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 2, Ticket_GamesId = 271, Ticket_UsersId = 4 },
                new Tickets() { Id = 108, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 3, Ticket_GamesId = 271, Ticket_UsersId = 5 },
                new Tickets() { Id = 109, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 4, Ticket_GamesId = 271, Ticket_UsersId = 6 },
                new Tickets() { Id = 110, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 5, Ticket_GamesId = 271, Ticket_UsersId = 7 },
                new Tickets() { Id = 111, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 6, Ticket_GamesId = 271, Ticket_UsersId = 8 },
                new Tickets() { Id = 112, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 7, Ticket_GamesId = 271, Ticket_UsersId = 9 },
                new Tickets() { Id = 113, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 8, Ticket_GamesId = 271, Ticket_UsersId = 10 },
                new Tickets() { Id = 114, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 9, Ticket_GamesId = 271, Ticket_UsersId = 11 },
                new Tickets() { Id = 115, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 10, Ticket_GamesId = 271, Ticket_UsersId = 12 },

                //cupa tur 2(sferturi)
                new Tickets() { Id = 116, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 1, Ticket_GamesId = 287, Ticket_UsersId = 13 },
                new Tickets() { Id = 117, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 2, Ticket_GamesId = 287, Ticket_UsersId = 14 },
                new Tickets() { Id = 118, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 3, Ticket_GamesId = 287, Ticket_UsersId = 15 },
                new Tickets() { Id = 119, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 4, Ticket_GamesId = 287, Ticket_UsersId = 16 },
                new Tickets() { Id = 120, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 5, Ticket_GamesId = 287, Ticket_UsersId = 17 },
                new Tickets() { Id = 121, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 6, Ticket_GamesId = 287, Ticket_UsersId = 18 },
                new Tickets() { Id = 122, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 7, Ticket_GamesId = 287, Ticket_UsersId = 19 },
                new Tickets() { Id = 123, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 8, Ticket_GamesId = 287, Ticket_UsersId = 20 },
                new Tickets() { Id = 124, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 9, Ticket_GamesId = 287, Ticket_UsersId = 21 },
                new Tickets() { Id = 125, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 10, Ticket_GamesId = 287, Ticket_UsersId = 22 },

                //cupa tur 3(semi finala)
                new Tickets() { Id = 126, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 1, Ticket_GamesId = 295, Ticket_UsersId = 23 },
                new Tickets() { Id = 127, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 2, Ticket_GamesId = 295, Ticket_UsersId = 24 },
                new Tickets() { Id = 128, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 3, Ticket_GamesId = 295, Ticket_UsersId = 25 },
                new Tickets() { Id = 129, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 4, Ticket_GamesId = 295, Ticket_UsersId = 26 },
                new Tickets() { Id = 130, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 5, Ticket_GamesId = 295, Ticket_UsersId = 27 },
                new Tickets() { Id = 131, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 6, Ticket_GamesId = 295, Ticket_UsersId = 28 },
                new Tickets() { Id = 132, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 7, Ticket_GamesId = 295, Ticket_UsersId = 29 },
                new Tickets() { Id = 133, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 8, Ticket_GamesId = 295, Ticket_UsersId = 30 },
                new Tickets() { Id = 134, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 9, Ticket_GamesId = 295, Ticket_UsersId = 31 },
                new Tickets() { Id = 135, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 10, Ticket_GamesId = 295, Ticket_UsersId = 1 },

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //ucl
                new Tickets() { Id = 136, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 1, Ticket_GamesId = 301, Ticket_UsersId = 2 },
                new Tickets() { Id = 137, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 2, Ticket_GamesId = 301, Ticket_UsersId = 3 },
                new Tickets() { Id = 138, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 3, Ticket_GamesId = 301, Ticket_UsersId = 4 },
                new Tickets() { Id = 139, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 4, Ticket_GamesId = 301, Ticket_UsersId = 5 },
                new Tickets() { Id = 140, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 5, Ticket_GamesId = 301, Ticket_UsersId = 6 },
                new Tickets() { Id = 141, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 6, Ticket_GamesId = 301, Ticket_UsersId = 7 },

                new Tickets() { Id = 142, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 1, Ticket_GamesId = 311, Ticket_UsersId = 8 },
                new Tickets() { Id = 143, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 2, Ticket_GamesId = 311, Ticket_UsersId = 9 },
                new Tickets() { Id = 144, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 3, Ticket_GamesId = 311, Ticket_UsersId = 10 },
                new Tickets() { Id = 145, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 4, Ticket_GamesId = 311, Ticket_UsersId = 11 },
                new Tickets() { Id = 146, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 5, Ticket_GamesId = 311, Ticket_UsersId = 12 },
                new Tickets() { Id = 147, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 6, Ticket_GamesId = 311, Ticket_UsersId = 13 },

                new Tickets() { Id = 148, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 1, Ticket_GamesId = 321, Ticket_UsersId = 14 },
                new Tickets() { Id = 149, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 2, Ticket_GamesId = 321, Ticket_UsersId = 15 },
                new Tickets() { Id = 150, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 3, Ticket_GamesId = 321, Ticket_UsersId = 16 },
                new Tickets() { Id = 151, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 4, Ticket_GamesId = 321, Ticket_UsersId = 17 },
                new Tickets() { Id = 152, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 5, Ticket_GamesId = 321, Ticket_UsersId = 18 },
                new Tickets() { Id = 153, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 6, Ticket_GamesId = 321, Ticket_UsersId = 19 },
                new Tickets() { Id = 154, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 7, Ticket_GamesId = 321, Ticket_UsersId = 20 }
            });

            modelBuilder.Entity<PlayerStatisticsPerGame>().HasData(new List<PlayerStatisticsPerGame>()
            {
                //etapa1
                new PlayerStatisticsPerGame() { Id = 1, Goals = 1, PlayerStatisticsPerGame_GamesId = 1, PlayerStatisticsPerGame_PlayersId = 11 },
                new PlayerStatisticsPerGame() { Id = 2, Goals = 1, PlayerStatisticsPerGame_GamesId = 1, PlayerStatisticsPerGame_PlayersId = 1 },
                new PlayerStatisticsPerGame() { Id = 3, Goals = 1, PlayerStatisticsPerGame_GamesId = 1, PlayerStatisticsPerGame_PlayersId = 194 },

                new PlayerStatisticsPerGame() { Id = 4, Goals = 1, PlayerStatisticsPerGame_GamesId = 3, PlayerStatisticsPerGame_PlayersId = 47 },
                new PlayerStatisticsPerGame() { Id = 5, Goals = 1, PlayerStatisticsPerGame_GamesId = 3, PlayerStatisticsPerGame_PlayersId = 56 },
                new PlayerStatisticsPerGame() { Id = 6, Goals = 1, PlayerStatisticsPerGame_GamesId = 3, PlayerStatisticsPerGame_PlayersId = 158 },

                new PlayerStatisticsPerGame() { Id = 7, Goals = 1, PlayerStatisticsPerGame_GamesId = 4, PlayerStatisticsPerGame_PlayersId = 136 },

                new PlayerStatisticsPerGame() { Id = 8, Goals = 1, PlayerStatisticsPerGame_GamesId = 5, PlayerStatisticsPerGame_PlayersId = 98 },
                new PlayerStatisticsPerGame() { Id = 9, Goals = 1, PlayerStatisticsPerGame_GamesId = 5, PlayerStatisticsPerGame_PlayersId = 113 },
                new PlayerStatisticsPerGame() { Id = 10, Goals = 1, PlayerStatisticsPerGame_GamesId = 5, PlayerStatisticsPerGame_PlayersId = 111 },

                new PlayerStatisticsPerGame() { Id = 11, Goals = 1, PlayerStatisticsPerGame_GamesId = 7, PlayerStatisticsPerGame_PlayersId = 230 },
                new PlayerStatisticsPerGame() { Id = 12, Goals = 1, PlayerStatisticsPerGame_GamesId = 7, PlayerStatisticsPerGame_PlayersId = 221 },
                new PlayerStatisticsPerGame() { Id = 13, Goals = 1, PlayerStatisticsPerGame_GamesId = 7, PlayerStatisticsPerGame_PlayersId = 363 },
                new PlayerStatisticsPerGame() { Id = 14, Goals = 1, PlayerStatisticsPerGame_GamesId = 7, PlayerStatisticsPerGame_PlayersId = 369 },
                new PlayerStatisticsPerGame() { Id = 15, Goals = 1, PlayerStatisticsPerGame_GamesId = 7, PlayerStatisticsPerGame_PlayersId = 364 },

                new PlayerStatisticsPerGame() { Id = 16, Goals = 1, PlayerStatisticsPerGame_GamesId = 8, PlayerStatisticsPerGame_PlayersId = 250 },
                new PlayerStatisticsPerGame() { Id = 17, Goals = 1, PlayerStatisticsPerGame_GamesId = 8, PlayerStatisticsPerGame_PlayersId = 254 },
                new PlayerStatisticsPerGame() { Id = 18, Goals = 1, PlayerStatisticsPerGame_GamesId = 8, PlayerStatisticsPerGame_PlayersId = 258 },
                new PlayerStatisticsPerGame() { Id = 19, Goals = 1, PlayerStatisticsPerGame_GamesId = 8, PlayerStatisticsPerGame_PlayersId = 343 },
                new PlayerStatisticsPerGame() { Id = 20, Goals = 1, PlayerStatisticsPerGame_GamesId = 8, PlayerStatisticsPerGame_PlayersId = 357 },
                new PlayerStatisticsPerGame() { Id = 21, Goals = 1, PlayerStatisticsPerGame_GamesId = 8, PlayerStatisticsPerGame_PlayersId = 358 },

                new PlayerStatisticsPerGame() { Id = 22, Goals = 1, PlayerStatisticsPerGame_GamesId = 9, PlayerStatisticsPerGame_PlayersId = 262 },
                new PlayerStatisticsPerGame() { Id = 23, Goals = 1, PlayerStatisticsPerGame_GamesId = 9, PlayerStatisticsPerGame_PlayersId = 277 },
                new PlayerStatisticsPerGame() { Id = 24, Goals = 1, PlayerStatisticsPerGame_GamesId = 9, PlayerStatisticsPerGame_PlayersId = 336 },

                new PlayerStatisticsPerGame() { Id = 25, Goals = 1, PlayerStatisticsPerGame_GamesId = 10, PlayerStatisticsPerGame_PlayersId = 293 },
                new PlayerStatisticsPerGame() { Id = 26, Goals = 1, PlayerStatisticsPerGame_GamesId = 10, PlayerStatisticsPerGame_PlayersId = 299 },
                new PlayerStatisticsPerGame() { Id = 27, Goals = 1, PlayerStatisticsPerGame_GamesId = 10, PlayerStatisticsPerGame_PlayersId = 310 },
                new PlayerStatisticsPerGame() { Id = 28, Goals = 1, PlayerStatisticsPerGame_GamesId = 10, PlayerStatisticsPerGame_PlayersId = 313 },
                new PlayerStatisticsPerGame() { Id = 29, Goals = 1, PlayerStatisticsPerGame_GamesId = 10, PlayerStatisticsPerGame_PlayersId = 317 },

                new PlayerStatisticsPerGame() { Id = 30, Goals = 1, PlayerStatisticsPerGame_GamesId = 11, PlayerStatisticsPerGame_PlayersId = 420 },
                new PlayerStatisticsPerGame() { Id = 31, Goals = 1, PlayerStatisticsPerGame_GamesId = 11, PlayerStatisticsPerGame_PlayersId = 406 },
                new PlayerStatisticsPerGame() { Id = 32, Goals = 1, PlayerStatisticsPerGame_GamesId = 11, PlayerStatisticsPerGame_PlayersId = 511 },

                new PlayerStatisticsPerGame() { Id = 33, Goals = 1, PlayerStatisticsPerGame_GamesId = 12, PlayerStatisticsPerGame_PlayersId = 431 },
                new PlayerStatisticsPerGame() { Id = 34, Goals = 1, PlayerStatisticsPerGame_GamesId = 12, PlayerStatisticsPerGame_PlayersId = 437 },
                new PlayerStatisticsPerGame() { Id = 35, Goals = 1, PlayerStatisticsPerGame_GamesId = 12, PlayerStatisticsPerGame_PlayersId = 537 },

                new PlayerStatisticsPerGame() { Id = 36, Goals = 1, PlayerStatisticsPerGame_GamesId = 13, PlayerStatisticsPerGame_PlayersId = 451 },
                new PlayerStatisticsPerGame() { Id = 37, Goals = 1, PlayerStatisticsPerGame_GamesId = 13, PlayerStatisticsPerGame_PlayersId = 457 },

                new PlayerStatisticsPerGame() { Id = 38, Goals = 1, PlayerStatisticsPerGame_GamesId = 14, PlayerStatisticsPerGame_PlayersId = 473 },
                new PlayerStatisticsPerGame() { Id = 39, Goals = 1, PlayerStatisticsPerGame_GamesId = 14, PlayerStatisticsPerGame_PlayersId = 464 },
                new PlayerStatisticsPerGame() { Id = 40, Goals = 1, PlayerStatisticsPerGame_GamesId = 14, PlayerStatisticsPerGame_PlayersId = 561 },

                new PlayerStatisticsPerGame() { Id = 41, Goals = 1, PlayerStatisticsPerGame_GamesId = 15, PlayerStatisticsPerGame_PlayersId = 484 },
                new PlayerStatisticsPerGame() { Id = 42, Goals = 1, PlayerStatisticsPerGame_GamesId = 15, PlayerStatisticsPerGame_PlayersId = 586 },
                new PlayerStatisticsPerGame() { Id = 43, Goals = 1, PlayerStatisticsPerGame_GamesId = 15, PlayerStatisticsPerGame_PlayersId = 581 },

                // ETAPA 2 - PlayerStatisticsPerGame
                new PlayerStatisticsPerGame() { Id = 44, Goals = 1, PlayerStatisticsPerGame_GamesId = 16, PlayerStatisticsPerGame_PlayersId = 185 },
                new PlayerStatisticsPerGame() { Id = 45, Goals = 1, PlayerStatisticsPerGame_GamesId = 16, PlayerStatisticsPerGame_PlayersId = 192 },
                new PlayerStatisticsPerGame() { Id = 46, Goals = 1, PlayerStatisticsPerGame_GamesId = 16, PlayerStatisticsPerGame_PlayersId = 110 },

                new PlayerStatisticsPerGame() { Id = 47, Goals = 1, PlayerStatisticsPerGame_GamesId = 17, PlayerStatisticsPerGame_PlayersId = 121 },
                new PlayerStatisticsPerGame() { Id = 48, Goals = 1, PlayerStatisticsPerGame_GamesId = 17, PlayerStatisticsPerGame_PlayersId = 125 },
                new PlayerStatisticsPerGame() { Id = 49, Goals = 1, PlayerStatisticsPerGame_GamesId = 17, PlayerStatisticsPerGame_PlayersId = 135 },
                new PlayerStatisticsPerGame() { Id = 50, Goals = 1, PlayerStatisticsPerGame_GamesId = 17, PlayerStatisticsPerGame_PlayersId = 100 },

                new PlayerStatisticsPerGame() { Id = 51, Goals = 1, PlayerStatisticsPerGame_GamesId = 18, PlayerStatisticsPerGame_PlayersId = 151 },
                new PlayerStatisticsPerGame() { Id = 52, Goals = 1, PlayerStatisticsPerGame_GamesId = 18, PlayerStatisticsPerGame_PlayersId = 156 },
                new PlayerStatisticsPerGame() { Id = 53, Goals = 1, PlayerStatisticsPerGame_GamesId = 18, PlayerStatisticsPerGame_PlayersId = 61 },
                new PlayerStatisticsPerGame() { Id = 54, Goals = 1, PlayerStatisticsPerGame_GamesId = 18, PlayerStatisticsPerGame_PlayersId = 65 },

                new PlayerStatisticsPerGame() { Id = 55, Goals = 1, PlayerStatisticsPerGame_GamesId = 19, PlayerStatisticsPerGame_PlayersId = 41 },

                new PlayerStatisticsPerGame() { Id = 56, Goals = 1, PlayerStatisticsPerGame_GamesId = 20, PlayerStatisticsPerGame_PlayersId = 2 },
                new PlayerStatisticsPerGame() { Id = 57, Goals = 1, PlayerStatisticsPerGame_GamesId = 20, PlayerStatisticsPerGame_PlayersId = 14 },
                new PlayerStatisticsPerGame() { Id = 58, Goals = 1, PlayerStatisticsPerGame_GamesId = 20, PlayerStatisticsPerGame_PlayersId = 11 },
                new PlayerStatisticsPerGame() { Id = 59, Goals = 1, PlayerStatisticsPerGame_GamesId = 20, PlayerStatisticsPerGame_PlayersId = 15 },
                new PlayerStatisticsPerGame() { Id = 60, Goals = 1, PlayerStatisticsPerGame_GamesId = 20, PlayerStatisticsPerGame_PlayersId = 25 },

                new PlayerStatisticsPerGame() { Id = 61, Goals = 1, PlayerStatisticsPerGame_GamesId = 21, PlayerStatisticsPerGame_PlayersId = 381 },
                new PlayerStatisticsPerGame() { Id = 62, Goals = 1, PlayerStatisticsPerGame_GamesId = 21, PlayerStatisticsPerGame_PlayersId = 384 },

                new PlayerStatisticsPerGame() { Id = 63, Goals = 1, PlayerStatisticsPerGame_GamesId = 22, PlayerStatisticsPerGame_PlayersId = 321 },
                new PlayerStatisticsPerGame() { Id = 64, Goals = 1, PlayerStatisticsPerGame_GamesId = 22, PlayerStatisticsPerGame_PlayersId = 338 },
                new PlayerStatisticsPerGame() { Id = 65, Goals = 1, PlayerStatisticsPerGame_GamesId = 22, PlayerStatisticsPerGame_PlayersId = 281 },
                new PlayerStatisticsPerGame() { Id = 66, Goals = 1, PlayerStatisticsPerGame_GamesId = 22, PlayerStatisticsPerGame_PlayersId = 294 },

                new PlayerStatisticsPerGame() { Id = 67, Goals = 1, PlayerStatisticsPerGame_GamesId = 23, PlayerStatisticsPerGame_PlayersId = 261 },
                new PlayerStatisticsPerGame() { Id = 68, Goals = 1, PlayerStatisticsPerGame_GamesId = 23, PlayerStatisticsPerGame_PlayersId = 274 },
                new PlayerStatisticsPerGame() { Id = 69, Goals = 1, PlayerStatisticsPerGame_GamesId = 23, PlayerStatisticsPerGame_PlayersId = 276 },

                new PlayerStatisticsPerGame() { Id = 70, Goals = 1, PlayerStatisticsPerGame_GamesId = 24, PlayerStatisticsPerGame_PlayersId = 361 },
                new PlayerStatisticsPerGame() { Id = 71, Goals = 1, PlayerStatisticsPerGame_GamesId = 24, PlayerStatisticsPerGame_PlayersId = 241 },

                new PlayerStatisticsPerGame() { Id = 72, Goals = 1, PlayerStatisticsPerGame_GamesId = 25, PlayerStatisticsPerGame_PlayersId = 222 },
                new PlayerStatisticsPerGame() { Id = 73, Goals = 1, PlayerStatisticsPerGame_GamesId = 25, PlayerStatisticsPerGame_PlayersId = 235 },

                new PlayerStatisticsPerGame() { Id = 74, Goals = 1, PlayerStatisticsPerGame_GamesId = 26, PlayerStatisticsPerGame_PlayersId = 581 },
                new PlayerStatisticsPerGame() { Id = 75, Goals = 1, PlayerStatisticsPerGame_GamesId = 26, PlayerStatisticsPerGame_PlayersId = 593 },
                new PlayerStatisticsPerGame() { Id = 76, Goals = 1, PlayerStatisticsPerGame_GamesId = 26, PlayerStatisticsPerGame_PlayersId = 595 },

                new PlayerStatisticsPerGame() { Id = 77, Goals = 1, PlayerStatisticsPerGame_GamesId = 27, PlayerStatisticsPerGame_PlayersId = 539 },
                new PlayerStatisticsPerGame() { Id = 78, Goals = 1, PlayerStatisticsPerGame_GamesId = 27, PlayerStatisticsPerGame_PlayersId = 521 },
                new PlayerStatisticsPerGame() { Id = 79, Goals = 1, PlayerStatisticsPerGame_GamesId = 27, PlayerStatisticsPerGame_PlayersId = 481 },

                new PlayerStatisticsPerGame() { Id = 80, Goals = 1, PlayerStatisticsPerGame_GamesId = 28, PlayerStatisticsPerGame_PlayersId = 462 },
                new PlayerStatisticsPerGame() { Id = 81, Goals = 1, PlayerStatisticsPerGame_GamesId = 28, PlayerStatisticsPerGame_PlayersId = 479 },

                new PlayerStatisticsPerGame() { Id = 82, Goals = 1, PlayerStatisticsPerGame_GamesId = 29, PlayerStatisticsPerGame_PlayersId = 561 },
                new PlayerStatisticsPerGame() { Id = 83, Goals = 1, PlayerStatisticsPerGame_GamesId = 29, PlayerStatisticsPerGame_PlayersId = 445 },
                new PlayerStatisticsPerGame() { Id = 84, Goals = 1, PlayerStatisticsPerGame_GamesId = 29, PlayerStatisticsPerGame_PlayersId = 441 },
                new PlayerStatisticsPerGame() { Id = 85, Goals = 1, PlayerStatisticsPerGame_GamesId = 29, PlayerStatisticsPerGame_PlayersId = 459 },

                new PlayerStatisticsPerGame() { Id = 86, Goals = 1, PlayerStatisticsPerGame_GamesId = 30, PlayerStatisticsPerGame_PlayersId = 401 },
                new PlayerStatisticsPerGame() { Id = 87, Goals = 1, PlayerStatisticsPerGame_GamesId = 30, PlayerStatisticsPerGame_PlayersId = 412 },
                new PlayerStatisticsPerGame() { Id = 88, Goals = 1, PlayerStatisticsPerGame_GamesId = 30, PlayerStatisticsPerGame_PlayersId = 427 },
                new PlayerStatisticsPerGame() { Id = 89, Goals = 1, PlayerStatisticsPerGame_GamesId = 30, PlayerStatisticsPerGame_PlayersId = 440 },

                // ETAPA 3 - PlayerStatisticsPerGame
                new PlayerStatisticsPerGame() { Id = 90, Goals = 1, PlayerStatisticsPerGame_GamesId = 31, PlayerStatisticsPerGame_PlayersId = 32 },
                new PlayerStatisticsPerGame() { Id = 91, Goals = 1, PlayerStatisticsPerGame_GamesId = 31, PlayerStatisticsPerGame_PlayersId = 198 },
                new PlayerStatisticsPerGame() { Id = 92, Goals = 1, PlayerStatisticsPerGame_GamesId = 31, PlayerStatisticsPerGame_PlayersId = 189 },

                new PlayerStatisticsPerGame() { Id = 93, Goals = 1, PlayerStatisticsPerGame_GamesId = 32, PlayerStatisticsPerGame_PlayersId = 17 },

                new PlayerStatisticsPerGame() { Id = 94, Goals = 1, PlayerStatisticsPerGame_GamesId = 33, PlayerStatisticsPerGame_PlayersId = 66 },
                new PlayerStatisticsPerGame() { Id = 95, Goals = 1, PlayerStatisticsPerGame_GamesId = 33, PlayerStatisticsPerGame_PlayersId = 77 },
                new PlayerStatisticsPerGame() { Id = 96, Goals = 1, PlayerStatisticsPerGame_GamesId = 33, PlayerStatisticsPerGame_PlayersId = 168 },
                new PlayerStatisticsPerGame() { Id = 97, Goals = 1, PlayerStatisticsPerGame_GamesId = 33, PlayerStatisticsPerGame_PlayersId = 177 },

                new PlayerStatisticsPerGame() { Id = 98, Goals = 1, PlayerStatisticsPerGame_GamesId = 34, PlayerStatisticsPerGame_PlayersId = 82 },
                new PlayerStatisticsPerGame() { Id = 99, Goals = 1, PlayerStatisticsPerGame_GamesId = 34, PlayerStatisticsPerGame_PlayersId = 84 },
                new PlayerStatisticsPerGame() { Id = 100, Goals = 1, PlayerStatisticsPerGame_GamesId = 34, PlayerStatisticsPerGame_PlayersId = 89 },

                new PlayerStatisticsPerGame() { Id = 101, Goals = 1, PlayerStatisticsPerGame_GamesId = 35, PlayerStatisticsPerGame_PlayersId = 113 },
                new PlayerStatisticsPerGame() { Id = 102, Goals = 1, PlayerStatisticsPerGame_GamesId = 35, PlayerStatisticsPerGame_PlayersId = 131 },

                new PlayerStatisticsPerGame() { Id = 103, Goals = 1, PlayerStatisticsPerGame_GamesId = 36, PlayerStatisticsPerGame_PlayersId = 233 },
                new PlayerStatisticsPerGame() { Id = 104, Goals = 1, PlayerStatisticsPerGame_GamesId = 36, PlayerStatisticsPerGame_PlayersId = 399 },

                new PlayerStatisticsPerGame() { Id = 105, Goals = 1, PlayerStatisticsPerGame_GamesId = 37, PlayerStatisticsPerGame_PlayersId = 217 },
                new PlayerStatisticsPerGame() { Id = 106, Goals = 1, PlayerStatisticsPerGame_GamesId = 37, PlayerStatisticsPerGame_PlayersId = 215 },

                new PlayerStatisticsPerGame() { Id = 107, Goals = 1, PlayerStatisticsPerGame_GamesId = 38, PlayerStatisticsPerGame_PlayersId = 280 },
                new PlayerStatisticsPerGame() { Id = 108, Goals = 1, PlayerStatisticsPerGame_GamesId = 38, PlayerStatisticsPerGame_PlayersId = 274 },
                new PlayerStatisticsPerGame() { Id = 109, Goals = 1, PlayerStatisticsPerGame_GamesId = 38, PlayerStatisticsPerGame_PlayersId = 273 },
                new PlayerStatisticsPerGame() { Id = 110, Goals = 1, PlayerStatisticsPerGame_GamesId = 38, PlayerStatisticsPerGame_PlayersId = 371 },
                new PlayerStatisticsPerGame() { Id = 111, Goals = 1, PlayerStatisticsPerGame_GamesId = 38, PlayerStatisticsPerGame_PlayersId = 376 },
                new PlayerStatisticsPerGame() { Id = 112, Goals = 1, PlayerStatisticsPerGame_GamesId = 38, PlayerStatisticsPerGame_PlayersId = 362 },
                new PlayerStatisticsPerGame() { Id = 113, Goals = 1, PlayerStatisticsPerGame_GamesId = 38, PlayerStatisticsPerGame_PlayersId = 378 },

                new PlayerStatisticsPerGame() { Id = 114, Goals = 1, PlayerStatisticsPerGame_GamesId = 39, PlayerStatisticsPerGame_PlayersId = 300 },
                new PlayerStatisticsPerGame() { Id = 115, Goals = 1, PlayerStatisticsPerGame_GamesId = 39, PlayerStatisticsPerGame_PlayersId = 293 },

                new PlayerStatisticsPerGame() { Id = 116, Goals = 1, PlayerStatisticsPerGame_GamesId = 40, PlayerStatisticsPerGame_PlayersId = 315 },
                new PlayerStatisticsPerGame() { Id = 117, Goals = 1, PlayerStatisticsPerGame_GamesId = 40, PlayerStatisticsPerGame_PlayersId = 336 },
                new PlayerStatisticsPerGame() { Id = 118, Goals = 1, PlayerStatisticsPerGame_GamesId = 40, PlayerStatisticsPerGame_PlayersId = 334 },

                new PlayerStatisticsPerGame() { Id = 119, Goals = 1, PlayerStatisticsPerGame_GamesId = 41, PlayerStatisticsPerGame_PlayersId = 600 },
                new PlayerStatisticsPerGame() { Id = 120, Goals = 1, PlayerStatisticsPerGame_GamesId = 41, PlayerStatisticsPerGame_PlayersId = 599 },
                new PlayerStatisticsPerGame() { Id = 121, Goals = 1, PlayerStatisticsPerGame_GamesId = 41, PlayerStatisticsPerGame_PlayersId = 589 },

                new PlayerStatisticsPerGame() { Id = 122, Goals = 1, PlayerStatisticsPerGame_GamesId = 42, PlayerStatisticsPerGame_PlayersId = 441 },
                new PlayerStatisticsPerGame() { Id = 123, Goals = 1, PlayerStatisticsPerGame_GamesId = 42, PlayerStatisticsPerGame_PlayersId = 453 },
                new PlayerStatisticsPerGame() { Id = 124, Goals = 1, PlayerStatisticsPerGame_GamesId = 42, PlayerStatisticsPerGame_PlayersId = 413 },
                new PlayerStatisticsPerGame() { Id = 125, Goals = 1, PlayerStatisticsPerGame_GamesId = 42, PlayerStatisticsPerGame_PlayersId = 420 },

                new PlayerStatisticsPerGame() { Id = 126, Goals = 1, PlayerStatisticsPerGame_GamesId = 43, PlayerStatisticsPerGame_PlayersId = 569 },

                new PlayerStatisticsPerGame() { Id = 127, Goals = 1, PlayerStatisticsPerGame_GamesId = 44, PlayerStatisticsPerGame_PlayersId = 485 },

                new PlayerStatisticsPerGame() { Id = 128, Goals = 1, PlayerStatisticsPerGame_GamesId = 45, PlayerStatisticsPerGame_PlayersId = 521 },
                new PlayerStatisticsPerGame() { Id = 129, Goals = 1, PlayerStatisticsPerGame_GamesId = 45, PlayerStatisticsPerGame_PlayersId = 523 },

                // ETAPA 4 - PlayerStatisticsPerGame
                new PlayerStatisticsPerGame() { Id = 133, Goals = 1, PlayerStatisticsPerGame_GamesId = 46, PlayerStatisticsPerGame_PlayersId = 191 },
                new PlayerStatisticsPerGame() { Id = 134, Goals = 1, PlayerStatisticsPerGame_GamesId = 46, PlayerStatisticsPerGame_PlayersId = 198 },
                new PlayerStatisticsPerGame() { Id = 135, Goals = 1, PlayerStatisticsPerGame_GamesId = 46, PlayerStatisticsPerGame_PlayersId = 127 },

                new PlayerStatisticsPerGame() { Id = 136, Goals = 1, PlayerStatisticsPerGame_GamesId = 47, PlayerStatisticsPerGame_PlayersId = 160 },

                new PlayerStatisticsPerGame() { Id = 143, Goals = 1, PlayerStatisticsPerGame_GamesId = 49, PlayerStatisticsPerGame_PlayersId = 8 },
                new PlayerStatisticsPerGame() { Id = 144, Goals = 1, PlayerStatisticsPerGame_GamesId = 49, PlayerStatisticsPerGame_PlayersId = 77 },

                new PlayerStatisticsPerGame() { Id = 146, Goals = 1, PlayerStatisticsPerGame_GamesId = 50, PlayerStatisticsPerGame_PlayersId = 36 },
                new PlayerStatisticsPerGame() { Id = 147, Goals = 1, PlayerStatisticsPerGame_GamesId = 50, PlayerStatisticsPerGame_PlayersId = 53 },

                new PlayerStatisticsPerGame() { Id = 148, Goals = 1, PlayerStatisticsPerGame_GamesId = 51, PlayerStatisticsPerGame_PlayersId = 387 },
                new PlayerStatisticsPerGame() { Id = 149, Goals = 1, PlayerStatisticsPerGame_GamesId = 51, PlayerStatisticsPerGame_PlayersId = 398 },
                new PlayerStatisticsPerGame() { Id = 150, Goals = 1, PlayerStatisticsPerGame_GamesId = 51, PlayerStatisticsPerGame_PlayersId = 336 },

                new PlayerStatisticsPerGame() { Id = 151, Goals = 1, PlayerStatisticsPerGame_GamesId = 52, PlayerStatisticsPerGame_PlayersId = 314 },

                new PlayerStatisticsPerGame() { Id = 152, Goals = 1, PlayerStatisticsPerGame_GamesId = 53, PlayerStatisticsPerGame_PlayersId = 372 },
                new PlayerStatisticsPerGame() { Id = 153, Goals = 1, PlayerStatisticsPerGame_GamesId = 53, PlayerStatisticsPerGame_PlayersId = 291 },
                new PlayerStatisticsPerGame() { Id = 154, Goals = 1, PlayerStatisticsPerGame_GamesId = 53, PlayerStatisticsPerGame_PlayersId = 295 },

                new PlayerStatisticsPerGame() { Id = 155, Goals = 1, PlayerStatisticsPerGame_GamesId = 55, PlayerStatisticsPerGame_PlayersId = 237 },
                new PlayerStatisticsPerGame() { Id = 156, Goals = 1, PlayerStatisticsPerGame_GamesId = 55, PlayerStatisticsPerGame_PlayersId = 241 },

                new PlayerStatisticsPerGame() { Id = 157, Goals = 1, PlayerStatisticsPerGame_GamesId = 56, PlayerStatisticsPerGame_PlayersId = 581 },
               

                new PlayerStatisticsPerGame() { Id = 161, Goals = 1, PlayerStatisticsPerGame_GamesId = 58, PlayerStatisticsPerGame_PlayersId = 569 },
                new PlayerStatisticsPerGame() { Id = 162, Goals = 1, PlayerStatisticsPerGame_GamesId = 58, PlayerStatisticsPerGame_PlayersId = 486 },

                new PlayerStatisticsPerGame() { Id = 164, Goals = 1, PlayerStatisticsPerGame_GamesId = 60, PlayerStatisticsPerGame_PlayersId = 425 },
                new PlayerStatisticsPerGame() { Id = 165, Goals = 1, PlayerStatisticsPerGame_GamesId = 60, PlayerStatisticsPerGame_PlayersId = 431 },
                new PlayerStatisticsPerGame() { Id = 166, Goals = 1, PlayerStatisticsPerGame_GamesId = 60, PlayerStatisticsPerGame_PlayersId = 441 },
                new PlayerStatisticsPerGame() { Id = 167, Goals = 1, PlayerStatisticsPerGame_GamesId = 60, PlayerStatisticsPerGame_PlayersId = 445 },

                // ETAPA 5 - PlayerStatisticsPerGame

                new PlayerStatisticsPerGame() { Id = 168, Goals = 1, PlayerStatisticsPerGame_GamesId = 61, PlayerStatisticsPerGame_PlayersId = 42 },
                new PlayerStatisticsPerGame() { Id = 169, Goals = 1, PlayerStatisticsPerGame_GamesId = 61, PlayerStatisticsPerGame_PlayersId = 46 },

                new PlayerStatisticsPerGame() { Id = 170, Goals = 1, PlayerStatisticsPerGame_GamesId = 62, PlayerStatisticsPerGame_PlayersId = 65 },
                new PlayerStatisticsPerGame() { Id = 171, Goals = 1, PlayerStatisticsPerGame_GamesId = 62, PlayerStatisticsPerGame_PlayersId = 32 },
                new PlayerStatisticsPerGame() { Id = 172, Goals = 1, PlayerStatisticsPerGame_GamesId = 62, PlayerStatisticsPerGame_PlayersId = 38 },
                new PlayerStatisticsPerGame() { Id = 173, Goals = 1, PlayerStatisticsPerGame_GamesId = 62, PlayerStatisticsPerGame_PlayersId = 27 },

                new PlayerStatisticsPerGame() { Id = 174, Goals = 1, PlayerStatisticsPerGame_GamesId = 63, PlayerStatisticsPerGame_PlayersId = 91 },
                new PlayerStatisticsPerGame() { Id = 175, Goals = 1, PlayerStatisticsPerGame_GamesId = 63, PlayerStatisticsPerGame_PlayersId = 11 },

                new PlayerStatisticsPerGame() { Id = 176, Goals = 1, PlayerStatisticsPerGame_GamesId = 64, PlayerStatisticsPerGame_PlayersId = 175 },

                new PlayerStatisticsPerGame() { Id = 177, Goals = 1, PlayerStatisticsPerGame_GamesId = 65, PlayerStatisticsPerGame_PlayersId = 137 },
                new PlayerStatisticsPerGame() { Id = 178, Goals = 1, PlayerStatisticsPerGame_GamesId = 65, PlayerStatisticsPerGame_PlayersId = 149 },
                new PlayerStatisticsPerGame() { Id = 179, Goals = 1, PlayerStatisticsPerGame_GamesId = 65, PlayerStatisticsPerGame_PlayersId = 158 },
                new PlayerStatisticsPerGame() { Id = 180, Goals = 1, PlayerStatisticsPerGame_GamesId = 65, PlayerStatisticsPerGame_PlayersId = 154 },

                new PlayerStatisticsPerGame() { Id = 181, Goals = 1, PlayerStatisticsPerGame_GamesId = 66, PlayerStatisticsPerGame_PlayersId = 259 },

                new PlayerStatisticsPerGame() { Id = 182, Goals = 1, PlayerStatisticsPerGame_GamesId = 68, PlayerStatisticsPerGame_PlayersId = 295 },
                new PlayerStatisticsPerGame() { Id = 184, Goals = 1, PlayerStatisticsPerGame_GamesId = 68, PlayerStatisticsPerGame_PlayersId = 211 },

                new PlayerStatisticsPerGame() { Id = 185, Goals = 1, PlayerStatisticsPerGame_GamesId = 69, PlayerStatisticsPerGame_PlayersId = 370 },
                new PlayerStatisticsPerGame() { Id = 186, Goals = 1, PlayerStatisticsPerGame_GamesId = 69, PlayerStatisticsPerGame_PlayersId = 374 },
                new PlayerStatisticsPerGame() { Id = 187, Goals = 1, PlayerStatisticsPerGame_GamesId = 69, PlayerStatisticsPerGame_PlayersId = 380 },

                new PlayerStatisticsPerGame() { Id = 188, Goals = 1, PlayerStatisticsPerGame_GamesId = 70, PlayerStatisticsPerGame_PlayersId = 335 },
                new PlayerStatisticsPerGame() { Id = 189, Goals = 1, PlayerStatisticsPerGame_GamesId = 70, PlayerStatisticsPerGame_PlayersId = 347 },

              
                new PlayerStatisticsPerGame() { Id = 193, Goals = 1, PlayerStatisticsPerGame_GamesId = 72, PlayerStatisticsPerGame_PlayersId = 424 },
                new PlayerStatisticsPerGame() { Id = 194, Goals = 1, PlayerStatisticsPerGame_GamesId = 72, PlayerStatisticsPerGame_PlayersId = 432 },
                new PlayerStatisticsPerGame() { Id = 195, Goals = 1, PlayerStatisticsPerGame_GamesId = 72, PlayerStatisticsPerGame_PlayersId = 422 },

                new PlayerStatisticsPerGame() { Id = 196, Goals = 1, PlayerStatisticsPerGame_GamesId = 73, PlayerStatisticsPerGame_PlayersId = 500 },
               
                new PlayerStatisticsPerGame() { Id = 199, Goals = 1, PlayerStatisticsPerGame_GamesId = 73, PlayerStatisticsPerGame_PlayersId = 406 },

                new PlayerStatisticsPerGame() { Id = 200, Goals = 1, PlayerStatisticsPerGame_GamesId = 74, PlayerStatisticsPerGame_PlayersId = 563 },
                new PlayerStatisticsPerGame() { Id = 201, Goals = 1, PlayerStatisticsPerGame_GamesId = 74, PlayerStatisticsPerGame_PlayersId = 573 },

                new PlayerStatisticsPerGame() { Id = 203, Goals = 1, PlayerStatisticsPerGame_GamesId = 75, PlayerStatisticsPerGame_PlayersId = 541 },
                new PlayerStatisticsPerGame() { Id = 204, Goals = 1, PlayerStatisticsPerGame_GamesId = 75, PlayerStatisticsPerGame_PlayersId = 547 },

                // ETAPA 6 - PlayerStatisticsPerGame
                new PlayerStatisticsPerGame() { Id = 206, Goals = 1, PlayerStatisticsPerGame_GamesId = 76, PlayerStatisticsPerGame_PlayersId = 181 },
                new PlayerStatisticsPerGame() { Id = 207, Goals = 1, PlayerStatisticsPerGame_GamesId = 76, PlayerStatisticsPerGame_PlayersId = 187 },
                new PlayerStatisticsPerGame() { Id = 208, Goals = 1, PlayerStatisticsPerGame_GamesId = 76, PlayerStatisticsPerGame_PlayersId = 156 },

                new PlayerStatisticsPerGame() { Id = 209, Goals = 1, PlayerStatisticsPerGame_GamesId = 77, PlayerStatisticsPerGame_PlayersId = 132 },
                new PlayerStatisticsPerGame() { Id = 211, Goals = 1, PlayerStatisticsPerGame_GamesId = 77, PlayerStatisticsPerGame_PlayersId = 128 },

                new PlayerStatisticsPerGame() { Id = 212, Goals = 1, PlayerStatisticsPerGame_GamesId = 78, PlayerStatisticsPerGame_PlayersId = 6 },
                new PlayerStatisticsPerGame() { Id = 213, Goals = 1, PlayerStatisticsPerGame_GamesId = 78, PlayerStatisticsPerGame_PlayersId = 113 },

                new PlayerStatisticsPerGame() { Id = 215, Goals = 1, PlayerStatisticsPerGame_GamesId = 79, PlayerStatisticsPerGame_PlayersId = 96 },

                new PlayerStatisticsPerGame() { Id = 216, Goals = 1, PlayerStatisticsPerGame_GamesId = 80, PlayerStatisticsPerGame_PlayersId = 54 },
                new PlayerStatisticsPerGame() { Id = 217, Goals = 1, PlayerStatisticsPerGame_GamesId = 80, PlayerStatisticsPerGame_PlayersId = 61 },
                new PlayerStatisticsPerGame() { Id = 218, Goals = 1, PlayerStatisticsPerGame_GamesId = 80, PlayerStatisticsPerGame_PlayersId = 74 },
                new PlayerStatisticsPerGame() { Id = 219, Goals = 1, PlayerStatisticsPerGame_GamesId = 80, PlayerStatisticsPerGame_PlayersId = 75 },

                new PlayerStatisticsPerGame() { Id = 220, Goals = 1, PlayerStatisticsPerGame_GamesId = 81, PlayerStatisticsPerGame_PlayersId = 391 },

                new PlayerStatisticsPerGame() { Id = 221, Goals = 1, PlayerStatisticsPerGame_GamesId = 82, PlayerStatisticsPerGame_PlayersId = 377 },
                new PlayerStatisticsPerGame() { Id = 223, Goals = 1, PlayerStatisticsPerGame_GamesId = 82, PlayerStatisticsPerGame_PlayersId = 340 },

                new PlayerStatisticsPerGame() { Id = 224, Goals = 1, PlayerStatisticsPerGame_GamesId = 83, PlayerStatisticsPerGame_PlayersId = 319 },
                new PlayerStatisticsPerGame() { Id = 225, Goals = 1, PlayerStatisticsPerGame_GamesId = 83, PlayerStatisticsPerGame_PlayersId = 320 },

                new PlayerStatisticsPerGame() { Id = 226, Goals = 1, PlayerStatisticsPerGame_GamesId = 84, PlayerStatisticsPerGame_PlayersId = 234 },

                new PlayerStatisticsPerGame() { Id = 227, Goals = 1, PlayerStatisticsPerGame_GamesId = 85, PlayerStatisticsPerGame_PlayersId = 251 },
                new PlayerStatisticsPerGame() { Id = 228, Goals = 1, PlayerStatisticsPerGame_GamesId = 85, PlayerStatisticsPerGame_PlayersId = 265 },
                new PlayerStatisticsPerGame() { Id = 229, Goals = 1, PlayerStatisticsPerGame_GamesId = 85, PlayerStatisticsPerGame_PlayersId = 277 },

                new PlayerStatisticsPerGame() { Id = 232, Goals = 1, PlayerStatisticsPerGame_GamesId = 86, PlayerStatisticsPerGame_PlayersId = 581 },
                new PlayerStatisticsPerGame() { Id = 233, Goals = 1, PlayerStatisticsPerGame_GamesId = 86, PlayerStatisticsPerGame_PlayersId = 595 },
                new PlayerStatisticsPerGame() { Id = 234, Goals = 1, PlayerStatisticsPerGame_GamesId = 86, PlayerStatisticsPerGame_PlayersId = 583 },

                new PlayerStatisticsPerGame() { Id = 236, Goals = 1, PlayerStatisticsPerGame_GamesId = 87, PlayerStatisticsPerGame_PlayersId = 566 },

                new PlayerStatisticsPerGame() { Id = 237, Goals = 1, PlayerStatisticsPerGame_GamesId = 88, PlayerStatisticsPerGame_PlayersId = 407 },

                new PlayerStatisticsPerGame() { Id = 238, Goals = 1, PlayerStatisticsPerGame_GamesId = 89, PlayerStatisticsPerGame_PlayersId = 425 },
                

                new PlayerStatisticsPerGame() { Id = 242, Goals = 1, PlayerStatisticsPerGame_GamesId = 90, PlayerStatisticsPerGame_PlayersId = 461 },
                new PlayerStatisticsPerGame() { Id = 243, Goals = 1, PlayerStatisticsPerGame_GamesId = 90, PlayerStatisticsPerGame_PlayersId = 471 },
                new PlayerStatisticsPerGame() { Id = 244, Goals = 1, PlayerStatisticsPerGame_GamesId = 90, PlayerStatisticsPerGame_PlayersId = 472 },

                // ETAPA 7 - PlayerStatisticsPerGame
                new PlayerStatisticsPerGame() { Id = 245, Goals = 1, PlayerStatisticsPerGame_GamesId = 91, PlayerStatisticsPerGame_PlayersId = 61 },
                new PlayerStatisticsPerGame() { Id = 246, Goals = 1, PlayerStatisticsPerGame_GamesId = 91, PlayerStatisticsPerGame_PlayersId = 193 },

                new PlayerStatisticsPerGame() { Id = 248, Goals = 1, PlayerStatisticsPerGame_GamesId = 92, PlayerStatisticsPerGame_PlayersId = 54 },

                new PlayerStatisticsPerGame() { Id = 249, Goals = 1, PlayerStatisticsPerGame_GamesId = 93, PlayerStatisticsPerGame_PlayersId = 101 },
                new PlayerStatisticsPerGame() { Id = 250, Goals = 1, PlayerStatisticsPerGame_GamesId = 93, PlayerStatisticsPerGame_PlayersId = 120 },
                new PlayerStatisticsPerGame() { Id = 251, Goals = 1, PlayerStatisticsPerGame_GamesId = 93, PlayerStatisticsPerGame_PlayersId = 37 },

                new PlayerStatisticsPerGame() { Id = 252, Goals = 1, PlayerStatisticsPerGame_GamesId = 94, PlayerStatisticsPerGame_PlayersId = 122 },
                new PlayerStatisticsPerGame() { Id = 253, Goals = 1, PlayerStatisticsPerGame_GamesId = 94, PlayerStatisticsPerGame_PlayersId = 129 },
                new PlayerStatisticsPerGame() { Id = 254, Goals = 1, PlayerStatisticsPerGame_GamesId = 94, PlayerStatisticsPerGame_PlayersId = 134 },

                new PlayerStatisticsPerGame() { Id = 255, Goals = 1, PlayerStatisticsPerGame_GamesId = 95, PlayerStatisticsPerGame_PlayersId = 141 },
                new PlayerStatisticsPerGame() { Id = 256, Goals = 1, PlayerStatisticsPerGame_GamesId = 95, PlayerStatisticsPerGame_PlayersId = 152 },
                new PlayerStatisticsPerGame() { Id = 257, Goals = 1, PlayerStatisticsPerGame_GamesId = 95, PlayerStatisticsPerGame_PlayersId = 171 },

                new PlayerStatisticsPerGame() { Id = 259, Goals = 1, PlayerStatisticsPerGame_GamesId = 96, PlayerStatisticsPerGame_PlayersId = 393 },

                new PlayerStatisticsPerGame() { Id = 260, Goals = 1, PlayerStatisticsPerGame_GamesId = 97, PlayerStatisticsPerGame_PlayersId = 291 },
                new PlayerStatisticsPerGame() { Id = 262, Goals = 1, PlayerStatisticsPerGame_GamesId = 97, PlayerStatisticsPerGame_PlayersId = 252 },

                new PlayerStatisticsPerGame() { Id = 263, Goals = 1, PlayerStatisticsPerGame_GamesId = 98, PlayerStatisticsPerGame_PlayersId = 316 },

                new PlayerStatisticsPerGame() { Id = 265, Goals = 1, PlayerStatisticsPerGame_GamesId = 99, PlayerStatisticsPerGame_PlayersId = 332 },
                new PlayerStatisticsPerGame() { Id = 266, Goals = 1, PlayerStatisticsPerGame_GamesId = 99, PlayerStatisticsPerGame_PlayersId = 219 },

                new PlayerStatisticsPerGame() { Id = 267, Goals = 1, PlayerStatisticsPerGame_GamesId = 101, PlayerStatisticsPerGame_PlayersId = 471 },
                new PlayerStatisticsPerGame() { Id = 269, Goals = 1, PlayerStatisticsPerGame_GamesId = 101, PlayerStatisticsPerGame_PlayersId = 600 },
                
                new PlayerStatisticsPerGame() { Id = 274, Goals = 1, PlayerStatisticsPerGame_GamesId = 102, PlayerStatisticsPerGame_PlayersId = 445 },

                new PlayerStatisticsPerGame() { Id = 277, Goals = 1, PlayerStatisticsPerGame_GamesId = 104, PlayerStatisticsPerGame_PlayersId = 420 },
                new PlayerStatisticsPerGame() { Id = 278, Goals = 1, PlayerStatisticsPerGame_GamesId = 104, PlayerStatisticsPerGame_PlayersId = 539 },

                new PlayerStatisticsPerGame() { Id = 280, Goals = 1, PlayerStatisticsPerGame_GamesId = 105, PlayerStatisticsPerGame_PlayersId = 561 },
                new PlayerStatisticsPerGame() { Id = 281, Goals = 1, PlayerStatisticsPerGame_GamesId = 105, PlayerStatisticsPerGame_PlayersId = 570 },
                new PlayerStatisticsPerGame() { Id = 282, Goals = 1, PlayerStatisticsPerGame_GamesId = 105, PlayerStatisticsPerGame_PlayersId = 573 },

                // ETAPA 8 - PlayerStatisticsPerGame
                new PlayerStatisticsPerGame() { Id = 283, Goals = 1, PlayerStatisticsPerGame_GamesId = 106, PlayerStatisticsPerGame_PlayersId = 191 },
                new PlayerStatisticsPerGame() { Id = 284, Goals = 1, PlayerStatisticsPerGame_GamesId = 106, PlayerStatisticsPerGame_PlayersId = 181 },
                new PlayerStatisticsPerGame() { Id = 285, Goals = 1, PlayerStatisticsPerGame_GamesId = 106, PlayerStatisticsPerGame_PlayersId = 177 },

                new PlayerStatisticsPerGame() { Id = 287, Goals = 1, PlayerStatisticsPerGame_GamesId = 108, PlayerStatisticsPerGame_PlayersId = 22 },
                new PlayerStatisticsPerGame() { Id = 288, Goals = 1, PlayerStatisticsPerGame_GamesId = 108, PlayerStatisticsPerGame_PlayersId = 39 },
                new PlayerStatisticsPerGame() { Id = 289, Goals = 1, PlayerStatisticsPerGame_GamesId = 108, PlayerStatisticsPerGame_PlayersId = 125 },

                new PlayerStatisticsPerGame() { Id = 290, Goals = 1, PlayerStatisticsPerGame_GamesId = 109, PlayerStatisticsPerGame_PlayersId = 112 },
                new PlayerStatisticsPerGame() { Id = 291, Goals = 1, PlayerStatisticsPerGame_GamesId = 109, PlayerStatisticsPerGame_PlayersId = 59 },

                new PlayerStatisticsPerGame() { Id = 292, Goals = 1, PlayerStatisticsPerGame_GamesId = 110, PlayerStatisticsPerGame_PlayersId = 77 },
                new PlayerStatisticsPerGame() { Id = 293, Goals = 1, PlayerStatisticsPerGame_GamesId = 110, PlayerStatisticsPerGame_PlayersId = 87 },

                new PlayerStatisticsPerGame() { Id = 294, Goals = 1, PlayerStatisticsPerGame_GamesId = 111, PlayerStatisticsPerGame_PlayersId = 399 },
                new PlayerStatisticsPerGame() { Id = 295, Goals = 1, PlayerStatisticsPerGame_GamesId = 111, PlayerStatisticsPerGame_PlayersId = 381 },

                new PlayerStatisticsPerGame() { Id = 296, Goals = 1, PlayerStatisticsPerGame_GamesId = 112, PlayerStatisticsPerGame_PlayersId = 212 },
                new PlayerStatisticsPerGame() { Id = 297, Goals = 1, PlayerStatisticsPerGame_GamesId = 112, PlayerStatisticsPerGame_PlayersId = 217 },

                new PlayerStatisticsPerGame() { Id = 299, Goals = 1, PlayerStatisticsPerGame_GamesId = 113, PlayerStatisticsPerGame_PlayersId = 237 },
                new PlayerStatisticsPerGame() { Id = 301, Goals = 1, PlayerStatisticsPerGame_GamesId = 113, PlayerStatisticsPerGame_PlayersId = 332 },
                new PlayerStatisticsPerGame() { Id = 302, Goals = 1, PlayerStatisticsPerGame_GamesId = 113, PlayerStatisticsPerGame_PlayersId = 333 },

                new PlayerStatisticsPerGame() { Id = 304, Goals = 1, PlayerStatisticsPerGame_GamesId = 114, PlayerStatisticsPerGame_PlayersId = 253 },

                new PlayerStatisticsPerGame() { Id = 305, Goals = 1, PlayerStatisticsPerGame_GamesId = 115, PlayerStatisticsPerGame_PlayersId = 289 },
                new PlayerStatisticsPerGame() { Id = 306, Goals = 1, PlayerStatisticsPerGame_GamesId = 115, PlayerStatisticsPerGame_PlayersId = 298 },

                new PlayerStatisticsPerGame() { Id = 307, Goals = 1, PlayerStatisticsPerGame_GamesId = 116, PlayerStatisticsPerGame_PlayersId = 593 },
                new PlayerStatisticsPerGame() { Id = 308, Goals = 1, PlayerStatisticsPerGame_GamesId = 116, PlayerStatisticsPerGame_PlayersId = 594 },
                new PlayerStatisticsPerGame() { Id = 309, Goals = 1, PlayerStatisticsPerGame_GamesId = 116, PlayerStatisticsPerGame_PlayersId = 581 },
                new PlayerStatisticsPerGame() { Id = 310, Goals = 1, PlayerStatisticsPerGame_GamesId = 116, PlayerStatisticsPerGame_PlayersId = 577 },

                new PlayerStatisticsPerGame() { Id = 311, Goals = 1, PlayerStatisticsPerGame_GamesId = 117, PlayerStatisticsPerGame_PlayersId = 405 },
                
                new PlayerStatisticsPerGame() { Id = 319, Goals = 1, PlayerStatisticsPerGame_GamesId = 119, PlayerStatisticsPerGame_PlayersId = 514 },

                new PlayerStatisticsPerGame() { Id = 320, Goals = 1, PlayerStatisticsPerGame_GamesId = 120, PlayerStatisticsPerGame_PlayersId = 488 },

                // ETAPA 9 - PlayerStatisticsPerGame
                new PlayerStatisticsPerGame() { Id = 321, Goals = 1, PlayerStatisticsPerGame_GamesId = 121, PlayerStatisticsPerGame_PlayersId = 81 },
                new PlayerStatisticsPerGame() { Id = 322, Goals = 1, PlayerStatisticsPerGame_GamesId = 121, PlayerStatisticsPerGame_PlayersId = 86 },
                

                new PlayerStatisticsPerGame() { Id = 331, Goals = 1, PlayerStatisticsPerGame_GamesId = 125, PlayerStatisticsPerGame_PlayersId = 178 },
                new PlayerStatisticsPerGame() { Id = 332, Goals = 1, PlayerStatisticsPerGame_GamesId = 125, PlayerStatisticsPerGame_PlayersId = 11 },
                new PlayerStatisticsPerGame() { Id = 333, Goals = 1, PlayerStatisticsPerGame_GamesId = 125, PlayerStatisticsPerGame_PlayersId = 6 },

                new PlayerStatisticsPerGame() { Id = 335, Goals = 1, PlayerStatisticsPerGame_GamesId = 127, PlayerStatisticsPerGame_PlayersId = 313 },
                
                new PlayerStatisticsPerGame() { Id = 342, Goals = 1, PlayerStatisticsPerGame_GamesId = 131, PlayerStatisticsPerGame_PlayersId = 593 },

                new PlayerStatisticsPerGame() { Id = 344, Goals = 1, PlayerStatisticsPerGame_GamesId = 132, PlayerStatisticsPerGame_PlayersId = 515 },
                
                new PlayerStatisticsPerGame() { Id = 352, Goals = 1, PlayerStatisticsPerGame_GamesId = 135, PlayerStatisticsPerGame_PlayersId = 407 },

                // ETAPA 10 - PlayerStatisticsPerGame
                new PlayerStatisticsPerGame() { Id = 353, Goals = 1, PlayerStatisticsPerGame_GamesId = 136, PlayerStatisticsPerGame_PlayersId = 185 },
                new PlayerStatisticsPerGame() { Id = 354, Goals = 1, PlayerStatisticsPerGame_GamesId = 136, PlayerStatisticsPerGame_PlayersId = 191 },

                new PlayerStatisticsPerGame() { Id = 356, Goals = 1, PlayerStatisticsPerGame_GamesId = 138, PlayerStatisticsPerGame_PlayersId = 153 },
                
                new PlayerStatisticsPerGame() { Id = 360, Goals = 1, PlayerStatisticsPerGame_GamesId = 139, PlayerStatisticsPerGame_PlayersId = 123 },

                
                new PlayerStatisticsPerGame() { Id = 368, Goals = 1, PlayerStatisticsPerGame_GamesId = 143, PlayerStatisticsPerGame_PlayersId = 250 },
                
                new PlayerStatisticsPerGame() { Id = 372, Goals = 1, PlayerStatisticsPerGame_GamesId = 145, PlayerStatisticsPerGame_PlayersId = 315 },
                new PlayerStatisticsPerGame() { Id = 373, Goals = 1, PlayerStatisticsPerGame_GamesId = 145, PlayerStatisticsPerGame_PlayersId = 311 },

               
                new PlayerStatisticsPerGame() { Id = 382, Goals = 1, PlayerStatisticsPerGame_GamesId = 149, PlayerStatisticsPerGame_PlayersId = 480 },
                new PlayerStatisticsPerGame() { Id = 383, Goals = 1, PlayerStatisticsPerGame_GamesId = 149, PlayerStatisticsPerGame_PlayersId = 471 },

                new PlayerStatisticsPerGame() { Id = 384, Goals = 1, PlayerStatisticsPerGame_GamesId = 150, PlayerStatisticsPerGame_PlayersId = 504 },
                new PlayerStatisticsPerGame() { Id = 385, Goals = 1, PlayerStatisticsPerGame_GamesId = 150, PlayerStatisticsPerGame_PlayersId = 502 },
                new PlayerStatisticsPerGame() { Id = 386, Goals = 1, PlayerStatisticsPerGame_GamesId = 150, PlayerStatisticsPerGame_PlayersId = 496 },
                 //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Cupa, PlayerStatisticsPerGame (începe cu Id = 133)
                new PlayerStatisticsPerGame() { Id = 387, Goals = 1, PlayerStatisticsPerGame_GamesId = 271, PlayerStatisticsPerGame_PlayersId = 12 },

                new PlayerStatisticsPerGame() { Id = 388, Goals = 1, PlayerStatisticsPerGame_GamesId = 272, PlayerStatisticsPerGame_PlayersId = 167 },
               
                new PlayerStatisticsPerGame() { Id = 391, Goals = 1, PlayerStatisticsPerGame_GamesId = 274, PlayerStatisticsPerGame_PlayersId = 632 },

                new PlayerStatisticsPerGame() { Id = 392, Goals = 1, PlayerStatisticsPerGame_GamesId = 275, PlayerStatisticsPerGame_PlayersId = 88 },
                new PlayerStatisticsPerGame() { Id = 393, Goals = 1, PlayerStatisticsPerGame_GamesId = 275, PlayerStatisticsPerGame_PlayersId = 91 },
                new PlayerStatisticsPerGame() { Id = 394, Goals = 1, PlayerStatisticsPerGame_GamesId = 275, PlayerStatisticsPerGame_PlayersId = 653 },

                // Games 276, 277 - 0-0, nu se inserează.

                new PlayerStatisticsPerGame() { Id = 395, Goals = 1, PlayerStatisticsPerGame_GamesId = 278, PlayerStatisticsPerGame_PlayersId = 157 },

                new PlayerStatisticsPerGame() { Id = 397, Goals = 1, PlayerStatisticsPerGame_GamesId = 279, PlayerStatisticsPerGame_PlayersId = 18 },

                new PlayerStatisticsPerGame() { Id = 398, Goals = 1, PlayerStatisticsPerGame_GamesId = 280, PlayerStatisticsPerGame_PlayersId = 22 },
                new PlayerStatisticsPerGame() { Id = 399, Goals = 1, PlayerStatisticsPerGame_GamesId = 280, PlayerStatisticsPerGame_PlayersId = 25 },
                new PlayerStatisticsPerGame() { Id = 400, Goals = 1, PlayerStatisticsPerGame_GamesId = 280, PlayerStatisticsPerGame_PlayersId = 33 },

                new PlayerStatisticsPerGame() { Id = 401, Goals = 1, PlayerStatisticsPerGame_GamesId = 281, PlayerStatisticsPerGame_PlayersId = 611 },
                new PlayerStatisticsPerGame() { Id = 402, Goals = 1, PlayerStatisticsPerGame_GamesId = 281, PlayerStatisticsPerGame_PlayersId = 49 },

                // Game 282 - 0-0, nu se inserează.

                new PlayerStatisticsPerGame() { Id = 403, Goals = 1, PlayerStatisticsPerGame_GamesId = 283, PlayerStatisticsPerGame_PlayersId = 653 },

                new PlayerStatisticsPerGame() { Id = 405, Goals = 1, PlayerStatisticsPerGame_GamesId = 284, PlayerStatisticsPerGame_PlayersId = 661 },

            

                new PlayerStatisticsPerGame() { Id = 409, Goals = 1, PlayerStatisticsPerGame_GamesId = 286, PlayerStatisticsPerGame_PlayersId = 712 },
                new PlayerStatisticsPerGame() { Id = 410, Goals = 1, PlayerStatisticsPerGame_GamesId = 286, PlayerStatisticsPerGame_PlayersId = 719 },
                new PlayerStatisticsPerGame() { Id = 411, Goals = 1, PlayerStatisticsPerGame_GamesId = 286, PlayerStatisticsPerGame_PlayersId = 708 },

                new PlayerStatisticsPerGame() { Id = 413, Goals = 1, PlayerStatisticsPerGame_GamesId = 287, PlayerStatisticsPerGame_PlayersId = 8 },
                new PlayerStatisticsPerGame() { Id = 414, Goals = 1, PlayerStatisticsPerGame_GamesId = 287, PlayerStatisticsPerGame_PlayersId = 13 },
                new PlayerStatisticsPerGame() { Id = 415, Goals = 1, PlayerStatisticsPerGame_GamesId = 287, PlayerStatisticsPerGame_PlayersId = 19 },
                new PlayerStatisticsPerGame() { Id = 416, Goals = 1, PlayerStatisticsPerGame_GamesId = 287, PlayerStatisticsPerGame_PlayersId = 15 },

                // Game 288 - 0-0, nu se inserează.

                new PlayerStatisticsPerGame() { Id = 417, Goals = 1, PlayerStatisticsPerGame_GamesId = 289, PlayerStatisticsPerGame_PlayersId = 661 },

                new PlayerStatisticsPerGame() { Id = 418, Goals = 1, PlayerStatisticsPerGame_GamesId = 290, PlayerStatisticsPerGame_PlayersId = 137 },
                new PlayerStatisticsPerGame() { Id = 419, Goals = 1, PlayerStatisticsPerGame_GamesId = 290, PlayerStatisticsPerGame_PlayersId = 140 },
                new PlayerStatisticsPerGame() { Id = 421, Goals = 1, PlayerStatisticsPerGame_GamesId = 290, PlayerStatisticsPerGame_PlayersId = 717 },
                new PlayerStatisticsPerGame() { Id = 422, Goals = 1, PlayerStatisticsPerGame_GamesId = 290, PlayerStatisticsPerGame_PlayersId = 713 },
                new PlayerStatisticsPerGame() { Id = 423, Goals = 1, PlayerStatisticsPerGame_GamesId = 290, PlayerStatisticsPerGame_PlayersId = 706 },

                // Game 291 - 0-0, nu se inserează.


                new PlayerStatisticsPerGame() { Id = 425, Goals = 1, PlayerStatisticsPerGame_GamesId = 293, PlayerStatisticsPerGame_PlayersId = 653 },
                new PlayerStatisticsPerGame() { Id = 426, Goals = 1, PlayerStatisticsPerGame_GamesId = 293, PlayerStatisticsPerGame_PlayersId = 661 },

                new PlayerStatisticsPerGame() { Id = 427, Goals = 1, PlayerStatisticsPerGame_GamesId = 294, PlayerStatisticsPerGame_PlayersId = 137 },

                new PlayerStatisticsPerGame() { Id = 428, Goals = 1, PlayerStatisticsPerGame_GamesId = 295, PlayerStatisticsPerGame_PlayersId = 14 },
                new PlayerStatisticsPerGame() { Id = 429, Goals = 1, PlayerStatisticsPerGame_GamesId = 295, PlayerStatisticsPerGame_PlayersId = 16 },
                new PlayerStatisticsPerGame() { Id = 430, Goals = 1, PlayerStatisticsPerGame_GamesId = 295, PlayerStatisticsPerGame_PlayersId = 4 },

                // Game 296 - 0-0, nu se inserează.

                
                new PlayerStatisticsPerGame() { Id = 433, Goals = 1, PlayerStatisticsPerGame_GamesId = 297, PlayerStatisticsPerGame_PlayersId = 17 },
                new PlayerStatisticsPerGame() { Id = 434, Goals = 1, PlayerStatisticsPerGame_GamesId = 297, PlayerStatisticsPerGame_PlayersId = 6 },
                new PlayerStatisticsPerGame() { Id = 435, Goals = 1, PlayerStatisticsPerGame_GamesId = 297, PlayerStatisticsPerGame_PlayersId = 2 },

                new PlayerStatisticsPerGame() { Id = 436, Goals = 1, PlayerStatisticsPerGame_GamesId = 298, PlayerStatisticsPerGame_PlayersId = 651 },

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                new PlayerStatisticsPerGame() { Id = 437, Goals = 1, PlayerStatisticsPerGame_GamesId = 301, PlayerStatisticsPerGame_PlayersId = 6 },
                new PlayerStatisticsPerGame() { Id = 438, Goals = 1, PlayerStatisticsPerGame_GamesId = 301, PlayerStatisticsPerGame_PlayersId = 12 },
                new PlayerStatisticsPerGame() { Id = 439, Goals = 1, PlayerStatisticsPerGame_GamesId = 301, PlayerStatisticsPerGame_PlayersId = 801 },
                new PlayerStatisticsPerGame() { Id = 440, Goals = 1, PlayerStatisticsPerGame_GamesId = 301, PlayerStatisticsPerGame_PlayersId = 807 },

                new PlayerStatisticsPerGame() { Id = 441, Goals = 1, PlayerStatisticsPerGame_GamesId = 302, PlayerStatisticsPerGame_PlayersId = 821 },

                new PlayerStatisticsPerGame() { Id = 442, Goals = 1, PlayerStatisticsPerGame_GamesId = 303, PlayerStatisticsPerGame_PlayersId = 851 },
                new PlayerStatisticsPerGame() { Id = 443, Goals = 1, PlayerStatisticsPerGame_GamesId = 303, PlayerStatisticsPerGame_PlayersId = 857 },
                new PlayerStatisticsPerGame() { Id = 444, Goals = 1, PlayerStatisticsPerGame_GamesId = 303, PlayerStatisticsPerGame_PlayersId = 852 },
                new PlayerStatisticsPerGame() { Id = 445, Goals = 1, PlayerStatisticsPerGame_GamesId = 303, PlayerStatisticsPerGame_PlayersId = 954 },
                new PlayerStatisticsPerGame() { Id = 446, Goals = 1, PlayerStatisticsPerGame_GamesId = 303, PlayerStatisticsPerGame_PlayersId = 945 },
                //
                new PlayerStatisticsPerGame() { Id = 447, Goals = 1, PlayerStatisticsPerGame_GamesId = 304, PlayerStatisticsPerGame_PlayersId = 938 },
                new PlayerStatisticsPerGame() { Id = 448, Goals = 1, PlayerStatisticsPerGame_GamesId = 304, PlayerStatisticsPerGame_PlayersId = 937 },

                new PlayerStatisticsPerGame() { Id = 449, Goals = 1, PlayerStatisticsPerGame_GamesId = 305, PlayerStatisticsPerGame_PlayersId = 899 },
                new PlayerStatisticsPerGame() { Id = 450, Goals = 1, PlayerStatisticsPerGame_GamesId = 305, PlayerStatisticsPerGame_PlayersId = 902 },

                new PlayerStatisticsPerGame() { Id = 451, Goals = 1, PlayerStatisticsPerGame_GamesId = 306, PlayerStatisticsPerGame_PlayersId = 961 },
                new PlayerStatisticsPerGame() { Id = 452, Goals = 1, PlayerStatisticsPerGame_GamesId = 306, PlayerStatisticsPerGame_PlayersId = 964 },
                new PlayerStatisticsPerGame() { Id = 453, Goals = 1, PlayerStatisticsPerGame_GamesId = 306, PlayerStatisticsPerGame_PlayersId = 969 },

                new PlayerStatisticsPerGame() { Id = 454, Goals = 1, PlayerStatisticsPerGame_GamesId = 307, PlayerStatisticsPerGame_PlayersId = 831 },

                new PlayerStatisticsPerGame() { Id = 455, Goals = 1, PlayerStatisticsPerGame_GamesId = 308, PlayerStatisticsPerGame_PlayersId = 901 },
                new PlayerStatisticsPerGame() { Id = 456, Goals = 1, PlayerStatisticsPerGame_GamesId = 308, PlayerStatisticsPerGame_PlayersId = 911 },
                new PlayerStatisticsPerGame() { Id = 457, Goals = 1, PlayerStatisticsPerGame_GamesId = 308, PlayerStatisticsPerGame_PlayersId = 868 },
                new PlayerStatisticsPerGame() { Id = 458, Goals = 1, PlayerStatisticsPerGame_GamesId = 308, PlayerStatisticsPerGame_PlayersId = 869 },
                new PlayerStatisticsPerGame() { Id = 459, Goals = 1, PlayerStatisticsPerGame_GamesId = 308, PlayerStatisticsPerGame_PlayersId = 865 },

                new PlayerStatisticsPerGame() { Id = 460, Goals = 1, PlayerStatisticsPerGame_GamesId = 309, PlayerStatisticsPerGame_PlayersId = 934 },
                new PlayerStatisticsPerGame() { Id = 461, Goals = 1, PlayerStatisticsPerGame_GamesId = 309, PlayerStatisticsPerGame_PlayersId = 854 },

                new PlayerStatisticsPerGame() { Id = 462, Goals = 1, PlayerStatisticsPerGame_GamesId = 310, PlayerStatisticsPerGame_PlayersId = 958 },

                new PlayerStatisticsPerGame() { Id = 463, Goals = 1, PlayerStatisticsPerGame_GamesId = 311, PlayerStatisticsPerGame_PlayersId = 17 },
                new PlayerStatisticsPerGame() { Id = 464, Goals = 1, PlayerStatisticsPerGame_GamesId = 311, PlayerStatisticsPerGame_PlayersId = 7 },
                new PlayerStatisticsPerGame() { Id = 465, Goals = 1, PlayerStatisticsPerGame_GamesId = 311, PlayerStatisticsPerGame_PlayersId = 821 },

                new PlayerStatisticsPerGame() { Id = 466, Goals = 1, PlayerStatisticsPerGame_GamesId = 312, PlayerStatisticsPerGame_PlayersId = 851 },
                new PlayerStatisticsPerGame() { Id = 467, Goals = 1, PlayerStatisticsPerGame_GamesId = 312, PlayerStatisticsPerGame_PlayersId = 813 },
                new PlayerStatisticsPerGame() { Id = 468, Goals = 1, PlayerStatisticsPerGame_GamesId = 312, PlayerStatisticsPerGame_PlayersId = 801 },
                new PlayerStatisticsPerGame() { Id = 469, Goals = 1, PlayerStatisticsPerGame_GamesId = 312, PlayerStatisticsPerGame_PlayersId = 802 },

                new PlayerStatisticsPerGame() { Id = 470, Goals = 1, PlayerStatisticsPerGame_GamesId = 313, PlayerStatisticsPerGame_PlayersId = 871 },
                new PlayerStatisticsPerGame() { Id = 471, Goals = 1, PlayerStatisticsPerGame_GamesId = 313, PlayerStatisticsPerGame_PlayersId = 873 },

                new PlayerStatisticsPerGame() { Id = 472, Goals = 1, PlayerStatisticsPerGame_GamesId = 314, PlayerStatisticsPerGame_PlayersId = 958 },

                new PlayerStatisticsPerGame() { Id = 473, Goals = 1, PlayerStatisticsPerGame_GamesId = 315, PlayerStatisticsPerGame_PlayersId = 919 },
                new PlayerStatisticsPerGame() { Id = 474, Goals = 1, PlayerStatisticsPerGame_GamesId = 315, PlayerStatisticsPerGame_PlayersId = 939 },

                new PlayerStatisticsPerGame() { Id = 475, Goals = 1, PlayerStatisticsPerGame_GamesId = 316, PlayerStatisticsPerGame_PlayersId = 813 },
                new PlayerStatisticsPerGame() { Id = 476, Goals = 1, PlayerStatisticsPerGame_GamesId = 316, PlayerStatisticsPerGame_PlayersId = 816 },
                new PlayerStatisticsPerGame() { Id = 477, Goals = 1, PlayerStatisticsPerGame_GamesId = 316, PlayerStatisticsPerGame_PlayersId = 819 },
                new PlayerStatisticsPerGame() { Id = 478, Goals = 1, PlayerStatisticsPerGame_GamesId = 316, PlayerStatisticsPerGame_PlayersId = 868 },

                new PlayerStatisticsPerGame() { Id = 479, Goals = 1, PlayerStatisticsPerGame_GamesId = 317, PlayerStatisticsPerGame_PlayersId = 831 },
                new PlayerStatisticsPerGame() { Id = 480, Goals = 1, PlayerStatisticsPerGame_GamesId = 317, PlayerStatisticsPerGame_PlayersId = 833 },

                new PlayerStatisticsPerGame() { Id = 481, Goals = 1, PlayerStatisticsPerGame_GamesId = 318, PlayerStatisticsPerGame_PlayersId = 964 },
                new PlayerStatisticsPerGame() { Id = 482, Goals = 1, PlayerStatisticsPerGame_GamesId = 318, PlayerStatisticsPerGame_PlayersId = 899 },

                new PlayerStatisticsPerGame() { Id = 483, Goals = 1, PlayerStatisticsPerGame_GamesId = 319, PlayerStatisticsPerGame_PlayersId = 933 },
                new PlayerStatisticsPerGame() { Id = 484, Goals = 1, PlayerStatisticsPerGame_GamesId = 319, PlayerStatisticsPerGame_PlayersId = 13 },

                new PlayerStatisticsPerGame() { Id = 485, Goals = 1, PlayerStatisticsPerGame_GamesId = 320, PlayerStatisticsPerGame_PlayersId = 951 },
                new PlayerStatisticsPerGame() { Id = 486, Goals = 1, PlayerStatisticsPerGame_GamesId = 320, PlayerStatisticsPerGame_PlayersId = 948 },
                new PlayerStatisticsPerGame() { Id = 487, Goals = 1, PlayerStatisticsPerGame_GamesId = 320, PlayerStatisticsPerGame_PlayersId = 949 },

                new PlayerStatisticsPerGame() { Id = 488, Goals = 1, PlayerStatisticsPerGame_GamesId = 321, PlayerStatisticsPerGame_PlayersId = 9 },
                new PlayerStatisticsPerGame() { Id = 489, Goals = 1, PlayerStatisticsPerGame_GamesId = 321, PlayerStatisticsPerGame_PlayersId = 856 },

                new PlayerStatisticsPerGame() { Id = 490, Goals = 1, PlayerStatisticsPerGame_GamesId = 322, PlayerStatisticsPerGame_PlayersId = 871 },
                new PlayerStatisticsPerGame() { Id = 491, Goals = 1, PlayerStatisticsPerGame_GamesId = 322, PlayerStatisticsPerGame_PlayersId = 869 },
                new PlayerStatisticsPerGame() { Id = 492, Goals = 1, PlayerStatisticsPerGame_GamesId = 322, PlayerStatisticsPerGame_PlayersId = 823 },
                new PlayerStatisticsPerGame() { Id = 493, Goals = 1, PlayerStatisticsPerGame_GamesId = 322, PlayerStatisticsPerGame_PlayersId = 824 },

                new PlayerStatisticsPerGame() { Id = 494, Goals = 1, PlayerStatisticsPerGame_GamesId = 323, PlayerStatisticsPerGame_PlayersId = 804 },
                new PlayerStatisticsPerGame() { Id = 495, Goals = 1, PlayerStatisticsPerGame_GamesId = 323, PlayerStatisticsPerGame_PlayersId = 813 },
                new PlayerStatisticsPerGame() { Id = 496, Goals = 1, PlayerStatisticsPerGame_GamesId = 323, PlayerStatisticsPerGame_PlayersId = 816 },

                new PlayerStatisticsPerGame() { Id = 497, Goals = 1, PlayerStatisticsPerGame_GamesId = 324, PlayerStatisticsPerGame_PlayersId = 912 },
                new PlayerStatisticsPerGame() { Id = 498, Goals = 1, PlayerStatisticsPerGame_GamesId = 324, PlayerStatisticsPerGame_PlayersId = 908 },

                new PlayerStatisticsPerGame() { Id = 499, Goals = 1, PlayerStatisticsPerGame_GamesId = 325, PlayerStatisticsPerGame_PlayersId = 951 },
                new PlayerStatisticsPerGame() { Id = 500, Goals = 1, PlayerStatisticsPerGame_GamesId = 325, PlayerStatisticsPerGame_PlayersId = 942 },
                new PlayerStatisticsPerGame() { Id = 501, Goals = 1, PlayerStatisticsPerGame_GamesId = 325, PlayerStatisticsPerGame_PlayersId = 931 },
                new PlayerStatisticsPerGame() { Id = 502, Goals = 1, PlayerStatisticsPerGame_GamesId = 325, PlayerStatisticsPerGame_PlayersId = 921 }

            });

            modelBuilder.Entity<News>().HasData(new List<News>()
            {
                new News()
                {
                    Id = 1,
                    Title = "FC Unirea va participa în trei competiții sezonul acesta!",
                    Text = "FC Unirea este încântată să anunțe participarea în trei competiții importante în sezonul acesta: Liga 1, Cupa României și Champions League.\n\n" +
                           "Participarea în **Liga 1** aduce un nou prilej pentru echipa noastră de a lupta pentru titlul național, alături de cele mai bune echipe din țară.\n\n" +
                           "În **Cupa României**, obiectivul nostru este să mergem cât mai departe în competiție și să aducem suporterilor momente de neuitat.\n\n" +
                           "Nu în ultimul rând, prezența în **Champions League** reprezintă un vis devenit realitate! Este o șansă uriașă pentru echipă de a se confrunta cu formații de top din Europa, de a acumula experiență și de a duce numele FC Unirea pe cele mai mari stadioane.\n\n" +
                           "Vă invităm să fiți alături de noi în acest sezon de excepție! Hai, Unirea!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1 // Admin
                },
                new News()
                {
                    Id = 2,
                    Title = "FC Unirea U21 va participa doar în Liga 1 U21 sezonul acesta!",
                    Text = "Echipa FC Unirea U21 va concura exclusiv în Liga 1 U21 în acest sezon, o competiție dedicată tinerilor talentați care fac parte din generația viitorului.\n\n" +
                           "Liga 1 U21 reprezintă o oportunitate excelentă pentru jucătorii noștri să-și demonstreze abilitățile și să facă pasul spre echipa mare. Antrenorii și staff-ul tehnic sunt încrezători că tinerii vor aduce rezultate bune și vor evolua de la meci la meci.\n\n" +
                           "Obiectivul principal este dezvoltarea jucătorilor, promovarea valorilor clubului și pregătirea lor pentru a face față provocărilor fotbalului de performanță.\n\n" +
                           "Susțineți FC Unirea U21 în această nouă aventură fotbalistică! Hai, Unirea!",

                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },
                new News()
                {
                    Id = 3,
                    Title = "FC Unirea Youth va participa în Liga 1 de tineret!",
                    Text = "Avem bucuria să anunțăm că echipa FC Unirea Youth va evolua în acest sezon în **Liga 1 de tineret**!\n\n" +
                           "Această competiție este dedicată tinerilor fotbaliști cu potențial, care se pregătesc pentru pasul următor în cariera lor sportivă. Obiectivul clubului este să descopere noi talente și să le ofere oportunitatea de a juca la nivel înalt încă de la o vârstă fragedă.\n\n" +
                           "Prin participarea în Liga 1 de tineret, FC Unirea Youth urmărește nu doar rezultate, ci și dezvoltarea continuă a jucătorilor, spiritul de echipă și promovarea fair-play-ului.\n\n" +
                           "Le dorim mult succes tinerilor noștri și suntem convinși că vor reprezenta cu mândrie culorile clubului! Susțineți FC Unirea Youth la fiecare meci!",

                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },
                new News()
                {
                    Id = 4,
                    Title = "Despre FC Unirea – Istorie, valori și performanță",
                    Text = "FC Unirea a fost fondată în anul 2005, având ca scop promovarea valorilor sportive și dezvoltarea fotbalului la nivel local. " +
                           "De-a lungul anilor, clubul a reușit să atragă numeroși tineri talentați din regiune, devenind rapid un punct de referință pentru fotbalul comunitar.\n\n" +
                           "Echipa a debutat în ligile inferioare, dar datorită muncii susținute și implicării staff-ului, FC Unirea a obținut promovări succesive, ajungând să participe în competiții naționale și ulterior europene. " +
                           "Performanțele notabile includ câștigarea campionatului regional în 2012 și participarea constantă în primele eșaloane ale fotbalului românesc începând cu sezonul 2015-2016.\n\n" +
                           "În prezent, echipa este pregătită de antrenorul Petrica Florea, sub îndrumarea căruia FC Unirea continuă să-și consolideze poziția în fotbalul românesc și să inspire o nouă generație de sportivi. " +
                           "Hai, Unirea!",

                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },
                new News()
                {
                    Id = 5,
                    Title = "FC Unirea U21 – Rampă de lansare pentru tinerii fotbaliști",
                    Text = "FC Unirea U21 a fost înființată ca parte a strategiei de dezvoltare a clubului FC Unirea, având ca principal obiectiv creșterea și promovarea tinerilor jucători către echipa de seniori. " +
                           "Echipa a luat naștere în anul 2013, din dorința de a oferi o rampă de lansare pentru fotbaliștii talentați cu vârste sub 21 de ani.\n\n" +
                           "Încă de la început, FC Unirea U21 a participat în competițiile naționale de juniori și tineret, obținând rezultate remarcabile și construind o reputație solidă pentru profesionalism și implicare. " +
                           "Mulți dintre jucătorii promovați din cadrul acestei echipe au ajuns ulterior să evolueze cu succes la nivel de seniori, contribuind la performanțele clubului-mamă.\n\n" +
                           "Prin accentul pus pe formare, disciplină și joc de echipă, FC Unirea U21 a devenit un pilon esențial în structura clubului, reprezentând legătura directă dintre academia de juniori și prima echipă. " +
                           "Clubul investește constant în infrastructură, staff și programe de pregătire pentru a asigura continuitatea valorilor și performanțelor fotbalistice.\n\n" +
                           "În prezent, echipa este pregătită de antrenorul Mihai Olaru, sub îndrumarea căruia tinerii își pot atinge potențialul și pot face pasul spre echipa de seniori. " +
                           "Hai, Unirea U21!",

                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },
                new News()
                {
                    Id = 6,
                    Title = "FC Unirea Youth – Academia care formează viitorul clubului",
                    Text = "FC Unirea Youth reprezintă segmentul de juniori al clubului FC Unirea, fiind dedicat dezvoltării copiilor și adolescenților pasionați de fotbal. " +
                           "Echipa a fost creată în anul 2010 ca răspuns la dorința clubului de a construi o academie puternică și de a forma jucători încă de la cele mai fragede vârste.\n\n" +
                           "Scopul principal al FC Unirea Youth este identificarea și formarea tinerelor talente, oferindu-le acestora condiții moderne de pregătire, antrenori calificați și participarea la competiții locale și regionale. " +
                           "De-a lungul anilor, această structură a devenit un adevărat incubator de jucători pentru club, numeroși fotbaliști ajungând ulterior să evolueze pentru FC Unirea U21 sau chiar la nivel de seniori.\n\n" +
                           "Prin activitatea sa, FC Unirea Youth promovează nu doar performanța sportivă, ci și valorile educației, fair-play-ului și respectului față de adversar. " +
                           "Clubul continuă să investească în infrastructură și în programe de formare, consolidându-și statutul de centru de excelență pentru tinerii fotbaliști din regiune.\n\n" +
                           "În prezent, echipa este antrenată de Nica Cercel, un tehnician recunoscut pentru devotamentul său față de copii și pentru rezultatele obținute la nivel juvenil. " +
                           "Hai, Unirea Youth!",

                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },
                new News()
                {
                    Id = 7,
                    Title = "Lotul echipei FC Unirea pentru sezonul actual",
                    Text = "Echipa FC Unirea pornește la drum în noul sezon cu un lot valoros, format din jucători experimentați și tineri de perspectivă. Iată componența lotului:\n\n" +
                           "**Portari:**  \n" +
                           "- Daniel Rădulescu (1992)  \n" +
                           "- Denis Chiriac (1997)  \n" +
                           "- Alin Neagu (2006)  \n" +
                           "- Ionuț Rădulescu (2004)  \n\n" +
                           "**Fundași:**  \n" +
                           "- Ștefan Popescu (1996)  \n" +
                           "- Radu Ilie (1999)  \n" +
                           "- Alex Lazăr (1995)  \n" +
                           "- Andrei Enache (1998)  \n" +
                           "- Andrei Neagu (2004)  \n" +
                           "- Robert Vasilescu (1996)  \n" +
                           "- Vlad Enache (1990)  \n\n" +
                           "**Mijlocași:**  \n" +
                           "- Mihai Toma (2000)  \n" +
                           "- Daniel Matei (1994)  \n" +
                           "- Sergiu Chiriac (1990)  \n" +
                           "- Denis Neagu (1999)  \n" +
                           "- George Ilie (2004)  \n" +
                           "- Gabriel Vasilescu (2005)  \n\n" +
                           "**Atacanți:**  \n" +
                           "- Daniel Stan (2003)  \n" +
                           "- Alex Vasilescu (1994)  \n" +
                           "- Denis Ilie (1991)  \n\n" +
                           "Echipa este pregătită să facă performanță și să aducă noi bucurii suporterilor!\n\n" +
                           "Hai, Unirea!",

                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },
                new News()
                {
                    Id = 8,
                    Title = "Lotul echipei FC Unirea U21 pentru sezonul actual",
                    Text = "FC Unirea U21 abordează noul sezon cu o echipă tânără, plină de entuziasm și determinare. Lotul reunește atât jucători cu experiență la nivel de juniori, cât și talente aflate la început de drum, dornice să confirme la cel mai înalt nivel al fotbalului de tineret. Iată componența lotului:\n\n" +
                           "**Portari:**  \n" +
                           "- Denis Lazar (2004)  \n" +
                           "- Eduard Georgescu (2006)  \n" +
                           "- Alin Dumitrescu (2008)  \n" +
                           "- Eduard Diaconu (2005)  \n" +
                           "- Robert Dumitrescu (2007)  \n\n" +
                           "**Fundași:**  \n" +
                           "- George Diaconu (2006)  \n" +
                           "- Adrian Toma (2007)  \n" +
                           "- Alin Diaconu (2004)  \n" +
                           "- Alin Voicu (2005)  \n" +
                           "- Sergiu Radulescu (2005)  \n\n" +
                           "**Mijlocași:**  \n" +
                           "- Daniel Ilie (2008)  \n" +
                           "- Alex Matei (2005)  \n" +
                           "- Robert Cojocaru (2008)  \n" +
                           "- Denis Cojocaru (2007)  \n\n" +
                           "**Atacanți:**  \n" +
                           "- Cristian Ilie (2005)  \n" +
                           "- Robert Ionescu (2004)  \n" +
                           "- Robert Radulescu (2007)  \n" +
                           "- Florin Matei (2005)  \n" +
                           "- Sergiu Neagu (2004)  \n" +
                           "- Eduard Popescu (2004)  \n\n" +
                           "Prin această selecție, FC Unirea U21 își propune să crească jucători valoroși, capabili să facă pasul spre fotbalul de seniori.\n\n" +
                           "Mult succes în noul sezon, U21! Hai, Unirea!",

                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },
                new News()
                {
                    Id = 9,
                    Title = "Lotul echipei FC Unirea Youth pentru sezonul actual",
                    Text = "FC Unirea Youth aliniază în acest sezon un lot numeros, format din copii și adolescenți talentați, cu dorință de afirmare și mult entuziasm. Mulți dintre acești jucători reprezintă viitorul clubului și al fotbalului local. Iată componența lotului:\n\n" +
                           "**Portari:**  \n" +
                           "- Cristian Matei (2011)  \n" +
                           "- Vlad Ilie (2012)  \n" +
                           "- Ionuț Neagu (2009)  \n" +
                           "- Adrian Cojocaru (2012)  \n" +
                           "- Paul Vasilescu (2011)  \n" +
                           "- Alin Neagu (2010)  \n" +
                           "- Cristian Chiriac (2010)  \n\n" +
                           "**Fundași:**  \n" +
                           "- Gabriel Ionescu (2011)  \n\n" +
                           "**Mijlocași:**  \n" +
                           "- Alin Vasilescu (2012)  \n" +
                           "- Andrei Ionescu (2009)  \n" +
                           "- Vlad Ionescu (2011)  \n" +
                           "- Sergiu Enache (2011)  \n" +
                           "- Alex Vasilescu (2010)  \n" +
                           "- Adrian Toma (2009)  \n" +
                           "- Vlad Neagu (2011)  \n" +
                           "- Ionuț Ilie (2010)  \n\n" +
                           "**Atacanți:**  \n" +
                           "- Paul Rădulescu (2011)  \n" +
                           "- Alin Ionescu (2009)  \n" +
                           "- George Neagu (2010)  \n" +
                           "- Ionuț Diaconu (2009)  \n\n" +
                           "Clubul investește permanent în dezvoltarea acestor copii, asigurându-le pregătire modernă și condiții optime pentru a-și atinge potențialul. Mult succes, Unirea Youth!\n\n" +
                           "Hai, Unirea!",

                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },
                new News()
                {
                    Id = 10,
                    Title = "Lotul echipei FC Unirea Youth pentru sezonul actual",
                    Text = "FC Unirea Youth intră în noul sezon cu o echipă tânără și echilibrată, construită pe valori solide și pe dorința de afirmare a fiecărui copil. Jucătorii acestei generații sunt dovada investiției clubului în viitor, iar energia și ambiția lor se văd la fiecare antrenament și meci. Iată lotul complet:\n\n" +
                           "**Portari:**  \n" +
                           "- Adrian Cojocaru (2012)  \n" +
                           "- Alin Neagu (2010)  \n" +
                           "- Cristian Chiriac (2010)  \n\n" +
                           "**Fundași:**  \n" +
                           "- Cristian Matei (2011)  \n" +
                           "- Vlad Ilie (2012)  \n" +
                           "- Ionuț Neagu (2009)  \n" +
                           "- Gabriel Ionescu (2011)  \n" +
                           "- Paul Vasilescu (2011)  \n\n" +
                           "**Mijlocași:**  \n" +
                           "- Alin Vasilescu (2012)  \n" +
                           "- Andrei Ionescu (2009)  \n" +
                           "- Vlad Ionescu (2011)  \n" +
                           "- Sergiu Enache (2011)  \n" +
                           "- Alex Vasilescu (2010)  \n" +
                           "- Adrian Toma (2009)  \n" +
                           "- Vlad Neagu (2011)  \n" +
                           "- Ionuț Ilie (2010)  \n\n" +
                           "**Atacanți:**  \n" +
                           "- Paul Rădulescu (2011)  \n" +
                           "- Alin Ionescu (2009)  \n" +
                           "- George Neagu (2010)  \n" +
                           "- Ionuț Diaconu (2009)  \n\n" +
                           "Lotul este rezultatul muncii academiei și reflectă preocuparea permanentă pentru dezvoltarea tinerelor talente.  \n" +
                           "Succes, Unirea Youth! Hai, copii!",

                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },
                new News()
                {
                    Id = 11,
                    Title = "Acasă pentru FC Unirea: Unirea Stadium din Odobești",
                    Text = "FC Unirea își dispută meciurile de acasă pe **Unirea Stadium**, situat în orașul Odobești.\n\n" +
                           "Stadionul dispune de o capacitate de 10 locuri și este destinat exclusiv meciurilor echipelor clubului, oferind o atmosferă caldă și apropiată de comunitatea locală. De-a lungul timpului, Unirea Stadium a găzduit numeroase momente speciale pentru suporterii alb-albaștrilor, devenind un simbol al pasiunii pentru fotbal în zonă.\n\n" +
                           "Fiecare partidă jucată pe Unirea Stadium înseamnă emoție, determinare și susținere necondiționată din partea fanilor. Clubul mulțumește tuturor celor care vin să susțină echipa și promite să facă din fiecare meci o adevărată sărbătoare a fotbalului.\n\n" +
                           "Hai, Unirea!",

                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },
                new News()
                {
                    Id = 12,
                    Title = "Unirea U21 Stadium – Casa tinerilor de la FC Unirea U21",
                    Text = "FC Unirea U21 joacă meciurile de acasă pe **Unirea U21 Stadium**, în orașul Odobești.\n\n" +
                           "Stadionul oferă o capacitate de 10 locuri și a devenit un loc familiar pentru generațiile de tineri fotbaliști ai clubului. Fiecare partidă disputată aici este o oportunitate pentru juniorii noștri să impresioneze și să-și construiască drumul spre performanță.\n\n" +
                           "Suporterii care vin pe Unirea U21 Stadium creează o atmosferă caldă și încurajatoare, ajutând echipa să se simtă mereu susținută, indiferent de rezultat. Stadionul reprezintă un punct de pornire spre cariere de succes pentru mulți jucători crescuți la FC Unirea.\n\n" +
                           "Mult succes în noul sezon, Unirea U21!\n" +
                           "Hai, Unirea!",

                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },
                new News()
                {
                    Id = 13,
                    Title = "Unirea Youth Stadium – Terenul de joacă al viitorilor campioni",
                    Text = "FC Unirea Youth își dispută meciurile de acasă pe **Unirea Youth Stadium**, situat în Odobești.\n\n" +
                           "Acest stadion, cu o capacitate de 10 locuri, este locul unde copiii și adolescenții clubului fac primii pași în fotbalul organizat. Pentru mulți dintre ei, Unirea Youth Stadium reprezintă locul unde pasiunea pentru fotbal se transformă în visuri, prietenii și primele reușite sportive.\n\n" +
                           "Fiecare meci disputat aici este o oportunitate de a învăța, de a se bucura de fotbal și de a construi viitorul clubului. Atmosfera este mereu caldă, iar suporterii prezenți îi încurajează pe tinerii jucători la fiecare pas.\n\n" +
                           "Hai, Unirea Youth!",

                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },
                new News()
                {
                    Id = 14,
                    Title = "Locurile disponibile la meciurile de acasă pe Unirea Stadium",
                    Text = "La fiecare meci disputat pe **Unirea Stadium** din Odobești, suporterii au la dispoziție o gamă variată de locuri, atât pentru cei care preferă confortul maxim, cât și pentru cei care vor să simtă pulsul tribunei alături de ceilalți fani.\n\n" +
                           "**Locuri disponibile:**  \n" +
                           "- VIP: A1, A2 (preț: 150 lei/bilet)  \n" +
                           "- Standard: B1, B2, C1, C2, D1, D2, E1, E2 (preț: 50 lei/bilet)  \n\n" +
                           "Indiferent de tipul biletului ales, fiecare suporter contribuie la atmosfera specială de pe stadion și la susținerea echipei. Vă așteptăm la fiecare meci să vă bucurați de fotbal și să susțineți FC Unirea din tribunele noastre!",

                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },
                new News()
                {
                    Id = 19,
                    Title = "Remiză spectaculoasă pentru FC Unirea Youth cu Youth Galați!",
                    Text = "Pe 8 mai 2025, FC Unirea Youth a terminat la egalitate, scor 2-2, cu Youth Galați, într-un meci palpitant din Liga 1 Tineret.\n\n" +
                           "Pentru echipa noastră au marcat Paul Rădulescu și Alex Vasilescu, în timp ce pentru oaspeți au înscris Florin Neagu și Andrei Petrescu.\n\n" +
                           "A fost un meci plin de faze de poartă, determinare și spirit de luptă din partea ambelor formații. Bravo tinerilor pentru atitudine!\n\n" +
                           "Hai, Unirea Youth!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 20,
                    Title = "FC Unirea, victorie clară cu Steaua Sud în Liga 1!",
                    Text = "Pe 8 mai 2025, FC Unirea a obținut o victorie răsunătoare cu scorul de 4-1 împotriva echipei Steaua Sud, în Liga 1.\n\n" +
                           "Golurile echipei noastre au fost marcate de Daniel Stan, Denis Ilie, Denis Chiriac și George Ilie, în timp ce pentru oaspeți a înscris Vlad Chiriac.\n\n" +
                           "A fost o demonstrație de forță și eficiență din partea băieților noștri, cu un atac excelent și o defensivă solidă. Felicitări echipei pentru spectacol!\n\n" +
                           "Hai, Unirea!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 21,
                    Title = "FC Unirea câștigă în Cupa României pe terenul CS Mioveni!",
                    Text = "Pe 7 mai 2025, FC Unirea a învins în deplasare, scor 2-0, pe CS Mioveni, într-un meci din Cupa României.\n\n" +
                           "Ionuț Rădulescu a marcat unul dintre goluri, iar echipa a arătat o prestație solidă, calificându-se mai departe în competiție.\n\n" +
                           "Felicitări băieților pentru evoluția foarte bună și pentru parcursul în Cupă!\n\n" +
                           "Hai, Unirea!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 22,
                    Title = "Spectacol total: FC Unirea și Steaua Belgrad, remiză în Champions League!",
                    Text = "Pe 7 mai 2025, FC Unirea a terminat la egalitate, scor 2-2, cu Steaua Belgrad, într-un meci intens din Champions League.\n\n" +
                           "Alex Vasilescu și Denis Neagu au înscris pentru FC Unirea, iar pentru oaspeți au punctat Nikola Mitrovic și Aleksandar Radovanovic.\n\n" +
                           "Un duel spectaculos, cu multe faze de poartă și un public extraordinar. Felicitări jucătorilor pentru determinare și pentru punctul obținut în fața unei echipe de top!\n\n" +
                           "Hai, Unirea!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 23,
                    Title = "FC Unirea începe luna mai cu victorie contra CS Mioveni!",
                    Text = "Pe 1 mai 2025, FC Unirea s-a impus cu scorul de 2-1 în fața celor de la CS Mioveni, într-un meci disputat în Liga 1.\n\n" +
                           "Pentru FC Unirea au marcat Denis Chiriac și Ștefan Popescu, iar pentru adversari a înscris Radu Ionescu.\n\n" +
                           "Meciul a fost dinamic și disputat, cu un final fericit pentru echipa noastră. Felicitări băieților pentru victorie!\n\n" +
                           "Hai, Unirea!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },
                new News()
                {
                    Id = 24,
                    Title = "Înfrângere pentru FC Unirea pe terenul lui Juventus, în Champions League",
                    Text = "Pe 21 mai 2025, FC Unirea a pierdut cu 3-0 în fața lui Juventus, într-un meci din grupele Champions League.\n\n" +
                           "Pentru italieni au înscris Marco Rossi, Alessandro Esposito și Simone Marino.\n\n" +
                           "Deși scorul nu ne avantajează, echipa noastră va continua lupta pentru calificare!\n\n" +
                           "Hai, Unirea!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 25,
                    Title = "Victorie la limită pentru FC Unirea contra Dinamo Est!",
                    Text = "Pe 15 mai 2025, FC Unirea a câștigat cu 1-0 pe terenul celor de la Dinamo Est, într-un meci disputat în Liga 1.\n\n" +
                           "Unicul gol al partidei a fost marcat de Andrei Neagu, care a adus 3 puncte echipei noastre.\n\n" +
                           "Felicitări băieților pentru efort și dăruire!\n\n" +
                           "Hai, Unirea!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 26,
                    Title = "Remiză spectaculoasă între Youth Hunedoara și FC Unirea Youth!",
                    Text = "Pe 15 mai 2025, FC Unirea Youth a terminat la egalitate, scor 2-2, pe terenul celor de la Youth Hunedoara, într-un meci din Liga 1 Tineret.\n\n" +
                           "Pentru gazde au marcat Cristian Neagu și Daniel Popescu, iar pentru echipa noastră au înscris Alin Ionescu și Ionuț Diaconu.\n\n" +
                           "A fost un meci cu multe faze de poartă și suspans până la final. Felicitări tinerilor pentru atitudine!\n\n" +
                           "Hai, Unirea Youth!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 27,
                    Title = "FC Unirea U21 se impune în deplasare cu U21 Farul!",
                    Text = "Pe 15 mai 2025, FC Unirea U21 a obținut o victorie cu 2-0 pe terenul celor de la U21 Farul, în Liga 1 U21.\n\n" +
                           "Golurile victoriei au fost marcate de Sergiu Neagu și Sergiu Rădulescu.\n\n" +
                           "Băieții continuă seria de meciuri bune și urcă în clasament!\n\n" +
                           "Hai, Unirea U21!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 28,
                    Title = "Eșec pe teren propriu pentru FC Unirea U21 cu U21 Voluntari",
                    Text = "Pe 8 mai 2025, FC Unirea U21 a pierdut cu 2-0 în fața celor de la U21 Voluntari, într-un meci din Liga 1 U21.\n\n" +
                           "Pentru oaspeți au înscris Paul Neagu și Daniel Popescu.\n\n" +
                           "Băieții au luptat până la final, dar norocul nu a fost de partea noastră de această dată.\n\n" +
                           "Hai, Unirea U21!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },
                // NEWS

                new News()
                {
                    Id = 29,
                    Title = "Înfrângere la limită pentru FC Unirea U21 în deplasare la U21 Poli Iași",
                    Text = "Pe 29 mai 2025, FC Unirea U21 a pierdut cu 2-1 în fața echipei U21 Poli Iași, într-un meci din Liga 1 U21.\n\n" +
                           "Pentru gazde a marcat Ștefan Diaconu, iar pentru FC Unirea U21 a punctat Eduard Diaconu.\n\n" +
                           "Un meci disputat, cu ocazii de ambele părți. Băieții noștri au luptat până la final!\n\n" +
                           "Hai, Unirea U21!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 30,
                    Title = "FC Unirea Youth învinsă de Youth Vaslui în Liga 1 Tineret",
                    Text = "Pe 29 mai 2025, FC Unirea Youth a pierdut cu scorul de 3-1 pe terenul celor de la Youth Vaslui, într-un meci din Liga 1 Tineret.\n\n" +
                           "Pentru echipa noastră a marcat Ionuț Neagu, iar pentru gazde a înscris George Voicu.\n\n" +
                           "Tinerii noștri au avut momente bune, dar gazdele s-au impus până la final. Capul sus, băieți!\n\n" +
                           "Hai, Unirea Youth!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 31,
                    Title = "FC Unirea pierde acasă cu Rapid Nord, după un meci strâns",
                    Text = "Pe 22 mai 2025, FC Unirea a pierdut cu scorul de 2-1 pe teren propriu în fața Rapid Nord, într-un meci disputat în Liga 1.\n\n" +
                           "Alex Lazăr a marcat pentru FC Unirea, iar pentru oaspeți a înscris Cristian Enache.\n\n" +
                           "Un meci cu multe ocazii, în care am avut ghinion. Hai, Unirea, nu renunțăm!\n\n" +
                           "Hai, Unirea!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 32,
                    Title = "Remiză albă între FC Unirea U21 și U21 Sepsi în Liga 1 U21",
                    Text = "Pe 22 mai 2025, FC Unirea U21 a remizat 0-0 cu U21 Sepsi, într-un meci echilibrat din Liga 1 U21.\n\n" +
                           "Deși nu s-au marcat goluri, meciul a fost disputat și cu multe ocazii la ambele porți.\n\n" +
                           "Felicitări băieților pentru efort!\n\n" +
                           "Hai, Unirea U21!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 33,
                    Title = "FC Unirea Youth pierde la limită cu Youth Târgoviște",
                    Text = "Pe 22 mai 2025, FC Unirea Youth a fost învinsă cu 1-0 de Youth Târgoviște, într-un meci din Liga 1 Tineret.\n\n" +
                           "A fost un meci echilibrat, dar adversarii au reușit să înscrie unicul gol al partidei.\n\n" +
                           "Tinerii noștri au dat totul pe teren și merită felicitări pentru efort!\n\n" +
                           "Hai, Unirea Youth!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },
                // NEWS

                new News()
                {
                    Id = 34,
                    Title = "FC Unirea obține o victorie importantă cu Dinamo Zagreb în Champions League!",
                    Text = "Pe 4 iunie 2025, FC Unirea a învins cu scorul de 2-1 pe Dinamo Zagreb, într-un meci disputat în Champions League.\n\n" +
                           "Golurile victoriei au fost marcate de Andrei Neagu și Daniel Rădulescu pentru FC Unirea, în timp ce pentru oaspeți a înscris Ivan Kovacic.\n\n" +
                           "Echipa a avut o evoluție excelentă și adaugă încă 3 puncte în grupa europeană!\n\n" +
                           "Hai, Unirea!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 35,
                    Title = "Calificare categorică: FC Unirea câștigă cu Steaua Sud în Cupa României!",
                    Text = "Pe 1 iunie 2025, FC Unirea s-a impus cu 4-0 în fața echipei Steaua Sud, într-un meci din Cupa României.\n\n" +
                           "Pentru echipa noastră au marcat Alex Lazăr, Alin Neagu, Robert Vasilescu și George Ilie.\n\n" +
                           "A fost un meci dominat de la un capăt la altul, cu o defensivă solidă și un atac de neoprit. Felicitări echipei pentru calificare!\n\n" +
                           "Hai, Unirea!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 36,
                    Title = "Remiză între FC Unirea și Petrolul Vest în Liga 1",
                    Text = "Pe 29 mai 2025, FC Unirea a terminat la egalitate, scor 1-1, pe terenul Petrolul Vest, într-un meci din Liga 1.\n\n" +
                           "Pentru gazde a marcat Vlad Voicu, iar pentru FC Unirea a înscris Denis Chiriac.\n\n" +
                           "A fost un meci echilibrat, cu ocazii de ambele părți. Continuăm lupta pentru locurile fruntașe!\n\n" +
                           "Hai, Unirea!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },
                // NEWS

                new News()
                {
                    Id = 37,
                    Title = "Înfrângere pentru FC Unirea la CSM Cluj în Liga 1",
                    Text = "Pe 13 iunie 2025, FC Unirea a pierdut cu scorul de 3-0 pe terenul celor de la CSM Cluj, într-un meci din Liga 1.\n\n" +
                           "Pentru gazde au marcat Mihai Ionescu, Denis Voicu și Gabriel Rădulescu.\n\n" +
                           "Echipa noastră va încerca să revină cu un rezultat pozitiv în următoarea etapă.\n\n" +
                           "Hai, Unirea!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 38,
                    Title = "Remiză între U21 Argeș și FC Unirea U21 în Liga 1 U21",
                    Text = "Pe 13 iunie 2025, FC Unirea U21 a remizat 1-1 în deplasare cu U21 Argeș, într-un meci din Liga 1 U21.\n\n" +
                           "Pentru gazde a marcat George Popescu, iar pentru FC Unirea U21 a punctat Denis Cojocaru.\n\n" +
                           "A fost un meci echilibrat, cu șanse de ambele părți.\n\n" +
                           "Hai, Unirea U21!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 39,
                    Title = "FC Unirea Youth scoate un egal la Youth Craiova în Liga 1 Tineret",
                    Text = "Pe 13 iunie 2025, FC Unirea Youth a terminat la egalitate, scor 2-2, în deplasare la Youth Craiova, într-un meci din Liga 1 Tineret.\n\n" +
                           "Pentru echipa noastră a marcat Ionuț Diaconu, iar pentru adversari a înscris Andrei Enache.\n\n" +
                           "Un rezultat bun, cu evoluții solide de ambele părți.\n\n" +
                           "Hai, Unirea Youth!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 40,
                    Title = "Remiză albă între Steaua Sud și FC Unirea în Cupa României",
                    Text = "Pe 8 iunie 2025, FC Unirea a remizat 0-0 în deplasare la Steaua Sud, într-un meci fără goluri în Cupa României.\n\n" +
                           "Meci echilibrat, cu ocazii de ambele părți, dar fără reușite pe tabelă.\n\n" +
                           "Hai, Unirea!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 41,
                    Title = "FC Unirea și Universitatea Brașov termină la egalitate în Liga 1",
                    Text = "Pe 6 iunie 2025, FC Unirea a remizat 1-1 cu Universitatea Brașov, într-un meci disputat în Liga 1.\n\n" +
                           "Pentru gazde a marcat Alex Vasilescu, iar pentru oaspeți a înscris Alin Ionescu.\n\n" +
                           "Meci echilibrat, ambele echipe au arătat fotbal de calitate.\n\n" +
                           "Hai, Unirea!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 42,
                    Title = "Înfrângere pe teren propriu pentru FC Unirea U21 cu U21 UTA",
                    Text = "Pe 6 iunie 2025, FC Unirea U21 a pierdut cu 2-0 pe teren propriu cu U21 UTA, într-un meci din Liga 1 U21.\n\n" +
                           "Pentru oaspeți au înscris Vlad Stan și Alin Enache.\n\n" +
                           "Băieții noștri au luptat, dar nu au reușit să marcheze de această dată.\n\n" +
                           "Hai, Unirea U21!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 43,
                    Title = "FC Unirea Youth, învinsă la limită de Youth Baia Mare",
                    Text = "Pe 6 iunie 2025, FC Unirea Youth a pierdut cu 1-0 în fața echipei Youth Baia Mare, într-un meci din Liga 1 Tineret.\n\n" +
                           "Unicul gol al partidei a fost marcat de Vlad Ionescu.\n\n" +
                           "Tinerii noștri au dat totul pe teren, dar norocul nu a fost de partea noastră.\n\n" +
                           "Hai, Unirea Youth!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },
                // NEWS

                new News()
                {
                    Id = 44,
                    Title = "Remiză albă pentru FC Unirea U21 la U21 Botoșani",
                    Text = "Pe 27 iunie 2025, FC Unirea U21 a terminat la egalitate, scor 0-0, cu U21 Botoșani, într-un meci din Liga 1 U21.\n\n" +
                           "A fost un meci echilibrat, fără goluri, dar cu multe faze de poartă de ambele părți.\n\n" +
                           "Hai, Unirea U21!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 45,
                    Title = "FC Unirea Youth câștigă la Oradea în Liga 1 Tineret!",
                    Text = "Pe 27 iunie 2025, FC Unirea Youth a obținut o victorie cu 2-0 pe terenul celor de la Youth Oradea, într-un meci din Liga 1 Tineret.\n\n" +
                           "Vlad Ionescu a marcat pentru echipa noastră, aducând trei puncte importante.\n\n" +
                           "Felicitări tinerilor pentru efort și atitudine!\n\n" +
                           "Hai, Unirea Youth!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 46,
                    Title = "FC Unirea se impune în deplasare la Viitorul Constanța!",
                    Text = "Pe 27 iunie 2025, FC Unirea a câștigat cu 2-1 pe terenul Viitorul Constanța, într-un meci disputat în Liga 1.\n\n" +
                           "Pentru gazde a marcat Gabriel Vasilescu, iar pentru FC Unirea au înscris Denis Chiriac și Alex Vasilescu.\n\n" +
                           "Un meci spectaculos, cu răsturnări de scor și un final fericit pentru echipa noastră.\n\n" +
                           "Hai, Unirea!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 47,
                    Title = "Remiză fără goluri între FC Unirea și Gloria Buzău în Liga 1",
                    Text = "Pe 20 iunie 2025, FC Unirea a remizat 0-0 cu Gloria Buzău, într-un meci echilibrat din Liga 1.\n\n" +
                           "Deși nu s-au marcat goluri, meciul a fost disputat și cu ocazii de ambele părți.\n\n" +
                           "Hai, Unirea!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 48,
                    Title = "Înfrângere pentru FC Unirea Youth cu Youth Ploiești",
                    Text = "Pe 20 iunie 2025, FC Unirea Youth a pierdut cu scorul de 3-1 pe teren propriu cu Youth Ploiești, într-un meci din Liga 1 Tineret.\n\n" +
                           "Singurul gol al echipei noastre a fost marcat de Andrei Ionescu.\n\n" +
                           "Băieții au dat totul pe teren și merită încurajări pentru efort!\n\n" +
                           "Hai, Unirea Youth!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 49,
                    Title = "FC Unirea U21 învinge clar pe U21 Hermannstadt în Liga 1 U21!",
                    Text = "Pe 20 iunie 2025, FC Unirea U21 a câștigat cu scorul de 3-0 împotriva celor de la U21 Hermannstadt, într-un meci disputat în Liga 1 U21.\n\n" +
                           "Pentru echipa noastră au marcat Alin Voicu și Sergiu Neagu.\n\n" +
                           "O victorie clară, cu un joc solid pe toate compartimentele.\n\n" +
                           "Hai, Unirea U21!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 50,
                    Title = "FC Unirea cedează la Paris cu PSG în Champions League",
                    Text = "Pe 18 iunie 2025, FC Unirea a fost învinsă cu scorul de 2-0 pe terenul celor de la Paris Saint-Germain, într-un meci disputat în Champions League.\n\n" +
                           "Pentru gazde a marcat Laurent Moreau, iar pentru FC Unirea a punctat Alin Neagu.\n\n" +
                           "Echipa noastră merge mai departe cu capul sus și speră la o revanșă acasă!\n\n" +
                           "Hai, Unirea!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },
                // NEWS

                new News()
                {
                    Id = 51,
                    Title = "FC Unirea trece de Dinamo Est în Cupa României, la capătul unui meci spectaculos!",
                    Text = "Pe 7 iulie 2025, FC Unirea s-a impus cu scorul de 3-2 pe terenul celor de la Dinamo Est, într-un meci dramatic din Cupa României.\n\n" +
                           "Golurile echipei noastre au fost marcate de Andrei Neagu, Alex Vasilescu și Daniel Stan.\n\n" +
                           "Bravo băieților pentru calificare și determinare!\n\n" +
                           "Hai, Unirea!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 52,
                    Title = "FC Unirea, înfrântă la CS Mioveni în Liga 1",
                    Text = "Pe 4 iulie 2025, FC Unirea a pierdut cu scorul de 2-0 pe terenul celor de la CS Mioveni, într-un meci din Liga 1.\n\n" +
                           "Pentru gazde au marcat Daniel Ilie și Gabriel Chiriac.\n\n" +
                           "Echipa noastră va căuta revanșa în etapele următoare.\n\n" +
                           "Hai, Unirea!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 53,
                    Title = "Victorie pentru FC Unirea Youth la Arad!",
                    Text = "Pe 4 iulie 2025, FC Unirea Youth a câștigat cu scorul de 1-0 pe terenul celor de la Youth Arad, într-un meci din Liga 1 Tineret.\n\n" +
                           "Tinerii noștri au obținut o victorie muncită, demonstrând caracter și ambiție.\n\n" +
                           "Felicitări tuturor jucătorilor!\n\n" +
                           "Hai, Unirea Youth!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 54,
                    Title = "FC Unirea U21 câștigă la U21 Slatina în Liga 1 U21!",
                    Text = "Pe 4 iulie 2025, FC Unirea U21 a câștigat cu scorul de 2-0 în deplasare la U21 Slatina, într-un meci disputat în Liga 1 U21.\n\n" +
                           "Echipa noastră a dominat jocul și a obținut trei puncte importante.\n\n" +
                           "Hai, Unirea U21!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 55,
                    Title = "FC Unirea și Olympiakos, remiză în Champions League!",
                    Text = "Pe 2 iulie 2025, FC Unirea a remizat 1-1 cu Olympiakos, într-un meci disputat în grupele Champions League.\n\n" +
                           "Pentru FC Unirea a înscris Sergiu Chiriac, iar pentru greci a marcat Marios Retsos.\n\n" +
                           "Un punct important în economia grupei. Felicitări băieților pentru efort!\n\n" +
                           "Hai, Unirea!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },

                new News()
                {
                    Id = 56,
                    Title = "FC Unirea câștigă clar cu Dinamo Est în Cupa României!",
                    Text = "Pe 1 iulie 2025, FC Unirea a învins cu 3-0 pe Dinamo Est, într-un meci din Cupa României.\n\n" +
                           "Golurile echipei noastre au fost marcate de Denis Ilie, Gabriel Vasilescu și Radu Ilie.\n\n" +
                           "Echipa merge mai departe cu un moral excelent!\n\n" +
                           "Hai, Unirea!",
                    CreatedAt = DateTime.UtcNow,
                    News_UsersId = 1
                },



            });

            modelBuilder.Entity<Comments>().HasData(new List<Comments>()
            {
                new Comments() { Id = 1, Text = "Felicitări echipei! Suntem mândri că FC Unirea ajunge și în Champions League!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 1, Comment_UsersId = 2 },
                new Comments() { Id = 2, Text = "Forza Unirea! Abia aștept meciurile din toate cele trei competiții!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 1, Comment_UsersId = 3 },
                new Comments() { Id = 3, Text = "Va fi un sezon greu, dar cu susținerea noastră sigur veți reuși!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 1, Comment_UsersId = 4 },
                new Comments() { Id = 4, Text = "Mult succes băieților, mai ales în Champions League! Suntem alături de voi!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 1, Comment_UsersId = 5 },
                new Comments() { Id = 5, Text = "Bravo! Să dovediți că sunteți cei mai buni atât în țară, cât și în Europa!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 1, Comment_UsersId = 6 },
                new Comments() { Id = 6, Text = "Aștept cu nerăbdare derby-urile din Liga 1! Haideți să câștigăm tot!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 1, Comment_UsersId = 7 },
                new Comments() { Id = 7, Text = "Băieți, să jucați cu inima și să nu vă lăsați niciodată!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 1, Comment_UsersId = 8 },
                new Comments() { Id = 8, Text = "Să avem un sezon plin de victorii! Mult succes și în Cupa României!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 1, Comment_UsersId = 9 },
                new Comments() { Id = 9, Text = "Ne vedem pe stadion! Vom fi mereu în spatele vostru, orice ar fi!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 1, Comment_UsersId = 10 },
                new Comments() { Id = 10, Text = "Felicitări întregului staff! Muncă, pasiune și dedicare – doar așa vom ajunge departe!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 1, Comment_UsersId = 11 }
            });
            modelBuilder.Entity<Comments>().HasData(new List<Comments>()
            {
                new Comments() { Id = 11, Text = "Mult succes băieților din U21! Abia aștept să văd tineri noi pe teren.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 2, Comment_UsersId = 12 },
                new Comments() { Id = 12, Text = "Bravo, Unirea! E important să investiți în tineret.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 2, Comment_UsersId = 13 },
                new Comments() { Id = 13, Text = "Forță, U21! Aveți toată susținerea noastră, haideți să arătați ce puteți!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 2, Comment_UsersId = 14 },
                new Comments() { Id = 14, Text = "Felicitări staff-ului pentru încrederea oferită tinerilor!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 2, Comment_UsersId = 15 },
                new Comments() { Id = 15, Text = "Este o șansă mare pentru voi. Luptați până la capăt!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 2, Comment_UsersId = 16 },
                new Comments() { Id = 16, Text = "Hai, Unirea U21! Viitorul începe cu voi!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 2, Comment_UsersId = 17 },
                new Comments() { Id = 17, Text = "Sper să vedem cât mai mulți dintre voi în echipa mare!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 2, Comment_UsersId = 18 },
                new Comments() { Id = 18, Text = "Este important să creștem talente locale. Mult succes!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 2, Comment_UsersId = 19 },
                new Comments() { Id = 19, Text = "Fiecare meci e o experiență nouă. Dați totul pe teren!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 2, Comment_UsersId = 20 },
                new Comments() { Id = 20, Text = "Vă țin pumnii la fiecare etapă! Hai, băieții!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 2, Comment_UsersId = 21 }
            });
            modelBuilder.Entity<Comments>().HasData(new List<Comments>()
            {
                new Comments() { Id = 21, Text = "Felicitări micilor Uniriști! Sunteți viitorul clubului!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 3, Comment_UsersId = 22 },
                new Comments() { Id = 22, Text = "Este minunat să vedem atât de mulți copii talentați la Unirea!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 3, Comment_UsersId = 23 },
                new Comments() { Id = 23, Text = "Mult succes în noul sezon! Să creșteți frumos și cu ambiție!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 3, Comment_UsersId = 24 },
                new Comments() { Id = 24, Text = "Bravo, FC Unirea Youth! Sunt sigur că veți impresiona!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 3, Comment_UsersId = 25 },
                new Comments() { Id = 25, Text = "Susținerea suporterilor e mereu cu voi, indiferent de vârstă!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 3, Comment_UsersId = 26 },
                new Comments() { Id = 26, Text = "Aștept să văd următoarea generație pe terenul mare!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 3, Comment_UsersId = 27 },
                new Comments() { Id = 27, Text = "Este foarte important să investiți în copii! Multă baftă!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 3, Comment_UsersId = 28 },
                new Comments() { Id = 28, Text = "Bucuria și pasiunea voastră pentru fotbal ne inspiră pe toți!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 3, Comment_UsersId = 29 },
                new Comments() { Id = 29, Text = "Să aveți parte de un sezon plin de goluri și zâmbete!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 3, Comment_UsersId = 30 },
                new Comments() { Id = 30, Text = "Felicitări și succes! Sper să vă vedem în curând la echipa mare!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 3, Comment_UsersId = 31 }
            });
            modelBuilder.Entity<Comments>().HasData(new List<Comments>()
            {
                new Comments() { Id = 31, Text = "Respect pentru întreaga istorie a clubului! Hai Unirea!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 4, Comment_UsersId = 2 },
                new Comments() { Id = 32, Text = "Felicitări pentru toate promovările și pentru ce ați construit!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 4, Comment_UsersId = 3 },
                new Comments() { Id = 33, Text = "Antrenorul Petrica Florea a făcut o treabă excelentă. Mult succes în continuare!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 4, Comment_UsersId = 4 },
                new Comments() { Id = 34, Text = "FC Unirea este un exemplu pentru fotbalul românesc!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 4, Comment_UsersId = 5 },
                new Comments() { Id = 35, Text = "Mă bucur că investește în tineri și promovează valorile locale.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 4, Comment_UsersId = 6 },
                new Comments() { Id = 36, Text = "Succes pe mai departe, Petrica Florea și întreaga echipă!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 4, Comment_UsersId = 7 },
                new Comments() { Id = 37, Text = "Felicitări pentru tot ce ați realizat de la înființare până azi!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 4, Comment_UsersId = 8 },
                new Comments() { Id = 38, Text = "Echipa asta chiar merită să fie susținută, se vede progresul an de an.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 4, Comment_UsersId = 9 },
                new Comments() { Id = 39, Text = "Hai Unirea! Să continuați să ne faceți mândri!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 4, Comment_UsersId = 10 },
                new Comments() { Id = 40, Text = "Toată stima pentru staff și pentru antrenorul nostru! Înainte, Unirea!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 4, Comment_UsersId = 11 }
            });
            modelBuilder.Entity<Comments>().HasData(new List<Comments>()
            {
                new Comments() { Id = 41, Text = "Felicitări pentru tot ce faceți pentru tinerii jucători!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 5, Comment_UsersId = 12 },
                new Comments() { Id = 42, Text = "Strategia clubului dă rezultate. Mulți dintre favoriții mei au venit de aici!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 5, Comment_UsersId = 13 },
                new Comments() { Id = 43, Text = "Bravo, Mihai Olaru! Se vede implicarea și profesionalismul echipei.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 5, Comment_UsersId = 14 },
                new Comments() { Id = 44, Text = "Îmi place că se pune accent pe disciplină și joc de echipă.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 5, Comment_UsersId = 15 },
                new Comments() { Id = 45, Text = "Este foarte importantă această legătură între juniori și seniori!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 5, Comment_UsersId = 16 },
                new Comments() { Id = 46, Text = "Succes în noul sezon! Sunt sigur că veți promova noi talente.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 5, Comment_UsersId = 17 },
                new Comments() { Id = 47, Text = "FC Unirea U21 a devenit o adevărată pepinieră de jucători.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 5, Comment_UsersId = 18 },
                new Comments() { Id = 48, Text = "Felicitări întregului staff pentru munca depusă!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 5, Comment_UsersId = 19 },
                new Comments() { Id = 49, Text = "Am încredere că veți duce mai departe tradiția clubului!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 5, Comment_UsersId = 20 },
                new Comments() { Id = 50, Text = "Hai Unirea U21, să aveți un sezon excelent!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 5, Comment_UsersId = 21 }
            });
            modelBuilder.Entity<Comments>().HasData(new List<Comments>()
            {
                new Comments() { Id = 51, Text = "Felicitări pentru investiția în copii și pentru tot ce faceți la nivel de academie!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 6, Comment_UsersId = 22 },
                new Comments() { Id = 52, Text = "Este minunat să vedem o academie care chiar scoate talente!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 6, Comment_UsersId = 23 },
                new Comments() { Id = 53, Text = "Respect pentru Nica Cercel și pentru toți antrenorii de la Youth.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 6, Comment_UsersId = 24 },
                new Comments() { Id = 54, Text = "Unirea Youth este un exemplu pentru multe cluburi din țară.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 6, Comment_UsersId = 25 },
                new Comments() { Id = 55, Text = "Mă bucur să văd accent pe educație și respect, nu doar pe performanță.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 6, Comment_UsersId = 26 },
                new Comments() { Id = 56, Text = "Hai Unirea Youth! Să creșteți mari și să ajungeți cât mai sus!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 6, Comment_UsersId = 27 },
                new Comments() { Id = 57, Text = "Bravo tuturor pentru rezultatele obținute la nivel de juniori!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 6, Comment_UsersId = 28 },
                new Comments() { Id = 58, Text = "Sprijinul pentru copii și adolescenți face diferența pe termen lung.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 6, Comment_UsersId = 29 },
                new Comments() { Id = 59, Text = "Am încredere că Unirea Youth va produce generații de campioni.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 6, Comment_UsersId = 30 },
                new Comments() { Id = 60, Text = "Felicitări Nica Cercel pentru munca extraordinară din academie!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 6, Comment_UsersId = 31 }
            });
            modelBuilder.Entity<Comments>().HasData(new List<Comments>()
            {
                new Comments() { Id = 61, Text = "Lot foarte echilibrat, avem șanse mari la titlu anul acesta!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 7, Comment_UsersId = 2 },
                new Comments() { Id = 62, Text = "Mă bucur să văd și mulți tineri promovați în echipă!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 7, Comment_UsersId = 3 },
                new Comments() { Id = 63, Text = "Forza Unirea! Fundașii noștri sunt printre cei mai buni din campionat.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 7, Comment_UsersId = 4 },
                new Comments() { Id = 64, Text = "Portarii au experiență și pot aduce multe puncte!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 7, Comment_UsersId = 5 },
                new Comments() { Id = 65, Text = "Felicitări staff-ului pentru selecție! Arată foarte bine lotul.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 7, Comment_UsersId = 6 },
                new Comments() { Id = 66, Text = "Sper să vedem cât mai multe goluri de la atacanți!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 7, Comment_UsersId = 7 },
                new Comments() { Id = 67, Text = "Mult succes echipei în noul sezon, vom fi mereu în tribune!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 7, Comment_UsersId = 8 },
                new Comments() { Id = 68, Text = "Îmi place echilibrul între experiență și tinerețe.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 7, Comment_UsersId = 9 },
                new Comments() { Id = 69, Text = "Haideți băieți, să facem un sezon de neuitat!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 7, Comment_UsersId = 10 },
                new Comments() { Id = 70, Text = "Bravo Unirea, arătați ca o echipă pregătită pentru orice!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 7, Comment_UsersId = 11 }
            });
            modelBuilder.Entity<Comments>().HasData(new List<Comments>()
            {
                new Comments() { Id = 71, Text = "Lot promițător! Avem mulți tineri cu potențial în acest sezon.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 8, Comment_UsersId = 12 },
                new Comments() { Id = 72, Text = "Portarii sunt foarte tineri, abia aștept să-i văd la lucru!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 8, Comment_UsersId = 13 },
                new Comments() { Id = 73, Text = "Fundașii noștri par foarte bine pregătiți. Hai, Unirea U21!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 8, Comment_UsersId = 14 },
                new Comments() { Id = 74, Text = "Felicitări staff-ului pentru alegerea lotului, multă baftă!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 8, Comment_UsersId = 15 },
                new Comments() { Id = 75, Text = "Mijlocul arată echilibrat, cu jucători din generații diferite.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 8, Comment_UsersId = 16 },
                new Comments() { Id = 76, Text = "Atacanții noștri sunt talentați, sper să înscrie cât mai mult!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 8, Comment_UsersId = 17 },
                new Comments() { Id = 77, Text = "Se vede accentul pus pe formarea tinerilor, bravo clubului!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 8, Comment_UsersId = 18 },
                new Comments() { Id = 78, Text = "Să avem un sezon plin de reușite și fără accidentări!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 8, Comment_UsersId = 19 },
                new Comments() { Id = 79, Text = "Hai Unirea U21, susținem viitorul echipei mari!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 8, Comment_UsersId = 20 },
                new Comments() { Id = 80, Text = "Mult succes tuturor băieților! Haideți să arătăm ce putem!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 8, Comment_UsersId = 21 }
            });
            modelBuilder.Entity<Comments>().HasData(new List<Comments>()
            {
                new Comments() { Id = 81, Text = "Felicitări tuturor copiilor și antrenorilor, să aveți un sezon minunat!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 9, Comment_UsersId = 22 },
                new Comments() { Id = 82, Text = "Lot numeros și diversificat, viitorul sună bine la Unirea!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 9, Comment_UsersId = 23 },
                new Comments() { Id = 83, Text = "Succes portărilor noștri cei mici! Să apere cu curaj poarta Unirii!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 9, Comment_UsersId = 24 },
                new Comments() { Id = 84, Text = "Mijlocașii sunt motorul echipei! Bravo, băieți!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 9, Comment_UsersId = 25 },
                new Comments() { Id = 85, Text = "Felicitări tuturor atacanților, să aveți un sezon plin de goluri!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 9, Comment_UsersId = 26 },
                new Comments() { Id = 86, Text = "Echipa Youth arată foarte bine, multă baftă pe teren!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 9, Comment_UsersId = 27 },
                new Comments() { Id = 87, Text = "Bravo clubului pentru investiția constantă în copii!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 9, Comment_UsersId = 28 },
                new Comments() { Id = 88, Text = "Sper ca mulți dintre acești jucători să ajungă la seniori!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 9, Comment_UsersId = 29 },
                new Comments() { Id = 89, Text = "Un sezon plin de reușite vă doresc, haideți să ne faceți mândri!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 9, Comment_UsersId = 30 },
                new Comments() { Id = 90, Text = "Hai Unirea Youth, sunteți viitorul echipei mari!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 9, Comment_UsersId = 31 }
            });
            modelBuilder.Entity<Comments>().HasData(new List<Comments>()
            {
                new Comments() { Id = 91, Text = "Se vede câtă muncă se depune la nivel de copii, felicitări clubului!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 10, Comment_UsersId = 22 },
                new Comments() { Id = 92, Text = "Mult succes portărilor noștri, să aveți un sezon de excepție!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 10, Comment_UsersId = 23 },
                new Comments() { Id = 93, Text = "Fundașii sunt foarte bine reprezentanți, bravo băieți!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 10, Comment_UsersId = 24 },
                new Comments() { Id = 94, Text = "Mijlocul echipei Youth arată foarte bine, multă energie și determinare!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 10, Comment_UsersId = 25 },
                new Comments() { Id = 95, Text = "Atacanții noștri vor marca sigur multe goluri!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 10, Comment_UsersId = 26 },
                new Comments() { Id = 96, Text = "Felicitări antrenorilor pentru selecție și muncă!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 10, Comment_UsersId = 27 },
                new Comments() { Id = 97, Text = "Hai Unirea Youth, să fiți uniți și să vă bucurați de fotbal!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 10, Comment_UsersId = 28 },
                new Comments() { Id = 98, Text = "Clubul are cu adevărat grijă de viitorul fotbalului local!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 10, Comment_UsersId = 29 },
                new Comments() { Id = 99, Text = "Sper să vedem cât mai mulți dintre voi la echipa mare în curând!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 10, Comment_UsersId = 30 },
                new Comments() { Id = 100, Text = "Mult succes tuturor copiilor și un sezon fără accidentări!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 10, Comment_UsersId = 31 }
            });
            modelBuilder.Entity<Comments>().HasData(new List<Comments>()
            {
                new Comments() { Id = 101, Text = "Un stadion mic, dar cu o atmosferă extraordinară!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 11, Comment_UsersId = 2 },
                new Comments() { Id = 102, Text = "Odobestiul trăiește pentru fotbal! Hai Unirea!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 11, Comment_UsersId = 3 },
                new Comments() { Id = 103, Text = "Aici ne simțim cu adevărat acasă, aproape de echipă!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 11, Comment_UsersId = 4 },
                new Comments() { Id = 104, Text = "Fiecare meci pe acest stadion e special pentru noi.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 11, Comment_UsersId = 5 },
                new Comments() { Id = 105, Text = "De-abia aștept să reînceapă sezonul și să fiu pe stadion!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 11, Comment_UsersId = 6 },
                new Comments() { Id = 106, Text = "Hai Unirea, să ne faceți mândri pe Unirea Stadium!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 11, Comment_UsersId = 7 },
                new Comments() { Id = 107, Text = "Sunt multe amintiri frumoase legate de acest stadion.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 11, Comment_UsersId = 8 },
                new Comments() { Id = 108, Text = "Respect pentru toți suporterii care vin la fiecare meci!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 11, Comment_UsersId = 9 },
                new Comments() { Id = 109, Text = "Mic, dar esențial pentru spiritul echipei noastre!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 11, Comment_UsersId = 10 },
                new Comments() { Id = 110, Text = "Hai Unirea, pe Unirea Stadium scriem istorie!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 11, Comment_UsersId = 11 }
            });
            modelBuilder.Entity<Comments>().HasData(new List<Comments>()
            {
                new Comments() { Id = 111, Text = "Atmosfera la meciurile U21 e mereu specială!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 12, Comment_UsersId = 12 },
                new Comments() { Id = 112, Text = "Un stadion mic, dar perfect pentru meciurile tinerilor.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 12, Comment_UsersId = 13 },
                new Comments() { Id = 113, Text = "Sunt mândru să văd juniorii noștri crescând pe acest teren.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 12, Comment_UsersId = 14 },
                new Comments() { Id = 114, Text = "Fiecare meci e o lecție de fotbal pentru tinerii noștri.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 12, Comment_UsersId = 15 },
                new Comments() { Id = 115, Text = "Felicitări clubului că investește în tineret!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 12, Comment_UsersId = 16 },
                new Comments() { Id = 116, Text = "Hai Unirea U21, să aveți un sezon plin de victorii!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 12, Comment_UsersId = 17 },
                new Comments() { Id = 117, Text = "Toți cei care vin la stadion sunt parte din familia Unirea!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 12, Comment_UsersId = 18 },
                new Comments() { Id = 118, Text = "Este important ca juniorii să aibă propriul lor stadion.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 12, Comment_UsersId = 19 },
                new Comments() { Id = 119, Text = "Meciurile U21 sunt întotdeauna pline de energie!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 12, Comment_UsersId = 20 },
                new Comments() { Id = 120, Text = "Sunt sigur că Unirea U21 va avea un sezon de excepție pe acest stadion!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 12, Comment_UsersId = 21 }
            });
            modelBuilder.Entity<Comments>().HasData(new List<Comments>()
            {
                new Comments() { Id = 121, Text = "Felicitări pentru grija față de cei mici! Un stadion cu adevărat special.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 13, Comment_UsersId = 22 },
                new Comments() { Id = 122, Text = "Unirea Youth Stadium e locul unde începe povestea fiecărui campion!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 13, Comment_UsersId = 23 },
                new Comments() { Id = 123, Text = "Fiecare copil merită să joace pe un teren atât de primitor.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 13, Comment_UsersId = 24 },
                new Comments() { Id = 124, Text = "Aici se simte bucuria fotbalului autentic!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 13, Comment_UsersId = 25 },
                new Comments() { Id = 125, Text = "Bravo clubului că investește în condiții pentru copii!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 13, Comment_UsersId = 26 },
                new Comments() { Id = 126, Text = "Meciurile de la Youth Stadium sunt mereu pline de entuziasm.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 13, Comment_UsersId = 27 },
                new Comments() { Id = 127, Text = "Felicitări tinerilor jucători pentru determinare și curaj!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 13, Comment_UsersId = 28 },
                new Comments() { Id = 128, Text = "Hai Unirea Youth! Vă susținem la fiecare meci!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 13, Comment_UsersId = 29 },
                new Comments() { Id = 129, Text = "Important să avem astfel de baze pentru generațiile următoare.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 13, Comment_UsersId = 30 },
                new Comments() { Id = 130, Text = "Succes tuturor copiilor care își trăiesc visul pe acest stadion!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 13, Comment_UsersId = 31 }
            });
            modelBuilder.Entity<Comments>().HasData(new List<Comments>()
            {
                new Comments() { Id = 131, Text = "VIP-ul e perfect pentru cei care vor să vadă meciul în cele mai bune condiții!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 14, Comment_UsersId = 2 },
                new Comments() { Id = 132, Text = "Prețurile sunt accesibile pentru toată lumea, bravo clubului!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 14, Comment_UsersId = 3 },
                new Comments() { Id = 133, Text = "Mereu aleg Standard, acolo atmosfera e cea mai tare!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 14, Comment_UsersId = 4 },
                new Comments() { Id = 134, Text = "Felicitări pentru organizare, abia aștept următorul meci acasă!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 14, Comment_UsersId = 5 },
                new Comments() { Id = 135, Text = "Îmi place diversitatea locurilor, fiecare își găsește ceva pe plac.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 14, Comment_UsersId = 6 },
                new Comments() { Id = 136, Text = "Vreau să-mi iau bilet VIP la derby-ul cu rivala, e clar!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 14, Comment_UsersId = 7 },
                new Comments() { Id = 137, Text = "Hai Unirea, oriunde aș sta, important e să fim alături de voi!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 14, Comment_UsersId = 8 },
                new Comments() { Id = 138, Text = "Apreciez efortul clubului de a oferi condiții cât mai bune fanilor.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 14, Comment_UsersId = 9 },
                new Comments() { Id = 139, Text = "Să fie stadionul plin la fiecare meci, doar așa câștigăm împreună!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 14, Comment_UsersId = 10 },
                new Comments() { Id = 140, Text = "Forza Unirea! Ne vedem la următorul meci pe Unirea Stadium!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 14, Comment_UsersId = 11 }
            });
            modelBuilder.Entity<Comments>().HasData(new List<Comments>()
            {
                // NewsId: 19
                new Comments() { Id = 151, Text = "Un meci intens, bravo băieți!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 19, Comment_UsersId = 6 },
                new Comments() { Id = 152, Text = "Remiză muncită, continuați tot așa!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 19, Comment_UsersId = 18 },
                new Comments() { Id = 153, Text = "Paul și Alex, de urmărit pe viitor!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 19, Comment_UsersId = 14 },
                new Comments() { Id = 154, Text = "Frumos joc, să vină și victoriile!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 19, Comment_UsersId = 25 },
                new Comments() { Id = 155, Text = "Atmosferă bună, tineri talentați!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 19, Comment_UsersId = 3 },

                // NewsId: 20
                new Comments() { Id = 156, Text = "Ce meci! 4 goluri, respect!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 20, Comment_UsersId = 22 },
                new Comments() { Id = 157, Text = "Bravo FC Unirea, victorie clară!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 20, Comment_UsersId = 7 },
                new Comments() { Id = 158, Text = "Daniel Stan și Denis Ilie, super jucători!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 20, Comment_UsersId = 27 },
                new Comments() { Id = 159, Text = "Așa vrem să vă vedem în fiecare meci!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 20, Comment_UsersId = 11 },
                new Comments() { Id = 160, Text = "Felicitări băieți, spectacol total!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 20, Comment_UsersId = 29 },

                // NewsId: 21
                new Comments() { Id = 161, Text = "Excelent în Cupă, țineți-o tot așa!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 21, Comment_UsersId = 9 },
                new Comments() { Id = 162, Text = "Ionuț Rădulescu din nou decisiv!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 21, Comment_UsersId = 1 },
                new Comments() { Id = 163, Text = "Felicitări pentru calificare!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 21, Comment_UsersId = 13 },
                new Comments() { Id = 164, Text = "Apărare de fier, bravo Unirea!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 21, Comment_UsersId = 28 },
                new Comments() { Id = 165, Text = "Cupa e aproape, hai băieți!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 21, Comment_UsersId = 23 },

                // NewsId: 22
                new Comments() { Id = 166, Text = "Spectacol în Champions League!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 22, Comment_UsersId = 17 },
                new Comments() { Id = 167, Text = "Remiză bună cu o echipă puternică!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 22, Comment_UsersId = 24 },
                new Comments() { Id = 168, Text = "Alex Vasilescu și Denis Neagu, excepționali!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 22, Comment_UsersId = 12 },
                new Comments() { Id = 169, Text = "Bravo băieți, ați luptat până la capăt!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 22, Comment_UsersId = 30 },
                new Comments() { Id = 170, Text = "Vrem să vă vedem în optimi!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 22, Comment_UsersId = 20 },

                // NewsId: 23
                new Comments() { Id = 171, Text = "Victorie importantă pentru moral!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 23, Comment_UsersId = 5 },
                new Comments() { Id = 172, Text = "Denis Chiriac și Ștefan Popescu, bravo!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 23, Comment_UsersId = 19 },
                new Comments() { Id = 173, Text = "Încă trei puncte, să urcăm în clasament!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 23, Comment_UsersId = 31 },
                new Comments() { Id = 174, Text = "Echipa joacă din ce în ce mai bine!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 23, Comment_UsersId = 8 },
                new Comments() { Id = 175, Text = "Să vină următoarea victorie!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 23, Comment_UsersId = 26 },

                // NewsId: 24
                new Comments() { Id = 176, Text = "Nu renunțăm, încă avem șanse!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 24, Comment_UsersId = 12 },
                new Comments() { Id = 177, Text = "Juventus a fost prea puternică azi.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 24, Comment_UsersId = 25 },
                new Comments() { Id = 178, Text = "Hai Unirea, capul sus!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 24, Comment_UsersId = 19 },
                new Comments() { Id = 179, Text = "Așteptăm revanșa pe teren propriu!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 24, Comment_UsersId = 4 },
                new Comments() { Id = 180, Text = "Credem în voi până la final!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 24, Comment_UsersId = 7 },

                // NewsId: 25
                new Comments() { Id = 181, Text = "Trei puncte muncite, felicitări!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 25, Comment_UsersId = 10 },
                new Comments() { Id = 182, Text = "Andrei Neagu, eroul nostru!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 25, Comment_UsersId = 20 },
                new Comments() { Id = 183, Text = "Bravo băieți, continuăm seria bună!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 25, Comment_UsersId = 29 },
                new Comments() { Id = 184, Text = "Forța Unirea, urcăm în clasament!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 25, Comment_UsersId = 5 },
                new Comments() { Id = 185, Text = "Victorie importantă pentru moral!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 25, Comment_UsersId = 16 },

                // NewsId: 26
                new Comments() { Id = 186, Text = "Super meci, emoții până la final!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 26, Comment_UsersId = 28 },
                new Comments() { Id = 187, Text = "Bravo, Unirea Youth!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 26, Comment_UsersId = 23 },
                new Comments() { Id = 188, Text = "Alin și Ionuț, de viitor!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 26, Comment_UsersId = 2 },
                new Comments() { Id = 189, Text = "Remiză echitabilă, ambele echipe au luptat!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 26, Comment_UsersId = 31 },
                new Comments() { Id = 190, Text = "Hai Unirea, la mai multe goluri!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 26, Comment_UsersId = 18 },

                // NewsId: 27
                new Comments() { Id = 191, Text = "Victorie clară, felicitări U21!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 27, Comment_UsersId = 1 },
                new Comments() { Id = 192, Text = "Sergiu Neagu și Radulescu, super goluri!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 27, Comment_UsersId = 8 },
                new Comments() { Id = 193, Text = "Meci foarte bun în deplasare!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 27, Comment_UsersId = 27 },
                new Comments() { Id = 194, Text = "Felicitări tuturor pentru efort!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 27, Comment_UsersId = 14 },
                new Comments() { Id = 195, Text = "Forța Unirea U21!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 27, Comment_UsersId = 21 },

                // NewsId: 28
                new Comments() { Id = 196, Text = "Capul sus, băieți! Vor veni și victoriile!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 28, Comment_UsersId = 6 },
                new Comments() { Id = 197, Text = "U21 Voluntari a fost mai bună azi.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 28, Comment_UsersId = 15 },
                new Comments() { Id = 198, Text = "Ne revenim la următorul meci!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 28, Comment_UsersId = 17 },
                new Comments() { Id = 199, Text = "Hai Unirea U21!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 28, Comment_UsersId = 9 },
                new Comments() { Id = 200, Text = "Nu renunțăm, suntem alături de voi!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 28, Comment_UsersId = 13 },

                // NewsId: 29
                new Comments() { Id = 201, Text = "Băieții au luptat frumos!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 29, Comment_UsersId = 2 },
                new Comments() { Id = 202, Text = "Eduard Diaconu a făcut un meci bun!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 29, Comment_UsersId = 17 },
                new Comments() { Id = 203, Text = "Meci greu, capul sus!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 29, Comment_UsersId = 25 },
                new Comments() { Id = 204, Text = "Felicitări pentru atitudine, mergem mai departe!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 29, Comment_UsersId = 8 },
                new Comments() { Id = 205, Text = "Nu renunțăm, Unirea U21!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 29, Comment_UsersId = 30 },

                // NewsId: 30
                new Comments() { Id = 206, Text = "A fost greu la Vaslui, dar avem potențial!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 30, Comment_UsersId = 4 },
                new Comments() { Id = 207, Text = "Bravo Ionuț Neagu pentru gol!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 30, Comment_UsersId = 14 },
                new Comments() { Id = 208, Text = "Hai Unirea Youth, revenim la următorul meci!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 30, Comment_UsersId = 29 },
                new Comments() { Id = 209, Text = "Tinerii merită încurajați mereu!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 30, Comment_UsersId = 10 },
                new Comments() { Id = 210, Text = "Capul sus, se poate mai bine!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 30, Comment_UsersId = 19 },

                // NewsId: 31
                new Comments() { Id = 211, Text = "Meci bun, păcat de rezultat!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 31, Comment_UsersId = 22 },
                new Comments() { Id = 212, Text = "Alex Lazăr a arătat calitate!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 31, Comment_UsersId = 6 },
                new Comments() { Id = 213, Text = "Rapid Nord ne-a surprins azi.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 31, Comment_UsersId = 24 },
                new Comments() { Id = 214, Text = "Nu e nimic, continuăm lupta!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 31, Comment_UsersId = 13 },
                new Comments() { Id = 215, Text = "Hai Unirea, credem în voi!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 31, Comment_UsersId = 28 },

                // NewsId: 32
                new Comments() { Id = 216, Text = "Meci echilibrat, portar bun!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 32, Comment_UsersId = 18 },
                new Comments() { Id = 217, Text = "0-0, dar echipa a jucat bine.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 32, Comment_UsersId = 21 },
                new Comments() { Id = 218, Text = "Felicitări pentru efort!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 32, Comment_UsersId = 7 },
                new Comments() { Id = 219, Text = "Ne vedem la următorul meci!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 32, Comment_UsersId = 26 },
                new Comments() { Id = 220, Text = "Un punct e mai bun decât nimic!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 32, Comment_UsersId = 15 },

                // NewsId: 33
                new Comments() { Id = 221, Text = "Tinerii s-au ținut bine!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 33, Comment_UsersId = 11 },
                new Comments() { Id = 222, Text = "Meci echilibrat, ghinion la final.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 33, Comment_UsersId = 5 },
                new Comments() { Id = 223, Text = "Felicitări pentru efort!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 33, Comment_UsersId = 27 },
                new Comments() { Id = 224, Text = "Hai Unirea Youth, mergem înainte!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 33, Comment_UsersId = 16 },
                new Comments() { Id = 225, Text = "Public frumos, mulțumim pentru susținere!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 33, Comment_UsersId = 12 },
                // NewsId: 34
                new Comments() { Id = 226, Text = "Victorie de moral, bravo băieți!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 34, Comment_UsersId = 7 },
                new Comments() { Id = 227, Text = "Andrei Neagu a făcut diferența din nou!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 34, Comment_UsersId = 11 },
                new Comments() { Id = 228, Text = "Super meci, trei puncte importante!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 34, Comment_UsersId = 21 },
                new Comments() { Id = 229, Text = "Forța Unirea în Europa!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 34, Comment_UsersId = 29 },
                new Comments() { Id = 230, Text = "Felicitări întregii echipe pentru efort!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 34, Comment_UsersId = 4 },

                // NewsId: 35
                new Comments() { Id = 231, Text = "Ce spectacol! Felicitări băieților!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 35, Comment_UsersId = 16 },
                new Comments() { Id = 232, Text = "Patru goluri, apărare perfectă!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 35, Comment_UsersId = 12 },
                new Comments() { Id = 233, Text = "Vrem trofeul în acest an!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 35, Comment_UsersId = 26 },
                new Comments() { Id = 234, Text = "Alex Lazăr și George Ilie, de nota 10!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 35, Comment_UsersId = 18 },
                new Comments() { Id = 235, Text = "Felicitări și staff-ului tehnic!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 35, Comment_UsersId = 24 },

                // NewsId: 36
                new Comments() { Id = 236, Text = "Meci echilibrat, am fi meritat victoria.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 36, Comment_UsersId = 5 },
                new Comments() { Id = 237, Text = "Bravo Denis Chiriac pentru gol!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 36, Comment_UsersId = 27 },
                new Comments() { Id = 238, Text = "Hai Unirea, luptați până la final!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 36, Comment_UsersId = 1 },
                new Comments() { Id = 239, Text = "Un punct câștigat, mergem înainte!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 36, Comment_UsersId = 22 },
                new Comments() { Id = 240, Text = "Încă un pas spre play-off!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 36, Comment_UsersId = 31 },

                // NewsId: 37
                new Comments() { Id = 241, Text = "Capul sus, urmează alte meciuri!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 37, Comment_UsersId = 5 },
                new Comments() { Id = 242, Text = "CSM Cluj a fost în formă azi.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 37, Comment_UsersId = 19 },
                new Comments() { Id = 243, Text = "Hai Unirea, revenim cu victorie!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 37, Comment_UsersId = 8 },
                new Comments() { Id = 244, Text = "Trebuie să strângem rândurile!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 37, Comment_UsersId = 25 },
                new Comments() { Id = 245, Text = "Ne vedem la următorul meci!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 37, Comment_UsersId = 13 },

                // NewsId: 38
                new Comments() { Id = 246, Text = "Remiză bună în deplasare!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 38, Comment_UsersId = 27 },
                new Comments() { Id = 247, Text = "Denis Cojocaru, felicitări pentru gol!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 38, Comment_UsersId = 1 },
                new Comments() { Id = 248, Text = "Un punct câștigat, urcăm în clasament!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 38, Comment_UsersId = 6 },
                new Comments() { Id = 249, Text = "Bravo băieți, continuăm seria bună!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 38, Comment_UsersId = 15 },
                new Comments() { Id = 250, Text = "Hai Unirea U21!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 38, Comment_UsersId = 30 },

                // NewsId: 39
                new Comments() { Id = 251, Text = "Ionuț Diaconu a fost în mare formă!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 39, Comment_UsersId = 2 },
                new Comments() { Id = 252, Text = "Un egal meritat pentru ambele echipe!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 39, Comment_UsersId = 23 },
                new Comments() { Id = 253, Text = "Bravo Unirea Youth!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 39, Comment_UsersId = 14 },
                new Comments() { Id = 254, Text = "Felicitări pentru rezultat!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 39, Comment_UsersId = 12 },
                new Comments() { Id = 255, Text = "Continuăm cu aceeași atitudine!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 39, Comment_UsersId = 28 },

                // NewsId: 40
                new Comments() { Id = 256, Text = "Remiză bună în deplasare!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 40, Comment_UsersId = 16 },
                new Comments() { Id = 257, Text = "Apărarea a funcționat perfect azi!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 40, Comment_UsersId = 22 },
                new Comments() { Id = 258, Text = "Hai Unirea, se poate mai mult!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 40, Comment_UsersId = 3 },
                new Comments() { Id = 259, Text = "Meci bun, fără goluri.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 40, Comment_UsersId = 10 },
                new Comments() { Id = 260, Text = "Continuăm drumul spre trofeu!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 40, Comment_UsersId = 18 },

                // NewsId: 41
                new Comments() { Id = 261, Text = "Egal echitabil, bun pentru moral!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 41, Comment_UsersId = 4 },
                new Comments() { Id = 262, Text = "Alex Vasilescu, gol frumos!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 41, Comment_UsersId = 29 },
                new Comments() { Id = 263, Text = "Universitatea Brașov a jucat bine!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 41, Comment_UsersId = 9 },
                new Comments() { Id = 264, Text = "Hai Unirea, urmează victoriile!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 41, Comment_UsersId = 26 },
                new Comments() { Id = 265, Text = "Felicitări băieților pentru efort!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 41, Comment_UsersId = 20 },

                // NewsId: 42
                new Comments() { Id = 266, Text = "U21 UTA a fost mai bună azi.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 42, Comment_UsersId = 7 },
                new Comments() { Id = 267, Text = "Băieții au dat totul pe teren!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 42, Comment_UsersId = 31 },
                new Comments() { Id = 268, Text = "Capul sus, Unirea U21!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 42, Comment_UsersId = 21 },
                new Comments() { Id = 269, Text = "Ne revanșăm la următorul meci!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 42, Comment_UsersId = 17 },
                new Comments() { Id = 270, Text = "Hai Unirea U21, suntem cu voi!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 42, Comment_UsersId = 27 },

                // NewsId: 43
                new Comments() { Id = 271, Text = "Băieții au muncit, păcat de rezultat.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 43, Comment_UsersId = 24 },
                new Comments() { Id = 272, Text = "Youth Baia Mare a fost pragmatică.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 43, Comment_UsersId = 11 },
                new Comments() { Id = 273, Text = "Hai Unirea Youth, revenim la victorie!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 43, Comment_UsersId = 2 },
                new Comments() { Id = 274, Text = "Atmosferă frumoasă la stadion!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 43, Comment_UsersId = 23 },
                new Comments() { Id = 275, Text = "Tinerii au nevoie de susținere!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 43, Comment_UsersId = 14 },
                // NewsId: 44
                new Comments() { Id = 276, Text = "Un punct muncit în deplasare!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 44, Comment_UsersId = 4 },
                new Comments() { Id = 277, Text = "Băieții au dat totul!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 44, Comment_UsersId = 15 },
                new Comments() { Id = 278, Text = "Bravo Unirea U21!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 44, Comment_UsersId = 23 },
                new Comments() { Id = 279, Text = "Felicitări pentru efort!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 44, Comment_UsersId = 29 },
                new Comments() { Id = 280, Text = "Hai Unirea U21 la următorul meci!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 44, Comment_UsersId = 2 },

                // NewsId: 45
                new Comments() { Id = 281, Text = "Super victorie la Oradea!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 45, Comment_UsersId = 1 },
                new Comments() { Id = 282, Text = "Felicitări Vlad Ionescu pentru gol!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 45, Comment_UsersId = 10 },
                new Comments() { Id = 283, Text = "Tinerii arată bine sezonul acesta!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 45, Comment_UsersId = 19 },
                new Comments() { Id = 284, Text = "Hai Unirea Youth, mergeți înainte!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 45, Comment_UsersId = 28 },
                new Comments() { Id = 285, Text = "Bravo tuturor pentru atitudine!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 45, Comment_UsersId = 7 },

                // NewsId: 46
                new Comments() { Id = 286, Text = "Victorie meritată la Constanța!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 46, Comment_UsersId = 13 },
                new Comments() { Id = 287, Text = "Denis Chiriac, Alex Vasilescu – super joc!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 46, Comment_UsersId = 6 },
                new Comments() { Id = 288, Text = "Felicitări echipei pentru efort!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 46, Comment_UsersId = 18 },
                new Comments() { Id = 289, Text = "Un meci cu multe emoții!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 46, Comment_UsersId = 24 },
                new Comments() { Id = 290, Text = "Hai Unirea, la cât mai multe victorii!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 46, Comment_UsersId = 12 },

                // NewsId: 47
                new Comments() { Id = 291, Text = "Un punct câștigat cu Buzău!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 47, Comment_UsersId = 27 },
                new Comments() { Id = 292, Text = "Portarii au fost la post!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 47, Comment_UsersId = 17 },
                new Comments() { Id = 293, Text = "Meci echilibrat, ne vedem la următorul!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 47, Comment_UsersId = 30 },
                new Comments() { Id = 294, Text = "Hai Unirea!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 47, Comment_UsersId = 21 },
                new Comments() { Id = 295, Text = "Capul sus, băieți!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 47, Comment_UsersId = 3 },

                // NewsId: 48
                new Comments() { Id = 296, Text = "Nu-i nimic, băieții au dat totul!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 48, Comment_UsersId = 8 },
                new Comments() { Id = 297, Text = "Felicitări Andrei Ionescu pentru gol!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 48, Comment_UsersId = 25 },
                new Comments() { Id = 298, Text = "Hai Unirea Youth, ne revenim la următorul!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 48, Comment_UsersId = 31 },
                new Comments() { Id = 299, Text = "Trebuie să avem încredere în tineri!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 48, Comment_UsersId = 14 },
                new Comments() { Id = 300, Text = "Atmosferă frumoasă pe stadion!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 48, Comment_UsersId = 22 },

                // NewsId: 49
                new Comments() { Id = 301, Text = "Victorie clară, felicitări U21!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 49, Comment_UsersId = 5 },
                new Comments() { Id = 302, Text = "Alin Voicu și Sergiu Neagu – decisivi!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 49, Comment_UsersId = 16 },
                new Comments() { Id = 303, Text = "Meci perfect, băieții au jucat bine!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 49, Comment_UsersId = 9 },
                new Comments() { Id = 304, Text = "Să continuăm tot așa!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 49, Comment_UsersId = 11 },
                new Comments() { Id = 305, Text = "Hai Unirea U21!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 49, Comment_UsersId = 26 },

                // NewsId: 50
                new Comments() { Id = 306, Text = "Meci greu la Paris, continuăm lupta!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 50, Comment_UsersId = 20 },
                new Comments() { Id = 307, Text = "Bravo Alin Neagu pentru gol!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 50, Comment_UsersId = 18 },
                new Comments() { Id = 308, Text = "Hai Unirea, credem în voi!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 50, Comment_UsersId = 24 },
                new Comments() { Id = 309, Text = "PSG e o echipă grea, felicitări pentru atitudine!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 50, Comment_UsersId = 29 },
                new Comments() { Id = 310, Text = "Așteptăm revanșa pe teren propriu!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 50, Comment_UsersId = 6 },

                // NewsId: 51
                new Comments() { Id = 311, Text = "Ce meci nebun! Bravo Unirea!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 51, Comment_UsersId = 17 },
                new Comments() { Id = 312, Text = "Calificare meritată, felicitări băieți!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 51, Comment_UsersId = 6 },
                new Comments() { Id = 313, Text = "Andrei Neagu, decisiv ca de obicei!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 51, Comment_UsersId = 12 },
                new Comments() { Id = 314, Text = "Trei goluri superbe!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 51, Comment_UsersId = 29 },
                new Comments() { Id = 315, Text = "Hai Unirea în semifinale!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 51, Comment_UsersId = 23 },

                // NewsId: 52
                new Comments() { Id = 316, Text = "Păcat de rezultat, dar mergem înainte!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 52, Comment_UsersId = 2 },
                new Comments() { Id = 317, Text = "CS Mioveni a profitat de ocazii.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 52, Comment_UsersId = 26 },
                new Comments() { Id = 318, Text = "Hai Unirea, ne revenim!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 52, Comment_UsersId = 5 },
                new Comments() { Id = 319, Text = "Capul sus, băieți!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 52, Comment_UsersId = 19 },
                new Comments() { Id = 320, Text = "Ne vedem pe stadion la următorul meci.", CreatedAt = DateTime.UtcNow, Comment_NewsId = 52, Comment_UsersId = 21 },
                // NewsId: 53
                new Comments() { Id = 321, Text = "Victorie muncită, bravo Youth!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 53, Comment_UsersId = 15 },
                new Comments() { Id = 322, Text = "Felicitări pentru cele 3 puncte!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 53, Comment_UsersId = 4 },
                new Comments() { Id = 323, Text = "Tinerii promit mult!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 53, Comment_UsersId = 13 },
                new Comments() { Id = 324, Text = "Hai Unirea Youth!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 53, Comment_UsersId = 24 },
                new Comments() { Id = 325, Text = "Atmosferă frumoasă la Arad!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 53, Comment_UsersId = 31 },

                // NewsId: 54
                new Comments() { Id = 326, Text = "Victorie clară pentru U21, felicitări!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 54, Comment_UsersId = 27 },
                new Comments() { Id = 327, Text = "Meci foarte bun al băieților!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 54, Comment_UsersId = 8 },
                new Comments() { Id = 328, Text = "Hai Unirea U21, susținem echipa!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 54, Comment_UsersId = 11 },
                new Comments() { Id = 329, Text = "Trei puncte uriașe în deplasare!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 54, Comment_UsersId = 3 },
                new Comments() { Id = 330, Text = "Continuăm seria bună!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 54, Comment_UsersId = 28 },

                // NewsId: 55
                new Comments() { Id = 331, Text = "Remiză utilă în grupele Champions League!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 55, Comment_UsersId = 1 },
                new Comments() { Id = 332, Text = "Felicitări Sergiu Chiriac pentru gol!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 55, Comment_UsersId = 25 },
                new Comments() { Id = 333, Text = "Olympiakos, adversar puternic!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 55, Comment_UsersId = 18 },
                new Comments() { Id = 334, Text = "Hai Unirea, credem în calificare!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 55, Comment_UsersId = 10 },
                new Comments() { Id = 335, Text = "Un punct important, felicitări!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 55, Comment_UsersId = 14 },

                // NewsId: 56
                new Comments() { Id = 336, Text = "Felicitări pentru calificare!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 56, Comment_UsersId = 7 },
                new Comments() { Id = 337, Text = "Trei goluri și fără gol primit!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 56, Comment_UsersId = 16 },
                new Comments() { Id = 338, Text = "Denis Ilie din nou decisiv!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 56, Comment_UsersId = 9 },
                new Comments() { Id = 339, Text = "Bravo echipei, se simte progresul!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 56, Comment_UsersId = 22 },
                new Comments() { Id = 340, Text = "Hai Unirea spre trofeu!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 56, Comment_UsersId = 20 }


            });
        }
    }
}
