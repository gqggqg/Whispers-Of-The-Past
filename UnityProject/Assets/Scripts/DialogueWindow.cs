using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueWindow : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI _nameText;

    [SerializeField]
    private TextMeshProUGUI _text;

    [SerializeField]
    private string[] _lines;

    [SerializeField]
    private float _textSpeed;

    [SerializeField]
    private string _name;

    private int _index;
    // Start is called before the first frame update
    void Start() {
        _nameText.text = string.Empty;
        _text.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (_text.text == _lines[_index]) {
                IsNextLine();
            } else {
                StopAllCoroutines();
                _text.text = _lines[_index];
            }
        }
    }

    public void StartDialogue() {
        _nameText.text = _name;
        _index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() {
        foreach (char c in _lines[_index].ToCharArray()) {
            _text.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
    }

    void IsNextLine() {
        if (_index < _lines.Length - 1) {
            _index++;
            _text.text = string.Empty;
            StartCoroutine(TypeLine());
        } else {
            gameObject.SetActive(false);
        }
    }
}
