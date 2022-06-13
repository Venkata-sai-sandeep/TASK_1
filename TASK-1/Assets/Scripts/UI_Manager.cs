using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Cube;
    public GameObject Cylinder;
    public GameObject Sphere;
    public GameObject _cubeToggle;
    public GameObject _CylinderToggle;
    public GameObject _SphereToggle;
    public UI_Manager _uiManager;
    public Canvas canvas;

    [SerializeField]
    private float _speed = 5f;

    [SerializeField]
    private int _SphereCount = 0;
    [SerializeField]
    private int _CubeCount = 0;
    [SerializeField]
    private int _CylinderCount = 0;

    

    [SerializeField]
    private Toggle cubeToggle;

    [SerializeField]
    private Toggle sphereToggle;

    [SerializeField]
    private Toggle cylinderToggle;


    private Renderer cubeRenderer;
    private Renderer sphereRenderer;
    private Renderer cylinderRenderer;
    private Color cubecolor;
    private Color spherecolor;
    private Color cylindercolor;


   
    private void Start()
    {
        
        cubeRenderer = Cube.GetComponent<Renderer>();
        sphereRenderer = Sphere.GetComponent<Renderer>();
        cylinderRenderer = Cylinder.GetComponent<Renderer>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

        }

        


        checkToggle();
        
        checkMovement();
    }
    public void SphereSpawnfun()
    {
        Vector3 location = new Vector3(Random.Range(-16f, 32f), Random.Range(-13f, 13f), 0);
        Instantiate(Sphere, location, Quaternion.identity);
        _SphereCount++;
    }

    public void CubeSpawnfun()
    {
        Vector3 location = new Vector3(Random.Range(-16f, 32f), Random.Range(-13f, 13f), 0);
        Instantiate(Cube, location, Quaternion.identity);
        _CubeCount++;
    }

    public void CylinderSpawnfun()
    {
        Vector3 location = new Vector3(Random.Range(-16f, 32f), Random.Range(-13f, 13f), 0);
        Instantiate(Cylinder, location, Quaternion.identity);
        _CylinderCount++;
    }
  
    public void checkToggle()
    {
        if(_CubeCount > 0)
        {
            _cubeToggle.SetActive(true);
        }

        if (_CylinderCount > 0)
        {
            _CylinderToggle.SetActive(true);
        }

        if (_SphereCount > 0)
        {
            _SphereToggle.SetActive(true);
        }
    }

    public Color myColor;
    MeshRenderer myRender;
    public void changeCube()
    {
        
        if (cubeToggle.isOn)
        {
            cubecolor = new Color(0, 255, 241, 1f);
            cubeRenderer.sharedMaterial.SetColor("_Color", cubecolor);
        }
        else
        {
            cubecolor = new Color(255, 255, 255, 1f);
            cubeRenderer.sharedMaterial.SetColor("_Color", cubecolor);
        }

        
    }

    public void changeCylinder()
    {
        if (cylinderToggle.isOn)
        {
            //Debug.Log("Sphere");
            cylindercolor = new Color(124, 252, 0, 1f);
            cylinderRenderer.sharedMaterial.SetColor("_Color", cylindercolor);
        }
        else
        {
            cylindercolor = new Color(255, 255, 255, 1f);
            cylinderRenderer.sharedMaterial.SetColor("_Color", cylindercolor);
        }
    }

    public void changeSphere()
    {
        //Debug.Log("Sphere");
        if(sphereToggle.isOn)
        {
            //Debug.Log("Sphere");
            spherecolor = new Color(124, 252, 0, 1f);
            sphereRenderer.sharedMaterial.SetColor("_Color", spherecolor);
        }
        else
        {
            spherecolor = new Color(255, 255, 255, 1f);
            sphereRenderer.sharedMaterial.SetColor("_Color", spherecolor);
        }
    }

    public void checkMovement()
    {
        float hInupt = CrossPlatformInputManager.GetAxis("Horizontal");// Input.GetAxis("Horizontal");
        float vInput = CrossPlatformInputManager.GetAxis("Vertical");// Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(hInupt, vInput);

        transform.Translate(direction * _speed * Time.deltaTime);
        if (transform.position.y >= 13)
        {
            transform.position = new Vector3(transform.position.x, 13.0f, 0);
        }
        else if (transform.position.y <= -13.0)
        {
            transform.position = new Vector3(transform.position.x, -13.0f, 0);
        }
        if (transform.position.x > 32f)
        {
            transform.position = new Vector3(32f, transform.position.y, 0);
        }
        else if (transform.position.x <= -16.0f)
        {
            transform.position = new Vector3(-16f, transform.position.y, 0);
        }
    }

    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    
    void OnMouseDrag()
    {
        
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
     
        

    }

    



}
