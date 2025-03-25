using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

public class ImageMetadataHelper
{
    // Get Date Taken
    public static DateTime? GetDateTaken(string imagePath)
    {
        using (Image image = Image.FromFile(imagePath))
        {
            const int DateTakenTag = 0x9003;

            if (image.PropertyIdList.Contains(DateTakenTag))
            {
                PropertyItem propItem = image.GetPropertyItem(DateTakenTag);
                string dateTakenStr = System.Text.Encoding.ASCII.GetString(propItem.Value).Trim('\0');

                if (DateTime.TryParseExact(dateTakenStr, "yyyy:MM:dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime dateTaken))
                {
                    return dateTaken;
                }
            }
            return null;
        }
    }

    // Set Date Taken
    public static void SetDateTaken(string imagePath, DateTime dateTaken)
    {
        using (Image image = Image.FromFile(imagePath))
        {
            const int DateTakenTag = 0x9003;

            string dateTakenStr = dateTaken.ToString("yyyy:MM:dd HH:mm:ss");
            byte[] dateTakenBytes = System.Text.Encoding.ASCII.GetBytes(dateTakenStr + '\0');

            PropertyItem propItem = image.PropertyItems[0];
            propItem.Id = DateTakenTag;
            propItem.Type = 2;
            propItem.Value = dateTakenBytes;
            propItem.Len = dateTakenBytes.Length;

            image.SetPropertyItem(propItem);
            image.Save(imagePath);
        }
    }
}
