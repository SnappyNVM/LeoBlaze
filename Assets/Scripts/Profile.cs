using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts
{
    public class Profile : MonoBehaviour
    {
        [SerializeField] private Image _bigGenderIcon;
        [SerializeField] private TMP_InputField _nameField;
        [SerializeField] private TMP_InputField _ageField;
        [SerializeField] private TMP_InputField _weightField;
        [SerializeField] private ProfileGenderSellector _genderSellector;
        [SerializeField] private Image _maleGenderSprite;
        [SerializeField] private Image _femaleGenderSprite;
        [SerializeField] private Sprite _bigMaleGenderSprite;
        [SerializeField] private Sprite _bigFemaleGenderSprite;

        private SaverLoader _progress;
        private bool _activeEdit = false;

        [Inject]
        private void Construct(SaverLoader saverLoader) =>
            _progress = saverLoader;

        private void OnEnable()
        {
            _genderSellector.CurrentGender = _progress.Progress.Gender;
            UpdateView(default);
            Subscribe();
            _activeEdit = false;
            SetEditMode();
        }

        public void ToggleEditMode()
        {
            _activeEdit = !_activeEdit;
            SetEditMode();
            SaveData(default);
        }

        private void SetEditMode()
        {
            _nameField.enabled = _activeEdit;
            _ageField.enabled = _activeEdit;
            _weightField.enabled = _activeEdit;
            _genderSellector.SetActive(_activeEdit);
        }

        private void Subscribe()
        {
            _nameField.onValueChanged.AddListener(SaveData);
            _ageField.onValueChanged.AddListener(SaveData);
            _weightField.onValueChanged.AddListener(SaveData);
            _genderSellector.GenderChanged += SaveData;

            _nameField.onValueChanged.AddListener(UpdateView);
            _ageField.onValueChanged.AddListener(UpdateView);
            _weightField.onValueChanged.AddListener(UpdateView);
            _genderSellector.GenderChanged += UpdateView;
        }

        private void SaveData(string arg0)
        {
            _progress.Progress.Name = _nameField.text;
            _progress.Progress.Age = int.Parse(_ageField.text);
            _progress.Progress.Weight = int.Parse(_weightField.text);
            _progress.Progress.Gender = _genderSellector.CurrentGender;

            _progress.Save();
        }

        private void UpdateView(string str)
        {
            _nameField.text = _progress.Progress.Name;
            _ageField.text = _progress.Progress.Age.ToString();
            _weightField.text = _progress.Progress.Weight.ToString();
            if (_progress.Progress.Gender == Gender.Male)
            {
                _maleGenderSprite.gameObject.SetActive(true);
                _femaleGenderSprite.gameObject.SetActive(false);

                _bigGenderIcon.sprite = _bigMaleGenderSprite;
            }
            else
            {
                _maleGenderSprite.gameObject.SetActive(false);
                _femaleGenderSprite.gameObject.SetActive(true);

                _bigGenderIcon.sprite = _bigFemaleGenderSprite;
            }
        }
    }
}
