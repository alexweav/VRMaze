using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class TeleportorController : MonoBehaviour
    {
        public AudioClip audio_clip;

        private GameObject colGO;
        private bool moveUpDown = false;
        private bool moveUp = false;
       
        private bool Teleported = true;
        private Vector3 colINTPOS, colFLYPOS , TelTo;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(new Vector3(0, 230, 0) * Time.deltaTime);
            movePlayerUpDown();
        }


        private void OnTriggerEnter(Collider other)
        {
            Teleported = other.GetComponent<WalkingScript>().Teleported;
            if (Teleported == false)
            {
                
                Debug.Log(other.name);
                if (other.name == "MainPlayer")
                {

                    this.GetComponent<AudioSource>().clip = audio_clip;
                    this.GetComponent<AudioSource>().Play();

                    moveUpDown = true;
                    other.gameObject.GetComponent<WalkingScript>().freezePlayer = true;
                    moveUp = true;
                    colGO = other.transform.gameObject;
                    colINTPOS = other.transform.position;

                    if (gameObject.name == "TeleportorA")
                    {
                        TelTo = GameObject.Find("TeleportorB").transform.position;
                    }
                    if (gameObject.name == "TeleportorB")
                    {
                        TelTo = GameObject.Find("TeleportorA").transform.position;
                    }

                    TelTo.y = TelTo.y + 4f;
                }

            }
        }

        private void movePlayerUpDown()
        {
            
            if (moveUpDown == true)
            {
                if(moveUp == true && Teleported == false)
                {
                    Debug.Log("Moveing Up");
                   colGO.transform.position = colGO.transform.position + (new Vector3(0, 3f, 0) * Time.deltaTime);
                    if (GameObject.Find("MainPlayer").transform.position.y >= (colINTPOS.y + 4))
                    {
                        colFLYPOS = colGO.transform.position + new Vector3(1,0,1);
                        moveUp = false;
                       
                        GameObject.Find("MainPlayer").GetComponent<WalkingScript>().Teleported = true;
                        colGO.transform.position = TelTo + new Vector3(1.5f, 0, 1.5f);
                    }

                }

                else
                {
                    Debug.Log("Moveing Down");
                    colGO.transform.position = colGO.transform.position - (new Vector3(0f, 3f, 0) * Time.deltaTime);
                    if (colGO.transform.position.y <= (colINTPOS.y))
                    {
                       
                        moveUpDown = false;
                        //colGO.transform.position = colINTPOS;
                        colGO.GetComponent<WalkingScript>().freezePlayer = false;
                        GameObject.Find("MainPlayer").GetComponent<WalkingScript>().Teleported = false;
                        PlaceIcon();
                    }
                }
                
            }

        }

        private void PlaceIcon()
        {
            GameObject Icon =(GameObject)GameObject.Find("Icon");
            Vector3 INTiconPOS = Icon.transform.position;
            Vector3 INTmainplayerPOS = GameObject.Find("MainPlayer").transform.position;
            Vector3 MPPosition = GameObject.Find("MainPlayer").transform.position;
            Icon.transform.position = INTiconPOS + new Vector3((MPPosition.x - INTmainplayerPOS.x) / 10, 0, (MPPosition.z - INTmainplayerPOS.z) / 10);
        }

    }

}
