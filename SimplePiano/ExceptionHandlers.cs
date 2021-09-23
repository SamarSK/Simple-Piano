using System.Windows.Forms;

public class ExceptionHandlers
{
    public ExceptionHandlers()
    {

    }

    /// <summary>
    /// Show error window for "Path does not exist" exception
    /// </summary>
    public void NotFound(string path)
    {
        MessageBox.Show(@"An error occured when trying to execute " + path +
                " Path does not exist.", "Path does not exist.",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    /// <summary>
    /// Show error window for "Invalid script" exception
    /// </summary>
    /// <param name="linecount">A number of line on which the error occured</param>
    public void InvalidScript(int linecount, string fileName)
    {
        MessageBox.Show(@"An error occured on line " + linecount + " in " + fileName, "Invalid script.",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
