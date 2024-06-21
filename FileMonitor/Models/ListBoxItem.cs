namespace FileMonitor.Models;

public class ListBoxItem
{
    public string Text { get; set; }
    public bool Bold { get; set; }

    public ListBoxItem(string text, bool bold)
    {
        Text = text;
        Bold = bold;
    }

    public override string ToString()
    {
        return Text;
    }
}