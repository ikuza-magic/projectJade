using UnityEngine;
using System.Collections;

public class enemySpriteManager : MonoBehaviour
{

    public enum motion
    {
        stay,
        go,
        back,
        attack,
    };
    public motion motionMode;

    Sprite[] stay = new Sprite[2];
    Sprite[] go = new Sprite[3];
    Sprite[] attack = new Sprite[4];

    SpriteRenderer spriteRenderer;

    float aniTime;
    int aniID;

    public string charaName;

    // Use this for initialization
    void Start()
    {

        //構え
        for (int ani = 0; ani < 2; ani++)
        {
            stay[ani] = Resources.Load<Sprite>("Sprite/enemySprite/" + charaName + "/" + charaName + "_buttle_" + "stay_" + ani);
        }
        //進む
        for (int ani = 0; ani < 3; ani++)
        {
            go[ani] = Resources.Load<Sprite>("Sprite/enemySprite/" + charaName + "/" + charaName + "_buttle_" + "go_" + ani);
        }
        //アタック
        for (int ani = 0; ani < 4; ani++)
        {
            attack[ani] = Resources.Load<Sprite>("Sprite/enemySprite/" + charaName + "/" + charaName + "_buttle_" + "attack_" + ani);
        }
        spriteRenderer = GetComponent<SpriteRenderer>();

        aniID = 0;
        aniTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (motionMode == motion.stay)
        {
            spriteRenderer.sprite = stay[aniID];
            aniTime += 8.0f * Time.deltaTime;
            if (0.0f <= aniTime && aniTime < 1.0f) aniID = 0;
            if (1.0f <= aniTime && aniTime < 2.0f) aniID = 1;
            if (2.0f <= aniTime) aniTime = 0.0f;
        }
        if (motionMode == motion.go)
        {
            spriteRenderer.sprite = go[aniID];
            aniTime += 8.0f * Time.deltaTime;
            if (0.0f <= aniTime && aniTime < 1.0f) aniID = 0;
            if (1.0f <= aniTime && aniTime < 2.0f) aniID = 1;
            if (2.0f <= aniTime && aniTime < 3.0f) aniID = 2;
            if (3.0f <= aniTime && aniTime < 4.0f) aniID = 1;
            if (4.0f <= aniTime) aniTime = 0.0f;
        }
        if (motionMode == motion.attack)
        {
            spriteRenderer.sprite = attack[aniID];
            aniTime += 8.0f * Time.deltaTime;
            if (0.0f <= aniTime && aniTime < 1.0f) aniID = 0;
            if (1.0f <= aniTime && aniTime < 2.0f) aniID = 1;
            if (2.0f <= aniTime && aniTime < 3.0f) aniID = 2;
            if (3.0f <= aniTime && aniTime < 4.0f) aniID = 3;
            if (10.0f <= aniTime) aniTime = 0.0f;
        }
    }
}
