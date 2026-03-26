using GamePrototype.Combat;
using GamePrototype.Dungeon;
using GamePrototype.Units;
using GamePrototype.Utils;

namespace GamePrototype.Game
{
    public sealed class GameLoop
    {
        private Unit _player;
        private DungeonRoom _dungeon;
        private readonly CombatManager _combatManager = new CombatManager();
        
        public void StartGame() 
        {
            Initialize();
            Console.WriteLine("Entering the dungeon");
            StartGameLoop();
        }

        #region Game Loop
        public static LevelSize getLevelSizeFromUser()
        {
            
            Console.WriteLine("Enter map size - S, M, L, XL, XXL");
            while (true)
            {
                var answer = Console.ReadLine();
                switch (answer?.ToLower())
                {
                    case "s": return LevelSize.S;
                    case "m": return LevelSize.M;
                    case "l": return LevelSize.L;
                    case "xl": return LevelSize.XL;
                    case "xxl": return LevelSize.XXL;
                    default: Console.WriteLine("You enter wrong value");break;

                }
                
            }
        }
        private void Initialize()
        {
            /*Console.WriteLine("Welcome, player!");
            _dungeon = DungeonBuilder.BuildDungeon();
            */
            //Тут будет интерфейс по выбору сложности игры и размера интерфейса
            bool notChoise = true;
            string level = "none";
            Console.WriteLine("Enter level difficulty - {H}ard or {E}asy");
            while (notChoise)
            { 
                var answer = Console.ReadLine();
                switch (answer?.ToLower())
                {
                    case "h":
                        level = "hard";
                        notChoise = false;
                        break;
                    case "e":
                        level = "easy";
                        notChoise = false;
                        break;
                    default:
                        Console.WriteLine("Ввели не допустимое значение"); break; 
    
                }
            }
            DungeonBuilderBase builder;

            if (level == "hard")
            { 
                builder = new HardDungeonBuilder(getLevelSizeFromUser());
            }
            else
            {
                builder = new EasyDungeonBuilder(getLevelSizeFromUser());
            }
            _dungeon = builder.BuildDungeon();

            Console.WriteLine("Enter your name");
            _player = UnitFactoryDemo.CreatePlayer(Console.ReadLine());
            Console.WriteLine($"Hello {_player.Name}");
        }

        private void StartGameLoop()
        {
            var currentRoom = _dungeon;
            
            while (currentRoom.IsFinal == false) 
            {
                StartRoomEncounter(currentRoom, out var success);
                if (!success) 
                {
                    Console.WriteLine("Game over!");
                    return;
                }
                DisplayRouteOptions(currentRoom);
                while (true) 
                {
                    string getUserCommand = Console.ReadLine();
                    if (Enum.TryParse<Direction>(getUserCommand, out var direction) ) 
                    {
                        currentRoom = currentRoom.Rooms[direction];
                        break;
                    }
                    else if((getUserCommand == "S") || (getUserCommand=="s"))
                    {
                        _player.ShowInventory();
                        Console.Write("\n\n");
                        DisplayRouteOptions(currentRoom);
                    }
                    else 
                    {
                        Console.WriteLine("Wrong direction!");
                        Console.Write("\n\n");
                        DisplayRouteOptions(currentRoom);

                    }
                }
            }
            Console.WriteLine($"Congratulations, {_player.Name}");
            Console.WriteLine("Result: ");
            Console.WriteLine(_player.ToString());
        }

        private void StartRoomEncounter(DungeonRoom currentRoom, out bool success)
        {
            success = true;
            if (currentRoom.Loot != null) 
            {
                Console.WriteLine("Ура! В этой комнате нашли: " + currentRoom.Loot.Name);
                _player.AddItemToInventory(currentRoom.Loot);
            }
            if (currentRoom.Enemy != null) 
            {
                Console.WriteLine("Ой! В этой комнате спрятался враг. Выйграй его в камень-ножницы-бумага, чтобы замочить его");
                if (_combatManager.StartCombat(_player, currentRoom.Enemy) == _player)
                {
                    _player.HandleCombatComplete();
                    LootEnemy(currentRoom.Enemy);
                }
                else 
                {
                    success = false;
                }
            }

            void LootEnemy(Unit enemy)
            {
                _player.AddItemsFromUnitToInventory(enemy);
            }
        }

        private void DisplayRouteOptions(DungeonRoom currentRoom)
        {
            Console.WriteLine("Where to go?");
            foreach (var room in currentRoom.Rooms)
            {
                Console.Write($"{room.Key} - {(int) room.Key}\t");
            }
            Console.WriteLine("{S}how your information?");
        }

        
        #endregion
    }
}
