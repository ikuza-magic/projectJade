using UnityEngine;
using System.Collections;

public class charaSpriteManager : MonoBehaviour {

    public int motionID;
    public enum direction
    {
        left,
        up,
        right,
        down,
    };
    public direction directionMode;

	MapCreate mapCreate;

    Sprite[,] walk = new Sprite[3,8];
    Sprite[,] stay = new Sprite[2, 8];

    SpriteRenderer spriteRenderer;

    float aniTime;
    int aniID;

    public string charaName;

    // Use this for initialization
    void Start () {
		mapCreate = GameObject.Find ("MapCreate").GetComponent<MapCreate> ();
		this.transform.localScale = new Vector3 (1.0f / mapCreate.spriteSize, 1.0f / mapCreate.spriteSize, 0.0f);
        //走る
        for (int ani = 0; ani < 3; ani++)
        {
            walk[ani, 0] = Resources.Load<Sprite>("Sprite/charaSprite/" + charaName + "/" + charaName + "_left_" + "walk_" + ani);
            walk[ani, 1] = Resources.Load<Sprite>("Sprite/charaSprite/" + charaName + "/" + charaName + "_up_" + "walk_" + ani);
            walk[ani, 2] = Resources.Load<Sprite>("Sprite/charaSprite/" + charaName + "/" + charaName + "_right_" + "walk_" + ani);
            walk[ani, 3] = Resources.Load<Sprite>("Sprite/charaSprite/" + charaName + "/" + charaName + "_down_" + "walk_" + ani);
        }
        //STAY
        for (int ani = 0; ani < 1; ani++)
        {
            stay[ani, 0] = Resources.Load<Sprite>("Sprite/charaSprite/" + charaName + "/" + charaName + "_left_" + "stay_" + ani);
            stay[ani, 1] = Resources.Load<Sprite>("Sprite/charaSprite/" + charaName + "/" + charaName + "_up_" + "stay_" + ani);
            stay[ani, 2] = Resources.Load<Sprite>("Sprite/charaSprite/" + charaName + "/" + charaName + "_right_" + "stay_" + ani);
            stay[ani, 3] = Resources.Load<Sprite>("Sprite/charaSprite/" + charaName + "/" + charaName + "_down_" + "stay_" + ani);
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        aniID = 0;
        aniTime = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
	    if (motionID == 0)
        {
            if (directionMode == direction.left)
                spriteRenderer.sprite = stay[0, 0];
            if (directionMode == direction.up)
                spriteRenderer.sprite = stay[0, 1];
            if (directionMode == direction.right)
                spriteRenderer.sprite = stay[0, 2];
            if (directionMode == direction.down)
                spriteRenderer.sprite = stay[0, 3];

        }
        if (motionID == 1)
        {
            if (directionMode == direction.left)
                spriteRenderer.sprite = walk[aniID, 0];
            if (directionMode == direction.up)
                spriteRenderer.sprite = walk[aniID, 1];
            if (directionMode == direction.right)
                spriteRenderer.sprite = walk[aniID, 2];
            if (directionMode == direction.down)
                spriteRenderer.sprite = walk[aniID, 3];
            aniTime += 8.0f * Time.deltaTime;
            if (0.0f <= aniTime && aniTime < 1.0f) aniID = 0;
            if (1.0f <= aniTime && aniTime < 2.0f) aniID = 1;
            if (2.0f <= aniTime && aniTime < 3.0f) aniID = 2;
            if (3.0f <= aniTime && aniTime < 4.0f) aniID = 1;
            if (4.0f <= aniTime) aniTime = 0.0f;
        }
    }

    int ToDirectionID(int directionNum)
    {
        int getID = 0;
        if (directionNum == 0) getID = 1;
        if (directionNum == 1) getID = 3;
        if (directionNum == 2) getID = 2;
        if (directionNum == 3) getID = 6;
        if (directionNum == 4) getID = 4;
        if (directionNum == 5) getID = 12;
        if (directionNum == 6) getID = 8;
        if (directionNum == 7) getID = 9;
        return getID;
    }
    int ToDirectionNum(int directionID)
    {
        int getID = 0;
        if (directionID == 1) getID = 0;
        if (directionID == 3) getID = 1;
        if (directionID == 2) getID = 2;
        if (directionID == 6) getID = 3;
        if (directionID == 4) getID = 4;
        if (directionID == 12) getID = 5;
        if (directionID == 8) getID = 6;
        if (directionID == 9) getID = 7;
        return getID;
    }

	public direction getDirectionEnum(string d) {
		if (d == "left")
			return direction.left;
		if (d == "right")
			return direction.right;
		if (d == "down")
			return direction.down;
		return direction.up;
	}
}
