using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class charaMoveManager : MonoBehaviour {
    public bool isControl;

    charaSpriteManager SpriteManager;
    Vector3 moveDirection;
	MapCreate mapCreate;
	int mapx = 1;
	int mapy = 1;
	public float modifyHeightYScale = 0.25f;

	enumDefine enumDefine;


	// Use this for initialization
	void Start () {
		enumDefine = GameObject.Find ("MapCreate").GetComponent<enumDefine>();

        moveDirection = Vector3.zero;
        SpriteManager = GetComponent<charaSpriteManager>();
		mapCreate = GameObject.Find ("MapCreate").GetComponent<MapCreate> ();

		float [] xy = mapCreate.getXYPosition(mapx,mapy);
		float z = mapCreate.getZPosition (mapx, mapy);
		Debug.Log (" " + xy[0] + " " +xy[1] + " " + z);
		transform.position = new Vector3 (xy [0], xy [1] + mapCreate.chipSize*modifyHeightYScale, z-0.001f);
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
        }
	
	}



    void KeyInput(int keyDirectionID)
    {
		if (keyDirectionID == 1) {
			SpriteManager.motionID = 1;
			SpriteManager.directionMode = charaSpriteManager.direction.left;
			Move (charaSpriteManager.direction.left);
		} else if (keyDirectionID == 2) {
			SpriteManager.motionID = 1;
			SpriteManager.directionMode = charaSpriteManager.direction.up;
			Move (charaSpriteManager.direction.up);
		} else if (keyDirectionID == 4) {
			SpriteManager.motionID = 1;
			SpriteManager.directionMode = charaSpriteManager.direction.right;
			Move (charaSpriteManager.direction.right);
		} else if (keyDirectionID == 8) {
			SpriteManager.motionID = 1;
			SpriteManager.directionMode = charaSpriteManager.direction.down;
			Move (charaSpriteManager.direction.down);
		} else {
			SpriteManager.motionID = 0;
		}
    }
	void Move(charaSpriteManager.direction direction)
    {
		int nextX = 0, nextY = 0;
		if (direction == charaSpriteManager.direction.up) {
			nextX = mapx + 0;
			nextY = mapy + 1;
		}
		if (direction == charaSpriteManager.direction.down) {
			nextX = mapx + 0;
			nextY = mapy - 1;
		}
		if (direction == charaSpriteManager.direction.right) {
			nextX = mapx + 1;
			nextY = mapy + 0;
		}
		if (direction == charaSpriteManager.direction.left) {
			nextX = mapx - 1;
			nextY = mapy + 0;
		}

		if (mapCreate.canThrough (nextX, nextY)) {
			StartCoroutine (moveCoroutine(nextX,nextY));
		}
    }

	private IEnumerator moveCoroutine(int nextX,int nextY) {
		SpriteManager.motionID = 1;
		isControl = false;
		float [] xy = mapCreate.getXYPosition(mapx,mapy);
		float[] axy = mapCreate.getXYPosition (nextX, nextY);
		float z = mapCreate.getZPosition (mapx, mapy);
		float az = mapCreate.getZPosition (nextX, nextY);
		if (az > z)
			az = z;
		for (float i = 0.0f; i < 1.0f; i += 1.0f * Time.deltaTime*5) {
			transform.position = new Vector3 (xy [0] * (1 - i) + axy [0] * i, xy [1] * (1 - i) + axy [1] * i  + mapCreate.chipSize*modifyHeightYScale, az-0.001f);
			yield return null;
		}
		transform.position = new Vector3 (axy [0], axy [1] + mapCreate.chipSize*modifyHeightYScale, az-0.001f);

		mapx = nextX;
		mapy = nextY;

		//移動後の強制アクションをチェック
		Dictionary<string,string> action = mapCreate.getRelatedAction (mapx, mapy);
		if (enumDefine.getChipActionKindEnum (action ["kind"]) == ChipActionKind.MoveScene) {
			//シーン移動
			int moveToSceneId = int.Parse (action ["toScene"]);
			mapCreate.sceneId = moveToSceneId;
			mapCreate.loadMap ();
			mapx = int.Parse (action ["toJ"]);
			mapy = mapCreate.mapYSize - int.Parse (action ["toI"]) - 1;
			SpriteManager.directionMode = SpriteManager.getDirectionEnum (action ["toD"]);
			float [] xy2 = mapCreate.getXYPosition(mapx,mapy);
			float z2 = mapCreate.getZPosition (mapx, mapy);
			transform.position = new Vector3 (xy2[0],xy2[1] + mapCreate.chipSize*modifyHeightYScale, z2-0.001f);
		}

		isControl = true;
	}
}
