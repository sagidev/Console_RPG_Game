using Console_RPG_Game.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG_Game.Locations
{
    interface Location
    {
        string Name { get; set; }

        List<Weapon> Weapons { get; set; }
        List<Armor> Armors { get; set; }
        List<Entity> Enemies { get; set; }
    }
}
