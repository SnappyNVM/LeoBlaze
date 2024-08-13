using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ProfileGenderSellector : MonoBehaviour
    {
        [SerializeField] private Button _changeGenderButton;
        [SerializeField] private Image _changeGenderButtonImage;

        public Gender CurrentGender;
        public event Action<string> GenderChanged;

        public void SetActive(bool activeEdit)
        {
            if (activeEdit == false)
                _changeGenderButton.onClick.RemoveAllListeners();
            else
                _changeGenderButton.onClick.AddListener(ChangeGender);
        }

        private void ChangeGender()
        {
            if (CurrentGender == Gender.Male)
                CurrentGender = Gender.Female;
            else
                CurrentGender = Gender.Male;
            GenderChanged?.Invoke(default);
        }
    }
}
