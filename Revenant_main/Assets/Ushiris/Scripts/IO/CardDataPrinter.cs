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
        type.text = selectCard.cardData.Type.ToString();
        cardName.text = GetNameText();
        race.text = GetRaceText();
        try { NC.text = GetNCText(); } catch { NC.text = ""; };
        try { TR.text = GetTRText(); } catch { TR.text = ""; };
        try { graze.text = GetGrazeText(); } catch { graze.text = ""; };
        try { state.text = GetStateText(); } catch { state.text = ""; };

    }

    string GetRaceText()
    {
        string race1 = selectCard.cardData.Race1.ToString();
        if (race1 == "") return "";

        string race2 = selectCard.cardData.Race2.ToString();

        string s_race1 = selectCard.cardData.SubRace1.ToString();
        if (s_race1 == "") return "種族:" + race1 + (race2 == "" ? "" : "," + race2);

        string s_race2 = selectCard.cardData.SubRace2.ToString();
        if(s_race2=="") return "種族:" + race1 + (race2 == "" ? "" : "," + race2) + "/" + s_race1;

        return "種族:" + race1 + (race2 == "" ? "" : "," + race2) + "/" + s_race1 + "," + s_race2;

    }

    string GetStateText()
    {
        if (selectCard.cardData.Attack == null) return "";
        return "攻撃力:" + selectCard.cardData.Attack + (selectCard.cardData.SubAttack == null ? "" : "/" + selectCard.cardData.SubAttack) +
             "\n耐久力:" + selectCard.cardData.Health + (selectCard.cardData.SubHealth == null ? "" : "/" + selectCard.cardData.SubHealth);
    }

    string GetNameText()
    {
        DebugLogger.Log(selectCard.cardData.Name);
        return selectCard.cardData.Name + (selectCard.cardData.SubName == "" ? "" : "/" + selectCard.cardData.SubName);
    }

    string GetTRText()
    {
        if (selectCard.cardData.Period == null) return "";
        return "期間:" + selectCard.cardData.Period.ToString() + "\n範囲:" + selectCard.cardData.Range.ToString();
    }

    string GetNCText()
    {
        return "Node:" + selectCard.cardData.Node + "\nCost:" + selectCard.cardData.Cost;
    }

    string GetGrazeText()
    {
        if (selectCard.cardData.Graze == null) return "";
        return "GRAZE:" + selectCard.cardData.Graze.ToString() + (selectCard.cardData.SubGraze == null ? "" : "/" + selectCard.cardData.SubGraze.ToString());
    }

    string GetMainText()
    {
        CardMainData data = selectCard.cardData;

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
