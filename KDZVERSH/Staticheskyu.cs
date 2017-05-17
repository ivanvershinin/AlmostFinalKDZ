using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace KDZVERSH
{
   static public class Staticheskyu
    {
        static public List<Game> Vyvod = new List<Game>();
        static public List<Chest> Placeholders = new List<Chest>();
        static public Dictionary<string, Chest> Collection = new Dictionary<string, Chest>();
        static public Dictionary<string, string> dictionary = new Dictionary<string, string>();
        static bool f = true;
        static public void download()
        {
            
            FileStream fs = new FileStream("input.bin", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            if (f)
            {
                try
                {
                    Collection = (Dictionary<string, Chest>)bf.Deserialize(fs);
                    foreach (string t in Collection.Keys)
                    {
                        foreach (string v in Collection[t].Games.Keys)
                            dictionary.Add(v, t);

                    }
                  
                }
                catch { Collection = new Dictionary<string, Chest>(); dictionary = new Dictionary<string, string>(); f = false; }
            }  fs.Close();
            f = false;

        }
        static public void Save ()
        {
            FileStream fs = new FileStream("input.bin", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, Collection);
            fs.Close();
        }
    }
}
