//class that handles the individual words in the scriptures
//also handles the boolean of whether the word is hidden or not
namespace Develope03;
class Word
{
    //attributes
    private string _text;
    private bool _hidden;

    //getters and setters
    public string Text
    {
        get { return _text; }
        set { _text = value; }
    }

    public bool Hidden
    {
        get { return _hidden; }
        set { _hidden = value; }
    }

    public Word(string text)
    {
        Text = text;
        _hidden = false;
    }

    //setting visibility
    public void setIsVisible()
    {
        _hidden = true;
    }
}