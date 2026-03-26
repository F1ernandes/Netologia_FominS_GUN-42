using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using System.Drawing;
using GamePrototype.Utils;

namespace GamePrototype.Utils
{
    public abstract class DungeonBuilderBase
    {
        protected LevelSize mapSize;          

        protected abstract int GetRoomCount();
        protected abstract float GetEnemyRatio();

        protected DungeonBuilderBase(LevelSize map)  // конструктор
        {
            this.mapSize = map;
        }

        public virtual DungeonRoom BuildDungeon()
        {
            var enter = new DungeonRoom("Enter");
            

            DungeonRoom[] rooms = new DungeonRoom[GetRoomCount()];
            Random lootOrEnemy = new Random();

            for (uint roomNum=0; roomNum <  GetRoomCount(); roomNum++)
            {
                int roomType = lootOrEnemy.Next(100);
                if (roomNum == GetRoomCount()-1)
                {
                    rooms[roomNum] = new DungeonRoom("Finally Room");
                }
                else if (roomType <= 100 * GetEnemyRatio())
                {
                    string roomName = $"room{roomNum} with enemy";
                    rooms[roomNum] = new DungeonRoom(roomName, UnitFactoryDemo.CreateGoblinEnemy());
                }
                else if (roomType <= (100 * GetEnemyRatio() + 10))
                {
                    string roomName = $"room{roomNum} with empty";
                    rooms[roomNum] = new DungeonRoom(roomName);

                }
                else
                {
                    string roomName = $"room{roomNum} with loot";
                    rooms[roomNum] = new DungeonRoom(roomName, UnitFactoryDemo.GetRandomLot());
                }

            }
            for (uint roomNum = 0; roomNum < GetRoomCount(); roomNum++)
            {
                /* Не могу сходу придумать, как создать путь по подземелью, чтобы он:
                 * а) точно имел линейный выход - это сделаю начальной комнатой, которая будет 
                 * б) чтобы в комнате было одинаковое количество входов и выходов
                 * в) не будет ли тупиком эта комната - это сделал
                 * 
                 * поэтому делаю переход между комнатами по средствам телепорта
                 * можно пойти прямо, направо или вперёд - определяется подкидыванием монетки
                 */
                if (roomNum != GetRoomCount() - 1) // Из последней комнаты можно только выйти
                {
                    bool hasADirection = false;
                    if (FlipACoin()) { rooms[roomNum].TrySetDirection(Direction.Right, rooms[WhereToGo(roomNum)]); hasADirection = true; }
                    if (FlipACoin()) { rooms[roomNum].TrySetDirection(Direction.Forward, rooms[WhereToGo(roomNum)]); hasADirection = true; }
                    if (FlipACoin()) { rooms[roomNum].TrySetDirection(Direction.Left, rooms[WhereToGo(roomNum)]); hasADirection = true; }
                    if (!hasADirection) { rooms[roomNum].TrySetDirection(Direction.Forward, rooms[WhereToGo(roomNum)]); }
                }
            }
            enter.TrySetDirection(Direction.Left, rooms[0]);
            enter.TrySetDirection(Direction.Forward, rooms[1]);
            enter.TrySetDirection(Direction.Right, rooms[GetRoomCount() - 1]);

            return enter;
        }
        static public bool FlipACoin()
        {
            Random coin = new Random();
            if (coin.Next(2) == 0) 
            {
                return true; 
            }
            return false; 
        }
        public uint WhereToGo(uint roomFrom)
        {
            Random rooms = new Random();
            uint roomToGo = roomFrom;
            while (roomToGo == roomFrom) { roomToGo = (uint)rooms.Next(GetRoomCount()-1); }
            return roomToGo; 
        }
    }
}
