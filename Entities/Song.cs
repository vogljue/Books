using System.Runtime.Serialization;

namespace Books.Entities
{
    [DataContract] 
    public class Song 
    {
        [DataMember] 
        public string Artist;
        
        [DataMember] 
        public string Title;
        
        public Song()
        {
            Artist = string.Empty;
            Title = string.Empty;
        }
    }
}