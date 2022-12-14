using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMPro.TextMeshProUGUI>().gameObject.LeanScale(new Vector3(1.2f,1.2f,1.2f),0.5f).setLoopPingPong();
    }

    
}
