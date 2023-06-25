using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ConaLuk
{

    public class FishBehaviour : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D fishRB;
        [SerializeField] private GameObject fish;
        [SerializeField] private GameObject lineCatch;

        [SerializeField] private GameObject caughtFish;
        [SerializeField] private Transform canvasTransform;
        [SerializeField] private Transform placeToSpawn;

        private bool onHook = false;

        // animations for line
        // 


        // Start is called before the first frame update
        void Start()
        {
            // fishgame.Play();
        }

        // Update is called once per frame
        void Update()
        {

            if(Input.GetKey(KeyCode.Space))
            {
                fish.transform.SetParent(lineCatch.transform);
                fishRB.isKinematic = true;
            }
            // is the fish on a hook
            // if it is, then prompt player to reel it in

            // reduce alpha on the bridge
            // the logic for the reel will be in the fishing rod


            // if not, prompt player to through line

        }

        public void CatchTheFish()
        {
            GameObject currentFish = Instantiate(caughtFish, placeToSpawn);
            currentFish.transform.SetParent(canvasTransform);
        }
    }
}