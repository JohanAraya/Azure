namespace ComponentesMVC._1_Entities
{
    public class Usuario
    {
        public Guid _id { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
       // public string ImagenURL { get; set; }
        public string buscar_tipo { get; set; }
        public string buscar_raza { get; set; }
        public string contrasenia { get; set; }
        //public Mascota mascota { get; set; }
    }
}
