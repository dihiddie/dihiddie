using dihiddie.DAL.Post.EF.Context;
using System;
using System.Text;

namespace dihiddie.DAL.Post.EF.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var context = new DihiddieContext();
                context.Add(new Context.Post() {Title = "1111", Content = Encoding.UTF8.GetBytes("1111"), PreviewImagePath = "111"});
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }
    }
}
