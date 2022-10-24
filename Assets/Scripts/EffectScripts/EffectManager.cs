using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum EffectTypes
{
    Explosion
}

public class EffectManager : MonoBehaviour
{
    public static EffectManager instance;

    [SerializeField]
    private List<GameObject> effectPrefabs;
    [SerializeField]
    private Transform EffectParent;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        //fire explosion
        effectPrefabs.Add(Resources.Load<GameObject>("Prefabs/Effects/Fire Explosion"));
    }

    public GameObject CreateEffect(EffectTypes effect)
    {
        GameObject TempEffect = Instantiate(effectPrefabs[((int)effect)], EffectParent);

        return TempEffect;
    }
}
