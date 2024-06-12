
using UnityEngine; 
using System.Collections; 

public class LERP_test_1 : MonoBehaviour 
{
    public bool isMonster;
    public GameObject[] providers; 
    public GameObject neutral;  

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

    ChangeForm(); 
}

void ChangeForm ()
{
    GameObject NewModelPrefabToInstantiate; 
    if (Random.value < 0.3f)
    {
        isMonster = true;
        int randomIndex = Random.Range(0, providers.Length); 
        NewModelPrefabToInstantiate = providers[randomIndex];
    }
    else
    {
        isMonster = false;
        NewModelPrefabToInstantiate = neutral;
    }
    Vector3 newPosition = transform.position;
    newPosition.y = 0; 
    transform.position = newPosition; 

    GameObject newModel = Instantiate(NewModelPrefabToInstantiate, transform.position, NewModelPrefabToInstantiate.transform.rotation);
    Destroy(gameObject); 
}

}