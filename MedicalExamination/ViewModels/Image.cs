namespace MedicalExamination.ViewModels
{
    public class Image
    {
        public string filePath { get; set; }
        public byte[] data { get; set; }
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
    }
}
