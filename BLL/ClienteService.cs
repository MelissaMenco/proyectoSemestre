using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using DAL;
namespace BLL
{
    public class ClienteService
    {

        private static ClienteRepository repository = new ClienteRepository();
        public ClienteService()
        {
            repository = new ClienteRepository();

        }
        public string Guardar(Cliente cliente)
        {
            repository.Guardar(cliente);
            return $" El dato se guardo exitosamente";
        }
       

        public static IList<Cliente> ConsultarTodos()
        {
            return repository.Consultar();
        }

        public Cliente BuscarID(string cedula)
        {
            try
            {
                return repository.Buscar(cedula);
            }
            catch (Exception e)
            {
                string mensaje = " ERROR" + e.Message;
                return null;
            }
        }

        public string Modificar(Cliente cliente)
        {
            try
            {
                if (repository.Buscar(cliente.Cedula) != null)
                {
                    repository.Modificar(cliente);
                    return $"la cedula numero: {cliente.Cedula} ha sido modificada con exito!";

                }
                return $"La cedula numero: {cliente.Cedula} no se encuentra registrada, por favor verifique!";

            }
            catch (Exception e)
            {

                return "Error de datos" + e.Message;
            }
        }

        public string Eliminar(string cedula)
        {
            try
            {
                if (repository.Buscar(cedula) != null)
                {
                    repository.Eliminar(cedula);
                    return $"se elimino el cliente: {cedula} correctamente";
                }
                return $"La cedula no está registrada en el sistema";
            }
            catch (Exception e)
            {
                return $"ERROR" + e.Message;
            }
        }


    }

}
