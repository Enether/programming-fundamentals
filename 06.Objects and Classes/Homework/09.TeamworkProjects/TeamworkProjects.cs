using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.TeamworkProjects
{
    class TeamworkProjects
    {
        static void Main()
        {
            /*
             DISCLAIMER: I know that this is not good performance wise and adding in hashsets holding team/creator names and
             etc optimization would be way faster than using LINQ on each check. Intentionally doing it like this because 
             */
            int teamCount = int.Parse(Console.ReadLine());

            // create teams
            List<Team> teams = new List<Team>();
            for (int i = 0; i < teamCount; i++)
            {
                string[] info = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string user = info[0];
                string team = info[1];

                
                if (teams.Select(x => x.Name).Contains(team))  // trying to create an existing team again
                {
                    Console.WriteLine($"Team {team} was already created!");
                    continue;
                }
                if (teams.Select(x => x.Creator).Contains(user))  // creator trying to create another team
                {
                    Console.WriteLine($"{user} cannot create another team!");
                    continue;
                }
                Console.WriteLine($"Team {team} has been created by {user}!");
                teams.Add(new Team(user, team));
            }

            // users join teams
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end of assignment")
                    break;

                string[] joinInfo = command.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                string user = joinInfo[0];
                string team = joinInfo[1];
                // TODO: ORDER OF PRINTS
                if (!teams.Select(x => x.Name).Contains(team))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                    continue;
                }
                if (teams.Select(x => x.Members.Contains(user)).Contains(true) ||
                    teams.Select(x => x.Creator).Contains(user))  // the user is in another team
                {
                    Console.WriteLine($"Member {user} cannot join team {team}!");
                    continue;
                }
                

                foreach (var item in teams)
                {
                    if (item.Name == team)
                        item.AddMember(user);
                }
            }

            // remove empty teams
            var emptyTeams = teams.Where(x => x.Members.Count == 0).Select(team => team).OrderBy(team => team.Creator).ToList();
            foreach (var emptyTeam in emptyTeams)
            {
                teams.RemoveAll(team => team.Name == emptyTeam.Name);
            }

            // print results
            var orderedValidTeams = teams.OrderByDescending(team => team.Members.Count).ThenBy(team => team.Name);
            foreach (Team team in orderedValidTeams)
            {
                Console.WriteLine(team.Name);
                Console.WriteLine($"- {team.Creator}");
                // print members sorted
                team.Members = team.Members.OrderBy(x => x).ToList();

                foreach (var teamMember in team.Members)
                {
                    Console.WriteLine($"-- {teamMember}");
                }
            }

            // print disbanded teams
            Console.WriteLine("Teams to disband:");
           // var emt = emptyTeams.OrderBy(x => x.Name)
            foreach (var team in emptyTeams)
            {
                Console.WriteLine(team.Name);
            }
        
        }
    }

    class Team
    {
        public string Name { get; }
        public string Creator { get; }
        public List<string> Members { get; set; }

        public Team(string creator, string teamName)
        {
            this.Creator = creator;
            this.Members = new List<string>();
            this.Name = teamName;
        }

        public void AddMember(string member)
        {   
            Members.Add(member);
        }
    }
}
