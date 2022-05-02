using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSubtitleSetup : MonoBehaviour
{
    [SerializeField] private Transform _Direction;
    [SerializeField] private float _RayRange = 1.3f;
    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit hit;
            if(Physics.Raycast(_Direction.position, _Direction.forward, out hit, _RayRange))
            {
                var controller = hit.transform.GetComponent<SubtitleInteraction>();
                if(controller != null)
                {
                    controller.OnSubtitle();
                }
            }
        }
    }
}
