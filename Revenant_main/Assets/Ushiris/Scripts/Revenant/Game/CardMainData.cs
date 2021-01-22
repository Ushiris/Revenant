using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMainData
{
    public struct Property
    {
        public const byte Number = 0,
        Type = 1,
        Name = 2,
        SubName = 3,
        Node = 4,
        Cost = 5,
        Graze = 6,
        SubGraze = 7,
        Attack = 8,
        SubAttack = 9,
        Health = 10,
        SubHealth = 11,
        Race1 = 12,
        Race2 = 13,
        SubRace1 = 14,
        SubRace2 = 15,
        Spiritualist = 16,
        Solidarity = 17,
        Range = 18,
        Period = 19,
        Text = 20,
        SubText = 21,
        PopularityExplosion = 22,
        PopularityBonus = 23,
        Normal = 24,
        UnpopularityPenalty = 25,
        Comment = 26,
        Ilust = 27,
        PROPRTY_COUNT = 28;
    }

    public enum CardType : byte
    {
        Character,
        Spell,
        Command,
        CARDTYPE_COUNT
    }

    public static readonly Dictionary<string, CardType> CardTypeDic = new Dictionary<string, CardType>
    {
        {"Character",CardType.Character },
        {"Spell",CardType.Spell },
        {"Command",CardType.Command }
    };

    public enum Race : byte
    {
        Human,
        Apparition,
        Fairy,
        Witch,
        Kappa,
        Vampire,
        Demon,
        Ghost,
        Tengu,
        GrimReaper,
        Enma,
        God,
        Beast,
        Ogre,
        CelestialMaiden,
        Dragon,
        Hermit,
        Dwarf,
        None,
        RACE_COUNT
    }

    public static readonly Dictionary<string, Race> RaceDic = new Dictionary<string, Race>
    {
        {"人間",Race.Human },
        {"妖怪",Race.Apparition },
        {"妖精",Race.Fairy },
        {"魔法使い",Race.Witch },
        {"河童",Race.Kappa },
        {"吸血鬼",Race.Vampire },
        {"魔界人",Race.Demon },
        {"幽霊",Race.Ghost },
        {"天狗",Race.Tengu },
        {"死神",Race.GrimReaper },
        {"閻魔",Race.Enma },
        {"神",Race.God },
        {"獣",Race.Beast },
        {"鬼",Race.Ogre },
        {"天人",Race.CelestialMaiden },
        {"龍",Race.Dragon },
        {"仙人",Race.Hermit },
        {"小人",Race.Dwarf },
        {"種族なし",Race.None }
    };

    public enum RangeType : byte
    {
        Target,
        All,
        Player,
        Select,
        Other,
        RANGETYPE_COUNT
    }

    public static readonly Dictionary<string, RangeType> RangeDic = new Dictionary<string, RangeType>
    {
        {"単一",RangeType.Target },
        {"範囲",RangeType.All },
        {"メタ",RangeType.Player },
        {"適応",RangeType.Select },
        {"その他",RangeType.Other }
    };

    public enum PeriodType : byte
    {
        Flash,
        Persistence,
        Equipment,
        Curse,
        Ruler,
        PERIODTYPE_COUNT
    }

    public static readonly Dictionary<string, PeriodType> PeriodDic = new Dictionary<string, PeriodType>
    {
        {"瞬間",PeriodType.Flash },
        {"持続",PeriodType.Persistence },
        {"装備",PeriodType.Equipment },
        {"呪符",PeriodType.Curse },
        {"世界呪符",PeriodType.Ruler }
    };

    public uint? Number { get; private set; }
    public CardType? Type { get; private set; }
    public string Name { get; private set; }
    public string SubName { get; private set; }
    public sbyte? Node { get; private set; }
    public sbyte? Cost { get; private set; }
    public sbyte? Graze { get; private set; }
    public sbyte? SubGraze { get; private set; }
    public int? Attack { get; private set; }
    public int? SubAttack { get; private set; }
    public int? Health { get; private set; }
    public int? SubHealth { get; private set; }
    public Race? Race1 { get; private set; }
    public Race? Race2 { get; private set; }
    public Race? SubRace1 { get; private set; }
    public Race? SubRace2 { get; private set; }
    public string Spiritualist { get; private set; }
    public List<Race> Solidarity { get; private set; }
    public RangeType? Range { get; private set; }
    public PeriodType? Period { get; private set; }
    public string Text { get; private set; }
    public string SubText { get; private set; }
    public string PopularityExplosion { get; private set; }
    public string PopularityBonus { get; private set; }
    public string Normal { get; private set; }
    public string UnpopularityPenalty { get; private set; }
    public string Comment { get; private set; }
    public Sprite Ilust { get; private set; }

    public void Compile(List<string> str_data)
    {
        List<string> data = str_data;

        try { Number = uint.Parse(data[Property.Number]); }                 catch { Number = null; }
        try { Type = CardTypeDic[data[Property.Type]]; }                    catch { Type = null; }
        try { Name = data[Property.Name]; }                                 catch { Name = null; }
        try { SubName = data[Property.SubName]; }                           catch { SubName = null; }
        try { Node = sbyte.Parse(data[Property.Node]); }                    catch { Node = null; }
        try { Cost = sbyte.Parse(data[Property.Cost]); }                    catch { Cost = null; }
        try { Graze = sbyte.Parse(data[Property.Graze]); }                  catch { Graze = null; }
        try { SubGraze = sbyte.Parse(data[Property.SubGraze]); }            catch { SubGraze = null; }
        try { Attack = int.Parse(data[Property.Attack]); }                  catch { Attack = null; }
        try { SubAttack = int.Parse(data[Property.SubAttack]); }            catch { SubAttack = null; }
        try { Health = int.Parse(data[Property.Health]); }                  catch { Health = null; }
        try { SubHealth = int.Parse(data[Property.SubHealth]); }            catch { SubHealth = null; }
        try { Race1 = RaceDic[data[Property.Race1]]; }                      catch { Race1 = null; }
        try { Race2 = RaceDic[data[Property.Race2]]; }                      catch { Race2 = null; }
        try { SubRace1 = RaceDic[data[Property.SubRace1]]; }                catch { SubRace1 = null; }
        try { SubRace2 = RaceDic[data[Property.SubRace2]]; }                catch { SubRace2 = null; }
        try { Spiritualist = data[Property.Spiritualist]; }                 catch { Spiritualist = null; }
        try { Range = RangeDic[data[Property.Range]]; }                     catch { Range = null; }
        try { Period = PeriodDic[data[Property.Period]]; }                  catch { Period = null; }
        try { Text = data[Property.Text]; }                                 catch { Text = null; }
        try { SubText = data[Property.SubText]; }                           catch { SubText = null; }
        try { PopularityExplosion = data[Property.PopularityExplosion]; }   catch { PopularityExplosion = null; }
        try { PopularityBonus = data[Property.PopularityBonus]; }           catch { PopularityBonus = null; }
        try { Normal = data[Property.Normal]; }                             catch { Normal = null; }
        try { UnpopularityPenalty = data[Property.UnpopularityPenalty]; }   catch { UnpopularityPenalty = null; }
        try { Comment = data[Property.Comment]; }                           catch { Comment = null; }

        List<string> races = new List<string>(data[Property.Solidarity].Split('+'));
        DebugLogger.Log(races[0]);
        if (races[0] != "") races.ForEach((item) => { Solidarity.Add(RaceDic[item]); });
        Ilust = Resources.Load(data[Property.Ilust]) as Sprite;
        if (Ilust == null) Ilust = Resources.Load("ilust/none") as Sprite;
    }
}
