using UnityEngine;

public class SingletonMonoBehaviourLoader : MonoBehaviour
{
    [SerializeField] private SingletonMonoBehaviour _singletonMonoBehaviour = null;
    [SerializeField] private Transform _parentTransform;
    
    protected void Awake()
    {
        Instantiate();
    }

    private void Instantiate()
    {
        /*Type type = _singletonMonoBehaviour.GetType();
        var instance = GameObject.FindObjectOfType(type);

        if (instance == null)
        {
            SingletonMonoBehaviour singletonMonoBehaviour = Instantiate(_singletonMonoBehaviour, _parentTransform);
        }*/
            
        SingletonMonoBehaviour singletonMonoBehaviour = Instantiate(_singletonMonoBehaviour, _parentTransform);
    }
}