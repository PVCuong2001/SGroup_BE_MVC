namespace Test1.ViewModel
{
    public class TestHello
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string CreatedAt{get ; set;}
        public string ImgUrl{get ; set;}
        public string Format{get ; set;}
        public string Height{get ; set;}
        public string PublicId{get ; set;}

        public string ResourceType{get ; set;}
            public string SecureUrl{get ; set;}
                public string Signature{get ; set;}
                    public string Type{get ; set;}
                        public string Url{get ; set;}
        
                        public int Version{get ; set;}

                        public string Width{get ; set;}
        public override string ToString()
        {
            return base.ToString();
        }

    }
}