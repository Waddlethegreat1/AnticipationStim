
using UnityEngine; 
using System.Collections; 

public class LERP_2 : MonoBehaviour 

{

public Vector3 positionToMoveTo; 

void Start()
{
    StartCoroutine(LerpPosition(positionToMoveTo, 1f)); 
}

IEnumerator LerpPosition(Vector3 targetPosition, float duration)
{
    float time = 0; 
    Vector3 startPosition = transform.position; 

    while (time < duration)
    {
        transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration); 
        time += Time.deltaTime; 
        yield return null; 
    }
    transform.position = targetPosition; 

}

}