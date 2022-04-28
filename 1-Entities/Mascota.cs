namespace ComponentesMVC._1_Entities
{
    public class Mascota
    {
        //HasNoKey[]
        public Guid _id { get; set; }

        public string correoUsuraio { get; set; }

        public string nombre { get; set; }

        public string raza { get; set; }

        //public string[] fotoUrl { get; set; }

        public string tipo { get; set; }

        public string sexo { get; set; }
    }
}
