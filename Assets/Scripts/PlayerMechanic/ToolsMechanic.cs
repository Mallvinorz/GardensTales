using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsMechanic : MonoBehaviour
{
    
    [SerializeField] private ParticleSystem hoeSlash;
    [SerializeField] private ParticleSystem sickleSlash;
    [SerializeField] private bool isUsingTools = false;
    [SerializeField] private GameObject shove;
    [SerializeField] private GameObject wateringCan;
    [SerializeField] private GameObject sickle;
    [SerializeField] private string lastUsedAnimation;
    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Animator>().SetBool("IsSickle", false);
        this.GetComponent<Animator>().SetBool("IsWatering", false);
        this.GetComponent<Animator>().SetBool("IsDigging", false);

        if(Input.GetKey(KeyCode.C)) UseTool("hoe");
        if(Input.GetKey(KeyCode.V)) UseTool("water");
        if(Input.GetKey(KeyCode.B)) UseTool("sickle");

        if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PickUp")){
            this.GetComponent<Player>().canMove = false;
        } else{
            this.GetComponent<Player>().canMove = true;
        }        

        isUsingTools = CheckIsAnimationStillPlaying(lastUsedAnimation);

        if(isUsingTools){
            if(lastUsedAnimation == "Sickle") sickle.SetActive(true);
            if(lastUsedAnimation == "watering") wateringCan.SetActive(true);
            if(lastUsedAnimation == "Digging") shove.SetActive(true);
        }else{
            HideTools();
        }

        this.GetComponent<Player>().canMove = !isUsingTools;
    }

    void Animate(){
        this.GetComponent<Animator>().SetBool("IsPickUp", true);
    }
    void AnimateSikle(){
        HideTools();
        lastUsedAnimation = "Sickle";

        sickleSlash.Play();
        this.GetComponent<Animator>().SetBool("IsSickle", true);
    }
    void AnimateWatering(){
        HideTools();
        lastUsedAnimation = "watering";

        this.GetComponent<Animator>().SetBool("IsWatering", true);
    }
    void AnimateDigging(){
        HideTools();
        lastUsedAnimation = "Digging";
        
        hoeSlash.Play();
        this.GetComponent<Animator>().SetBool("IsDigging", true);
    }
    bool CheckIsAnimationStillPlaying(string name){
        return this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(name)? true : false;
    }
    void UseTool(string actionName){
        isUsingTools = true;
        if(actionName == "sickle") AnimateSikle();
        if(actionName == "hoe") AnimateDigging();
        if(actionName == "water") AnimateWatering();
    }
    void HideTools(){
        wateringCan.SetActive(false);
        shove.SetActive(false);
        sickle.SetActive(false);
    }
}