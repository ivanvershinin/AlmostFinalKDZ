using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZVERSH
{
    [Serializable]
    public class Chest
    {
        int amount;
public int Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        string name;
       public Dictionary<string,Game> Games = new Dictionary<string, Game>();
        public Chest(string Name, int amount)
        {
            Amount = amount;
            this.Name = Name; 
        }
    }
    
}
