using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{

    DataManager dataManager;

    public MeshRenderer pad;
    public MeshRenderer ball;

    public Material defoultMat;

    public GameObject go;
    public GameObject go2;
    public Button pressedPadButton;
    public Button presseddBallButton;


    private void Awake()
    {


        CheckMat();
        CheckSavedButton();
        dataManager = FindObjectOfType<DataManager>();
    }



    void CheckMat()
    {
        if (DataManager.paddleMat == null)
        {
            pad.material = defoultMat;
        }
        else
        {
            pad.material = DataManager.paddleMat;
        }

        if (DataManager.ballMat == null)
        {
            ball.material = defoultMat;
        }
        else
        {
            ball.material = DataManager.ballMat;
        }
    }

    void CheckSavedButton()
    {

        if (DataManager.padButton != null)//if is selected color paddle 
        {
            pressedPadButton = DataManager.padButton;
        }

        if (DataManager.ballButton != null)
        {
            presseddBallButton = DataManager.ballButton;
        }

    }
    void ChceckColor()
    {
        if (go.transform.GetChild(0).gameObject.activeSelf == true)
        {
            go.transform.GetChild(0).gameObject.SetActive(false);
        }


    }

    public void SetPaddleColor()
    {

        ChceckColor();

        pressedPadButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        pad.material = pressedPadButton.image.material;

        go = EventSystem.current.currentSelectedGameObject;
        go.transform.GetChild(0).gameObject.SetActive(true);

        DataManager.paddleMat = pressedPadButton.image.material;//store material in var
        DataManager.padButton = pressedPadButton;//save pressed button

        pad.material = pressedPadButton.image.material;

        dataManager.SaveColor();//

    }

    public void SetBallColor()
    {
        if (go2.transform.GetChild(0).gameObject.activeSelf == true)
        {
            go2.transform.GetChild(0).gameObject.SetActive(false);
        }

        presseddBallButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        ball.material = presseddBallButton.image.material;

        go2 = EventSystem.current.currentSelectedGameObject;
        go2.transform.GetChild(0).gameObject.SetActive(true);

        DataManager.ballMat = presseddBallButton.image.material;
        DataManager.ballButton = presseddBallButton;

        ball.material = presseddBallButton.image.material;
        
        dataManager.SaveColor();//
    }

}
