public class Shell
{
    public int North;
    public int South;
    public int East;
    public int West;
    public string flavor;
    public bool current;
    public Room assignedRoom;
    public bool visited;
    public bool encountered;


    public Shell(int North, int South, int East, int West, string flavor, bool current, bool visited, bool encountered, Room assignedRoom)
    {
        this.North = North;
        this.South = South;
        this.East = East;
        this.West = West;
        this.flavor = flavor;
        this.current = current;
        this.assignedRoom = assignedRoom;
        this.visited = visited;
        this.encountered = encountered;
    }

    public static Shell[] StarterDungeonShell = new Shell[]
    {
        new Shell(0,0,0,0,"",false, false,false, Room.StarterGenericRoomList[0]),

        new Shell(2,0,0,0,"Entrance",true, true, true, Room.StarterGenericRoomList[0]),
        new Shell(4,1,3,0,"Room One",false,false,  false, Room.StarterGenericRoomList[0]),
        new Shell(7,0,0,2, "Room Two",false,false, false, Room.StarterStaticRoomList[1]),
        new Shell(0,2,0,5,"Room Three",false,false,false, Room.StarterGenericRoomList[0]),
        new Shell(6,0,4,0,"Room Four",false,false, false, Room.StarterGenericRoomList[0]),
        new Shell(0,5,9,0, "Room Five",false,false,false, Room.StarterGenericRoomList[0]),
        new Shell(8,3,0,0, "Room Six",false,false,false, Room.StarterGenericRoomList[0]),
        new Shell(0,7,0,9, "Room Seven",false,false,false, Room.StarterGenericRoomList[0]),
        new Shell(0,0,8,6, "Boss Room",false, false,false, Room.StarterStaticRoomList[0])
    };

    public static Shell[] CastleShell = new Shell[]
    {
        new Shell(0,0,0,0,"",false, false,false, Room.StarterGenericRoomList[0]),

        new Shell(2,0,0,0,      "1", true,  true,   true,  Room.CastleGenericRoomList[0]),
        new Shell(8,1,14,3,     "2", false, false,  false, Room.CastleGenericRoomList[0]),
        new Shell(0,4,2,0,      "3", false, false,  false, Room.CastleStaticRoomList[3]),
        new Shell(3,0,0,5,      "4", false, false,  false, Room.CastleGenericRoomList[0]),
        new Shell(6,0,4,7,      "5", false, false,  false, Room.CastleGenericRoomList[0]),
        new Shell(0,5,0,0,      "6", false, false,  false, Room.CastleGenericRoomList[0]),
        new Shell(0,0,5,0,      "7", false, false,  false, Room.CastleStaticRoomList[1]),
        new Shell(0,2,9,0,      "8", false, false,  false, Room.CastleStaticRoomList[4]),
        new Shell(10,0,0,8,     "9", false, false,  false, Room.CastleGenericRoomList[0]),
        new Shell(0,9,0,11,    "10", false, false,  false, Room.CastleGenericRoomList[0]),

        new Shell(0,0,10,0,    "12", false, false,  false, Room.CastleStaticRoomList[2]),
        new Shell(13,0,8,0,    "12", false, false,  false, Room.CastleGenericRoomList[0]),
        new Shell(0,12,0,0,    "13", false, false,  false, Room.CastleGenericRoomList[0]),
        new Shell(0,0,15,2,    "14", false, false,  false, Room.CastleStaticRoomList[5]),
        new Shell(19,16,18,14, "15", false, false,  false, Room.CastleGenericRoomList[0]),
        new Shell(15,0,17,0,   "16", false, false,  false, Room.CastleGenericRoomList[0]),
        new Shell(18,0,0,16,   "17", false, false,  false, Room.CastleGenericRoomList[0]),
        new Shell(0,17,0,15,   "18", false, false,  false, Room.CastleGenericRoomList[0]),
        new Shell(0,15,20,0,   "19", false, false,  false, Room.CastleGenericRoomList[0]),
        new Shell(0,0,21,19,   "20", false, false,  false, Room.CastleGenericRoomList[0]),

        new Shell(0,22,0,20,   "21", false, false,  false, Room.CastleGenericRoomList[0]),
        new Shell(21,0,0,0,    "22", false, false,  false, Room.CastleStaticRoomList[0])
    };
}