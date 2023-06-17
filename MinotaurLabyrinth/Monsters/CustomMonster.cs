namespace MinotaurLabyrinth
{
    public class CustomSecondMonster : Monster
    {
        
        
        public new bool IsAlive { get; set; } = true;


        public override void Activate(Hero hero, Map map)
        {
            const int RowMove = 1;
            const int ColMove = 2;
            ConsoleHelper.WriteLine("You have encountered the a  monster ambigious powers and ! He charges at you and knocks you into another room.", ConsoleColor.Magenta);
            if (hero.HasSword)
            {
                hero.HasSword = false;
                ConsoleHelper.WriteLine("After recovering your senses, you notice you are no longer in possession of the magic sword!", ConsoleColor.Magenta);
            }

            Location currentLocation = hero.Location;

            // Clamp the player to a new location
            hero.Location = Clamp(new Location(hero.Location.Row - RowMove, hero.Location.Column + ColMove), map.Rows, map.Columns);

            // Clamp the minotaur to a valid location starting at the maximum clamp distance and working inwards.
            // Will eventually get stuck in/near the bottom left corner of the map.
            for (int i = RowMove; i >= 0; --i)
            {
                for (int j = ColMove; j >= 0; --j)
                {
                    Location newLocation = Clamp(new Location(currentLocation.Row + i, currentLocation.Column - j), map.Rows, map.Columns);
                    Room room = map.GetRoomAtLocation(newLocation);
                    if (room.Type == RoomType.Room && !room.IsActive)
                    {
                        room.AddMonster(this);
                        map.GetRoomAtLocation(currentLocation).RemoveMonster();
                        return;
                    }
                }
            }
        }    
        
        private static Location Clamp(Location location, int totalRows, int totalColumns)
        {
            int row = location.Row;
            row = Math.Clamp(row, 0, totalRows - 1);
            int column = location.Column;
            column = Math.Clamp(column, 0, totalColumns - 1);

            return new Location(row, column);
        }

        public override bool DisplaySense(Hero hero, int heroDistance)
        {
            if (heroDistance == 1 || heroDistance==2)
            {
                ConsoleHelper.WriteLine("You hear strange noises and thumping!", ConsoleColor.Red);
                return true;
            }
            return false;
        }

        public int lifeline { get; set; }
        public int power{ get; set; }
        

       public override  DisplayDetails Display()
       {
            string text = "ambigious monster";
            ConsoleColor color = ConsoleColor.Red;
            

            DisplayDetails displayDetails = new DisplayDetails(text,color);
            
            return displayDetails;
       }





    }
}