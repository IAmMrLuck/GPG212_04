using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ConaLuk
{
    public class FishDisplay : MonoBehaviour
    {

        public Fish currentFish;

        public TMP_Text nameText;
        public Image fishImage;

        public TMP_Text descriptionText;



        private void Start()
        {


            nameText.text = currentFish.name;

            fishImage.sprite = currentFish.fishPhoto;

            descriptionText.text = currentFish.fishFact;


        }


    }
}