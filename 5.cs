public class Solution {

    private int _biggestSize = 0;
    private int _biggestIndex = 0;
    private string _s;
    public string LongestPalindrome (string s) {
        _s = s;
        Checker (1, 0);
        for (int i = 0; i < _s.Length; i++) {
            Checker (i, 0);
            Checker (i, 1);
        }
        if (s.Length == 0) {
            return string.Empty;
        }
        return s.Substring (_biggestIndex, _biggestSize + 1);
    }
    private void Checker (int index, int size) {
        if (index < 0) {
            return;
        }
        if (size == 0 || (index + size < _s.Length && _s[index + size] == _s[index])) {
            if (size > _biggestSize) {
                _biggestSize = size;
                _biggestIndex = index;
            }

            Checker (index - 1, size + 2);
        }
    }

}