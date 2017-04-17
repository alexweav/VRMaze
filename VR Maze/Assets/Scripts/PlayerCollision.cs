using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{

    public class PlayerCollision : MonoBehaviour
    {
        GameObject currentCollidingGO;

        // Use this for initialization
        void Start()
        {
          
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider other)
        {           
            currentCollidingGO = GameObject.Find(other.gameObject.transform.parent.name);   
        }

        public GameObject GetCollidingObject()
        {
            return currentCollidingGO;
        }
        
        



    }

}
