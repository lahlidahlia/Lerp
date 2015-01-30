using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Generator : MonoBehaviour {
    /*Generate blocks to fall out of the sky*/

    public GameObject StandardBlock;
    public GameObject SpinningBlock;

    private Dictionary<GameObject, int> spawnChances = new Dictionary<GameObject, int>();
	// Use this for initialization
	void Start () {
        Global.LerpList.Add(gameObject);

        //Setting spawn chances
        spawnChances.Add(StandardBlock, 50);
        spawnChances.Add(SpinningBlock, 50);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void LerpUpdate() {
        GameObject objToSpawn = null; //Temp variable to shorten code

        /*Refer to http://forums.asp.net/t/1567334.aspx?picking+random+items+from+a+list+based+on+percentages */
        int maxPercent = 0;
        foreach (KeyValuePair<GameObject, int> kvp in spawnChances) {
            maxPercent += kvp.Value;
        }

        int randNum = Random.Range(1, maxPercent);
        int currentPercent = 0;

        foreach (KeyValuePair<GameObject, int> kvp in spawnChances) { //Choosing object to spawn
            currentPercent += kvp.Value;

            if (currentPercent > randNum) {
                objToSpawn = kvp.Key;
                break;
            }
        }


        //Picking object to spawn

        //if()
        Instantiate(objToSpawn, randomLocation(0, 1, 1, 1.2f), Quaternion.identity);
    }

    Vector2 randomLocation(float x_min, float x_max, float y_min, float y_max) {
        /* Return a random world coordinate within the specified viewport range
         * Remember that (0,0) is bottom left
         */
        Vector2 location = Camera.main.ViewportToWorldPoint(new Vector2(Random.Range(x_min, x_max), Random.Range(y_min, y_max)));
        return location;
    }
}
