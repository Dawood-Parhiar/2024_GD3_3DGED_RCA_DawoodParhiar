using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

/// <summary>
/// This class provides tween animations using DOTween for a GameObject's position, rotation, and material color.
/// </summary>
/// <remarks>
/// Make sure to have DOTween properly installed in your project.
/// </remarks>
public class TweenedBehaviour : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Check to immediately start tweening before first update on the GameObject in the scene")]
    private bool playOnStart = true;

    [TabGroup("tab1", "Translation Settings")]
    [SerializeField]
    private bool applyTranslation = true;

    [EnableIf("applyTranslation")]
    [TabGroup("tab1", "Translation Settings")]
    [SerializeField]
    [Range(0, 10)]
    [Unit(Units.Second)]
    private float translationDuration = 1;

    [EnableIf("applyTranslation")]
    [TabGroup("tab1", "Translation Settings")]
    [SerializeField]
    private Vector3 translationVector = Vector3.up;

    [EnableIf("applyTranslation")]
    [TabGroup("tab1", "Translation Settings")]
    [SerializeField]
    private Ease translationEaseFunction = Ease.InOutSine;

    [EnableIf("applyTranslation")]
    [TabGroup("tab1", "Translation Settings")]
    [SerializeField]
    [Range(-1, 20)]
    private int translationLoopCount = -1;

    [TabGroup("tab1", "Rotation Settings")]
    [SerializeField]
    private bool applyRotation = true;

    [EnableIf("applyRotation")]
    [TabGroup("tab1", "Rotation Settings")]
    [SerializeField]
    [Range(0, 10)]
    [Unit(Units.Second)]
    private float rotationDuration = 1;

    [EnableIf("applyRotation")]
    [TabGroup("tab1", "Rotation Settings")]
    [SerializeField]
    private Vector3 rotationVector = new Vector3(0, 180, 0);

    [EnableIf("applyRotation")]
    [TabGroup("tab1", "Rotation Settings")]
    [SerializeField]
    private Ease rotateEaseFunction = Ease.Linear;

    [EnableIf("applyRotation")]
    [TabGroup("tab1", "Rotation Settings")]
    [SerializeField]
    [Range(-1, 20)]
    private int rotationLoopCount = -1;

    [TabGroup("tab1", "Scale Settings")]
    [SerializeField]
    private bool applyScale = true;

    [EnableIf("applyScale")]
    [TabGroup("tab1", "Scale Settings")]
    [SerializeField]
    [Range(0, 10)]
    [Unit(Units.Second)]
    private float scaleDuration = 1;

    [EnableIf("applyScale")]
    [TabGroup("tab1", "Scale Settings")]
    [SerializeField]
    [Range(0.1f, 2)]
    private float scaleFactor = 1.1f;

    [EnableIf("applyScale")]
    [TabGroup("tab1", "Scale Settings")]
    [SerializeField]
    private Ease scaleEaseFunction = Ease.InOutSine;

    [EnableIf("applyScale")]
    [TabGroup("tab1", "Scale Settings")]
    [SerializeField]
    [Range(-1, 20)]
    private int scaleLoopCount = -1;

    [TabGroup("tab1", "Color Settings")]
    [SerializeField]
    private bool applyColor = true;

    [EnableIf("applyColor")]
    [TabGroup("tab1", "Color Settings")]
    [SerializeField]
    [Range(0, 10)]
    [Unit(Units.Second)]
    private float colorDuration = 1;

    [EnableIf("applyColor")]
    [TabGroup("tab1", "Color Settings")]
    [SerializeField]
    [ColorUsage(true)]
    private Color targetColor = Color.red;

    [EnableIf("applyColor")]
    [TabGroup("tab1", "Color Settings")]
    [SerializeField]
    private Ease colorEaseFunction = Ease.InOutCubic;

    [EnableIf("applyColor")]
    [TabGroup("tab1", "Color Settings")]
    [SerializeField]
    [Range(-1, 20)]
    private int colorLoopCount = -1;

    private Material material;

    private void Start()
    {
        if (playOnStart)
            StartTweening();
    }

    /// <summary>
    /// We can also call this method using an event
    /// </summary>
    public void StartTweening()
    {
        if (applyTranslation)
        {
            // Tween the local position of the GameObject along the moveVector
            gameObject.transform.DOLocalMove(gameObject.transform.localPosition + translationVector, translationDuration)
                .SetLoops(translationLoopCount, LoopType.Yoyo)  // Yoyo loop (back and forth)
                .SetEase(translationEaseFunction);  // Set the ease function for the movement
        }

        if (applyRotation)
        {
            // Tween the local rotation of the GameObject by 180 degrees around the y-axis
            gameObject.transform.DOLocalRotate(rotationVector, rotationDuration)
                .SetLoops(rotationLoopCount, LoopType.Incremental)  // Incremental loop (rotates by increments)
                .SetEase(rotateEaseFunction);  // Set the ease function for rotation
        }

        if (applyScale)
        {
            var originalScale = gameObject.transform.localScale;

            // Tween the local scale of the GameObject
            gameObject.transform.DOBlendableScaleBy(scaleFactor * originalScale, scaleDuration)
                .SetLoops(scaleLoopCount, LoopType.Yoyo)  // Incremental loop (rotates by increments)
                .SetEase(scaleEaseFunction);  // Set the ease function for rotation
        }

        if (applyColor)
        {
            // Get the material of the GameObject's Renderer component
            material = gameObject.GetComponent<Renderer>().material;

            // Tween the color of the material to red
            material.DOColor(targetColor, colorDuration)
                .SetLoops(colorLoopCount, LoopType.Yoyo)  // Yoyo loop for color change
                .SetEase(colorEaseFunction);  // Set the ease function for color change
        }
    }
}

/*
public abstract class BaseTween : ScriptableGameObject
{
    [Range(0, 10)]
    [Unit(Units.Second)]
    public float Duration = 1;

    [Range(-1, 20)]
    public int LoopCount = -1;

    public LoopType LoopType = LoopType.Yoyo;

    public Ease EaseFunction = Ease.InOutSine;

    public virtual void Start(GameObject target)
    {
    }
}

[CreateAssetMenu(fileName = "TranslationTween",
menuName = "DkIT/Scriptable Objects/Tweening/Translation", order = 1)]
public class TranslationTween : BaseTween
{
    public Vector3 TranslationVector = Vector3.up;

    public override void Start(GameObject target)
    {
        if (Duration != 0)
        {
            target.transform.DOLocalMove(target.transform.localPosition + TranslationVector, Duration)
                .SetLoops(LoopCount, LoopType)
                .SetEase(EaseFunction);
        }
    }
}
*/