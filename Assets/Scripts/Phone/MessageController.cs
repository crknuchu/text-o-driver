using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Random = System.Random;

public class MessageController : MonoBehaviour
{
    [Header("Message")] [SerializeField] private Message message;
    [Header("Player")] [SerializeField] private GameObject player;
    
    [Header("UI")]
    [SerializeField] private Text name;
    [SerializeField] private Text question;
    [SerializeField] private Text positiveResponse;
    [SerializeField] private Text negativeResponse;
    [SerializeField] private Button answerPositive;
    [SerializeField] private Button answerNegative;
    [SerializeField] private Image displayControlA;
    [SerializeField] private Image displayControlB;
    private bool hasAnswered;
    public AudioSource audioSource;
    public AudioSource applauseSource;
    public AudioSource booSource;
    
    public bool isPositiveFirst = true;
    public bool isAnswered = false;

    public int timeBeforeDestroy = 2;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        InvokeRepeating("checkIsAnswered", 5, 5.0f);
    }
    
    void Update()
    {
        if (isAnswered)
        {
            question.enabled = false;
            answerPositive.gameObject.SetActive(false);
            answerNegative.gameObject.SetActive(false);
            displayControlA.enabled = false;
            displayControlB.enabled = false;
            StartCoroutine(DestroyMessage(timeBeforeDestroy));
            return;
        }
        UpdateMenuControls();
        HandleInputs();
    }

    void InitUIElements()
    {
        question.text = message.npcQuestion;

        name.text = Message.GetName(message.charachter);
        negativeResponse.text = message.npcNegativeAnswer;
        negativeResponse.enabled = false;
        positiveResponse.text = message.npcPositiveAnswer;
        positiveResponse.enabled = false;
        
        answerNegative.GetComponentInChildren<Text>().text = message.playerNegativeAnswer;
        answerPositive.GetComponentInChildren<Text>().text = message.playerPositiveAnswer;
        
        if (new Random().Next(20) % 2 == 0)
        {
            isPositiveFirst = true;
        }
        else
        {
            isPositiveFirst = false;
            Vector3 temp = answerPositive.GetComponent<Transform>().position;
            answerPositive.GetComponent<Transform>().position = answerNegative.GetComponent<Transform>().position;
            answerNegative.GetComponent<Transform>().position = temp;
        }
    }

    void UpdateMenuControls()
    {
        displayControlA.sprite = SpriteManager.instance.GetSprite(EInputAction.OnActionA, InputManager.instance.GetInputDevice());
        displayControlB.sprite = SpriteManager.instance.GetSprite(EInputAction.OnActionB, InputManager.instance.GetInputDevice());
    }

    public void ShowMessage()
    {
        if (message != null)
        {
            InitUIElements();
        }
    }
    
    public void ShowMessage(Message _message)
    {
        message = _message;
        if (message != null)
        {
            InitUIElements();
            MessageSpawner.instance.isMessageActive = true;
        }
        audioSource.Play();
    }

    void HandleInputs()
    {
        if (isAnswered)
        {
            return;
        }

        if (isPositiveFirst)
        {
            if (InputManager.instance.controls.InGame.OptionA.WasPressedThisFrame())
            {
                //POSITIVE
                positiveResponse.enabled = true;
                negativeResponse.enabled = false;
                BoostPlayer();
                isAnswered = true;
                applauseSource.Play();
            }
            else if (InputManager.instance.controls.InGame.OptionB.WasPressedThisFrame())
            {
                //NEGATIVE
                positiveResponse.enabled = false;
                negativeResponse.enabled = true;
                HurtPlayer();
                isAnswered = true;
                booSource.Play();
            }
        }
        else
        {
            if (InputManager.instance.controls.InGame.OptionA.WasPressedThisFrame())
            {
                //NEGATIVE
                positiveResponse.enabled = false;
                negativeResponse.enabled = true;
                HurtPlayer();
                isAnswered = true;
                booSource.Play();
            }
            else if (InputManager.instance.controls.InGame.OptionB.WasPressedThisFrame())
            {
                //POSITIVE
                positiveResponse.enabled = true;
                negativeResponse.enabled = false;
                BoostPlayer();
                isAnswered = true;
                applauseSource.Play();
            }
        }
        

    }

    void HurtPlayer()
    {
        RumbleManager.instance.RumblePulse(0.15f, 0.15f, 0.1f);
        player.GetComponent<Rating>().RemoveRating(message.removeRating);
    }

    void BoostPlayer()
    {
        player.GetComponent<Rating>().AddRating(message.addRating);
    }
    
    IEnumerator DestroyMessage(float After)
    {
        float elapsedTime = 0f;

        while (elapsedTime < After)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        MessageSpawner.instance.isMessageActive = false;
        Destroy(gameObject);
    }
    
    IEnumerator StartTimer(float time)
    {
        // hasAnswered = false;
        yield return new WaitForSeconds(time);
        if (!isAnswered)
        {
            HurtPlayer();
        }
    }

    void checkIsAnswered()
    {
        if (!isAnswered)
        {
            HurtPlayer();
        }
    }
}
