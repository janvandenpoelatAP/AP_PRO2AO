// See https://aka.ms/new-console-template for more information

using EFExtra;

using (BlogDbContext blogDbContext = new BlogDbContext())
{
    Blog blog = new Blog()
    {
        Name = "testblog",
        Posts = new List<Post>(),
    }; 
    blogDbContext.Blogs.Add(blog);
    blogDbContext.SaveChanges();
} 