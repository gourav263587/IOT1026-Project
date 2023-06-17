namespace MinotaurLabyrinth
{
    /// <summary>
    /// Represents a snake chamber, which contains a snake :( .
    /// </summary>

    public class CustomRoom : Room
    {
        static CustomRoom()
        {
            RoomFactory.Instance.Register(RoomType.CustomRoom, () => new CustomRoom());
        }

        public override RoomType Type { get; } = RoomType.CustomRoom;

        public override bool IsActive { get; protected set; } = true;

        public override void Activate(Hero hero, Map map)
        {
               if (IsActive)
            {
                ConsoleHelper.WriteLine("You walk into the room and you find a mstery box inside it!", ConsoleColor.Red);
                
                double chanceOfSuccess = hero.HasSword ? 0.25 : 0.75;

                if (hero.HasSword)
                {
                    ConsoleHelper.WriteLine("you open it and deadly gas attacks you.", ConsoleColor.DarkMagenta);
                    hero.HasSword = true;
                }
                

                if (RandomNumberGenerator.NextDouble() < chanceOfSuccess)
                {
                    IsActive = false;
                    ConsoleHelper.WriteLine("you manage to close it.", ConsoleColor.Green);
                    ConsoleHelper.WriteLine("Looking around, This room is now safe.", ConsoleColor.Green);
                }
                else
                {
                    ConsoleHelper.WriteLine("you are too late to close it and die :(.", ConsoleColor.DarkRed);
                    hero.Kill("You have fallen and died.");
                }
            }
        }

        public override DisplayDetails Display()
        {
            return IsActive ? new DisplayDetails($"[{Type.ToString()[0]}]", ConsoleColor.Red)
                            : base.Display();
        }

        public override bool DisplaySense(Hero hero, int heroDistance)
        {
            if (!IsActive)
            {
                if (base.DisplaySense(hero, heroDistance))
                {
                    return true;
                }
                if (heroDistance == 0)
                {
                    ConsoleHelper.WriteLine("You shudder as you recall your near death experience with the now defunct gas of the mystery box in this room.", ConsoleColor.DarkGray);
                    return true;
                }
            }
            else if (heroDistance == 1 || heroDistance == 2)
            {
                ConsoleHelper.WriteLine(heroDistance == 1 ? "You feel a draft. There is a mysterybox in a nearby room!" : "Your intuition are ambigious", ConsoleColor.DarkGray);
                return true;
            }
            return false;
        }
    }
}



