using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Program_UI
    {
        private readonly DeveloperRepo _dRepo = new DeveloperRepo();
        private readonly DevTeamRepo _dtrepo = new DevTeamRepo();

        public void Run()
        {
           SeedData();
           RunApplication();
            
        }
        private void RunApplication()
        {
            bool isRunning = true;
            while(isRunning)
            {
                Console.Clear();
                Console.Clear();
            System.Console.WriteLine("=== Welcome to Komodo Dev Teams! ===");
            System.Console.WriteLine("Make a Selection: \n"+
            "1.  Add Team to Database\n"+
            "2.  View All Teams\n"+
            "3.  View Teams By ID\n"+
            "4.  Update Team Data\n"+
            "5.  Delete Team Data\n"+
            "------------------------------------\n"+
            "=== Developer Database ===\n"+
            "6.  Add Developer To Database\n"+
            "7.  View All Developers\n"+
            "8.  View Developer By ID\n"+
            "--------------------------------------\n"+
            "50.  Close Application\n"
            );
             var userInput = Console.ReadLine();
             switch(userInput)
             {
                 case "1":
                 AddDevTeamToDataBase();
                 break;
                case "2":
                 ViewAllDevTeams();
                 break;
                case "3":
                 VeiwDevTeamByID();
                 break;
                 case "4":
                 UpdateDevTeamData();
                 break;
                 case "5":
                 DeleteDevTeamData();
                 break;
                 case "6":
                 AddDeveloperToDataBase();
                 break;
                 case "7":
                 VeiwAllDevelopers();
                 break;
                 case "8":
                 VeiwDeveloperByID();
                 break;
                 case "50":
                 isRunning = CloseApplication();
                 break;
                 default:
                 System.Console.WriteLine("Invalid Selection");
                 PressAnyKeyToContinue();
                 break;
             }

            }
        }

    private bool CloseApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Thank You!");
        PressAnyKeyToContinue();
        return false;
    }

    private void DeleteDevTeamData()
    {
        Console.Clear();
    }

    private void VeiwDeveloperByID()
    {
       Console.Clear();
        System.Console.WriteLine("Please Enter a Developer ID:");
        var userInputDeveloperID = int.Parse(Console.ReadLine());
        var developer = _dRepo.GetDeveloperByID(userInputDeveloperID);

        if(developer != null)
        {
            DisplayDeveloperInfo(developer);
        }
        else
        {
            System.Console.WriteLine($"The developer with the ID: {userInputDeveloperID} doesn't exist. ");
        }
        PressAnyKeyToContinue();
    }

    private void DisplayDeveloperInfo(Developer developer)
    {
        DisplayDeveloperData(developer);
    }

    private void VeiwAllDevelopers()
    {
        Console.Clear();
        var developers = _dRepo.GetAllDevelopers();
        foreach(var Developer in developers)
        {
            DisplayDeveloperData(Developer);
        }
        PressAnyKeyToContinue();
    }

    private void DisplayDeveloperData(Developer developer)
    {
        System.Console.WriteLine($"DeveloperID: {developer.ID}\n"+ 
        $"DeveloperName: {developer.FirstName}\n"+ 
        "---------------------------------\n");
    }

    private void AddDeveloperToDataBase()
    {
        Console.Clear();
        var newDeveloper = new Developer();
        System.Console.WriteLine("Enter a developer Name");
        newDeveloper.FirstName = Console.ReadLine();

        bool isSuccesful = _dRepo.AddDeveloperToDataBase(newDeveloper);
        if(isSuccesful)
        {
            System.Console.WriteLine($"{newDeveloper.FirstName} was added to the database.");
        }
        else{
            System.Console.WriteLine("failed to add developer to the database.");
        }

        PressAnyKeyToContinue();
    }

    private void UpdateDevTeamData()
    {
        throw new NotImplementedException();
    }

    private void VeiwDevTeamByID()
    {
        throw new NotImplementedException();
    }

    private void ViewAllDevTeams()
    {
        throw new NotImplementedException();
    }

    private void AddDevTeamToDataBase()
    {
        throw new NotImplementedException();
    }

    private void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void SeedData()
        {
            var Brontie = new Developer ("Brontie" ,"Wrong" ,false);
            var Imaani = new Developer ("Imaani" ,"Old" ,true);
            var Ethan = new Developer ("Ethan" ,"VanUnder" ,true);
            var Heather = new Developer ("Heather" ,"Blanketbreaker" ,true);
            var Magoo = new Developer ("Mr." ,"Magoo" ,true);

            _dRepo.AddDeveloperToDataBase(Brontie);
            _dRepo.AddDeveloperToDataBase(Imaani);
            _dRepo.AddDeveloperToDataBase(Ethan);
            _dRepo.AddDeveloperToDataBase(Heather);
            _dRepo.AddDeveloperToDataBase(Magoo);

            var theCoconuts = new DevTeam ("The Coconuts", new List<Developer>
            {
                Brontie,
                Heather,
            });
            var theMangoMen = new DevTeam ("The Mango Men", new List<Developer>
            {
                Imaani,
                Magoo,
                Ethan,
                Brontie
            });
            _dtrepo.AddDevTeamToDataBase(theCoconuts);
            _dtrepo.AddDevTeamToDataBase(theMangoMen);
        }


    }