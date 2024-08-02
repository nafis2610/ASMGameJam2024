using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlobCharacter : MonoBehaviour
{
    public int TensePower = 100;
    public bool InTense = false;

    public bool IsJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        var test = this.GetComponentInChildren<Component>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J) && !this.IsJumping) {
            var collider = this.GetComponentInChildren<SphereCollider>();
            collider.radius = 1.25f;
            //this.IsJumping = true;
        }
        else if(this.IsJumping) {
            var collider = this.GetComponentInChildren<SphereCollider>();
            collider.radius = 0.14f;
            this.IsJumping = false;
        }


        if(Input.GetKeyDown(KeyCode.Space)) {

            if(this.InTense && this.TensePower != 0) {
                this.TensePower -= 10;
            }

            if(!this.InTense) {

                foreach (SpringJoint joint in this.GetComponentsInChildren<SpringJoint>())
                {
                    joint.spring = 1000;
                }

                this.InTense = true;
            }
        }
        else if(this.TensePower < 100) {
            TensePower += 1;
        }

        if(Input.GetKeyUp(KeyCode.Space)) {
        
            foreach (SpringJoint joint in this.GetComponentsInChildren<SpringJoint>())
            {
                joint.spring = 200;
            }

            this.InTense = false;
        }
    }
}
