
using UnityEngine; 
using System.Collections; 

public class LERP_test_1 : MonoBehaviour 
{
    public bool isMonster;
    public GameObject[] providers; 
    public GameObject[] neutral;
    public GameObject priest;
    public GameObject SK;
    public bool isPriest;
    public GameObject gamemanage;

public Vector3 positionToMoveTo; 

void Start()
{
    StartCoroutine(LerpPosition(positionToMoveTo, 1f)); 
}

IEnumerator LerpPosition(Vector3 targetPosition, float duration)
{
    yield return new WaitForSeconds(1);
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
    SK = GameObject.FindGameObjectWithTag("scoreKeep");
    PreCreateTrials score = SK.GetComponent<PreCreateTrials>();
    int round = SK.GetComponent<Score>().totalRounds + 1;
    GameManager gamem = gamemanage.GetComponent<GameManager>();
    float val = Random.value;
    if (score.indexes[round - 1] < 6)
    {
        isMonster = true;
        int randomIndex = score.indexes[round - 1];
        gamem.index = randomIndex;
        NewModelPrefabToInstantiate = providers[randomIndex];
        isPriest = false;
    }
    else if (score.indexes[round - 1] == 11)
    {
            gamem.index = 5;
            isMonster = false;
            NewModelPrefabToInstantiate = priest;
            isPriest = true;
    }
    else
    {
        isMonster = false;
        int randomIndex = score.indexes[round - 1] - 6;
        gamem.index = randomIndex;
        NewModelPrefabToInstantiate = neutral[randomIndex];
        isPriest = false;
    }
    Vector3 newPosition = transform.position;
    newPosition.y = 0; 
    transform.position = newPosition; 

    GameObject newModel = Instantiate(NewModelPrefabToInstantiate, transform.position, NewModelPrefabToInstantiate.transform.rotation);
    Destroy(gameObject); 
}

}