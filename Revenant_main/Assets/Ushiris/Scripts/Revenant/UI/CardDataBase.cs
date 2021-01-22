using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.AddressableAssets;

public class CardDataBase:MonoBehaviour
{
    //csvDatas[No,PR,SP][index(0=Property names)][property] = string value
    static List<List<List<string>>> csvDatas = new List<List<List<string>>>();
    static bool isInit = false;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Init()
    {
        if (isInit) return;

        ResourceSettings resouce = ResourceSettings.Instance();

        // csvをロード

        var normalCsv = ResourceSettings.Load<TextAsset>(resouce.normalCardData);
        var PRCsv = ResourceSettings.Load<TextAsset>(resouce.prCardData);
        var SPCsv = ResourceSettings.Load<TextAsset>(resouce.spCardData);

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
        cardData.Compile(csvDatas[(int)type][GetIndex(type,num)]);

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
