using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissTextScript : MonoBehaviour
{
    Animator animator;
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (text.text == "MISS!!")
        {
            animator.SetBool("isMiss", true);
        }
        else
        {
            animator.SetBool("isMiss", false);
        }
    }
}
