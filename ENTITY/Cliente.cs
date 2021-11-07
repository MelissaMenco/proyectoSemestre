namespace ENTITY
{
    public class Cliente
    {
        public string Cedula { get; set; }
        public string Primernombre { get; set; }
        public string Segundonombre { get; set; }
        public string Primerapellido { get; set; }
        public string Segundoapellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Tipodeaceite { get; set; }
        public string Referenciaaceite { get; set; }
        public string Tipofiltro { get; set; }
        public string Referenciafiltro { get; set; }

        public override string ToString()
        {
            return $"{Cedula};{Primernombre};{Segundonombre};{Primerapellido};{Segundoapellido};{Telefono};{Email};{Marca};{Modelo};{Tipodeaceite};{Tipofiltro};{Referenciaaceite};{Referenciafiltro}";
        }
    }
}
