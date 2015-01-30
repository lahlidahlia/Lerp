using UnityEngine;
using System.Collections;

public class SpinningBlock : MonoBehaviour {
    private Vector3 chosenDestination; //Destination to move to after LerpUpdate
    private Vector3 nextDestination;

    private float chosenRotation;
    private float nextRotation;

    public float rotation; //How much the block rotates per lerp
    public float distance; //How far the block will move per lerp
    // Use this for initialization
    void Start() {
        chosenDestination = transform.position;
        Global.LerpList.Add(gameObject);
    }

    // Update is called once per frame
    void Update() {
        //Movement code
        nextDestination = transform.position - new Vector3(0, distance, 0);
        transform.position = Vector3.Lerp(transform.position, chosenDestination, Global.SPEED); //Lerp the block to destination

        nextRotation = transform.rotation.eulerAngles.z + rotation;
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Inverse(chosenRotation), Global.SPEED);
        //transform.Rotate(Vector3.forward, Mathf.Lerp(transform.rotation.z, chosenRotation, Global.SPEED));
        
        /*Without these if statements, the block will spin very rapidly once it wraps around the 360 mark. The reason is that the chosenRotation can
         *go negative and over 360, but the object's angle can't, so when the object's angle reaches its limit, the chosenRotation is normalize so the 
         *object's angle can reach it.
         */
        float t_rotation = Mathf.Lerp(transform.eulerAngles.z, chosenRotation, Global.SPEED); //temp variable
        if (t_rotation > 360) { //If the current angle is higher than 360, then wrap around chosenRotation around.
            chosenRotation -= 360;
        }
        if (t_rotation < 0) {
            chosenRotation += 360;
        }
        //Debug.Log("Rotation: " + t_rotation + ", Angles.z: " + transform.eulerAngles.z + ", chosen: " + chosenRotation);
        transform.rotation = Quaternion.Euler(0, 0, t_rotation);

        if (transform.position.y < Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y) {
            //Remove block if offscreen. The reason it's in the update loop is so that it won't trigger when LerpTimer is sending out LerpUpdate messages
            Global.LerpList.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    void LerpUpdate() {
        chosenDestination = nextDestination;
        chosenRotation = nextRotation;
        Debug.Log(transform.eulerAngles.z + ", chosen: " + chosenRotation);
    }
}
