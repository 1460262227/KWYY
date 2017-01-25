using UnityEngine;
using System.Collections;

public class CharContoller : MonoBehaviour
{
    void Start()
    {
        Play("daiji01");
    }

	public void Play(string ani)
    {
        GetComponent<Animator>().Play(ani);
    }
}
