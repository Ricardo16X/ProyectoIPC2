using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_IPC2.Models
{
    public class GestionTrabajador
    {
        private int codTipo { get; set; }
        private string dpi { get; set; }
        private string nombre { get; set; }
        private string apellido { get; set; }
        private string fechaNacimiento { get; set; }
        private string email { get; set; }
        private string telefono { get; set; }
        private string usuario { get; set; }
        private string password { get; set; }
        private string palabraClave { get; set; }
        public int estadoCuenta { get; set; }

        //Crear nuevo trabajador
        public GestionTrabajador(int codTipo, string dpi, string nombre, string apellido, string fechaNacimiento, string email, string telefono, string usuario, string password, string palabraClave)
        {
            this.codTipo = codTipo;
            this.dpi = dpi;
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNacimiento = fechaNacimiento;
            this.email = email;
            this.telefono = telefono;
            this.usuario = usuario;
            this.password = password;
            this.palabraClave = palabraClave;
            estadoCuenta = 1;
        }
        public GestionTrabajador()
        {

        }
        //Aplica solo a clientes;
        public GestionTrabajador(string dpi, string nombre, string apellido, string fechaNacimiento, string email, string telefono, string usuario, string pass, string palabraClave)
        {
            this.dpi = dpi;
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNacimiento = fechaNacimiento;
            this.email = email;
            this.telefono = telefono;
            this.usuario = usuario;
            this.password = pass;
            this.palabraClave = palabraClave;
            estadoCuenta = 1;
        }

        //Escribir nuevo trabajador a base de datos.
        public void escribirInformacion(GestionTrabajador nuevoTrabajador)
        {
            SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
            SqlCommand comando = new SqlCommand("INSERT INTO trabajador(dpi,nombre,apellido,fechaNacimiento,correo,telefono,usuario,contraseña,palabraClave,estadoCuenta) " +
                "values('" + nuevoTrabajador.dpi + "'," +
                        "'" + nuevoTrabajador.nombre + "'," +
                        "'" + nuevoTrabajador.apellido + "'," +
                        "'" + nuevoTrabajador.fechaNacimiento + "'," +
                        "'" + nuevoTrabajador.email + "'," +
                        "'" + nuevoTrabajador.telefono + "'," +
                        "'" + nuevoTrabajador.usuario + "'," +
                        "'" + nuevoTrabajador.password + "'," +
                        "'" + nuevoTrabajador.palabraClave + "'," + 
                        nuevoTrabajador.estadoCuenta + ")", conexion);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        //Registrar Cliente
        public void registrarCliente(GestionTrabajador nuevoCliente)
        {
            SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
            SqlCommand comando = new SqlCommand("INSERT INTO cliente(dpi,nombre,apellido,fechaNacimiento,correo,telefono,usuario,contraseña,palabraClave,estadoCuenta) " +
                "values('" + nuevoCliente.dpi + "'," +
                        "'" + nuevoCliente.nombre + "'," +
                        "'" + nuevoCliente.apellido + "'," +
                        "'" + nuevoCliente.fechaNacimiento + "'," +
                        "'" + nuevoCliente.email + "'," +
                        "'" + nuevoCliente.telefono + "'," +
                        "'" + nuevoCliente.usuario + "'," +
                        "'" + nuevoCliente.password + "'," +
                        "'" + nuevoCliente.palabraClave + "'," +
                         nuevoCliente.estadoCuenta + ")", conexion);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        //Modificar Cliente;
        public void actualizarCliente(int codCliente, string dpi, string nombre, string apellido, string fechaNacimiento, string email, string telefono, string usuario, string pass, string palabraClave)
        {
            SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
            SqlCommand comando = new SqlCommand("UPDATE cliente SET dpi = '" + dpi + "'," +
                "nombre = '" + nombre + "'," +
                "apellido = '" + apellido + "'," +
                "fechaNacimiento = '" + fechaNacimiento + "'," +
                "correo ='" + email + "'," +
                "telefono = '" + telefono + "'," +
                "usuario = '" + usuario + "'," +
                "contraseña = '" + pass + "'," +
                "palabraClave = '" + palabraClave + "' " +
                "where idCliente = " + codCliente, conexion);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        //Eliminar Cliente
        public void eliminarCliente(int codCliente)
        {
            SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
            SqlCommand comando = new SqlCommand("update cliente set estadoCuenta = " + 0 + " where idCliente = " + codCliente, conexion);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}