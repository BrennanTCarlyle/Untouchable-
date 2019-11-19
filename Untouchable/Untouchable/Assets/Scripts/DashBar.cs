using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBar : MonoBehaviour
{
    public Image barImage;
    private Movement move;
    //private Meter afuckingmeter;

    private void Awake()
    {
        barImage = transform.Find("bar").GetComponent<Image>();

        barImage.fillAmount = 0;

        //afuckingmeter = new Meter();
    }

    private void Start()
    {
        move = GetComponent<Movement>();
    }

    private void Update()
    {
        //afuckingmeter.Update();

        //barImage.fillAmount = afuckingmeter.GetNormalizedMeter();
    }

    /*public class Meter : MonoBehaviour
    {
        private const int MAX_METER = 100;
        private Movement move;
        private float gainMeter;
        private float currentMeter;


        void Start()
        {
            move = GetComponent<Movement>();
        }

        public Meter()
        {
            gainMeter = 0;
            
        }

        public void Update()
        {
            //gainMeter += move.meter;
            currentMeter = move.meter;
        }

        public float GetNormalizedMeter()
        {
            return currentMeter;
        }
    }*/


}
