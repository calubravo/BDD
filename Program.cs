using EjercicioVentas.NewFolder;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace EjercicioVentas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stringConnection = @"Data Source=DESKTOP-2KMVVF5\MSSQLSERVER01;Initial Catalog=""Ejercicio Ventas"";Integrated Security=True;Trust Server Certificate=True";
            var options = new DbContextOptionsBuilder<DataBaseContext>().UseSqlServer(stringConnection).Options;
            var context = new DataBaseContext(options);
            #region CARGA BD



            //string path = @"C:\Users\Nicolas-PC\Desktop\CDA\EjercicioVentas\data.txt";
            //    string[] data = File.ReadAllLines(path);

            //    var fechaProceso = context.Parametria.FirstOrDefault();
            //    string fechaFormato="";
            //    int I =1;
            //    if(fechaProceso!=null)
            //    {
            //        DateTime fecha_proceso = fechaProceso.Fecha.Date;
            //        fechaFormato = fecha_proceso.ToString("yyyy-MM-dd");
            //    }

            //    foreach(string line in data)
            //    {   
            //        string fecha = line.Substring(0, 8);
            //        string codigo = line.Substring(8, 3).Trim();
            //        decimal venta =decimal.Parse( line.Substring(11, 11),CultureInfo.InvariantCulture);
            //        string letra = line.Substring(22, 1);

            //        string FormatoFecha = $"{fecha.Substring(0, 4)}-{fecha.Substring(4, 2)}-{fecha.Substring(6, 2)}";

            //        var newVendedor = new Vendedor();

            //        var rechazado = new Rechazo();

            //        if (codigo!= null && codigo !="")
            //        {
            //            if (FormatoFecha.Equals(fechaFormato))
            //            {
            //                if (letra == "S" || letra == "N")
            //                {
            //                    newVendedor.Fecha = DateTime.Parse(FormatoFecha);
            //                    newVendedor.Codigo = codigo;
            //                    newVendedor.Venta = venta;
            //                    if (letra == "S")
            //                    {
            //                        newVendedor.VentaEmpresaGrande = true;

            //                    }
            //                    else
            //                    {
            //                        newVendedor.VentaEmpresaGrande = false;

            //                    }
            //                    context.Vendedor.Add(newVendedor);

            //                }
            //                else
            //                {
            //                    string motivo = "Empresa no especificada";
            //                    rechazado.Motivo = motivo;
            //                    rechazado.Linea = I;
            //                    context.Rechazo.Add(rechazado);
            //                }


            //            }
            //            else
            //            {
            //                string motivo = "La fecha no corresponde a la parametrizada ";
            //                rechazado.Motivo = motivo;
            //                rechazado.Linea = I;
            //                context.Rechazo.Add(rechazado);
            //            } 

            //        }
            //        else
            //        {
            //            string motivo = "Codigo de vendedor invalido";
            //            rechazado.Motivo = motivo;
            //            rechazado.Linea = I;
            //            context.Rechazo.Add(rechazado);

            //        }


            //        I++;
            //    }
            //    context.SaveChanges();

            #endregion
            bool exit = false;
            while (!exit) {
                Console.Clear();
            Console.WriteLine("Eliga una opcion:");
            Console.WriteLine("[1] - Listar los vendedores que hayan superado los $100.000");
            Console.WriteLine("[2] - Listar los vendedores que no hayan superado los $100.000");
            Console.WriteLine("[3] - Listar los vendedores con al menos 1 venta a empresa grande");
                int seleccion = int.Parse(Console.ReadLine()!);

                

                 if (seleccion == 1) // vendedores que vendieron mas de 100k
                {
                    Console.Clear();
                    var ListaVendedores = context.Vendedor
                                              .GroupBy(ven => ven.Codigo)
                                              .Where(v => v.ToList().Sum(s => s.Venta) >= 100000m)
                                              .Select(s => new { s.Key, TotalVenta = s.ToList().Sum(s => s.Venta) }) //clase anonima para guardar los totales de ventas
                                              .ToList();
                    if (ListaVendedores.Count() > 0)
                    {
                        foreach (var vendedor in ListaVendedores)
                        {
                            Console.WriteLine($"El vendedor {vendedor.Key} vendió {vendedor.TotalVenta:C}");
                        }
                    }
                    else { Console.WriteLine("Ningun vendedor supero ese monto"); }

                    Console.ReadKey();
                }
                else if (seleccion == 2)// vendedores que vendieron menos de 100k
                {
                    Console.Clear();

                    var ListaVendedoresMenos = context.Vendedor
                                                .GroupBy(ven => ven.Codigo)
                                                .Where(v => v.ToList().Sum(s => s.Venta) < 100000m)
                                                .Select(s => new { s.Key, TotalVenta = s.ToList().Sum(s => s.Venta) }) //clase anonima para guardar los totales de ventas
                                                .ToList();
                    if (ListaVendedoresMenos.Count() > 0)
                    {
                        foreach (var vendedor in ListaVendedoresMenos)
                        {
                            Console.WriteLine($"El vendedor {vendedor.Key} vendió {vendedor.TotalVenta:C}");
                        }
                    }
                    else { Console.WriteLine("Ningun vendedor esta por debajo ese monto"); }

                    Console.ReadKey();
                }
                else if (seleccion == 3)// vendedores que vendieron al menos una a en empresa grande
                {
                    Console.Clear();

                    var ListaVendedores = context.Vendedor
                                                .GroupBy(ven => ven.Codigo)
                                                .Where(v => v.ToList().Any(a => a.VentaEmpresaGrande))
                                                .Select(s => new { s.Key, TotalVenta = s.ToList().Sum(s => s.Venta) }) //clase anonima para guardar los totales de ventas
                                                .ToList();
                    if (ListaVendedores.Count() > 0)
                    {
                        foreach (var vendedor in ListaVendedores)
                        {
                            Console.WriteLine($"{vendedor.Key} ");
                        }
                    }
                    else { Console.WriteLine("Ningun vendedor ha vendido a empresas grandes"); }

                    Console.ReadKey();
                }
               
            }
        }
    }
}