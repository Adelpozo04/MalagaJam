using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent : ShipComponent
{
    #region parameters
    #endregion

    #region references
    /*[SerializeField]
    private Material cameraInterference;*/
    private VHSPostProcessEffect effect;

    [SerializeField] private AudioClip destroyClip;

    [SerializeField] GameObject estatica_;

    [SerializeField] GameObject estaticaHud_;
    #endregion

    #region methods
    override public void GotHit()
    {
        if (compLife_ == 1)
        {
            GetComponent<Animator>().SetTrigger("Destroy");
            //cameraInterference.SetFloat("_Clarity", 0.04f);

            //if(Application.platform != RuntimePlatform.WebGLPlayer)
            //{
            //    effect.enabled = true;
            //}
            //else
            //{
                estaticaHud_.SetActive(true);
                estatica_.SetActive(true);
            //}
            


        }
        else
        {
            myShipMng_.sufferDamage((compLife_ - 1) * fuelLoss_);
        }
        compLife_--;
        SFXManager.instance.playSFXClip(destroyClip, transform, 1f);
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //cameraInterference.SetFloat("_Clarity", 0f);
        effect = Camera.main.gameObject.GetComponent<VHSPostProcessEffect>();
        effect.enabled = false;
        myShipMng_ = this.transform.parent.gameObject.GetComponent<ShipManager>();

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
