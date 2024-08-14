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
        [SerializeField] private Color _onEditColor;

        private bool _viewSetted = false;

        private Color _prevColor;
        private SaverLoader _progress;
        private bool _activeEdit = false;

        [Inject]
        private void Construct(SaverLoader saverLoader) =>
            _progress = saverLoader;

        private void Awake()
        {
            _prevColor = _nameField.image.color;
        } 

        private void OnEnable()
        {
            _genderSellector.CurrentGender = _progress.Progress.Gender;
            DeSubscribe();
            UpdateView(default);
            _activeEdit = false;
            SetEditMode();
            Subscribe();
        }

        public void ToggleEditMode()
        {
            _activeEdit = !_activeEdit;
            SetEditMode();
            if (_activeEdit)
            {
                _ageField.image.color = _onEditColor;
                _nameField.image.color = _onEditColor;
                _weightField.image.color = _onEditColor;
            }
            else
            {
                _ageField.image.color = _prevColor;
                _nameField.image.color = _prevColor;
                _weightField.image.color = _prevColor;
            }
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

        private void DeSubscribe()
        {
            _nameField.onValueChanged.RemoveAllListeners();
            _ageField.onValueChanged.RemoveAllListeners();
            _weightField.onValueChanged.RemoveAllListeners();
            _genderSellector.GenderChanged -= SaveData;
            _genderSellector.GenderChanged -= UpdateView;
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
            _viewSetted = true;
        }
    }
}
