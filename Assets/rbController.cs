using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rbController : MonoBehaviour
{
    public Rigidbody rb;
    [Range(0, 200)]
    public float forceFW;

    [Range(0, 100)]
    public float forceUP;

    [Range(0,1)]
    public float Yaw;

    public Transform[] VerticalProp;
    public Transform[] HorizontalProp;
    public CinemachineFreeLook cm1;
    public CinemachineFreeLook cm2;
    public GameObject[] bubbleParticle;
    public Light[] lights;
    bool fpv;
    bool lightStatus;
    public bool bubbleEffect;
    public GameObject kontroller;

    void Start(){
        bubbleParticle[0].GetComponent<ParticleSystem>().enableEmission = false;
    }

    void Update(){
        Vector3 yEU = this.transform.eulerAngles;
        if (Input.GetKey(KeyCode.W)) {
            rb.AddForce(rb.transform.forward  * forceFW);
            for (int i = 0; i < HorizontalProp.Length; i++) {
                Vector3 hpRotate = HorizontalProp[i].eulerAngles;
                hpRotate.z += 30;
                HorizontalProp[i].eulerAngles = hpRotate;
                
            }
            if (rb.velocity.magnitude > 0.5f && bubbleEffect)
                bubbleParticle[0].GetComponent<ParticleSystem>().enableEmission = true;
            else
                bubbleParticle[0].GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (Input.GetKey(KeyCode.S)) {
            rb.AddForce(rb.transform.forward * -forceFW);
            for (int i = 0; i < HorizontalProp.Length; i++) {
                Vector3 hpRotate = HorizontalProp[i].eulerAngles;
                hpRotate.z -= 30;
                HorizontalProp[i].eulerAngles = hpRotate;

            }
            if (rb.velocity.magnitude > 0.5f && bubbleEffect)
                bubbleParticle[0].GetComponent<ParticleSystem>().enableEmission = true;
            else
                bubbleParticle[0].GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (Input.GetKey(KeyCode.A)) {
            rb.AddForce(rb.transform.right * -forceFW);
            if (rb.velocity.magnitude > 0.5f && bubbleEffect)
                bubbleParticle[0].GetComponent<ParticleSystem>().enableEmission = true;
            else
                bubbleParticle[0].GetComponent<ParticleSystem>().enableEmission = false;

        } 
        if (Input.GetKey(KeyCode.D)) { 
            rb.AddForce(rb.transform.right * forceFW);
            if (rb.velocity.magnitude > 0.5f && bubbleEffect)
                bubbleParticle[0].GetComponent<ParticleSystem>().enableEmission = true;
            else
                bubbleParticle[0].GetComponent<ParticleSystem>().enableEmission = false;

        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
           yEU.y  -= Yaw;
            this.transform.eulerAngles = yEU;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            yEU.y += Yaw;
            this.transform.eulerAngles = yEU;
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            rb.AddForce(rb.transform.up * 100);
            for (int i = 0; i < VerticalProp.Length; i++) {
                Vector3 vpRotate = VerticalProp[i].eulerAngles;
                vpRotate.z += 30;
                VerticalProp[i].eulerAngles = vpRotate;

            }
            if (rb.velocity.magnitude > 0.5f && bubbleEffect)
                bubbleParticle[0].GetComponent<ParticleSystem>().enableEmission = true;
            else
                bubbleParticle[0].GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            rb.AddForce(rb.transform.up * -100);
            for (int i = 0; i < VerticalProp.Length; i++) {
                Vector3 vpRotate = VerticalProp[i].eulerAngles;
                vpRotate.z -= 30;
                VerticalProp[i].eulerAngles = vpRotate;

            }
            if (rb.velocity.magnitude > 0.5f && bubbleEffect)
                bubbleParticle[0].GetComponent<ParticleSystem>().enableEmission = true;
            else
                bubbleParticle[0].GetComponent<ParticleSystem>().enableEmission = false;
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            if (!fpv) {
                cm1.Priority = 1;
                cm2.Priority = 0;
                fpv = true;
            } else {
                cm1.Priority = 0;
                cm2.Priority = 1;
                fpv = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.L)) {
            if (!lightStatus) {
                lights[0].enabled = true;
                lights[1].enabled = true;
                lightStatus = true;
            } else {
                lights[0].enabled = false;
                lights[1].enabled = false;
                lightStatus = false;
            }

        }
        if (Input.GetKeyDown(KeyCode.B)) {
            if (bubbleEffect)
                bubbleEffect = false;
            else
                bubbleEffect = true;
        }

        if (Input.GetKeyDown(KeyCode.K)) {
            if(!kontroller.gameObject.activeSelf)
                kontroller.gameObject.SetActive(true);
            else
                kontroller.gameObject.SetActive(false);

        }

        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}
