using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class LongClickButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler {
    private bool pointerDown;
    private float pointerDownTimer;
    [SerializeField]
    private float requireHoldTime;
    public UnityEvent onLongClick;
    [SerializeField]
    private Image fillImage;
    public GameObject myPlayer;
    AudioSource shootSound;
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        //print("Esta siendo preisonado");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
        

        if (onLongClick != null)
        {

            onLongClick.Invoke();

        }
        Reset();

    }

    private void Update()
    {
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if(pointerDownTimer>requireHoldTime)
            {
               // Reset();

            }
            fillImage.fillAmount = pointerDownTimer / requireHoldTime;
        }
    }
    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
        fillImage.fillAmount = 0;


    }
    private void Start()
    {
        shootSound = GetComponent<AudioSource>();
        onLongClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        if(myPlayer==null)
        myPlayer = GameObject.Find("Local");
        if (pointerDownTimer > requireHoldTime)
        {
            myPlayer.GetComponent<PlayerController>().Cmd_Shoot(requireHoldTime);

        }else
        myPlayer.GetComponent<PlayerController>().Cmd_Shoot(pointerDownTimer);
        shootSound.Play();
    }
}
