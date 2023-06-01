namespace Forum.Data.Seeding
{
    using Models;

    class PostSeeder
    {
        internal Post[] GeneratePosts()
        {
            ICollection<Post> posts = new HashSet<Post>();
            Post currentPost;

            currentPost = new Post()
            {
                Title = "My first post",
                Content = "I SAY first post"
            };
            posts.Add(currentPost);

            currentPost = new Post()
            {
                Title = "My second post",
                Content = "I SAY second post"
            };
            posts.Add(currentPost);

            currentPost = new Post()
            {
                Title = "My thitd post",
                Content = "I SAY third post"
            };
            posts.Add(currentPost);
            return posts.ToArray();
        }
    }
}