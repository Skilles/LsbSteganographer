namespace Stenographer;

public partial class Steganographer : Form
{
    private readonly LsbProcessor _lsbProcessor;

    public Steganographer()
    {
        InitializeComponent();
        _lsbProcessor = new LsbProcessor(pictureBox.Width, pictureBox.Height);
        UpdateStatus();
    }

    private void encodeButton_Click(object sender, EventArgs e)
    {
        try
        {
            _lsbProcessor.EncodeText(textBox.Text);
        }
        catch (InvalidOperationException er)
        {
            Console.WriteLine(er);
            return;
        }

        pictureBox.Image?.Dispose();
        pictureBox.Image = _lsbProcessor.GetImage();
        UpdateStatus();
    }

    private void decodeButton_Click(object sender, EventArgs e)
    {
        try
        {
            var text = _lsbProcessor.DecodeText();
            textBox.Text = text;
        }
        catch (InvalidOperationException er)
        {
            Console.WriteLine(er);
        }

        UpdateStatus();
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (saveFileDialog.ShowDialog() == DialogResult.OK) _lsbProcessor.SaveImage(saveFileDialog.FileName);
    }

    private void loadToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog() == DialogResult.OK)
            if (File.Exists(openFileDialog.FileName))
            {
                _lsbProcessor.LoadImage(openFileDialog.FileName);
                pictureBox.Image?.Dispose();
                pictureBox.Image = _lsbProcessor.GetImage();
                UpdateStatus();
                saveFileDialog.FileName = $"{Path.GetFileNameWithoutExtension(openFileDialog.FileName)}_encoded.png";
            }
    }

    private void UpdateStatus()
    {
        statusLabel.Text = $@"Status: {_lsbProcessor.Status}";
    }
}