using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffApplier : MonoBehaviour
{
    [Header("Item")]
    [SerializeField] float itemPersistDuration = 25f;


    void Start()
    {
        Destroy(gameObject, itemPersistDuration);
    }


}
