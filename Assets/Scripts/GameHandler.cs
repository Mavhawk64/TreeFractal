using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public int depth = 10;
    public int splitNumber = 2;
    // Start is called before the first frame update
    void Start()
    {
        depth--;
        for(int i = 0; i < splitNumber; i++) {
            if(depth > 0) {
                GameObject clone = Instantiate(gameObject);
                var cloneHandler = clone.GetComponent<GameHandler>();
                cloneHandler.SendMessage("Generate", Pair(i, splitNumber));
            }
        }
    }

    private int Pair(int a, int b) {
        return (a + b) * (a + b + 1) / 2 + b;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
