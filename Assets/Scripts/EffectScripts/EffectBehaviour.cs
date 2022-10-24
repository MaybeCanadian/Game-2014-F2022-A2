using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBehaviour : MonoBehaviour
{
    [SerializeField]
    private float LifeSpan = 1.0f;

    private void Start()
    {
        Invoke("Remove", LifeSpan);
    }

    private void Remove()
    {
        Destroy(gameObject);
    }
}
