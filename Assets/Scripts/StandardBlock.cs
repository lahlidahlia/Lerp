using UnityEngine;
using System.Collections;

public class StandardBlock : MonoBehaviour {
    private Vector3 chosenDestination; //Destination to move to after LerpUpdate
    private Vector3 nextDestination;

    public float distance; //How far the block will move per lerp
	// Use this for initialization
	void Start () {
        chosenDestination = transform.position;
        Global.LerpList.Add(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        //Movement code
        nextDestination = transform.position - new Vector3(0, distance, 0);
        transform.position = Vector3.Lerp(transform.position, chosenDestination, Global.SPEED); //Lerp the block to destination

        if (transform.position.y < Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y) {
            //Remove block if offscreen. The reason it's in the update loop is so that it won't trigger when LerpTimer is sending out LerpUpdate messages
            Global.LerpList.Remove(gameObject);
            Destroy(gameObject);
        }
	}

    void LerpUpdate() {
        chosenDestination = nextDestination;
    }
}
