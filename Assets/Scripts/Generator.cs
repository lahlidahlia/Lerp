using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {
    /*Generate blocks to fall out of the sky*/

    public GameObject StandardBlock;

	// Use this for initialization
	void Start () {
        Global.LerpList.Add(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void LerpUpdate() {
        Vector2 location = randomLocation(0, 1, 1, 1.2f);
        Instantiate(StandardBlock, location, Quaternion.identity);
    }

    Vector2 randomLocation(float x_min, float x_max, float y_min, float y_max) {
        /* Return a random world coordinate within the specified viewport range
         * Remember that (0,0) is bottom left
         */
        Vector2 location = Camera.main.ViewportToWorldPoint(new Vector2(Random.Range(x_min, x_max), Random.Range(y_min, y_max)));
        return location;
    }
}
