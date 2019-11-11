using ConsoleWars.Dungeons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Content
{
    public static class DungeonInfo
    {
        public static string EarthHallsDungeon()
        {
            return "Not implemented";
        }

        public static string GoblinFieldInfo()
        {
            return "Not implemented";
        }

        public static string ChooseDungInfo()
        {
            string info = "Choose dungeon:\r\n1: Goblin Fields\r\n2: Orc Fort\r\n3: Troll Jungles\r\n4: Earth Halls" +
                "\r\n5: Gian Conyons\r\n6: Water Halls\r\n7: Fire Halls\r\n8: Molten Core";
            return info;
        }

        public static string DungeonMeetings(Dungeon dungeons)
        {

        }
    }
}
