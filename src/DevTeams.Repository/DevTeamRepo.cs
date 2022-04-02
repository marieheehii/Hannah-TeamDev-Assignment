using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class DevTeamRepo
    {
        private readonly List<DevTeam> _devTeamsDatabase = new List<DevTeam>();

        private int _count=0;
        public bool AddDevTeamToDataBase(DevTeam devTeam)
        {
            if(devTeam !=null)
            {
                _count++;
                devTeam.ID= _count;
                _devTeamsDatabase.Add(devTeam);
                return true;
            }else{
                return false;
            }
        }
        public List<DevTeam> GetAllDevTeams()
        {
            return _devTeamsDatabase;
        }
        public DevTeam GetDevTeamByID(int id)
        {
            foreach(var devTeam in _devTeamsDatabase)
            {
                if(devTeam.ID == id)
                {
                    return devTeam;
                }
            }
            return null;
        }
        public bool RemoveDevTeamFromDatabase(int id)
        {
            var devTeam = GetDevTeamByID(id);
            if(devTeam != null)
            {
                _devTeamsDatabase.Remove(devTeam);
                return true;
            }else{
                return false;
            }

        }

    }
