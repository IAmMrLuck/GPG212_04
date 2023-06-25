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
        public Fish[] scriptableObjects;

        public TMP_Text nameText;
        public Image fishImage;

        public TMP_Text descriptionText;
        public TMP_Text heightText;
        public TMP_Text lengthText;

        private void Start()
        {
            int randomNumber = Random.Range(0, scriptableObjects.Length);
            currentFish = scriptableObjects[randomNumber];

            nameText.text = currentFish.name;

            fishImage.sprite = currentFish.fishPhoto;

            descriptionText.text = currentFish.fishFact;
            heightText.text = currentFish.fishHeight;
            lengthText.text = currentFish.fishLength;

        }


    }
}