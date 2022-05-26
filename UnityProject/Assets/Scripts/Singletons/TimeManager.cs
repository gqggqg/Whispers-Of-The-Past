using UnityEngine;
using Game.AI;
using Utils;

namespace Game {

    public class TimeManager : Singleton<TimeManager> {

        [SerializeField]
        private Weekday _weekday;

		[SerializeField]
		[Range(0, 24)]
		private int _startHour;

		[SerializeField]
		private bool _randomizeTime;

		[SerializeField]
		[Range(-10, 100)]
		private int _speed;

		[SerializeField]
		private AIFloatProperty _hoursProperty;

		[SerializeField]
		private AIBooleanProperty _weekendProperty;


		private int _startDay;

		private float _totalMinutes;

		private float _days;
		private float _hours;
		private float _minutes;


		public Weekday Weekday => (Weekday)_days;
		public int Hours => (int)_hours;
		public int Minutes => (int)_minutes;


		protected override void Awake() {
			base.Awake();

			TimeUtility.Speed = _speed;

			_startHour = _randomizeTime ? Random.Range(0, 25) : _startHour;
			_startDay = (int)_weekday;

			_days = _startDay;
			_hours = _startHour;
			_minutes = 0;

			_totalMinutes = _hours * 60;
		}

        private void Start() {
            UpdateProperties();
        }

        private void Update() {
			_totalMinutes += TimeUtility.DeltaTime;

			var totalHours = _totalMinutes / 60 + _startHour;
			var totalDays = _totalMinutes / 1440 + _startDay;

			_minutes = _totalMinutes % 60;
			_hours = totalHours % 24;
			_days = totalDays % 7;

			UpdateProperties();
		}

		private void LateUpdate() {
			TimeUtility.Speed = _speed;
        }

		private void UpdateProperties() {
			_hoursProperty.CurrentValue = _hours;
			_weekendProperty.CurrentValue = (Weekday == Weekday.Sunday || Weekday == Weekday.Saturday);
        }
	}
}
