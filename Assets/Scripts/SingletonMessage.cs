using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMessage : MonoBehaviour
{
    public static SingletonMessage SM;
    public bool joinedPlayer;
    // Start is called before the first frame update
    void Start()
    {
        if (SM == null)
        {
            SM = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
