using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ResourceSettings:MonoBehaviour
{
    public AssetReference
        card,
        deckEditElement,
        errorMessage,
        deckView,
        dragableCamera,
        table,
        deckManager,
        normalCardData,
        prCardData,
        spCardData,
        gameAreaElement,
        cardGenerator,
        debugUI,
        mainUI,
        cardData,
        addCardToDeck;

    static ResourceSettings instance;
    static bool DoneInit = false;

    private void Awake()
    {
        Init(this);
    }

    static void Init(ResourceSettings new_instance)
    {
        if (DoneInit) return;

        instance ??= new_instance;
        DontDestroyOnLoad(instance);
        DoneInit = true;
    }

    public static ResourceSettings Instance()
    {
        return instance;
    }


    public static T Load<T>(AssetReference reference)
    {
        T result = default;

        instance.StartCoroutine(instance.LoadObj(reference,result));

        return result;
    }

    IEnumerator LoadObj<T>(AssetReference reference,T result)
    {
        var Obj = Addressables.LoadAssetAsync<T>(reference);

        //ƒ[ƒh‚ªŠ®—¹‚·‚é‚Ü‚Å‘Ò‹@
        yield return new WaitUntil(() => Obj.IsDone);

        if (Obj.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
        {
            result = Obj.Result;
        }
        else
        {
            Debug.LogError(Obj.Status);
        }
    }
}
