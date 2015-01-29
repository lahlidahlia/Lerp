using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {
    private Vector3 chosenDestination; //Destination to move to after LerpUpdate
    private Vector3 nextDestination; 
	// Use this for initialization
	void Start () {
        chosenDestination = transform.position;
        Global.LerpList.Add(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        nextDestination = transform.position - new Vector3(0, 1, 0);
        transform.position = Vector3.Lerp(transform.position, chosenDestination, Global.SPEED); 
	}

    void LerpUpdate() {
        chosenDestination = nextDestination;
    }
}
