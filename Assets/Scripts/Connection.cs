using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Connection : MonoBehaviour
{

    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( GET());
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator GET()
    {
                
        WWW Query = new WWW("http://localhost:53445/?token=123");
        yield return Query;

        if (Query.error != null)
        {
            Debug.Log("Server does not respond : " + Query.error);
        }
        else
        {
            Debug.Log("Server responded : " + Query.text);
            string[] str = Query.text.Split('&');
            text.text = $"GUID = {str[0]}\nID = {str[1]}";
        }

        Query.Dispose();
    }
}

