
namespace FileMonitor;

public partial class FileMonitorBase : Form
{
    private FileSystemWatcher fileWatcher;
    private System.Windows.Forms.Timer timer;
    private string targetFilePath;
    private string lastReadContent;
    private bool changeDetected;
    private System.Windows.Forms.RichTextBox textBoxChange;
    public FileMonitorBase()
    {
        InitializeComponent();
        InitializeFileWatcher();
        InitializeTimer();
    }

    private void InitializeFileWatcher()
    {
        fileWatcher = new FileSystemWatcher
        {
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size,
            Filter = "*.txt"
        };
        fileWatcher.Changed += OnChanged;
    }

    private void InitializeTimer()
    {
        timer = new System.Windows.Forms.Timer
        {
            Interval = 15000 // 15 seconds
        };
        timer.Tick += Timer_Tick;
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        if (changeDetected)
        {
            changeDetected = false;
            ReportChange();
        }
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        changeDetected = true;
    }

    private void ReportChange()
    {
        if (File.Exists(targetFilePath))
        {
            string currentContent = File.ReadAllText(targetFilePath);
            if (currentContent != lastReadContent)
            {
                string previousContent = lastReadContent;
                lastReadContent = currentContent;

                textBoxChanges.Clear(); // Clear previous contents in the text box

                AppendToTextBox($"File changed at {DateTime.Now}\r\n", true);
                AppendToTextBox("Previous Content:\r\n", true);
                AppendToTextBox(previousContent + "\r\n", false);
                AppendToTextBox("Current Content:\r\n", true);
                AppendToTextBox(currentContent + "\r\n", false);
            }
        }
    }

    private void AppendToTextBox(string text, bool bold)
    {
        if (textBoxChanges.InvokeRequired)
        {
            textBoxChanges.Invoke(new Action(() =>
            {
                int start = textBoxChanges.TextLength;
                textBoxChanges.AppendText(text);
                int end = textBoxChanges.TextLength;

                // Apply formatting to the appended text
                textBoxChanges.Select(start, end - start);
                textBoxChanges.SelectionFont = new Font(textBoxChanges.Font, bold ? FontStyle.Bold : FontStyle.Regular);
                textBoxChanges.SelectionColor = bold ? Color.Black : Color.Gray;
                textBoxChanges.SelectionLength = 0; // Reset selection length
                textBoxChanges.SelectionStart = textBoxChanges.TextLength; // Reset selection start
            }));
        }
        else
        {
            int start = textBoxChanges.TextLength;
            textBoxChanges.AppendText(text);
            int end = textBoxChanges.TextLength;

            // Apply formatting to the appended text
            textBoxChanges.Select(start, end - start);
            textBoxChanges.SelectionFont = new Font(textBoxChanges.Font, bold ? FontStyle.Bold : FontStyle.Regular);
            textBoxChanges.SelectionColor = bold ? Color.Black : Color.Gray;
            textBoxChanges.SelectionLength = 0; // Reset selection length
            textBoxChanges.SelectionStart = textBoxChanges.TextLength; // Reset selection start
        }
    }


    private void btnBrowse_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog ofd = new OpenFileDialog())
        {
            ofd.Filter = "Text files (*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                targetFilePath = ofd.FileName;
                txtFilePath.Text = targetFilePath;
                fileWatcher.Path = Path.GetDirectoryName(targetFilePath);
                fileWatcher.Filter = Path.GetFileName(targetFilePath);
                fileWatcher.EnableRaisingEvents = true;
                timer.Start();
                lastReadContent = File.ReadAllText(targetFilePath);

                // Display initial content if desired
                textBoxChanges.Clear();
                AppendToTextBox($"Initial file content loaded at {DateTime.Now}\r\n", true);
                AppendToTextBox(lastReadContent + "\r\n", false);
            }
        }
    }

   

    private void toolStripButtonBrowse_Click(object sender, EventArgs e)
    {
        btnBrowse_Click(sender, e);
    }
   
}


