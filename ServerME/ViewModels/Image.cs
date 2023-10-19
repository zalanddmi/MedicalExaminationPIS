using System.Drawing;
using System.Drawing.Imaging;


namespace ServerME.ViewModels
{
    public class Image
    {
        public string? filePath { get; set; }
        public byte[]? data { get; set; }
        public bool IsRemoved => (filePath == null && data != null);

        public Image()
        {

        }
        public Image(byte[] data)
        {
            this.data = data;
        }
        public Image(string path, byte[] data)
        {
            this.filePath = path;
            this.data = data;
        }
        
        public void RemovePhoto()
        {
            data = null;
        }

        public string SaveImage(string directory)
        {
            if (filePath != null &&  File.Exists(filePath))
            {
                if (data == null)
                {
                    File.Delete(filePath);
                }
            }
            if (data == null)
                throw new ArgumentNullException();


            var stream = new MemoryStream(data);
            var currentPhoto = System.Drawing.Image.FromStream(stream);
            var path = directory + $"/photo_{DateTime.Now.ToString()}_.png";
            currentPhoto.Save(path, ImageFormat.Png);

    
            return path;
        }
    }
}
