using System.Text.Json;

namespace myGuestbook
{
    public class GuestBook
    {
        private string filename = @"guestbook.json";
        private List<Post> posts = new List<Post>();

        public GuestBook()
        {
            if (File.Exists(filename) == true)
            {
                string jsonString = File.ReadAllText(filename);
                posts = JsonSerializer.Deserialize<List<Post>>(jsonString)!;
            }
        }
        public Post addPost(string name, string inlagg)
        {
            Post obj = new Post();
            obj.Name = name;
            obj.Inlagg = inlagg;

            posts.Add(obj);
            marshal();
            return obj;
        }

        public int delPost(int index)
        {
            posts.RemoveAt(index);
            marshal();
            return index;
        }

        public List<Post> getPosts()
        {
            return posts;
        }

        private void marshal()
        {
            // Serialize all the objects and save to file
            var jsonString = JsonSerializer.Serialize(posts);
            File.WriteAllText(filename, jsonString);
        }
    }
}