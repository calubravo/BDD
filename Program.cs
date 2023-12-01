using EjercicioVentas.NewFolder;
using Microsoft.EntityFrameworkCore;

namespace EjercicioVentas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stringConnection = @"Data Source=DESKTOP-2KMVVF5\MSSQLSERVER01;Initial Catalog=VentasTP;Integrated Security=True;Trust Server Certificate=True";
            var options = new DbContextOptionsBuilder<DataBaseContext>().UseSqlServer(stringConnection).Options;
            var context = new DataBaseContext(options);

            string path = @"C:\Users\Nicolas-PC\Desktop\CDA\EjercicioVentas\data.txt";
            string[] data = File.ReadAllLines(path);

            var fechaProceso = context.Parametria.FirstOrDefault();
            string fechaFormato="";
            int I =1;
            if(fechaProceso!=null)
            {
                DateTime fecha_proceso = fechaProceso.Fecha.Date;
                fechaFormato = fecha_proceso.ToString("yyyy-MM-dd");
            }

            foreach(string line in data)
            {   
                string fecha = line.Substring(0, 8);
                string codigo = line.Substring(8, 3).Trim();
                float venta =float.Parse( line.Substring(11, 11));
                string letra = line.Substring(22, 1);
              
                string FormatoFecha = $"{fecha.Substring(0, 4)}-{fecha.Substring(4, 2)}-{fecha.Substring(6, 2)}";

                var newVendedor = new Vendedor();
                              
                var rechazado = new Rechazo();

                if (codigo!= null && codigo !="")
                {
                    if (FormatoFecha.Equals(fechaFormato))
                    {
                        if (letra == "S" || letra == "N")
                        {
                            newVendedor.Fecha = DateTime.Parse(FormatoFecha);
                            newVendedor.Codigo = codigo;
                            newVendedor.Venta = venta;
                            if (letra == "S")
                            {
                                newVendedor.VentaEmpresaGrande = true;
                              
                            }
                            else
                            {
                                newVendedor.VentaEmpresaGrande = false;
                               
                            }
                            context.Vendedor.Add(newVendedor);

                        }
                        else
                        {
                            string motivo = "Empresa no especificada";
                            rechazado.Motivo = motivo;
                            rechazado.Linea = I;
                            context.Rechazo.Add(rechazado);
                        }
                        

                    }
                    else
                    {
                        string motivo = "La fecha no corresponde a la parametrizada ";
                        rechazado.Motivo = motivo;
                        rechazado.Linea = I;
                        context.Rechazo.Add(rechazado);
                    } 

                }
                else
                {
                    string motivo = "Codigo de vendedor invalido";
                    rechazado.Motivo = motivo;
                    rechazado.Linea = I;
                    context.Rechazo.Add(rechazado);

                }


                I++;
            }
            context.SaveChanges();


            // var resultado = context.Parametria.FirstOrDefault();

        }
    }
}