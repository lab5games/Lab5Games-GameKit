using TMPro;

namespace Lab5Games
{
    public static class UnityExtensions
    {
        public static void SetText(this TextMeshPro textComponent, object obj)
        {
            textComponent.text = obj.ToString();
        }

        public static void SetText(this TextMeshProUGUI textComponent, object obj)
        {
            textComponent.text = obj.ToString();
        }
    }
}
