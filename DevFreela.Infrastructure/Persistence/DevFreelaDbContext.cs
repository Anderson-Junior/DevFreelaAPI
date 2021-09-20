using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto ASP.NET CORE 1", "Descrição", 1, 1, 10000),
                new Project("Meu projeto ASP.NET CORE 2", "Descrição", 1, 1, 10000),
                new Project("Meu projeto ASP.NET CORE 3", "Descrição", 1, 1, 10000)
            };

            Users = new List<User>
            {
                new User("Anderson", "anderson@gmail.com", new DateTime(2001, 6, 2)),
                new User("Junior", "junior@gmail.com", new DateTime(2000, 2, 3)),
                new User("Pedro", "pedro@gmail.com", new DateTime(2002, 8, 9))
            };

            Skills = new List<Skill>
            {
                new Skill("C#"),
                new Skill("ASP.NET CORE"),
                new Skill("SQLSERVER"),
            };
        }
    }
}
