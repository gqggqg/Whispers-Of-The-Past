using UnityEngine;
using System.Collections;

namespace Game {
	public class Unit : MonoBehaviour {
		[SerializeField]
		Movement _movement;
		[SerializeField]
		Flipper _flipper;
		[SerializeField]
		private Transform _target;

		public float speed = 20;
		private float _freuqency = 1;
		private float _nextUpdate = 0;

		Vector2[] path;
		int targetIndex;

		private bool _isMoving = false;

		public Transform Target {
			get => _target;
            set {
				_target = value;
            }
        }
        private void Start() {
            _movement.BaseSpeed = speed;
        }
		void Update() {
			if (_target == null) {
				return;
            }
			if (_isMoving) {
				if (Time.time >= _nextUpdate) {
					_nextUpdate = Time.time + _freuqency;
					UpdatePath();
				}
				if (path != null) {
					StartCoroutine("FollowPath");
				}
			}
			StopCoroutine("FollowPath");
		}

        void UpdatePath() {
			path = Pathfinding.RequestPath(transform.position, _target.position);
		}
		public void SetMovingState(bool movingState) {
			_isMoving = movingState;
		}

		IEnumerator FollowPath() {
			Vector2 currentWaypoint = path[0];

			while (true) {
				if ((Vector2)transform.position == currentWaypoint) {
					targetIndex++;
					if (targetIndex >= path.Length) {
						yield break;
					}
					currentWaypoint = path[targetIndex];
				}
				_flipper.FlipToDirection(transform, currentWaypoint - (Vector2)transform.position);
				transform.position = Vector2.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);

				yield return null;

			}
		}

		public void OnDrawGizmos() {
			if (path != null) {
		
				//Gizmos.DrawCube((Vector3)path[targetIndex], Vector3.one * .5f);
				for (int i = targetIndex; i < path.Length; i++) {
					Gizmos.color = Color.black;
					Gizmos.DrawCube((Vector3)path[i], Vector3.one *.5f);
					Debug.Log(i);

					if (i == targetIndex) {
						Gizmos.DrawLine(transform.position, path[i]);
					}
					else {
						Gizmos.DrawLine(path[i - 1], path[i]);
					}
				}
				Gizmos.DrawCube(transform.position, Vector3.one * .5f);
			}
		}
	}
}