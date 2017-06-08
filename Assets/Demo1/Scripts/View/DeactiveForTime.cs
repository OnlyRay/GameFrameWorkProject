using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveForTime : MonoBehaviour {
	
    void OnEnable()
    {
        Invoke("Deactive", 3);
    }

	void Deactive()
    {
        this.gameObject.SetActive(false);
    }
}
