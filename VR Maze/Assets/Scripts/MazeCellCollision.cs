using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{

    public class MazeCellCollision : MonoBehaviour
    {
        public GameObject currentCollidingGO;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            //Debug.Log(collision.gameObject);
            
           // HUDMiniMap workingMiniMap = GameObject.Find("MiniMapMaze").GetComponent<HUDMiniMap>;

        }
        
    }

}
