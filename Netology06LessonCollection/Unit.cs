using System;
using System.Collections.Generic;
using System.Text;

namespace Netology06LessonCollection
{
    internal class Unit
    {
        public string Name { get; set; }
        public Dictionary<int , string> Abilities = new Dictionary<int, string>()
        {
            {1, "Fireball"},
            {2, "Thunderbolt"},

        };

    }
}
