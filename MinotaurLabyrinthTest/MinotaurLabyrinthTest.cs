using MinotaurLabyrinth;

namespace MinotaurLabyrinthTest
{
    [TestClass]
    public class CustomSecondMonsterTests
    {
        [TestMethod]
        public void Activate_Issword()
        {
            Location heroLocation = new Location(0, 0); 
            Hero hero = new Hero(heroLocation);
            hero.HasSword = true;
            Map map = new Map(7, 6);
            CustomSecondMonster customMonster = new CustomSecondMonster();
            customMonster.Activate(hero, map);
            Assert.IsFalse(hero.HasSword);
        }

        [TestMethod]
        public void Activate_Herolocation()
        {
            
            Location heroLocation = new Location(0, 0); 
            Hero hero = new Hero(heroLocation);;
            hero.Location = new Location(5, 5);
            Map map = new Map(10, 10);
            CustomSecondMonster customMonster = new CustomSecondMonster();
            customMonster.Activate(hero, map);
            Assert.AreNotEqual(new Location(5, 5), hero.Location);
            Assert.AreEqual(RoomType.Room, map.GetRoomAtLocation(hero.Location).Type);
        }

        [TestMethod]
        public void Display_displaystuff()
        {
            
            CustomSecondMonster customMonster = new CustomSecondMonster();
            DisplayDetails displayDetails = customMonster.Display();
            Assert.AreEqual("ambigious monster", displayDetails.Text);
            Assert.AreEqual(ConsoleColor.Red, displayDetails.Color);
        }

         [TestMethod]
        public void DisplaySense_HeroDistance()
        {
            Location heroLocation = new Location(0, 0); 
            Hero hero = new Hero(heroLocation);
            int heroDistance = 1;
            CustomSecondMonster customMonster = new CustomSecondMonster();
            bool result = customMonster.DisplaySense(hero, heroDistance);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DisplaySense_HeroDistanceIs1Or2_ReturnsTrue()
        {
            Location heroLocation = new Location(0, 0); 
            Hero hero = new Hero(heroLocation);
            var monster = new CustomSecondMonster();
            var var1 = monster.DisplaySense(hero, 1);
            var var2 = monster.DisplaySense(hero, 2);

            // Assert
            Assert.IsTrue(var1);
            Assert.IsTrue(var2);
        }


    }
}
