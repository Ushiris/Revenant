using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;
using System.Text;
using System;

[RequireComponent(typeof(Deck))]
public class DeckDataIO : MonoBehaviour
{
    public static UnityEvent OnSaved = new UnityEvent();
    public static UnityEvent OnLoad = new UnityEvent();

    public static List<string> DeckNames { get; private set; }
    public static string deckPath = "";
    Deck deck;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void InitDeckPath()
    {
        deckPath = Application.dataPath + "/DeckData";
        SetDeckNames();
        OnSaved.AddListener(SetDeckNames);
    }

    private void Awake()
    {
        deck = GetComponent<Deck>();
    }

    static void SetDeckNames()
    {
        DirectryManager.SafeCreateDirectory(deckPath);
        File.AppendAllText(deckPath + "/" + "Temp.csv", "");
        DeckNames = new List<string>(Directory.EnumerateFiles(deckPath, "*.csv"));
        for (int i = 0; i < DeckNames.Count; i++)
        {
            DeckNames[i] = GetDeckName(DeckNames[i]);
        }
    }

    static string GetDeckName(string path)
    {
        var trueName = path.Replace(deckPath + "\\", "");
        trueName = trueName.Replace(".csv", "");
        return trueName;
    }

    public void Save()
    {
        File.WriteAllText(deckPath + "/" + deck.DeckName + ".csv", "");
        deck.List.ForEach((item) =>
        {
            File.AppendAllText(deckPath + "/" + deck.DeckName + ".csv", ToData(item) + '\n');
        });
        SetDeckNames();

        OnSaved.Invoke();
    }

    public void Load(int index)
    {
        if (index >= DeckNames.Count)
        {
            DebugLogger.Log("index out of range");
            return;
        }

        var path = deckPath + "/" + DeckNames[index] + ".csv";
        FileInfo fi = new FileInfo(path);
        try
        {
            using StreamReader sr = new StreamReader(fi.OpenRead(), Encoding.UTF8);
            string readTxt = sr.ReadToEnd();
            deck.SetDeck(ToDeckData(readTxt));
        }
        catch (Exception e)
        {
            DebugLogger.Log(e);
        }

        OnLoad.Invoke();
    }

    static List<DeckElement> ToDeckData(string mainData)
    {
        List<string> lines = new List<string>(mainData.Split('\n'));
        List<DeckElement> elements = new List<DeckElement>();

        lines.ForEach((line) =>
        {
            List<string> data = new List<string>(line.Split(','));
            if (data[0] == "") return;

            elements.Add(new DeckElement
            {
                amount = uint.Parse(data[0]),
                type = (Card.IDType)int.Parse(data[1]),
                id = uint.Parse(data[2])
            });
        });

        return elements;
    }

    static string ToData(DeckElement element)
    {
        return element.amount + "," + ((int)element.type) + "," + element.id;
    }
}