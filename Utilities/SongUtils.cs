using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Books.Entities;

namespace Books.Utilities
{
    public class SongUtils 
    {
        public void GetSongs() 
        {
            List<Song> songList = new List<Song>();
            
            Song song = new Song();
            song.Artist = "Eric Clapton";
            song.Title = "Heaven";
            songList.Add(song);
            Song song2 = new Song();
            song2.Artist = "Dire Straits";
            song2.Title = "MTV";
            songList.Add(song2);
            
            MemoryStream ms = new MemoryStream();  
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Song>));  
            ser.WriteObject(ms, songList);  
            byte[] json = ms.ToArray();  
            ms.Close();  
            string jsonString = Encoding.UTF8.GetString(json, 0, json.Length);              
            Console.WriteLine($"Song serialize = {jsonString}");
            
            List<Song> songList2 = new List<Song>();
            MemoryStream ms2 = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));  
            DataContractJsonSerializer ser2 = new DataContractJsonSerializer(typeof(List<Song>));  
            songList2 = ser.ReadObject(ms2) as List<Song>;  
            ms2.Close();  
            foreach(Song s in songList2)
            {
            Console.WriteLine($"Song deserialize = {s.Title} {s.Artist}");
            }
        }
    }
}