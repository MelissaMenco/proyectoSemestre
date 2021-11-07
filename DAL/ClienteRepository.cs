using System.Collections.Generic;
using System.IO;
using System.Linq;
using ENTITY;

namespace DAL
{
    public class ClienteRepository
    {
        private string ruta = @"clientes.txt";
        private List<Cliente> clientes;
        public ClienteRepository()
        {
            clientes = new List<Cliente>();

        }

        public void Guardar(Cliente cliente)
        {
            FileStream fileStream = new FileStream(ruta, FileMode.Append);
            StreamWriter writer = new StreamWriter(fileStream);
            writer.WriteLine(cliente.ToString());
            writer.Close();
            fileStream.Close();
        }
        public List<Cliente> Consultar()
        {
            clientes.Clear();
            FileStream fileStream = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader streamReader = new StreamReader(fileStream);
            string linea = string.Empty;

            while ((linea = streamReader.ReadLine()) != null)
            {
                Cliente cliente = new Cliente();
                string[] datos = linea.Split(';');
                cliente.Cedula = datos[0];
                cliente.Primernombre = datos[1];
                cliente.Segundonombre = datos[2];
                cliente.Primerapellido = datos[3];
                cliente.Segundoapellido = datos[4];
                cliente.Telefono = datos[5];
                cliente.Email = datos[6];
                cliente.Marca = datos[7];
                cliente.Modelo = datos[8];
                cliente.Tipodeaceite = datos[9];
                cliente.Referenciaaceite = datos[10];
                cliente.Tipofiltro = datos[11];
                cliente.Referenciafiltro = datos[12];
                clientes.Add(cliente);
            }

            fileStream.Close();
            streamReader.Close();
            return clientes;
        }

        public Cliente Buscar(string cedula)
        {
            clientes.Clear();
            clientes = Consultar();
            foreach (var item in clientes)
            {
                if (item.Cedula.Equals(cedula))
                {
                    return item;
                }
            }
            return null;
        }

        public void Modificar(Cliente cliente)
        {
            clientes.Clear();
            clientes = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in clientes)
            {
                if (item.Cedula != cliente.Cedula)
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(cliente);
                }
            }
        }

        public void Eliminar(string cedula)
        {
            clientes.Clear();
            clientes = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in clientes)
            {
                if (item.Cedula != cedula)
                {
                    Guardar(item);
                }
            }
        }

    }
}
