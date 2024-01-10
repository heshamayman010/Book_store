namespace BookStore2.Models
{
    public class ReadersRepo:Readers
    {
        private readonly Appdbcontext context;

        // CRUD
        public ReadersRepo(Appdbcontext _context)
        {
            context = _context;
        }



        // create 

        public void Adduser(string name ) {


            //        public int Id { get; set; }
            //public string Name { get; set; }

            //public List<Books> Book { get; set; }

            var user = new Readers();
            user.Name = name;

            using (var context =new Appdbcontext())
            {

                context.Readers.Add(user);
                context.SaveChanges();
            }




    }
        public void Deleteuser(int id)
        {
            var usertodelet=context.Readers.FirstOrDefault(x => x.Id == id);
            context.Readers.Remove(usertodelet);
           
            context.SaveChanges();

        }

        public Readers getuser(int id)
        {
            var user=context.Readers.FirstOrDefault(x=>x.Id == id);
            return user;
        }


        public List<Readers> getAllusers() { 
        
        
        
        List<Readers>all=context.Readers.ToList();
            return all;
        
        }


        public void updateuser(int id ,string name) {
        
        
        var usertoupdate=context.Readers.FirstOrDefault(x=>x.Id==id);
            usertoupdate.Name= name;
            context.SaveChanges();
        }

        public void readbook(int readerid,int bookid)
        {
        var thereader=    context.Readers.FirstOrDefault(x => x.Id == readerid);

            var thebook = context.Books.FirstOrDefault(x => x.Id == bookid);
            thebook.readerid= readerid;
            context.SaveChanges();

        }


}
}
