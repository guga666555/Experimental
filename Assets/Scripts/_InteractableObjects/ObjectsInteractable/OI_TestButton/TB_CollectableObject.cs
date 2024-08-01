using System;
using System.Collections.Generic;
using UnityEngine;

public class TB_CollectableObject : MonoBehaviour
{
    public static event Action OnCollected;
    public static int CollectableCount;
    public static List<GameObject> gameObjects = new();

    private void Start()
    {
        TB_CollectableObject.gameObjects.Add(gameObject);
    }

    private void OnEnable()
    {
        CollectableCount++;
    }

    private void OnDisable()
    {
        CollectableCount--;
    }

    private void Update()
    {
        transform.localRotation = Quaternion.Euler(0, Time.time * 100f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected?.Invoke();
            gameObject.SetActive(false);
        }
    }
}