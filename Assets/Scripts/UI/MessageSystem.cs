using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageSystem : MonoBehaviour
{
    public static MessageSystem instance;
    


    private void Awake()
    {
        instance = this;
    }

    [SerializeField] GameObject damageMessage;

    List<TMPro.TextMeshPro> messagePool;

    int objectCount = 10;
    int count;

    private void Start()
    {

        messagePool = new List<TMPro.TextMeshPro>();

        for(int i = 0; i < objectCount; i++) 
        {
            Populate();
        }
    }

    public void Populate() 
    {
        GameObject go = Instantiate(damageMessage, transform);
        messagePool.Add(go.GetComponent<TMPro.TextMeshPro>());
        go.SetActive(false);
    }

    public void PostMessage(string text, Vector3 worldPosition) //calls damage text messages or general pop ups
    {
        messagePool[count].gameObject.SetActive(true);
        messagePool[count].transform.position = worldPosition;
        messagePool[count].text = text;
        count += 1;

        if(count >= objectCount) //sets limit of messages to reuse equal to objectCount (10), and resets it when >= to (10)
        {
            count = 0;
        }
    }
}
