using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Developer
    {
       public Developer(){}
       public Developer(string firstName, string lastName, bool hasPluralSightAccess)
       {
           FirstName=firstName;
           LastName=lastName;
           HasPluralSightAccess=hasPluralSightAccess;
       }
       public string FirstName { get; set; }//null
       public string  LastName { get; set; }
       public int ID {get; set;}
       public bool HasPluralSightAccess {get; set;}

    }