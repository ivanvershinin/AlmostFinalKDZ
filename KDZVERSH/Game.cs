using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZVERSH
{
    [Serializable]
    public class Game
    {



        public string Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string Genre
        {
            get
            {
                return genre;
            }

            set
            {
                genre = value;
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

        string genre;
        string name;
        string _age;
        public Game(string name, string genre, string _age)
        {
            Name = name;
            Genre = genre;
            Age = _age;

        }
    }

}
