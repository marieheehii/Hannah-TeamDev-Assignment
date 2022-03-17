using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Developer
    {
       public Developer(){}
       public Developer(string firstName, string lastName, bool hasPluralSightAccess)
       {
           firstName=FirstName;
           lastName=LastName;
           hasPluralSightAccess=HasPluralSightAccess;
       }
       public string FirstName { get; set; }
       public string  LastName { get; set; }
       public int ID {get; set;}
       public bool HasPluralSightAccess {get; set;}

    }