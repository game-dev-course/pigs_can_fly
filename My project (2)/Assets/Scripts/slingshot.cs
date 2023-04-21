using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class slingshot : MonoBehaviour
{
    public string lose_scene;
    public string next_scene;
    [SerializeField] public LineRenderer[] lineRenderers;
    [SerializeField] public Transform[] stripPositions;
    [SerializeField] public Transform center;
    [SerializeField] public Transform idlePosition;
    Vector3 currpos;
    bool is_mouse_down = false;
    public float max_l;

    public GameObject birdprefab;
    float birdPositionOffset;
    Rigidbody2D bird;
    Collider2D birdCollider;
    public int pigs_amount = 0;
    public float force;

    public GameObject textmeshpro;
    TextMeshProUGUI textmp;
    // Start is called before the first frame update
    void Start()
    {
        textmp = textmeshpro.GetComponent<TextMeshProUGUI>();
        textmp.text = pigs_amount.ToString();
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);

        CreateBird();
        ResetStrips();
    }

    void CreateBird()
    {
        bird = Instantiate(birdprefab).GetComponent<Rigidbody2D>();
        birdCollider = bird.GetComponent<Collider2D>();
        birdCollider.enabled = false;

        bird.isKinematic = true;

        ResetStrips();
    }


    private void OnMouseDown()
    {
        is_mouse_down = true;
    }
    private void OnMouseUp()
    {
        is_mouse_down = false;
        Shoot();
        ResetStrips();
    }
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            SceneManager.LoadScene(next_scene);
        }
        if (GameObject.FindGameObjectsWithTag("Player").Length == 0 && pigs_amount == 0)
        {
            SceneManager.LoadScene(lose_scene);
        }
        if (is_mouse_down)
        {
            Vector3 mousepos = Input.mousePosition;
            mousepos.z = 10;

            mousepos = Camera.main.ScreenToWorldPoint(mousepos);
            currpos = mousepos;
            currpos = center.position + Vector3.ClampMagnitude(currpos
                - center.position, max_l);
            SetStrips(currpos);
            if (birdCollider)
            {
                birdCollider.enabled = true;
            }
        }

    }
    void ResetStrips()
    {
        currpos = idlePosition.position;
        SetStrips(idlePosition.position);
    }
    void SetStrips(Vector3 position)
    {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);

        if (bird)
        {
            bird.transform.position = position;

        }
    }
    void Shoot()
    {
        if (pigs_amount > 0)
        {
            pigs_amount--;
            textmp.text = pigs_amount.ToString();
            bird.isKinematic = false;
            Vector3 birdForce = (currpos - center.position) * force * -1;
            bird.velocity = birdForce;

            bird = null;
            birdCollider = null;
        }
        if (pigs_amount != 0)
        {
            Invoke("CreateBird", 1);
        }

    }

}
