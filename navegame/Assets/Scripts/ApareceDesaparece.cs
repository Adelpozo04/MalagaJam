using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApareceDesaparece : MonoBehaviour
{

    private SpriteRenderer image_;

    [SerializeField] private float alfaDiference_ = 100;

    [SerializeField] private float currentAlfa_;

    [SerializeField] private float speed_ = 1;

    [SerializeField] private float invisibleTime_ = 3;

    private float elapsedTime = 0;

    private bool invisibleMode_ = false;

    // Start is called before the first frame update
    void Start()
    {
        currentAlfa_ = 0;

        image_ = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!invisibleMode_)
        {
            image_.color = new Color(1, 1, 1, (currentAlfa_ % alfaDiference_) / alfaDiference_);

            currentAlfa_ += speed_;

            if((currentAlfa_ % alfaDiference_) / alfaDiference_ <= 0.1)
            {
                invisibleMode_= true;

                elapsedTime = 0;
            }
        }
        else
        {

            Debug.Log("Invisible: " + elapsedTime + " / " + invisibleTime_);

            if(elapsedTime > invisibleTime_)
            {
                invisibleMode_ = false;

                currentAlfa_ = 0.2f;
            }
            else
            {
                elapsedTime += Time.deltaTime;
            }

        }

        
    }
}
