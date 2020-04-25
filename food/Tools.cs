using System.Text.RegularExpressions;
namespace food
{
    static class Tools
    {
        static internal string StringBonify(string old)
        {
            Regex rx = new Regex("[\\/:\"*?<>|]+");
            return rx.Replace(old, "");
        }
    }
}
