using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2_Object_HairPro : InteractiveObject
{
    [SerializeField] Image hairproductor;
    protected override void Action()
    {
        hairproductor.gameObject.SetActive(false);
    }

}
