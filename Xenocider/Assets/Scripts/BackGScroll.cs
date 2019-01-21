using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGScroll : MonoBehaviour {

    private Material material;
    private Vector2 offSet;

    [Range(0f, 5f)][SerializeField]private float xVel, yVel = 1.8f;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void Update () {
        offSet = new Vector2(xVel, yVel);
        material.mainTextureOffset += offSet * Time.deltaTime;
	}
}
