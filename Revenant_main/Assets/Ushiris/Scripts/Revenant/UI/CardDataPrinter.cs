using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDataPrinter : MonoBehaviour
{
    Card selectCard;
    [SerializeField] Text type, cardName, NC, TR, graze, state, main, race;


    private void Start()
    {
        if (Card.OnCardClick == null) Card.OnCardClick = new UEventCard();
        Card.OnCardClick.AddListener(OnCardClick);
    }

    void OnCardClick(Card card)
    {
        selectCard = card;

        main.text = GetMainText();
        type.text = selectCard.DefaultCardData.Type.ToString();
        cardName.text = GetNameText();
        race.text = GetRaceText();
        try { NC.text = GetNCText(); } catch { NC.text = ""; };
        try { TR.text = GetTRText(); } catch { TR.text = ""; };
        try { graze.text = GetGrazeText(); } catch { graze.text = ""; };
        try { state.text = GetStateText(); } catch { state.text = ""; };

    }

    string GetRaceText()
    {
        string race1 = selectCard.DefaultCardData.Race1.ToString();
        if (race1 == "") return "";

        string race2 = selectCard.DefaultCardData.Race2.ToString();

        string s_race1 = selectCard.DefaultCardData.SubRace1.ToString();
        if (s_race1 == "") return "種族:" + race1 + (race2 == "" ? "" : "," + race2);

        string s_race2 = selectCard.DefaultCardData.SubRace2.ToString();
        if(s_race2=="") return "種族:" + race1 + (race2 == "" ? "" : "," + race2) + "/" + s_race1;

        return "種族:" + race1 + (race2 == "" ? "" : "," + race2) + "/" + s_race1 + "," + s_race2;

    }

    string GetStateText()
    {
        if (selectCard.DefaultCardData.Attack == null) return "";
        return "攻撃力:" + selectCard.DefaultCardData.Attack + (selectCard.DefaultCardData.SubAttack == null ? "" : "/" + selectCard.DefaultCardData.SubAttack) +
             "\n耐久力:" + selectCard.DefaultCardData.Health + (selectCard.DefaultCardData.SubHealth == null ? "" : "/" + selectCard.DefaultCardData.SubHealth);
    }

    string GetNameText()
    {
        DebugLogger.Log(selectCard.DefaultCardData.Name);
        return selectCard.DefaultCardData.Name + (selectCard.DefaultCardData.SubName == "" ? "" : "/" + selectCard.DefaultCardData.SubName);
    }

    string GetTRText()
    {
        if (selectCard.DefaultCardData.Period == null) return "";
        return "期間:" + selectCard.DefaultCardData.Period.ToString() + "\n範囲:" + selectCard.DefaultCardData.Range.ToString();
    }

    string GetNCText()
    {
        return "Node:" + selectCard.DefaultCardData.Node + "\nCost:" + selectCard.DefaultCardData.Cost;
    }

    string GetGrazeText()
    {
        if (selectCard.DefaultCardData.Graze == null) return "";
        return "GRAZE:" + selectCard.DefaultCardData.Graze.ToString() + (selectCard.DefaultCardData.SubGraze == null ? "" : "/" + selectCard.DefaultCardData.SubGraze.ToString());
    }

    string GetMainText()
    {
        CardMainData data = selectCard.DefaultCardData;

        //normal card
        string main = data.Text.Replace("<br>", "\n");

        //transformable card
        string sub = data.SubText;

        //reader card
        string ex = data.PopularityExplosion.Replace("<br>", "\n");
        string bonus = data.PopularityBonus.Replace("<br>", "\n");
        string normal = data.Normal.Replace("<br>", "\n");
        string bad = data.UnpopularityPenalty.Replace("<br>", "\n");

        string result = "";
        result += main;
        result += sub == "" ? "" : "\n(変身時)\n" + sub;
        if (ex != "")
        {
            result += "\n[人気4]\n" + ex;
            result += "\n[人気2]\n" + bonus;
            result += "\n[人気1]\n" + normal;
            result += "\n[人気0]\n" + bad;
        }

        return result;
    }
}
