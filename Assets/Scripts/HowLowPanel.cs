using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class HowLowPanel : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _nameField;
        [SerializeField] private TMP_InputField _ageField;
        [SerializeField] private TMP_InputField _weightField;
        [SerializeField] private GenderSellector _genderSellector;

        private SaverLoader _progress;

        [Inject]
        private void Construct(SaverLoader progress) =>
            _progress = progress;

        private void Awake() => 
            gameObject.SetActive(!_progress.Progress.Authorized);

        public void SaveProgress()
        {
            _progress.Progress.Name = _nameField.text;
            _progress.Progress.Age = int.Parse(_ageField.text);
            _progress.Progress.Weight = int.Parse(_weightField.text);
            _progress.Progress.Gender = _genderSellector.CurrentGender;
            _progress.Progress.Authorized = true;
            _progress.Save();
        }
    }
}
