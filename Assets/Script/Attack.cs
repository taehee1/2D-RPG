using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage = 5f;

    private void Update()
    {
        if (gameObject.name == "AttackObj")
        {
            transform.position = transform.parent.position;
        }
    }
}
