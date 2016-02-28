using UnityEngine;
using System.Collections;

public class charaSpriteManager : MonoBehaviour {

    public int motionID;
    public int directionID;

    Sprite[,] run = new Sprite[3,8];
    Sprite[,] stay = new Sprite[2, 8];

    SpriteRenderer spriteRenderer;

    float aniTime;
    int aniID;

    public string charaName;

    // Use this for initialization
    void Start () {
        //走る
        for (int ani = 0; ani < 3; ani++)
        {
            for (int d = 0; d < 8; d++)
            {
                run[ani, d] = Resources.Load<Sprite>("Sprite/charaSprite/" + charaName + "_run_" + ToDirectionID(d) + "_" + ani);
            }
        }
        //STAY
        for (int ani = 0; ani < 2; ani++)
        {
            for (int d = 0; d < 8; d++)
            {
                stay[ani, d] = Resources.Load<Sprite>("Sprite/charaSprite/" + charaName + "_stay_" + ToDirectionID(d) + "_" + ani);
            }
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        aniID = 0;
        aniTime = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
	    if (motionID == 0)
        {
            spriteRenderer.sprite = stay[0, ToDirectionNum(directionID)];
        }
        if (motionID == 1)
        {
            spriteRenderer.sprite = run[aniID, ToDirectionNum(directionID)];
            aniTime += 10.0f * Time.deltaTime;
            if (0.0f <= aniTime && aniTime < 1.0f) aniID = 0;
            if (1.0f <= aniTime && aniTime < 2.0f) aniID = 1;
            if (2.0f <= aniTime && aniTime < 3.0f) aniID = 0;
            if (3.0f <= aniTime && aniTime < 4.0f) aniID = 2;
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
}
