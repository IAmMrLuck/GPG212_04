using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ConaLuk
{

    public class FishBehaviour : MonoBehaviour
    {

        [SerializeField] private GameObject fish;
        [SerializeField] private GameObject lineCatch;

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
            // is the fish on a hook
            // if it is, then prompt player to reel it in

            // reduce alpha on the bridge
            // the logic for the reel will be in the fishing rod


            // if not, prompt player to through line

        }



    }
}