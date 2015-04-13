class GarrisonInfo
{
    private static Garrison fThisMe = null;
    private static ReBot.API.ReBotAPI fReBotAPI = null;
    private static ReBot.API.FactionGroup fFaction = ReBot.API.FactionGroup.ValueNotReadYet;
    private static int fLevel = -1;
    public static Garrison thisMe { get { return fThisMe; } set { fThisMe = value; } }
    public static ReBot.API.ReBotAPI API { get { return fReBotAPI; } set { fReBotAPI = value; } }
    public static ReBot.API.FactionGroup faction
    {
        get
        {
            ReBot.API.FactionGroup result = ReBot.API.FactionGroup.ValueNotReadYet;
            if (!object.ReferenceEquals(null, fReBotAPI))
            {
                result = fFaction;
                if (result.Equals(ReBot.API.FactionGroup.ValueNotReadYet))
                {
                    ReBot.API.LocalPlayer me = API.Me;
                    if (me.IsAlliance) { result = ReBot.API.FactionGroup.Alliance; }
                    else if (me.IsHorde) { result = ReBot.API.FactionGroup.Horde; }
                }
            }
            return result;
        }
    }
    public static int level
    {
        get
        {
            int result = -1;
            if (!object.ReferenceEquals(null, fReBotAPI))
            {
                result = fLevel;
                if (fLevel == -1)
                {
                    if (fReBotAPI.Me.IsAlliance)
                    {
                        if (fReBotAPI.IsQuestCompleted(36615)) { result = 3; }
                        else if (fReBotAPI.IsQuestCompleted(36592)) { result = 2; }
                    }
                    else if (fReBotAPI.Me.IsHorde)
                    {
                        if (fReBotAPI.IsQuestCompleted(36614)) { result = 3; }
                        else if (fReBotAPI.IsQuestCompleted(36567)) { result = 2; }
                    }
                }
            }
            return result;
        }
    }
}

class GarrisonRecon
{
    public static BuildingObject playerClosestBuilding
    {
        get 
        {
            BuildingObject result = BuildingObject.none;
            ReBot.API.GameObject x = null;
            float z = 9999f;
            foreach (ReBot.API.GameObject o in GarrisonInfo.API.GameObjects)
            {
                int e = o.EntryID;
                float d = o.Distance;
                if (o.GameObjectType.Equals(ReBot.API.WoWGameObjectType.GarrisonBuilding))
                {
                    if (d < z) { x = o; z = d; }
                }
            }
            if (!object.ReferenceEquals(null, x))
            {
                int e = x.EntryID;
                if ((e == 224800) || (e == 224801) || (e == 235990) || (e == 235991) || (e == 230415) || (e == 236448) || (e == 236449))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fFarm; //224801 & 235990 = V2 alliance
                } else if ((e == 225538) || (e == 225539) || (e == 225540) || (e == 230466) || (e == 230467) || (e == 230468))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fMine;
                }
                else if ((e == 227597) || (e == 230453) || (e == 227596) || (e == 230452) || (e == 227073) || (e == 230451))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fEnchanting;
                }
                else if ((e == 227603) || (e == 230462) || (e == 227602) || (e == 230461) || (e == 227075) || (e == 230460))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fJewelcrafting;
                }
                else if ((e == 230476) || (e == 230442) || (e == 230475) || (e == 230441) || (e == 224853) || (e == 230440))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fSalvageYard;
                }
                else if ((e == 234679) || (e == 230439) || (e == 234678) || (e == 230438) || (e == 224854) || (e == 230437))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fStorehouse;
                }
                else if ((e == 227591) || (e == 230445) || (e == 227590) || (e == 230444) || (e == 227179) || (e == 230443))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fAlchemy;
                }
                else if ((e == 227595) || (e == 230456) || (e == 227594) || (e == 230455) || (e == 227072) || (e == 230454))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fEngineering;
                }
                else if ((e == 227601) || (e == 230432) || (e == 227600) || (e == 230430) || (e == 227074) || (e == 230427))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fIncscription;
                }
                else if ((e == 227599) || (e == 230465) || (e == 227598) || (e == 230464) || (e == 227180) || (e == 230463))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fTailoring;
                }
                else if ((e == 227589) || (e == 230450) || (e == 227588) || (e == 230449) || (e == 225537) || (e == 230448))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fBlacksmith;
                }
                else if ((e == 227593) || (e == 230459) || (e == 227592) || (e == 230458) || (e == 227070) || (e == 230457))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fLeatherworking;
                }
                else if ((e == 225579) || (e == 230471) || (e == 225578) || (e == 230470) || (e == 225577) || (e == 230469))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fStable;
                }
                else if ((e == 224799) || (e == 230414) || (e == 224798) || (e == 230413) || (e == 224797) || (e == 230412))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fBarracks;
                }
                else if ((e == 224810) || (e == 230421) || (e == 224809) || (e == 230420) || (e == 224808) || (e == 230419))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fMageTower;
                }
                else if ((e == 230494) || (e == 230491) || (e == 230493) || (e == 230490) || (e == 230492) || (e == 230489))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fWorkshop;
                }
                else if ((e == 224550) || (e == 230409) || (e == 224549) || (e == 230407) || (e == 224548) || (e == 230406))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fArmory;
                }
                else if ((e == 233186) || (e == 233188) || (e == 224796) || (e == 230411) || (e == 224795) || (e == 230410))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fBarn;
                }
                else if ((e == 224807) || (e == 230418) || (e == 224806) || (e == 230417) || (e == 224805) || (e == 230416))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fInn;
                }
                else if ((e == 230487) || (e == 230479) || (e == 230486) || (e == 230478) || (e == 230480) || (e == 230477))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fArena;
                }
                else if ((e == 233267) || (e == 233266) || (e == 224812) || (e == 230423) || (e == 224811) || (e == 230422))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fMill;
                }
                else if ((e == 233189) || (e == 230474) || (e == 227674) || (e == 230473) || (e == 227673) || (e == 230472))
                {
                    result = (BuildingObject)GarrisonInfo.thisMe.fTradingPost;
                }
            }
            return result;
        }
    }
    public static bool playerIsInsideBuilding(BuildingObject building)
    {
            bool result = false;
            if ((GarrisonStatics.plotPositionStreet.ContainsKey(building.plotId)) && (GarrisonStatics.playerMiniMapZoneText.IndexOf(GarrisonInfo.API.Me.Name) < 0))
            {
                result = true;
            }
            return result;
    }
}

class BuildingObject
{
    private static BuildingObject fNone = new BuildingObject(-1, "", -1, -1);
    private int fPlotId = -1;
    private string fBuildingName = "";
    private System.Collections.Generic.List<int> fWorkerEntryIDs = new System.Collections.Generic.List<int>(new int[] { });
    private System.Collections.Generic.List<int> fShipmentEntryIDs = new System.Collections.Generic.List<int>(new int[] { });
    private int fOrderMatObjectID = -1;
    private int fOrderMatQuantity = 5;
    public Geometry.Vector3 PositionStreet
    {
        get
        {
            Geometry.Vector3 result = new Geometry.Vector3(0f, 0f, 0f);
            if (GarrisonStatics.plotPositionStreet.ContainsKey(fPlotId))
            {
                result = GarrisonStatics.plotPositionStreet[fPlotId];
            }
            return result;
        }
    }
    public Geometry.Vector3 PositionPorche
    {
        get
        {
            Geometry.Vector3 result = new Geometry.Vector3(0f, 0f, 0f);
            result = GarrisonStatics.plotPositionPorche[fPlotId];
            return result;
        }
    }
    public Geometry.Vector3 PositionInside
    {
        get
        {
            Geometry.Vector3 result = new Geometry.Vector3(0f, 0f, 0f);
            result = GarrisonStatics.plotPositionInside[fPlotId];
            return result;
        }
    }
    public Geometry.Vector3 PositionAlpha
    {
        get
        {
            Geometry.Vector3 result = new Geometry.Vector3(0f, 0f, 0f);
            return result;
        }
    }
    public BuildingObject(int plotId, string buildingName, int orderMatObjectID, int orderMatQuantity)
    {
        fPlotId = plotId;
        fBuildingName = buildingName;
        fOrderMatObjectID = orderMatObjectID;
        fOrderMatQuantity = orderMatQuantity;
    }
    public static BuildingObject none { get { return fNone; } }
    public string name { get { return fBuildingName; } }
    public int plotId { get { return fPlotId; } }
    public void MoveOut()
    {

    }
    public void MoveTo()
    {
        //move to closest safe point.
        BuildingObject cb = GarrisonRecon.playerClosestBuilding;
        if ((cb.name.Equals(fBuildingName)) && (GarrisonStatics.playerMiniMapZoneText.IndexOf(GarrisonInfo.API.Me.Name) < 0))
        {
            //already inside this building
        } else if (GarrisonRecon.playerIsInsideBuilding(cb))
        {
            //player is inside building named cb.name
            cb.MoveOut();
        }
    }
}

class Mine : BuildingObject
{
    public Mine()
        : base(59, "Mine", 0, 5)
    {

    }
}

class Farm : BuildingObject
{
    public Farm()
        : base(59, "Farm", 0, 5)
    {

    }
}

class SmallBuildingObject : BuildingObject
{
    public SmallBuildingObject(int plotId, string buildingName, int orderMatObjectID, int orderMatQuantity)
        : base(plotId, buildingName, orderMatObjectID, orderMatQuantity)
    {

    }
}

class MediumBuildingObject : BuildingObject
{
    public MediumBuildingObject(int plotId, string buildingName, int orderMatObjectID, int orderMatQuantity)
        : base(plotId, buildingName, orderMatObjectID, orderMatQuantity)
    {

    }
}

class LargeBuildingObject : BuildingObject
{
    public LargeBuildingObject(int plotId, string buildingName, int orderMatObjectID, int orderMatQuantity)
        : base(plotId, buildingName, orderMatObjectID, orderMatQuantity)
    {

    }
}

class Enchanting : SmallBuildingObject
{
    public Enchanting()
        : base(-1, "Enchanting", -1, 5)
    {
    }
}

class Jewelcrafting : SmallBuildingObject
{
    public Jewelcrafting()
        : base(-1, "Jewelcrafting", -1, 5)
    {
    }
}

class SalvageYard : SmallBuildingObject
{
    public SalvageYard()
        : base(-1, "SalvageYard", -1, 5)
    {
    }
}

class Storehouse : SmallBuildingObject
{
    public Storehouse()
        : base(-1, "Storehouse", -1, 5)
    {
    }
}

class Alchemy : SmallBuildingObject
{
    public Alchemy()
        : base(-1, "Alchemy", -1, 5)
    {
    }
}

class Engineering : SmallBuildingObject
{
    public Engineering()
        : base(-1, "Engineering", -1, 5)
    {
    }
}

class Incscription : SmallBuildingObject
{
    public Incscription()
        : base(-1, "Incscription", -1, 5)
    {
    }
}

class Tailoring : SmallBuildingObject
{
    public Tailoring()
        : base(-1, "Tailoring", -1, 5)
    {
    }
}

class Blacksmith : SmallBuildingObject
{
    public Blacksmith()
        : base(-1, "Blacksmith", -1, 5)
    {
    }
}

class Leatherworking : SmallBuildingObject
{
    public Leatherworking()
        : base(-1, "Leatherworking", -1, 5)
    {
    }
}

class Barn : MediumBuildingObject
{
    public Barn()
        : base(-1, "Barn", -1, 5)
    {
    }
}

class Inn : MediumBuildingObject
{
    public Inn()
        : base(-1, "Inn", -1, 5)
    {
    }
}

class Arena : MediumBuildingObject
{
    public Arena()
        : base(-1, "Arena", -1, 5)
    {
    }
}

class Mill : MediumBuildingObject
{
    public Mill()
        : base(-1, "Mill", -1, 5)
    {
    }
}

class TradingPost : MediumBuildingObject
{
    public TradingPost()
        : base(-1, "TradingPost", -1, 5)
    {
    }
}

class Stable : LargeBuildingObject
{
    public Stable()
        : base(-1, "Stable", -1, 5)
    {
    }
}

class Barracks : LargeBuildingObject
{
    public Barracks()
        : base(-1, "Barracks", -1, 5)
    {
    }
}

class MageTower : LargeBuildingObject
{
    public MageTower()
        : base(-1, "MageTower", -1, 5)
    {
    }
}

class Workshop : LargeBuildingObject
{
    public Workshop()
        : base(-1, "Workshop", -1, 5)
    {
    }
}

class Armory : LargeBuildingObject
{
    public Armory()
        : base(-1, "Armory", -1, 5)
    {
    }
}

class Garrison
{
    private static ReBot.API.ReBotAPI pReBotAPI = null;
    private static string pThisGetTypeToString = typeof(Garrison).ToString();
    public Mine fMine = null;
    public Farm fFarm = null;
    public Enchanting fEnchanting = null;
    public Jewelcrafting fJewelcrafting = null;
    public SalvageYard fSalvageYard = null;
    public Storehouse fStorehouse = null;
    public Alchemy fAlchemy = null;
    public Engineering fEngineering = null;
    public Incscription fIncscription = null;
    public Tailoring fTailoring = null;
    public Blacksmith fBlacksmith = null;
    public Leatherworking fLeatherworking = null;
    public Barn fBarn = null;
    public Inn fInn = null;
    public Arena fArena = null;
    public Mill fMill = null;
    public TradingPost fTradingPost = null;
    public Stable fStable = null;
    public Barracks fBarracks = null;
    public MageTower fMageTower = null;
    public Workshop fWorkshop = null;
    public Armory fArmory = null;

    private static bool validate(object rRebotAPI) //, object rGVar)
    {
        bool result = false;
        if (object.ReferenceEquals(null, rRebotAPI))
        {
            throw new System.Exception("Slow your roll there buddy boy, we need the ReBotAPI passed in (aka: this)");
        }
        else
        {
            pReBotAPI = (ReBot.API.ReBotAPI)rRebotAPI;
            GarrisonInfo.API = pReBotAPI;
            result = true;
        }
        return result;
    }

    public static void WriteLine(string message) //object rReBotAPI, object rGVar, string message)
    {
        if (validate(pReBotAPI)) //, pGVar))
        {
            pReBotAPI.Print(pThisGetTypeToString + ": " + message);
        }
    }

    public Garrison(object sReBotAPI, object sGVar) //non static constructor...
    {
        //non-static object initializations... (can be done here or above as noted)
        if (validate(sReBotAPI)) //, sGVar)) //set-up static PRebotAPI & pGVar & G
        {
            GarrisonInfo.thisMe = this;
            fMine = new Mine();
            fFarm = new Farm();
            fEnchanting = new Enchanting();
            fJewelcrafting = new Jewelcrafting();
            fSalvageYard = new SalvageYard();
            fStorehouse = new Storehouse();
            fAlchemy = new Alchemy();
            fEngineering = new Engineering();
            fIncscription = new Incscription();
            fTailoring = new Tailoring();
            fBlacksmith = new Blacksmith();
            fLeatherworking = new Leatherworking();
            fStable = new Stable();
            fBarracks = new Barracks();
            fMageTower = new MageTower();
            fWorkshop = new Workshop();
            fArmory = new Armory();
            fBarn = new Barn();
            fInn = new Inn();
            fArena = new Arena();
            fMill = new Mill();
            fTradingPost = new TradingPost();
        }
    }
    //Public Declarations (properties and methods)
    public static int level { get { return GarrisonInfo.level; } }
    public static Mine mine { get { return GarrisonInfo.thisMe.fMine; } }
    public static Farm farm { get { return GarrisonInfo.thisMe.fFarm; } }
    public static Enchanting enchanting { get { return GarrisonInfo.thisMe.fEnchanting; } }
    public static Jewelcrafting jewelcrafting { get { return GarrisonInfo.thisMe.fJewelcrafting; } }
    public static SalvageYard salvageyard { get { return GarrisonInfo.thisMe.fSalvageYard; } }
    public static Storehouse storehouse { get { return GarrisonInfo.thisMe.fStorehouse; } }
    public static Alchemy alchemy { get { return GarrisonInfo.thisMe.fAlchemy; } }
    public static Engineering engineering { get { return GarrisonInfo.thisMe.fEngineering; } }
    public static Incscription inscription { get { return GarrisonInfo.thisMe.fIncscription; } }
    public static Tailoring tailoring { get { return GarrisonInfo.thisMe.fTailoring; } }
    public static Blacksmith blacksmith { get { return GarrisonInfo.thisMe.fBlacksmith; } }
    public static Leatherworking leatherworking { get { return GarrisonInfo.thisMe.fLeatherworking; } }
    public static Barn barn { get { return GarrisonInfo.thisMe.fBarn; } }
    public static Inn inn { get { return GarrisonInfo.thisMe.fInn; } }
    public static Arena arena { get { return GarrisonInfo.thisMe.fArena; } }
    public static Mill mill { get { return GarrisonInfo.thisMe.fMill; } }
    public static TradingPost tradingpost { get { return GarrisonInfo.thisMe.fTradingPost; } }
    public static Stable stable { get { return GarrisonInfo.thisMe.fStable; } }
    public static Barracks barracks { get { return GarrisonInfo.thisMe.fBarracks; } }
    public static MageTower magetower { get { return GarrisonInfo.thisMe.fMageTower; } }
    public static Workshop workshop { get { return GarrisonInfo.thisMe.fWorkshop; } }
    public static Armory armory { get { return GarrisonInfo.thisMe.fArmory; } }
}



public class GarrisonStatics
{
    public static string playerMiniMapZoneText
    {
        get
        {
            string result = "";
            try { result = GarrisonInfo.API.ExecuteLua<string>("return tostring(GetMinimapZoneText())"); }
            catch { result = ""; }
            return result;
        }
    }
    private static System.Collections.Generic.Dictionary<int, Geometry.Vector3> HordePlotPositionStreet = new System.Collections.Generic.Dictionary<int, Geometry.Vector3> { { 18, new Geometry.Vector3(0f, 0f, 0f) }, { 19, new Geometry.Vector3(0f, 0f, 0f) }, { 20, new Geometry.Vector3(0f, 0f, 0f) }, { 22, new Geometry.Vector3(0f, 0f, 0f) }, { 23, new Geometry.Vector3(0f, 0f, 0f) }, { 24, new Geometry.Vector3(0f, 0f, 0f) }, { 25, new Geometry.Vector3(0f, 0f, 0f) }, { 59, new Geometry.Vector3(0f, 0f, 0f) }, { 63, new Geometry.Vector3(0f, 0f, 0f) } };
    private static System.Collections.Generic.Dictionary<int, Geometry.Vector3> HordePlotPositionPorche = new System.Collections.Generic.Dictionary<int, Geometry.Vector3> { { 18, new Geometry.Vector3(0f, 0f, 0f) }, { 19, new Geometry.Vector3(0f, 0f, 0f) }, { 20, new Geometry.Vector3(0f, 0f, 0f) }, { 22, new Geometry.Vector3(0f, 0f, 0f) }, { 23, new Geometry.Vector3(0f, 0f, 0f) }, { 24, new Geometry.Vector3(0f, 0f, 0f) }, { 25, new Geometry.Vector3(0f, 0f, 0f) }, { 59, new Geometry.Vector3(0f, 0f, 0f) }, { 63, new Geometry.Vector3(0f, 0f, 0f) } };
    private static System.Collections.Generic.Dictionary<int, Geometry.Vector3> HordePlotPositionDoorwy = new System.Collections.Generic.Dictionary<int, Geometry.Vector3> { { 18, new Geometry.Vector3(0f, 0f, 0f) }, { 19, new Geometry.Vector3(0f, 0f, 0f) }, { 20, new Geometry.Vector3(0f, 0f, 0f) }, { 22, new Geometry.Vector3(0f, 0f, 0f) }, { 23, new Geometry.Vector3(0f, 0f, 0f) }, { 24, new Geometry.Vector3(0f, 0f, 0f) }, { 25, new Geometry.Vector3(0f, 0f, 0f) }, { 59, new Geometry.Vector3(0f, 0f, 0f) }, { 63, new Geometry.Vector3(0f, 0f, 0f) } };
    private static System.Collections.Generic.Dictionary<int, Geometry.Vector3> HordePlotPositionInside = new System.Collections.Generic.Dictionary<int, Geometry.Vector3> { { 18, new Geometry.Vector3(0f, 0f, 0f) }, { 19, new Geometry.Vector3(0f, 0f, 0f) }, { 20, new Geometry.Vector3(0f, 0f, 0f) }, { 22, new Geometry.Vector3(0f, 0f, 0f) }, { 23, new Geometry.Vector3(0f, 0f, 0f) }, { 24, new Geometry.Vector3(0f, 0f, 0f) }, { 25, new Geometry.Vector3(0f, 0f, 0f) }, { 59, new Geometry.Vector3(0f, 0f, 0f) }, { 63, new Geometry.Vector3(0f, 0f, 0f) } };
    private static System.Collections.Generic.Dictionary<int, Geometry.Vector3> AlliancePlotPositionStreet = new System.Collections.Generic.Dictionary<int, Geometry.Vector3> { { 18, new Geometry.Vector3(0f, 0f, 0f) }, { 19, new Geometry.Vector3(0f, 0f, 0f) }, { 20, new Geometry.Vector3(0f, 0f, 0f) }, { 22, new Geometry.Vector3(0f, 0f, 0f) }, { 23, new Geometry.Vector3(0f, 0f, 0f) }, { 24, new Geometry.Vector3(0f, 0f, 0f) }, { 25, new Geometry.Vector3(0f, 0f, 0f) }, { 59, new Geometry.Vector3(0f, 0f, 0f) }, { 63, new Geometry.Vector3(0f, 0f, 0f) } };
    private static System.Collections.Generic.Dictionary<int, Geometry.Vector3> AlliancePlotPositionPorche = new System.Collections.Generic.Dictionary<int, Geometry.Vector3> { { 18, new Geometry.Vector3(0f, 0f, 0f) }, { 19, new Geometry.Vector3(0f, 0f, 0f) }, { 20, new Geometry.Vector3(0f, 0f, 0f) }, { 22, new Geometry.Vector3(0f, 0f, 0f) }, { 23, new Geometry.Vector3(0f, 0f, 0f) }, { 24, new Geometry.Vector3(0f, 0f, 0f) }, { 25, new Geometry.Vector3(0f, 0f, 0f) }, { 59, new Geometry.Vector3(0f, 0f, 0f) }, { 63, new Geometry.Vector3(0f, 0f, 0f) } };
    private static System.Collections.Generic.Dictionary<int, Geometry.Vector3> AlliancePlotPositionDoorwy = new System.Collections.Generic.Dictionary<int, Geometry.Vector3> { { 18, new Geometry.Vector3(0f, 0f, 0f) }, { 19, new Geometry.Vector3(0f, 0f, 0f) }, { 20, new Geometry.Vector3(0f, 0f, 0f) }, { 22, new Geometry.Vector3(0f, 0f, 0f) }, { 23, new Geometry.Vector3(0f, 0f, 0f) }, { 24, new Geometry.Vector3(0f, 0f, 0f) }, { 25, new Geometry.Vector3(0f, 0f, 0f) }, { 59, new Geometry.Vector3(0f, 0f, 0f) }, { 63, new Geometry.Vector3(0f, 0f, 0f) } };
    private static System.Collections.Generic.Dictionary<int, Geometry.Vector3> AlliancePlotPositionInside = new System.Collections.Generic.Dictionary<int, Geometry.Vector3> { { 18, new Geometry.Vector3(0f, 0f, 0f) }, { 19, new Geometry.Vector3(0f, 0f, 0f) }, { 20, new Geometry.Vector3(0f, 0f, 0f) }, { 22, new Geometry.Vector3(0f, 0f, 0f) }, { 23, new Geometry.Vector3(0f, 0f, 0f) }, { 24, new Geometry.Vector3(0f, 0f, 0f) }, { 25, new Geometry.Vector3(0f, 0f, 0f) }, { 59, new Geometry.Vector3(0f, 0f, 0f) }, { 63, new Geometry.Vector3(0f, 0f, 0f) } };
    private static System.Collections.Generic.Dictionary<int, Geometry.Vector3> fPlotPositionStreet = new System.Collections.Generic.Dictionary<int, Geometry.Vector3> { };
    private static System.Collections.Generic.Dictionary<int, Geometry.Vector3> fPlotPositionPorche = new System.Collections.Generic.Dictionary<int, Geometry.Vector3> { };
    private static System.Collections.Generic.Dictionary<int, Geometry.Vector3> fPlotPositionDoorwy = new System.Collections.Generic.Dictionary<int, Geometry.Vector3> { };
    private static System.Collections.Generic.Dictionary<int, Geometry.Vector3> fPlotPositionInside = new System.Collections.Generic.Dictionary<int, Geometry.Vector3> { };
    public static System.Collections.Generic.Dictionary<int, Geometry.Vector3> plotPositionStreet
    {
        get
        {
            if (fPlotPositionStreet.Keys.Count < 1)
            {
                if (GarrisonInfo.API.Me.IsAlliance)
                {
                    fPlotPositionStreet = AlliancePlotPositionStreet;
                }
                else
                {
                    fPlotPositionStreet = HordePlotPositionStreet;
                }
            }
            return fPlotPositionStreet;
        }
    }
    public static System.Collections.Generic.Dictionary<int, Geometry.Vector3> plotPositionPorche
    {
        get
        {
            if (fPlotPositionPorche.Keys.Count < 1)
            {
                if (GarrisonInfo.API.Me.IsAlliance)
                {
                    fPlotPositionPorche = AlliancePlotPositionPorche;
                }
                else
                {
                    fPlotPositionPorche = HordePlotPositionPorche;
                }
            }
            return fPlotPositionPorche;
        }
    }
    public static System.Collections.Generic.Dictionary<int, Geometry.Vector3> plotPositionDoorwy
    {
        get
        {
            if (fPlotPositionDoorwy.Keys.Count < 1)
            {
                if (GarrisonInfo.API.Me.IsAlliance)
                {
                    fPlotPositionDoorwy = AlliancePlotPositionDoorwy;
                }
                else
                {
                    fPlotPositionDoorwy = HordePlotPositionDoorwy;
                }
            }
            return fPlotPositionDoorwy;
        }
    }
    public static System.Collections.Generic.Dictionary<int, Geometry.Vector3> plotPositionInside
    {
        get
        {
            if (fPlotPositionInside.Keys.Count < 1)
            {
                if (GarrisonInfo.API.Me.IsAlliance)
                {
                    fPlotPositionInside = AlliancePlotPositionInside;
                }
                else
                {
                    fPlotPositionInside = HordePlotPositionInside;
                }
            }
            return fPlotPositionInside;
        }
    }
}
