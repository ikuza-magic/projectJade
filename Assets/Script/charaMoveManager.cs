using UnityEngine;
using System.Collections;

public class charaMoveManager : MonoBehaviour {
    public bool isControl;

    charaSpriteManager SpriteManager;
    Vector3 moveDirection;
    float speed;
	// Use this for initialization
	void Start () {
        speed = 3.0f;
        moveDirection = Vector3.zero;
        SpriteManager = GetComponent<charaSpriteManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isControl)
        {
            moveDirection = Vector3.zero;
            SpriteManager.motionID = 0;
            if (Input.GetKey(KeyCode.UpArrow)) KeyInput(2);
            if (Input.GetKey(KeyCode.DownArrow)) KeyInput(8);
            if (Input.GetKey(KeyCode.RightArrow)) KeyInput(4);
            if (Input.GetKey(KeyCode.LeftArrow)) KeyInput(1);

            Move(moveDirection);
        }
	
	}
    void KeyInput(int keyDirectionID)
    {
        if (keyDirectionID == 1)
        {
            SpriteManager.motionID = 1;
            SpriteManager.directionMode = charaSpriteManager.direction.left;
            moveDirection += Vector3.left;
        }
        if (keyDirectionID == 2)
        {
            SpriteManager.motionID = 1;
            SpriteManager.directionMode = charaSpriteManager.direction.up;
            moveDirection += Vector3.up;
        }
        if (keyDirectionID == 4)
        {
            SpriteManager.motionID = 1;
            SpriteManager.directionMode = charaSpriteManager.direction.right;
            moveDirection += Vector3.right;
        }
        if (keyDirectionID == 8)
        {
            SpriteManager.motionID = 1;
            SpriteManager.directionMode = charaSpriteManager.direction.down;
            moveDirection += Vector3.down;
        }



    }
    void Move(Vector3 _moveDirection)
    {
        
        Vector3 moveDirection = _moveDirection.normalized * speed;
        transform.Translate(
            moveDirection.x * Time.deltaTime,
            moveDirection.y * Time.deltaTime,
            moveDirection.z * 0,
            Space.World);
    }
}
