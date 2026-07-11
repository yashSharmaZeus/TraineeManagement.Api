namespace TraineeManagement.Api.Helpers;


public static class FileExtensionHelper
{
    public static bool isValidFile(string fileName)
    {
        List<string> validExt = [".pdf", ".zip", ".png", ".jpg", ".jpeg"];
        string extension = Path.GetExtension(fileName);
        if (!validExt.Contains(extension.ToLower()))
        {
            return false;
        }
        return true;
    }
}