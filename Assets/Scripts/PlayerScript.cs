using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    private Vector2 mouse_pos;
    private Vector3 chosenDestination; //Destination to move to after LerpUpdate
    private Vector3 nextDestination; //Chosen destination in mouse clicks
	// Use this for initialization
	void Start () {
        Global.LerpList.Add(gameObject);
        Debug.Log(Global.LerpList);
	}
	
	// Update is called once per frame
	void Update () {
        mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) {
            nextDestination = mouse_pos;
        }

        transform.position = Vector3.Lerp(transform.position, chosenDestination, Global.SPEED); 
	}

    void LerpUpdate() {
        chosenDestination = nextDestination;
    }
}
