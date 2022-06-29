using System;
using static System.Console;

namespace BuilderCS
{
    public interface IWorker
    {
        void GetName();
    }

    public interface IPart
    {
        void Build();
    }

    class Team
    {
        public Worker[] worker = new Worker[5];
        public String result = "";

        public void OutWorkers()
        {
            foreach (var item in worker)
            {
                WriteLine(item.ToString());
            }
        }

        public void Write()
        {
            for (int i = 0; i < 5; i++)
            {
                if(worker[i].house.houses != "") WriteLine($"Worker №{i + 1} build {worker[i].house.houses}");
            }
            if (worker[4].house.houses != "") result += worker[0].house.houses + worker[1].house.houses + worker[2].house.houses + worker[3].house.houses + worker[4].house.houses;
        }
    }

    class Worker : IWorker
    {
        String name;
        int age;
        public House house = new House();
        
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public void GetName()
        {
            WriteLine($"Name: {name}\nAge: {age}");
        }

        public override string ToString()
        {
            return $"Name: {name}\nAge: {age}";
        }

        public Worker this[int index]
        {
            get
            {
                return this[index];
            }
        }
    }

    class TeamLeader : IWorker
    {
        String name;
        int age;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public void GetName()
        {
            WriteLine($"Name: {name}\nAge: {age}");
        }

        public void WriteReport(Team team)
        {
            WriteLine("REPORT");
            team.Write();
        }
    }

    class House
    {
        public String houses = "";

        public void Add(String line)
        {
            houses += line + " ";
        }

        public override string ToString()
        {
            return houses;
        }

        public void BuildBasement()
        {
            Basement basement = new Basement();
            basement.Build();
            this.Add("1 basement");
        }

        public void BuildWall(int num = 1)
        {
            Walls wall = new Walls();
            wall.Build();
            this.Add(num + " wall");
        }

        public void BuildDoor(int num = 1)
        {
            Door door = new Door();
            door.Build();
            this.Add(num + " door");
        }

        public void BuildWindow(int num = 1)
        {
            Window window = new Window();
            window.Build();
            this.Add(num + " window");
        }

        public void BuildRoof()
        {
            Roof roof = new Roof();
            roof.Build();
            this.Add("1 roof");
        }
    }

    class Basement : House, IPart
    {
        public void Build()
        {
            WriteLine("Building basement...");
        }
    }

    class Walls : House, IPart
    {
        public void Build()
        {
            WriteLine("Building walls...");
        }
    }

    class Door : House, IPart
    {
        public void Build()
        {
            WriteLine("Building door...");
        }
    }

    class Window : House, IPart
    {
        public void Build()
        {
            WriteLine("Building window...");
        }
    }

    class Roof : House, IPart
    {
        public void Build()
        {
            WriteLine("Building roof...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Team team = new Team();
            team.worker[0] = new Worker { Age = 22, Name = "Bob" };
            team.worker[1] = new Worker { Name = "Jhon", Age = 33 };
            team.worker[2] = new Worker { Name = "Max", Age = 26 };
            team.worker[3] = new Worker { Name = "Leni", Age = 23 };
            team.worker[4] = new Worker { Name = "Sam", Age = 30 };
            team.OutWorkers();
            team.worker[0].house.BuildBasement();

            TeamLeader teamLeader = new TeamLeader() { Name = "Raf", Age = 33 };
            teamLeader.GetName();
            teamLeader.WriteReport(team);

            team.worker[1].house.BuildWall(4);
            team.worker[2].house.BuildDoor(2);
            team.worker[3].house.BuildWindow(4);
            team.worker[4].house.BuildRoof();

            teamLeader.WriteReport(team);
            WriteLine($"Result: {team.result}");
        }
    }
}
