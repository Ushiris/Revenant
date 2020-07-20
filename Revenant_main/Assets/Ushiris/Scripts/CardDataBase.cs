using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CardDataBase:MonoBehaviour
{
    //csvDatas[No,PR,SP][index(0=Property names)][property] = string value
    static List<List<List<string>>> csvDatas = new List<List<List<string>>>();
    static bool isInit = false;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Init()
    {
        if (isInit) return;

        // csvをロード
        TextAsset normalCsv = Resources.Load<TextAsset>("no_upload/Normal_CardData");
        TextAsset PRCsv = Resources.Load<TextAsset>("no_upload/PR_CardData");
        TextAsset SPCsv = Resources.Load<TextAsset>("no_upload/SP_CardData");

        List<StringReader> reader = new List<StringReader> { new StringReader(normalCsv.text), new StringReader(PRCsv.text), new StringReader(SPCsv.text) };

        for (int i = 0; i < reader.Count; i++)
        {
            while (reader[i].Peek() > -1)
            {
                // ','ごとに区切って配列へ格納
                string line = reader[i].ReadLine();
                csvDatas.Add(new List<List<string>>());
                csvDatas[i].Add(new List<string>(line.Split(',')));
            }
        }

        isInit = true;
    }

    public static CardMainData GetCardData(Card.IDType type,uint num)
    {
        CardMainData cardData = new CardMainData();
        cardData.Compile(csvDatas[(int)type][(int)num]);

        return cardData;
    }

    public static int GetIndex(Card.IDType type, uint ID)
    {
        int index = 0;

        for (var i=0;i< csvDatas[(int)type].Count; i++)
        {
            int id;
            try { id=int.Parse(csvDatas[(int)type][i][CardMainData.Property.Number]); } catch { id = 0; };
            if (id == ID)
            {
                index = i;
            }
        }

        return index;
    }
}
