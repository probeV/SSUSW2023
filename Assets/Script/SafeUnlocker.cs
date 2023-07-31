using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeUnlocker : MonoBehaviour
{
    public GameObject dialobject;

    public int minimumDegrees = 5;
    public int dialNumberAngles = 45;
    private int[] digitAngles = new int[] { 90, 135, 0 };
    private bool[] digitSet = new bool[3];
    private int[] digitPasses = new int[] { 3, 3, 2 };
    private bool[] digitLeftTurn = new bool[] { true, false, true };

    private int passCount;
    private bool passReset;
    private int currentDigit;

    private bool turningLeft;

    private bool unlocked;

    private int oldAngle;
    private int currentAngle;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (unlocked)
        {
            return;
        }

        //reset if you turn the wrong direction
        if (digitLeftTurn[currentDigit] != turningLeft && oldAngle != currentAngle)
        {
            passCount = 0;
            currentDigit = 0;
            for(int i = 0; i < digitSet.Length; i++)
            {
                digitSet[i] = false;
            }
            Debug.Log("Unlock failed, try again");
            //"reset noise
        }
        
        //reset dial rotation back to zero at 360 dagrees
        if(dialobject.transform.localEulerAngles.y > 360 || dialobject.transform.localEulerAngles.y < -360)
        {
            dialobject.transform.localEulerAngles = Vector3.zero;
        }

        //set currentAngle to dial rotation rounded by the sensitivity
        currentAngle = (int)(Mathf.RoundToInt(dialobject.transform.localEulerAngles.y / minimumDegrees) * minimumDegrees);

        //Reset pass so you only increment passCount once
        if(!passReset&& currentAngle!= digitAngles[currentDigit])
        {
            passReset = true;
        }

        //update on dial number chage
        if(currentAngle % dialNumberAngles == 0)
        {
            //if the currentAngle has chaged to a different dial number and the oldAngle is not zero
            if(currentAngle < oldAngle)
            {
                if (oldAngle != 0 && oldAngle != 360)
                    turningLeft = false;
                oldAngle = Mathf.RoundToInt(currentAngle / dialNumberAngles) * dialNumberAngles;
            }
            if(currentAngle > oldAngle)
            {
                if (oldAngle != 0 && oldAngle != 360)
                    turningLeft = true;
                oldAngle = Mathf.RoundToInt(currentAngle / dialNumberAngles) * dialNumberAngles;
            }
        }

        if (currentAngle == digitAngles[currentDigit])
        {
            if (passReset)
            {
                passCount++;
                passReset= false;
            }

            if (passCount >= digitPasses[currentDigit])
            {
                Debug.Log("Digit " + (currentDigit) + " set");
                digitSet[currentDigit] = true;
                if(currentDigit != digitAngles.Length)
                {
                    currentDigit++;
                    turningLeft = digitLeftTurn[currentDigit];
                    passCount = 0;
                }

                //click noise
            }
        }
    }
}
