using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{

    public GameMaster gameMaster;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray mouse = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouse, out hit)){
                Debug.Log("We hit something???" + hit.collider.name);


                // Ideally you would call some generic "onHit" function for the respective block, but this works for now.
                if(hit.collider.name == "Brick"){ 
                    Destroy(hit.collider.gameObject);
                }
                if (hit.collider.name == "Question"){
                    // TODO: Add coin
                    gameMaster.getCoin();
                }

            }
        }
    }
}
