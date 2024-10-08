namespace ClassLibrary1
{
    public class Product
    {
        ////Java way
        //private int id;
        //public void SetId(int id)
        //{
        //    this.id = id;
        //}
        //public int getId()
        //{
        //    return this.id;
        //}

        public int Id { get; set; };
        public string Name { get; set; };
    }

}
