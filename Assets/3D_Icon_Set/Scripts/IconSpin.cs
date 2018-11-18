using UnityEngine;
using System.Collections;

public class IconSpin : MonoBehaviour {

	[Range(-10.0f, 10.0f)]
	public float mRotationSpeed = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 objectEuler = this.transform.localEulerAngles;
        objectEuler.y += mRotationSpeed ;
        this.transform.localEulerAngles = objectEuler;

	}
}
