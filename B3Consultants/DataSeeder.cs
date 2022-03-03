using B3Consultants.DB;
using B3Consultants.Entities;

namespace B3Consultants
{
    public class DataSeeder
    {
        private ConsultantDBContext _dBContext;
        public DataSeeder(ConsultantDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public void Seed()
        {
            if (_dBContext.Database.CanConnect())
            {
                if (!_dBContext.Experiences.Any())
                {
                    var experiences = SetExperiences();
                    _dBContext.Experiences.AddRange(experiences);
                    _dBContext.SaveChanges();
                }
                if (!_dBContext.Availabilities.Any())
                {
                    var availabilities = SetAvailabilities();
                    _dBContext.Availabilities.AddRange(availabilities);
                    _dBContext.SaveChanges();
                }
                if (!_dBContext.Roles.Any())
                {
                    var roles = SetRoles();
                    _dBContext.Roles.AddRange(roles);
                    _dBContext.SaveChanges();
                }

                if (!_dBContext.Consultants.Any())
                {
                    var consultants = SetConsultants();
                    _dBContext.Consultants.AddRange(consultants);
                    _dBContext.SaveChanges();
                }

                if (!_dBContext.UserRoles.Any())
                {
                    var roles = SetUserRoles();
                    _dBContext.UserRoles.AddRange(roles);
                    _dBContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Consultant> SetConsultants()
        {
            var consultants = new List<Consultant>()
            {
               new Consultant()
               {
                   FirstName = "Mateusz",
                   LastName = "Twarowski",
                   RoleId = 1,
                   ExperienceId = 1,
                   AvailabilityId = 1,
                   HourlyRatePlnNet = 100,
                   Location = "Warsaw",
                   Description = ".Net Developer with no commercial exeprience",
                   ProfileSource = "https://www.linkedin.com/in/mateusz-twarowski-82737517b/",

               },

               new Consultant()
               {
                   FirstName = "Karol",
                   LastName = "Adamczyk",
                   RoleId = 2,
                   ExperienceId = 5,
                   HourlyRatePlnNet = 150,
                   Location = "Remote",
                   AvailabilityId = 7,
                   Description = "Senior Java Developer",
                   ProfileSource = "https://www.google.com/search?q=Karolashimaru+Krawczykobono&oq=karol&aqs=chrome.0.69i59j69i57j35i39j69i60l5.461j0j7&sourceid=chrome&ie=UTF-8",
               }

            };
        return consultants;
        }

        private IEnumerable<Role> SetRoles()
        {
            var roles = new List<Role>()
            {
               new Role() 
               {
                   RoleTitle = ".NET Developer"
               },
               new Role()
               {
                   RoleTitle = "Java Developer"
               },
               new Role()
               {
                   RoleTitle = "PHP Developer"
               },
               new Role()
               {
                   RoleTitle = "Business Analyst"
               },
               new Role()
               {
                   RoleTitle = "Automation Tester"
               }

            };
            return roles;
        }
        private IEnumerable<Experience> SetExperiences()
        {
            var experiences = new List<Experience>()
            {
               new Experience()
               {
                   ExperienceLevel = "Junior"
               },
               new Experience()
               {
                   ExperienceLevel = "Junior+"
               },
               new Experience()
               {
                   ExperienceLevel = "Mid"
               },
               new Experience()
               {
                   ExperienceLevel = "Mid+"
               },
               new Experience()
               {
                   ExperienceLevel = "Senior"
               }

            };
            return experiences;
        }
        private IEnumerable<Availability> SetAvailabilities()
        {
            var availabilities = new List<Availability>()
            {
               new Availability()
               {
                   WhenAvailable = "ASAP"
               },
               new Availability()
               {
                   WhenAvailable = "7 days"
               },
               new Availability()
               {
                   WhenAvailable = "14 days"
               },
               new Availability()
               {
                   WhenAvailable = "30 days"
               },
               new Availability()
               {
                   WhenAvailable = "1 month"
               },
               new Availability()
               {
                   WhenAvailable = "2 months"
               },
               new Availability()
               {
                   WhenAvailable = "3 months"
               },
            };
            return availabilities;
        }

        /*private IEnumerable<User> SetUsers()
        {
            var users = new List<User>()
            {
                new User()
                {
                    FirstName = "Jan",
                    LastName = "Nowak",

                },
                new UserRole()
                {
                    UserRoleTitle = "Business Manager"
                },
                new UserRole()
                {
                    UserRoleTitle = "Admin"
                }
            };
            return roles;
        }*/

        private IEnumerable<UserRole> SetUserRoles()
        {
            var roles = new List<UserRole>()
            {
                new UserRole()
                {
                    UserRoleTitle = "User"
                },
                new UserRole()
                {
                    UserRoleTitle = "Business Manager"
                },
                new UserRole()
                {
                    UserRoleTitle = "Admin"
                }
            };
            return roles;
        }
    };
}
