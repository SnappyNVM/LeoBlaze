using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GenderSellector : MonoBehaviour
    {
        [SerializeField] private Button _maleGenderButton;
        [SerializeField] private TMP_Text _maleGenderButtonText;
        [SerializeField] private Button _femaleGenderButton;
        [SerializeField] private TMP_Text _femaleGenderButtonText;
        [SerializeField] private Color _onSellectColor;

        private Gender _currentGender = Gender.Male;

        public Gender CurrentGender => _currentGender;

        private void OnEnable() => 
            UpdateButtons();

        public void SellectGender(int id)
        {
            _currentGender = (Gender)id;
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            if (_currentGender == Gender.Male)
            {
                _maleGenderButton.image.color = _onSellectColor;
                _maleGenderButtonText.color = Color.white;
                _femaleGenderButton.image.color = Color.white;
                _femaleGenderButtonText.color = Color.black;
            }
            else
            {
                _femaleGenderButton.image.color = _onSellectColor;
                _femaleGenderButtonText.color = Color.white;
                _maleGenderButton.image.color = Color.white;
                _maleGenderButtonText.color = Color.black;
            }
        }
    }
}
