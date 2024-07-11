using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Search;
using UnityEngine;

public class PreCreateTrials : MonoBehaviour
{
    GameObject gamem;
    public int[] indexes;
    public int trialsToBeCreated;
    bool foundGamem;
    public GameObject SK;
    int index2 = 0;
    bool makeNew = false;
    // Start is called before the first frame update
    void Start()
    {
        indexes = new int[trialsToBeCreated];
        foundGamem = false;
        index2 = 0;
        makeNew = false;
    }

    // Update is called once per frame
    void Update()
    {
        gamem = GameObject.FindGameObjectWithTag("gm");
        if(SK.GetComponent<Score>().totalRounds % 100 == 7)
        {
            makeNew = true;
        }
        if(SK.GetComponent<Score>().totalRounds % 100 == 0 && SK.GetComponent<Score>().totalRounds != 0 && makeNew)
        {
            makeNew = false;
            index2 += 100;
            int[] indexes2 = indexes;
            indexes = new int[trialsToBeCreated + index2];
            for(int i = 0; i < index2; i++)
            {
                indexes[i] = indexes2[i];
            }
            foundGamem = false;
        }
        if(gamem != null && !foundGamem)
        {
            foundGamem=true;
            CreateTrials(index2);
        }
    }
    public void CreateTrials(int index2)
    {
        GameManager gameManager = gamem.GetComponent<GameManager>();
        for(int i = index2; i < trialsToBeCreated * gameManager.monsterChance + index2; i++)
        {
            indexes[i] = Random.Range(0, 6);
        }
        for(int i = (int)(trialsToBeCreated * gameManager.monsterChance) + index2; i < trialsToBeCreated - (gameManager.priestChance * trialsToBeCreated) + index2; i++)
        {
            indexes[i] = Random.Range(6, 11);
        }
        for(int i = trialsToBeCreated - (int)(gameManager.priestChance * trialsToBeCreated) + index2; i < trialsToBeCreated + index2; i++) 
        {
            indexes[i] = 11;
        }
        reshuffle(indexes, index2);
        for (int i = index2; i < indexes.Length; i++)
        {
            if (indexes[i] == 11)
            {
                bool notwork = false;
                int index = i + 1;
                while (index < indexes.Length && index <= i + 5)
                {
                    if (indexes[index] == 11)
                    {
                        notwork = true;
                        break;
                    }
                    index++;
                }
                index = i - 1;
                while (index >= index2 && index >= i - 5)
                {
                    if (indexes[index] == 11)
                    {
                        notwork = true;
                        break;
                    }
                    index--;
                }
                if (notwork)
                {
                    int tmp = indexes[i];
                    int r = Random.Range(1 + index2, indexes.Length);
                    indexes[i] = indexes[r];
                    indexes[r] = tmp;
                    i = index2 + 1;
                }
            }
        }
    }
    void reshuffle(int[] indexes, int index2)
    {
        for (int i = index2; i < indexes.Length; i++)
        {
            int tmp = indexes[i];
            int r = Random.Range(index2, indexes.Length);
            indexes[i] = indexes[r];
            indexes[r] = tmp;
        }
    }
}
