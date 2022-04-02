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
                // Console.Clear();
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
        System.Console.WriteLine($"DeveloperID: {developer.ID}\n"+
        $"DeveloperName: {developer.FirstName} {developer.LastName}\n"+
        "-----------------------------------------\n");
        
    }

    private void VeiwAllDevelopers()
    {
        Console.Clear();
        List<Developer> developersInDB = _dRepo.GetAllDevelopers();
        
        if(developersInDB.Count > 0)
        {
            foreach(Developer developer in developersInDB)
        {
            DisplayDeveloperInfo(developer);
        }
        
        }
        else
        {
            System.Console.WriteLine("There aren't any developers inside of the database.");
        }
    PressAnyKeyToContinue();
    }

    private void AddDeveloperToDataBase()
    {
        Console.Clear();
        var newDeveloper = new Developer();
        System.Console.WriteLine("Enter a developer First Name");
        newDeveloper.FirstName = Console.ReadLine();
        System.Console.WriteLine("Enter a developer Last Name");
        newDeveloper.LastName = Console.ReadLine();

        bool isSuccesful = _dRepo.AddDeveloperToDataBase(newDeveloper);
        if(isSuccesful)
        {
            System.Console.WriteLine($"{newDeveloper.FirstName} - {newDeveloper.LastName} was added to the database.");
        }
        else{
            System.Console.WriteLine("failed to add developer to the database.");
        }

        PressAnyKeyToContinue();
    }


    private void VeiwDevTeamByID()
    {
        Console.Clear();
        
        var devTeams = _dtrepo.GetAllDevTeams();
        foreach(DevTeam devTeam in devTeams)
        {
           DisplayDevTeamData(devTeam);
        }
        try
        {
            System.Console.WriteLine("Please select a Team ID:");
            var userInputSelectedTeam = int.Parse(Console.ReadLine());
            var selectedTeam = _dtrepo.GetDevTeamByID(userInputSelectedTeam);
            if(selectedTeam != null)
            {
                DisplayTeamDetails(selectedTeam);
            }
            else{
                System.Console.WriteLine($"The selected team with the ID: {userInputSelectedTeam} does not exist");
            }
        }
        catch
        {
            System.Console.WriteLine("Sorry Invalid Selection");
        }
        PressAnyKeyToContinue();
    }

    private void DisplayTeamDetails(DevTeam selectedTeam)
    {
        Console.Clear();
        System.Console.WriteLine($"DevTeamID: {selectedTeam.ID}\n"+
        $"TeamName: {selectedTeam.TeamName}\n"+
        "--------------------------------------");
        System.Console.WriteLine("---Developers---");
        if(selectedTeam.Developers.Count >0)
        {
            foreach(var developer in selectedTeam.Developers)
        {
            DisplayDeveloperInfo(developer);
        }
        }
        else{
            System.Console.WriteLine("There are no developers");
        }

        PressAnyKeyToContinue();
    }

    private void ViewAllDevTeams()
    {
        Console.Clear();
        var devTeamsinDb = _dtrepo.GetAllDevTeams();
        foreach(var devTeam in devTeamsinDb)
        {
            DisplayDevTeamData(devTeam);
        }
        PressAnyKeyToContinue();
    }

    private void DisplayDevTeamData(DevTeam devTeam)
    {
        System.Console.WriteLine($"DevTeamID: {devTeam.ID}\n"+ 
        $"DevTeamTeamName: {devTeam.TeamName}\n"+ 
        "---------------------------------\n");
    }
    private void DeleteDevTeamData()
    {
        Console.Clear();
        
        var devTeams = _dtrepo.GetAllDevTeams();
        foreach(DevTeam devTeam in devTeams)
        {
           DisplayDevTeamData(devTeam);
        }
        try
        {
            System.Console.WriteLine("Please select a Team ID:");
            var userInputSelectedTeam = int.Parse(Console.ReadLine());
            bool isSuccesful = _dtrepo.RemoveDevTeamFromDatabase(userInputSelectedTeam);
            if(isSuccesful)
            {
                System.Console.WriteLine("Team was deleted");
            }
            else{
                System.Console.WriteLine("Team was not deleted");
            }
        }
        catch
        {
            System.Console.WriteLine("Sorry Invalid Selection");
        }
        PressAnyKeyToContinue();

    }

    private void AddDevTeamToDataBase()
    {
        Console.Clear();
        var newDevTeam = new DevTeam();
        
        var currentDeveloper = _dRepo.GetAllDevelopers();
        System.Console.WriteLine("Please enter a Team name");
        newDevTeam.TeamName=Console.ReadLine();

        bool hasAssignedDevelopers = false;
        while(!hasAssignedDevelopers)
        {
            System.Console.WriteLine("Do you have any developers? y/n");
            var userInputHasDevs = Console.ReadLine();

            if(userInputHasDevs == "Y".ToLower())
            {
                foreach(var developer in currentDeveloper)
                {
                    System.Console.WriteLine($"{developer.ID} {developer.FirstName} {developer.LastName}");
                }

                var userInputDeveloperSelection = int.Parse(Console.ReadLine());
                var selectedDeveloper = _dRepo.GetDeveloperByID(userInputDeveloperSelection);

                if(selectedDeveloper !=null)
                {
                    newDevTeam.Developers.Add(selectedDeveloper);
                    currentDeveloper.Remove(selectedDeveloper);
                }
                else{
                    System.Console.WriteLine($"Sorry, the developer with the ID: {userInputDeveloperSelection} doesnt exist.");
                }
            }else{
                hasAssignedDevelopers = true;
            }
        }
        bool isSuccesful = _dtrepo.AddDevTeamToDataBase(newDevTeam);
        if(isSuccesful){
            System.Console.WriteLine($"{newDevTeam.TeamName} was added to database");
        }
        else{
            System.Console.WriteLine($"{newDevTeam.TeamName} was not added to database");
        }
        PressAnyKeyToContinue();
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