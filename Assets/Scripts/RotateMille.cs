using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMille : MonoBehaviour
{
    [SerializeField] private float SpeedRotate;

    private void Update()
    {
        transform.Rotate(SpeedRotate * Time.deltaTime, 0, 0);
    }
}
