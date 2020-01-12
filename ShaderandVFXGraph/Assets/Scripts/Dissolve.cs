using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    [SerializeField]
    private float dissolveTime = 1;

    private int dissolveDirection = -1;
    private float dissolveAmount = 1;
    private string dissolveReference = "Vector1_A89ABD58";
    private Material dissolveMaterial;

    private void Awake()
    {
        dissolveMaterial = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dissolveDirection *= -1;
        }

        dissolveAmount += dissolveDirection * (1 / dissolveTime) * Time.deltaTime;

        if (dissolveDirection == 1 && dissolveAmount > 1)
        {
            dissolveAmount = 1;
        }

        if (dissolveDirection == -1 && dissolveAmount < 0)
        {
            dissolveAmount = 0;
        }

        dissolveMaterial.SetFloat(dissolveReference, dissolveAmount);
    }
}
