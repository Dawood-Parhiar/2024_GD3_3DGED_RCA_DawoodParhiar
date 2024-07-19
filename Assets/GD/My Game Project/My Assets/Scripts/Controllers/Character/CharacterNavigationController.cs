using GD.Selection;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

/// <summary>
/// Supports click to select and click to set waypoint on a mav mesh
/// </summary>
/// <see cref="https://www.youtube.com/watch?v=u2EQtrdgfNs"/>
/// <see cref="https://www.youtube.com/watch?v=dOI-N2QVly8"/>
/// <see cref="https://www.youtube.com/watch?v=CHV1ymlw-P8"/>
/// <seealso cref="https://www.youtube.com/watch?v=FkLJ45Pt-mY&t=158s"/>

namespace GD.Controllers
{
    public class CharacterNavigationController : MonoBehaviour
    {
        [Header("Selection & Waypoint")]
        [SerializeField]
        [Tooltip("Set the game object used to indicate that the character using this controller is currently selected.")]
        private GameObject selectionMarker;

        [SerializeField]
        [Tooltip("Set the game object used to indicate a waypoint for the character using this controller for navigation.")]
        private GameObject waypointMarker;

        [SerializeField]
        [Tooltip("Used by the waypoint when the character is moving. Can be simple empty object.")]
        private GameObject sceneAnchor;

        //[Header("Selected Object")]
        //[SerializeField]
        //[Tooltip("A scriptable object which holds a reference to the currently selected character")]
        //private GameObjectVariable currentlySelectedGameObject;

        [Header("Current State")]
        [SerializeField]
        [ReadOnly]
        private bool isWalking;

        private Animator animator;
        private NavMeshAgent navMeshAgent;
        private IRayProvider rayProvider;
        //private ISelector selector;
        private RaycastHit hitInfo;
        //private bool isSelected;

        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            rayProvider = GetComponent<IRayProvider>();
            // selector = GetComponent<ISelector>();
            animator = GetComponent<Animator>();
        }

        #region Actions -  Set/Clear destination and waypoint

        /// <summary>
        /// Sets navmesh target
        /// </summary>
        /// <param name="target"></param>
        private void SetDestination(Vector3 target)
        {
            navMeshAgent.SetDestination(target);
        }

        /// <summary>
        /// Tests if selector ray intersects with valid destination target, if true set destination
        /// </summary>
        private void ClickDestination()
        {
            rayProvider.CreateRay();
            if (rayProvider.CreateRay().origin != Vector3.zero)
            {
                if (Physics.Raycast(rayProvider.CreateRay(), out hitInfo))
                {
                    SetDestination(hitInfo.point);
                    SetWaypoint();
                    //SetSelected(false);
                    isWalking = true;
                    animator.SetBool("IsWalking", isWalking);
                }

                
            }
            
        }

        /// <summary>
        /// Set the next naviagable waypoint
        /// </summary>
        private void SetWaypoint()
        {
            waypointMarker.SetActive(true);
            waypointMarker.transform.position = navMeshAgent.destination;
            waypointMarker.transform.SetParent(sceneAnchor.transform);
        }

        /// <summary>
        /// Disable waypoint indicator and set waypoint transform back to attached player
        /// </summary>
        private void ClearWaypoint()
        {
            waypointMarker.SetActive(false);
            waypointMarker.transform.SetParent(transform);
        }

        /// <summary>
        /// Set selected and show selection indicator around the player
        /// </summary>
        /// <param name="isSelected"></param>
        
   /*     public void SetSelected(bool isSelected)
        {
            this.isSelected = isSelected;
            selectionMarker.SetActive(isSelected);
        }
    
        #endregion Actions -  Set/Clear destination and waypoint

        #region NEW INPUT - Selection
       
         ///// <summary>
         ///// Called when a player selects the on-screen player avatar
        ///// </summary>
         ///// <param name="context"></param>
         public void OnSelectPlayer(InputAction.CallbackContext context)
         {
             if (context.action.triggered)
            {
                //if player is selected and we click and select a different player
                 if (currentlySelectedGameObject.Value != null
                     && currentlySelectedGameObject.Value != gameObject)
                 {
                     //de-select current
                    currentlySelectedGameObject.Value = null;
                     SetSelected(false);
                 }
       
                 //set selected new player object
                 SetSelected(true);
                 currentlySelectedGameObject.Value = gameObject;
             }
         }
        */
        
         ///// <summary>
         ///// Called when player selects a destination point on the navmesh
         ///// </summary>
         ///// <param name="context"></param>
         public void OnSelectWaypoint(InputAction.CallbackContext context)
         {
             //if a player is selected then determine destination
             //if (isSelected)
             if (context.action.triggered)
                 ClickDestination();
         }
        
         /// <summary>
         /// Move selected player towards active destination point
         /// </summary>
         private void Update()
         {
             if (isWalking && Vector3.Distance(navMeshAgent.destination, transform.position)
                 <= navMeshAgent.stoppingDistance)
             {
                ClearWaypoint();
                isWalking = false;
                 animator.SetBool("IsWalking", isWalking);
             }
         }

        #endregion NEW INPUT - Selection

        #region OLD INPUT - Selection
/*
        private void OnMouseDown()
        {
            if (currentlySelectedGameObject.Value != null
                && currentlySelectedGameObject.Value != gameObject)
            {
                currentlySelectedGameObject.Value = null;
                SetSelected(false);
            }

            SetSelected(true);
            currentlySelectedGameObject.Value = gameObject;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1) && isSelected)
            {
                ClickDestination();
            }

            if (isWalking && Vector3.Distance(navMeshAgent.destination, transform.position) <= navMeshAgent.stoppingDistance)
            {
                ClearWaypoint();
                animator.SetBool("IsWalking", false);
            }
        }
*/
        #endregion OLD INPUT - Selection
    }
}