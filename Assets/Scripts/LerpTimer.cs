using UnityEngine;
using System.Collections;

public class LerpTimer : MonoBehaviour {
    /*Times and execute a Lerp Loop*/

    public float timer; //In seconds
    public float lerpTime;
	// Use this for initialization
	void Start () {
        timer = lerpTime;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            foreach (GameObject obj in Global.LerpList) {
                //Debug.Log(obj);
                obj.SendMessage("LerpUpdate");
                
            }
            timer = lerpTime;
        }
	}
}
