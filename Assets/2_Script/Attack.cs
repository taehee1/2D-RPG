using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage = 5f;

    public static Attack Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (gameObject.name == "AttackObj")
        {
            transform.position = transform.parent.position;
        }
    }
}
