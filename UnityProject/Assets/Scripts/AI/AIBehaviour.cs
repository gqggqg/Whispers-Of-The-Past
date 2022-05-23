using UnityEngine;

namespace Game.AI {

    public class AIBehaviour : MonoBehaviour {

        [SerializeField]
        private Character _character;

        [SerializeField]
        private AIAgent _agent;

        [SerializeField]
        private WaypointContainer _waypointContainer;


        private AIContext _context;


        private void Start() {
            Init();
        }

        private void Update() {
            UpdateLogic();
        }

        private void Init() {
            _context = new AIContext() {
                character = _character,
                waypointContainer = _waypointContainer
            };
        }

        public void UpdateLogic() {
            UpdateContext();
            _agent.UpdateAgent(_context);
            ExecuteTopAction();
        }

        private void UpdateContext() {

        }

        private void ExecuteTopAction() {
            
        }
    }
}
